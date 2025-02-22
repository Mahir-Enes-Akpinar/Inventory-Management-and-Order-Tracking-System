using StokYönetimi.Model;
using System;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class KullaniciPanel : Form
    {
        private int _customerId; // Giriş yapan kullanıcının CustomerID'si

        public KullaniciPanel(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void KullaniciPanel_Load(object sender, EventArgs e)
        {
            
            LoadUrunAlimPanel();
        }

        private void LoadUrunAlimPanel()
        {
            
            IcerikPanel.Controls.Clear();

            
            UrunAlım urunAlimPanel = new UrunAlım(_customerId)
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            IcerikPanel.Controls.Add(urunAlimPanel); 
            urunAlimPanel.Show(); 
        }

        private void SatınAlmaPanelButon_Click(object sender, EventArgs e)
        {
            LoadUrunAlimPanel();
        }

        private void CikisButon_Click(object sender, EventArgs e)
        {
            
            this.Close();

            
            Form1 girisFormu = new Form1();
            girisFormu.Show();
        }

        private void gecmisSiparisButon_Click(object sender, EventArgs e)
        {
            
            IcerikPanel.Controls.Clear();

           
            GecmisSiparisler gecmisSiparislerPanel = new GecmisSiparisler(_customerId)
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            IcerikPanel.Controls.Add(gecmisSiparislerPanel); 
            gecmisSiparislerPanel.Show(); 
        }
    }
}
