using System;
using System.Windows.Forms;

namespace StokYönetimi
{
    partial class StokYoneti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StokYoneti));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.UrunEkleButon = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.UrunTablosu = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunTablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(179)))), ((int)(((byte)(206)))));
            this.guna2Panel1.Controls.Add(this.UrunEkleButon);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(886, 138);
            this.guna2Panel1.TabIndex = 0;
            // 
            // UrunEkleButon
            // 
            this.UrunEkleButon.Animated = true;
            this.UrunEkleButon.AutoRoundedCorners = true;
            this.UrunEkleButon.BorderRadius = 21;
            this.UrunEkleButon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.UrunEkleButon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.UrunEkleButon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.UrunEkleButon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.UrunEkleButon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            this.UrunEkleButon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.UrunEkleButon.ForeColor = System.Drawing.Color.White;
            this.UrunEkleButon.Image = ((System.Drawing.Image)(resources.GetObject("UrunEkleButon.Image")));
            this.UrunEkleButon.Location = new System.Drawing.Point(40, 68);
            this.UrunEkleButon.Name = "UrunEkleButon";
            this.UrunEkleButon.Size = new System.Drawing.Size(180, 45);
            this.UrunEkleButon.TabIndex = 1;
            this.UrunEkleButon.Text = "Ürün Ekle";
            this.UrunEkleButon.Click += new System.EventHandler(this.UrunEkleButon_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stok Yönetimi";
            // 
            // UrunTablosu
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.UrunTablosu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.UrunTablosu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(62)))), ((int)(((byte)(125)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UrunTablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.UrunTablosu.ColumnHeadersHeight = 34;
            this.UrunTablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.UrunTablosu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSr,
            this.ProductID,
            this.ProductName,
            this.dgvStock,
            this.Price,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UrunTablosu.DefaultCellStyle = dataGridViewCellStyle15;
            this.UrunTablosu.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UrunTablosu.Location = new System.Drawing.Point(40, 158);
            this.UrunTablosu.Name = "UrunTablosu";
            this.UrunTablosu.RowHeadersVisible = false;
            this.UrunTablosu.RowHeadersWidth = 51;
            this.UrunTablosu.RowTemplate.Height = 24;
            this.UrunTablosu.Size = new System.Drawing.Size(800, 321);
            this.UrunTablosu.TabIndex = 1;
            this.UrunTablosu.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.UrunTablosu.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.UrunTablosu.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.UrunTablosu.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.UrunTablosu.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.UrunTablosu.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.UrunTablosu.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UrunTablosu.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.UrunTablosu.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.UrunTablosu.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunTablosu.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.UrunTablosu.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.UrunTablosu.ThemeStyle.HeaderStyle.Height = 34;
            this.UrunTablosu.ThemeStyle.ReadOnly = false;
            this.UrunTablosu.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.UrunTablosu.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.UrunTablosu.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UrunTablosu.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.UrunTablosu.ThemeStyle.RowsStyle.Height = 24;
            this.UrunTablosu.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UrunTablosu.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.UrunTablosu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UrunTablosu_CellContentClick_1);
            // 
            // dgvSr
            // 
            this.dgvSr.HeaderText = "Sr #";
            this.dgvSr.MinimumWidth = 6;
            this.dgvSr.Name = "dgvSr";
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            // 
            // dgvStock
            // 
            this.dgvStock.HeaderText = "Stock";
            this.dgvStock.MinimumWidth = 6;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            // 
            // StokYoneti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(220)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.UrunTablosu);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "StokYoneti";
            this.Text = "StokYonetimi";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UrunTablosu)).EndInit();
            this.ResumeLayout(false);

        }

        private void UrunTablosu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button UrunEkleButon;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView UrunTablosu;
        private DataGridViewTextBoxColumn dgvSr;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn dgvStock;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
    }
}