namespace StokYönetimi
{
    partial class KullaniciEKlePanel
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
            this.KullaniciAdi = new System.Windows.Forms.TextBox();
            this.KullaniciBakiye = new System.Windows.Forms.NumericUpDown();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.KullaniciTürüComboBox = new System.Windows.Forms.ComboBox();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.KullaniciBakiye)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KullaniciAdi
            // 
            this.KullaniciAdi.Location = new System.Drawing.Point(12, 94);
            this.KullaniciAdi.Name = "KullaniciAdi";
            this.KullaniciAdi.Size = new System.Drawing.Size(120, 25);
            this.KullaniciAdi.TabIndex = 0;
            // 
            // KullaniciBakiye
            // 
            this.KullaniciBakiye.Location = new System.Drawing.Point(12, 205);
            this.KullaniciBakiye.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.KullaniciBakiye.Name = "KullaniciBakiye";
            this.KullaniciBakiye.Size = new System.Drawing.Size(120, 25);
            this.KullaniciBakiye.TabIndex = 3;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.KullaniciTürüComboBox);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel5);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel4);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel3);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnCancel);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnAddCustomer);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2CustomGradientPanel1.Controls.Add(this.KullaniciAdi);
            this.guna2CustomGradientPanel1.Controls.Add(this.KullaniciBakiye);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.LightBlue;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.DodgerBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.DarkGray;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Silver;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(344, 379);
            this.guna2CustomGradientPanel1.TabIndex = 7;
            // 
            // KullaniciTürüComboBox
            // 
            this.KullaniciTürüComboBox.FormattingEnabled = true;
            this.KullaniciTürüComboBox.Items.AddRange(new object[] {
            "Premium",
            "Standart"});
            this.KullaniciTürüComboBox.Location = new System.Drawing.Point(13, 150);
            this.KullaniciTürüComboBox.Name = "KullaniciTürüComboBox";
            this.KullaniciTürüComboBox.Size = new System.Drawing.Size(121, 25);
            this.KullaniciTürüComboBox.TabIndex = 13;
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(12, 69);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(75, 18);
            this.guna2HtmlLabel5.TabIndex = 12;
            this.guna2HtmlLabel5.Text = "Kullanıcı Adı";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(12, 181);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(97, 18);
            this.guna2HtmlLabel4.TabIndex = 11;
            this.guna2HtmlLabel4.Text = "Kullanıcı Bakiye";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(12, 125);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(82, 18);
            this.guna2HtmlLabel3.TabIndex = 10;
            this.guna2HtmlLabel3.Text = "Kullanıcı Türü";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.DarkRed;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(200, 268);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 35);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "İptal";
            this.btnCancel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCustomer.BorderRadius = 20;
            this.btnAddCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddCustomer.FillColor = System.Drawing.Color.Green;
            this.btnAddCustomer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.Location = new System.Drawing.Point(49, 268);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(83, 35);
            this.btnAddCustomer.TabIndex = 7;
            this.btnAddCustomer.Text = "Ekle";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(176, 39);
            this.guna2HtmlLabel1.TabIndex = 6;
            this.guna2HtmlLabel1.Text = "Kullanıcı Ekle";
            // 
            // KullaniciEKlePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 379);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "KullaniciEKlePanel";
            this.Text = "Ürün Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.KullaniciBakiye)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox KullaniciAdi;
        private System.Windows.Forms.NumericUpDown KullaniciBakiye;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnAddCustomer;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private System.Windows.Forms.ComboBox KullaniciTürüComboBox;
    }
}