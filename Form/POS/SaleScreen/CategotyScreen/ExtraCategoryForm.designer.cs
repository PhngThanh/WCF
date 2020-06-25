using System.ComponentModel;
using System.Windows.Forms;

namespace POS.SaleScreen
{
    partial class ExtraCategoryForm
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
            this.pnlMainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlBottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFinish = new System.Windows.Forms.Panel();
            this.pnlTopPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 39);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Size = new System.Drawing.Size(720, 578);
            this.pnlMainContainer.TabIndex = 3;
            // 
            // pnlBottomPanel
            // 
            this.pnlBottomPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomPanel.BackColor = System.Drawing.Color.Red;
            this.pnlBottomPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlBottomPanel.Location = new System.Drawing.Point(0, 616);
            this.pnlBottomPanel.Name = "pnlBottomPanel";
            this.pnlBottomPanel.Size = new System.Drawing.Size(721, 44);
            this.pnlBottomPanel.TabIndex = 1;
            // 
            // lblFinish
            // 
            this.lblFinish.Location = new System.Drawing.Point(0, 0);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(200, 100);
            this.lblFinish.TabIndex = 0;
            // 
            // pnlTopPanel
            // 
            this.pnlTopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopPanel.BackColor = System.Drawing.Color.Red;
            this.pnlTopPanel.Location = new System.Drawing.Point(0, -2);
            this.pnlTopPanel.Name = "pnlTopPanel";
            this.pnlTopPanel.Size = new System.Drawing.Size(721, 44);
            this.pnlTopPanel.TabIndex = 2;
            // 
            // ExtraCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 660);
            this.Controls.Add(this.pnlTopPanel);
            this.Controls.Add(this.pnlMainContainer);
            this.Controls.Add(this.pnlBottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraCategoryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PropertiesPanel";
            this.ResumeLayout(false);

        }

        #endregion
        private Panel lblFinish;
        private FlowLayoutPanel pnlBottomPanel;
        private FlowLayoutPanel pnlTopPanel;
        private TableLayoutPanel pnlMainContainer;
    }
}
