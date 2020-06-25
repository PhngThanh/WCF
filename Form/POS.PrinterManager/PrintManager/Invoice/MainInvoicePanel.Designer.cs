
namespace POS.PrintManager.Invoice
{
    partial class MainInvoicePanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblWiSkyInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Black;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(100, 100);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(967, 1453);
            this.pnlMain.TabIndex = 0;
            // 
            // lblWiSkyInfo
            // 
            this.lblWiSkyInfo.AutoSize = true;
            this.lblWiSkyInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWiSkyInfo.Location = new System.Drawing.Point(417, 1561);
            this.lblWiSkyInfo.Name = "lblWiSkyInfo";
            this.lblWiSkyInfo.Size = new System.Drawing.Size(311, 15);
            this.lblWiSkyInfo.TabIndex = 55;
            this.lblWiSkyInfo.Text = "In từ phần mềm SKYPOS - www.wisky.vn - 083 715 5700";
            // 
            // InvoicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblWiSkyInfo);
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InvoicePanel";
            this.Size = new System.Drawing.Size(1167, 1653);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblWiSkyInfo;
    }
}
