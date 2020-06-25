using System;

namespace POS.DashboardScreen
{
    partial class ViewOrderDetailDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new POS.Common.FlexButton();
            this.btnCancel = new POS.Common.FlexButton();
            this.btnHide = new POS.Common.FlexButton();
            this.btnReject = new POS.Common.FlexButton();
            this.btnAccept = new POS.Common.FlexButton();
            this.btnPrint = new POS.Common.FlexButton();
            this.orderDetailControl = new ViewOrderDetailControl();
            this.btnPrintWifiPass = new POS.Common.FlexButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnPrintWifiPass);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnHide);
            this.panel1.Controls.Add(this.btnReject);
            this.panel1.Controls.Add(this.btnAccept);
            //this.panel1.Controls.Add(this.btnPrintVAT);
            this.panel1.Location = new System.Drawing.Point(12, 580);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 54);
            this.panel1.TabIndex = 30;
            // 
            // orderDetailControl1
            // 
            this.orderDetailControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.orderDetailControl.Location = new System.Drawing.Point(12, 18);
            this.orderDetailControl.Name = "orderDetailControl";
            this.orderDetailControl.Size = new System.Drawing.Size(777, 556);
            this.orderDetailControl.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BorderColor = System.Drawing.Color.White;
            this.btnPrint.BorderRadius = 3;
            this.btnPrint.BorderThick = 1;
            this.btnPrint.Caption = "Print Bill";
            this.btnPrint.CenterImageDisable = null;
            this.btnPrint.CenterImageNormal = null;
            this.btnPrint.CenterImagePress = null;
            this.btnPrint.DisableColor = System.Drawing.Color.Empty;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.IsActivated = false;
            this.btnPrint.LeftImageDisable = null;
            this.btnPrint.LeftImageGap = 0;
            this.btnPrint.LeftImageNornal = null;
            this.btnPrint.LeftImagePress = null;
            this.btnPrint.Location = new System.Drawing.Point(366, 8);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnPrint.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnPrint.Size = new System.Drawing.Size(116, 37);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 3;
            this.btnCancel.BorderThick = 1;
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.CenterImageDisable = null;
            this.btnCancel.CenterImageNormal = null;
            this.btnCancel.CenterImagePress = null;
            this.btnCancel.DisableColor = System.Drawing.Color.Empty;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.IsActivated = false;
            this.btnCancel.LeftImageDisable = null;
            this.btnCancel.LeftImageGap = 0;
            this.btnCancel.LeftImageNornal = null;
            this.btnCancel.LeftImagePress = null;
            this.btnCancel.Location = new System.Drawing.Point(186, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnCancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnCancel.Size = new System.Drawing.Size(116, 37);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHide.BorderColor = System.Drawing.Color.White;
            this.btnHide.BorderRadius = 3;
            this.btnHide.BorderThick = 1;
            this.btnHide.Caption = "Hide";
            this.btnHide.CenterImageDisable = null;
            this.btnHide.CenterImageNormal = null;
            this.btnHide.CenterImagePress = null;
            this.btnHide.DisableColor = System.Drawing.Color.Empty;
            this.btnHide.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHide.IsActivated = false;
            this.btnHide.LeftImageDisable = null;
            this.btnHide.LeftImageGap = 0;
            this.btnHide.LeftImageNornal = null;
            this.btnHide.LeftImagePress = null;
            this.btnHide.Location = new System.Drawing.Point(13, 8);
            this.btnHide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHide.Name = "btnHide";
            this.btnHide.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnHide.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnHide.Size = new System.Drawing.Size(116, 37);
            this.btnHide.TabIndex = 0;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnReject
            // 
            this.btnReject.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReject.BorderColor = System.Drawing.Color.White;
            this.btnReject.BorderRadius = 3;
            this.btnReject.BorderThick = 1;
            this.btnReject.Caption = "Reject";
            this.btnReject.CenterImageDisable = null;
            this.btnReject.CenterImageNormal = null;
            this.btnReject.CenterImagePress = null;
            this.btnReject.DisableColor = System.Drawing.Color.Empty;
            this.btnReject.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.IsActivated = false;
            this.btnReject.LeftImageDisable = null;
            this.btnReject.LeftImageGap = 0;
            this.btnReject.LeftImageNornal = null;
            this.btnReject.LeftImagePress = null;
            this.btnReject.Location = new System.Drawing.Point(210, 8);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReject.Name = "btnReject";
            this.btnReject.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnReject.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnReject.Size = new System.Drawing.Size(116, 37);
            this.btnReject.TabIndex = 3;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.BorderColor = System.Drawing.Color.White;
            this.btnAccept.BorderRadius = 3;
            this.btnAccept.BorderThick = 1;
            this.btnAccept.Caption = "Accept";
            this.btnAccept.CenterImageDisable = null;
            this.btnAccept.CenterImageNormal = null;
            this.btnAccept.CenterImagePress = null;
            this.btnAccept.DisableColor = System.Drawing.Color.Empty;
            this.btnAccept.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.IsActivated = false;
            this.btnAccept.LeftImageDisable = null;
            this.btnAccept.LeftImageGap = 0;
            this.btnAccept.LeftImageNornal = null;
            this.btnAccept.LeftImagePress = null;
            this.btnAccept.Location = new System.Drawing.Point(648, 8);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnAccept.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnAccept.Size = new System.Drawing.Size(116, 37);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnPrintVAT
            // 
            //this.btnPrintVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.btnPrintVAT.BorderColor = System.Drawing.Color.White;
            //this.btnPrintVAT.BorderRadius = 3;
            //this.btnPrintVAT.BorderThick = 1;
            //this.btnPrintVAT.Caption = "Print VAT Bill";
            //this.btnPrintVAT.CenterImageDisable = null;
            //this.btnPrintVAT.CenterImageNormal = null;
            //this.btnPrintVAT.CenterImagePress = null;
            //this.btnPrintVAT.DisableColor = System.Drawing.Color.Empty;
            //this.btnPrintVAT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnPrintVAT.IsActivated = false;
            //this.btnPrintVAT.LeftImageDisable = null;
            //this.btnPrintVAT.LeftImageGap = 0;
            //this.btnPrintVAT.LeftImageNornal = null;
            //this.btnPrintVAT.LeftImagePress = null;
            //this.btnPrintVAT.Location = new System.Drawing.Point(490, 8);
            //this.btnPrintVAT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            //this.btnPrintVAT.Name = "btnPrintVAT";
            //this.btnPrintVAT.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            //this.btnPrintVAT.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            //this.btnPrintVAT.Size = new System.Drawing.Size(116, 37);
            //this.btnPrintVAT.TabIndex = 6;
            //this.btnPrintVAT.Click += new System.EventHandler(this.btnPrintVAT_Click);
            // 
            // OrderDetailDialog
            // btnPrintWifiPass
            // 
            this.btnPrintWifiPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintWifiPass.BorderColor = System.Drawing.Color.White;
            this.btnPrintWifiPass.BorderRadius = 3;
            this.btnPrintWifiPass.BorderThick = 1;
            this.btnPrintWifiPass.Caption = "Print Wifi Pass";
            this.btnPrintWifiPass.CenterImageDisable = null;
            this.btnPrintWifiPass.CenterImageNormal = null;
            this.btnPrintWifiPass.CenterImagePress = null;
            this.btnPrintWifiPass.DisableColor = System.Drawing.Color.Empty;
            this.btnPrintWifiPass.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintWifiPass.IsActivated = false;
            this.btnPrintWifiPass.LeftImageDisable = null;
            this.btnPrintWifiPass.LeftImageGap = 0;
            this.btnPrintWifiPass.LeftImageNornal = null;
            this.btnPrintWifiPass.LeftImagePress = null;
            this.btnPrintWifiPass.Location = new System.Drawing.Point(508, 8);
            this.btnPrintWifiPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrintWifiPass.Name = "btnPrintWifiPass";
            this.btnPrintWifiPass.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.btnPrintWifiPass.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnPrintWifiPass.Size = new System.Drawing.Size(116, 37);
            this.btnPrintWifiPass.TabIndex = 6;
            this.btnPrintWifiPass.Click += new EventHandler(btnPrintWifiPass_Click);
            // 
            // ViewOrderDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(817, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.orderDetailControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderDetailDialog";
            this.Name = "ViewOrderDetailDialog";
            this.ShowInTaskbar = false;
            this.Text = "MessageDialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewOrderDetailControl orderDetailControl;
        private System.Windows.Forms.Panel panel1;
        private Common.FlexButton btnHide;
        private Common.FlexButton btnReject;
        private Common.FlexButton btnAccept;
        private Common.FlexButton btnCancel;
        private Common.FlexButton btnPrint;
        private Common.FlexButton btnPrintWifiPass;
        //private Common.FlexButton btnPrintVAT;
    }
}