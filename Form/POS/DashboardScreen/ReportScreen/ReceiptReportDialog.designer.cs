using System.ComponentModel;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;

namespace POS.DashboardScreen.ReportScreen
{
    partial class ReceiptReportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.containerOuter = new System.Windows.Forms.Panel();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.lblUp = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.btnClose = new POS.Common.FlexButton();
            this.containerOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // containerOuter
            // 
            this.containerOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.containerOuter.Controls.Add(this.pBox);
            this.containerOuter.Location = new System.Drawing.Point(16, 57);
            this.containerOuter.Name = "containerOuter";
            this.containerOuter.Size = new System.Drawing.Size(286, 578);
            this.containerOuter.TabIndex = 4;
            // 
            // pBox
            // 
            this.pBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pBox.Location = new System.Drawing.Point(3, 117);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(280, 155);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBox.TabIndex = 0;
            this.pBox.TabStop = false;
            // 
            // lblUp
            // 
            this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.ForeColor = System.Drawing.Color.Transparent;
            this.lblUp.Location = new System.Drawing.Point(46, 650);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(90, 40);
            this.lblUp.TabIndex = 0;
            this.lblUp.Click += new System.EventHandler(this.lblUp_Click_1);
            // 
            // lblDown
            // 
            this.lblDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.ForeColor = System.Drawing.Color.Transparent;
            this.lblDown.Location = new System.Drawing.Point(166, 650);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(90, 40);
            this.lblDown.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.White;
            this.btnClose.BorderRadius = 2;
            this.btnClose.BorderThick = 1;
            this.btnClose.Caption = "X";
            this.btnClose.CenterImageDisable = null;
            this.btnClose.CenterImageNormal = null;
            this.btnClose.CenterImagePress = null;
            this.btnClose.DisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnClose.IsActivated = false;
            this.btnClose.LeftImageDisable = null;
            this.btnClose.LeftImageGap = 0;
            this.btnClose.LeftImageNornal = null;
            this.btnClose.LeftImagePress = null;
            this.btnClose.Location = new System.Drawing.Point(260, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnClose.PressColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(42, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReceiptReportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(318, 700);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.containerOuter);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.lblDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReceiptReportDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateSelectDialog";
            this.TopMost = true;
            this.containerOuter.ResumeLayout(false);
            this.containerOuter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel containerOuter;
        private Label lblUp;
        private Label lblDown;
//        private FlexButton btnUp;
//        private FlexButton btnDown;
        private PictureBox pBox;
        private FlexButton btnClose;
    }
}