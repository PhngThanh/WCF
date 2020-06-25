using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using POS;

namespace POS.Common
{
    public partial class LoginFlatTextBox : UserControl
    {
        public LoginFlatTextBox()
        {
            BorderSize = 1;
            BorderRadius = 2;
            ImageZoom = 4;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            pictureBox1.Top = BorderSize * ImageZoom;
            pictureBox1.Left = BorderSize * ImageZoom;
            textBox.Left = BorderSize * 2;
            textBox.Width = Width - BorderSize * 4;
            pictureBox1.Height = Height - BorderSize * ImageZoom * 2;
            var path1 = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, Size), BorderRadius);
            var path2 =
                DrawUtility.DrawBorderRadiusRectangle(
                    new Rectangle(new Point(BorderSize - 1, BorderSize - 1), new Size(Width - BorderSize * 2, Height - BorderSize * 2)),
                    BorderRadius);
            e.Graphics.FillPath(new SolidBrush(Constant.Brown), path1);
            e.Graphics.DrawPath(new Pen(Constant.White, BorderSize), path2);
        }

        public Image Logo
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public int ImageWidth
        {
            get { return pictureBox1.Width; }
            set { pictureBox1.Width = value; }
        }

        public int ImageZoom { get; set; }

        public int BorderSize { get; set; }

        public int BorderRadius { get; set; }
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }
        
        public char PasswordChar
        {
            get { return textBox.PasswordChar; }
            set { textBox.PasswordChar = value; }
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
