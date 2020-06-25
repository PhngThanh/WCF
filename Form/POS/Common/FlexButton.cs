using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.Common
{
    public partial class FlexButton : UserControl
    {
        #region Properties

        /// <summary>
        /// Color of the button on normal state.
        /// </summary>
        public Color NormalColor
        {
            get { return _normalColor; }
            set
            {
                _normalColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Color of the button on pressed state.
        /// </summary>
        public Color PressColor
        {
            get { return _pressColor; }
            set
            {
                _pressColor = value;
                Invalidate();
            }
        }

        public Color ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Color of the button on disabled state.
        /// </summary>
        public Color DisableColor
        {
            get { return _disableColor; }
            set
            {
                _disableColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Border color of the button.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Border thick of the button.
        /// </summary>
        public int BorderThick
        {
            get { return _borderThick; }
            set
            {
                _borderThick = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Border radius of the button, must > 0.
        /// </summary>
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The gap between left image and text.
        /// </summary>
        public int LeftImageGap
        {
            get { return _leftImageGap; }
            set
            {
                _leftImageGap = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Left image on normal state.
        /// </summary>
        public Image LeftImageNornal
        {
            get { return _leftImageNormal; }
            set
            {
                _leftImageNormal = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Left image on pressed state.
        /// </summary>
        public Image LeftImagePress
        {
            get { return _leftImagePress; }
            set
            {
                _leftImagePress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Left image on disabled state.
        /// </summary>
        public Image LeftImageDisable
        {
            get { return _leftImageDisable; }
            set
            {
                _leftImageDisable = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Center image on normal state.
        /// </summary>
        public Image CenterImageNormal
        {
            get { return _centerImageNormal; }
            set
            {
                _centerImageNormal = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Center image on pressed state.
        /// </summary>
        public Image CenterImagePress
        {
            get { return _centerImagePress; }
            set
            {
                _centerImagePress = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Center image on disabled state.
        /// </summary>
        public Image CenterImageDisable
        {
            get { return _centerImageDisable; }
            set
            {
                _centerImageDisable = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The text to be displayed.
        /// </summary>
        public string Caption
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate();
            }
        }

        #endregion

        #region Private Members

        private Color _normalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        private Color _pressColor = ColorScheme.GetColor(BootstrapColorEnum.BackColor);
        private Color _foreColor = ColorScheme.GetColor(BootstrapColorEnum.BackColor);
        private Color _disableColor;
        private Color _borderColor;
        private int _borderThick;
        private int _borderRadius;
        private int _leftImageGap;
        private Image _leftImageNormal;
        private Image _leftImagePress;
        private Image _leftImageDisable;
        private Image _centerImageNormal;
        private Image _centerImagePress;
        private Image _centerImageDisable;
        private string _text;
        private bool _pressed;
        private readonly Action _playClickSound;

        #endregion

      

        private bool _isActivated;

        public bool IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                Invalidate();
            }
        }


        public FlexButton()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get { return Caption; }
            set { Caption = value; }
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

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
                var brush = new SolidBrush(NormalColor);
                if (_pressed || _isActivated) brush = new SolidBrush(PressColor);
                if (!Enabled) brush = new SolidBrush(DisableColor);

                // Fill background.
                e.Graphics.FillPath(brush, boundPath);

                // Draw border.
                if (_borderThick > 0)
                {
                    var pen = new Pen(_borderColor);
                    e.Graphics.DrawPath(pen, boundPath);
                }

                // Draw image.
                if (_centerImageNormal != null && _centerImagePress != null)
                {
                    var width = Width * 0.6;
                    var height = Height * 0.6;
                    var drawImg = DrawUtility.Resize((_pressed || _isActivated) ? _centerImagePress : _centerImageNormal,
                        (int)width, (int)height);
                    if (!Enabled && _centerImageDisable != null) drawImg = _centerImageDisable;

                    e.Graphics.DrawImageUnscaled(drawImg, new Rectangle((int)((Width - width) / 2),
                        (int)((Height - height) / 2), (int)width, (int)height));
                }
                else
                {
                    var txtBrush = new SolidBrush((_pressed || _isActivated) ? _normalColor : _pressColor);
                    var size = e.Graphics.MeasureString(_text, Font);
                    if (_leftImageNormal != null && _leftImagePress != null)
                    {
                        var drawImg = (_pressed || _isActivated) ? _leftImagePress : _leftImageNormal;
                        if (!Enabled && _leftImageDisable != null) drawImg = _leftImageDisable;

                        var contentW = Width - (drawImg.Width + LeftImageGap + size.Width);
                        var contentH = Height - size.Height;

                        e.Graphics.DrawImage(drawImg, contentW / 2, (Height - drawImg.Height) / 2f);
                        e.Graphics.DrawString(_text, Font, txtBrush, contentW / 2 + drawImg.Width + LeftImageGap,
                            contentH / 2);
                    }
                    else
                    {
                        var contentW = Width - size.Width;
                        var contentH = Height - size.Height;
                        e.Graphics.DrawString(_text, Font, txtBrush, contentW / 2, contentH / 2);
                    }
                }
            }
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                PlayClickSound();
                _pressed = true;
                Invalidate();
                timer.Start();
            }
        }

        private void PlayClickSound()
        {
            if (_playClickSound != null)
            {
                _playClickSound();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            StopTimer();

            if (e.Button == MouseButtons.Left)
            {
                _pressed = false;
                Invalidate();
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            _pressed = false;
            Invalidate();
            if (!Enabled)
            {
                StopTimer();
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            StopTimer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PlayClickSound();
            OnClick(null);
            timer.Interval = 150;
        }

        private void StopTimer()
        {
            timer.Stop();
            timer.Interval = 500;
        }


    }
}
