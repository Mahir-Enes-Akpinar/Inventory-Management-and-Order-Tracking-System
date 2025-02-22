using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace StokYönetimi.Model
{
    public partial class LogPanel : Form
    {
        private string connectionString = "Server=ENES\\SQLEXPRESS;Database=StokYonetimDB;Trusted_Connection=True;";
        private Thread logKontrolThread;
        private bool isThreadRunning = false;
        private DateTime lastLogDate = DateTime.MinValue; 

        public LogPanel()
        {
            InitializeComponent();
            HazirlaLogPanel();

            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 0.8;
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.TopMost = true;
            this.Width = 600;
            this.Height = 300;

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10,
                                       Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10);
        }

        private void LogPanel_Load(object sender, EventArgs e)
        {
            BaslatLogKontrolThread();
        }

        private void HazirlaLogPanel()
        {
            logFlowLayoutPanel.Controls.Clear();
            logFlowLayoutPanel.AutoScroll = true;
            logFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            logFlowLayoutPanel.WrapContents = false;
        }

        private void BaslatLogKontrolThread()
        {
            isThreadRunning = true;
            logKontrolThread = new Thread(() =>
            {
                while (isThreadRunning)
                {
                    try
                    {
                        // Yeni logları kontrol et
                        if (YeniLogVarMi())
                        {
                            Invoke((MethodInvoker)delegate { GuncelleLogPanel(); });
                        }

                        Thread.Sleep(2000); // 2 saniyede bir kontrol et
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Log kontrol sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            });

            logKontrolThread.IsBackground = true;
            logKontrolThread.Start();
        }

        private bool YeniLogVarMi()
        {
            string query = "SELECT MAX(LogDate) AS LastLogDate FROM Logs";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            DateTime maxLogDate = Convert.ToDateTime(result);

                            // Yeni log olup olmadığını kontrol et
                            if (maxLogDate > lastLogDate)
                            {
                                lastLogDate = maxLogDate; // En son kontrol edilen log tarihini güncelle
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Log kontrol sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        private void GuncelleLogPanel()
        {
            string query = "SELECT LogID, CustomerID, OrderID, LogDate, LogType, LogDetails FROM Logs ORDER BY LogDate DESC";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            logFlowLayoutPanel.Controls.Clear();

                            while (reader.Read())
                            {
                                Panel logPanel = new Panel
                                {
                                    BorderStyle = BorderStyle.FixedSingle,
                                    Padding = new Padding(10),
                                    Margin = new Padding(5),
                                    Width = logFlowLayoutPanel.ClientSize.Width - 20,
                                    Height = 50,
                                    BackColor = GetLogColor(reader["LogType"].ToString())
                                };

                                Label logLabel = new Label
                                {
                                    Text = $"[{reader["LogDate"]:yyyy-MM-dd HH:mm:ss}] {reader["LogType"].ToString().ToUpper()}: {reader["LogDetails"]}",
                                    AutoSize = false,
                                    ForeColor = Color.Black,
                                    Dock = DockStyle.Fill,
                                    TextAlign = ContentAlignment.MiddleLeft
                                };

                                logPanel.Controls.Add(logLabel);
                                logFlowLayoutPanel.Controls.Add(logPanel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Loglar güncellenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Color GetLogColor(string logType)
        {
            switch (logType.ToLower())
            {
                case "bilgilendirme":
                    return Color.LightBlue;
                case "hata":
                    return Color.LightCoral;
                case "uyarı":
                    return Color.LightYellow;
                case "admin işlemi":
                    return Color.Silver;
                default:
                    return Color.White;
            }
        }

        private void DurdurLogKontrolThread()
        {
            isThreadRunning = false;
            if (logKontrolThread != null && logKontrolThread.IsAlive)
            {
                logKontrolThread.Join();
            }
        }

        private void LogPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            DurdurLogKontrolThread();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DurdurLogKontrolThread();
            base.OnFormClosing(e);
        }
    }
}
