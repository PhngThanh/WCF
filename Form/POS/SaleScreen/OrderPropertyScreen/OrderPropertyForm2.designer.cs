using System.ComponentModel;
using System.Windows.Forms;
using POS.Common;
using POS.SaleScreen.CustomControl;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class OrderPropertyForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPropertyForm2));
            this.btnRefreshAllTab = new POS.CustomControl.BootstrapButton();
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.lblInNeed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlNote = new POS.CustomControl.BootstrapPanel();
            this.bsbtnCloseNote = new POS.CustomControl.BootstrapButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDiscout = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblReceived = new System.Windows.Forms.Label();
            this.bootstrapButton9 = new POS.CustomControl.BootstrapButton();
            this.lblExchange = new System.Windows.Forms.Label();
            this.lblVATAmount = new System.Windows.Forms.Label();
            this.lblAfterDiscount = new System.Windows.Forms.Label();
            this.lblFinalAmount = new System.Windows.Forms.Label();
            this.lblTotalDiscount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.pnlInformation = new POS.CustomControl.BootstrapPanel();
            this.pnlContainer = new POS.CustomControl.BootstrapPanel();
            this.pnlHeader = new POS.CustomControl.BootstrapPanel();
            this.lblPoint = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.Label();
            this.txtAvailPromo = new System.Windows.Forms.Label();
            this.bsBtnServedStaff = new POS.CustomControl.BootstrapButton();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblOrderCode = new System.Windows.Forms.Label();
            this.lblNoti = new System.Windows.Forms.Label();
            this.btnAddVAT = new POS.CustomControl.BootstrapButton();
            this.btnDecreaseVAT = new POS.CustomControl.BootstrapButton();
            this.pnlBottomPanel = new POS.CustomControl.BootstrapPanel();
            this.btnPrintMomo = new POS.CustomControl.BootstrapButton();
            this.BtnMomoPay = new POS.CustomControl.BootstrapButton();
            this.btnCheckMomo = new POS.CustomControl.BootstrapButton();
            this.lblCheckinDate = new System.Windows.Forms.Label();
            this.btnPrintCook = new POS.CustomControl.BootstrapButton();
            this.btnPrintReceipt = new POS.CustomControl.BootstrapButton();
            this.btnHide = new POS.CustomControl.BootstrapButton();
            this.btnFinish = new POS.CustomControl.BootstrapButton();
            this.btnListMembershipType = new POS.CustomControl.BootstrapButton();
            this.barTop = new POS.SaleScreen.CustomControl.CategoryBar();
            this.btnPreview = new POS.CustomControl.BootstrapButton();
            this.bsBtnOrderNotes = new POS.CustomControl.BootstrapButton();
            this.btnPaymentInfo = new POS.CustomControl.BootstrapButton();
            this.btnPromotionInfo = new POS.CustomControl.BootstrapButton();
            this.btnCustomerInfo = new POS.CustomControl.BootstrapButton();
            this.txtOrderNotes = new POS.Common.LoginFlatTextBox();
            this.txtServedStaff = new POS.Common.RoundTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshAllTab)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsbtnCloseNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton9)).BeginInit();
            this.pnlInformation.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnServedStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecreaseVAT)).BeginInit();
            this.pnlBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMomo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMomoPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckMomo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintCook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnListMembershipType)).BeginInit();
            this.barTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnOrderNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaymentInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPromotionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshAllTab
            // 
            this.btnRefreshAllTab.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnRefreshAllTab.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnRefreshAllTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnRefreshAllTab.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnRefreshAllTab.BorderRadius = 3;
            this.btnRefreshAllTab.BorderThick = 3;
            this.btnRefreshAllTab.ButtonValue = "";
            this.btnRefreshAllTab.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshAllTab.Image")));
            this.btnRefreshAllTab.ImageColor = System.Drawing.Color.White;
            this.btnRefreshAllTab.ImageCss = "refresh";
            this.btnRefreshAllTab.ImageFontSize = 25F;
            this.btnRefreshAllTab.ImageTextPadding = 0;
            this.btnRefreshAllTab.IsActive = false;
            this.btnRefreshAllTab.IsAutoScaleWidth = false;
            this.btnRefreshAllTab.IsVerticalImageText = false;
            this.btnRefreshAllTab.Location = new System.Drawing.Point(816, 4);
            this.btnRefreshAllTab.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshAllTab.Name = "btnRefreshAllTab";
            this.btnRefreshAllTab.Size = new System.Drawing.Size(173, 81);
            this.btnRefreshAllTab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRefreshAllTab.TabIndex = 17;
            this.btnRefreshAllTab.TabStop = false;
            this.btnRefreshAllTab.TextColor = System.Drawing.Color.White;
            this.btnRefreshAllTab.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefreshAllTab.TextValue = "Làm mới";
            this.btnRefreshAllTab.ToggleGroup = 1;
            this.btnRefreshAllTab.Type = POS.CustomControl.ButtonType.Click;
            this.btnRefreshAllTab.Click += new System.EventHandler(this.btnRefreshAllTab_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlMain.Controls.Add(this.lblInNeed);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.pnlNote);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.lblDiscout);
            this.pnlMain.Controls.Add(this.lblTotal);
            this.pnlMain.Controls.Add(this.lblReceived);
            this.pnlMain.Controls.Add(this.bootstrapButton9);
            this.pnlMain.Controls.Add(this.lblExchange);
            this.pnlMain.Controls.Add(this.lblVATAmount);
            this.pnlMain.Controls.Add(this.lblAfterDiscount);
            this.pnlMain.Controls.Add(this.lblFinalAmount);
            this.pnlMain.Controls.Add(this.lblTotalDiscount);
            this.pnlMain.Controls.Add(this.lblTotalAmount);
            this.pnlMain.Controls.Add(this.pnlInformation);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.btnAddVAT);
            this.pnlMain.Controls.Add(this.btnDecreaseVAT);
            this.pnlMain.Location = new System.Drawing.Point(5, 4);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1355, 762);
            this.pnlMain.TabIndex = 2;
            // 
            // lblInNeed
            // 
            this.lblInNeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInNeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblInNeed.ForeColor = System.Drawing.Color.White;
            this.lblInNeed.Location = new System.Drawing.Point(1077, 609);
            this.lblInNeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInNeed.Name = "lblInNeed";
            this.lblInNeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInNeed.Size = new System.Drawing.Size(263, 48);
            this.lblInNeed.TabIndex = 32;
            this.lblInNeed.Text = "10.000.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(993, 591);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Thiếu";
            // 
            // pnlNote
            // 
            this.pnlNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlNote.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNote.Controls.Add(this.bsbtnCloseNote);
            this.pnlNote.Controls.Add(this.txtOrderNotes);
            this.pnlNote.Location = new System.Drawing.Point(249, 236);
            this.pnlNote.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNote.Name = "pnlNote";
            this.pnlNote.Size = new System.Drawing.Size(926, 205);
            this.pnlNote.TabIndex = 18;
            // 
            // bsbtnCloseNote
            // 
            this.bsbtnCloseNote.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.bsbtnCloseNote.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.bsbtnCloseNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.bsbtnCloseNote.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.bsbtnCloseNote.BorderRadius = 0;
            this.bsbtnCloseNote.BorderThick = 0;
            this.bsbtnCloseNote.ButtonValue = "";
            this.bsbtnCloseNote.Image = ((System.Drawing.Image)(resources.GetObject("bsbtnCloseNote.Image")));
            this.bsbtnCloseNote.ImageColor = System.Drawing.Color.Black;
            this.bsbtnCloseNote.ImageCss = "close";
            this.bsbtnCloseNote.ImageFontSize = 25F;
            this.bsbtnCloseNote.ImageTextPadding = 0;
            this.bsbtnCloseNote.IsActive = false;
            this.bsbtnCloseNote.IsAutoScaleWidth = false;
            this.bsbtnCloseNote.IsVerticalImageText = false;
            this.bsbtnCloseNote.Location = new System.Drawing.Point(721, 145);
            this.bsbtnCloseNote.Margin = new System.Windows.Forms.Padding(4);
            this.bsbtnCloseNote.Name = "bsbtnCloseNote";
            this.bsbtnCloseNote.Size = new System.Drawing.Size(184, 55);
            this.bsbtnCloseNote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bsbtnCloseNote.TabIndex = 16;
            this.bsbtnCloseNote.TabStop = false;
            this.bsbtnCloseNote.TextColor = System.Drawing.Color.Black;
            this.bsbtnCloseNote.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bsbtnCloseNote.TextValue = "Đóng";
            this.bsbtnCloseNote.ToggleGroup = 0;
            this.bsbtnCloseNote.Type = POS.CustomControl.ButtonType.Click;
            this.bsbtnCloseNote.Click += new System.EventHandler(this.bsbtnCloseNote_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(993, 665);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Trả lại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(993, 517);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Khách đưa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(993, 443);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 28;
            this.label3.Text = "Thành tiền";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(993, 334);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Còn lại";
            // 
            // lblDiscout
            // 
            this.lblDiscout.AutoSize = true;
            this.lblDiscout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscout.ForeColor = System.Drawing.Color.White;
            this.lblDiscout.Location = new System.Drawing.Point(993, 276);
            this.lblDiscout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiscout.Name = "lblDiscout";
            this.lblDiscout.Size = new System.Drawing.Size(94, 23);
            this.lblDiscout.TabIndex = 28;
            this.lblDiscout.Text = "Giảm giá";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(993, 214);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(110, 23);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "Tổng cộng";
            // 
            // lblReceived
            // 
            this.lblReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.lblReceived.ForeColor = System.Drawing.Color.White;
            this.lblReceived.Location = new System.Drawing.Point(1077, 535);
            this.lblReceived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReceived.Name = "lblReceived";
            this.lblReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblReceived.Size = new System.Drawing.Size(263, 48);
            this.lblReceived.TabIndex = 27;
            this.lblReceived.Text = "10.000.000";
            // 
            // bootstrapButton9
            // 
            this.bootstrapButton9.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton9.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bootstrapButton9.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.StripColor;
            this.bootstrapButton9.BorderRadius = 0;
            this.bootstrapButton9.BorderThick = 0;
            this.bootstrapButton9.ButtonValue = "";
            this.bootstrapButton9.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton9.Image")));
            this.bootstrapButton9.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton9.ImageCss = "dollar";
            this.bootstrapButton9.ImageFontSize = 25F;
            this.bootstrapButton9.ImageTextPadding = 0;
            this.bootstrapButton9.IsActive = false;
            this.bootstrapButton9.IsAutoScaleWidth = false;
            this.bootstrapButton9.IsVerticalImageText = false;
            this.bootstrapButton9.Location = new System.Drawing.Point(977, 132);
            this.bootstrapButton9.Margin = new System.Windows.Forms.Padding(3, 4, 1, 4);
            this.bootstrapButton9.Name = "bootstrapButton9";
            this.bootstrapButton9.Size = new System.Drawing.Size(369, 53);
            this.bootstrapButton9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton9.TabIndex = 12;
            this.bootstrapButton9.TabStop = false;
            this.bootstrapButton9.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton9.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton9.TextValue = "Thông tin thanh toán:  ";
            this.bootstrapButton9.ToggleGroup = 0;
            this.bootstrapButton9.Type = POS.CustomControl.ButtonType.Click;
            // 
            // lblExchange
            // 
            this.lblExchange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.lblExchange.ForeColor = System.Drawing.Color.White;
            this.lblExchange.Location = new System.Drawing.Point(1088, 702);
            this.lblExchange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(283, 48);
            this.lblExchange.TabIndex = 26;
            this.lblExchange.Text = "-10.000.000";
            // 
            // lblVATAmount
            // 
            this.lblVATAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVATAmount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVATAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblVATAmount.ForeColor = System.Drawing.Color.White;
            this.lblVATAmount.Location = new System.Drawing.Point(1176, 382);
            this.lblVATAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVATAmount.Name = "lblVATAmount";
            this.lblVATAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblVATAmount.Size = new System.Drawing.Size(173, 32);
            this.lblVATAmount.TabIndex = 24;
            this.lblVATAmount.Text = "10.000.000";
            // 
            // lblAfterDiscount
            // 
            this.lblAfterDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAfterDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblAfterDiscount.ForeColor = System.Drawing.Color.White;
            this.lblAfterDiscount.Location = new System.Drawing.Point(1176, 324);
            this.lblAfterDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAfterDiscount.Name = "lblAfterDiscount";
            this.lblAfterDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAfterDiscount.Size = new System.Drawing.Size(173, 32);
            this.lblAfterDiscount.TabIndex = 23;
            this.lblAfterDiscount.Text = "10.000.000";
            // 
            // lblFinalAmount
            // 
            this.lblFinalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.lblFinalAmount.ForeColor = System.Drawing.Color.White;
            this.lblFinalAmount.Location = new System.Drawing.Point(1077, 462);
            this.lblFinalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFinalAmount.Name = "lblFinalAmount";
            this.lblFinalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFinalAmount.Size = new System.Drawing.Size(263, 48);
            this.lblFinalAmount.TabIndex = 22;
            this.lblFinalAmount.Text = "10.000.000";
            // 
            // lblTotalDiscount
            // 
            this.lblTotalDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiscount.ForeColor = System.Drawing.Color.White;
            this.lblTotalDiscount.Location = new System.Drawing.Point(1176, 266);
            this.lblTotalDiscount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDiscount.Name = "lblTotalDiscount";
            this.lblTotalDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalDiscount.Size = new System.Drawing.Size(173, 32);
            this.lblTotalDiscount.TabIndex = 21;
            this.lblTotalDiscount.Text = "10.000.000";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(1165, 204);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalAmount.Size = new System.Drawing.Size(185, 36);
            this.lblTotalAmount.TabIndex = 20;
            this.lblTotalAmount.Text = "10.000.000";
            // 
            // pnlInformation
            // 
            this.pnlInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlInformation.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.StripColor;
            this.pnlInformation.Controls.Add(this.pnlContainer);
            this.pnlInformation.Location = new System.Drawing.Point(1, 68);
            this.pnlInformation.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(969, 695);
            this.pnlInformation.TabIndex = 1;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.pnlContainer.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.pnlContainer.Location = new System.Drawing.Point(0, 58);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(961, 638);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlHeader.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlHeader.Controls.Add(this.lblPoint);
            this.pnlHeader.Controls.Add(this.txtPoint);
            this.pnlHeader.Controls.Add(this.lblMoney);
            this.pnlHeader.Controls.Add(this.txtMoney);
            this.pnlHeader.Controls.Add(this.txtAvailPromo);
            this.pnlHeader.Controls.Add(this.bsBtnServedStaff);
            this.pnlHeader.Controls.Add(this.txtServedStaff);
            this.pnlHeader.Controls.Add(this.lblTable);
            this.pnlHeader.Controls.Add(this.lblOrderCode);
            this.pnlHeader.Controls.Add(this.lblNoti);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1355, 66);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblPoint
            // 
            this.lblPoint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPoint.AutoSize = true;
            this.lblPoint.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint.ForeColor = System.Drawing.Color.White;
            this.lblPoint.Location = new System.Drawing.Point(328, 38);
            this.lblPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(67, 23);
            this.lblPoint.TabIndex = 30;
            this.lblPoint.Text = "Điểm:";
            this.lblPoint.Visible = false;
            // 
            // txtPoint
            // 
            this.txtPoint.AutoSize = true;
            this.txtPoint.Font = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint.ForeColor = System.Drawing.Color.White;
            this.txtPoint.Location = new System.Drawing.Point(405, 37);
            this.txtPoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(94, 24);
            this.txtPoint.TabIndex = 29;
            this.txtPoint.Text = "100.000";
            this.txtPoint.Visible = false;
            // 
            // lblMoney
            // 
            this.lblMoney.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMoney.AutoSize = true;
            this.lblMoney.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.ForeColor = System.Drawing.Color.White;
            this.lblMoney.Location = new System.Drawing.Point(328, 7);
            this.lblMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(58, 23);
            this.lblMoney.TabIndex = 1;
            this.lblMoney.Text = "Tiền:";
            this.lblMoney.Visible = false;
            // 
            // txtMoney
            // 
            this.txtMoney.AutoSize = true;
            this.txtMoney.Font = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoney.ForeColor = System.Drawing.Color.White;
            this.txtMoney.Location = new System.Drawing.Point(405, 7);
            this.txtMoney.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(94, 24);
            this.txtMoney.TabIndex = 0;
            this.txtMoney.Text = "100.000";
            this.txtMoney.Visible = false;
            // 
            // txtAvailPromo
            // 
            this.txtAvailPromo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAvailPromo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtAvailPromo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAvailPromo.ForeColor = System.Drawing.Color.White;
            this.txtAvailPromo.Location = new System.Drawing.Point(639, 4);
            this.txtAvailPromo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAvailPromo.Name = "txtAvailPromo";
            this.txtAvailPromo.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtAvailPromo.Size = new System.Drawing.Size(287, 57);
            this.txtAvailPromo.TabIndex = 32;
            this.txtAvailPromo.Text = "Các khuyến mãi cho thẻ: \r\n +CreditCard-10%, +CreditCard-10%, +CreditCard-10%, +Cr" +
    "editCard-10%, ";
            this.txtAvailPromo.Visible = false;
            // 
            // bsBtnServedStaff
            // 
            this.bsBtnServedStaff.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bsBtnServedStaff.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bsBtnServedStaff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.bsBtnServedStaff.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.bsBtnServedStaff.BorderRadius = 0;
            this.bsBtnServedStaff.BorderThick = 0;
            this.bsBtnServedStaff.ButtonValue = "";
            this.bsBtnServedStaff.Image = ((System.Drawing.Image)(resources.GetObject("bsBtnServedStaff.Image")));
            this.bsBtnServedStaff.ImageColor = System.Drawing.Color.White;
            this.bsBtnServedStaff.ImageCss = "street-view";
            this.bsBtnServedStaff.ImageFontSize = 25F;
            this.bsBtnServedStaff.ImageTextPadding = 0;
            this.bsBtnServedStaff.IsActive = false;
            this.bsBtnServedStaff.IsAutoScaleWidth = false;
            this.bsBtnServedStaff.IsVerticalImageText = false;
            this.bsBtnServedStaff.Location = new System.Drawing.Point(972, 4);
            this.bsBtnServedStaff.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.bsBtnServedStaff.Name = "bsBtnServedStaff";
            this.bsBtnServedStaff.Size = new System.Drawing.Size(53, 57);
            this.bsBtnServedStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bsBtnServedStaff.TabIndex = 28;
            this.bsBtnServedStaff.TabStop = false;
            this.bsBtnServedStaff.TextColor = System.Drawing.Color.Black;
            this.bsBtnServedStaff.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bsBtnServedStaff.TextValue = "";
            this.bsBtnServedStaff.ToggleGroup = 0;
            this.bsBtnServedStaff.Type = POS.CustomControl.ButtonType.Click;
            // 
            // lblTable
            // 
            this.lblTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(13, 2);
            this.lblTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(111, 29);
            this.lblTable.TabIndex = 1;
            this.lblTable.Text = "Bàn : 27";
            // 
            // lblOrderCode
            // 
            this.lblOrderCode.AutoSize = true;
            this.lblOrderCode.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCode.ForeColor = System.Drawing.Color.White;
            this.lblOrderCode.Location = new System.Drawing.Point(13, 33);
            this.lblOrderCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrderCode.Name = "lblOrderCode";
            this.lblOrderCode.Size = new System.Drawing.Size(257, 29);
            this.lblOrderCode.TabIndex = 0;
            this.lblOrderCode.Text = "TEST-36-AS-35ylknz";
            // 
            // lblNoti
            // 
            this.lblNoti.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNoti.AutoSize = true;
            this.lblNoti.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoti.ForeColor = System.Drawing.Color.White;
            this.lblNoti.Location = new System.Drawing.Point(315, 20);
            this.lblNoti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoti.Name = "lblNoti";
            this.lblNoti.Size = new System.Drawing.Size(350, 29);
            this.lblNoti.TabIndex = 31;
            this.lblNoti.Text = "Đang tìm kiếm thông tin thẻ";
            this.lblNoti.Visible = false;
            // 
            // btnAddVAT
            // 
            this.btnAddVAT.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnAddVAT.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnAddVAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnAddVAT.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnAddVAT.BorderRadius = 3;
            this.btnAddVAT.BorderThick = 3;
            this.btnAddVAT.ButtonValue = "";
            this.btnAddVAT.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVAT.Image")));
            this.btnAddVAT.ImageColor = System.Drawing.Color.White;
            this.btnAddVAT.ImageCss = "plus-square-o";
            this.btnAddVAT.ImageFontSize = 19F;
            this.btnAddVAT.ImageTextPadding = 0;
            this.btnAddVAT.IsActive = false;
            this.btnAddVAT.IsAutoScaleWidth = false;
            this.btnAddVAT.IsVerticalImageText = false;
            this.btnAddVAT.Location = new System.Drawing.Point(997, 382);
            this.btnAddVAT.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddVAT.Name = "btnAddVAT";
            this.btnAddVAT.Size = new System.Drawing.Size(111, 32);
            this.btnAddVAT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAddVAT.TabIndex = 16;
            this.btnAddVAT.TabStop = false;
            this.btnAddVAT.TextColor = System.Drawing.Color.White;
            this.btnAddVAT.TextFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddVAT.TextValue = "VAT";
            this.btnAddVAT.ToggleGroup = 1;
            this.btnAddVAT.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnAddVAT.Click += new System.EventHandler(this.btnVAT_Click);
            // 
            // btnDecreaseVAT
            // 
            this.btnDecreaseVAT.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnDecreaseVAT.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnDecreaseVAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnDecreaseVAT.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnDecreaseVAT.BorderRadius = 3;
            this.btnDecreaseVAT.BorderThick = 3;
            this.btnDecreaseVAT.ButtonValue = "";
            this.btnDecreaseVAT.Image = ((System.Drawing.Image)(resources.GetObject("btnDecreaseVAT.Image")));
            this.btnDecreaseVAT.ImageColor = System.Drawing.Color.White;
            this.btnDecreaseVAT.ImageCss = "minus-square-o";
            this.btnDecreaseVAT.ImageFontSize = 19F;
            this.btnDecreaseVAT.ImageTextPadding = 0;
            this.btnDecreaseVAT.IsActive = false;
            this.btnDecreaseVAT.IsAutoScaleWidth = false;
            this.btnDecreaseVAT.IsVerticalImageText = false;
            this.btnDecreaseVAT.Location = new System.Drawing.Point(997, 382);
            this.btnDecreaseVAT.Margin = new System.Windows.Forms.Padding(0);
            this.btnDecreaseVAT.Name = "btnDecreaseVAT";
            this.btnDecreaseVAT.Size = new System.Drawing.Size(111, 32);
            this.btnDecreaseVAT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnDecreaseVAT.TabIndex = 29;
            this.btnDecreaseVAT.TabStop = false;
            this.btnDecreaseVAT.TextColor = System.Drawing.Color.White;
            this.btnDecreaseVAT.TextFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnDecreaseVAT.TextValue = "VAT";
            this.btnDecreaseVAT.ToggleGroup = 1;
            this.btnDecreaseVAT.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnDecreaseVAT.Click += new System.EventHandler(this.btnVAT_Click);
            // 
            // pnlBottomPanel
            // 
            this.pnlBottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlBottomPanel.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlBottomPanel.Controls.Add(this.btnPrintMomo);
            this.pnlBottomPanel.Controls.Add(this.BtnMomoPay);
            this.pnlBottomPanel.Controls.Add(this.btnCheckMomo);
            this.pnlBottomPanel.Controls.Add(this.btnRefreshAllTab);
            this.pnlBottomPanel.Controls.Add(this.lblCheckinDate);
            this.pnlBottomPanel.Controls.Add(this.btnPrintCook);
            this.pnlBottomPanel.Controls.Add(this.btnPrintReceipt);
            this.pnlBottomPanel.Controls.Add(this.btnHide);
            this.pnlBottomPanel.Controls.Add(this.btnFinish);
            this.pnlBottomPanel.Location = new System.Drawing.Point(5, 773);
            this.pnlBottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottomPanel.Name = "pnlBottomPanel";
            this.pnlBottomPanel.Size = new System.Drawing.Size(1355, 89);
            this.pnlBottomPanel.TabIndex = 1;
            // 
            // btnPrintMomo
            // 
            this.btnPrintMomo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPrintMomo.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnPrintMomo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintMomo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnPrintMomo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnPrintMomo.BorderRadius = 0;
            this.btnPrintMomo.BorderThick = 0;
            this.btnPrintMomo.ButtonValue = "";
            this.btnPrintMomo.Enabled = false;
            this.btnPrintMomo.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintMomo.Image")));
            this.btnPrintMomo.ImageColor = System.Drawing.Color.White;
            this.btnPrintMomo.ImageCss = "print";
            this.btnPrintMomo.ImageFontSize = 30F;
            this.btnPrintMomo.ImageTextPadding = 0;
            this.btnPrintMomo.IsActive = false;
            this.btnPrintMomo.IsAutoScaleWidth = false;
            this.btnPrintMomo.IsVerticalImageText = true;
            this.btnPrintMomo.Location = new System.Drawing.Point(184, 60);
            this.btnPrintMomo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintMomo.Name = "btnPrintMomo";
            this.btnPrintMomo.Size = new System.Drawing.Size(27, 21);
            this.btnPrintMomo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPrintMomo.TabIndex = 18;
            this.btnPrintMomo.TabStop = false;
            this.btnPrintMomo.TextColor = System.Drawing.Color.White;
            this.btnPrintMomo.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintMomo.TextValue = "  In Phiếu";
            this.btnPrintMomo.ToggleGroup = 0;
            this.btnPrintMomo.Type = POS.CustomControl.ButtonType.Click;
            this.btnPrintMomo.Click += new System.EventHandler(this.btnPrintMomo_Click);
            // 
            // BtnMomoPay
            // 
            this.BtnMomoPay.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.BtnMomoPay.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.BtnMomoPay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnMomoPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.BtnMomoPay.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.BtnMomoPay.BorderRadius = 0;
            this.BtnMomoPay.BorderThick = 0;
            this.BtnMomoPay.ButtonValue = "";
            this.BtnMomoPay.Enabled = false;
            this.BtnMomoPay.Image = ((System.Drawing.Image)(resources.GetObject("BtnMomoPay.Image")));
            this.BtnMomoPay.ImageColor = System.Drawing.Color.White;
            this.BtnMomoPay.ImageCss = "search";
            this.BtnMomoPay.ImageFontSize = 30F;
            this.BtnMomoPay.ImageTextPadding = 0;
            this.BtnMomoPay.IsActive = false;
            this.BtnMomoPay.IsAutoScaleWidth = false;
            this.BtnMomoPay.IsVerticalImageText = true;
            this.BtnMomoPay.Location = new System.Drawing.Point(361, 5);
            this.BtnMomoPay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMomoPay.Name = "BtnMomoPay";
            this.BtnMomoPay.Size = new System.Drawing.Size(128, 81);
            this.BtnMomoPay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BtnMomoPay.TabIndex = 20;
            this.BtnMomoPay.TabStop = false;
            this.BtnMomoPay.TextColor = System.Drawing.Color.White;
            this.BtnMomoPay.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.BtnMomoPay.TextValue = "Nhập mã";
            this.BtnMomoPay.ToggleGroup = 0;
            this.BtnMomoPay.Type = POS.CustomControl.ButtonType.Click;
            // 
            // btnCheckMomo
            // 
            this.btnCheckMomo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnCheckMomo.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnCheckMomo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckMomo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnCheckMomo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnCheckMomo.BorderRadius = 0;
            this.btnCheckMomo.BorderThick = 0;
            this.btnCheckMomo.ButtonValue = "";
            this.btnCheckMomo.Enabled = false;
            this.btnCheckMomo.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckMomo.Image")));
            this.btnCheckMomo.ImageColor = System.Drawing.Color.White;
            this.btnCheckMomo.ImageCss = "check";
            this.btnCheckMomo.ImageFontSize = 30F;
            this.btnCheckMomo.ImageTextPadding = 0;
            this.btnCheckMomo.IsActive = false;
            this.btnCheckMomo.IsAutoScaleWidth = false;
            this.btnCheckMomo.IsVerticalImageText = true;
            this.btnCheckMomo.Location = new System.Drawing.Point(216, 5);
            this.btnCheckMomo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckMomo.Name = "btnCheckMomo";
            this.btnCheckMomo.Size = new System.Drawing.Size(127, 81);
            this.btnCheckMomo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCheckMomo.TabIndex = 19;
            this.btnCheckMomo.TabStop = false;
            this.btnCheckMomo.TextColor = System.Drawing.Color.White;
            this.btnCheckMomo.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnCheckMomo.TextValue = "  Kiểm tra";
            this.btnCheckMomo.ToggleGroup = 0;
            this.btnCheckMomo.Type = POS.CustomControl.ButtonType.Click;
            this.btnCheckMomo.Click += new System.EventHandler(this.btnCheckMomo_Click);
            // 
            // lblCheckinDate
            // 
            this.lblCheckinDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCheckinDate.AutoSize = true;
            this.lblCheckinDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckinDate.ForeColor = System.Drawing.Color.White;
            this.lblCheckinDate.Location = new System.Drawing.Point(7, 14);
            this.lblCheckinDate.Margin = new System.Windows.Forms.Padding(0, 12, 4, 12);
            this.lblCheckinDate.Name = "lblCheckinDate";
            this.lblCheckinDate.Size = new System.Drawing.Size(161, 58);
            this.lblCheckinDate.TabIndex = 2;
            this.lblCheckinDate.Text = "14/08/2016\r\n00:00";
            this.lblCheckinDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrintCook
            // 
            this.btnPrintCook.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPrintCook.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnPrintCook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintCook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnPrintCook.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnPrintCook.BorderRadius = 0;
            this.btnPrintCook.BorderThick = 0;
            this.btnPrintCook.ButtonValue = "";
            this.btnPrintCook.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintCook.Image")));
            this.btnPrintCook.ImageColor = System.Drawing.Color.White;
            this.btnPrintCook.ImageCss = "print";
            this.btnPrintCook.ImageFontSize = 30F;
            this.btnPrintCook.ImageTextPadding = 0;
            this.btnPrintCook.IsActive = false;
            this.btnPrintCook.IsAutoScaleWidth = false;
            this.btnPrintCook.IsVerticalImageText = true;
            this.btnPrintCook.Location = new System.Drawing.Point(667, 2);
            this.btnPrintCook.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintCook.Name = "btnPrintCook";
            this.btnPrintCook.Size = new System.Drawing.Size(127, 81);
            this.btnPrintCook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPrintCook.TabIndex = 0;
            this.btnPrintCook.TabStop = false;
            this.btnPrintCook.TextColor = System.Drawing.Color.White;
            this.btnPrintCook.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintCook.TextValue = "  Phiếu bếp";
            this.btnPrintCook.ToggleGroup = 0;
            this.btnPrintCook.Type = POS.CustomControl.ButtonType.Click;
            this.btnPrintCook.Click += new System.EventHandler(this.btnPrintCook_Click);
            // 
            // btnPrintReceipt
            // 
            this.btnPrintReceipt.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPrintReceipt.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnPrintReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnPrintReceipt.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnPrintReceipt.BorderRadius = 0;
            this.btnPrintReceipt.BorderThick = 0;
            this.btnPrintReceipt.ButtonValue = "";
            this.btnPrintReceipt.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReceipt.Image")));
            this.btnPrintReceipt.ImageColor = System.Drawing.Color.White;
            this.btnPrintReceipt.ImageCss = "print";
            this.btnPrintReceipt.ImageFontSize = 30F;
            this.btnPrintReceipt.ImageTextPadding = 0;
            this.btnPrintReceipt.IsActive = false;
            this.btnPrintReceipt.IsAutoScaleWidth = false;
            this.btnPrintReceipt.IsVerticalImageText = true;
            this.btnPrintReceipt.Location = new System.Drawing.Point(535, 2);
            this.btnPrintReceipt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintReceipt.Name = "btnPrintReceipt";
            this.btnPrintReceipt.Size = new System.Drawing.Size(127, 81);
            this.btnPrintReceipt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPrintReceipt.TabIndex = 0;
            this.btnPrintReceipt.TabStop = false;
            this.btnPrintReceipt.TextColor = System.Drawing.Color.White;
            this.btnPrintReceipt.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.TextValue = " Tạm tính";
            this.btnPrintReceipt.ToggleGroup = 0;
            this.btnPrintReceipt.Type = POS.CustomControl.ButtonType.Click;
            this.btnPrintReceipt.Visible = false;
            this.btnPrintReceipt.Click += new System.EventHandler(this.btnPrintReceipt_Click);
            // 
            // btnHide
            // 
            this.btnHide.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnHide.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnHide.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnHide.BorderRadius = 0;
            this.btnHide.BorderThick = 0;
            this.btnHide.ButtonValue = "";
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.ImageColor = System.Drawing.Color.White;
            this.btnHide.ImageCss = "pause";
            this.btnHide.ImageFontSize = 30F;
            this.btnHide.ImageTextPadding = 0;
            this.btnHide.IsActive = false;
            this.btnHide.IsAutoScaleWidth = false;
            this.btnHide.IsVerticalImageText = false;
            this.btnHide.Location = new System.Drawing.Point(997, 4);
            this.btnHide.Margin = new System.Windows.Forms.Padding(4);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(173, 81);
            this.btnHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHide.TabIndex = 0;
            this.btnHide.TabStop = false;
            this.btnHide.TextColor = System.Drawing.Color.White;
            this.btnHide.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnHide.TextValue = "Ẩn";
            this.btnHide.ToggleGroup = 0;
            this.btnHide.Type = POS.CustomControl.ButtonType.Click;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnFinish.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnFinish.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnFinish.BorderRadius = 0;
            this.btnFinish.BorderThick = 0;
            this.btnFinish.ButtonValue = "";
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageColor = System.Drawing.Color.White;
            this.btnFinish.ImageCss = "check";
            this.btnFinish.ImageFontSize = 30F;
            this.btnFinish.ImageTextPadding = 0;
            this.btnFinish.IsActive = false;
            this.btnFinish.IsAutoScaleWidth = false;
            this.btnFinish.IsVerticalImageText = false;
            this.btnFinish.Location = new System.Drawing.Point(1179, 4);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(173, 81);
            this.btnFinish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFinish.TabIndex = 0;
            this.btnFinish.TabStop = false;
            this.btnFinish.TextColor = System.Drawing.Color.White;
            this.btnFinish.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnFinish.TextValue = "Hoàn tất";
            this.btnFinish.ToggleGroup = 0;
            this.btnFinish.Type = POS.CustomControl.ButtonType.Click;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_ClickAsync);
            // 
            // btnListMembershipType
            // 
            this.btnListMembershipType.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnListMembershipType.ActiveBackgroudColor = System.Drawing.Color.Black;
            this.btnListMembershipType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnListMembershipType.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnListMembershipType.BorderRadius = 0;
            this.btnListMembershipType.BorderThick = 0;
            this.btnListMembershipType.ButtonValue = "";
            this.btnListMembershipType.Image = ((System.Drawing.Image)(resources.GetObject("btnListMembershipType.Image")));
            this.btnListMembershipType.ImageColor = System.Drawing.Color.White;
            this.btnListMembershipType.ImageCss = "user";
            this.btnListMembershipType.ImageFontSize = 25F;
            this.btnListMembershipType.ImageTextPadding = 0;
            this.btnListMembershipType.IsActive = false;
            this.btnListMembershipType.IsAutoScaleWidth = false;
            this.btnListMembershipType.IsVerticalImageText = false;
            this.btnListMembershipType.Location = new System.Drawing.Point(489, 3);
            this.btnListMembershipType.Margin = new System.Windows.Forms.Padding(0);
            this.btnListMembershipType.Name = "btnListMembershipType";
            this.btnListMembershipType.Size = new System.Drawing.Size(157, 44);
            this.btnListMembershipType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnListMembershipType.TabIndex = 2;
            this.btnListMembershipType.TabStop = false;
            this.btnListMembershipType.TextColor = System.Drawing.Color.White;
            this.btnListMembershipType.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnListMembershipType.TextValue = "Thành Viên";
            this.btnListMembershipType.ToggleGroup = 1;
            this.btnListMembershipType.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnListMembershipType.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // barTop
            // 
            this.barTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barTop.BackColor = System.Drawing.Color.White;
            this.barTop.Controls.Add(this.btnPreview);
            this.barTop.Controls.Add(this.bsBtnOrderNotes);
            this.barTop.Controls.Add(this.btnPaymentInfo);
            this.barTop.Controls.Add(this.btnPromotionInfo);
            this.barTop.Controls.Add(this.btnCustomerInfo);
            this.barTop.Location = new System.Drawing.Point(5, 70);
            this.barTop.Margin = new System.Windows.Forms.Padding(0);
            this.barTop.Name = "barTop";
            this.barTop.Size = new System.Drawing.Size(1368, 78);
            this.barTop.TabIndex = 1;
            // 
            // btnPreview
            // 
            this.btnPreview.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPreview.ActiveBackgroudColor = System.Drawing.Color.Purple;
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.btnPreview.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPreview.BorderRadius = 0;
            this.btnPreview.BorderThick = 0;
            this.btnPreview.ButtonValue = "";
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageColor = System.Drawing.Color.White;
            this.btnPreview.ImageCss = "eye";
            this.btnPreview.ImageFontSize = 25F;
            this.btnPreview.ImageTextPadding = 0;
            this.btnPreview.IsActive = false;
            this.btnPreview.IsAutoScaleWidth = false;
            this.btnPreview.IsVerticalImageText = false;
            this.btnPreview.Location = new System.Drawing.Point(972, 5);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(204, 52);
            this.btnPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPreview.TabIndex = 16;
            this.btnPreview.TabStop = false;
            this.btnPreview.TextColor = System.Drawing.Color.White;
            this.btnPreview.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.TextValue = "Xem trước";
            this.btnPreview.ToggleGroup = 1;
            this.btnPreview.Type = POS.CustomControl.ButtonType.Click;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // bsBtnOrderNotes
            // 
            this.bsBtnOrderNotes.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bsBtnOrderNotes.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bsBtnOrderNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(187)))), ((int)(((byte)(173)))));
            this.bsBtnOrderNotes.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bsBtnOrderNotes.BorderRadius = 0;
            this.bsBtnOrderNotes.BorderThick = 0;
            this.bsBtnOrderNotes.ButtonValue = "";
            this.bsBtnOrderNotes.Image = ((System.Drawing.Image)(resources.GetObject("bsBtnOrderNotes.Image")));
            this.bsBtnOrderNotes.ImageColor = System.Drawing.Color.Black;
            this.bsBtnOrderNotes.ImageCss = "sticky-note";
            this.bsBtnOrderNotes.ImageFontSize = 25F;
            this.bsBtnOrderNotes.ImageTextPadding = 0;
            this.bsBtnOrderNotes.IsActive = false;
            this.bsBtnOrderNotes.IsAutoScaleWidth = false;
            this.bsBtnOrderNotes.IsVerticalImageText = false;
            this.bsBtnOrderNotes.Location = new System.Drawing.Point(1185, 5);
            this.bsBtnOrderNotes.Margin = new System.Windows.Forms.Padding(4);
            this.bsBtnOrderNotes.Name = "bsBtnOrderNotes";
            this.bsBtnOrderNotes.Size = new System.Drawing.Size(161, 52);
            this.bsBtnOrderNotes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bsBtnOrderNotes.TabIndex = 15;
            this.bsBtnOrderNotes.TabStop = false;
            this.bsBtnOrderNotes.TextColor = System.Drawing.Color.Black;
            this.bsBtnOrderNotes.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bsBtnOrderNotes.TextValue = "Ghi chú";
            this.bsBtnOrderNotes.ToggleGroup = 0;
            this.bsBtnOrderNotes.Type = POS.CustomControl.ButtonType.Click;
            this.bsBtnOrderNotes.Click += new System.EventHandler(this.bsBtnOrderNotes_Click);
            // 
            // btnPaymentInfo
            // 
            this.btnPaymentInfo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPaymentInfo.ActiveBackgroudColor = System.Drawing.Color.Black;
            this.btnPaymentInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnPaymentInfo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnPaymentInfo.BorderRadius = 0;
            this.btnPaymentInfo.BorderThick = 0;
            this.btnPaymentInfo.ButtonValue = "";
            this.btnPaymentInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentInfo.Image")));
            this.btnPaymentInfo.ImageColor = System.Drawing.Color.White;
            this.btnPaymentInfo.ImageCss = "money";
            this.btnPaymentInfo.ImageFontSize = 25F;
            this.btnPaymentInfo.ImageTextPadding = 0;
            this.btnPaymentInfo.IsActive = false;
            this.btnPaymentInfo.IsAutoScaleWidth = false;
            this.btnPaymentInfo.IsVerticalImageText = false;
            this.btnPaymentInfo.Location = new System.Drawing.Point(436, 4);
            this.btnPaymentInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnPaymentInfo.Name = "btnPaymentInfo";
            this.btnPaymentInfo.Size = new System.Drawing.Size(209, 54);
            this.btnPaymentInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPaymentInfo.TabIndex = 2;
            this.btnPaymentInfo.TabStop = false;
            this.btnPaymentInfo.TextColor = System.Drawing.Color.White;
            this.btnPaymentInfo.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPaymentInfo.TextValue = "Thanh toán";
            this.btnPaymentInfo.ToggleGroup = 1;
            this.btnPaymentInfo.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnPaymentInfo.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // btnPromotionInfo
            // 
            this.btnPromotionInfo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnPromotionInfo.ActiveBackgroudColor = System.Drawing.Color.Black;
            this.btnPromotionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(181)))), ((int)(((byte)(229)))));
            this.btnPromotionInfo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnPromotionInfo.BorderRadius = 0;
            this.btnPromotionInfo.BorderThick = 0;
            this.btnPromotionInfo.ButtonValue = "";
            this.btnPromotionInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnPromotionInfo.Image")));
            this.btnPromotionInfo.ImageColor = System.Drawing.Color.White;
            this.btnPromotionInfo.ImageCss = "gift";
            this.btnPromotionInfo.ImageFontSize = 25F;
            this.btnPromotionInfo.ImageTextPadding = 0;
            this.btnPromotionInfo.IsActive = false;
            this.btnPromotionInfo.IsAutoScaleWidth = false;
            this.btnPromotionInfo.IsVerticalImageText = false;
            this.btnPromotionInfo.Location = new System.Drawing.Point(219, 4);
            this.btnPromotionInfo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnPromotionInfo.Name = "btnPromotionInfo";
            this.btnPromotionInfo.Size = new System.Drawing.Size(209, 54);
            this.btnPromotionInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnPromotionInfo.TabIndex = 1;
            this.btnPromotionInfo.TabStop = false;
            this.btnPromotionInfo.TextColor = System.Drawing.Color.White;
            this.btnPromotionInfo.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnPromotionInfo.TextValue = "Khuyến mãi";
            this.btnPromotionInfo.ToggleGroup = 1;
            this.btnPromotionInfo.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnPromotionInfo.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnCustomerInfo.ActiveBackgroudColor = System.Drawing.Color.Black;
            this.btnCustomerInfo.BackColor = System.Drawing.Color.Black;
            this.btnCustomerInfo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Info;
            this.btnCustomerInfo.BorderRadius = 0;
            this.btnCustomerInfo.BorderThick = 0;
            this.btnCustomerInfo.ButtonValue = "";
            this.btnCustomerInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerInfo.Image")));
            this.btnCustomerInfo.ImageColor = System.Drawing.Color.White;
            this.btnCustomerInfo.ImageCss = "user";
            this.btnCustomerInfo.ImageFontSize = 25F;
            this.btnCustomerInfo.ImageTextPadding = 0;
            this.btnCustomerInfo.IsActive = true;
            this.btnCustomerInfo.IsAutoScaleWidth = false;
            this.btnCustomerInfo.IsVerticalImageText = false;
            this.btnCustomerInfo.Location = new System.Drawing.Point(1, 4);
            this.btnCustomerInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(209, 54);
            this.btnCustomerInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCustomerInfo.TabIndex = 0;
            this.btnCustomerInfo.TabStop = false;
            this.btnCustomerInfo.TextColor = System.Drawing.Color.White;
            this.btnCustomerInfo.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnCustomerInfo.TextValue = "Khách hàng";
            this.btnCustomerInfo.ToggleGroup = 1;
            this.btnCustomerInfo.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnCustomerInfo.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // txtOrderNotes
            // 
            this.txtOrderNotes.BackColor = System.Drawing.Color.White;
            this.txtOrderNotes.BorderRadius = 2;
            this.txtOrderNotes.BorderSize = 1;
            this.txtOrderNotes.ImageWidth = 1;
            this.txtOrderNotes.ImageZoom = 1;
            this.txtOrderNotes.Location = new System.Drawing.Point(28, 39);
            this.txtOrderNotes.Logo = null;
            this.txtOrderNotes.Margin = new System.Windows.Forms.Padding(0);
            this.txtOrderNotes.Name = "txtOrderNotes";
            this.txtOrderNotes.PasswordChar = '\0';
            this.txtOrderNotes.Size = new System.Drawing.Size(877, 80);
            this.txtOrderNotes.TabIndex = 14;
            // 
            // txtServedStaff
            // 
            this.txtServedStaff.BackColor = System.Drawing.Color.Transparent;
            this.txtServedStaff.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtServedStaff.BorderRadius = 2;
            this.txtServedStaff.BorderThick = 1;
            this.txtServedStaff.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServedStaff.ForeColor = System.Drawing.Color.White;
            this.txtServedStaff.Location = new System.Drawing.Point(1033, 14);
            this.txtServedStaff.Margin = new System.Windows.Forms.Padding(7, 6, 4, 4);
            this.txtServedStaff.Name = "txtServedStaff";
            this.txtServedStaff.PasswordChar = '\0';
            this.txtServedStaff.ReadOnly = true;
            this.txtServedStaff.Size = new System.Drawing.Size(311, 35);
            this.txtServedStaff.TabIndex = 1;
            this.txtServedStaff.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServedStaff.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtServedStaff.Click += new System.EventHandler(this.txtServedStaff_Click);
            // 
            // OrderPropertyForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1041, 692);
            this.Controls.Add(this.pnlBottomPanel);
            this.Controls.Add(this.barTop);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderPropertyForm2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PropertiesPanel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderPropetyPanel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshAllTab)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlNote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsbtnCloseNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton9)).EndInit();
            this.pnlInformation.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnServedStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddVAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDecreaseVAT)).EndInit();
            this.pnlBottomPanel.ResumeLayout(false);
            this.pnlBottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintMomo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnMomoPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheckMomo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintCook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrintReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnListMembershipType)).EndInit();
            this.barTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnOrderNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPaymentInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPromotionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomerInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        const int labelPaddingLeft = 13;
        private BootstrapPanel pnlBottomPanel;
        private BootstrapButton btnFinish;
        private BootstrapButton btnHide;
        private BootstrapPanel pnlMain;
        private BootstrapPanel pnlInformation;
        private BootstrapPanel pnlHeader;
        private CategoryBar barTop;
        private BootstrapButton btnCustomerInfo;
        private BootstrapButton btnPaymentInfo;
        //
        private BootstrapButton btnListMembershipType;
        //
        private BootstrapButton btnPromotionInfo;
        private BootstrapPanel pnlContainer;
        private Label lblOrderCode;
        private Label lblCheckinDate;
        private Label lblTable;
        private Label lblTotalAmount;
        private Label lblExchange;
        private Label lblVATAmount;
        private Label lblAfterDiscount;
        private Label lblFinalAmount;
        private Label lblTotalDiscount;
        private Label lblReceived;
        private BootstrapButton bootstrapButton9;
        private BootstrapButton btnPrintReceipt;
        private BootstrapButton btnPrintCook;
        private BootstrapButton bsBtnServedStaff;
        private RoundTextbox txtServedStaff;
        private Label label1;
        private Label lblDiscout;
        private Label lblTotal;
        private Label label4;
        private Label label3;
        private Label label5;
        private BootstrapButton bsBtnOrderNotes;
        private LoginFlatTextBox txtOrderNotes;
        private BootstrapButton bsbtnCloseNote;
        private BootstrapPanel pnlNote;
        private Label lblMoney;
        private Label txtMoney;
        private Label lblPoint;
        private Label txtPoint;
        private Label lblNoti;
        private BootstrapButton btnRefreshAllTab;
        public BootstrapButton btnAddVAT;
        public BootstrapButton btnDecreaseVAT;
        private BootstrapButton btnPreview;
        private Label txtAvailPromo;
        private BootstrapButton btnPrintMomo;
        private BootstrapButton btnCheckMomo;
        private Label label2;
        private Label lblInNeed;
        private BootstrapButton BtnMomoPay;
    }
}
