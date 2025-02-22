using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GirisButonu_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = KullaniciAdiField.Text.Trim();
            string sifre = SifreAlani.Text.Trim();

            
            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanlarını doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (kullaniciAdi == "admin" && sifre == "1234")
            {
                MessageBox.Show("Admin paneline yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Hide();
                return;
            }

            
            string connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string query = "SELECT CustomerID FROM Customers WHERE LTRIM(RTRIM(CustomerName)) = LTRIM(RTRIM(@KullaniciAdi)) AND LTRIM(RTRIM(Password)) = LTRIM(RTRIM(@Sifre))";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@KullaniciAdi", System.Data.SqlDbType.NVarChar).Value = kullaniciAdi;
                        command.Parameters.Add("@Sifre", System.Data.SqlDbType.NVarChar).Value = sifre;

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            int customerId = Convert.ToInt32(result);

                            MessageBox.Show("Kullanıcı paneline yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            
                            KullaniciPanel kullaniciPanel = new KullaniciPanel(customerId);
                            kullaniciPanel.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
