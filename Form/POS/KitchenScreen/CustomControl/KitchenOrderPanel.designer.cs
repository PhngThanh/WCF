using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class KitchenOrderPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenOrderPanel));
            this.btnSave = new POS.CustomControl.BootstrapButton();
            this.btnShowAll = new POS.CustomControl.BootstrapButton();
            this.btnSelectAll = new POS.CustomControl.BootstrapButton();
            this.btnShowProcessing = new POS.CustomControl.BootstrapButton();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblOrderType = new System.Windows.Forms.Label();
            this.pnlItemList = new POS.SaleScreen.KitchenOrderItemList();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowProcessing)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnSave.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSave.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnSave.BorderRadius = 0;
            this.btnSave.BorderThick = 0;
            this.btnSave.ButtonValue = "";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageColor = System.Drawing.Color.White;
            this.btnSave.ImageCss = "save";
            this.btnSave.ImageFontSize = 16F;
            this.btnSave.ImageTextPadding = 0;
            this.btnSave.IsActive = false;
            this.btnSave.IsAutoScaleWidth = false;
            this.btnSave.IsVerticalImageText = true;
            this.btnSave.Location = new System.Drawing.Point(2, 551);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 40);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSave.TabIndex = 20;
            this.btnSave.TabStop = false;
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.TextFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.TextValue = "Hoàn tất món";
            this.btnSave.ToggleGroup = 0;
            this.btnSave.Type = POS.CustomControl.ButtonType.Click;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnShowAll.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnShowAll.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnShowAll.BorderRadius = 0;
            this.btnShowAll.BorderThick = 0;
            this.btnShowAll.ButtonValue = "3";
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.ImageColor = System.Drawing.Color.White;
            this.btnShowAll.ImageCss = "navicon";
            this.btnShowAll.ImageFontSize = 1F;
            this.btnShowAll.ImageTextPadding = 0;
            this.btnShowAll.IsActive = false;
            this.btnShowAll.IsAutoScaleWidth = false;
            this.btnShowAll.IsVerticalImageText = true;
            this.btnShowAll.Location = new System.Drawing.Point(2, 49);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(90, 40);
            this.btnShowAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnShowAll.TabIndex = 16;
            this.btnShowAll.TabStop = false;
            this.btnShowAll.TextColor = System.Drawing.Color.Black;
            this.btnShowAll.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.TextValue = "Xem tất cả";
            this.btnShowAll.ToggleGroup = 1;
            this.btnShowAll.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnSelectAll.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSelectAll.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnSelectAll.BorderRadius = 0;
            this.btnSelectAll.BorderThick = 0;
            this.btnSelectAll.ButtonValue = "3";
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.ImageColor = System.Drawing.Color.White;
            this.btnSelectAll.ImageCss = "navicon";
            this.btnSelectAll.ImageFontSize = 1F;
            this.btnSelectAll.ImageTextPadding = 0;
            this.btnSelectAll.IsActive = false;
            this.btnSelectAll.IsAutoScaleWidth = false;
            this.btnSelectAll.IsVerticalImageText = true;
            this.btnSelectAll.Location = new System.Drawing.Point(231, 49);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(90, 40);
            this.btnSelectAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSelectAll.TabIndex = 18;
            this.btnSelectAll.TabStop = false;
            this.btnSelectAll.TextColor = System.Drawing.Color.Black;
            this.btnSelectAll.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.TextValue = "Chọn hết";
            this.btnSelectAll.ToggleGroup = 2;
            this.btnSelectAll.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnShowProcessing
            // 
            this.btnShowProcessing.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.btnShowProcessing.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnShowProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnShowProcessing.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnShowProcessing.BorderRadius = 0;
            this.btnShowProcessing.BorderThick = 0;
            this.btnShowProcessing.ButtonValue = "3";
            this.btnShowProcessing.Image = ((System.Drawing.Image)(resources.GetObject("btnShowProcessing.Image")));
            this.btnShowProcessing.ImageColor = System.Drawing.Color.White;
            this.btnShowProcessing.ImageCss = "navicon";
            this.btnShowProcessing.ImageFontSize = 1F;
            this.btnShowProcessing.ImageTextPadding = 0;
            this.btnShowProcessing.IsActive = false;
            this.btnShowProcessing.IsAutoScaleWidth = false;
            this.btnShowProcessing.IsVerticalImageText = true;
            this.btnShowProcessing.Location = new System.Drawing.Point(98, 49);
            this.btnShowProcessing.Name = "btnShowProcessing";
            this.btnShowProcessing.Size = new System.Drawing.Size(90, 40);
            this.btnShowProcessing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnShowProcessing.TabIndex = 17;
            this.btnShowProcessing.TabStop = false;
            this.btnShowProcessing.TextColor = System.Drawing.Color.Black;
            this.btnShowProcessing.TextFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowProcessing.TextValue = "Đang chế biến";
            this.btnShowProcessing.ToggleGroup = 1;
            this.btnShowProcessing.Type = POS.CustomControl.ButtonType.Toggle;
            this.btnShowProcessing.Click += new System.EventHandler(this.btnShowProcessing_Click);
            // 
            // lblTable
            // 
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(3, 12);
            this.lblTable.Margin = new System.Windows.Forms.Padding(3);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(96, 30);
            this.lblTable.TabIndex = 19;
            this.lblTable.Text = "Bàn: 10";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(105, 12);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(3);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(120, 30);
            this.lblQuantity.TabIndex = 20;
            this.lblQuantity.Text = "7 / 10";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(231, 12);
            this.lblTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(90, 30);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "12:12";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.BackColor = System.Drawing.Color.LimeGreen;
            this.topPanel.Controls.Add(this.lblTable);
            this.topPanel.Controls.Add(this.lblTime);
            this.topPanel.Controls.Add(this.lblQuantity);
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(324, 45);
            this.topPanel.TabIndex = 22;
            // 
            // lblOrderType
            // 
            this.lblOrderType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderType.BackColor = System.Drawing.Color.ForestGreen;
            this.lblOrderType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderType.ForeColor = System.Drawing.Color.White;
            this.lblOrderType.Location = new System.Drawing.Point(213, 551);
            this.lblOrderType.Margin = new System.Windows.Forms.Padding(3);
            this.lblOrderType.Name = "lblOrderType";
            this.lblOrderType.Size = new System.Drawing.Size(109, 40);
            this.lblOrderType.TabIndex = 23;
            this.lblOrderType.Text = "Tại quán";
            this.lblOrderType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlItemList
            // 
            this.pnlItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItemList.BackColor = System.Drawing.Color.DimGray;
            this.pnlItemList.Location = new System.Drawing.Point(2, 95);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.OrderEditViewModel = null;
            this.pnlItemList.Size = new System.Drawing.Size(320, 450);
            this.pnlItemList.TabIndex = 0;
            // 
            // KitchenOrderPanel
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.lblOrderType);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlItemList);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnShowProcessing);
            this.Controls.Add(this.btnShowAll);
            this.Name = "KitchenOrderPanel";
            this.Size = new System.Drawing.Size(324, 594);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnShowProcessing)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //private void SetPosition()
        //{
        //    // LongTN - thay đổi giao diện: thêm khoảng trống show list item
        //    lblExchange.Hide();
        //    lblReceived.Hide();

        //    lblExchange.Top = Height - 82
        //                      - 42 + 20;
        //    lblReceived.Top = lblExchange.Top - 55;
        //pnlSummary.Top = Height - 37 - 140; // - 93 //khi cần thêm lblReceived + lblExchange
        //    lblPayment.Top = Height - 42 - 2;
        //    lblCancel.Top = Height - 42 - 2;
        //    if (pnlItemList != null)
        //    {
        //        pnlItemList.Height = Height - 82 -
        //                            42 - 50 - pnlItemList.Top; // - 42 - 161
        //    }
        //    lblReceived.Invalidate();
        //}

        #endregion

        private KitchenOrderItemList pnlItemList;
        private BootstrapButton btnSave;
        private BootstrapButton btnShowAll;
        private BootstrapButton btnSelectAll;
        private BootstrapButton btnShowProcessing;
        private Label lblTable;
        private Label lblQuantity;
        private Panel topPanel;
        private Label lblTime;
        private Label lblOrderType;
    }
}
