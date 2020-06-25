using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class OrderDetailPropetyPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailPropetyPanel));
            this.pnlMainContainer = new POS.CustomControl.BootstrapPanel();
            this.pnlDiscountControls = new System.Windows.Forms.Panel();
            this.btnODPromotion1 = new POS.CustomControl.BootstrapButton();
            this.btnODPromotion2 = new POS.CustomControl.BootstrapButton();
            this.btnODPromotion3 = new POS.CustomControl.BootstrapButton();
            this.btnODPromotion4 = new POS.CustomControl.BootstrapButton();
            this.lblQuantity = new System.Windows.Forms.Label();
            this._extraPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnDecreaseQuantity = new POS.CustomControl.BootstrapButton();
            this.btnIncreaseQuantity = new POS.CustomControl.BootstrapButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDiscountOnProduct = new System.Windows.Forms.Label();
            this.btnPromotionRefresh = new POS.CustomControl.BootstrapButton();
            this.pnlNumPad = new POS.SaleScreen.CustomControl.NumPadPanel();
            this.txtQuantity = new POS.Common.FlatTextBox();
            this.pnlMainContainer.SuspendLayout();
            this.pnlDiscountControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecreaseQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncreaseQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPromotionRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlMainContainer.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlMainContainer.Controls.Add(this.btnPromotionRefresh);
            this.pnlMainContainer.Controls.Add(this.pnlDiscountControls);
            this.pnlMainContainer.Controls.Add(this.lblQuantity);
            this.pnlMainContainer.Controls.Add(this._extraPanel);
            this.pnlMainContainer.Controls.Add(this.pnlNumPad);
            this.pnlMainContainer.Controls.Add(this.btnDecreaseQuantity);
            this.pnlMainContainer.Controls.Add(this.btnIncreaseQuantity);
            this.pnlMainContainer.Controls.Add(this.label2);
            this.pnlMainContainer.Controls.Add(this.lblDiscountOnProduct);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(663, 550);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // pnlDiscountControls
            // 
            this.pnlDiscountControls.Controls.Add(this.btnODPromotion1);
            this.pnlDiscountControls.Controls.Add(this.btnODPromotion2);
            this.pnlDiscountControls.Controls.Add(this.btnODPromotion3);
            this.pnlDiscountControls.Controls.Add(this.btnODPromotion4);
            this.pnlDiscountControls.Location = new System.Drawing.Point(9, 59);
            this.pnlDiscountControls.Name = "pnlDiscountControls";
            this.pnlDiscountControls.Size = new System.Drawing.Size(415, 59);
            this.pnlDiscountControls.TabIndex = 13;
            // 
            // btnODPromotion1
            // 
            this.btnODPromotion1.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnODPromotion1.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnODPromotion1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnODPromotion1.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnODPromotion1.BorderRadius = 3;
            this.btnODPromotion1.BorderThick = 3;
            this.btnODPromotion1.ButtonValue = "20";
            this.btnODPromotion1.Image = ((System.Drawing.Image)(resources.GetObject("btnODPromotion1.Image")));
            this.btnODPromotion1.ImageColor = System.Drawing.Color.White;
            this.btnODPromotion1.ImageCss = "percent";
            this.btnODPromotion1.ImageFontSize = 20F;
            this.btnODPromotion1.ImageTextPadding = 0;
            this.btnODPromotion1.IsActive = false;
            this.btnODPromotion1.IsAutoScaleWidth = false;
            this.btnODPromotion1.IsVerticalImageText = true;
            this.btnODPromotion1.Location = new System.Drawing.Point(15, 3);
            this.btnODPromotion1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnODPromotion1.Name = "btnODPromotion1";
            this.btnODPromotion1.Size = new System.Drawing.Size(70, 50);
            this.btnODPromotion1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnODPromotion1.TabIndex = 7;
            this.btnODPromotion1.TabStop = false;
            this.btnODPromotion1.TextColor = System.Drawing.Color.White;
            this.btnODPromotion1.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnODPromotion1.TextValue = "Name1";
            this.btnODPromotion1.ToggleGroup = 1;
            this.btnODPromotion1.Type = POS.CustomControl.ButtonType.Click;
            this.btnODPromotion1.Click += new System.EventHandler(this.OnDiscount_ClickedAsync);
            // 
            // btnODPromotion2
            // 
            this.btnODPromotion2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnODPromotion2.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnODPromotion2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnODPromotion2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnODPromotion2.BorderRadius = 3;
            this.btnODPromotion2.BorderThick = 3;
            this.btnODPromotion2.ButtonValue = "20";
            this.btnODPromotion2.Image = ((System.Drawing.Image)(resources.GetObject("btnODPromotion2.Image")));
            this.btnODPromotion2.ImageColor = System.Drawing.Color.White;
            this.btnODPromotion2.ImageCss = "percent";
            this.btnODPromotion2.ImageFontSize = 20F;
            this.btnODPromotion2.ImageTextPadding = 0;
            this.btnODPromotion2.IsActive = false;
            this.btnODPromotion2.IsAutoScaleWidth = false;
            this.btnODPromotion2.IsVerticalImageText = true;
            this.btnODPromotion2.Location = new System.Drawing.Point(98, 3);
            this.btnODPromotion2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnODPromotion2.Name = "btnODPromotion2";
            this.btnODPromotion2.Size = new System.Drawing.Size(70, 50);
            this.btnODPromotion2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnODPromotion2.TabIndex = 7;
            this.btnODPromotion2.TabStop = false;
            this.btnODPromotion2.TextColor = System.Drawing.Color.White;
            this.btnODPromotion2.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnODPromotion2.TextValue = "Name2";
            this.btnODPromotion2.ToggleGroup = 1;
            this.btnODPromotion2.Type = POS.CustomControl.ButtonType.Click;
            this.btnODPromotion2.Click += new System.EventHandler(this.OnDiscount_ClickedAsync);
            // 
            // btnODPromotion3
            // 
            this.btnODPromotion3.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnODPromotion3.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnODPromotion3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnODPromotion3.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnODPromotion3.BorderRadius = 3;
            this.btnODPromotion3.BorderThick = 3;
            this.btnODPromotion3.ButtonValue = "50";
            this.btnODPromotion3.Image = ((System.Drawing.Image)(resources.GetObject("btnODPromotion3.Image")));
            this.btnODPromotion3.ImageColor = System.Drawing.Color.White;
            this.btnODPromotion3.ImageCss = "percent";
            this.btnODPromotion3.ImageFontSize = 20F;
            this.btnODPromotion3.ImageTextPadding = 0;
            this.btnODPromotion3.IsActive = false;
            this.btnODPromotion3.IsAutoScaleWidth = false;
            this.btnODPromotion3.IsVerticalImageText = true;
            this.btnODPromotion3.Location = new System.Drawing.Point(181, 3);
            this.btnODPromotion3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnODPromotion3.Name = "btnODPromotion3";
            this.btnODPromotion3.Size = new System.Drawing.Size(70, 50);
            this.btnODPromotion3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnODPromotion3.TabIndex = 7;
            this.btnODPromotion3.TabStop = false;
            this.btnODPromotion3.TextColor = System.Drawing.Color.White;
            this.btnODPromotion3.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnODPromotion3.TextValue = "Name3";
            this.btnODPromotion3.ToggleGroup = 1;
            this.btnODPromotion3.Type = POS.CustomControl.ButtonType.Click;
            this.btnODPromotion3.Click += new System.EventHandler(this.OnDiscount_ClickedAsync);
            // 
            // btnODPromotion4
            // 
            this.btnODPromotion4.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnODPromotion4.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnODPromotion4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnODPromotion4.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnODPromotion4.BorderRadius = 3;
            this.btnODPromotion4.BorderThick = 3;
            this.btnODPromotion4.ButtonValue = "100";
            this.btnODPromotion4.Image = ((System.Drawing.Image)(resources.GetObject("btnODPromotion4.Image")));
            this.btnODPromotion4.ImageColor = System.Drawing.Color.White;
            this.btnODPromotion4.ImageCss = "percent";
            this.btnODPromotion4.ImageFontSize = 20F;
            this.btnODPromotion4.ImageTextPadding = 0;
            this.btnODPromotion4.IsActive = false;
            this.btnODPromotion4.IsAutoScaleWidth = false;
            this.btnODPromotion4.IsVerticalImageText = true;
            this.btnODPromotion4.Location = new System.Drawing.Point(264, 4);
            this.btnODPromotion4.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnODPromotion4.Name = "btnODPromotion4";
            this.btnODPromotion4.Size = new System.Drawing.Size(70, 50);
            this.btnODPromotion4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnODPromotion4.TabIndex = 7;
            this.btnODPromotion4.TabStop = false;
            this.btnODPromotion4.TextColor = System.Drawing.Color.White;
            this.btnODPromotion4.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnODPromotion4.TextValue = "Name4";
            this.btnODPromotion4.ToggleGroup = 1;
            this.btnODPromotion4.Type = POS.CustomControl.ButtonType.Click;
            this.btnODPromotion4.Click += new System.EventHandler(this.OnDiscount_ClickedAsync);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(501, 65);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(86, 46);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "112";
            // 
            // _extraPanel
            // 
            this._extraPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._extraPanel.ColumnCount = 2;
            this._extraPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._extraPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._extraPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this._extraPanel.Location = new System.Drawing.Point(9, 124);
            this._extraPanel.Name = "_extraPanel";
            this._extraPanel.RowCount = 2;
            this._extraPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._extraPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._extraPanel.Size = new System.Drawing.Size(415, 423);
            this._extraPanel.TabIndex = 10;
            // 
            // btnDecreaseQuantity
            // 
            this.btnDecreaseQuantity.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnDecreaseQuantity.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnDecreaseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecreaseQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnDecreaseQuantity.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnDecreaseQuantity.BorderRadius = 3;
            this.btnDecreaseQuantity.BorderThick = 3;
            this.btnDecreaseQuantity.ButtonValue = "20";
            this.btnDecreaseQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnDecreaseQuantity.Image")));
            this.btnDecreaseQuantity.ImageColor = System.Drawing.Color.Black;
            this.btnDecreaseQuantity.ImageCss = "minus";
            this.btnDecreaseQuantity.ImageFontSize = 25F;
            this.btnDecreaseQuantity.ImageTextPadding = 0;
            this.btnDecreaseQuantity.IsActive = false;
            this.btnDecreaseQuantity.IsAutoScaleWidth = false;
            this.btnDecreaseQuantity.IsVerticalImageText = true;
            this.btnDecreaseQuantity.Location = new System.Drawing.Point(583, 63);
            this.btnDecreaseQuantity.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnDecreaseQuantity.Name = "btnDecreaseQuantity";
            this.btnDecreaseQuantity.Size = new System.Drawing.Size(70, 50);
            this.btnDecreaseQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDecreaseQuantity.TabIndex = 7;
            this.btnDecreaseQuantity.TabStop = false;
            this.btnDecreaseQuantity.TextColor = System.Drawing.Color.Black;
            this.btnDecreaseQuantity.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnDecreaseQuantity.TextValue = "";
            this.btnDecreaseQuantity.ToggleGroup = 0;
            this.btnDecreaseQuantity.Type = POS.CustomControl.ButtonType.Click;
            this.btnDecreaseQuantity.Click += new System.EventHandler(this.btnDecreaseQuantity_Click);
            // 
            // btnIncreaseQuantity
            // 
            this.btnIncreaseQuantity.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnIncreaseQuantity.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnIncreaseQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncreaseQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnIncreaseQuantity.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnIncreaseQuantity.BorderRadius = 3;
            this.btnIncreaseQuantity.BorderThick = 3;
            this.btnIncreaseQuantity.ButtonValue = "20";
            this.btnIncreaseQuantity.Image = ((System.Drawing.Image)(resources.GetObject("btnIncreaseQuantity.Image")));
            this.btnIncreaseQuantity.ImageColor = System.Drawing.Color.Black;
            this.btnIncreaseQuantity.ImageCss = "plus";
            this.btnIncreaseQuantity.ImageFontSize = 25F;
            this.btnIncreaseQuantity.ImageTextPadding = 0;
            this.btnIncreaseQuantity.IsActive = false;
            this.btnIncreaseQuantity.IsAutoScaleWidth = false;
            this.btnIncreaseQuantity.IsVerticalImageText = true;
            this.btnIncreaseQuantity.Location = new System.Drawing.Point(430, 63);
            this.btnIncreaseQuantity.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnIncreaseQuantity.Name = "btnIncreaseQuantity";
            this.btnIncreaseQuantity.Size = new System.Drawing.Size(70, 50);
            this.btnIncreaseQuantity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnIncreaseQuantity.TabIndex = 7;
            this.btnIncreaseQuantity.TabStop = false;
            this.btnIncreaseQuantity.TextColor = System.Drawing.Color.Black;
            this.btnIncreaseQuantity.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnIncreaseQuantity.TextValue = "";
            this.btnIncreaseQuantity.ToggleGroup = 0;
            this.btnIncreaseQuantity.Type = POS.CustomControl.ButtonType.Click;
            this.btnIncreaseQuantity.Click += new System.EventHandler(this.btnIncreaseQuantity_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(505, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số lượng";
            // 
            // lblDiscountOnProduct
            // 
            this.lblDiscountOnProduct.AutoSize = true;
            this.lblDiscountOnProduct.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountOnProduct.Location = new System.Drawing.Point(20, 22);
            this.lblDiscountOnProduct.Name = "lblDiscountOnProduct";
            this.lblDiscountOnProduct.Size = new System.Drawing.Size(213, 21);
            this.lblDiscountOnProduct.TabIndex = 0;
            this.lblDiscountOnProduct.Text = "Giảm giá trên sản phẩm";
            // 
            // btnPromotionRefresh
            // 
            this.btnPromotionRefresh.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPromotionRefresh.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnPromotionRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnPromotionRefresh.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnPromotionRefresh.BorderRadius = 3;
            this.btnPromotionRefresh.BorderThick = 3;
            this.btnPromotionRefresh.ButtonValue = "";
            this.btnPromotionRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnPromotionRefresh.Image")));
            this.btnPromotionRefresh.ImageColor = System.Drawing.Color.White;
            this.btnPromotionRefresh.ImageCss = "refresh";
            this.btnPromotionRefresh.ImageFontSize = 20F;
            this.btnPromotionRefresh.ImageTextPadding = 0;
            this.btnPromotionRefresh.IsActive = false;
            this.btnPromotionRefresh.IsAutoScaleWidth = false;
            this.btnPromotionRefresh.IsVerticalImageText = true;
            this.btnPromotionRefresh.Location = new System.Drawing.Point(354, 3);
            this.btnPromotionRefresh.Name = "btnPromotionRefresh";
            this.btnPromotionRefresh.Size = new System.Drawing.Size(70, 50);
            this.btnPromotionRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPromotionRefresh.TabIndex = 59;
            this.btnPromotionRefresh.TabStop = false;
            this.btnPromotionRefresh.TextColor = System.Drawing.Color.White;
            this.btnPromotionRefresh.TextFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromotionRefresh.TextValue = "Làm mới";
            this.btnPromotionRefresh.ToggleGroup = 0;
            this.btnPromotionRefresh.Type = POS.CustomControl.ButtonType.Click;
            this.btnPromotionRefresh.Click += new System.EventHandler(this.btnPromotionRefresh_Click);
            // 
            // pnlNumPad
            // 
            this.pnlNumPad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNumPad.BackColor = System.Drawing.Color.Transparent;
            this.pnlNumPad.CustomDiscount = null;
            this.pnlNumPad.Location = new System.Drawing.Point(425, 114);
            this.pnlNumPad.Name = "pnlNumPad";
            this.pnlNumPad.Size = new System.Drawing.Size(232, 308);
            this.pnlNumPad.TabIndex = 9;
            this.pnlNumPad.Textbox = null;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Active = true;
            this.txtQuantity.BackColor = System.Drawing.Color.DimGray;
            this.txtQuantity.BackgroundColor = System.Drawing.Color.Empty;
            this.txtQuantity.BorderColor = System.Drawing.Color.Empty;
            this.txtQuantity.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(571, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQuantity.ShowClearButton = true;
            this.txtQuantity.Size = new System.Drawing.Size(82, 45);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.Tag = "";
            this.txtQuantity.TextColor = System.Drawing.Color.Black;
            this.txtQuantity.TextValue = "1";
            this.txtQuantity.Value = "1";
            // 
            // OrderDetailPropetyPanel
            // 
            this.Controls.Add(this.pnlMainContainer);
            this.Name = "OrderDetailPropetyPanel";
            this.Size = new System.Drawing.Size(663, 550);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlMainContainer.PerformLayout();
            this.pnlDiscountControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnODPromotion4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecreaseQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncreaseQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPromotionRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        private BootstrapPanel pnlMainContainer;
        private Label lblDiscountOnProduct;
        private BootstrapButton btnODPromotion3;
        private BootstrapButton btnODPromotion2;
        private Label label2;
        private CustomControl.NumPadPanel pnlNumPad;
        private BootstrapButton btnDecreaseQuantity;
        private BootstrapButton btnIncreaseQuantity;
        private TableLayoutPanel _extraPanel;
        private Label lblQuantity;
        private Common.FlatTextBox txtQuantity;
        private Panel pnlDiscountControls;
        private BootstrapButton btnODPromotion4;
        private BootstrapButton btnODPromotion1;
        private BootstrapButton btnPromotionRefresh;

        #endregion
        //private Panel lblFinish;

        //        private FlowLayoutPanel pnlMainContainer;
        // private FlowLayoutPanel pnlBottomPanel;
    }
}
