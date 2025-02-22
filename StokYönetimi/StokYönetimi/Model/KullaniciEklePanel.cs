using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class KullaniciEKlePanel : Form
    {
        private readonly string connectionString;

        public KullaniciEKlePanel(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;

            KullaniciTürüComboBox.Items.Add("Standard");
            KullaniciTürüComboBox.Items.Add("Premium");
            KullaniciTürüComboBox.SelectedIndex = 0; 
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = KullaniciAdi.Text.Trim();
            string kullaniciTuru = KullaniciTürüComboBox.SelectedItem.ToString();
            decimal kullaniciBakiye;

            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(KullaniciBakiye.Text, out kullaniciBakiye) || kullaniciBakiye < 0)
            {
                MessageBox.Show("Geçerli bir bakiye giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int priorityScore = kullaniciTuru == "Premium" ? 15 : 10;
            string password = "1234"; 

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string query = @"
                INSERT INTO Customers (CustomerName, Password, Budget, CustomerType, PriorityScore) 
                VALUES (@CustomerName, @Password, @Budget, @CustomerType, @PriorityScore)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerName", kullaniciAdi);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Budget", kullaniciBakiye);
                        command.Parameters.AddWithValue("@CustomerType", kullaniciTuru);
                        command.Parameters.AddWithValue("@PriorityScore", priorityScore);

                        command.ExecuteNonQuery();
                    }

                    
                    string logQuery = @"
                INSERT INTO Logs (LogDate, LogType, LogDetails) 
                VALUES (@LogDate, @LogType, @LogDetails)";

                    using (SqlCommand logCommand = new SqlCommand(logQuery, connection))
                    {
                        logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@LogType", "Admin İşlemi");
                        logCommand.Parameters.AddWithValue("@LogDetails", $"Yeni kullanıcı eklendi: {kullaniciAdi}, Tür: {kullaniciTuru}");

                        logCommand.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı başarıyla eklendi ve log kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı eklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
