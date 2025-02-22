using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class UrunEklePanel : Form
    {
        private readonly string connectionString;

        public UrunEklePanel(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numCurrentStock.Value <= 0)
            {
                MessageBox.Show("Stok miktarı 0 veya daha küçük olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Fiyat 0 veya daha küçük olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Yeni ürün ekleme sorgusu
                    string query = "INSERT INTO Products (ProductName, Stock, Price) VALUES (@ProductName, @Stock, @Price)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        command.Parameters.AddWithValue("@Stock", (int)numCurrentStock.Value);
                        command.Parameters.AddWithValue("@Price", numPrice.Value);

                        command.ExecuteNonQuery();
                    }

                    // Loglama sorgusu
                    string logQuery = "INSERT INTO Logs (LogDate, LogType, LogDetails) VALUES (@LogDate, @LogType, @LogDetails)";
                    using (SqlCommand logCommand = new SqlCommand(logQuery, connection))
                    {
                        logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@LogType", "Bilgilendirme");
                        logCommand.Parameters.AddWithValue("@LogDetails", $"Yeni ürün eklendi: {txtProductName.Text.Trim()}, Stok: {(int)numCurrentStock.Value}, Fiyat: {numPrice.Value:C}");

                        logCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ürün başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // İşlem başarılı olarak kapan
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
