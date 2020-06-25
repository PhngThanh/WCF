using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS.SaleScreen.CustomControl
{
    sealed partial class ProductItemControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        //private Label _minusLabel = new Label();
        //private Label _addLabel = new Label();
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
            components = new System.ComponentModel.Container();
            //init minusLabel
            _minusLabel.MouseUp += MouseUp_Event;
            _minusLabel.Paint += Paint_Event;
            _minusLabel.Text = "-";
            _minusLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            _addLabel.MouseUp += MouseUp_Event;
            _addLabel.Paint += Paint_Event;
            _addLabel.Text = "+";
            _addLabel.TextAlign = ContentAlignment.MiddleCenter;
            //_minusLabel.Width = 51;
            //addLabel.Width = 50;
            //_minusLabel.Height = 56;
            //_addLabel.Height = 56;
            //_minusLabel.Top = 65;
            //_minusLabel.Left = 2;
            //_addLabel.Top = 65;
            //_addLabel.Left = 54;
           // _minusLabel.MouseDown += MouseDown_Event;
           
           // _addLabel.MouseDown += MouseDown_Event;
           
            this.Controls.Add(_minusLabel);
            this.Controls.Add(_addLabel);
        }

        #endregion

        private Label _minusLabel = new Label();
        private Label _addLabel = new Label();
    }
}
