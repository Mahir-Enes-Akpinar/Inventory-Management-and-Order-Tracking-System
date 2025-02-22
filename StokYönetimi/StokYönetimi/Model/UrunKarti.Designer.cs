namespace StokYönetimi.Model
{
    partial class UrunKarti
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.MiktarCircleBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.UrunAdi = new System.Windows.Forms.Label();
            this.UrunFiyati = new System.Windows.Forms.Label();
            this.UrunMiktari = new System.Windows.Forms.Label();
            this.SepeteEkleButon = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // MiktarCircleBar
            // 
            this.MiktarCircleBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.MiktarCircleBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MiktarCircleBar.ForeColor = System.Drawing.Color.White;
            this.MiktarCircleBar.Location = new System.Drawing.Point(55, 17);
            this.MiktarCircleBar.Maximum = 500;
            this.MiktarCircleBar.Minimum = 0;
            this.MiktarCircleBar.Name = "MiktarCircleBar";
            this.MiktarCircleBar.ProgressColor2 = System.Drawing.Color.Red;
            this.MiktarCircleBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.MiktarCircleBar.Size = new System.Drawing.Size(130, 130);
            this.MiktarCircleBar.TabIndex = 0;
            this.MiktarCircleBar.Text = "guna2CircleProgressBar1";
            // 
            // UrunAdi
            // 
            this.UrunAdi.AutoSize = true;
            this.UrunAdi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunAdi.Location = new System.Drawing.Point(41, 178);
            this.UrunAdi.Name = "UrunAdi";
            this.UrunAdi.Size = new System.Drawing.Size(51, 20);
            this.UrunAdi.TabIndex = 1;
            this.UrunAdi.Text = "label1";
            // 
            // UrunFiyati
            // 
            this.UrunFiyati.AutoSize = true;
            this.UrunFiyati.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunFiyati.Location = new System.Drawing.Point(41, 211);
            this.UrunFiyati.Name = "UrunFiyati";
            this.UrunFiyati.Size = new System.Drawing.Size(51, 20);
            this.UrunFiyati.TabIndex = 2;
            this.UrunFiyati.Text = "label2";
            // 
            // UrunMiktari
            // 
            this.UrunMiktari.AutoSize = true;
            this.UrunMiktari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunMiktari.Location = new System.Drawing.Point(41, 243);
            this.UrunMiktari.Name = "UrunMiktari";
            this.UrunMiktari.Size = new System.Drawing.Size(51, 20);
            this.UrunMiktari.TabIndex = 4;
            this.UrunMiktari.Text = "label4";
            // 
            // SepeteEkleButon
            // 
            this.SepeteEkleButon.AutoRoundedCorners = true;
            this.SepeteEkleButon.BorderRadius = 15;
            this.SepeteEkleButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SepeteEkleButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SepeteEkleButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SepeteEkleButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SepeteEkleButon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SepeteEkleButon.ForeColor = System.Drawing.Color.White;
            this.SepeteEkleButon.Location = new System.Drawing.Point(62, 283);
            this.SepeteEkleButon.Name = "SepeteEkleButon";
            this.SepeteEkleButon.Size = new System.Drawing.Size(123, 33);
            this.SepeteEkleButon.TabIndex = 5;
            this.SepeteEkleButon.Text = "Sepete Ekle";
            this.SepeteEkleButon.Click += new System.EventHandler(this.SepeteEkleButon_Click);
            // 
            // UrunKarti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.SepeteEkleButon);
            this.Controls.Add(this.UrunMiktari);
            this.Controls.Add(this.UrunFiyati);
            this.Controls.Add(this.UrunAdi);
            this.Controls.Add(this.MiktarCircleBar);
            this.Name = "UrunKarti";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(232, 325);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar MiktarCircleBar;
        private System.Windows.Forms.Label UrunAdi;
        private System.Windows.Forms.Label UrunFiyati;
        private System.Windows.Forms.Label UrunMiktari;
        private Guna.UI2.WinForms.Guna2Button SepeteEkleButon;
    }
}
