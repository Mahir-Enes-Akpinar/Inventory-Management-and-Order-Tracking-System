namespace StokYönetimi
{
    partial class Form1
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KullaniciAdiField = new Guna.UI2.WinForms.Guna2TextBox();
            this.GirisButonu1 = new Guna.UI2.WinForms.Guna2Button();
            this.SifreAlani = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(21, 63);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(329, 304);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(504, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // KullaniciAdiField
            // 
            this.KullaniciAdiField.AutoRoundedCorners = true;
            this.KullaniciAdiField.BorderRadius = 23;
            this.KullaniciAdiField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KullaniciAdiField.DefaultText = "";
            this.KullaniciAdiField.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KullaniciAdiField.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KullaniciAdiField.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KullaniciAdiField.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KullaniciAdiField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KullaniciAdiField.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KullaniciAdiField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KullaniciAdiField.Location = new System.Drawing.Point(488, 137);
            this.KullaniciAdiField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.KullaniciAdiField.Name = "KullaniciAdiField";
            this.KullaniciAdiField.PasswordChar = '\0';
            this.KullaniciAdiField.PlaceholderText = "";
            this.KullaniciAdiField.SelectedText = "";
            this.KullaniciAdiField.Size = new System.Drawing.Size(229, 48);
            this.KullaniciAdiField.TabIndex = 2;
            // 
            // GirisButonu1
            // 
            this.GirisButonu1.AutoRoundedCorners = true;
            this.GirisButonu1.BorderRadius = 21;
            this.GirisButonu1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GirisButonu1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GirisButonu1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GirisButonu1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GirisButonu1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.GirisButonu1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GirisButonu1.ForeColor = System.Drawing.Color.White;
            this.GirisButonu1.Location = new System.Drawing.Point(509, 359);
            this.GirisButonu1.Name = "GirisButonu1";
            this.GirisButonu1.Size = new System.Drawing.Size(180, 45);
            this.GirisButonu1.TabIndex = 3;
            this.GirisButonu1.Text = "Giriş Yap";
            this.GirisButonu1.Click += new System.EventHandler(this.GirisButonu_Click);
            // 
            // SifreAlani
            // 
            this.SifreAlani.AutoRoundedCorners = true;
            this.SifreAlani.BorderRadius = 23;
            this.SifreAlani.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SifreAlani.DefaultText = "";
            this.SifreAlani.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SifreAlani.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SifreAlani.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SifreAlani.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SifreAlani.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SifreAlani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SifreAlani.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SifreAlani.Location = new System.Drawing.Point(488, 264);
            this.SifreAlani.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SifreAlani.Name = "SifreAlani";
            this.SifreAlani.PasswordChar = '\0';
            this.SifreAlani.PlaceholderText = "";
            this.SifreAlani.SelectedText = "";
            this.SifreAlani.Size = new System.Drawing.Size(229, 48);
            this.SifreAlani.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(504, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kullanıcı Şifresi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SifreAlani);
            this.Controls.Add(this.GirisButonu1);
            this.Controls.Add(this.KullaniciAdiField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox KullaniciAdiField;
        private Guna.UI2.WinForms.Guna2Button GirisButonu1;
        private Guna.UI2.WinForms.Guna2TextBox SifreAlani;
        private System.Windows.Forms.Label label2;
    }
}

