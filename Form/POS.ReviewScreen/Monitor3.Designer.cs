namespace POS.ReviewScreen
{
    partial class formMonitor3
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
            this.pnlView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlView
            // 
            this.pnlView.AutoSize = true;
            this.pnlView.Location = new System.Drawing.Point(0, 0);
            this.pnlView.Margin = new System.Windows.Forms.Padding(0);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(400, 300);
            this.pnlView.TabIndex = 0;
            // 
            // formMonitor3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formMonitor3";
            this.Text = "Monitor3";
            this.Load += new System.EventHandler(this.Monitor3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlView;
    }
}