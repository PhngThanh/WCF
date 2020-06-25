using POS.CustomControl;
using POS.Common;

namespace POS.DashboardScreen.ViewOrderScreen
{
    partial class ReviewOrderScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewOrderScreen));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.btnViewNoti = new POS.CustomControl.BootstrapButton();
            this.btnBack = new POS.CustomControl.BootstrapButton();
            this.btnViewReport = new POS.CustomControl.BootstrapButton();
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
            this.btnAtStoreMode = new POS.CustomControl.BootstrapButton();
            this.btnAllMode = new POS.CustomControl.BootstrapButton();
            this.btnTakeAwayMode = new POS.CustomControl.BootstrapButton();
            this.btnDeliveryMode = new POS.CustomControl.BootstrapButton();
            this.pnlBottom = new POS.CustomControl.BootstrapPanel();
            this.btnAllStatus = new POS.CustomControl.BootstrapButton();
            this.btnProcessingStatus = new POS.CustomControl.BootstrapButton();
            this.btnFinishStatus = new POS.CustomControl.BootstrapButton();
            this.btnCancelStatus = new POS.CustomControl.BootstrapButton();
            this.btnOrderCardMode = new POS.CustomControl.BootstrapButton();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewNoti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).BeginInit();
            this.pnlPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).BeginInit();
            this.orderContainerOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAllMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAllStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessingStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinishStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrderCardMode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlOrder.Controls.Add(this.btnViewNoti);
            this.pnlOrder.Controls.Add(this.btnBack);
            this.pnlOrder.Controls.Add(this.btnViewReport);
            this.pnlOrder.Controls.Add(this.pnlPaging);
            this.pnlOrder.Controls.Add(this.btnDate);
            this.pnlOrder.Controls.Add(this.lineGreen);
            this.pnlOrder.Controls.Add(this.orderContainerOuter);
            this.pnlOrder.Location = new System.Drawing.Point(0, 98);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1365, 492);
            this.pnlOrder.TabIndex = 2;
            // 
            // btnViewNoti
            // 
            this.btnViewNoti.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnViewNoti.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnViewNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnViewNoti.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnViewNoti.BorderRadius = 0;
            this.btnViewNoti.BorderThick = 0;
            this.btnViewNoti.ButtonValue = "";
            this.btnViewNoti.Image = ((System.Drawing.Image)(resources.GetObject("btnViewNoti.Image")));
            this.btnViewNoti.ImageColor = System.Drawing.Color.White;
            this.btnViewNoti.ImageCss = "comment-o";
            this.btnViewNoti.ImageFontSize = 16F;
            this.btnViewNoti.ImageTextPadding = 0;
            this.btnViewNoti.IsActive = false;
            this.btnViewNoti.IsAutoScaleWidth = false;
            this.btnViewNoti.IsVerticalImageText = false;
            this.btnViewNoti.Location = new System.Drawing.Point(684, 2);
            this.btnViewNoti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewNoti.Name = "btnViewNoti";
            this.btnViewNoti.Size = new System.Drawing.Size(267, 47);
            this.btnViewNoti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnViewNoti.TabIndex = 16;
            this.btnViewNoti.TabStop = false;
            this.btnViewNoti.TextColor = System.Drawing.Color.White;
            this.btnViewNoti.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewNoti.TextValue = "Xem thông báo";
            this.btnViewNoti.ToggleGroup = 0;
            this.btnViewNoti.Type = POS.CustomControl.ButtonType.Click;
            this.btnViewNoti.Click += new System.EventHandler(this.btnViewNoti_Click);
            // 
            // btnBack
            // 
            this.btnBack.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnBack.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
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
            this.btnBack.Location = new System.Drawing.Point(8, 2);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 47);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBack.TabIndex = 15;
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
            // btnViewReport
            // 
            this.btnViewReport.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnViewReport.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnViewReport.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnViewReport.BorderRadius = 0;
            this.btnViewReport.BorderThick = 0;
            this.btnViewReport.ButtonValue = "";
            this.btnViewReport.Image = ((System.Drawing.Image)(resources.GetObject("btnViewReport.Image")));
            this.btnViewReport.ImageColor = System.Drawing.Color.White;
            this.btnViewReport.ImageCss = "newspaper-o";
            this.btnViewReport.ImageFontSize = 16F;
            this.btnViewReport.ImageTextPadding = 0;
            this.btnViewReport.IsActive = false;
            this.btnViewReport.IsAutoScaleWidth = false;
            this.btnViewReport.IsVerticalImageText = false;
            this.btnViewReport.Location = new System.Drawing.Point(409, 2);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(267, 47);
            this.btnViewReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnViewReport.TabIndex = 14;
            this.btnViewReport.TabStop = false;
            this.btnViewReport.TextColor = System.Drawing.Color.White;
            this.btnViewReport.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewReport.TextValue = "Xem báo cáo";
            this.btnViewReport.ToggleGroup = 0;
            this.btnViewReport.Type = POS.CustomControl.ButtonType.Click;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // pnlPaging
            // 
            this.pnlPaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlPaging.Controls.Add(this.lblTotalPage);
            this.pnlPaging.Controls.Add(this.lblPage);
            this.pnlPaging.Controls.Add(this.btnPageNext);
            this.pnlPaging.Controls.Add(this.btnPageBack);
            this.pnlPaging.Location = new System.Drawing.Point(1017, 5);
            this.pnlPaging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(335, 42);
            this.pnlPaging.TabIndex = 13;
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
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
            this.btnDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
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
            this.btnDate.Location = new System.Drawing.Point(132, 2);
            this.btnDate.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnDate.Name = "btnDate";
            this.btnDate.NormalColor = System.Drawing.Color.White;
            this.btnDate.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnDate.Size = new System.Drawing.Size(267, 47);
            this.btnDate.TabIndex = 10;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // lineGreen
            // 
            this.lineGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.lineGreen.Location = new System.Drawing.Point(0, 52);
            this.lineGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineGreen.Name = "lineGreen";
            this.lineGreen.Size = new System.Drawing.Size(1365, 2);
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
            this.orderContainerOuter.Size = new System.Drawing.Size(1365, 438);
            this.orderContainerOuter.TabIndex = 1;
            // 
            // orderContainerInner
            // 
            this.orderContainerInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orderContainerInner.AutoSize = true;
            this.orderContainerInner.BackColor = System.Drawing.Color.Gray;
            this.orderContainerInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1345F));
            this.orderContainerInner.Location = new System.Drawing.Point(0, 4);
            this.orderContainerInner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderContainerInner.Name = "orderContainerInner";
            this.orderContainerInner.Padding = new System.Windows.Forms.Padding(20, 18, 0, 0);
            this.orderContainerInner.Size = new System.Drawing.Size(1365, 359);
            this.orderContainerInner.TabIndex = 0;
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "";
            this.ptbLogo.Location = new System.Drawing.Point(4, 19);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 3;
            this.ptbLogo.TabStop = false;
            // 
            // btnAtStoreMode
            // 
            this.btnAtStoreMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnAtStoreMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnAtStoreMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtStoreMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnAtStoreMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
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
            this.btnAtStoreMode.Location = new System.Drawing.Point(823, 0);
            this.btnAtStoreMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnAtStoreMode.Name = "btnAtStoreMode";
            this.btnAtStoreMode.Size = new System.Drawing.Size(133, 98);
            this.btnAtStoreMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAtStoreMode.TabIndex = 14;
            this.btnAtStoreMode.TabStop = false;
            this.btnAtStoreMode.TextColor = System.Drawing.Color.White;
            this.btnAtStoreMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnAtStoreMode.TextValue = "Tại quán";
            this.btnAtStoreMode.ToggleGroup = 2;
            this.btnAtStoreMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAtStoreMode.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnAllMode
            // 
            this.btnAllMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAllMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnAllMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnAllMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnAllMode.BorderRadius = 3;
            this.btnAllMode.BorderThick = 3;
            this.btnAllMode.ButtonValue = "";
            this.btnAllMode.Image = ((System.Drawing.Image)(resources.GetObject("btnAllMode.Image")));
            this.btnAllMode.ImageColor = System.Drawing.Color.White;
            this.btnAllMode.ImageCss = "bars";
            this.btnAllMode.ImageFontSize = 40F;
            this.btnAllMode.ImageTextPadding = 0;
            this.btnAllMode.IsActive = false;
            this.btnAllMode.IsAutoScaleWidth = false;
            this.btnAllMode.IsVerticalImageText = true;
            this.btnAllMode.Location = new System.Drawing.Point(687, 0);
            this.btnAllMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnAllMode.Name = "btnAllMode";
            this.btnAllMode.Size = new System.Drawing.Size(133, 98);
            this.btnAllMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAllMode.TabIndex = 11;
            this.btnAllMode.TabStop = false;
            this.btnAllMode.TextColor = System.Drawing.Color.White;
            this.btnAllMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnAllMode.TextValue = "Tất cả";
            this.btnAllMode.ToggleGroup = 2;
            this.btnAllMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAllMode.Click += new System.EventHandler(this.btnStatus_Click);
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
            this.btnTakeAwayMode.Location = new System.Drawing.Point(959, 0);
            this.btnTakeAwayMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnTakeAwayMode.Name = "btnTakeAwayMode";
            this.btnTakeAwayMode.Size = new System.Drawing.Size(133, 98);
            this.btnTakeAwayMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnTakeAwayMode.TabIndex = 12;
            this.btnTakeAwayMode.TabStop = false;
            this.btnTakeAwayMode.TextColor = System.Drawing.Color.White;
            this.btnTakeAwayMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnTakeAwayMode.TextValue = "Mang về";
            this.btnTakeAwayMode.ToggleGroup = 2;
            this.btnTakeAwayMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnTakeAwayMode.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDeliveryMode
            // 
            this.btnDeliveryMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnDeliveryMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnDeliveryMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliveryMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnDeliveryMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
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
            this.btnDeliveryMode.Location = new System.Drawing.Point(1095, 0);
            this.btnDeliveryMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeliveryMode.Name = "btnDeliveryMode";
            this.btnDeliveryMode.Size = new System.Drawing.Size(133, 98);
            this.btnDeliveryMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDeliveryMode.TabIndex = 13;
            this.btnDeliveryMode.TabStop = false;
            this.btnDeliveryMode.TextColor = System.Drawing.Color.White;
            this.btnDeliveryMode.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnDeliveryMode.TextValue = "Giao hàng";
            this.btnDeliveryMode.ToggleGroup = 2;
            this.btnDeliveryMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnDeliveryMode.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlBottom.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlBottom.Controls.Add(this.btnAllStatus);
            this.pnlBottom.Controls.Add(this.btnProcessingStatus);
            this.pnlBottom.Controls.Add(this.btnFinishStatus);
            this.pnlBottom.Controls.Add(this.btnCancelStatus);
            this.pnlBottom.Location = new System.Drawing.Point(0, 512);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1365, 123);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnAllStatus
            // 
            this.btnAllStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAllStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnAllStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnAllStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnAllStatus.BorderRadius = 3;
            this.btnAllStatus.BorderThick = 3;
            this.btnAllStatus.ButtonValue = "";
            this.btnAllStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnAllStatus.Image")));
            this.btnAllStatus.ImageColor = System.Drawing.Color.White;
            this.btnAllStatus.ImageCss = "cubes";
            this.btnAllStatus.ImageFontSize = 40F;
            this.btnAllStatus.ImageTextPadding = 0;
            this.btnAllStatus.IsActive = false;
            this.btnAllStatus.IsAutoScaleWidth = false;
            this.btnAllStatus.IsVerticalImageText = true;
            this.btnAllStatus.Location = new System.Drawing.Point(757, 0);
            this.btnAllStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnAllStatus.Name = "btnAllStatus";
            this.btnAllStatus.Size = new System.Drawing.Size(147, 123);
            this.btnAllStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAllStatus.TabIndex = 6;
            this.btnAllStatus.TabStop = false;
            this.btnAllStatus.TextColor = System.Drawing.Color.White;
            this.btnAllStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAllStatus.TextValue = "Tất cả";
            this.btnAllStatus.ToggleGroup = 3;
            this.btnAllStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAllStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnProcessingStatus
            // 
            this.btnProcessingStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnProcessingStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnProcessingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessingStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnProcessingStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnProcessingStatus.BorderRadius = 3;
            this.btnProcessingStatus.BorderThick = 3;
            this.btnProcessingStatus.ButtonValue = "";
            this.btnProcessingStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessingStatus.Image")));
            this.btnProcessingStatus.ImageColor = System.Drawing.Color.White;
            this.btnProcessingStatus.ImageCss = "fire";
            this.btnProcessingStatus.ImageFontSize = 40F;
            this.btnProcessingStatus.ImageTextPadding = 0;
            this.btnProcessingStatus.IsActive = false;
            this.btnProcessingStatus.IsAutoScaleWidth = false;
            this.btnProcessingStatus.IsVerticalImageText = true;
            this.btnProcessingStatus.Location = new System.Drawing.Point(1056, 0);
            this.btnProcessingStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnProcessingStatus.Name = "btnProcessingStatus";
            this.btnProcessingStatus.Size = new System.Drawing.Size(147, 123);
            this.btnProcessingStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnProcessingStatus.TabIndex = 5;
            this.btnProcessingStatus.TabStop = false;
            this.btnProcessingStatus.TextColor = System.Drawing.Color.White;
            this.btnProcessingStatus.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnProcessingStatus.TextValue = "Đang chế biến";
            this.btnProcessingStatus.ToggleGroup = 3;
            this.btnProcessingStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnProcessingStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnFinishStatus
            // 
            this.btnFinishStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnFinishStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnFinishStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinishStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnFinishStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnFinishStatus.BorderRadius = 3;
            this.btnFinishStatus.BorderThick = 3;
            this.btnFinishStatus.ButtonValue = "";
            this.btnFinishStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnFinishStatus.Image")));
            this.btnFinishStatus.ImageColor = System.Drawing.Color.White;
            this.btnFinishStatus.ImageCss = "check-square-o";
            this.btnFinishStatus.ImageFontSize = 40F;
            this.btnFinishStatus.ImageTextPadding = 0;
            this.btnFinishStatus.IsActive = false;
            this.btnFinishStatus.IsAutoScaleWidth = false;
            this.btnFinishStatus.IsVerticalImageText = true;
            this.btnFinishStatus.Location = new System.Drawing.Point(907, 0);
            this.btnFinishStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnFinishStatus.Name = "btnFinishStatus";
            this.btnFinishStatus.Size = new System.Drawing.Size(147, 123);
            this.btnFinishStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFinishStatus.TabIndex = 2;
            this.btnFinishStatus.TabStop = false;
            this.btnFinishStatus.TextColor = System.Drawing.Color.White;
            this.btnFinishStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnFinishStatus.TextValue = "Hoàn tất";
            this.btnFinishStatus.ToggleGroup = 3;
            this.btnFinishStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnFinishStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnCancelStatus
            // 
            this.btnCancelStatus.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnCancelStatus.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelStatus.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.btnCancelStatus.BorderRadius = 3;
            this.btnCancelStatus.BorderThick = 3;
            this.btnCancelStatus.ButtonValue = "";
            this.btnCancelStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelStatus.Image")));
            this.btnCancelStatus.ImageColor = System.Drawing.Color.White;
            this.btnCancelStatus.ImageCss = "minus-square-o";
            this.btnCancelStatus.ImageFontSize = 40F;
            this.btnCancelStatus.ImageTextPadding = 0;
            this.btnCancelStatus.IsActive = false;
            this.btnCancelStatus.IsAutoScaleWidth = false;
            this.btnCancelStatus.IsVerticalImageText = true;
            this.btnCancelStatus.Location = new System.Drawing.Point(1205, 0);
            this.btnCancelStatus.Margin = new System.Windows.Forms.Padding(1);
            this.btnCancelStatus.Name = "btnCancelStatus";
            this.btnCancelStatus.Size = new System.Drawing.Size(160, 123);
            this.btnCancelStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelStatus.TabIndex = 4;
            this.btnCancelStatus.TabStop = false;
            this.btnCancelStatus.TextColor = System.Drawing.Color.White;
            this.btnCancelStatus.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancelStatus.TextValue = "Hủy";
            this.btnCancelStatus.ToggleGroup = 3;
            this.btnCancelStatus.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnCancelStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnOrderCardMode
            // 
            this.btnOrderCardMode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnOrderCardMode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnOrderCardMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderCardMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnOrderCardMode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnOrderCardMode.BorderRadius = 3;
            this.btnOrderCardMode.BorderThick = 3;
            this.btnOrderCardMode.ButtonValue = "";
            this.btnOrderCardMode.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderCardMode.Image")));
            this.btnOrderCardMode.ImageColor = System.Drawing.Color.White;
            this.btnOrderCardMode.ImageCss = "credit-card";
            this.btnOrderCardMode.ImageFontSize = 40F;
            this.btnOrderCardMode.ImageTextPadding = 0;
            this.btnOrderCardMode.IsActive = false;
            this.btnOrderCardMode.IsAutoScaleWidth = false;
            this.btnOrderCardMode.IsVerticalImageText = true;
            this.btnOrderCardMode.Location = new System.Drawing.Point(1231, 0);
            this.btnOrderCardMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnOrderCardMode.Name = "btnOrderCardMode";
            this.btnOrderCardMode.Size = new System.Drawing.Size(133, 98);
            this.btnOrderCardMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnOrderCardMode.TabIndex = 15;
            this.btnOrderCardMode.TabStop = false;
            this.btnOrderCardMode.TextColor = System.Drawing.Color.White;
            this.btnOrderCardMode.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnOrderCardMode.TextValue = "Thẻ";
            this.btnOrderCardMode.ToggleGroup = 2;
            this.btnOrderCardMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnOrderCardMode.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // ReviewOrderScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.btnOrderCardMode);
            this.Controls.Add(this.btnAtStoreMode);
            this.Controls.Add(this.btnAllMode);
            this.Controls.Add(this.btnTakeAwayMode);
            this.Controls.Add(this.btnDeliveryMode);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.pnlOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReviewOrderScreen";
            this.Size = new System.Drawing.Size(1365, 635);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnViewNoti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnViewReport)).EndInit();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).EndInit();
            this.orderContainerOuter.ResumeLayout(false);
            this.orderContainerOuter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAllMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAllStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcessingStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinishStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrderCardMode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel lineGreen;
        private System.Windows.Forms.Panel orderContainerOuter;
        private System.Windows.Forms.TableLayoutPanel orderContainerInner;
        private FlexButton btnDate;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.PictureBox btnPageNext;
        private System.Windows.Forms.PictureBox btnPageBack;
        private BootstrapButton btnViewReport;
        private BootstrapButton btnBack;
        private System.Windows.Forms.PictureBox ptbLogo;
        private BootstrapPanel pnlBottom;
        private BootstrapButton btnProcessingStatus;
        private BootstrapButton btnFinishStatus;
        private BootstrapButton btnCancelStatus;
        private BootstrapButton btnAllStatus;
        private BootstrapButton btnAtStoreMode;
        private BootstrapButton btnAllMode;
        private BootstrapButton btnTakeAwayMode;
        private BootstrapButton btnDeliveryMode;
        private BootstrapButton btnOrderCardMode;
        private BootstrapButton btnViewNoti;
    }
}
