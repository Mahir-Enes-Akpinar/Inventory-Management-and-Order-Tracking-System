using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokYönetimi.Model
{
    public partial class UrunKarti : UserControl
    {
        public UrunKarti()
        {
            InitializeComponent();
        }

        public int id { get; set; }
        public string name
        {
            get { return UrunAdi.Text; }
            set { UrunAdi.Text = value; }
        }
        public string Price
        {
            get { return UrunFiyati.Text; }
            set { UrunFiyati.Text = value; }
        }
        public int Miktar
        {
            get { return MiktarCircleBar.Value; }
            set
            {
                MiktarCircleBar.Value = value; // Circle bar'ın değerini ayarla
                UrunMiktari.Text = $"Stok: {value}"; // Metin olarak göster
            }
        }


        public event EventHandler SepeteEkleClick; // Dışarıdan bağlanabilir bir olay

        

        private void SepeteEkleButon_Click(object sender, EventArgs e)
        {
            if (SepeteEkleClick != null)
            {
                SepeteEkleClick(this, e);
            }
        }
    }
}
