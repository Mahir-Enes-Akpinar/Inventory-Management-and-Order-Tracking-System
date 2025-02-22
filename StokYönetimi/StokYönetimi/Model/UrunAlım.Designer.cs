namespace StokYönetimi.Model
{
    partial class UrunAlım
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewSepet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.UrunAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toplam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SepetOnayButon = new Guna.UI2.WinForms.Guna2Button();
            this.SepetTutari = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSepet)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(50, 10, 50, 10);
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(739, 488);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.TabStop = true;
            // 
            // dataGridViewSepet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewSepet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSepet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSepet.ColumnHeadersHeight = 45;
            this.dataGridViewSepet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewSepet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UrunAdi,
            this.Miktar,
            this.Fiyat,
            this.Toplam,
            this.Sil});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSepet.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSepet.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridViewSepet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSepet.Location = new System.Drawing.Point(739, 0);
            this.dataGridViewSepet.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewSepet.Name = "dataGridViewSepet";
            this.dataGridViewSepet.RowHeadersVisible = false;
            this.dataGridViewSepet.RowHeadersWidth = 51;
            this.dataGridViewSepet.RowTemplate.Height = 24;
            this.dataGridViewSepet.Size = new System.Drawing.Size(442, 573);
            this.dataGridViewSepet.TabIndex = 2;
            this.dataGridViewSepet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSepet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewSepet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewSepet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewSepet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewSepet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSepet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewSepet.ThemeStyle.HeaderStyle.Height = 45;
            this.dataGridViewSepet.ThemeStyle.ReadOnly = false;
            this.dataGridViewSepet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSepet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewSepet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridViewSepet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewSepet.ThemeStyle.RowsStyle.Height = 24;
            this.dataGridViewSepet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewSepet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewSepet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSepet_CellContentClick);
            // 
            // UrunAdi
            // 
            this.UrunAdi.HeaderText = "Ürün Adı";
            this.UrunAdi.MinimumWidth = 6;
            this.UrunAdi.Name = "UrunAdi";
            // 
            // Miktar
            // 
            this.Miktar.HeaderText = "Miktar";
            this.Miktar.MinimumWidth = 6;
            this.Miktar.Name = "Miktar";
            // 
            // Fiyat
            // 
            this.Fiyat.HeaderText = "Fiyat";
            this.Fiyat.MinimumWidth = 6;
            this.Fiyat.Name = "Fiyat";
            // 
            // Toplam
            // 
            this.Toplam.HeaderText = "Toplam Fiyatı";
            this.Toplam.MinimumWidth = 6;
            this.Toplam.Name = "Toplam";
            // 
            // Sil
            // 
            this.Sil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Sil.HeaderText = "Sil";
            this.Sil.MinimumWidth = 6;
            this.Sil.Name = "Sil";
            this.Sil.Text = "Sil";
            this.Sil.UseColumnTextForButtonValue = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel1.BorderRadius = 60;
            this.guna2Panel1.Controls.Add(this.SepetOnayButon);
            this.guna2Panel1.Controls.Add(this.SepetTutari);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(739, 90);
            this.guna2Panel1.TabIndex = 3;
            // 
            // SepetOnayButon
            // 
            this.SepetOnayButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SepetOnayButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SepetOnayButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SepetOnayButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SepetOnayButon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SepetOnayButon.ForeColor = System.Drawing.Color.White;
            this.SepetOnayButon.Location = new System.Drawing.Point(522, 19);
            this.SepetOnayButon.Name = "SepetOnayButon";
            this.SepetOnayButon.Size = new System.Drawing.Size(180, 45);
            this.SepetOnayButon.TabIndex = 1;
            this.SepetOnayButon.Text = "Sepeti Onayla";
            this.SepetOnayButon.Click += new System.EventHandler(this.SepetOnayButon_Click);
            // 
            // SepetTutari
            // 
            this.SepetTutari.AutoSize = true;
            this.SepetTutari.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SepetTutari.ForeColor = System.Drawing.Color.White;
            this.SepetTutari.Location = new System.Drawing.Point(12, 18);
            this.SepetTutari.Name = "SepetTutari";
            this.SepetTutari.Size = new System.Drawing.Size(225, 45);
            this.SepetTutari.TabIndex = 0;
            this.SepetTutari.Text = "Sepet Tutarı :";
            // 
            // UrunAlım
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 573);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.dataGridViewSepet);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UrunAlım";
            this.Text = "UrunAlım";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSepet)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewSepet;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrunAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toplam;
        private System.Windows.Forms.DataGridViewButtonColumn Sil;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label SepetTutari;
        private Guna.UI2.WinForms.Guna2Button SepetOnayButon;
    }
}