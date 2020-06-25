using System.ComponentModel;
using System.Windows.Forms;

namespace POS.SaleScreen
{
    partial class KitchenOrderItemList
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
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.lblUp = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.pnlItemContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPaging.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPaging
            // 
            this.pnlPaging.Controls.Add(this.lblUp);
            this.pnlPaging.Controls.Add(this.lblDown);
            this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaging.Location = new System.Drawing.Point(0, 196);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(288, 60);
            this.pnlPaging.TabIndex = 0;
            this.pnlPaging.Visible = false;
            // 
            // lblUp
            // 
            this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.ForeColor = System.Drawing.Color.Transparent;
            this.lblUp.Location = new System.Drawing.Point(148, 10);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(90, 40);
            this.lblUp.TabIndex = 0;
            // 
            // lblDown
            // 
            this.lblDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.ForeColor = System.Drawing.Color.Transparent;
            this.lblDown.Location = new System.Drawing.Point(50, 10);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(90, 40);
            this.lblDown.TabIndex = 0;
            // 
            // pnlItemContainer
            // 
            this.pnlItemContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItemContainer.AutoSize = true;
            this.pnlItemContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlItemContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlItemContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlItemContainer.Name = "pnlItemContainer";
            this.pnlItemContainer.Size = new System.Drawing.Size(288, 10);
            this.pnlItemContainer.TabIndex = 1;
            // 
            // OrderPanelItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlPaging);
            this.Controls.Add(this.pnlItemContainer);
            this.Name = "OrderPanelItemList";
            this.Size = new System.Drawing.Size(288, 256);
            this.pnlPaging.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlPaging;
        public FlowLayoutPanel pnlItemContainer;
        private Label lblUp;
        private Label lblDown;
    }
}
