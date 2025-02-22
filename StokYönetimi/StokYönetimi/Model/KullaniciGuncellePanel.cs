using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StokYönetimi
{
    public partial class KullaniciGuncellePanel : Form
    {
        private readonly string connectionString;
        private readonly string userId;

        public KullaniciGuncellePanel(string userId, string userName, string userType, decimal budget, decimal totalSpent, string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;

            this.connectionString = connectionString;
            this.userId = userId;

            
            KullaniciAdi.Text = userName;
            KullaniciTürüComboBox.Items.Add("Standard");
            KullaniciTürüComboBox.Items.Add("Premium");
            KullaniciTürüComboBox.SelectedItem = userType;
            KullaniciBakiye.Value = budget;
            ToplamHarcama.Value = totalSpent;
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Customers 
                        SET CustomerName = @CustomerName, 
                            Budget = @Budget, 
                            CustomerType = @CustomerType, 
                            TotalSpent = @TotalSpent, 
                            PriorityScore = @PriorityScore 
                        WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        string selectedType = KullaniciTürüComboBox.SelectedItem.ToString();
                        int priorityScore = (selectedType == "Premium") ? 15 : 10;

                        command.Parameters.AddWithValue("@CustomerName", KullaniciAdi.Text.Trim());
                        command.Parameters.AddWithValue("@Budget", KullaniciBakiye.Value);
                        command.Parameters.AddWithValue("@CustomerType", selectedType);
                        command.Parameters.AddWithValue("@TotalSpent", ToplamHarcama.Value);
                        command.Parameters.AddWithValue("@PriorityScore", priorityScore);
                        command.Parameters.AddWithValue("@CustomerID", userId);

                        command.ExecuteNonQuery();
                    }

                    
                    string logQuery = @"
                        INSERT INTO Logs (LogDate, LogType, LogDetails) 
                        VALUES (@LogDate, @LogType, @LogDetails)";

                    using (SqlCommand logCommand = new SqlCommand(logQuery, connection))
                    {
                        logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@LogType", "Admin İşlemi");
                        logCommand.Parameters.AddWithValue("@LogDetails", $"Kullanıcı ID: {userId} güncellendi. Yeni Adı: {KullaniciAdi.Text}, Tür: {KullaniciTürüComboBox.SelectedItem}, Bakiye: {KullaniciBakiye.Value}, Toplam Harcama: {ToplamHarcama.Value}");
                        logCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kullanıcı başarıyla güncellendi ve loglandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
