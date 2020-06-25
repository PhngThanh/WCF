using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using POS.Properties;
using POS.SaleScreen.CustomControl;

namespace POS.SaleScreen
{
    partial class SaleScreen3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleScreen3));
            this.pnlTop = new POS.CustomControl.BootstrapPanel();
            this.btnAtStoreMode = new POS.CustomControl.BootstrapButton();
            this.btnTakeAwayMode = new POS.CustomControl.BootstrapButton();
            this.btnDeliveryMode = new POS.CustomControl.BootstrapButton();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new POS.CustomControl.BootstrapPanel();
            this.btnScanBarcode = new POS.CustomControl.BootstrapButton();
            this.btnCancelOrder = new POS.CustomControl.BootstrapButton();
            this.btnSplitOrderDetail = new POS.CustomControl.BootstrapButton();
            this.btnChangeTable = new POS.CustomControl.BootstrapButton();
            this.btnStaffInfo = new POS.CustomControl.BootstrapButton();
            this.clockControl1 = new POS.Common.ClockControl();
            this.pnlOrder = new POS.SaleScreen.OrderPanel();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScanBarcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSplitOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStaffInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlTop.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlTop.Controls.Add(this.btnAtStoreMode);
            this.pnlTop.Controls.Add(this.btnTakeAwayMode);
            this.pnlTop.Controls.Add(this.btnDeliveryMode);
            this.pnlTop.Controls.Add(this.ptbLogo);
            this.pnlTop.Location = new System.Drawing.Point(0, 1);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(911, 74);
            this.pnlTop.TabIndex = 4;
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
            this.btnAtStoreMode.ButtonValue = "4";
            this.btnAtStoreMode.Image = ((System.Drawing.Image)(resources.GetObject("btnAtStoreMode.Image")));
            this.btnAtStoreMode.ImageColor = System.Drawing.Color.White;
            this.btnAtStoreMode.ImageCss = "building-o";
            this.btnAtStoreMode.ImageFontSize = 30F;
            this.btnAtStoreMode.ImageTextPadding = 0;
            this.btnAtStoreMode.IsActive = false;
            this.btnAtStoreMode.IsAutoScaleWidth = false;
            this.btnAtStoreMode.IsVerticalImageText = true;
            this.btnAtStoreMode.Location = new System.Drawing.Point(500, -1);
            this.btnAtStoreMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnAtStoreMode.Name = "btnAtStoreMode";
            this.btnAtStoreMode.Size = new System.Drawing.Size(135, 75);
            this.btnAtStoreMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAtStoreMode.TabIndex = 2;
            this.btnAtStoreMode.TabStop = false;
            this.btnAtStoreMode.TextColor = System.Drawing.Color.White;
            this.btnAtStoreMode.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAtStoreMode.TextValue = "Tại quán";
            this.btnAtStoreMode.ToggleGroup = 1;
            this.btnAtStoreMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAtStoreMode.Visible = false;
            this.btnAtStoreMode.Click += new System.EventHandler(this.OrderType_Clicked);
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
            this.btnTakeAwayMode.ButtonValue = "5";
            this.btnTakeAwayMode.Image = ((System.Drawing.Image)(resources.GetObject("btnTakeAwayMode.Image")));
            this.btnTakeAwayMode.ImageColor = System.Drawing.Color.White;
            this.btnTakeAwayMode.ImageCss = "hand-o-right";
            this.btnTakeAwayMode.ImageFontSize = 30F;
            this.btnTakeAwayMode.ImageTextPadding = 0;
            this.btnTakeAwayMode.IsActive = false;
            this.btnTakeAwayMode.IsAutoScaleWidth = false;
            this.btnTakeAwayMode.IsVerticalImageText = true;
            this.btnTakeAwayMode.Location = new System.Drawing.Point(639, -1);
            this.btnTakeAwayMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnTakeAwayMode.Name = "btnTakeAwayMode";
            this.btnTakeAwayMode.Size = new System.Drawing.Size(135, 75);
            this.btnTakeAwayMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnTakeAwayMode.TabIndex = 3;
            this.btnTakeAwayMode.TabStop = false;
            this.btnTakeAwayMode.TextColor = System.Drawing.Color.White;
            this.btnTakeAwayMode.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnTakeAwayMode.TextValue = "Mang về";
            this.btnTakeAwayMode.ToggleGroup = 1;
            this.btnTakeAwayMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnTakeAwayMode.Visible = false;
            this.btnTakeAwayMode.Click += new System.EventHandler(this.OrderType_Clicked);
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
            this.btnDeliveryMode.ButtonValue = "6";
            this.btnDeliveryMode.Image = ((System.Drawing.Image)(resources.GetObject("btnDeliveryMode.Image")));
            this.btnDeliveryMode.ImageColor = System.Drawing.Color.White;
            this.btnDeliveryMode.ImageCss = "truck";
            this.btnDeliveryMode.ImageFontSize = 30F;
            this.btnDeliveryMode.ImageTextPadding = 0;
            this.btnDeliveryMode.IsActive = false;
            this.btnDeliveryMode.IsAutoScaleWidth = false;
            this.btnDeliveryMode.IsVerticalImageText = true;
            this.btnDeliveryMode.Location = new System.Drawing.Point(776, -1);
            this.btnDeliveryMode.Margin = new System.Windows.Forms.Padding(1);
            this.btnDeliveryMode.Name = "btnDeliveryMode";
            this.btnDeliveryMode.Size = new System.Drawing.Size(135, 75);
            this.btnDeliveryMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDeliveryMode.TabIndex = 4;
            this.btnDeliveryMode.TabStop = false;
            this.btnDeliveryMode.TextColor = System.Drawing.Color.White;
            this.btnDeliveryMode.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeliveryMode.TextValue = "Giao hàng";
            this.btnDeliveryMode.ToggleGroup = 1;
            this.btnDeliveryMode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnDeliveryMode.Visible = false;
            this.btnDeliveryMode.Click += new System.EventHandler(this.OrderType_Clicked);
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "./Resources/logo_simple_passio.png";
            this.ptbLogo.Location = new System.Drawing.Point(2, 9);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlBottom.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlBottom.Controls.Add(this.btnScanBarcode);
            this.pnlBottom.Controls.Add(this.btnCancelOrder);
            this.pnlBottom.Controls.Add(this.btnSplitOrderDetail);
            this.pnlBottom.Controls.Add(this.btnChangeTable);
            this.pnlBottom.Controls.Add(this.btnStaffInfo);
            this.pnlBottom.Controls.Add(this.clockControl1);
            this.pnlBottom.Location = new System.Drawing.Point(0, 618);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1359, 89);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnScanBarcode
            // 
            this.btnScanBarcode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnScanBarcode.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnScanBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnScanBarcode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnScanBarcode.BorderRadius = 3;
            this.btnScanBarcode.BorderThick = 3;
            this.btnScanBarcode.ButtonValue = "4";
            this.btnScanBarcode.Image = ((System.Drawing.Image)(resources.GetObject("btnScanBarcode.Image")));
            this.btnScanBarcode.ImageColor = System.Drawing.Color.White;
            this.btnScanBarcode.ImageCss = "barcode";
            this.btnScanBarcode.ImageFontSize = 30F;
            this.btnScanBarcode.ImageTextPadding = 0;
            this.btnScanBarcode.IsActive = false;
            this.btnScanBarcode.IsAutoScaleWidth = false;
            this.btnScanBarcode.IsVerticalImageText = true;
            this.btnScanBarcode.Location = new System.Drawing.Point(475, 12);
            this.btnScanBarcode.Margin = new System.Windows.Forms.Padding(1);
            this.btnScanBarcode.Name = "btnScanBarcode";
            this.btnScanBarcode.Size = new System.Drawing.Size(160, 75);
            this.btnScanBarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnScanBarcode.TabIndex = 7;
            this.btnScanBarcode.TabStop = false;
            this.btnScanBarcode.TextColor = System.Drawing.Color.White;
            this.btnScanBarcode.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnScanBarcode.TextValue = "Quét Barcode";
            this.btnScanBarcode.ToggleGroup = 1;
            this.btnScanBarcode.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnScanBarcode.Click += new System.EventHandler(this.btnScanBarcode_Click_1);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnCancelOrder.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnCancelOrder.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.btnCancelOrder.BorderRadius = 3;
            this.btnCancelOrder.BorderThick = 3;
            this.btnCancelOrder.ButtonValue = "";
            this.btnCancelOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelOrder.Image")));
            this.btnCancelOrder.ImageColor = System.Drawing.Color.White;
            this.btnCancelOrder.ImageCss = "close";
            this.btnCancelOrder.ImageFontSize = 30F;
            this.btnCancelOrder.ImageTextPadding = 0;
            this.btnCancelOrder.IsActive = false;
            this.btnCancelOrder.IsAutoScaleWidth = false;
            this.btnCancelOrder.IsVerticalImageText = true;
            this.btnCancelOrder.Location = new System.Drawing.Point(277, 1);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(173, 87);
            this.btnCancelOrder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelOrder.TabIndex = 6;
            this.btnCancelOrder.TabStop = false;
            this.btnCancelOrder.TextColor = System.Drawing.Color.White;
            this.btnCancelOrder.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.TextValue = "Hủy hóa đơn";
            this.btnCancelOrder.ToggleGroup = 0;
            this.btnCancelOrder.Type = POS.CustomControl.ButtonType.Click;
            this.btnCancelOrder.Visible = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnSplitOrderDetail
            // 
            this.btnSplitOrderDetail.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnSplitOrderDetail.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnSplitOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSplitOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnSplitOrderDetail.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnSplitOrderDetail.BorderRadius = 3;
            this.btnSplitOrderDetail.BorderThick = 3;
            this.btnSplitOrderDetail.ButtonValue = "";
            this.btnSplitOrderDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnSplitOrderDetail.Image")));
            this.btnSplitOrderDetail.ImageColor = System.Drawing.Color.White;
            this.btnSplitOrderDetail.ImageCss = "random";
            this.btnSplitOrderDetail.ImageFontSize = 30F;
            this.btnSplitOrderDetail.ImageTextPadding = 0;
            this.btnSplitOrderDetail.IsActive = false;
            this.btnSplitOrderDetail.IsAutoScaleWidth = false;
            this.btnSplitOrderDetail.IsVerticalImageText = true;
            this.btnSplitOrderDetail.Location = new System.Drawing.Point(649, 1);
            this.btnSplitOrderDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnSplitOrderDetail.Name = "btnSplitOrderDetail";
            this.btnSplitOrderDetail.Size = new System.Drawing.Size(173, 87);
            this.btnSplitOrderDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSplitOrderDetail.TabIndex = 6;
            this.btnSplitOrderDetail.TabStop = false;
            this.btnSplitOrderDetail.TextColor = System.Drawing.Color.White;
            this.btnSplitOrderDetail.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnSplitOrderDetail.TextValue = "Tách hóa đơn";
            this.btnSplitOrderDetail.ToggleGroup = 0;
            this.btnSplitOrderDetail.Type = POS.CustomControl.ButtonType.Click;
            this.btnSplitOrderDetail.Visible = false;
            this.btnSplitOrderDetail.Click += new System.EventHandler(this.btnSplitOrderDetail_Click);
            // 
            // btnChangeTable
            // 
            this.btnChangeTable.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnChangeTable.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnChangeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnChangeTable.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnChangeTable.BorderRadius = 3;
            this.btnChangeTable.BorderThick = 3;
            this.btnChangeTable.ButtonValue = "";
            this.btnChangeTable.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeTable.Image")));
            this.btnChangeTable.ImageColor = System.Drawing.Color.White;
            this.btnChangeTable.ImageCss = "exchange";
            this.btnChangeTable.ImageFontSize = 30F;
            this.btnChangeTable.ImageTextPadding = 0;
            this.btnChangeTable.IsActive = false;
            this.btnChangeTable.IsAutoScaleWidth = false;
            this.btnChangeTable.IsVerticalImageText = true;
            this.btnChangeTable.Location = new System.Drawing.Point(468, 1);
            this.btnChangeTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeTable.Name = "btnChangeTable";
            this.btnChangeTable.Size = new System.Drawing.Size(173, 87);
            this.btnChangeTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnChangeTable.TabIndex = 6;
            this.btnChangeTable.TabStop = false;
            this.btnChangeTable.TextColor = System.Drawing.Color.White;
            this.btnChangeTable.TextFont = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.btnChangeTable.TextValue = "Chuyển bàn";
            this.btnChangeTable.ToggleGroup = 0;
            this.btnChangeTable.Type = POS.CustomControl.ButtonType.Click;
            this.btnChangeTable.Visible = false;
            this.btnChangeTable.Click += new System.EventHandler(this.btnChangeTable_Click);
            // 
            // btnStaffInfo
            // 
            this.btnStaffInfo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnStaffInfo.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnStaffInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnStaffInfo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnStaffInfo.BorderRadius = 3;
            this.btnStaffInfo.BorderThick = 0;
            this.btnStaffInfo.ButtonValue = "";
            this.btnStaffInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnStaffInfo.Image")));
            this.btnStaffInfo.ImageColor = System.Drawing.Color.White;
            this.btnStaffInfo.ImageCss = "user";
            this.btnStaffInfo.ImageFontSize = 20F;
            this.btnStaffInfo.ImageTextPadding = 0;
            this.btnStaffInfo.IsActive = false;
            this.btnStaffInfo.IsAutoScaleWidth = false;
            this.btnStaffInfo.IsVerticalImageText = false;
            this.btnStaffInfo.Location = new System.Drawing.Point(0, 1);
            this.btnStaffInfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnStaffInfo.Name = "btnStaffInfo";
            this.btnStaffInfo.Size = new System.Drawing.Size(269, 33);
            this.btnStaffInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnStaffInfo.TabIndex = 4;
            this.btnStaffInfo.TabStop = false;
            this.btnStaffInfo.TextColor = System.Drawing.Color.White;
            this.btnStaffInfo.TextFont = new System.Drawing.Font("Tahoma", 13F);
            this.btnStaffInfo.TextValue = "Đoàn Thanh Duy";
            this.btnStaffInfo.ToggleGroup = 0;
            this.btnStaffInfo.Type = POS.CustomControl.ButtonType.Click;
            // 
            // clockControl1
            // 
            this.clockControl1.BackColor = System.Drawing.Color.Transparent;
            this.clockControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.clockControl1.Location = new System.Drawing.Point(1, 41);
            this.clockControl1.Margin = new System.Windows.Forms.Padding(4);
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.Size = new System.Drawing.Size(272, 71);
            this.clockControl1.TabIndex = 0;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.Gray;
            this.pnlOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlOrder.Location = new System.Drawing.Point(919, 4);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(440, 703);
            this.pnlOrder.TabIndex = 2;
            this.pnlOrder.TableNo = "";
            // 
            // SaleScreen3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleScreen3";
            this.Size = new System.Drawing.Size(1365, 710);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAtStoreMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeAwayMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeliveryMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnScanBarcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSplitOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStaffInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public CategoryPanel1 pnlCategory;
        public OrderPanel pnlOrder;
        private POS.CustomControl.BootstrapPanel pnlTop;
        private PictureBox ptbLogo;
        private POS.CustomControl.BootstrapPanel pnlBottom;
        private POS.CustomControl.BootstrapButton btnStaffInfo;
        private Common.ClockControl clockControl1;
        private POS.CustomControl.BootstrapButton btnCancelOrder;
        private POS.CustomControl.BootstrapButton btnChangeTable;
        private POS.CustomControl.BootstrapButton btnSplitOrderDetail;
        private POS.CustomControl.BootstrapButton btnAtStoreMode;
        private POS.CustomControl.BootstrapButton btnTakeAwayMode;
        private POS.CustomControl.BootstrapButton btnDeliveryMode;
        private POS.CustomControl.BootstrapButton btnScanBarcode;
    }
}
