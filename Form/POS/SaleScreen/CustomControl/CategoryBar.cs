using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen.CustomControl
{
    public partial class CategoryBar : Panel
    {
        public CategoryBar()
        {
            InitializeComponent();
            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //top category
            int borderThick = 2;
            var rect = new Rectangle(0, 2, Width, Height-4);
            e.Graphics.DrawRectangle(new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor), 2), rect);
            //rect = new Rectangle(rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
            //e.Graphics.FillRectangle(new SolidBrush(Constant.White), rect);
        }
    }
}
