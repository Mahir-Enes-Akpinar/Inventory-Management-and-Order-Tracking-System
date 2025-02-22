using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StokYönetimi.Model
{
    public partial class GecmisSiparisler : Form
    {
        private readonly int _customerId;
        private readonly string connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";

        public GecmisSiparisler(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;

           
            SiparislerFlowLayoutPanel.Dock = DockStyle.Fill;
            SiparislerFlowLayoutPanel.AutoScroll = true; 

            SiparisleriYukle();
        }

        private void SiparisleriYukle()
        {
            string query = "SELECT OrderID, ProductID, Quantity, TotalPrice, OrderDate, OrderStatus FROM Orders WHERE CustomerID = @CustomerID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", _customerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            SiparislerFlowLayoutPanel.Controls.Clear(); 

                            while (reader.Read())
                            {
                                
                                int orderId = Convert.ToInt32(reader["OrderID"]);
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);
                                string orderStatus = reader["OrderStatus"].ToString();

                                
                                Panel siparisKart = new Panel
                                {
                                    Width = 250, 
                                    Height = 170, 
                                    Margin = new Padding(30),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = GetBackgroundColorByStatus(orderStatus) 
                                };

                                Label lblOrderId = new Label
                                {
                                    Text = $"Sipariş ID: {orderId}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 10, FontStyle.Bold),
                                    ForeColor = Color.Black,
                                    Location = new Point(10, 10)
                                };

                                Label lblProductId = new Label
                                {
                                    Text = $"Ürün ID: {productId}",
                                    AutoSize = true,
                                    Location = new Point(10, 35)
                                };

                                Label lblQuantity = new Label
                                {
                                    Text = $"Miktar: {quantity}",
                                    AutoSize = true,
                                    Location = new Point(10, 60)
                                };

                                Label lblTotalPrice = new Label
                                {
                                    Text = $"Tutar: {totalPrice:C}",
                                    AutoSize = true,
                                    Location = new Point(10, 85)
                                };

                                Label lblOrderDate = new Label
                                {
                                    Text = $"Tarih: {orderDate:yyyy-MM-dd}",
                                    AutoSize = true,
                                    Location = new Point(10, 110)
                                };

                                Label lblOrderStatus = new Label
                                {
                                    Text = $"Durum: {orderStatus}",
                                    AutoSize = true,
                                    Font = new Font("Arial", 9, FontStyle.Italic),
                                    ForeColor = Color.Black,
                                    Location = new Point(10, 135)
                                };

                                
                                siparisKart.Controls.Add(lblOrderId);
                                siparisKart.Controls.Add(lblProductId);
                                siparisKart.Controls.Add(lblQuantity);
                                siparisKart.Controls.Add(lblTotalPrice);
                                siparisKart.Controls.Add(lblOrderDate);
                                siparisKart.Controls.Add(lblOrderStatus);

                                SiparislerFlowLayoutPanel.Controls.Add(siparisKart);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetBackgroundColorByStatus(string status)
        {
            switch (status.ToLower())
            {
                case "bekliyor":
                    return Color.LightYellow; 
                case "onaylandı":
                    return Color.LightGreen; 
                case "zaman aşımına uğradı":
                    return Color.LightCoral; 
                case "bakiye yetersiz":
                    return Color.LightSkyBlue; 
                case "stok yetersiz":
                    return Color.LightPink; 
                default:
                    return Color.White; 
            }
        }
    }
    
}
