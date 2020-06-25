namespace POS.VPOS
{
    partial class TCPConnectionInfoScreen
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
            this.imgQRCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // imgQRCode
            // 
            this.imgQRCode.Location = new System.Drawing.Point(0, 0);
            this.imgQRCode.Name = "imgQRCode";
            this.imgQRCode.Size = new System.Drawing.Size(139, 137);
            this.imgQRCode.TabIndex = 0;
            this.imgQRCode.TabStop = false;
            // 
            // TCPConnectionInfoScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgQRCode);
            this.Name = "TCPConnectionInfoScreen";
            this.Size = new System.Drawing.Size(139, 137);
            ((System.ComponentModel.ISupportInitialize)(this.imgQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgQRCode;
    }
}
