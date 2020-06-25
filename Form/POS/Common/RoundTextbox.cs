using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class RoundTextbox : UserControl
    {
        #region Properties

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Misc"), Browsable(true)]
        public bool ReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        public Color TextBoxColor
        {
            get { return textBox.BackColor; }
            set { textBox.BackColor = value; }
        }

        public int BorderThick
        {
            get { return _borderThick; }
            set
            {
                _borderThick = value;
                Invalidate();
            }
        }

        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        [Category("Misc"), Browsable(true)]
        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return textBox.TextAlign; }
            set { textBox.TextAlign = value; }
        }

        public char PasswordChar
        {
            get { return textBox.PasswordChar; }
            set { textBox.PasswordChar = value; }
        }

        #endregion


        private Color _borderColor;
        private int _borderThick;
        private int _borderRadius;

        public RoundTextbox()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);
            if (_borderRadius > 0)
            {
                // Adjust constant.
                int bottom = Height - 1;
                int right = Width - 1;

                // Path of expand field button.
                var boundPath = new GraphicsPath();
                boundPath.StartFigure();
                boundPath.AddArc(0, 0, 2 * BorderRadius, 2 * BorderRadius, 180, 90);
                boundPath.AddArc(right - 2 * BorderRadius, 0, 2 * BorderRadius, 2 * BorderRadius, 270, 90);
                boundPath.AddArc(right - 2 * BorderRadius, bottom - 2 * BorderRadius, 2 * BorderRadius, 2 * BorderRadius, 0, 90);
                boundPath.AddArc(0, bottom - 2 * BorderRadius, 2 * BorderRadius, 2 * BorderRadius, 90, 90);
                boundPath.CloseFigure();

                // Prepare fill brush.
                var brush = new SolidBrush(textBox.BackColor);

                // Fill background.
                e.Graphics.FillPath(brush, boundPath);

                // Draw border.
                if (_borderThick > 0)
                {
                    var pen = new Pen(_borderColor);
                    e.Graphics.DrawPath(pen, boundPath);
                }
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            textBox.Font = Font;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            textBox.ForeColor = ForeColor;
        }

        private void textBox_SizeChanged(object sender, EventArgs e)
        {
            Height = textBox.Height + 6;
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
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
