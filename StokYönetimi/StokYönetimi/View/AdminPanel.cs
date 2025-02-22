using StokYönetimi.Model;
using System;
using System.Windows.Forms;

namespace StokYönetimi
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            
            LoadAdminSiparisOnaylaPanel();
        }

        private void KullaniciYonetimiButon_Click(object sender, EventArgs e)
        {
            IcerikPanel.Controls.Clear(); 

            KullaniciYonetimi kullaniciPanel = new KullaniciYonetimi
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            IcerikPanel.Controls.Add(kullaniciPanel);
            kullaniciPanel.Show();
        }

        private void StokYönetimiButon_Click(object sender, EventArgs e)
        {
            IcerikPanel.Controls.Clear(); 

            StokYoneti stokPanel = new StokYoneti
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            IcerikPanel.Controls.Add(stokPanel);
            stokPanel.Show();
        }

        private void OnayYonetimButon_Click(object sender, EventArgs e)
        {
            LoadAdminSiparisOnaylaPanel();
        }

        private void LoadAdminSiparisOnaylaPanel()
        {
            IcerikPanel.Controls.Clear(); 

            AdminSiparişOnayla adminSiparişOnayla = new AdminSiparişOnayla
            {
                TopLevel = false, 
                FormBorderStyle = FormBorderStyle.None, 
                Dock = DockStyle.Fill 
            };

            IcerikPanel.Controls.Add(adminSiparişOnayla);
            adminSiparişOnayla.Show(); 
        }

        private void cıkısButon_Click(object sender, EventArgs e)
        {
            this.Close();

            
            Form1 girisFormu = new Form1();
            girisFormu.Show();
        }
    }
}
