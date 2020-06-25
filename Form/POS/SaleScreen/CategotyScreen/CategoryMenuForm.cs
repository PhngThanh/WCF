using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace POS.SaleScreen
{

    public partial class CategoryMenuForm : Form
    { 
        public CategoryMenuForm()
        {
            InitializeComponent();
            //StartPosition = FormStartPosition.CenterScreen;
            //Controls.Add(_topPanel);
            Left = Screen.PrimaryScreen.Bounds.Width - 290 - Width - 5;
            //Top = Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2 + 40;
            Top = Screen.PrimaryScreen.Bounds.Height / 2 - Height / 2 - 90;
            BackColor = Constant.DarkGrayPanel;
        }
       
        protected override void OnDeactivate(EventArgs e)
        {
            Hide();
        }
      
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Left = Screen.PrimaryScreen.Bounds.Width - 350 - this.Width;
            this.Show();
            this.Left = 50;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Constant.GrayPanel))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

    }
}
