using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class TableChangeForm
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

        //this.pnlListOrderSelectedTable = new OrderPanelItemList(OrderItemClickEventCommandCode.OldOrder);
        

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableChangeForm));
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.btnNewTable = new POS.CustomControl.BootstrapButton();
            this.lblChooseTable = new System.Windows.Forms.Label();
            this.btnMoveLeftAll = new POS.CustomControl.BootstrapButton();
            this.btnMoveRightAll = new POS.CustomControl.BootstrapButton();
            this.pnlItemListNew = new POS.SaleScreen.OrderPanelItemList();
            this.pnlItemListCurrent = new POS.SaleScreen.OrderPanelItemList();
            this.lblCurrentTable = new System.Windows.Forms.Label();
            this.barBottom = new POS.CustomControl.BootstrapPanel();
            this.btnHide = new POS.CustomControl.BootstrapButton();
            this.btnSave = new POS.CustomControl.BootstrapButton();
            this.selectTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveLeftAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveRightAll)).BeginInit();
            this.barBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.pnlMain.Controls.Add(this.btnNewTable);
            this.pnlMain.Controls.Add(this.lblChooseTable);
            this.pnlMain.Controls.Add(this.btnMoveLeftAll);
            this.pnlMain.Controls.Add(this.btnMoveRightAll);
            this.pnlMain.Controls.Add(this.pnlItemListNew);
            this.pnlMain.Controls.Add(this.pnlItemListCurrent);
            this.pnlMain.Controls.Add(this.lblCurrentTable);
            this.pnlMain.Location = new System.Drawing.Point(7, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(774, 600);
            this.pnlMain.TabIndex = 7;
            // 
            // btnNewTable
            // 
            this.btnNewTable.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnNewTable.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnNewTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnNewTable.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnNewTable.BorderRadius = 0;
            this.btnNewTable.BorderThick = 0;
            this.btnNewTable.ButtonValue = "";
            this.btnNewTable.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTable.Image")));
            this.btnNewTable.ImageColor = System.Drawing.Color.White;
            this.btnNewTable.ImageCss = "plus-square";
            this.btnNewTable.ImageFontSize = 20F;
            this.btnNewTable.ImageTextPadding = 0;
            this.btnNewTable.IsActive = false;
            this.btnNewTable.IsAutoScaleWidth = false;
            this.btnNewTable.IsVerticalImageText = false;
            this.btnNewTable.Location = new System.Drawing.Point(432, 15);
            this.btnNewTable.Name = "btnNewTable";
            this.btnNewTable.Size = new System.Drawing.Size(310, 39);
            this.btnNewTable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnNewTable.TabIndex = 18;
            this.btnNewTable.TabStop = false;
            this.btnNewTable.TextColor = System.Drawing.Color.White;
            this.btnNewTable.TextFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.btnNewTable.TextValue = "Chọn bàn mới";
            this.btnNewTable.ToggleGroup = 0;
            this.btnNewTable.Type = POS.CustomControl.ButtonType.Click;
            this.btnNewTable.Click += new System.EventHandler(this.btnNewTable_Click);
            // 
            // lblChooseTable
            // 
            this.lblChooseTable.AutoSize = true;
            this.lblChooseTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseTable.ForeColor = System.Drawing.Color.White;
            this.lblChooseTable.Location = new System.Drawing.Point(279, 27);
            this.lblChooseTable.Name = "lblChooseTable";
            this.lblChooseTable.Size = new System.Drawing.Size(193, 25);
            this.lblChooseTable.TabIndex = 17;
            this.lblChooseTable.Text = "Chọn bàn sẽ chuyển";
            // 
            // btnMoveLeftAll
            // 
            this.btnMoveLeftAll.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnMoveLeftAll.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnMoveLeftAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnMoveLeftAll.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnMoveLeftAll.BorderRadius = 0;
            this.btnMoveLeftAll.BorderThick = 0;
            this.btnMoveLeftAll.ButtonValue = "";
            this.btnMoveLeftAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLeftAll.Image")));
            this.btnMoveLeftAll.ImageColor = System.Drawing.Color.White;
            this.btnMoveLeftAll.ImageCss = "chevron-circle-left";
            this.btnMoveLeftAll.ImageFontSize = 40F;
            this.btnMoveLeftAll.ImageTextPadding = 0;
            this.btnMoveLeftAll.IsActive = false;
            this.btnMoveLeftAll.IsAutoScaleWidth = false;
            this.btnMoveLeftAll.IsVerticalImageText = false;
            this.btnMoveLeftAll.Location = new System.Drawing.Point(356, 325);
            this.btnMoveLeftAll.Name = "btnMoveLeftAll";
            this.btnMoveLeftAll.Size = new System.Drawing.Size(54, 50);
            this.btnMoveLeftAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMoveLeftAll.TabIndex = 16;
            this.btnMoveLeftAll.TabStop = false;
            this.btnMoveLeftAll.TextColor = System.Drawing.Color.White;
            this.btnMoveLeftAll.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnMoveLeftAll.TextValue = "";
            this.btnMoveLeftAll.ToggleGroup = 0;
            this.btnMoveLeftAll.Type = POS.CustomControl.ButtonType.Click;
            this.btnMoveLeftAll.Click += new System.EventHandler(this.btnMoveLeftAll_Click);
            // 
            // btnMoveRightAll
            // 
            this.btnMoveRightAll.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnMoveRightAll.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnMoveRightAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnMoveRightAll.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnMoveRightAll.BorderRadius = 0;
            this.btnMoveRightAll.BorderThick = 0;
            this.btnMoveRightAll.ButtonValue = "";
            this.btnMoveRightAll.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRightAll.Image")));
            this.btnMoveRightAll.ImageColor = System.Drawing.Color.White;
            this.btnMoveRightAll.ImageCss = "chevron-circle-right";
            this.btnMoveRightAll.ImageFontSize = 40F;
            this.btnMoveRightAll.ImageTextPadding = 0;
            this.btnMoveRightAll.IsActive = false;
            this.btnMoveRightAll.IsAutoScaleWidth = false;
            this.btnMoveRightAll.IsVerticalImageText = false;
            this.btnMoveRightAll.Location = new System.Drawing.Point(356, 199);
            this.btnMoveRightAll.Name = "btnMoveRightAll";
            this.btnMoveRightAll.Size = new System.Drawing.Size(54, 50);
            this.btnMoveRightAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMoveRightAll.TabIndex = 16;
            this.btnMoveRightAll.TabStop = false;
            this.btnMoveRightAll.TextColor = System.Drawing.Color.White;
            this.btnMoveRightAll.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnMoveRightAll.TextValue = "";
            this.btnMoveRightAll.ToggleGroup = 0;
            this.btnMoveRightAll.Type = POS.CustomControl.ButtonType.Click;
            this.btnMoveRightAll.Click += new System.EventHandler(this.btnMoveRightAll_Click);
            // 
            // pnlItemListNew
            // 
            this.pnlItemListNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlItemListNew.Location = new System.Drawing.Point(416, 65);
            this.pnlItemListNew.Name = "pnlItemListNew";
            this.pnlItemListNew.OrderEditViewModel = null;
            this.pnlItemListNew.Size = new System.Drawing.Size(340, 515);
            this.pnlItemListNew.TabIndex = 9;
            // 
            // pnlItemListCurrent
            // 
            this.pnlItemListCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlItemListCurrent.Location = new System.Drawing.Point(10, 65);
            this.pnlItemListCurrent.Name = "pnlItemListCurrent";
            this.pnlItemListCurrent.OrderEditViewModel = null;
            this.pnlItemListCurrent.Size = new System.Drawing.Size(340, 515);
            this.pnlItemListCurrent.TabIndex = 8;
            // 
            // lblCurrentTable
            // 
            this.lblCurrentTable.AutoSize = true;
            this.lblCurrentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTable.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTable.Location = new System.Drawing.Point(116, 27);
            this.lblCurrentTable.Name = "lblCurrentTable";
            this.lblCurrentTable.Size = new System.Drawing.Size(132, 25);
            this.lblCurrentTable.TabIndex = 4;
            this.lblCurrentTable.Text = "Current Table";
            // 
            // barBottom
            // 
            this.barBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.barBottom.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.barBottom.Controls.Add(this.btnHide);
            this.barBottom.Controls.Add(this.btnSave);
            this.barBottom.Location = new System.Drawing.Point(7, 611);
            this.barBottom.Name = "barBottom";
            this.barBottom.Size = new System.Drawing.Size(777, 84);
            this.barBottom.TabIndex = 8;
            // 
            // btnHide
            // 
            this.btnHide.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnHide.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnHide.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Danger;
            this.btnHide.BorderRadius = 0;
            this.btnHide.BorderThick = 0;
            this.btnHide.ButtonValue = "";
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.ImageColor = System.Drawing.Color.White;
            this.btnHide.ImageCss = "close";
            this.btnHide.ImageFontSize = 35F;
            this.btnHide.ImageTextPadding = 0;
            this.btnHide.IsActive = false;
            this.btnHide.IsAutoScaleWidth = false;
            this.btnHide.IsVerticalImageText = true;
            this.btnHide.Location = new System.Drawing.Point(15, 10);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(148, 67);
            this.btnHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnHide.TabIndex = 0;
            this.btnHide.TabStop = false;
            this.btnHide.TextColor = System.Drawing.Color.White;
            this.btnHide.TextFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnHide.TextValue = "Hủy";
            this.btnHide.ToggleGroup = 0;
            this.btnHide.Type = POS.CustomControl.ButtonType.Click;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnSave
            // 
            this.btnSave.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnSave.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnSave.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnSave.BorderRadius = 0;
            this.btnSave.BorderThick = 0;
            this.btnSave.ButtonValue = "";
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageColor = System.Drawing.Color.White;
            this.btnSave.ImageCss = "save";
            this.btnSave.ImageFontSize = 35F;
            this.btnSave.ImageTextPadding = 0;
            this.btnSave.IsActive = false;
            this.btnSave.IsAutoScaleWidth = false;
            this.btnSave.IsVerticalImageText = true;
            this.btnSave.Location = new System.Drawing.Point(616, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(148, 67);
            this.btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSave.TabIndex = 0;
            this.btnSave.TabStop = false;
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.TextFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnSave.TextValue = "Lưu";
            this.btnSave.ToggleGroup = 0;
            this.btnSave.Type = POS.CustomControl.ButtonType.Click;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // selectTablePanel
            // 
            this.selectTablePanel.Location = new System.Drawing.Point(0, 0);
            this.selectTablePanel.Name = "selectTablePanel";
            this.selectTablePanel.Size = new System.Drawing.Size(200, 100);
            this.selectTablePanel.TabIndex = 0;
            // 
            // TableChangeForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.barBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableChangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableChangeForm";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveLeftAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMoveRightAll)).EndInit();
            this.barBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private BootstrapPanel pnlMain;
        private Label lblCurrentTable;
        private Label lblChooseTable;
        private TableLayoutPanel selectTablePanel;
        private OrderPanelItemList pnlItemListCurrent;
        private OrderPanelItemList pnlItemListNew;
        private BootstrapPanel barBottom;
        private BootstrapButton btnSave;
        private BootstrapButton btnMoveLeftAll;
        private BootstrapButton btnMoveRightAll;
        private BootstrapButton btnHide;
        private BootstrapButton btnNewTable;
    }
}