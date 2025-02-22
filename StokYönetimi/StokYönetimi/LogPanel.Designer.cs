namespace StokYönetimi.Model
{
    partial class LogPanel
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
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.logFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "POS";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.guna2MessageDialog1.Text = null;
            // 
            // logFlowLayoutPanel
            // 
            this.logFlowLayoutPanel.Location = new System.Drawing.Point(22, 12);
            this.logFlowLayoutPanel.Name = "logFlowLayoutPanel";
            this.logFlowLayoutPanel.Size = new System.Drawing.Size(753, 413);
            this.logFlowLayoutPanel.TabIndex = 0;
            // 
            // LogPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logFlowLayoutPanel);
            this.Name = "LogPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Samplecs";
            this.Load += new System.EventHandler(this.LogPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private System.Windows.Forms.FlowLayoutPanel logFlowLayoutPanel;
    }
}