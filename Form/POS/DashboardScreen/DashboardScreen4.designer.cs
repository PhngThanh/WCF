using POS.Common;
using POS.CustomControl;

namespace POS.DashboardScreen
{
    partial class DashboardScreen4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardScreen4));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.lineGreen = new System.Windows.Forms.Panel();
            this.btnBack2 = new POS.CustomControl.BootstrapButton();
            this.orderContainerOuter = new System.Windows.Forms.Panel();
            this._functionContainerInner = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUpdatePassword = new POS.Common.FlexButton();
            this.btnButtonOpenSafe = new POS.Common.FlexButton();
            this.btnOpenSalescreen = new POS.Common.FlexButton();
            this.btnUpdate = new POS.Common.FlexButton();
            this.btnOpenKitchenScreen = new POS.Common.FlexButton();
            this.btnPaymentMember = new POS.Common.FlexButton();
            this.btnSetting = new POS.Common.FlexButton();
            this.btnPrintWifi = new POS.Common.FlexButton();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack2)).BeginInit();
            this.orderContainerOuter.SuspendLayout();
            this._functionContainerInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.pnlOrder.Controls.Add(this.lineGreen);
            this.pnlOrder.Controls.Add(this.btnBack2);
            this.pnlOrder.Controls.Add(this.orderContainerOuter);
            this.pnlOrder.Location = new System.Drawing.Point(0, 124);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(984, 551);
            this.pnlOrder.TabIndex = 3;
            // 
            // lineGreen
            // 
            this.lineGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.lineGreen.Location = new System.Drawing.Point(0, 52);
            this.lineGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineGreen.Name = "lineGreen";
            this.lineGreen.Size = new System.Drawing.Size(984, 2);
            this.lineGreen.TabIndex = 5;
            // 
            // btnBack2
            // 
            this.btnBack2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack2.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnBack2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack2.BorderRadius = 0;
            this.btnBack2.BorderThick = 0;
            this.btnBack2.ButtonValue = "";
            this.btnBack2.Image = ((System.Drawing.Image)(resources.GetObject("btnBack2.Image")));
            this.btnBack2.ImageColor = System.Drawing.Color.White;
            this.btnBack2.ImageCss = "arrow-left";
            this.btnBack2.ImageFontSize = 24F;
            this.btnBack2.ImageTextPadding = 0;
            this.btnBack2.IsActive = false;
            this.btnBack2.IsAutoScaleWidth = false;
            this.btnBack2.IsVerticalImageText = false;
            this.btnBack2.Location = new System.Drawing.Point(8, 2);
            this.btnBack2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(107, 47);
            this.btnBack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBack2.TabIndex = 15;
            this.btnBack2.TabStop = false;
            this.btnBack2.TextColor = System.Drawing.Color.White;
            this.btnBack2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnBack2.TextValue = "";
            this.btnBack2.ToggleGroup = 0;
            this.btnBack2.Type = POS.CustomControl.ButtonType.Click;
            this.btnBack2.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // orderContainerOuter
            // 
            this.orderContainerOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderContainerOuter.Controls.Add(this._functionContainerInner);
            this.orderContainerOuter.Location = new System.Drawing.Point(0, 54);
            this.orderContainerOuter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderContainerOuter.Name = "orderContainerOuter";
            this.orderContainerOuter.Size = new System.Drawing.Size(984, 437);
            this.orderContainerOuter.TabIndex = 1;
            // 
            // _functionContainerInner
            // 
            this._functionContainerInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._functionContainerInner.AutoSize = true;
            this._functionContainerInner.Controls.Add(this.btnUpdatePassword);
            this._functionContainerInner.Controls.Add(this.btnButtonOpenSafe);
            this._functionContainerInner.Controls.Add(this.btnOpenSalescreen);
            this._functionContainerInner.Controls.Add(this.btnUpdate);
            this._functionContainerInner.Controls.Add(this.btnOpenKitchenScreen);
            this._functionContainerInner.Controls.Add(this.btnPaymentMember);
            this._functionContainerInner.Controls.Add(this.btnSetting);
            this._functionContainerInner.Controls.Add(this.btnPrintWifi);
            this._functionContainerInner.Location = new System.Drawing.Point(4, 4);
            this._functionContainerInner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._functionContainerInner.Name = "_functionContainerInner";
            this._functionContainerInner.Padding = new System.Windows.Forms.Padding(20, 18, 0, 0);
            this._functionContainerInner.Size = new System.Drawing.Size(975, 489);
            this._functionContainerInner.TabIndex = 0;
            // 
            // btnUpdatePassword
            // 
            this.btnUpdatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePassword.BorderColor = System.Drawing.Color.White;
            this.btnUpdatePassword.BorderRadius = 4;
            this.btnUpdatePassword.BorderThick = 1;
            this.btnUpdatePassword.Caption = "Change Password";
            this.btnUpdatePassword.CenterImageDisable = null;
            this.btnUpdatePassword.CenterImageNormal = null;
            this.btnUpdatePassword.CenterImagePress = null;
            this.btnUpdatePassword.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdatePassword.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePassword.IsActivated = false;
            this.btnUpdatePassword.LeftImageDisable = null;
            this.btnUpdatePassword.LeftImageGap = 7;
            this.btnUpdatePassword.LeftImageNornal = null;
            this.btnUpdatePassword.LeftImagePress = null;
            this.btnUpdatePassword.Location = new System.Drawing.Point(29, 27);
            this.btnUpdatePassword.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnUpdatePassword.Name = "btnUpdatePassword";
            this.btnUpdatePassword.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdatePassword.PressColor = System.Drawing.Color.White;
            this.btnUpdatePassword.Size = new System.Drawing.Size(267, 74);
            this.btnUpdatePassword.TabIndex = 6;
            this.btnUpdatePassword.Click += new System.EventHandler(this.btnUpdatePassword_Click);
            // 
            // btnButtonOpenSafe
            // 
            this.btnButtonOpenSafe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnButtonOpenSafe.BorderColor = System.Drawing.Color.White;
            this.btnButtonOpenSafe.BorderRadius = 4;
            this.btnButtonOpenSafe.BorderThick = 1;
            this.btnButtonOpenSafe.Caption = "OpenSafe";
            this.btnButtonOpenSafe.CenterImageDisable = null;
            this.btnButtonOpenSafe.CenterImageNormal = null;
            this.btnButtonOpenSafe.CenterImagePress = null;
            this.btnButtonOpenSafe.DisableColor = System.Drawing.Color.Empty;
            this.btnButtonOpenSafe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnButtonOpenSafe.IsActivated = false;
            this.btnButtonOpenSafe.LeftImageDisable = null;
            this.btnButtonOpenSafe.LeftImageGap = 7;
            this.btnButtonOpenSafe.LeftImageNornal = null;
            this.btnButtonOpenSafe.LeftImagePress = null;
            this.btnButtonOpenSafe.Location = new System.Drawing.Point(314, 27);
            this.btnButtonOpenSafe.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnButtonOpenSafe.Name = "btnButtonOpenSafe";
            this.btnButtonOpenSafe.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnButtonOpenSafe.PressColor = System.Drawing.Color.White;
            this.btnButtonOpenSafe.Size = new System.Drawing.Size(267, 74);
            this.btnButtonOpenSafe.TabIndex = 7;
            this.btnButtonOpenSafe.Click += new System.EventHandler(this.btnButtonOpenSafe_Click);
            // 
            // btnOpenSalescreen
            // 
            this.btnOpenSalescreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSalescreen.BorderColor = System.Drawing.Color.White;
            this.btnOpenSalescreen.BorderRadius = 4;
            this.btnOpenSalescreen.BorderThick = 1;
            this.btnOpenSalescreen.Caption = "OpenSalescreen";
            this.btnOpenSalescreen.CenterImageDisable = null;
            this.btnOpenSalescreen.CenterImageNormal = null;
            this.btnOpenSalescreen.CenterImagePress = null;
            this.btnOpenSalescreen.DisableColor = System.Drawing.Color.Empty;
            this.btnOpenSalescreen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSalescreen.IsActivated = false;
            this.btnOpenSalescreen.LeftImageDisable = null;
            this.btnOpenSalescreen.LeftImageGap = 7;
            this.btnOpenSalescreen.LeftImageNornal = null;
            this.btnOpenSalescreen.LeftImagePress = null;
            this.btnOpenSalescreen.Location = new System.Drawing.Point(599, 27);
            this.btnOpenSalescreen.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnOpenSalescreen.Name = "btnOpenSalescreen";
            this.btnOpenSalescreen.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnOpenSalescreen.PressColor = System.Drawing.Color.White;
            this.btnOpenSalescreen.Size = new System.Drawing.Size(267, 74);
            this.btnOpenSalescreen.TabIndex = 7;
            this.btnOpenSalescreen.Click += new System.EventHandler(this.btnOpenSalescreen_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BorderColor = System.Drawing.Color.White;
            this.btnUpdate.BorderRadius = 4;
            this.btnUpdate.BorderThick = 1;
            this.btnUpdate.Caption = "Cập nhật";
            this.btnUpdate.CenterImageDisable = null;
            this.btnUpdate.CenterImageNormal = null;
            this.btnUpdate.CenterImagePress = null;
            this.btnUpdate.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.IsActivated = false;
            this.btnUpdate.LeftImageDisable = null;
            this.btnUpdate.LeftImageGap = 7;
            this.btnUpdate.LeftImageNornal = null;
            this.btnUpdate.LeftImagePress = null;
            this.btnUpdate.Location = new System.Drawing.Point(29, 119);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdate.PressColor = System.Drawing.Color.White;
            this.btnUpdate.Size = new System.Drawing.Size(267, 74);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Load += new System.EventHandler(this.btnUpdate_Load);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnOpenKitchenScreen
            // 
            this.btnOpenKitchenScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenKitchenScreen.BorderColor = System.Drawing.Color.White;
            this.btnOpenKitchenScreen.BorderRadius = 4;
            this.btnOpenKitchenScreen.BorderThick = 1;
            this.btnOpenKitchenScreen.Caption = "Nhà Bếp";
            this.btnOpenKitchenScreen.CenterImageDisable = null;
            this.btnOpenKitchenScreen.CenterImageNormal = null;
            this.btnOpenKitchenScreen.CenterImagePress = null;
            this.btnOpenKitchenScreen.DisableColor = System.Drawing.Color.Empty;
            this.btnOpenKitchenScreen.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenKitchenScreen.IsActivated = false;
            this.btnOpenKitchenScreen.LeftImageDisable = null;
            this.btnOpenKitchenScreen.LeftImageGap = 7;
            this.btnOpenKitchenScreen.LeftImageNornal = null;
            this.btnOpenKitchenScreen.LeftImagePress = null;
            this.btnOpenKitchenScreen.Location = new System.Drawing.Point(314, 119);
            this.btnOpenKitchenScreen.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnOpenKitchenScreen.Name = "btnOpenKitchenScreen";
            this.btnOpenKitchenScreen.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnOpenKitchenScreen.PressColor = System.Drawing.Color.White;
            this.btnOpenKitchenScreen.Size = new System.Drawing.Size(267, 74);
            this.btnOpenKitchenScreen.TabIndex = 18;
            this.btnOpenKitchenScreen.Click += new System.EventHandler(this.btnOpenKitchenScreen_Click);
            // 
            // btnPaymentMember
            // 
            this.btnPaymentMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaymentMember.BorderColor = System.Drawing.Color.White;
            this.btnPaymentMember.BorderRadius = 4;
            this.btnPaymentMember.BorderThick = 1;
            this.btnPaymentMember.Caption = "Thẻ thành viên";
            this.btnPaymentMember.CenterImageDisable = null;
            this.btnPaymentMember.CenterImageNormal = null;
            this.btnPaymentMember.CenterImagePress = null;
            this.btnPaymentMember.DisableColor = System.Drawing.Color.Empty;
            this.btnPaymentMember.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentMember.IsActivated = false;
            this.btnPaymentMember.LeftImageDisable = null;
            this.btnPaymentMember.LeftImageGap = 7;
            this.btnPaymentMember.LeftImageNornal = null;
            this.btnPaymentMember.LeftImagePress = null;
            this.btnPaymentMember.Location = new System.Drawing.Point(599, 119);
            this.btnPaymentMember.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnPaymentMember.Name = "btnPaymentMember";
            this.btnPaymentMember.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnPaymentMember.PressColor = System.Drawing.Color.White;
            this.btnPaymentMember.Size = new System.Drawing.Size(267, 74);
            this.btnPaymentMember.TabIndex = 20;
            this.btnPaymentMember.Click += new System.EventHandler(this.btnPaymentMember_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetting.BorderColor = System.Drawing.Color.White;
            this.btnSetting.BorderRadius = 4;
            this.btnSetting.BorderThick = 1;
            this.btnSetting.Caption = "Cài Đặt";
            this.btnSetting.CenterImageDisable = null;
            this.btnSetting.CenterImageNormal = null;
            this.btnSetting.CenterImagePress = null;
            this.btnSetting.DisableColor = System.Drawing.Color.Empty;
            this.btnSetting.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.IsActivated = false;
            this.btnSetting.LeftImageDisable = null;
            this.btnSetting.LeftImageGap = 7;
            this.btnSetting.LeftImageNornal = null;
            this.btnSetting.LeftImagePress = null;
            this.btnSetting.Location = new System.Drawing.Point(29, 211);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnSetting.PressColor = System.Drawing.Color.White;
            this.btnSetting.Size = new System.Drawing.Size(267, 74);
            this.btnSetting.TabIndex = 19;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnPrintWifi
            // 
            this.btnPrintWifi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintWifi.BorderColor = System.Drawing.Color.White;
            this.btnPrintWifi.BorderRadius = 4;
            this.btnPrintWifi.BorderThick = 1;
            this.btnPrintWifi.Caption = "In Pass Wifi";
            this.btnPrintWifi.CenterImageDisable = null;
            this.btnPrintWifi.CenterImageNormal = null;
            this.btnPrintWifi.CenterImagePress = null;
            this.btnPrintWifi.DisableColor = System.Drawing.Color.Empty;
            this.btnPrintWifi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintWifi.IsActivated = false;
            this.btnPrintWifi.LeftImageDisable = null;
            this.btnPrintWifi.LeftImageGap = 7;
            this.btnPrintWifi.LeftImageNornal = null;
            this.btnPrintWifi.LeftImagePress = null;
            this.btnPrintWifi.Location = new System.Drawing.Point(314, 211);
            this.btnPrintWifi.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.btnPrintWifi.Name = "btnPrintWifi";
            this.btnPrintWifi.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnPrintWifi.PressColor = System.Drawing.Color.White;
            this.btnPrintWifi.Size = new System.Drawing.Size(267, 74);
            this.btnPrintWifi.TabIndex = 21;
            this.btnPrintWifi.Click += new System.EventHandler(this.btnPrintWifi_Click);
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "";
            this.ptbLogo.Location = new System.Drawing.Point(0, 28);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 4;
            this.ptbLogo.TabStop = false;
            // 
            // DashboardScreen4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.pnlOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DashboardScreen4";
            this.Size = new System.Drawing.Size(984, 635);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack2)).EndInit();
            this.orderContainerOuter.ResumeLayout(false);
            this.orderContainerOuter.PerformLayout();
            this._functionContainerInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel lineGreen;
        private System.Windows.Forms.Panel orderContainerOuter;
        private System.Windows.Forms.FlowLayoutPanel _functionContainerInner;
        private FlexButton btnUpdatePassword;
        private FlexButton btnButtonOpenSafe;
        private FlexButton btnOpenSalescreen;
        private FlexButton btnUpdate;
        private BootstrapButton btnBack2;
        private System.Windows.Forms.PictureBox ptbLogo;
        private FlexButton btnOpenKitchenScreen;
        private FlexButton btnSetting;
        private FlexButton btnPaymentMember;
        private FlexButton btnPrintWifi;
    }
}
