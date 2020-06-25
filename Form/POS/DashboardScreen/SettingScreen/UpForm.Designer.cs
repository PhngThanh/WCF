namespace POS.DashboardScreen.SettingScreen
{
    partial class UpForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpForm));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.btnUpdateAll = new POS.Common.FlexButton();
            this.btnUpdateAccount = new POS.Common.FlexButton();
            this.btnUpdateProduct = new POS.Common.FlexButton();
            this.btnUpdateCategory = new POS.Common.FlexButton();
            this.btnUpdatePromotion = new POS.Common.FlexButton();
            this.btnBack2 = new POS.CustomControl.BootstrapButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.pnlOrder.Controls.Add(this.btnUpdateAll);
            this.pnlOrder.Controls.Add(this.btnUpdateAccount);
            this.pnlOrder.Controls.Add(this.btnUpdateProduct);
            this.pnlOrder.Controls.Add(this.btnUpdateCategory);
            this.pnlOrder.Controls.Add(this.btnUpdatePromotion);
            this.pnlOrder.Location = new System.Drawing.Point(10, 14);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(1);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(440, 246);
            this.pnlOrder.TabIndex = 8;
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateAll.BorderColor = System.Drawing.Color.White;
            this.btnUpdateAll.BorderRadius = 4;
            this.btnUpdateAll.BorderThick = 1;
            this.btnUpdateAll.Caption = "Cập nhật tất cả";
            this.btnUpdateAll.CenterImageDisable = null;
            this.btnUpdateAll.CenterImageNormal = null;
            this.btnUpdateAll.CenterImagePress = null;
            this.btnUpdateAll.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdateAll.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAll.IsActivated = false;
            this.btnUpdateAll.LeftImageDisable = null;
            this.btnUpdateAll.LeftImageGap = 7;
            this.btnUpdateAll.LeftImageNornal = null;
            this.btnUpdateAll.LeftImagePress = null;
            this.btnUpdateAll.Location = new System.Drawing.Point(6, 16);
            this.btnUpdateAll.Margin = new System.Windows.Forms.Padding(7);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdateAll.PressColor = System.Drawing.Color.White;
            this.btnUpdateAll.Size = new System.Drawing.Size(427, 60);
            this.btnUpdateAll.TabIndex = 20;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateAccount.BorderColor = System.Drawing.Color.White;
            this.btnUpdateAccount.BorderRadius = 4;
            this.btnUpdateAccount.BorderThick = 1;
            this.btnUpdateAccount.Caption = "Cập nhật tài khoản";
            this.btnUpdateAccount.CenterImageDisable = null;
            this.btnUpdateAccount.CenterImageNormal = null;
            this.btnUpdateAccount.CenterImagePress = null;
            this.btnUpdateAccount.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdateAccount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateAccount.IsActivated = false;
            this.btnUpdateAccount.LeftImageDisable = null;
            this.btnUpdateAccount.LeftImageGap = 7;
            this.btnUpdateAccount.LeftImageNornal = null;
            this.btnUpdateAccount.LeftImagePress = null;
            this.btnUpdateAccount.Location = new System.Drawing.Point(10, 93);
            this.btnUpdateAccount.Margin = new System.Windows.Forms.Padding(10);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdateAccount.PressColor = System.Drawing.Color.White;
            this.btnUpdateAccount.Size = new System.Drawing.Size(200, 60);
            this.btnUpdateAccount.TabIndex = 19;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateProduct.BorderColor = System.Drawing.Color.White;
            this.btnUpdateProduct.BorderRadius = 4;
            this.btnUpdateProduct.BorderThick = 1;
            this.btnUpdateProduct.Caption = "Cập nhật sản phẩm";
            this.btnUpdateProduct.CenterImageDisable = null;
            this.btnUpdateProduct.CenterImageNormal = null;
            this.btnUpdateProduct.CenterImagePress = null;
            this.btnUpdateProduct.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdateProduct.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProduct.IsActivated = false;
            this.btnUpdateProduct.LeftImageDisable = null;
            this.btnUpdateProduct.LeftImageGap = 7;
            this.btnUpdateProduct.LeftImageNornal = null;
            this.btnUpdateProduct.LeftImagePress = null;
            this.btnUpdateProduct.Location = new System.Drawing.Point(230, 173);
            this.btnUpdateProduct.Margin = new System.Windows.Forms.Padding(10);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdateProduct.PressColor = System.Drawing.Color.White;
            this.btnUpdateProduct.Size = new System.Drawing.Size(200, 60);
            this.btnUpdateProduct.TabIndex = 18;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCategory.BorderColor = System.Drawing.Color.White;
            this.btnUpdateCategory.BorderRadius = 4;
            this.btnUpdateCategory.BorderThick = 1;
            this.btnUpdateCategory.Caption = "Cập nhật danh mục";
            this.btnUpdateCategory.CenterImageDisable = null;
            this.btnUpdateCategory.CenterImageNormal = null;
            this.btnUpdateCategory.CenterImagePress = null;
            this.btnUpdateCategory.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdateCategory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.IsActivated = false;
            this.btnUpdateCategory.LeftImageDisable = null;
            this.btnUpdateCategory.LeftImageGap = 7;
            this.btnUpdateCategory.LeftImageNornal = null;
            this.btnUpdateCategory.LeftImagePress = null;
            this.btnUpdateCategory.Location = new System.Drawing.Point(10, 173);
            this.btnUpdateCategory.Margin = new System.Windows.Forms.Padding(10);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdateCategory.PressColor = System.Drawing.Color.White;
            this.btnUpdateCategory.Size = new System.Drawing.Size(200, 60);
            this.btnUpdateCategory.TabIndex = 17;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // btnUpdatePromotion
            // 
            this.btnUpdatePromotion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePromotion.BorderColor = System.Drawing.Color.White;
            this.btnUpdatePromotion.BorderRadius = 4;
            this.btnUpdatePromotion.BorderThick = 1;
            this.btnUpdatePromotion.Caption = "Cập nhật khuyến mãi";
            this.btnUpdatePromotion.CenterImageDisable = null;
            this.btnUpdatePromotion.CenterImageNormal = null;
            this.btnUpdatePromotion.CenterImagePress = null;
            this.btnUpdatePromotion.DisableColor = System.Drawing.Color.Empty;
            this.btnUpdatePromotion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePromotion.IsActivated = false;
            this.btnUpdatePromotion.LeftImageDisable = null;
            this.btnUpdatePromotion.LeftImageGap = 7;
            this.btnUpdatePromotion.LeftImageNornal = null;
            this.btnUpdatePromotion.LeftImagePress = null;
            this.btnUpdatePromotion.Location = new System.Drawing.Point(230, 93);
            this.btnUpdatePromotion.Margin = new System.Windows.Forms.Padding(10);
            this.btnUpdatePromotion.Name = "btnUpdatePromotion";
            this.btnUpdatePromotion.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnUpdatePromotion.PressColor = System.Drawing.Color.White;
            this.btnUpdatePromotion.Size = new System.Drawing.Size(200, 60);
            this.btnUpdatePromotion.TabIndex = 7;
            this.btnUpdatePromotion.Click += new System.EventHandler(this.btnUpdatePromotion_Click);
            // 
            // btnBack2
            // 
            this.btnBack2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack2.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack2.BorderRadius = 0;
            this.btnBack2.BorderThick = 0;
            this.btnBack2.ButtonValue = "";
            this.btnBack2.Image = ((System.Drawing.Image)(resources.GetObject("btnBack2.Image")));
            this.btnBack2.ImageColor = System.Drawing.Color.White;
            this.btnBack2.ImageCss = "times";
            this.btnBack2.ImageFontSize = 24F;
            this.btnBack2.ImageTextPadding = 0;
            this.btnBack2.IsActive = false;
            this.btnBack2.IsAutoScaleWidth = false;
            this.btnBack2.IsVerticalImageText = false;
            this.btnBack2.Location = new System.Drawing.Point(392, 0);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(71, 30);
            this.btnBack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBack2.TabIndex = 22;
            this.btnBack2.TabStop = false;
            this.btnBack2.TextColor = System.Drawing.Color.White;
            this.btnBack2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnBack2.TextValue = "";
            this.btnBack2.ToggleGroup = 0;
            this.btnBack2.Type = POS.CustomControl.ButtonType.Click;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.pnlOrder);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 274);
            this.panel1.TabIndex = 21;
            // 
            // UpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(460, 304);
            this.Controls.Add(this.btnBack2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingScreen";
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private Common.FlexButton btnUpdateAll;
        private Common.FlexButton btnUpdateAccount;
        private Common.FlexButton btnUpdateProduct;
        private Common.FlexButton btnUpdateCategory;
        private Common.FlexButton btnUpdatePromotion;
        private CustomControl.BootstrapButton btnBack2;
        private System.Windows.Forms.Panel panel1;
    }
}