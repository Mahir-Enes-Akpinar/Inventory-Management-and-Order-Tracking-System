using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokYönetimi.Model
{
    public partial class AdminSiparişOnayla : Form
    {
        private Thread siparisGuncellemeThread;
        private static Mutex stokMutex = new Mutex();
        private readonly string connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";

        public AdminSiparişOnayla()
        {
            InitializeComponent();
            this.Load += AdminSiparişOnayla_Load;
        }

        private void AdminSiparişOnayla_Load(object sender, EventArgs e)
        {
            HazirlaListView();
            YukleOnayBekleyenSiparisler();
            BaslatGuncellemeThread();
        }
        //listviewı hazırlar
        private void HazirlaListView()
        {
            OnayBekleyenList.Clear();
            OnayBekleyenList.Columns.Add("Sipariş ID", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Müşteri Adı", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Müşteri Türü", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Ürün Adı", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Miktar", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Toplam Tutar", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Öncelik Skoru", 145, HorizontalAlignment.Center);
            OnayBekleyenList.Columns.Add("Durum", 145, HorizontalAlignment.Center);

            OnayBekleyenList.View = View.Details;
            OnayBekleyenList.FullRowSelect = true;
            OnayBekleyenList.GridLines = true;
        }
        //onay bekleyen siparişleri Lİstviewa yükler

        private void YukleOnayBekleyenSiparisler()
        {
            string query = @"
        SELECT o.OrderID, c.CustomerName, c.CustomerType, p.ProductName, o.Quantity, o.TotalPrice, o.OrderDate,
               CASE 
                   WHEN c.CustomerType = 'Premium' THEN 20
                   ELSE 10 
               END + DATEDIFF(SECOND, o.OrderDate, GETDATE()) * 0.5 AS PriorityScore
        FROM Orders o
        JOIN Customers c ON o.CustomerID = c.CustomerID
        JOIN Products p ON o.ProductID = p.ProductID
        WHERE o.OrderStatus = 'Bekliyor'
        ORDER BY PriorityScore DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            OnayBekleyenList.Items.Clear();
                            while (reader.Read())
                            {
                                int orderId = Convert.ToInt32(reader["OrderID"]);
                                string customerName = reader["CustomerName"].ToString();
                                string customerType = reader["CustomerType"].ToString();
                                string productName = reader["ProductName"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);
                                float priorityScore = Convert.ToSingle(reader["PriorityScore"]);

                                
                                ListViewItem item = new ListViewItem(orderId.ToString());
                                item.SubItems.Add(customerName);
                                item.SubItems.Add(customerType);
                                item.SubItems.Add(productName);
                                item.SubItems.Add(quantity.ToString());
                                item.SubItems.Add($"{totalPrice:C}");
                                item.SubItems.Add(priorityScore.ToString("F2")); 
                                item.SubItems.Add("Bekliyor");
                                OnayBekleyenList.Items.Add(item);
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


        private float HesaplaOncelikSkoru(string musteriTuru, int beklemeSuresi)
        {
            float temelOncelikSkoru = (musteriTuru == "Premium") ? 20f : 10f;
            float beklemeSureAgirligi = 0.5f;
            return temelOncelikSkoru + (beklemeSuresi * beklemeSureAgirligi);
        }


        private void BaslatGuncellemeThread()
        {
            siparisGuncellemeThread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000); //her saniye kontrol
                    Invoke((MethodInvoker)delegate
                    {
                        ZamanAsimiKontrol();
                        YukleOnayBekleyenSiparisler();
                    });
                }
            });
            siparisGuncellemeThread.IsBackground = true;
            siparisGuncellemeThread.Start();
        }

        private void ZamanAsimiKontrol()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT OrderID, CustomerID FROM Orders WHERE OrderStatus = 'Bekliyor' AND DATEDIFF(SECOND, OrderDate, GETDATE()) > 45";
                    List<(int OrderId, int CustomerId)> zamanAsimiSiparisler = new List<(int, int)>();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = Convert.ToInt32(reader["OrderID"]);
                                int customerId = Convert.ToInt32(reader["CustomerID"]);
                                zamanAsimiSiparisler.Add((orderId, customerId));
                            }
                        }
                    }

                    foreach (var siparis in zamanAsimiSiparisler)
                    {
                        KaydetLog(connection, siparis.CustomerId, siparis.OrderId, "Hata", "Zaman aşımına uğradı.");

                        string updateQuery = "UPDATE Orders SET OrderStatus = 'Zaman Aşımına Uğradı' WHERE OrderID = @OrderID";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderID", siparis.OrderId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    if (zamanAsimiSiparisler.Count > 0)
                    {
                        MessageBox.Show($"{zamanAsimiSiparisler.Count} sipariş zaman aşımına uğradı ve durum güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Zaman aşımı kontrolünde bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KaydetLog(SqlConnection connection, int customerId, int orderId, string logType, string logDetails)
        {
            string logQuery = @"INSERT INTO Logs (CustomerID, OrderID, LogDate, LogType, LogDetails) VALUES (@CustomerID, @OrderID, @LogDate, @LogType, @LogDetails)";

            using (SqlCommand logCommand = new SqlCommand(logQuery, connection))
            {
                logCommand.Parameters.AddWithValue("@CustomerID", customerId);
                logCommand.Parameters.AddWithValue("@OrderID", orderId);
                logCommand.Parameters.AddWithValue("@LogDate", DateTime.Now);
                logCommand.Parameters.AddWithValue("@LogType", logType);
                logCommand.Parameters.AddWithValue("@LogDetails", logDetails);
                logCommand.ExecuteNonQuery();
            }
        }
        //Onay bekleyen sipaişleri tek tek sipaisOnayla ya gönderir
        private void SiparisleriOnayla()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string getOrdersQuery = @"
                SELECT o.OrderID, o.ProductID, o.Quantity, o.CustomerID, c.CustomerType,
                       CASE 
                           WHEN c.CustomerType = 'Premium' THEN 20
                           ELSE 10 
                       END + DATEDIFF(SECOND, o.OrderDate, GETDATE()) * 0.5 AS PriorityScore
                FROM Orders o
                JOIN Customers c ON o.CustomerID = c.CustomerID
                WHERE o.OrderStatus = 'Bekliyor'
                ORDER BY PriorityScore DESC";

                    using (SqlCommand command = new SqlCommand(getOrdersQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = Convert.ToInt32(reader["OrderID"]);
                                int productId = Convert.ToInt32(reader["ProductID"]);
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                int customerId = Convert.ToInt32(reader["CustomerID"]);
                                // her sipaiş için thread oluşturur threadlar SiparisiOnayla Methodunu çağırır
                                Thread siparisThread = new Thread(() => SiparisiOnayla(orderId, productId, quantity, customerId));
                                siparisThread.Start();
                                siparisThread.Join();
                            }
                        }
                    }

                    MessageBox.Show("Tüm bekleyen siparişler öncelik sırasına göre işlenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Siparişler işlenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SiparisiOnayla(int orderId, int productId, int quantity, int customerId)
        {
            try
            {
                stokMutex.WaitOne(); // kanğı kilitler aynı anda birden fazla thread kaynağa erişemez

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ürün stoğunu kontrol et
                    string stockQuery = "SELECT Stock FROM Products WHERE ProductID = @ProductID";
                    int currentStock;

                    using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                    {
                        stockCommand.Parameters.AddWithValue("@ProductID", productId);
                        currentStock = Convert.ToInt32(stockCommand.ExecuteScalar());
                    }

                    if (currentStock < quantity)
                    {
                        KaydetLog(connection, customerId, orderId, "Hata", "Ürün stoğu yetersiz");

                        string updateOrderStatusQuery = "UPDATE Orders SET OrderStatus = 'Stok Yetersiz' WHERE OrderID = @OrderID";
                        using (SqlCommand updateCommand = new SqlCommand(updateOrderStatusQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                            updateCommand.ExecuteNonQuery();
                        }

                        return;
                    }

                    // Siparişin toplam fiyatını al
                    decimal totalPrice;
                    string orderTotalQuery = "SELECT TotalPrice FROM Orders WHERE OrderID = @OrderID";
                    using (SqlCommand orderTotalCommand = new SqlCommand(orderTotalQuery, connection))
                    {
                        orderTotalCommand.Parameters.AddWithValue("@OrderID", orderId);
                        totalPrice = Convert.ToDecimal(orderTotalCommand.ExecuteScalar());
                    }

                    // Müşteri bakiyesini kontrol et
                    decimal customerBudget;
                    string customerBudgetQuery = "SELECT Budget FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand customerBudgetCommand = new SqlCommand(customerBudgetQuery, connection))
                    {
                        customerBudgetCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        customerBudget = Convert.ToDecimal(customerBudgetCommand.ExecuteScalar());
                    }

                    if (customerBudget < totalPrice)
                    {
                        KaydetLog(connection, customerId, orderId, "Hata", "Müşteri bakiyesi yetersiz");

                        string updateOrderStatusQuery = "UPDATE Orders SET OrderStatus = 'Bakiye Yetersiz' WHERE OrderID = @OrderID";
                        using (SqlCommand updateCommand = new SqlCommand(updateOrderStatusQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                            updateCommand.ExecuteNonQuery();
                        }

                        return;
                    }

                    // Ürün stoğunu güncelle
                    string updateStockQuery = "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID";
                    using (SqlCommand stockUpdateCommand = new SqlCommand(updateStockQuery, connection))
                    {
                        stockUpdateCommand.Parameters.AddWithValue("@Quantity", quantity);
                        stockUpdateCommand.Parameters.AddWithValue("@ProductID", productId);
                        stockUpdateCommand.ExecuteNonQuery();
                    }

                    // Müşterinin bütçesini ve toplam harcamasını güncelle
                    string customerUpdateQuery = @"
                UPDATE Customers
                SET Budget = Budget - @TotalPrice, 
                    TotalSpent = TotalSpent + @TotalPrice
                WHERE CustomerID = @CustomerID";

                    using (SqlCommand customerUpdateCommand = new SqlCommand(customerUpdateQuery, connection))
                    {
                        customerUpdateCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        customerUpdateCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        customerUpdateCommand.ExecuteNonQuery();
                    }

                    // Müşterinin toplam harcamasını kontrol et ve müşteri türünü güncelle
                    string customerTypeUpdateQuery = @"
                UPDATE Customers
                SET CustomerType = 'Premium' ,PriorityScore = 15

                WHERE CustomerID = @CustomerID AND TotalSpent > 2000";

                    using (SqlCommand customerTypeUpdateCommand = new SqlCommand(customerTypeUpdateQuery, connection))
                    {
                        customerTypeUpdateCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        customerTypeUpdateCommand.ExecuteNonQuery();
                    }

                    
                    string updateOrderStatusQueryOnay = "UPDATE Orders SET OrderStatus = 'Onaylandı' WHERE OrderID = @OrderID";
                    using (SqlCommand updateOrderStatusCommand = new SqlCommand(updateOrderStatusQueryOnay, connection))
                    {
                        updateOrderStatusCommand.Parameters.AddWithValue("@OrderID", orderId);
                        updateOrderStatusCommand.ExecuteNonQuery();
                    }

                    
                    KaydetLog(connection, customerId, orderId, "Bilgilendirme", "Sipariş onaylandı ve müşteri bilgileri güncellendi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş onaylanırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                stokMutex.ReleaseMutex();
            }
        }


        private void SiparisOnaylaButon_Click(object sender, EventArgs e)
        {
            if (OnayBekleyenList.Items.Count == 0)
            {
                MessageBox.Show("Onay bekleyen sipariş yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            PictureBox loadingAnimation = new PictureBox
            {
                Size = new Size(100, 100),
                Image = Properties.Resources.Animation___1735140874496, 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Visible = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(loadingAnimation);
            loadingAnimation.BringToFront();
            


            Label customerInfoLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true
            };

            
            this.Controls.Add(loadingAnimation);
            this.Controls.Add(customerInfoLabel);

            
            loadingAnimation.Location = new Point((this.Width - loadingAnimation.Width) / 2, (this.Height - loadingAnimation.Height) / 2 - 20);
            customerInfoLabel.Location = new Point(((this.Width - customerInfoLabel.Width) / 2)-110, loadingAnimation.Bottom + 10);

           
            Task.Run(() =>
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                SELECT o.OrderID, o.CustomerID, c.CustomerType, p.ProductName, o.Quantity, o.ProductID
                FROM Orders o
                JOIN Customers c ON o.CustomerID = c.CustomerID
                JOIN Products p ON o.ProductID = p.ProductID
                WHERE o.OrderStatus = 'Bekliyor'
                ORDER BY 
                    CASE 
                        WHEN c.CustomerType = 'Premium' THEN 20 
                        ELSE 10 
                    END + DATEDIFF(SECOND, o.OrderDate, GETDATE()) * 0.5 DESC";

                        List<(int orderId, int productId, int quantity, int customerId, string customerType, string productName)> orders = new List<(int, int, int, int, string, string)>();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int orderId = Convert.ToInt32(reader["OrderID"]);
                                    int productId = Convert.ToInt32(reader["ProductID"]);
                                    int quantity = Convert.ToInt32(reader["Quantity"]);
                                    int customerId = Convert.ToInt32(reader["CustomerID"]);
                                    string customerType = reader["CustomerType"].ToString();
                                    string productName = reader["ProductName"].ToString();

                                    orders.Add((orderId, productId, quantity, customerId, customerType, productName));
                                }
                            }
                        }

                        foreach (var order in orders)
                        {
                            
                            Invoke((MethodInvoker)(() =>
                            {
                                loadingAnimation.Visible = true;
                                customerInfoLabel.Visible = true;
                                loadingAnimation.Refresh();
                                loadingAnimation.BringToFront();
                                customerInfoLabel.Text = $"MüşteriID: {order.customerId} için sipariş işleniyor...";
                                customerInfoLabel.Refresh();
                                customerInfoLabel.BringToFront();
                            }));

                            
                            SiparisiOnayla(order.orderId, order.productId, order.quantity, order.customerId);

                           
                            Thread.Sleep(2000);
                        }

                        
                        Invoke((MethodInvoker)(() =>
                        {
                            YukleOnayBekleyenSiparisler();
                            loadingAnimation.Visible = false; 
                            customerInfoLabel.Visible = false;
                            this.Controls.Remove(loadingAnimation);
                            MessageBox.Show("Tüm siparişler başarıyla işlenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"Sipariş işleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadingAnimation.Visible = false; 
                        this.Controls.Remove(loadingAnimation);
                    }));
                }
            });
        }






    }
}
