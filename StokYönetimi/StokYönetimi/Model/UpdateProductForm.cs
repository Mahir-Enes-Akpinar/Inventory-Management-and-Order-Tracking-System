using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class UpdateProductForm : Form
    {
        private readonly string connectionString;
        private readonly string productId;

        public UpdateProductForm(string productId, string productName, int stock, decimal price, string connectionString)
        {
            InitializeComponent();
            this.productId = productId;
            this.connectionString = connectionString;

            
            txtProductName.Text = productName;
            numCurrentStock.Value = stock;
            numPrice.Value = price;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Ürün adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = "UPDATE Products SET ProductName = @ProductName, Stock = @Stock, Price = @Price WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        command.Parameters.AddWithValue("@Stock", (int)numCurrentStock.Value);
                        command.Parameters.AddWithValue("@Price", numPrice.Value);
                        command.Parameters.AddWithValue("@ProductID", productId);

                        command.ExecuteNonQuery();
                    }

                    
                    string logQuery = "INSERT INTO Logs (LogDate, LogType, LogDetails) VALUES (@LogDate, @LogType, @LogDetails)";
                    using (SqlCommand logCommand = new SqlCommand(logQuery, connection))
                    {
                        logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@LogType", "Bilgilendirme");
                        logCommand.Parameters.AddWithValue("@LogDetails", $"Product ID: {productId} ürünü güncellendi.");
                        logCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Ürün başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
