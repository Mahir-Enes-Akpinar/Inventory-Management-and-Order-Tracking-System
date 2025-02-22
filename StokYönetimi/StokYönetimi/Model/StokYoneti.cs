using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class StokYoneti : Form
    {
        private readonly string connectionString;

        public StokYoneti()
        {
            InitializeComponent();
            connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";
            LoadProducts();

            // DataGridView'in CellPainting olayına abone ol
            UrunTablosu.CellPainting += UrunTablosu_CellPainting;
        }

        private void LoadProducts()
        {
            try
            {
                UrunTablosu.Rows.Clear(); // Mevcut satırları temizle

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ProductID, ProductName, Stock, Price FROM Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int srNo = 1; // Sıra numarası için sayaç
                            while (reader.Read())
                            {
                                UrunTablosu.Rows.Add(
                                    srNo++,
                                    reader["ProductID"],
                                    reader["ProductName"],
                                    reader["Stock"],
                                    Convert.ToDecimal(reader["Price"]),
                                    "Edit",    // Edit butonu
                                    "Delete"   // Delete butonu
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunTablosu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == UrunTablosu.Columns["dgvStock"].Index)
            {
                e.PaintBackground(e.ClipBounds, true); // Hücre arka planını çiz

                // Stok değerini al
                object cellValue = UrunTablosu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                int stockValue = 0;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out stockValue))
                {
                    int maxStock = 500; // Maksimum stok değeri
                    double percentage = (double)stockValue / maxStock;
                    int progressWidth = (int)(percentage * e.CellBounds.Width); // Bar genişliği

                    // Yüzdelik değere göre renk seçimi
                    Color progressColor = percentage <= 0.25 ? Color.Red :
                                          percentage <= 0.5 ? Color.Orange :
                                          percentage <= 0.75 ? Color.Yellow :
                                          Color.Green;

                    // Progress bar'ı çiz
                    using (Brush brush = new SolidBrush(progressColor))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds.X + 2, e.CellBounds.Y + 2, progressWidth - 4, e.CellBounds.Height - 4);
                    }

                    // Stok değerini siyah renkle yaz
                    string stockText = $"{stockValue}";
                    using (Brush textBrush = new SolidBrush(Color.Black))
                    {
                        var textSize = e.Graphics.MeasureString(stockText, e.CellStyle.Font);
                        float textX = e.CellBounds.X + (e.CellBounds.Width - textSize.Width) / 2; // Ortada hizalama
                        float textY = e.CellBounds.Y + (e.CellBounds.Height - textSize.Height) / 2;
                        e.Graphics.DrawString(stockText, e.CellStyle.Font, textBrush, textX, textY);
                    }
                }

                e.Handled = true; // Hücreyi bizim çizdiğimizi belirt
            }
        }

        private void UrunTablosu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Edit butonuna tıklama
                if (e.ColumnIndex == UrunTablosu.Columns["Edit"].Index)
                {
                    string productId = UrunTablosu.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();
                    string productName = UrunTablosu.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    int currentStock = Convert.ToInt32(UrunTablosu.Rows[e.RowIndex].Cells["dgvStock"].Value);
                    decimal currentPrice = Convert.ToDecimal(UrunTablosu.Rows[e.RowIndex].Cells["Price"].Value);

                    UpdateProductForm updateForm = new UpdateProductForm(productId, productName, currentStock, currentPrice, connectionString);
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        
                        LoadProducts(); // Güncelleme sonrası tabloyu yenile
                    }
                }

                // Delete butonuna tıklama
                if (e.ColumnIndex == UrunTablosu.Columns["Delete"].Index)
                {
                    string productId = UrunTablosu.Rows[e.RowIndex].Cells["ProductID"].Value.ToString();

                    DialogResult result = MessageBox.Show($"Ürünü ve ilişkili tüm siparişleri/logları silmek istiyor musunuz? ID: {productId}",
                        "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        DeleteProductAndRelations(productId);
                        LogAdminAction($"Ürün silindi: ProductID = {productId}");
                        LoadProducts(); // Tabloyu yenile
                    }
                }
            }
        }

        private void DeleteProductAndRelations(string productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Silinecek OrderID'leri al
                            List<int> orderIds = new List<int>();
                            string getOrderIdsQuery = "SELECT OrderID FROM Orders WHERE ProductID = @ProductID";
                            using (SqlCommand getOrderIdsCommand = new SqlCommand(getOrderIdsQuery, connection, transaction))
                            {
                                getOrderIdsCommand.Parameters.AddWithValue("@ProductID", productId);
                                using (SqlDataReader reader = getOrderIdsCommand.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        orderIds.Add(Convert.ToInt32(reader["OrderID"]));
                                    }
                                }
                            }

                            // 2. Logları sil (bulunan OrderID'lere göre)
                            if (orderIds.Count > 0)
                            {
                                string deleteLogsQuery = "DELETE FROM Logs WHERE OrderID IN (" + string.Join(",", orderIds) + ")";
                                using (SqlCommand deleteLogsCommand = new SqlCommand(deleteLogsQuery, connection, transaction))
                                {
                                    deleteLogsCommand.ExecuteNonQuery();
                                }
                            }

                            // 3. Siparişleri sil
                            string deleteOrdersQuery = "DELETE FROM Orders WHERE ProductID = @ProductID";
                            using (SqlCommand deleteOrdersCommand = new SqlCommand(deleteOrdersQuery, connection, transaction))
                            {
                                deleteOrdersCommand.Parameters.AddWithValue("@ProductID", productId);
                                deleteOrdersCommand.ExecuteNonQuery();
                            }

                            // 4. Ürünü sil
                            string deleteProductQuery = "DELETE FROM Products WHERE ProductID = @ProductID";
                            using (SqlCommand deleteProductCommand = new SqlCommand(deleteProductQuery, connection, transaction))
                            {
                                deleteProductCommand.Parameters.AddWithValue("@ProductID", productId);
                                deleteProductCommand.ExecuteNonQuery();
                            }

                            transaction.Commit(); // Tüm işlemler başarıyla tamamlandı
                            MessageBox.Show("Ürün ve ilişkili tüm siparişler/loglar başarıyla silindi.",
                                "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Hata durumunda tüm işlemleri geri al
                            MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}",
                                "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogAdminAction(string actionDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Logs (LogDate, LogType, LogDetails) VALUES (@LogDate, @LogType, @LogDetails)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LogDate", DateTime.Now);
                        command.Parameters.AddWithValue("@LogType", "Admin İşlemi");
                        command.Parameters.AddWithValue("@LogDetails", actionDetails);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loglama sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunEkleButon_Click_1(object sender, EventArgs e)
        {

            using (UrunEklePanel urunEklePanel = new UrunEklePanel(connectionString))
            {
                if (urunEklePanel.ShowDialog() == DialogResult.OK)
                {
                    // Ürün eklendikten sonra tabloyu yeniden yükle
                    LoadProducts();
                }
            }

        }
    }
}
