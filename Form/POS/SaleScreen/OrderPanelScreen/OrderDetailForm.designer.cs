using POS.CustomControl;
using System.ComponentModel;
using System.Windows.Forms;

namespace POS.SaleScreen
{
    partial class OrderDetailForm
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailForm));
            this.pnlBottomPanel = new System.Windows.Forms.Panel();
            this.btnCancel = new POS.CustomControl.BootstrapButton();
            this.btnClose = new POS.CustomControl.BootstrapButton();
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.barTop = new POS.SaleScreen.CustomControl.CategoryBar();
            this.btnExtra2 = new POS.CustomControl.BootstrapButton();
            this.btnMoreExtra = new POS.CustomControl.BootstrapButton();
            this.btnExtra1 = new POS.CustomControl.BootstrapButton();
            this.btnGeneral = new POS.CustomControl.BootstrapButton();
            this.btnAttribute = new POS.CustomControl.BootstrapButton();
            this.barMore = new POS.SaleScreen.CustomControl.CategoryBar();
            this.btnExtra3 = new POS.CustomControl.BootstrapButton();
            this.btnExtra4 = new POS.CustomControl.BootstrapButton();
            this.btnExtra7 = new POS.CustomControl.BootstrapButton();
            this.btnExtra6 = new POS.CustomControl.BootstrapButton();
            this.btnExtra5 = new POS.CustomControl.BootstrapButton();
            this.btnClone = new POS.CustomControl.BootstrapButton();
            this.pnlBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.barTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreExtra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAttribute)).BeginInit();
            this.barMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClone)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottomPanel
            // 
            this.pnlBottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.pnlBottomPanel.Controls.Add(this.btnCancel);
            this.pnlBottomPanel.Controls.Add(this.btnClone);
            this.pnlBottomPanel.Controls.Add(this.btnClose);
            this.pnlBottomPanel.Location = new System.Drawing.Point(3, 585);
            this.pnlBottomPanel.Name = "pnlBottomPanel";
            this.pnlBottomPanel.Size = new System.Drawing.Size(665, 72);
            this.pnlBottomPanel.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnCancel.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancel.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderThick = 0;
            this.btnCancel.ButtonValue = "";
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageColor = System.Drawing.Color.White;
            this.btnCancel.ImageCss = "close";
            this.btnCancel.ImageFontSize = 35F;
            this.btnCancel.ImageTextPadding = 0;
            this.btnCancel.IsActive = false;
            this.btnCancel.IsAutoScaleWidth = false;
            this.btnCancel.IsVerticalImageText = true;
            this.btnCancel.Location = new System.Drawing.Point(2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 69);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancel.TabIndex = 0;
            this.btnCancel.TabStop = false;
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.TextValue = "Hủy";
            this.btnCancel.ToggleGroup = 0;
            this.btnCancel.Type = POS.CustomControl.ButtonType.Click;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnClose.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnClose.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnClose.BorderRadius = 0;
            this.btnClose.BorderThick = 0;
            this.btnClose.ButtonValue = "";
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageColor = System.Drawing.Color.White;
            this.btnClose.ImageCss = "pause";
            this.btnClose.ImageFontSize = 35F;
            this.btnClose.ImageTextPadding = 0;
            this.btnClose.IsActive = false;
            this.btnClose.IsAutoScaleWidth = false;
            this.btnClose.IsVerticalImageText = true;
            this.btnClose.Location = new System.Drawing.Point(529, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 69);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.TextValue = "Ẩn";
            this.btnClose.ToggleGroup = 0;
            this.btnClose.Type = POS.CustomControl.ButtonType.Click;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlMain.Location = new System.Drawing.Point(3, 53);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(665, 533);
            this.pnlMain.TabIndex = 3;
            // 
            // barTop
            // 
            this.barTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barTop.BackColor = System.Drawing.Color.White;
            this.barTop.Controls.Add(this.btnExtra2);
            this.barTop.Controls.Add(this.btnMoreExtra);
            this.barTop.Controls.Add(this.btnExtra1);
            this.barTop.Controls.Add(this.btnGeneral);
            this.barTop.Controls.Add(this.btnAttribute);
            this.barTop.Location = new System.Drawing.Point(3, 3);
            this.barTop.Margin = new System.Windows.Forms.Padding(0);
            this.barTop.Name = "barTop";
            this.barTop.Size = new System.Drawing.Size(665, 50);
            this.barTop.TabIndex = 1;
            // 
            // btnExtra2
            // 
            this.btnExtra2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra2.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra2.BorderRadius = 0;
            this.btnExtra2.BorderThick = 0;
            this.btnExtra2.ButtonValue = "1";
            this.btnExtra2.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra2.Image")));
            this.btnExtra2.ImageColor = System.Drawing.Color.White;
            this.btnExtra2.ImageCss = "list-alt";
            this.btnExtra2.ImageFontSize = 20F;
            this.btnExtra2.ImageTextPadding = 0;
            this.btnExtra2.IsActive = false;
            this.btnExtra2.IsAutoScaleWidth = false;
            this.btnExtra2.IsVerticalImageText = false;
            this.btnExtra2.Location = new System.Drawing.Point(351, 3);
            this.btnExtra2.Name = "btnExtra2";
            this.btnExtra2.Size = new System.Drawing.Size(115, 44);
            this.btnExtra2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra2.TabIndex = 7;
            this.btnExtra2.TabStop = false;
            this.btnExtra2.TextColor = System.Drawing.Color.White;
            this.btnExtra2.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra2.TextValue = "Extra 2";
            this.btnExtra2.ToggleGroup = 0;
            this.btnExtra2.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra2.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnMoreExtra
            // 
            this.btnMoreExtra.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnMoreExtra.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnMoreExtra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnMoreExtra.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnMoreExtra.BorderRadius = 0;
            this.btnMoreExtra.BorderThick = 0;
            this.btnMoreExtra.ButtonValue = "2";
            this.btnMoreExtra.Image = ((System.Drawing.Image)(resources.GetObject("btnMoreExtra.Image")));
            this.btnMoreExtra.ImageColor = System.Drawing.Color.White;
            this.btnMoreExtra.ImageCss = "list-alt";
            this.btnMoreExtra.ImageFontSize = 20F;
            this.btnMoreExtra.ImageTextPadding = 0;
            this.btnMoreExtra.IsActive = false;
            this.btnMoreExtra.IsAutoScaleWidth = false;
            this.btnMoreExtra.IsVerticalImageText = false;
            this.btnMoreExtra.Location = new System.Drawing.Point(467, 3);
            this.btnMoreExtra.Name = "btnMoreExtra";
            this.btnMoreExtra.Size = new System.Drawing.Size(115, 44);
            this.btnMoreExtra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMoreExtra.TabIndex = 8;
            this.btnMoreExtra.TabStop = false;
            this.btnMoreExtra.TextColor = System.Drawing.Color.White;
            this.btnMoreExtra.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoreExtra.TextValue = "Thêm";
            this.btnMoreExtra.ToggleGroup = 0;
            this.btnMoreExtra.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnMoreExtra.Visible = false;
            this.btnMoreExtra.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // btnExtra1
            // 
            this.btnExtra1.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra1.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra1.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra1.BorderRadius = 0;
            this.btnExtra1.BorderThick = 0;
            this.btnExtra1.ButtonValue = "0";
            this.btnExtra1.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra1.Image")));
            this.btnExtra1.ImageColor = System.Drawing.Color.White;
            this.btnExtra1.ImageCss = "list-alt";
            this.btnExtra1.ImageFontSize = 20F;
            this.btnExtra1.ImageTextPadding = 0;
            this.btnExtra1.IsActive = false;
            this.btnExtra1.IsAutoScaleWidth = false;
            this.btnExtra1.IsVerticalImageText = false;
            this.btnExtra1.Location = new System.Drawing.Point(235, 3);
            this.btnExtra1.Name = "btnExtra1";
            this.btnExtra1.Size = new System.Drawing.Size(115, 44);
            this.btnExtra1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra1.TabIndex = 6;
            this.btnExtra1.TabStop = false;
            this.btnExtra1.TextColor = System.Drawing.Color.White;
            this.btnExtra1.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra1.TextValue = "Extra 1";
            this.btnExtra1.ToggleGroup = 0;
            this.btnExtra1.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra1.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnGeneral.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnGeneral.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnGeneral.BorderRadius = 0;
            this.btnGeneral.BorderThick = 0;
            this.btnGeneral.ButtonValue = "";
            this.btnGeneral.Image = ((System.Drawing.Image)(resources.GetObject("btnGeneral.Image")));
            this.btnGeneral.ImageColor = System.Drawing.Color.White;
            this.btnGeneral.ImageCss = "list-alt";
            this.btnGeneral.ImageFontSize = 20F;
            this.btnGeneral.ImageTextPadding = 0;
            this.btnGeneral.IsActive = false;
            this.btnGeneral.IsAutoScaleWidth = false;
            this.btnGeneral.IsVerticalImageText = false;
            this.btnGeneral.Location = new System.Drawing.Point(3, 3);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(115, 44);
            this.btnGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnGeneral.TabIndex = 4;
            this.btnGeneral.TabStop = false;
            this.btnGeneral.TextColor = System.Drawing.Color.White;
            this.btnGeneral.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneral.TextValue = "Tổng quan";
            this.btnGeneral.ToggleGroup = 0;
            this.btnGeneral.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnAttribute
            // 
            this.btnAttribute.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnAttribute.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAttribute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAttribute.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnAttribute.BorderRadius = 0;
            this.btnAttribute.BorderThick = 0;
            this.btnAttribute.ButtonValue = "";
            this.btnAttribute.Image = ((System.Drawing.Image)(resources.GetObject("btnAttribute.Image")));
            this.btnAttribute.ImageColor = System.Drawing.Color.White;
            this.btnAttribute.ImageCss = "list-alt";
            this.btnAttribute.ImageFontSize = 20F;
            this.btnAttribute.ImageTextPadding = 0;
            this.btnAttribute.IsActive = false;
            this.btnAttribute.IsAutoScaleWidth = false;
            this.btnAttribute.IsVerticalImageText = false;
            this.btnAttribute.Location = new System.Drawing.Point(119, 3);
            this.btnAttribute.Name = "btnAttribute";
            this.btnAttribute.Size = new System.Drawing.Size(115, 44);
            this.btnAttribute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAttribute.TabIndex = 5;
            this.btnAttribute.TabStop = false;
            this.btnAttribute.TextColor = System.Drawing.Color.White;
            this.btnAttribute.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttribute.TextValue = "Ðặc tính";
            this.btnAttribute.ToggleGroup = 0;
            this.btnAttribute.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAttribute.Click += new System.EventHandler(this.btnAttribute_Click);
            // 
            // barMore
            // 
            this.barMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barMore.BackColor = System.Drawing.Color.White;
            this.barMore.Controls.Add(this.btnExtra3);
            this.barMore.Controls.Add(this.btnExtra4);
            this.barMore.Controls.Add(this.btnExtra7);
            this.barMore.Controls.Add(this.btnExtra6);
            this.barMore.Controls.Add(this.btnExtra5);
            this.barMore.Location = new System.Drawing.Point(2, 56);
            this.barMore.Margin = new System.Windows.Forms.Padding(0);
            this.barMore.Name = "barMore";
            this.barMore.Size = new System.Drawing.Size(665, 50);
            this.barMore.TabIndex = 9;
            // 
            // btnExtra3
            // 
            this.btnExtra3.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra3.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra3.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra3.BorderRadius = 0;
            this.btnExtra3.BorderThick = 0;
            this.btnExtra3.ButtonValue = "2";
            this.btnExtra3.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra3.Image")));
            this.btnExtra3.ImageColor = System.Drawing.Color.White;
            this.btnExtra3.ImageCss = "list-alt";
            this.btnExtra3.ImageFontSize = 20F;
            this.btnExtra3.ImageTextPadding = 0;
            this.btnExtra3.IsActive = false;
            this.btnExtra3.IsAutoScaleWidth = false;
            this.btnExtra3.IsVerticalImageText = false;
            this.btnExtra3.Location = new System.Drawing.Point(3, 3);
            this.btnExtra3.Name = "btnExtra3";
            this.btnExtra3.Size = new System.Drawing.Size(115, 44);
            this.btnExtra3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra3.TabIndex = 8;
            this.btnExtra3.TabStop = false;
            this.btnExtra3.TextColor = System.Drawing.Color.White;
            this.btnExtra3.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra3.TextValue = "Extra 3";
            this.btnExtra3.ToggleGroup = 0;
            this.btnExtra3.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra3.Visible = false;
            this.btnExtra3.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnExtra4
            // 
            this.btnExtra4.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra4.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra4.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra4.BorderRadius = 0;
            this.btnExtra4.BorderThick = 0;
            this.btnExtra4.ButtonValue = "1";
            this.btnExtra4.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra4.Image")));
            this.btnExtra4.ImageColor = System.Drawing.Color.White;
            this.btnExtra4.ImageCss = "list-alt";
            this.btnExtra4.ImageFontSize = 20F;
            this.btnExtra4.ImageTextPadding = 0;
            this.btnExtra4.IsActive = false;
            this.btnExtra4.IsAutoScaleWidth = false;
            this.btnExtra4.IsVerticalImageText = false;
            this.btnExtra4.Location = new System.Drawing.Point(119, 3);
            this.btnExtra4.Name = "btnExtra4";
            this.btnExtra4.Size = new System.Drawing.Size(115, 44);
            this.btnExtra4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra4.TabIndex = 7;
            this.btnExtra4.TabStop = false;
            this.btnExtra4.TextColor = System.Drawing.Color.White;
            this.btnExtra4.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra4.TextValue = "Extra 4";
            this.btnExtra4.ToggleGroup = 0;
            this.btnExtra4.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra4.Visible = false;
            this.btnExtra4.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnExtra7
            // 
            this.btnExtra7.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra7.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra7.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra7.BorderRadius = 0;
            this.btnExtra7.BorderThick = 0;
            this.btnExtra7.ButtonValue = "0";
            this.btnExtra7.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra7.Image")));
            this.btnExtra7.ImageColor = System.Drawing.Color.White;
            this.btnExtra7.ImageCss = "list-alt";
            this.btnExtra7.ImageFontSize = 20F;
            this.btnExtra7.ImageTextPadding = 0;
            this.btnExtra7.IsActive = false;
            this.btnExtra7.IsAutoScaleWidth = false;
            this.btnExtra7.IsVerticalImageText = false;
            this.btnExtra7.Location = new System.Drawing.Point(467, 3);
            this.btnExtra7.Name = "btnExtra7";
            this.btnExtra7.Size = new System.Drawing.Size(115, 44);
            this.btnExtra7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra7.TabIndex = 6;
            this.btnExtra7.TabStop = false;
            this.btnExtra7.TextColor = System.Drawing.Color.White;
            this.btnExtra7.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra7.TextValue = "Extra 7";
            this.btnExtra7.ToggleGroup = 0;
            this.btnExtra7.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra7.Visible = false;
            this.btnExtra7.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnExtra6
            // 
            this.btnExtra6.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra6.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra6.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra6.BorderRadius = 0;
            this.btnExtra6.BorderThick = 0;
            this.btnExtra6.ButtonValue = "1";
            this.btnExtra6.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra6.Image")));
            this.btnExtra6.ImageColor = System.Drawing.Color.White;
            this.btnExtra6.ImageCss = "list-alt";
            this.btnExtra6.ImageFontSize = 20F;
            this.btnExtra6.ImageTextPadding = 0;
            this.btnExtra6.IsActive = false;
            this.btnExtra6.IsAutoScaleWidth = false;
            this.btnExtra6.IsVerticalImageText = false;
            this.btnExtra6.Location = new System.Drawing.Point(351, 3);
            this.btnExtra6.Name = "btnExtra6";
            this.btnExtra6.Size = new System.Drawing.Size(115, 44);
            this.btnExtra6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra6.TabIndex = 7;
            this.btnExtra6.TabStop = false;
            this.btnExtra6.TextColor = System.Drawing.Color.White;
            this.btnExtra6.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra6.TextValue = "Extra 6";
            this.btnExtra6.ToggleGroup = 0;
            this.btnExtra6.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra6.Visible = false;
            this.btnExtra6.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnExtra5
            // 
            this.btnExtra5.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnExtra5.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnExtra5.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnExtra5.BorderRadius = 0;
            this.btnExtra5.BorderThick = 0;
            this.btnExtra5.ButtonValue = "0";
            this.btnExtra5.Image = ((System.Drawing.Image)(resources.GetObject("btnExtra5.Image")));
            this.btnExtra5.ImageColor = System.Drawing.Color.White;
            this.btnExtra5.ImageCss = "list-alt";
            this.btnExtra5.ImageFontSize = 20F;
            this.btnExtra5.ImageTextPadding = 0;
            this.btnExtra5.IsActive = false;
            this.btnExtra5.IsAutoScaleWidth = false;
            this.btnExtra5.IsVerticalImageText = false;
            this.btnExtra5.Location = new System.Drawing.Point(235, 3);
            this.btnExtra5.Name = "btnExtra5";
            this.btnExtra5.Size = new System.Drawing.Size(115, 44);
            this.btnExtra5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnExtra5.TabIndex = 6;
            this.btnExtra5.TabStop = false;
            this.btnExtra5.TextColor = System.Drawing.Color.White;
            this.btnExtra5.TextFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtra5.TextValue = "Extra 5";
            this.btnExtra5.ToggleGroup = 0;
            this.btnExtra5.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnExtra5.Visible = false;
            this.btnExtra5.Click += new System.EventHandler(this.btnExtra_Click);
            // 
            // btnClone
            // 
            this.btnClone.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnClone.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnClone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnClone.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnClone.BorderRadius = 0;
            this.btnClone.BorderThick = 0;
            this.btnClone.ButtonValue = "";
            this.btnClone.Image = ((System.Drawing.Image)(resources.GetObject("btnClone.Image")));
            this.btnClone.ImageColor = System.Drawing.Color.White;
            this.btnClone.ImageCss = "plus-square";
            this.btnClone.ImageFontSize = 35F;
            this.btnClone.ImageTextPadding = 0;
            this.btnClone.IsActive = false;
            this.btnClone.IsAutoScaleWidth = false;
            this.btnClone.IsVerticalImageText = true;
            this.btnClone.Location = new System.Drawing.Point(389, 2);
            this.btnClone.Name = "btnClone";
            this.btnClone.Size = new System.Drawing.Size(135, 69);
            this.btnClone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClone.TabIndex = 0;
            this.btnClone.TabStop = false;
            this.btnClone.TextColor = System.Drawing.Color.White;
            this.btnClone.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClone.TextValue = "Thêm mới";
            this.btnClone.ToggleGroup = 0;
            this.btnClone.Type = POS.CustomControl.ButtonType.Click;
            this.btnClone.Click += new System.EventHandler(this.btnClone_Click);
            // 
            // OrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 660);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.barTop);
            this.Controls.Add(this.pnlBottomPanel);
            this.Controls.Add(this.barMore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chọn sản phẩm";
            this.pnlBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.barTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoreExtra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAttribute)).EndInit();
            this.barMore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExtra5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Panel lblReset;
        private Panel pnlBottomPanel;
       // private TableLayoutPanel pnlMainContainer;
        private CustomControl.CategoryBar barTop;
        private BootstrapPanel pnlMain;
        private POS.CustomControl.BootstrapButton btnGeneral;
        private POS.CustomControl.BootstrapButton btnClose;
        private POS.CustomControl.BootstrapButton btnAttribute;
        private POS.CustomControl.BootstrapButton btnExtra3;
        private POS.CustomControl.BootstrapButton btnExtra2;
        private POS.CustomControl.BootstrapButton btnExtra1;
        private CustomControl.CategoryBar barMore;
        private BootstrapButton btnExtra4;
        private BootstrapButton btnExtra7;
        private BootstrapButton btnExtra6;
        private BootstrapButton btnExtra5;
        private BootstrapButton btnMoreExtra;
        private BootstrapButton btnCancel;
        private BootstrapButton btnClone;
    }
}
