using POS.Common;
using POS.CustomControl;

namespace POS.DashboardScreen
{
    partial class KitchenScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenScreen));
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.btnBack = new POS.CustomControl.BootstrapButton();
            this.btnRefresh = new POS.CustomControl.BootstrapButton();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnPageNext = new System.Windows.Forms.PictureBox();
            this.btnPageBack = new System.Windows.Forms.PictureBox();
            this.lineGreen = new System.Windows.Forms.Panel();
            this.orderContainerOuter = new System.Windows.Forms.Panel();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.clockControl1 = new POS.Common.ClockControl();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.pnlPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOrder
            // 
            this.pnlOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlOrder.Controls.Add(this.btnBack);
            this.pnlOrder.Controls.Add(this.btnRefresh);
            this.pnlOrder.Controls.Add(this.pnlPaging);
            this.pnlOrder.Controls.Add(this.lineGreen);
            this.pnlOrder.Controls.Add(this.orderContainerOuter);
            this.pnlOrder.Location = new System.Drawing.Point(0, 98);
            this.pnlOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(1333, 492);
            this.pnlOrder.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnBack.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnBack.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnBack.BorderRadius = 3;
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
            this.btnBack.Size = new System.Drawing.Size(63, 47);
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
            // btnRefresh
            // 
            this.btnRefresh.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnRefresh.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnRefresh.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.btnRefresh.BorderRadius = 3;
            this.btnRefresh.BorderThick = 0;
            this.btnRefresh.ButtonValue = "";
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageColor = System.Drawing.Color.White;
            this.btnRefresh.ImageCss = "refresh";
            this.btnRefresh.ImageFontSize = 15F;
            this.btnRefresh.ImageTextPadding = 0;
            this.btnRefresh.IsActive = false;
            this.btnRefresh.IsAutoScaleWidth = false;
            this.btnRefresh.IsVerticalImageText = false;
            this.btnRefresh.Location = new System.Drawing.Point(79, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(227, 46);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.TextColor = System.Drawing.Color.White;
            this.btnRefresh.TextFont = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.TextValue = "Làm mới";
            this.btnRefresh.ToggleGroup = 0;
            this.btnRefresh.Type = POS.CustomControl.ButtonType.Click;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlPaging
            // 
            this.pnlPaging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaging.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.pnlPaging.Controls.Add(this.lblTotalPage);
            this.pnlPaging.Controls.Add(this.lblPage);
            this.pnlPaging.Controls.Add(this.btnPageNext);
            this.pnlPaging.Controls.Add(this.btnPageBack);
            this.pnlPaging.Location = new System.Drawing.Point(985, 5);
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
            // lineGreen
            // 
            this.lineGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
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
            this.orderContainerOuter.Location = new System.Drawing.Point(0, 54);
            this.orderContainerOuter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.orderContainerOuter.Name = "orderContainerOuter";
            this.orderContainerOuter.Size = new System.Drawing.Size(1333, 438);
            this.orderContainerOuter.TabIndex = 1;
            // 
            // ptbLogo
            // 
            this.ptbLogo.ImageLocation = "";
            this.ptbLogo.Location = new System.Drawing.Point(1, 24);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(412, 54);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptbLogo.TabIndex = 3;
            this.ptbLogo.TabStop = false;
            // 
            // clockControl1
            // 
            this.clockControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clockControl1.BackColor = System.Drawing.Color.Transparent;
            this.clockControl1.Location = new System.Drawing.Point(1007, 15);
            this.clockControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clockControl1.Name = "clockControl1";
            this.clockControl1.Size = new System.Drawing.Size(281, 63);
            this.clockControl1.TabIndex = 4;
            // 
            // KitchenScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.clockControl1);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.pnlOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "KitchenScreen";
            this.Size = new System.Drawing.Size(1333, 635);
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPageBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Panel lineGreen;
        private System.Windows.Forms.Panel orderContainerOuter;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.PictureBox btnPageNext;
        private System.Windows.Forms.PictureBox btnPageBack;
        private BootstrapButton btnRefresh;
        private BootstrapButton btnBack;
        private System.Windows.Forms.PictureBox ptbLogo;
        private ClockControl clockControl1;
    }
}
