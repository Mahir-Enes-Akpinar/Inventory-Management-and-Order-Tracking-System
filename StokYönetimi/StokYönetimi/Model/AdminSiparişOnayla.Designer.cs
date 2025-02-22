namespace StokYönetimi.Model
{
    partial class AdminSiparişOnayla
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SiparisOnaylaButon = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.OnayBekleyenList = new System.Windows.Forms.ListView();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(179)))), ((int)(((byte)(206)))));
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.SiparisOnaylaButon);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(928, 138);
            this.guna2Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sipariş Onay Yönetimi";
            // 
            // SiparisOnaylaButon
            // 
            this.SiparisOnaylaButon.AutoRoundedCorners = true;
            this.SiparisOnaylaButon.BorderRadius = 21;
            this.SiparisOnaylaButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SiparisOnaylaButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SiparisOnaylaButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SiparisOnaylaButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SiparisOnaylaButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.SiparisOnaylaButon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SiparisOnaylaButon.ForeColor = System.Drawing.Color.White;
            this.SiparisOnaylaButon.Location = new System.Drawing.Point(47, 74);
            this.SiparisOnaylaButon.Name = "SiparisOnaylaButon";
            this.SiparisOnaylaButon.Size = new System.Drawing.Size(180, 45);
            this.SiparisOnaylaButon.TabIndex = 0;
            this.SiparisOnaylaButon.Text = "Siparişleri Onayla";
            this.SiparisOnaylaButon.Click += new System.EventHandler(this.SiparisOnaylaButon_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.guna2Panel2.Controls.Add(this.OnayBekleyenList);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 138);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(928, 302);
            this.guna2Panel2.TabIndex = 1;
            // 
            // OnayBekleyenList
            // 
            this.OnayBekleyenList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnayBekleyenList.HideSelection = false;
            this.OnayBekleyenList.Location = new System.Drawing.Point(107, 50);
            this.OnayBekleyenList.Name = "OnayBekleyenList";
            this.OnayBekleyenList.Size = new System.Drawing.Size(708, 218);
            this.OnayBekleyenList.TabIndex = 0;
            this.OnayBekleyenList.UseCompatibleStateImageBehavior = false;
            // 
            // AdminSiparişOnayla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 440);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "AdminSiparişOnayla";
            this.Text = "AdminSiparişOnayla";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.ListView OnayBekleyenList;
        private Guna.UI2.WinForms.Guna2Button SiparisOnaylaButon;
        private System.Windows.Forms.Label label1;
    }
}