namespace POS.SaleScreen
{
    partial class CategoryPanel1
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
            this.tlpProductContainer = new System.Windows.Forms.TableLayoutPanel();
            this.barBottom = new POS.SaleScreen.CustomControl.CategoryBar();
            this.barTop = new POS.SaleScreen.CustomControl.CategoryBar();
//            this.barMore = new POS.SaleScreen.CustomControl.CategoryBar();
            this.SuspendLayout();
            // 
            // tlpProductContainer
            // 
            this.tlpProductContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpProductContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.tlpProductContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 628F));
            this.tlpProductContainer.Location = new System.Drawing.Point(0, 50);
            this.tlpProductContainer.Name = "tlpProductContainer";
            this.tlpProductContainer.Size = new System.Drawing.Size(628, 400);
            this.tlpProductContainer.TabIndex = 2;
            // 
            // barBottom
            // 
            this.barBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barBottom.BackColor = System.Drawing.Color.White;
            this.barBottom.Location = new System.Drawing.Point(0, 450);
            this.barBottom.Margin = new System.Windows.Forms.Padding(0);
            this.barBottom.Name = "barBottom";
            this.barBottom.Size = new System.Drawing.Size(628, 50);
            this.barBottom.TabIndex = 1;
            // 
            // barTop
            // 
            this.barTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barTop.BackColor = System.Drawing.Color.White;
            this.barTop.Location = new System.Drawing.Point(0, 0);
            this.barTop.Margin = new System.Windows.Forms.Padding(0);
            this.barTop.Name = "barTop";
            this.barTop.Size = new System.Drawing.Size(628, 50);
            this.barTop.TabIndex = 0;
//            // 
//            // barMore
//            // 
//            this.barMore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.barMore.BackColor = System.Drawing.Color.White;
//            this.barMore.Location = new System.Drawing.Point(0, 401);
//            this.barMore.Margin = new System.Windows.Forms.Padding(0);
//            this.barMore.Name = "barMore";
//            this.barMore.Size = new System.Drawing.Size(628, 50);
//            this.barMore.TabIndex = 1;
//            this.barMore.Visible = false;
            // 
            // CategoryPanel1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.Controls.Add(this.tlpProductContainer);
            this.Controls.Add(this.barBottom);
            this.Controls.Add(this.barTop);
//            this.Controls.Add(this.barMore);
            this.Name = "CategoryPanel1";
            this.Size = new System.Drawing.Size(628, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControl.CategoryBar barTop;
        private CustomControl.CategoryBar barBottom;
        private System.Windows.Forms.TableLayoutPanel tlpProductContainer;
//        private CustomControl.CategoryBar barMore;
    }
}
