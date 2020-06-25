using System;
using System.Drawing;
using System.Windows.Forms;
using POS.SaleScreen.CustomControl;
using System.Drawing.Text;

namespace POS.Common
{
    public class FlatTextBox : Panel
    {
        public FlatTextBox()
        {
            Width = 180;
            Height = 30;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            //Height = 30;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (Width - 20 < e.X && ShowClearButton)
            {
                TextValue = "";
                Value = "";
                if (ValueChange != null)
                {
                    ValueChange(this, e);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var formatCl = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            var formatCr = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            //var font = new Font(this.Font, 15, FontStyle.Bold);
            if (this.Active)
            {
                e.Graphics.DrawRectangle(new Pen(Constant.Brown), 0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(Constant.White), 1, 1, this.Width - 2, this.Height - 2);
                e.Graphics.DrawString(this.TextValue, this.Font, new SolidBrush(Constant.Brown),
                    new RectangleF(4, 1, this.Width - 8, this.Height - 2), formatCl);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(this.BorderColor), 0, 0, this.Width - 1, this.Height - 1);
                e.Graphics.FillRectangle(new SolidBrush(this.BackgroundColor), 1, 1, this.Width - 2,
                    this.Height - 2);
                e.Graphics.DrawString(this.TextValue, this.Font, new SolidBrush(this.TextColor),
                    new RectangleF(4, 1, this.Width - 8, this.Height - 2), formatCl);
            }
            if (!string.IsNullOrEmpty(this.TextValue) && this.ShowClearButton)
            {
                e.Graphics.DrawString("X", this.Font, new SolidBrush(Constant.GrayPanel), this.Width - 5,
                    this.Height / 2 + 2, formatCr);
            }
        }
        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }

        private bool _active;

        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                Invalidate();
            }
        }


        private Color _borderColor;

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }
        private Color _textColor;

        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                Invalidate();
            }
        }

        public bool ShowClearButton { get; set; }
        private string _textValue;
        public event EventHandler ValueChange;

        public string TextValue
        {
            get { return _textValue; }
            set
            {
                _textValue = value;
                Invalidate();
                if (ValueChange!=null)
                {
                    ValueChange(this, null);
                }
            }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Invalidate();
            }
        }
    }
}
