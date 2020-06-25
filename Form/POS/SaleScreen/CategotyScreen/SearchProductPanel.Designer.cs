using System.Drawing;
using System.Windows.Forms;
using POS.Common;
using POS.SaleScreen.CustomControl;

namespace POS.SaleScreen
{
    partial class SearchProductPanel
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
            this.pnlInputGroup = new FlowLayoutPanel();
            this.txtInput = new LoginFlatTextBox();
            this.pnlProduct = new TableLayoutPanel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotesForm));
            // 
            // pnlInputGroup
            // 
            this.pnlInputGroup.Height = 880;
            this.pnlInputGroup.Width = 880;
            this.pnlInputGroup.FlowDirection = FlowDirection.LeftToRight;
            this.pnlInputGroup.Location = new System.Drawing.Point(20, 100);
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtInput.BorderRadius = 2;
            this.txtInput.BorderSize = 1;
            this.txtInput.ImageWidth = 0;
            this.txtInput.ImageZoom = 4;
            this.txtInput.Location = new System.Drawing.Point(50, 50);
            this.txtInput.Logo = null;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(289, 36);
            this.txtInput.TabIndex = 4;
            this.txtInput.Top += 10;
            this.txtInput.TextChanged += SearchProduct;
            this.txtInput.KeyUp += txtInput_KeyUp;
            //
            // pnlProduct
            //
            //this.pnlProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            //this.pnlProduct.Location = new Point(20, 100);
            //this.pnlProduct.BackColor = Color.Red;
            this.pnlProduct.Height = 400;
            this.pnlProduct.Width = 600;
            this.pnlInputGroup.Controls.Add(pnlProduct);
            // 
            // SearchProductPanel
            // 
            this.BackColor = Constant.GrayPanel;
            this.Padding = new Padding(5, DrawControlLibrary.CategoryPanel.Bottom, 5, DrawControlLibrary.CategoryPanel.Bottom * 3);//Chua khoang cach cho toppanel va bottompanel
            this.Dock = DockStyle.Fill;
            //this.Controls.Add(btnSearch);
            this.Controls.Add(txtInput);
            this.Controls.Add(pnlInputGroup);
            //this.Controls.Add(pnlProduct);
//            this.pnlInputGroup.Controls.Add(_numpad);
            //this.pnlInputGroup.Controls.Add(_keyboard);
        }

        #endregion

//        private static NumPadPanel _numpad = new NumPadPanel();
        private static OnScreenKeyboardPanel _keyboard = new OnScreenKeyboardPanel();
        private FlowLayoutPanel pnlInputGroup;
        private TableLayoutPanel pnlProduct;
        private LoginFlatTextBox txtInput;
        //private Common.FlexButton btnSearch;

    }
}
