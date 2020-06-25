using System.ComponentModel;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Properties;

namespace POS.TableScreen
{
    partial class TableScreen2
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
            this.tableContainerInner = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableContainerInner
            // 
            this.tableContainerInner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableContainerInner.BackColor = System.Drawing.Color.DimGray;
            this.tableContainerInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1820F));
            this.tableContainerInner.Location = new System.Drawing.Point(0, 62);
            this.tableContainerInner.Name = "tableContainerInner";
            this.tableContainerInner.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.tableContainerInner.Size = new System.Drawing.Size(1019, 500);
            this.tableContainerInner.TabIndex = 0;
            // 
            // TableScreen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableContainerInner);
            this.Name = "TableScreen2";
            this.Size = new System.Drawing.Size(1019, 611);
            this.ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableContainerInner;
    }
}
