using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS.CustomControl
{
    public partial class BootstrapButton : PictureBox
    {
        FontAwesome fontAwesome = new FontAwesome();
        Image image;

        private bool _pressed;//handle color when user press button

        public BootstrapButton()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.CenterImage;
            textFont = null;
            defaultEmptyFont = new Font(Font, FontStyle.Italic);

            this.Click += BootstrapButton_Click;
        }

        private int _borderRadius;
        [Browsable(true)]
        [Description("Border radius of the button, must > 0."), Category("Data")]
        [DefaultValue(2)]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                Invalidate();
            }
        }

        private int _borderThick;
        [Browsable(true)]
        [Description("Border thick of the button, must > 0."), Category("Data")]
        [DefaultValue(2)]
        public int BorderThick
        {
            get { return _borderThick; }
            set
            {
                _borderThick = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            base.OnPaint(e);
            if (_borderThick > 0 && _borderRadius > 0)
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
                //var brush = new SolidBrush(BorderColor);
                //if (_pressed ||isActive)
                //    brush = new SolidBrush(ActiveBackgroudColor);
                //e.Graphics.FillPath(brush, boundPath);

                //if (!Enabled) brush = new SolidBrush(DisableColor);

                //// Fill background.
                //e.Graphics.FillPath(brush, boundPath);

                // Draw border.
                //if (_borderThick > 0)
                //{
                var pen = new Pen(Color.White, _borderThick);
                e.Graphics.DrawPath(pen, boundPath);
                //}
            }
        }

        #region Image
        string imageCss = "";
        [Description("Font Awesome CSS class"), Category("Data")]
        public string ImageCss
        {
            get { return imageCss; }
            set
            {
                imageCss = value;
                RenderImage();
            }
        }

        [Description("Padding between image and text"), Category("Data")]
        public int ImageTextPadding { get; set; }


        Color imageColor = Color.White;
        [Description("Color of image"), Category("Data")]
        [Browsable(true)]
        public Color ImageColor
        {
            get
            {
                return imageColor;
            }
            set
            {
                imageColor = value;
                RenderImage();

            }
        }


        float imageFontSize = 16;
        [Description("Size of image"), Category("Data")]
        [DefaultValue(16)]
        public float ImageFontSize
        {
            get
            {
                return imageFontSize;
            }
            set
            {
                imageFontSize = value;
                RenderImage();
            }
        }

        //        private Size minimumSize;
        //        [Browsable(true)]
        //        [Description("Minimun size of control"), Category("Data")]
        //        public Size MinimumSize
        //        {
        //            get { return this.minimumSize; }
        //            set
        //            {
        //                this.minimumSize = value;
        //                RenderImage();
        //            }
        //        }
        //
        //        private Size maximumSize;
        //        [Browsable(true)]
        //        [Description("Maximun size of control"), Category("Data")]
        //        public Size MaximumSize
        //        {
        //            get { return this.maximumSize; }
        //            set
        //            {
        //                this.maximumSize = value;
        //                RenderImage();
        //            }
        //        }

        private void RenderImage()
        {

            if (!String.IsNullOrEmpty(imageCss))
            {
                this.Image = this.fontAwesome.GenerateIconWithText(imageCss, ImageFontSize, ImageColor,
                    TextValue, TextFont, TextColor, 5, ImageTextPadding, IsVerticalImageText);
            }

            if (_isAutoScaleWidth)
            {
                Size = new Size(this.Image.Size.Width + 10, this.Image.Size.Height + 10);
            }

            //            int width = this.Size.Width;
            //            if (this.minimumSize.Width > 0)
            //            {
            //                width = Math.Max(this.minimumSize.Width, this.Size.Width);
            //            }
            //
            //            if (this.maximumSize.Width > 0)
            //            {
            //                width = Math.Min(this.maximumSize.Width, this.Size.Width);
            //            }
            //
            //            int height = this.Size.Height;
            //            if (this.minimumSize.Height > 0)
            //            {
            //                height = Math.Max(this.minimumSize.Height, this.Size.Height);
            //            }
            //
            //            if (this.maximumSize.Height > 0)
            //            {
            //                height = Math.Min(this.maximumSize.Height, this.Size.Height);
            //            }
            //
            //            this.Size = new Size(width, height);

            if (type == ButtonType.Toggle && isActive)
            {
                if (isActive)
                {
                    this.BackColor = activeBackgroundColor;
                }
                else
                {
                    this.BackColor = ColorScheme.GetColor(backgroundBootstrapColor);
                }
            }

            Refresh();
        }



        private string textValue = "";
        [Description("Text in control"), Category("Data")]
        public string TextValue
        {
            get
            {
                return textValue;
            }
            set
            {
                textValue = value;
                RenderImage();
            }
        }



        private Font textFont, defaultEmptyFont;

        [Browsable(true)]
        [AmbientValue(typeof(Font), null), Category("Appearance")]
        public Font TextFont
        {
            get { return (textFont == null) ? defaultEmptyFont : textFont; }
            set
            {
                textFont = value;
                RenderImage();
            }
        }



        Color textColor = Color.White;
        [Description("Color of text"), Category("Data")]
        [Browsable(true)]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                RenderImage();

            }
        }



        #endregion

        #region BackgroundColor
        private BootstrapColorEnum backgroundBootstrapColor;
        [Browsable(true)]
        [Description("Bootstrap color name for background color"), Category("Data")]
        public BootstrapColorEnum BackgroudBootstrapColor
        {
            get
            {
                return backgroundBootstrapColor;
            }
            set
            {
                backgroundBootstrapColor = value;
                //                this.ActiveBackgroudColor = ColorScheme.GetColor(value);
                this.BackColor = ColorScheme.GetColor(value);
                Refresh();
            }

        }

        private BootstrapColorEnum activeBackgroundBootstrapColor;
        [Browsable(true)]
        [Description("Bootstrap color name for active background color"), Category("Data")]
        public BootstrapColorEnum ActiveBackgroudBootstrapColor
        {
            get
            {
                return activeBackgroundBootstrapColor;
            }
            set
            {
                activeBackgroundBootstrapColor = value;
                this.activeBackgroundColor = ColorScheme.GetColor(value);
                Refresh();
            }
        }


        #region Toggle Button

        private bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }
            set
            {
                isActive = value;

                if (isActive)
                {
                    this.BackColor = activeBackgroundColor;
                }
                else
                {
                    this.BackColor = ColorScheme.GetColor(backgroundBootstrapColor);
                }
            }
        }



        [Browsable(true)]
        [Description("Toggle Group button"), Category("Data")]
        public int ToggleGroup
        {
            get;
            set;
        }

        private ButtonType type;
        [Browsable(true)]
        [Description("Buttom Type"), Category("Data")]
        public ButtonType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        void BootstrapButton_Click(object sender, EventArgs e)
        {
            if (type == ButtonType.Toggle)
            {
                bool newActiveState = !isActive;

                if (this.Parent.Controls != null)
                {
                    foreach (var c in this.Parent.Controls)
                    {
                        if ((c is BootstrapButton) && (c as BootstrapButton).Type == ButtonType.Toggle
                                       && (c as BootstrapButton).ToggleGroup == this.ToggleGroup)
                        {
                            (c as BootstrapButton).IsActive = false;
                        }
                    }
                }

                isActive = newActiveState;
                RenderImage();
            }
        }





        #endregion




        private Color activeBackgroundColor;
        [Browsable(true)]
        [Description("Color of control when active. Valid in Toggle mode only"), Category("Data")]
        public Color ActiveBackgroudColor
        {
            get
            {
                return activeBackgroundColor;
            }
            set
            {
                activeBackgroundColor = value;

            }
        }






        #endregion


        string buttonValue = "";
        [Browsable(true)]
        [Description("Value of button"), Category("Data")]
        public string ButtonValue
        {
            get { return buttonValue; }
            set
            {
                buttonValue = value;
            }
        }


        bool isVertical = false;
        [Browsable(true)]
        [Description("Set flow is vertical or not"), Category("Data")]
        public bool IsVerticalImageText
        {
            get
            {
                return isVertical;
            }
            set
            {
                isVertical = value;
                RenderImage();
            }
        }

        bool _isAutoScaleWidth = false;
        [Browsable(true)]
        [Description("Auto scale control"), Category("Data")]
        public bool IsAutoScaleWidth
        {
            get
            {
                return _isAutoScaleWidth;
            }
            set
            {
                _isAutoScaleWidth = value;
                RenderImage();
            }
        }
    }


    public enum ButtonType
    {
        Click,
        Toggle
    }
}
