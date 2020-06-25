using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new POS.CustomControl.BootstrapPanel();
            this.btnAtStoreMode = new POS.CustomControl.BootstrapButton();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.btnHideApplication = new POS.CustomControl.BootstrapButton();
            this.btnDeliveryMode = new POS.CustomControl.BootstrapButton();
            this.btnTakeAwayMode = new POS.CustomControl.BootstrapButton();
            this.pnlBottom = new POS.CustomControl.BootstrapPanel();
            this.lblSkyPOSVersion = new System.Windows.Forms.Label();
            this.pnlDashboard = new POS.CustomControl.BootstrapPanel();
            this.btnViewOrder = new POS.CustomControl.BootstrapButton();
            this.btnOnlineOrder = new POS.CustomControl.BootstrapButton();
            this.btnFloor5 = new POS.CustomControl.BootstrapButton();
            this.btnFloor4 = new POS.CustomControl.BootstrapButton();
            this.btnFloor2 = new POS.CustomControl.BootstrapButton();
            this.btnFloor1 = new POS.CustomControl.BootstrapButton();
            this.btnFloor0 = new POS.CustomControl.BootstrapButton();
            this.btnConfig = new POS.CustomControl.BootstrapButton();
            this.btnFloor3 = new POS.CustomControl.BootstrapButton();
            this.btnLogout = new POS.CustomControl.BootstrapButton();
            this.clockControl1 = new POS.Common.ClockControl();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnlineOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Gray;
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1333, 554);
            this.pnlMain.TabIndex = 7;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlTop.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlTop.Controls.Add(this.btnAtStoreMode);
            this.pnlTop.Controls.Add(this.ptbLogo);
            this.pnlTop.Controls.Add(this.btnHideApplication);
            this.pnlTop.Controls.Add(this.btnDeliveryMode);
            this.pnlTop.Controls.Add(this.btnTakeAwayMode);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1333, 98);
            this.pnlTop.TabIndex = 2;
            // 
            // btnAtStoreMode
            // 
            this.btnAtStoreMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAtStoreMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAtStoreMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtStoreMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAtStoreMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnAtStoreMode.BorderRadius = 3;
            this.btnAtStoreMode.BorderThick = 3;
            this.btnAtStoreMode.ButtonValue = "";
            this.btnAtStoreMode.Image = ((System.Drawing.Image)(resources.GetObject("btnAtStoreMode.Image")));
            this.btnAtStoreMode.ImageColor = System.Drawing.Color.White;
            this.btnAtStoreMode.ImageCss = "building-o";
            this.btnAtStoreMode.ImageFontSize = 40F;
            this.btnAtStoreMode.ImageTextPadding = 0;
            this.btnAtStoreMode.IsActive = false;
            this.btnAtStoreMode.IsAutoScaleWidth = false;
            this.btnAtStoreMode.IsVerticalImageText = true;
            this.btnAtStoreMode.Location = new System.Drawing.Point(645, 0);
            this.btnAtStoreMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnAtStoreMode.Name = "btnAtStoreMode";
            this.btnAtStoreMode.Size = new System.Drawing.Size(160, 98);
            this.btnAtStoreMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAtStoreMode.TabIndex = 1;
            this.btnAtStoreMode.TabStop = false;
            this.btnAtStoreMode.TextColor = System.Drawing.Color.White;
            this.btnAtStoreMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnAtStoreMode.TextValue = "Tại quán";
            this.btnAtStoreMode.ToggleGroup = 1;
            this.btnAtStoreMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAtStoreMode.Click += new System.EventHandler(this.btnAtStoreMode_Click);
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "";
            this.ptbLogo.Location = new System.Drawing.Point(0, 20);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // btnHideApplication
            // 
            this.btnHideApplication.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnHideApplication.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnHideApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnHideApplication.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnHideApplication.BorderRadius = 3;
            this.btnHideApplication.BorderThick = 3;
            this.btnHideApplication.ButtonValue = "";
            this.btnHideApplication.Image = ((System.Drawing.Image)(resources.GetObject("btnHideApplication.Image")));
            this.btnHideApplication.ImageColor = System.Drawing.Color.White;
            this.btnHideApplication.ImageCss = "pause-circle-o";
            this.btnHideApplication.ImageFontSize = 45F;
            this.btnHideApplication.ImageTextPadding = 0;
            this.btnHideApplication.IsActive = false;
            this.btnHideApplication.IsAutoScaleWidth = false;
            this.btnHideApplication.IsVerticalImageText = true;
            this.btnHideApplication.Location = new System.Drawing.Point(1145, 0);
            this.btnHideApplication.Margin = new System.Windows.Forms.Padding(13, 4, 4, 4);
            this.btnHideApplication.Name = "btnHideApplication";
            this.btnHideApplication.Size = new System.Drawing.Size(188, 98);
            this.btnHideApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHideApplication.TabIndex = 11;
            this.btnHideApplication.TabStop = false;
            this.btnHideApplication.TextColor = System.Drawing.Color.White;
            this.btnHideApplication.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideApplication.TextValue = "Ẩn màn hình";
            this.btnHideApplication.ToggleGroup = 0;
            this.btnHideApplication.Type = POS.CustomControl.ButtonType.Click;
            this.btnHideApplication.Click += new System.EventHandler(this.btnHideApplication_Click);
            // 
            // btnDeliveryMode
            // 
            this.btnDeliveryMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnDeliveryMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnDeliveryMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliveryMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnDeliveryMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnDeliveryMode.BorderRadius = 3;
            this.btnDeliveryMode.BorderThick = 3;
            this.btnDeliveryMode.ButtonValue = "";
            this.btnDeliveryMode.Image = ((System.Drawing.Image)(resources.GetObject("btnDeliveryMode.Image")));
            this.btnDeliveryMode.ImageColor = System.Drawing.Color.White;
            this.btnDeliveryMode.ImageCss = "truck";
            this.btnDeliveryMode.ImageFontSize = 40F;
            this.btnDeliveryMode.ImageTextPadding = 0;
            this.btnDeliveryMode.IsActive = false;
            this.btnDeliveryMode.IsAutoScaleWidth = false;
            this.btnDeliveryMode.IsVerticalImageText = true;
            this.btnDeliveryMode.Location = new System.Drawing.Point(971, 0);
            this.btnDeliveryMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeliveryMode.Name = "btnDeliveryMode";
            this.btnDeliveryMode.Size = new System.Drawing.Size(160, 98);
            this.btnDeliveryMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDeliveryMode.TabIndex = 1;
            this.btnDeliveryMode.TabStop = false;
            this.btnDeliveryMode.TextColor = System.Drawing.Color.White;
            this.btnDeliveryMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnDeliveryMode.TextValue = "Giao hàng";
            this.btnDeliveryMode.ToggleGroup = 1;
            this.btnDeliveryMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnDeliveryMode.Click += new System.EventHandler(this.btnDeliveryMode_Click);
            // 
            // btnTakeAwayMode
            // 
            this.btnTakeAwayMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnTakeAwayMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnTakeAwayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakeAwayMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnTakeAwayMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnTakeAwayMode.BorderRadius = 3;
            this.btnTakeAwayMode.BorderThick = 3;
            this.btnTakeAwayMode.ButtonValue = "";
            this.btnTakeAwayMode.Image = ((System.Drawing.Image)(resources.GetObject("btnTakeAwayMode.Image")));
            this.btnTakeAwayMode.ImageColor = System.Drawing.Color.White;
            this.btnTakeAwayMode.ImageCss = "hand-o-right";
            this.btnTakeAwayMode.ImageFontSize = 40F;
            this.btnTakeAwayMode.ImageTextPadding = 0;
            this.btnTakeAwayMode.IsActive = false;
            this.btnTakeAwayMode.IsAutoScaleWidth = false;
            this.btnTakeAwayMode.IsVerticalImageText = true;
            this.btnTakeAwayMode.Location = new System.Drawing.Point(808, 0);
            this.btnTakeAwayMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnTakeAwayMode.Name = "btnTakeAwayMode";
            this.btnTakeAwayMode.Size = new System.Drawing.Size(160, 98);
            this.btnTakeAwayMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnTakeAwayMode.TabIndex = 1;
            this.btnTakeAwayMode.TabStop = false;
            this.btnTakeAwayMode.TextColor = System.Drawing.Color.White;
            this.btnTakeAwayMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnTakeAwayMode.TextValue = "Mang về";
            this.btnTakeAwayMode.ToggleGroup = 1;
            this.btnTakeAwayMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnTakeAwayMode.Click += new System.EventHandler(this.btnTakeAwayMode_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlBottom.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlBottom.Controls.Add(this.lblSkyPOSVersion);
            this.pnlBottom.Controls.Add(this.pnlDashboard);
            this.pnlBottom.Controls.Add(this.btnLogout);
            this.pnlBottom.Controls.Add(this.clockControl1);
            this.pnlBottom.Location = new System.Drawing.Point(0, 431);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1333, 123);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblSkyPOSVersion
            // 
            this.lblSkyPOSVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSkyPOSVersion.AutoSize = true;
            this.lblSkyPOSVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblSkyPOSVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkyPOSVersion.ForeColor = System.Drawing.Color.Silver;
            this.lblSkyPOSVersion.Location = new System.Drawing.Point(0, 107);
            this.lblSkyPOSVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSkyPOSVersion.Name = "lblSkyPOSVersion";
            this.lblSkyPOSVersion.Size = new System.Drawing.Size(98, 17);
            this.lblSkyPOSVersion.TabIndex = 6;
            this.lblSkyPOSVersion.Text = "version 1.5.23";
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlDashboard.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlDashboard.Controls.Add(this.btnViewOrder);
            this.pnlDashboard.Controls.Add(this.btnOnlineOrder);
            this.pnlDashboard.Controls.Add(this.btnFloor5);
            this.pnlDashboard.Controls.Add(this.btnFloor4);
            this.pnlDashboard.Controls.Add(this.btnFloor2);
            this.pnlDashboard.Controls.Add(this.btnFloor1);
            this.pnlDashboard.Controls.Add(this.btnFloor0);
            this.pnlDashboard.Controls.Add(this.btnConfig);
            this.pnlDashboard.Controls.Add(this.btnFloor3);
            this.pnlDashboard.Location = new System.Drawing.Point(279, -30);
            this.pnlDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1055, 153);
            this.pnlDashboard.TabIndex = 4;
            // 
            // btnViewOrder
            // 
            this.btnViewOrder.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnViewOrder.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnViewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnViewOrder.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnViewOrder.BorderRadius = 3;
            this.btnViewOrder.BorderThick = 3;
            this.btnViewOrder.ButtonValue = "";
            this.btnViewOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnViewOrder.Image")));
            this.btnViewOrder.ImageColor = System.Drawing.Color.White;
            this.btnViewOrder.ImageCss = "calendar-check-o";
            this.btnViewOrder.ImageFontSize = 45F;
            this.btnViewOrder.ImageTextPadding = 0;
            this.btnViewOrder.IsActive = false;
            this.btnViewOrder.IsAutoScaleWidth = false;
            this.btnViewOrder.IsVerticalImageText = true;
            this.btnViewOrder.Location = new System.Drawing.Point(649, 30);
            this.btnViewOrder.Margin = new System.Windows.Forms.Padding(1);
            this.btnViewOrder.Name = "btnViewOrder";
            this.btnViewOrder.Size = new System.Drawing.Size(200, 123);
            this.btnViewOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnViewOrder.TabIndex = 18;
            this.btnViewOrder.TabStop = false;
            this.btnViewOrder.TextColor = System.Drawing.Color.White;
            this.btnViewOrder.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewOrder.TextValue = "Xem hóa đơn";
            this.btnViewOrder.ToggleGroup = 0;
            this.btnViewOrder.Type = POS.CustomControl.ButtonType.Click;
            this.btnViewOrder.Click += new System.EventHandler(this.btnViewOrder_Click);
            // 
            // btnOnlineOrder
            // 
            this.btnOnlineOrder.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnOnlineOrder.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnOnlineOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnlineOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnOnlineOrder.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnOnlineOrder.BorderRadius = 3;
            this.btnOnlineOrder.BorderThick = 3;
            this.btnOnlineOrder.ButtonValue = "";
            this.btnOnlineOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOnlineOrder.Image")));
            this.btnOnlineOrder.ImageColor = System.Drawing.Color.White;
            this.btnOnlineOrder.ImageCss = "shopping-cart";
            this.btnOnlineOrder.ImageFontSize = 45F;
            this.btnOnlineOrder.ImageTextPadding = 0;
            this.btnOnlineOrder.IsActive = false;
            this.btnOnlineOrder.IsAutoScaleWidth = false;
            this.btnOnlineOrder.IsVerticalImageText = true;
            this.btnOnlineOrder.Location = new System.Drawing.Point(447, 30);
            this.btnOnlineOrder.Margin = new System.Windows.Forms.Padding(1);
            this.btnOnlineOrder.Name = "btnOnlineOrder";
            this.btnOnlineOrder.Size = new System.Drawing.Size(200, 123);
            this.btnOnlineOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnOnlineOrder.TabIndex = 9;
            this.btnOnlineOrder.TabStop = false;
            this.btnOnlineOrder.TextColor = System.Drawing.Color.White;
            this.btnOnlineOrder.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnOnlineOrder.TextValue = "Tổng đài";
            this.btnOnlineOrder.ToggleGroup = 0;
            this.btnOnlineOrder.Type = POS.CustomControl.ButtonType.Click;
            this.btnOnlineOrder.Click += new System.EventHandler(this.btnOnlineOrder_Click);
            // 
            // btnFloor5
            // 
            this.btnFloor5.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor5.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor5.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor5.BorderRadius = 3;
            this.btnFloor5.BorderThick = 3;
            this.btnFloor5.ButtonValue = "5";
            this.btnFloor5.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor5.Image")));
            this.btnFloor5.ImageColor = System.Drawing.Color.White;
            this.btnFloor5.ImageCss = "bank";
            this.btnFloor5.ImageFontSize = 20F;
            this.btnFloor5.ImageTextPadding = 0;
            this.btnFloor5.IsActive = false;
            this.btnFloor5.IsAutoScaleWidth = false;
            this.btnFloor5.IsVerticalImageText = true;
            this.btnFloor5.Location = new System.Drawing.Point(277, 94);
            this.btnFloor5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor5.Name = "btnFloor5";
            this.btnFloor5.Size = new System.Drawing.Size(133, 59);
            this.btnFloor5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor5.TabIndex = 17;
            this.btnFloor5.TabStop = false;
            this.btnFloor5.Tag = "";
            this.btnFloor5.TextColor = System.Drawing.Color.White;
            this.btnFloor5.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor5.TextValue = "Floor 5";
            this.btnFloor5.ToggleGroup = 3;
            this.btnFloor5.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor5.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnFloor4
            // 
            this.btnFloor4.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor4.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor4.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor4.BorderRadius = 3;
            this.btnFloor4.BorderThick = 3;
            this.btnFloor4.ButtonValue = "4";
            this.btnFloor4.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor4.Image")));
            this.btnFloor4.ImageColor = System.Drawing.Color.White;
            this.btnFloor4.ImageCss = "bank";
            this.btnFloor4.ImageFontSize = 20F;
            this.btnFloor4.ImageTextPadding = 0;
            this.btnFloor4.IsActive = false;
            this.btnFloor4.IsAutoScaleWidth = false;
            this.btnFloor4.IsVerticalImageText = true;
            this.btnFloor4.Location = new System.Drawing.Point(277, 30);
            this.btnFloor4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor4.Name = "btnFloor4";
            this.btnFloor4.Size = new System.Drawing.Size(133, 59);
            this.btnFloor4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor4.TabIndex = 16;
            this.btnFloor4.TabStop = false;
            this.btnFloor4.TextColor = System.Drawing.Color.White;
            this.btnFloor4.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor4.TextValue = "Floor 4";
            this.btnFloor4.ToggleGroup = 3;
            this.btnFloor4.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor4.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnFloor2
            // 
            this.btnFloor2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor2.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor2.BorderRadius = 3;
            this.btnFloor2.BorderThick = 3;
            this.btnFloor2.ButtonValue = "2";
            this.btnFloor2.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor2.Image")));
            this.btnFloor2.ImageColor = System.Drawing.Color.White;
            this.btnFloor2.ImageCss = "bank";
            this.btnFloor2.ImageFontSize = 20F;
            this.btnFloor2.ImageTextPadding = 0;
            this.btnFloor2.IsActive = false;
            this.btnFloor2.IsAutoScaleWidth = false;
            this.btnFloor2.IsVerticalImageText = true;
            this.btnFloor2.Location = new System.Drawing.Point(139, 30);
            this.btnFloor2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor2.Name = "btnFloor2";
            this.btnFloor2.Size = new System.Drawing.Size(133, 59);
            this.btnFloor2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor2.TabIndex = 14;
            this.btnFloor2.TabStop = false;
            this.btnFloor2.TextColor = System.Drawing.Color.White;
            this.btnFloor2.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor2.TextValue = "Floor 2";
            this.btnFloor2.ToggleGroup = 3;
            this.btnFloor2.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor2.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnFloor1
            // 
            this.btnFloor1.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor1.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor1.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor1.BorderRadius = 3;
            this.btnFloor1.BorderThick = 3;
            this.btnFloor1.ButtonValue = "1";
            this.btnFloor1.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor1.Image")));
            this.btnFloor1.ImageColor = System.Drawing.Color.White;
            this.btnFloor1.ImageCss = "bank";
            this.btnFloor1.ImageFontSize = 20F;
            this.btnFloor1.ImageTextPadding = 0;
            this.btnFloor1.IsActive = false;
            this.btnFloor1.IsAutoScaleWidth = false;
            this.btnFloor1.IsVerticalImageText = true;
            this.btnFloor1.Location = new System.Drawing.Point(0, 94);
            this.btnFloor1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor1.Name = "btnFloor1";
            this.btnFloor1.Size = new System.Drawing.Size(133, 59);
            this.btnFloor1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor1.TabIndex = 13;
            this.btnFloor1.TabStop = false;
            this.btnFloor1.TextColor = System.Drawing.Color.White;
            this.btnFloor1.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor1.TextValue = "Floor 1";
            this.btnFloor1.ToggleGroup = 3;
            this.btnFloor1.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor1.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnFloor0
            // 
            this.btnFloor0.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor0.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor0.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor0.BorderRadius = 3;
            this.btnFloor0.BorderThick = 3;
            this.btnFloor0.ButtonValue = "0";
            this.btnFloor0.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor0.Image")));
            this.btnFloor0.ImageColor = System.Drawing.Color.White;
            this.btnFloor0.ImageCss = "bank";
            this.btnFloor0.ImageFontSize = 20F;
            this.btnFloor0.ImageTextPadding = 0;
            this.btnFloor0.IsActive = false;
            this.btnFloor0.IsAutoScaleWidth = false;
            this.btnFloor0.IsVerticalImageText = true;
            this.btnFloor0.Location = new System.Drawing.Point(0, 30);
            this.btnFloor0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor0.Name = "btnFloor0";
            this.btnFloor0.Size = new System.Drawing.Size(133, 59);
            this.btnFloor0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor0.TabIndex = 12;
            this.btnFloor0.TabStop = false;
            this.btnFloor0.TextColor = System.Drawing.Color.White;
            this.btnFloor0.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor0.TextValue = "Ground";
            this.btnFloor0.ToggleGroup = 3;
            this.btnFloor0.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor0.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnConfig.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnConfig.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnConfig.BorderRadius = 3;
            this.btnConfig.BorderThick = 3;
            this.btnConfig.ButtonValue = "";
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageColor = System.Drawing.Color.White;
            this.btnConfig.ImageCss = "dashboard";
            this.btnConfig.ImageFontSize = 45F;
            this.btnConfig.ImageTextPadding = 0;
            this.btnConfig.IsActive = false;
            this.btnConfig.IsAutoScaleWidth = false;
            this.btnConfig.IsVerticalImageText = true;
            this.btnConfig.Location = new System.Drawing.Point(852, 30);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(1);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(200, 123);
            this.btnConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnConfig.TabIndex = 12;
            this.btnConfig.TabStop = false;
            this.btnConfig.TextColor = System.Drawing.Color.White;
            this.btnConfig.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfig.TextValue = "Bảng điều khiển";
            this.btnConfig.ToggleGroup = 0;
            this.btnConfig.Type = POS.CustomControl.ButtonType.Click;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnFloor3
            // 
            this.btnFloor3.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFloor3.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFloor3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFloor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnFloor3.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnFloor3.BorderRadius = 3;
            this.btnFloor3.BorderThick = 3;
            this.btnFloor3.ButtonValue = "3";
            this.btnFloor3.Image = ((System.Drawing.Image)(resources.GetObject("btnFloor3.Image")));
            this.btnFloor3.ImageColor = System.Drawing.Color.White;
            this.btnFloor3.ImageCss = "bank";
            this.btnFloor3.ImageFontSize = 20F;
            this.btnFloor3.ImageTextPadding = 0;
            this.btnFloor3.IsActive = false;
            this.btnFloor3.IsAutoScaleWidth = false;
            this.btnFloor3.IsVerticalImageText = true;
            this.btnFloor3.Location = new System.Drawing.Point(139, 94);
            this.btnFloor3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFloor3.Name = "btnFloor3";
            this.btnFloor3.Size = new System.Drawing.Size(133, 59);
            this.btnFloor3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFloor3.TabIndex = 15;
            this.btnFloor3.TabStop = false;
            this.btnFloor3.TextColor = System.Drawing.Color.White;
            this.btnFloor3.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnFloor3.TextValue = "Floor 3";
            this.btnFloor3.ToggleGroup = 3;
            this.btnFloor3.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFloor3.Click += new System.EventHandler(this.btnFloor_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnLogout.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnLogout.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnLogout.BorderRadius = 0;
            this.btnLogout.BorderThick = 0;
            this.btnLogout.ButtonValue = "";
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageColor = System.Drawing.Color.OrangeRed;
            this.btnLogout.ImageCss = "power-off";
            this.btnLogout.ImageFontSize = 25F;
            this.btnLogout.ImageTextPadding = 0;
            this.btnLogout.IsActive = false;
            this.btnLogout.IsAutoScaleWidth = false;
            this.btnLogout.IsVerticalImageText = true;
            this.btnLogout.Location = new System.Drawing.Point(0, -7);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(267, 66);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnLogout.TabIndex = 4;
            this.btnLogout.TabStop = false;
            this.btnLogout.TextColor = System.Drawing.Color.White;
            this.btnLogout.TextFont = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.TextValue = "Lâm Hữu Khánh Phương";
            this.btnLogout.ToggleGroup = 0;
            this.btnLogout.Type = POS.CustomControl.ButtonType.Click;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // clockControl1
            // 
            this.clockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clockControl1.BackColor = System.Drawing.Color.Transparent;
            this.clockControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.clockControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.clockControl1.Location = new System.Drawing.Point(0, 49);
            this.clockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.Size = new System.Drawing.Size(267, 55);
            this.clockControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1333, 554);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SKYPOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormClosed);
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHideApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOnlineOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFloor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlMain;
        private BootstrapPanel pnlTop;
        private PictureBox ptbLogo;
        private BootstrapPanel pnlBottom;
        private Common.ClockControl clockControl1;
        private BootstrapButton btnLogout;
        private BootstrapPanel pnlDashboard;
        private BootstrapButton btnHideApplication;
        private BootstrapButton btnConfig;
        private BootstrapButton btnOnlineOrder;
        private BootstrapButton btnAtStoreMode;
        private BootstrapButton btnTakeAwayMode;
        private BootstrapButton btnDeliveryMode;
        private BootstrapButton btnFloor5;
        private BootstrapButton btnFloor4;
        private BootstrapButton btnFloor3;
        private BootstrapButton btnFloor2;
        private BootstrapButton btnFloor1;
        private BootstrapButton btnFloor0;
        private BootstrapButton btnViewOrder;
        private Label lblSkyPOSVersion;
    }
}

