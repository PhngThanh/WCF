using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class ProductAttributePanel
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
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesForm));
            this.pnlAttributeContainer = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlAttributeContainer
            // 
            this.pnlAttributeContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right))));
            this.pnlAttributeContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlAttributeContainer.Location = new System.Drawing.Point(400, 0);
            this.pnlAttributeContainer.Name = "pnlAttributeContainer";
            this.pnlAttributeContainer.Size = new System.Drawing.Size(400, 659);
//            this.pnlAttributeContainer.Size = new System.Drawing.Size(721, 617);
            this.pnlAttributeContainer.TabIndex = 3;
//            //
//            // pnlNotes
//            //
//            this.pnlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.pnlNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
//            this.pnlNotes.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
//            this.pnlNotes.Location = new System.Drawing.Point(401, 0);
//            this.pnlNotes.Name = "pnlNotes";
//            this.pnlNotes.Size = new System.Drawing.Size(360, 655);
            // ProductAttributeForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 660);
            this.Controls.Add(this.pnlAttributeContainer);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.KeyPreview = true;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.Name = "ProductAttributeForm";
            //this.ShowInTaskbar = false;
            //this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PropertiesPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel pnlAttributeContainer;

    }
}
