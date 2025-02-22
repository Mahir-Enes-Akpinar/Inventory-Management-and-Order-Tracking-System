using System;
using System.Data.SqlClient;
using System.Configuration; // app.config'i okumak için
using System.Threading;
using System.Windows.Forms;
using StokYönetimi.Model;
using Microsoft.VisualBasic.Logging;
using StokYönetimi;

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // LogPanel'ı ayrı bir thread üzerinde başlat
        Thread logPanelThread = new Thread(() =>
        {
            Application.Run(new LogPanel());
        });
        logPanelThread.IsBackground = true;
        logPanelThread.Start();

        try
        {
            // app.config dosyasından bağlantı dizesini al
            string connectionString = ConfigurationManager.ConnectionStrings["StokYonetimDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("Veritabanı bağlantısı başarılı. Manuel veri ekleme işlemleri bekleniyor.");

                // Programın açık kalmasını simüle etmek için bekleme
                Console.WriteLine("Program çalışıyor. Çıkmak için Enter'a basın...");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            

        }

        // Windows Forms ana uygulamasını başlat
        Application.Run(new Form1());
    }
}
