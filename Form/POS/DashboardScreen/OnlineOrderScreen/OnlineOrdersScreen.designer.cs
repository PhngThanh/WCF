using POS.CustomControl;
using POS.Common;

namespace POS.DashboardScreen.OnlineOrderScreen
{
    partial class OnlineOrdersScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineOrdersScreen));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.pnlBottom = new POS.CustomControl.BootstrapPanel();
            this.btnAllDeliveryStatus = new POS.CustomControl.BootstrapButton();
            this.btnAssignedDeliveryStatus = new POS.CustomControl.BootstrapButton();
            this.btnAcceptedDeliveryStatus = new POS.CustomControl.BootstrapButton();
            this.btnRejectedDeliveryStatus = new POS.CustomControl.BootstrapButton();
            this.btnBack = new POS.CustomControl.BootstrapButton();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPageNext = new System.Windows.Forms.PictureBox();
            this.btnPageBack = new System.Windows.Forms.PictureBox();
            this.btnDate = new POS.Common.FlexButton();
            this.lineGreen = new System.Windows.Forms.Panel();
            this.orderContainerOuter = new System.Windows.Forms.Panel();
            this.orderContainerInner = new System.Windows.Forms.TableLayoutPanel();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.pnlOrder.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAllDeliveryStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssignedDeliveryStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAcceptedDeliveryStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejectedDeliveryStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.pnlPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).BeginInit();
            this.orderContainerOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlOrder.Controls.Add(this.pnlBottom);
            this.pnlOrder.Controls.Add(this.btnBack);
            this.pnlOrder.Controls.Add(this.pnlPaging);
            this.pnlOrder.Controls.Add(this.btnDate);
            this.pnlOrder.Controls.Add(this.lineGreen);
            this.pnlOrder.Controls.Add(this.orderContainerOuter);
            this.pnlOrder.Location = new System.Drawing.Point(0, 98);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1333, 537);
            this.pnlOrder.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlBottom.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlBottom.Controls.Add(this.btnAllDeliveryStatus);
            this.pnlBottom.Controls.Add(this.btnAssignedDeliveryStatus);
            this.pnlBottom.Controls.Add(this.btnAcceptedDeliveryStatus);
            this.pnlBottom.Controls.Add(this.btnRejectedDeliveryStatus);
            this.pnlBottom.Location = new System.Drawing.Point(1, 414);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1332, 123);
            this.pnlBottom.TabIndex = 17;
            // 
            // btnAllDeliveryStatus
            // 
            this.btnAllDeliveryStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAllDeliveryStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnAllDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllDeliveryStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnAllDeliveryStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnAllDeliveryStatus.BorderRadius = 3;
            this.btnAllDeliveryStatus.BorderThick = 3;
            this.btnAllDeliveryStatus.ButtonValue = "";
            this.btnAllDeliveryStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnAllDeliveryStatus.Image")));
            this.btnAllDeliveryStatus.ImageColor = System.Drawing.Color.White;
            this.btnAllDeliveryStatus.ImageCss = "cubes";
            this.btnAllDeliveryStatus.ImageFontSize = 40F;
            this.btnAllDeliveryStatus.ImageTextPadding = 0;
            this.btnAllDeliveryStatus.IsActive = false;
            this.btnAllDeliveryStatus.IsAutoScaleWidth = false;
            this.btnAllDeliveryStatus.IsVerticalImageText = true;
            this.btnAllDeliveryStatus.Location = new System.Drawing.Point(737, 0);
            this.btnAllDeliveryStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnAllDeliveryStatus.Name = "btnAllDeliveryStatus";
            this.btnAllDeliveryStatus.Size = new System.Drawing.Size(147, 123);
            this.btnAllDeliveryStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAllDeliveryStatus.TabIndex = 6;
            this.btnAllDeliveryStatus.TabStop = false;
            this.btnAllDeliveryStatus.TextColor = System.Drawing.Color.White;
            this.btnAllDeliveryStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAllDeliveryStatus.TextValue = "Tất cả";
            this.btnAllDeliveryStatus.ToggleGroup = 3;
            this.btnAllDeliveryStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAllDeliveryStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAssignedDeliveryStatus
            // 
            this.btnAssignedDeliveryStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAssignedDeliveryStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnAssignedDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignedDeliveryStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAssignedDeliveryStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnAssignedDeliveryStatus.BorderRadius = 3;
            this.btnAssignedDeliveryStatus.BorderThick = 3;
            this.btnAssignedDeliveryStatus.ButtonValue = "";
            this.btnAssignedDeliveryStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignedDeliveryStatus.Image")));
            this.btnAssignedDeliveryStatus.ImageColor = System.Drawing.Color.White;
            this.btnAssignedDeliveryStatus.ImageCss = "plus-square-o";
            this.btnAssignedDeliveryStatus.ImageFontSize = 40F;
            this.btnAssignedDeliveryStatus.ImageTextPadding = 0;
            this.btnAssignedDeliveryStatus.IsActive = false;
            this.btnAssignedDeliveryStatus.IsAutoScaleWidth = false;
            this.btnAssignedDeliveryStatus.IsVerticalImageText = true;
            this.btnAssignedDeliveryStatus.Location = new System.Drawing.Point(887, 0);
            this.btnAssignedDeliveryStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnAssignedDeliveryStatus.Name = "btnAssignedDeliveryStatus";
            this.btnAssignedDeliveryStatus.Size = new System.Drawing.Size(147, 123);
            this.btnAssignedDeliveryStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAssignedDeliveryStatus.TabIndex = 5;
            this.btnAssignedDeliveryStatus.TabStop = false;
            this.btnAssignedDeliveryStatus.TextColor = System.Drawing.Color.White;
            this.btnAssignedDeliveryStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAssignedDeliveryStatus.TextValue = "Mới";
            this.btnAssignedDeliveryStatus.ToggleGroup = 3;
            this.btnAssignedDeliveryStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAssignedDeliveryStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAcceptedDeliveryStatus
            // 
            this.btnAcceptedDeliveryStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAcceptedDeliveryStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnAcceptedDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptedDeliveryStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnAcceptedDeliveryStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnAcceptedDeliveryStatus.BorderRadius = 3;
            this.btnAcceptedDeliveryStatus.BorderThick = 3;
            this.btnAcceptedDeliveryStatus.ButtonValue = "";
            this.btnAcceptedDeliveryStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnAcceptedDeliveryStatus.Image")));
            this.btnAcceptedDeliveryStatus.ImageColor = System.Drawing.Color.White;
            this.btnAcceptedDeliveryStatus.ImageCss = "check-square-o";
            this.btnAcceptedDeliveryStatus.ImageFontSize = 40F;
            this.btnAcceptedDeliveryStatus.ImageTextPadding = 0;
            this.btnAcceptedDeliveryStatus.IsActive = false;
            this.btnAcceptedDeliveryStatus.IsAutoScaleWidth = false;
            this.btnAcceptedDeliveryStatus.IsVerticalImageText = true;
            this.btnAcceptedDeliveryStatus.Location = new System.Drawing.Point(1036, 0);
            this.btnAcceptedDeliveryStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnAcceptedDeliveryStatus.Name = "btnAcceptedDeliveryStatus";
            this.btnAcceptedDeliveryStatus.Size = new System.Drawing.Size(147, 123);
            this.btnAcceptedDeliveryStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAcceptedDeliveryStatus.TabIndex = 2;
            this.btnAcceptedDeliveryStatus.TabStop = false;
            this.btnAcceptedDeliveryStatus.TextColor = System.Drawing.Color.White;
            this.btnAcceptedDeliveryStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAcceptedDeliveryStatus.TextValue = "Đã Nhận";
            this.btnAcceptedDeliveryStatus.ToggleGroup = 3;
            this.btnAcceptedDeliveryStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAcceptedDeliveryStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnRejectedDeliveryStatus
            // 
            this.btnRejectedDeliveryStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnRejectedDeliveryStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnRejectedDeliveryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRejectedDeliveryStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnRejectedDeliveryStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.btnRejectedDeliveryStatus.BorderRadius = 3;
            this.btnRejectedDeliveryStatus.BorderThick = 3;
            this.btnRejectedDeliveryStatus.ButtonValue = "";
            this.btnRejectedDeliveryStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnRejectedDeliveryStatus.Image")));
            this.btnRejectedDeliveryStatus.ImageColor = System.Drawing.Color.White;
            this.btnRejectedDeliveryStatus.ImageCss = "minus-square-o";
            this.btnRejectedDeliveryStatus.ImageFontSize = 40F;
            this.btnRejectedDeliveryStatus.ImageTextPadding = 0;
            this.btnRejectedDeliveryStatus.IsActive = false;
            this.btnRejectedDeliveryStatus.IsAutoScaleWidth = false;
            this.btnRejectedDeliveryStatus.IsVerticalImageText = true;
            this.btnRejectedDeliveryStatus.Location = new System.Drawing.Point(1185, 0);
            this.btnRejectedDeliveryStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnRejectedDeliveryStatus.Name = "btnRejectedDeliveryStatus";
            this.btnRejectedDeliveryStatus.Size = new System.Drawing.Size(147, 123);
            this.btnRejectedDeliveryStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRejectedDeliveryStatus.TabIndex = 4;
            this.btnRejectedDeliveryStatus.TabStop = false;
            this.btnRejectedDeliveryStatus.TextColor = System.Drawing.Color.White;
            this.btnRejectedDeliveryStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRejectedDeliveryStatus.TextValue = "Đã Hủy";
            this.btnRejectedDeliveryStatus.ToggleGroup = 3;
            this.btnRejectedDeliveryStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnRejectedDeliveryStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnBack
            // 
            this.btnBack.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnBack.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack.BorderRadius = 0;
            this.btnBack.BorderThick = 0;
            this.btnBack.ButtonValue = "";
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageColor = System.Drawing.Color.White;
            this.btnBack.ImageCss = "arrow-left";
            this.btnBack.ImageFontSize = 24F;
            this.btnBack.ImageTextPadding = 0;
            this.btnBack.IsActive = false;
            this.btnBack.IsAutoScaleWidth = false;
            this.btnBack.IsVerticalImageText = false;
            this.btnBack.Location = new System.Drawing.Point(7, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 47);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBack.TabIndex = 16;
            this.btnBack.TabStop = false;
            this.btnBack.TextColor = System.Drawing.Color.White;
            this.btnBack.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnBack.TextValue = "";
            this.btnBack.ToggleGroup = 0;
            this.btnBack.Type = POS.CustomControl.ButtonType.Click;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseDown);
            this.btnBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnBack_MouseUp);
            // 
            // pnlPaging
            // 
            this.pnlPaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlPaging.Controls.Add(this.lblTotalPage);
            this.pnlPaging.Controls.Add(this.lblPage);
            this.pnlPaging.Controls.Add(this.btnPageNext);
            this.pnlPaging.Controls.Add(this.btnPageBack);
            this.pnlPaging.Location = new System.Drawing.Point(977, 4);
            this.pnlPaging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(351, 50);
            this.pnlPaging.TabIndex = 12;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.lblTotalPage.Location = new System.Drawing.Point(169, 4);
            this.lblTotalPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(53, 46);
            this.lblTotalPage.TabIndex = 14;
            this.lblTotalPage.Text = "/2";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.ForeColor = System.Drawing.Color.White;
            this.lblPage.Location = new System.Drawing.Point(123, 4);
            this.lblPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(36, 39);
            this.lblPage.TabIndex = 13;
            this.lblPage.Text = "1";
            // 
            // btnPageNext
            // 
            this.btnPageNext.Image = ((System.Drawing.Image)(resources.GetObject("btnPageNext.Image")));
            this.btnPageNext.Location = new System.Drawing.Point(240, 0);
            this.btnPageNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.Size = new System.Drawing.Size(80, 49);
            this.btnPageNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPageNext.TabIndex = 12;
            this.btnPageNext.TabStop = false;
            this.btnPageNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPageNext_MouseDown);
            this.btnPageNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPageNext_MouseUp);
            // 
            // btnPageBack
            // 
            this.btnPageBack.Image = ((System.Drawing.Image)(resources.GetObject("btnPageBack.Image")));
            this.btnPageBack.Location = new System.Drawing.Point(4, 4);
            this.btnPageBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPageBack.Name = "btnPageBack";
            this.btnPageBack.Size = new System.Drawing.Size(68, 43);
            this.btnPageBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPageBack.TabIndex = 11;
            this.btnPageBack.TabStop = false;
            this.btnPageBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnPageBack_MouseDown);
            this.btnPageBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnPageBack_MouseUp);
            // 
            // btnDate
            // 
            this.btnDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnDate.BorderRadius = 2;
            this.btnDate.BorderThick = 1;
            this.btnDate.Caption = "";
            this.btnDate.CenterImageDisable = null;
            this.btnDate.CenterImageNormal = null;
            this.btnDate.CenterImagePress = null;
            this.btnDate.DisableColor = System.Drawing.Color.Empty;
            this.btnDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDate.IsActivated = false;
            this.btnDate.LeftImageDisable = null;
            this.btnDate.LeftImageGap = 0;
            this.btnDate.LeftImageNornal = null;
            this.btnDate.LeftImagePress = null;
            this.btnDate.Location = new System.Drawing.Point(131, 2);
            this.btnDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDate.Name = "btnDate";
            this.btnDate.NormalColor = System.Drawing.Color.White;
            this.btnDate.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnDate.Size = new System.Drawing.Size(267, 47);
            this.btnDate.TabIndex = 10;
            this.btnDate.Click += new System.EventHandler(this.txtDate_Click);
            // 
            // lineGreen
            // 
            this.lineGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.lineGreen.Location = new System.Drawing.Point(0, 52);
            this.lineGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineGreen.Name = "lineGreen";
            this.lineGreen.Size = new System.Drawing.Size(1333, 2);
            this.lineGreen.TabIndex = 5;
            // 
            // orderContainerOuter
            // 
            this.orderContainerOuter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderContainerOuter.Controls.Add(this.orderContainerInner);
            this.orderContainerOuter.Location = new System.Drawing.Point(0, 54);
            this.orderContainerOuter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderContainerOuter.Name = "orderContainerOuter";
            this.orderContainerOuter.Size = new System.Drawing.Size(1333, 363);
            this.orderContainerOuter.TabIndex = 1;
            // 
            // orderContainerInner
            // 
            this.orderContainerInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderContainerInner.AutoSize = true;
            this.orderContainerInner.BackColor = System.Drawing.Color.Gray;
            this.orderContainerInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1304F));
            this.orderContainerInner.Location = new System.Drawing.Point(4, 4);
            this.orderContainerInner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderContainerInner.Name = "orderContainerInner";
            this.orderContainerInner.Padding = new System.Windows.Forms.Padding(20, 18, 0, 0);
            this.orderContainerInner.Size = new System.Drawing.Size(1324, 356);
            this.orderContainerInner.TabIndex = 0;
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "";
            this.ptbLogo.Location = new System.Drawing.Point(0, 19);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 4;
            this.ptbLogo.TabStop = false;
            // 
            // OnlineOrdersScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.pnlOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OnlineOrdersScreen";
            this.Size = new System.Drawing.Size(1333, 635);
            this.pnlOrder.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAllDeliveryStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAssignedDeliveryStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAcceptedDeliveryStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRejectedDeliveryStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).EndInit();
            this.orderContainerOuter.ResumeLayout(false);
            this.orderContainerOuter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel lineGreen;
        private System.Windows.Forms.Panel orderContainerOuter;
        private FlexButton btnDate;
        private System.Windows.Forms.TableLayoutPanel orderContainerInner;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.PictureBox btnPageNext;
        private System.Windows.Forms.PictureBox btnPageBack;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblTotalPage;
        private BootstrapButton btnBack;
        private System.Windows.Forms.PictureBox ptbLogo;
        private BootstrapPanel pnlBottom;
        private BootstrapButton btnAllDeliveryStatus;
        private BootstrapButton btnAssignedDeliveryStatus;
        private BootstrapButton btnAcceptedDeliveryStatus;
        private BootstrapButton btnRejectedDeliveryStatus;
    }
}
