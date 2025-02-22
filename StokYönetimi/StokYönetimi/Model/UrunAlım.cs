using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace StokYönetimi.Model
{
    public partial class UrunAlım : Form
    {
        private readonly string connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";
        private int currentCustomerId = 0; 

        public UrunAlım(int customerId)
        {
            InitializeComponent();
            currentCustomerId = customerId;
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT ProductID, ProductName, Stock, Price FROM Products";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                string productName = reader["ProductName"].ToString();
                                int stock = Convert.ToInt32(reader["Stock"]);
                                decimal price = Convert.ToDecimal(reader["Price"]);

                                UrunKarti urunKarti = new UrunKarti
                                {
                                    id = productId,
                                    name = productName,
                                    Price = $"{price:C}",
                                    Miktar = stock
                                };

                                urunKarti.SepeteEkleClick += SepeteEkle_Click;
                                flowLayoutPanel1.Controls.Add(urunKarti);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SepeteEkle_Click(object sender, EventArgs e)
        {
            var urunKart = sender as UrunKarti;

            if (urunKart == null)
            {
                MessageBox.Show("Ürün bilgisi alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string urunAdi = urunKart.name;
            int stokMiktari = urunKart.Miktar;
            decimal fiyat = decimal.Parse(urunKart.Price.Replace("₺", "").Trim());

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                $"Lütfen {urunAdi} için almak istediğiniz miktarı girin (Maksimum 5):",
                "Miktar Girin",
                "1"
            );

            if (string.IsNullOrEmpty(input)) return;

            if (!int.TryParse(input, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (miktar > 5)
            {
                MessageBox.Show("Bir üründen en fazla 5 adet alabilirsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (miktar > stokMiktari)
            {
                MessageBox.Show($"Yeterli stok yok! Mevcut stok: {stokMiktari}", "Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridViewSepet.Rows)
            {
                if (row.Cells["UrunAdi"].Value?.ToString() == urunAdi)
                {
                    int mevcutMiktar = Convert.ToInt32(row.Cells["Miktar"].Value);
                    if (mevcutMiktar + miktar > 5)
                    {
                        MessageBox.Show("Bu üründen sepette en fazla 5 adet olabilir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["Miktar"].Value = mevcutMiktar + miktar;
                    row.Cells["Toplam"].Value = (mevcutMiktar + miktar) * fiyat;
                    urunKart.Miktar -= miktar;
                    SepetToplamTutarHesapla();
                    return;
                }
            }

            dataGridViewSepet.Rows.Add(urunAdi, miktar, fiyat, miktar * fiyat);
            SepetToplamTutarHesapla();
            urunKart.Miktar -= miktar;
        }

        private void SepetToplamTutarHesapla()
        {
            decimal toplamTutar = 0;

            foreach (DataGridViewRow row in dataGridViewSepet.Rows)
            {
                if (row.Cells["Toplam"].Value != null)
                {
                    toplamTutar += Convert.ToDecimal(row.Cells["Toplam"].Value);
                }
            }

            SepetTutari.Text = $"Toplam Tutar: {toplamTutar:C}";
        }

        private void SepetOnayButon_Click(object sender, EventArgs e)
        {
            Thread siparisThread = new Thread(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (DataGridViewRow row in dataGridViewSepet.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string urunAdi = row.Cells["UrunAdi"].Value.ToString();
                            int miktar = Convert.ToInt32(row.Cells["Miktar"].Value);
                            decimal toplamTutar = Convert.ToDecimal(row.Cells["Toplam"].Value);

                            string getProductQuery = "SELECT ProductID FROM Products WHERE ProductName = @ProductName";
                            int productId = 0;

                            using (SqlCommand getProductCmd = new SqlCommand(getProductQuery, connection))
                            {
                                getProductCmd.Parameters.AddWithValue("@ProductName", urunAdi);
                                productId = Convert.ToInt32(getProductCmd.ExecuteScalar());
                            }

                            string insertOrderQuery = @"
                                INSERT INTO Orders (CustomerID, ProductID, Quantity, TotalPrice, OrderDate, OrderStatus) 
                                VALUES (@CustomerID, @ProductID, @Quantity, @TotalPrice, @OrderDate, @OrderStatus)";

                            using (SqlCommand insertOrderCmd = new SqlCommand(insertOrderQuery, connection))
                            {
                                insertOrderCmd.Parameters.AddWithValue("@CustomerID", currentCustomerId);
                                insertOrderCmd.Parameters.AddWithValue("@ProductID", productId);
                                insertOrderCmd.Parameters.AddWithValue("@Quantity", miktar);
                                insertOrderCmd.Parameters.AddWithValue("@TotalPrice", toplamTutar);
                                insertOrderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                insertOrderCmd.Parameters.AddWithValue("@OrderStatus", "Bekliyor");
                                insertOrderCmd.ExecuteNonQuery();
                            }
                        }

                        Invoke((MethodInvoker)(() =>
                        {
                            dataGridViewSepet.Rows.Clear();
                            SepetToplamTutarHesapla();
                            MessageBox.Show("Siparişler admin onayı için gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });

            siparisThread.IsBackground = true;
            siparisThread.Start();
        }

        private void dataGridViewSepet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewSepet.Columns["Sil"].Index) 
            {
                string urunAdi = dataGridViewSepet.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
                int miktar = Convert.ToInt32(dataGridViewSepet.Rows[e.RowIndex].Cells["Miktar"].Value);

                
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is UrunKarti urunKart && urunKart.name == urunAdi)
                    {
                        urunKart.Miktar += miktar;
                        break;
                    }
                }

                
                dataGridViewSepet.Rows.RemoveAt(e.RowIndex);

                
                SepetToplamTutarHesapla();
            }
        }

    }
}
