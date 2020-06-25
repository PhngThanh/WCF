using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Common;

namespace POS.SaleScreen.CustomControl
{
    public partial class CurveButtonRight : Label
    {
        public CurveButtonRight()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
                pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                var path = DrawUtility.DrawSmoothEdgeRectangleWithHaft(0, 0, 290,
                    42 - 4, -4, 4, 180);
                pe.Graphics.FillPath(new SolidBrush(Constant.Orange), path);
                pe.Graphics.DrawPath(new Pen(Constant.White, 1), path);
                var font = new Font(new FontFamily(GenericFontFamilies.SansSerif), 11, FontStyle.Bold);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var x = (float)((180) / 2.0);
                var y = (float)(42 / 2.0) + 3;
                pe.Graphics.DrawString(this.Text, font, new SolidBrush(Constant.White), x, y, format);
                //textBox.Width = 180 - 2;
                //textBox.Height = 42 + 2;

            base.OnPaint(pe);
        }
    }
}
