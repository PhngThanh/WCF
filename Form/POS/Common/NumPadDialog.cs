using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.Repository;

namespace POS.Common
{

    public partial class NumPadDialog : Form
    {
        private const int CallOutWidth = 10;
        private const int CallOutHeight = 20;

        private readonly CallOutPositionEnum _callOutPosition;
        private readonly Form _callOut;
        private readonly Control _textbox;

        public NumPadDialog(Control textbox, CallOutPositionEnum callOutPosition)
        {
            InitializeComponent();

            _textbox = textbox;
            _callOutPosition = callOutPosition;

            _textbox.Click += _textbox_Click;

            // Create call out.
            _callOut = new Form();
            _callOut.FormBorderStyle = FormBorderStyle.None;
            _callOut.ShowInTaskbar = false;

            // Cut to triangle.
            var region = new GraphicsPath();
            switch (callOutPosition)
            {
                case CallOutPositionEnum.BottomRight:
                    region.StartFigure();
                    region.AddLine(0, 0, CallOutWidth, CallOutHeight / 2);
                    region.AddLine(CallOutWidth, CallOutHeight / 2, 0, CallOutHeight);
                    region.CloseFigure();
                    break;
                case CallOutPositionEnum.MiddleLeft:
                    region.StartFigure();
                    region.AddLine(CallOutWidth, 0, 0, CallOutHeight / 2);
                    region.AddLine(0, CallOutHeight / 2, CallOutWidth, CallOutHeight);
                    region.CloseFigure();
                    break;
                case CallOutPositionEnum.TopCenter:

                    break;
            }
            NormalNumber = false;
            _callOut.Region = new Region(region);
            _callOut.BackColor = Color.FromArgb(124, 124, 124);
        }

        public bool NormalNumber { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawLine(Pens.White, btn1.Right, 5, btn1.Right, Height - 5);
            e.Graphics.DrawLine(Pens.White, btn2.Right, 5, btn2.Right, Height - 5);
            e.Graphics.DrawLine(Pens.White, 5, btn1.Bottom, Width - 5, btn1.Bottom);
            e.Graphics.DrawLine(Pens.White, 5, btn4.Bottom, Width - 5, btn4.Bottom);
            e.Graphics.DrawLine(Pens.White, 5, btn7.Bottom, Width - 5, btn7.Bottom);
        }

        private void NumPadDialog_LocationChanged(object sender, EventArgs e)
        {
            switch (_callOutPosition)
            {
                case CallOutPositionEnum.BottomRight:
                    _callOut.Left = Right;
                    _callOut.Top = Bottom - CallOutHeight - 5;
                    break;
                case CallOutPositionEnum.MiddleLeft:
                    _callOut.Left = Left - CallOutWidth;
                    _callOut.Top = Top + (Height - CallOutHeight) / 2;
                    break;
                case CallOutPositionEnum.TopCenter:

                    break;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = sender as FlexButton;
            if (btn == null) return;

            if (btn == btn1 && (_textbox.TabIndex == 0 || (int.MaxValue - 1) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 1;
            }
            if (btn == btn2 && (_textbox.TabIndex == 0 || (int.MaxValue - 2) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 2;
            }
            if (btn == btn3 && (_textbox.TabIndex == 0 || (int.MaxValue - 3) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 3;
            }
            if (btn == btn4 && (_textbox.TabIndex == 0 || (int.MaxValue - 5) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 4;
            }
            if (btn == btn5 && (_textbox.TabIndex == 0 || (int.MaxValue - 5) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 5;
            }
            if (btn == btn6 && (_textbox.TabIndex == 0 || (int.MaxValue - 6) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 6;
            }
            if (btn == btn7 && (_textbox.TabIndex == 0 || (int.MaxValue - 7) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 7;
            }
            if (btn == btn8 && (_textbox.TabIndex == 0 || (int.MaxValue - 8) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 8;
            }
            if (btn == btn9 && (_textbox.TabIndex == 0 || (int.MaxValue - 9) / _textbox.TabIndex > 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10 + 9;
            }
            if (btn == btn0 && (_textbox.TabIndex == 0 || int.MaxValue / _textbox.TabIndex >= 10))
            {
                _textbox.TabIndex = _textbox.TabIndex * 10;
            }
            if (btn == btn000 && (_textbox.TabIndex == 0 || int.MaxValue / _textbox.TabIndex >= 1000))
            {
                _textbox.TabIndex = _textbox.TabIndex * 1000;
            }
            if (btn == btnDel)
            {
                _textbox.TabIndex = _textbox.TabIndex / 10;

                if (!string.IsNullOrEmpty(_textbox.Text))
                {
                    _textbox.Text = _textbox.Text.Substring(0, _textbox.Text.Length - 1);
                }
            }
            _textbox.Text = string.Format(NormalNumber ? "{0}" : "{0:n0} VND", _textbox.TabIndex);
        }

        private void NumPadDialog_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        private void _textbox_Click(object sender, EventArgs e)
        {
            if (NormalNumber)
            {
                _textbox.Text = _textbox.TabIndex.ToString();
            }
            else
            {
                _textbox.TabIndex = 0;
                _textbox.Text = "0";
            }
            Show();
            TopMost = true;
            var location = _textbox.PointToScreen(Point.Empty);
            switch (_callOutPosition)
            {
                case CallOutPositionEnum.BottomRight:
                    Left = location.X - Width - CallOutWidth;
                    Top = location.Y + (_textbox.Height - CallOutHeight) / 2 - (Height - CallOutHeight - 5);
                    break;
                case CallOutPositionEnum.MiddleLeft:
                    Left = location.X + _textbox.Width + CallOutWidth;
                    Top = location.Y + (_textbox.Height - Height) / 2;
                    break;
                case CallOutPositionEnum.TopCenter:
                    Left = location.X + _textbox.Width / 2 - Width;
                    Top = location.Y + _textbox.Height + CallOutHeight;
                    break;
            }
        }

        private void NumPadDialog_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _callOut.Show();
                _callOut.TopMost = true;
                _callOut.Width = CallOutWidth;
                _callOut.Height = CallOutHeight;
            }
            else
            {
                _callOut.Hide();
            }
        }

        private void NumPadDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
