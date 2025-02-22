using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Generic;

namespace StokYönetimi
{
    public partial class KullaniciYonetimi : Form
    {
        private string connectionString;

        public KullaniciYonetimi()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["StokYonetimDB"].ConnectionString;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                KullaniciTablo.Rows.Clear(); 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT CustomerID, CustomerName, Password, Budget, CustomerType FROM Customers";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int srNo = 1; 
                            while (reader.Read())
                            {
                                KullaniciTablo.Rows.Add(
                                    srNo++,                                  
                                    reader["CustomerID"],                   
                                    reader["CustomerName"],                  
                                    reader["Password"],                      
                                    Convert.ToDecimal(reader["Budget"]),     
                                    reader["CustomerType"],                  
                                    "Düzenle",                               
                                    "Sil"                                   
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

        private void KullaniciTablo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedUserID = KullaniciTablo.Rows[e.RowIndex].Cells["Id"].Value.ToString(); 

                
                if (e.ColumnIndex == KullaniciTablo.Columns["Edit"].Index)
                {
                    
                    string userName = "";
                    string userType = "";
                    decimal budget = 0;
                    decimal totalSpent = 0;

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "SELECT CustomerName, CustomerType, Budget, TotalSpent FROM Customers WHERE CustomerID = @CustomerID";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@CustomerID", selectedUserID);

                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        userName = reader["CustomerName"].ToString();
                                        userType = reader["CustomerType"].ToString();
                                        budget = Convert.ToDecimal(reader["Budget"]);
                                        totalSpent = Convert.ToDecimal(reader["TotalSpent"]);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Kullanıcı bilgileri alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }

                    
                    using (KullaniciGuncellePanel guncellePanel = new KullaniciGuncellePanel(selectedUserID, userName, userType, budget, totalSpent, connectionString))
                    {
                        if (guncellePanel.ShowDialog() == DialogResult.OK)
                        {
                            LoadUsers(); 
                            MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                
                if (e.ColumnIndex == KullaniciTablo.Columns["Del"].Index)
                {
                    DialogResult result = MessageBox.Show($"Kullanıcıyı silmek ve ilişkili tüm sipariş/logları kaldırmak istiyor musunuz? ID: {selectedUserID}",
                                                          "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DeleteUser(selectedUserID); 
                        LoadUsers(); 
                    }
                }
            }
        }


        private void DeleteUser(string userID)
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
                           
                            List<int> orderIds = new List<int>();
                            string getOrderIdsQuery = "SELECT OrderID FROM Orders WHERE CustomerID = @CustomerID";
                            using (SqlCommand getOrderIdsCommand = new SqlCommand(getOrderIdsQuery, connection, transaction))
                            {
                                getOrderIdsCommand.Parameters.AddWithValue("@CustomerID", userID);
                                using (SqlDataReader reader = getOrderIdsCommand.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        orderIds.Add(Convert.ToInt32(reader["OrderID"]));
                                    }
                                }
                            }

                            
                            if (orderIds.Count > 0)
                            {
                                string deleteLogsQuery = "DELETE FROM Logs WHERE OrderID IN (" + string.Join(",", orderIds) + ")";
                                using (SqlCommand deleteLogsCommand = new SqlCommand(deleteLogsQuery, connection, transaction))
                                {
                                    deleteLogsCommand.ExecuteNonQuery();
                                }
                            }

                           
                            string deleteOrdersQuery = "DELETE FROM Orders WHERE CustomerID = @CustomerID";
                            using (SqlCommand deleteOrdersCommand = new SqlCommand(deleteOrdersQuery, connection, transaction))
                            {
                                deleteOrdersCommand.Parameters.AddWithValue("@CustomerID", userID);
                                deleteOrdersCommand.ExecuteNonQuery();
                            }

                            
                            string deleteCustomerQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                            using (SqlCommand deleteCustomerCommand = new SqlCommand(deleteCustomerQuery, connection, transaction))
                            {
                                deleteCustomerCommand.Parameters.AddWithValue("@CustomerID", userID);
                                deleteCustomerCommand.ExecuteNonQuery();
                            }

                           
                            string logQuery = @"
                        INSERT INTO Logs (LogDate, LogType, LogDetails)
                        VALUES (@LogDate, @LogType, @LogDetails)";
                            using (SqlCommand logCommand = new SqlCommand(logQuery, connection, transaction))
                            {
                                logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                                logCommand.Parameters.AddWithValue("@LogType", "Admin İşlemi");
                                logCommand.Parameters.AddWithValue("@LogDetails", $"Kullanıcı ID: {userID} ve ilişkili siparişler/loglar silindi.");
                                logCommand.ExecuteNonQuery();
                            }

                            transaction.Commit(); 
                            MessageBox.Show("Kullanıcı ve ilişkili tüm veriler başarıyla silindi ve loglandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); 
                            MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void KullaniciEkleButon_Click(object sender, EventArgs e)
        {
            using (KullaniciEKlePanel kullaniciEklePanel = new KullaniciEKlePanel(connectionString))
            {
                
                if (kullaniciEklePanel.ShowDialog() == DialogResult.OK)
                {
                    
                    LoadUsers(); 
                    
                }
            }
        }
    }
}
