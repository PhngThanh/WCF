using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using POS;

namespace POS.Common
{
    public partial class InputFlatTextBox : UserControl
    {
        public InputFlatTextBox()
        {
            BorderSize = 1;
            BorderRadius = 2;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            textBox.Left = BorderSize * 2;
            textBox.Width = Width - BorderSize * 4;
            var path1 = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, Size), BorderRadius);
            var path2 =
                DrawUtility.DrawBorderRadiusRectangle(
                    new Rectangle(new Point(BorderSize - 1, BorderSize - 1), new Size(Width - BorderSize * 2, Height - BorderSize * 2)),
                    BorderRadius);
            e.Graphics.FillPath(new SolidBrush(Constant.Brown), path1);
            e.Graphics.DrawPath(new Pen(Constant.White, BorderSize), path2);
        }

        public int BorderSize { get; set; }

        public int BorderRadius { get; set; }
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }
        
        protected override void OnClick(EventArgs e)
        {
            textBox.Focus();
            base.OnClick(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            textBox.Focus();
            base.OnGotFocus(e);
        }
        protected override void OnFontChanged(EventArgs e)
        {
            textBox.Font = Font;
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            textBox.ForeColor = ForeColor;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }
        
        private void textBox_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
