namespace StokYönetimi
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cıkısButon = new Guna.UI2.WinForms.Guna2Button();
            this.OnayYonetimButon = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.KullaniciYonetimiButon = new Guna.UI2.WinForms.Guna2Button();
            this.StokYönetimiButon = new Guna.UI2.WinForms.Guna2Button();
            this.IcerikPanel = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 250);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 52);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(139)))), ((int)(((byte)(193)))));
            this.panel3.Controls.Add(this.cıkısButon);
            this.panel3.Controls.Add(this.OnayYonetimButon);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.KullaniciYonetimiButon);
            this.panel3.Controls.Add(this.StokYönetimiButon);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(273, 651);
            this.panel3.TabIndex = 2;
            // 
            // cıkısButon
            // 
            this.cıkısButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cıkısButon.BorderRadius = 8;
            this.cıkısButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cıkısButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cıkısButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cıkısButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cıkısButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.cıkısButon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cıkısButon.ForeColor = System.Drawing.Color.White;
            this.cıkısButon.Image = global::StokYönetimi.Properties.Resources.logout_24dp_E8EAED_FILL0_wght400_GRAD0_opsz24;
            this.cıkısButon.ImageSize = new System.Drawing.Size(25, 25);
            this.cıkısButon.Location = new System.Drawing.Point(13, 319);
            this.cıkısButon.Name = "cıkısButon";
            this.cıkısButon.Size = new System.Drawing.Size(252, 47);
            this.cıkısButon.TabIndex = 4;
            this.cıkısButon.Text = "Çıkış Yap";
            this.cıkısButon.Click += new System.EventHandler(this.cıkısButon_Click);
            // 
            // OnayYonetimButon
            // 
            this.OnayYonetimButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnayYonetimButon.BorderRadius = 8;
            this.OnayYonetimButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.OnayYonetimButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.OnayYonetimButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.OnayYonetimButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.OnayYonetimButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.OnayYonetimButon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.OnayYonetimButon.ForeColor = System.Drawing.Color.White;
            this.OnayYonetimButon.Image = global::StokYönetimi.Properties.Resources.check_circle_24dp_E8EAED_FILL0_wght400_GRAD0_opsz24;
            this.OnayYonetimButon.ImageSize = new System.Drawing.Size(25, 25);
            this.OnayYonetimButon.Location = new System.Drawing.Point(12, 154);
            this.OnayYonetimButon.Name = "OnayYonetimButon";
            this.OnayYonetimButon.Size = new System.Drawing.Size(252, 47);
            this.OnayYonetimButon.TabIndex = 2;
            this.OnayYonetimButon.Text = "Onay Yönetimi";
            this.OnayYonetimButon.Click += new System.EventHandler(this.OnayYonetimButon_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StokYönetimi.Properties.Resources.admin_panel_settings_24dp_E8EAED_FILL0_wght400_GRAD0_opsz24;
            this.pictureBox1.Location = new System.Drawing.Point(82, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // KullaniciYonetimiButon
            // 
            this.KullaniciYonetimiButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KullaniciYonetimiButon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(139)))), ((int)(((byte)(193)))));
            this.KullaniciYonetimiButon.BorderRadius = 8;
            this.KullaniciYonetimiButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.KullaniciYonetimiButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.KullaniciYonetimiButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.KullaniciYonetimiButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.KullaniciYonetimiButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.KullaniciYonetimiButon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.KullaniciYonetimiButon.ForeColor = System.Drawing.Color.White;
            this.KullaniciYonetimiButon.Image = global::StokYönetimi.Properties.Resources.person_24dp_E8EAED_FILL0_wght400_GRAD0_opsz24;
            this.KullaniciYonetimiButon.ImageSize = new System.Drawing.Size(25, 25);
            this.KullaniciYonetimiButon.Location = new System.Drawing.Point(12, 207);
            this.KullaniciYonetimiButon.Name = "KullaniciYonetimiButon";
            this.KullaniciYonetimiButon.Size = new System.Drawing.Size(252, 53);
            this.KullaniciYonetimiButon.TabIndex = 1;
            this.KullaniciYonetimiButon.Text = "Kullanıcı Yönetimi";
            this.KullaniciYonetimiButon.Click += new System.EventHandler(this.KullaniciYonetimiButon_Click);
            // 
            // StokYönetimiButon
            // 
            this.StokYönetimiButon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StokYönetimiButon.BorderRadius = 8;
            this.StokYönetimiButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.StokYönetimiButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.StokYönetimiButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.StokYönetimiButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.StokYönetimiButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.StokYönetimiButon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.StokYönetimiButon.ForeColor = System.Drawing.Color.White;
            this.StokYönetimiButon.Image = global::StokYönetimi.Properties.Resources.inventory_2_24dp_E8EAED_FILL0_wght400_GRAD0_opsz24;
            this.StokYönetimiButon.ImageSize = new System.Drawing.Size(25, 25);
            this.StokYönetimiButon.Location = new System.Drawing.Point(12, 266);
            this.StokYönetimiButon.Name = "StokYönetimiButon";
            this.StokYönetimiButon.Size = new System.Drawing.Size(252, 47);
            this.StokYönetimiButon.TabIndex = 0;
            this.StokYönetimiButon.Text = "Stok Yönetimi";
            this.StokYönetimiButon.Click += new System.EventHandler(this.StokYönetimiButon_Click);
            // 
            // IcerikPanel
            // 
            this.IcerikPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IcerikPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.IcerikPanel.Location = new System.Drawing.Point(271, 52);
            this.IcerikPanel.Name = "IcerikPanel";
            this.IcerikPanel.Size = new System.Drawing.Size(911, 651);
            this.IcerikPanel.TabIndex = 3;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.IcerikPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel IcerikPanel;
        private Guna.UI2.WinForms.Guna2Button KullaniciYonetimiButon;
        private Guna.UI2.WinForms.Guna2Button StokYönetimiButon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button OnayYonetimButon;
        private Guna.UI2.WinForms.Guna2Button cıkısButon;
    }
}