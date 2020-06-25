using POS.Common;
using POS.CustomControl;

namespace POS
{
    partial class FunctionPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionPanel));
            this.clockControl1 = new POS.Common.ClockControl();
            this.btnMainFunction = new POS.Common.FlexButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnHide = new POS.Common.FlexButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clockControl1
            // 
            this.clockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clockControl1.BackColor = System.Drawing.Color.Transparent;
            this.clockControl1.Location = new System.Drawing.Point(3, 14);
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.Size = new System.Drawing.Size(230, 50);
            this.clockControl1.TabIndex = 6;
            this.clockControl1.Text = "abc";
            // 
            // btnMainFunction
            // 
            this.btnMainFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainFunction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnMainFunction.BorderRadius = 1;
            this.btnMainFunction.BorderThick = 4;
            this.btnMainFunction.Caption = "Main function";
            this.btnMainFunction.CenterImageDisable = null;
            this.btnMainFunction.CenterImageNormal = null;
            this.btnMainFunction.CenterImagePress = null;
            this.btnMainFunction.DisableColor = System.Drawing.Color.Empty;
            this.btnMainFunction.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnMainFunction.IsActivated = false;
            this.btnMainFunction.LeftImageDisable = null;
            this.btnMainFunction.LeftImageGap = 0;
            this.btnMainFunction.LeftImageNornal = null;
            this.btnMainFunction.LeftImagePress = null;
            this.btnMainFunction.Location = new System.Drawing.Point(693, -4);
            this.btnMainFunction.Margin = new System.Windows.Forms.Padding(2);
            this.btnMainFunction.Name = "btnMainFunction";
            this.btnMainFunction.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnMainFunction.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnMainFunction.Size = new System.Drawing.Size(154, 81);
            this.btnMainFunction.TabIndex = 8;
            this.btnMainFunction.Load += new System.EventHandler(this.btnMainFunction_Load);
            this.btnMainFunction.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(308, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(385, 28);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(27, 29);
            this.lblNumber.TabIndex = 10;
            this.lblNumber.Text = "1";
            this.lblNumber.Visible = false;
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnHide.BorderRadius = 1;
            this.btnHide.BorderThick = 4;
            this.btnHide.Caption = "Hide";
            this.btnHide.CenterImageDisable = null;
            this.btnHide.CenterImageNormal = null;
            this.btnHide.CenterImagePress = null;
            this.btnHide.DisableColor = System.Drawing.Color.Empty;
            this.btnHide.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnHide.IsActivated = false;
            this.btnHide.LeftImageDisable = null;
            this.btnHide.LeftImageGap = 0;
            this.btnHide.LeftImageNornal = null;
            this.btnHide.LeftImagePress = null;
            this.btnHide.Location = new System.Drawing.Point(535, -4);
            this.btnHide.Margin = new System.Windows.Forms.Padding(2);
            this.btnHide.Name = "btnHide";
            this.btnHide.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnHide.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnHide.Size = new System.Drawing.Size(154, 81);
            this.btnHide.TabIndex = 11;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // FunctionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnMainFunction);
            this.Controls.Add(this.clockControl1);
            this.Name = "FunctionPanel";
            this.Size = new System.Drawing.Size(847, 67);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClockControl clockControl1;
        private FlexButton btnMainFunction;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumber;
        private FlexButton btnHide;
    }
}
