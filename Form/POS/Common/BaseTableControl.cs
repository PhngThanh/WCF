using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class BaseTableControl : Panel
    {
        private Pen _pen;
        private Rectangle _regionRectangle;
        private Rectangle _imageRectangle;
       
        private int _margin = 5;
        private int _padding = 5;
        private int _radius = 30;
        private int _width = 30;
        private int _height = 30;

        public bool IsCircle { get; set; }

        public BaseTableControl()
        {
            InitializeComponent();
            ChangeLayoutProperty += CircleButton_ChangeLayoutProperty;
            BackColor = Color.Transparent;
        }

        private void CircleButton_ChangeLayoutProperty(object sender, EventArgs e)
        {
            Height = (_height + _margin) * 2;
            Width = (_width + _margin) * 2;
            _regionRectangle = new Rectangle(_margin, _margin, _width * 2, _height * 2);
            _imageRectangle = new Rectangle(_margin + _padding, _margin + _padding, 
                (_width - _padding) * 2, (_height - _padding) * 2);
            using (var path = new GraphicsPath())
            {
                if (IsCircle)
                {
                    path.AddEllipse(_regionRectangle);
                }
                else
                {
                    path.AddRectangle(_regionRectangle);
                }
                //Region = new Region(path);
            }
            Invalidate();
        }

        public event EventHandler ChangeLayoutProperty;

        [Browsable(true), Category("Appearance"), Description("Margin of circle to rectangle")]
        public new int Margin
        {
            get { return _margin; }
            set
            {
                if (value >= 0 && value != _margin)
                {
                    _margin = value;
                    CircleButton_ChangeLayoutProperty(null, null);
                }
            }
        }



        public bool IsFocus { get; set; }

        [Browsable(true), Category("Appearance"), Description("Margin of circle to rectangle")]
        public new int Padding
        {
            get { return _padding; }
            set
            {
                if (value >= 0 && value != _padding)
                {
                    _padding = value;
                    CircleButton_ChangeLayoutProperty(null, null);
                }
            }
        }

        [Browsable(true), Category("Appearance"), Description("Image at the center")]
        public Image CenterImage { get; set; }

        [Browsable(true), Category("Appearance"), Description("Text at the center")]
        public string CenterText { get; set; }
        public string MiniCenterText { get; set; }

        [Browsable(true), Category("Appearance"), DefaultValue(30), Description("Radius of circle")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                _height = _radius;
                _width = _radius;
                CircleButton_ChangeLayoutProperty(null, null);
            }
        }

        [Browsable(true), Category("Appearance"), DefaultValue(30), Description("Width of rectangle / Column")]
        public int Width1
        {
            get { return _width; }
            set
            {
                _width = value;
                CircleButton_ChangeLayoutProperty(null, null);
            }
        }

        [Browsable(true), Category("Appearance"), DefaultValue(30), Description("Height of rectangle / Row")]
        public int Height1
        {
            get { return _height; }
            set
            {
                _height = value;
                CircleButton_ChangeLayoutProperty(null, null);
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var color1 = ActiveColor;
            var color2 = NormalColor;

            if (IsFocus)
            {
                if (IsCircle)
                {
                    pe.Graphics.FillEllipse(new SolidBrush(color1), _regionRectangle);//Fill all circle
                }
                else
                {
                    pe.Graphics.FillRectangle(new SolidBrush(color1), _regionRectangle);//Fill all rectangle
                }
            }
            else
            {
                _pen = new Pen(new SolidBrush(color1), 2);
                if (IsCircle)
                {
                    pe.Graphics.FillEllipse(new SolidBrush(color2), _regionRectangle);//Fill all circle
                    pe.Graphics.DrawEllipse(_pen, 11, 11, _regionRectangle.Width - 2, _regionRectangle.Height - 2);//Draw circle border
                }
                else
                {
                    pe.Graphics.FillRectangle(new SolidBrush(color2), _regionRectangle);//Fill all rectangle
                    pe.Graphics.DrawRectangle(_pen, 11, 11, _regionRectangle.Width - 2, _regionRectangle.Height - 2);//Draw rectangle border
                }
            }

            if (CenterText != "")
            {
                using (var font1 = new Font("Tahoma", 20, FontStyle.Bold, GraphicsUnit.Point))
                {
                    // Create a StringFormat object with the each line of text, and the block 
                    // of text centered on the page.
                    var stringFormat = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    // Draw the text and the surrounding rectangle.
                    if (IsFocus && !IsCircle)
                    {
                        var textColor = color2;
                        var fontMini = new Font("Tahoma", 15, FontStyle.Bold, GraphicsUnit.Point);

                        // x,y : middle point
                        var x = _regionRectangle.X + (_regionRectangle.Width / 2);
                        var y = _regionRectangle.Y + (_regionRectangle.Height / 2);
                        
                        //Draw TableNumber
                        pe.Graphics.DrawString(CenterText, font1, new SolidBrush(textColor), x, y - 6, stringFormat);
                        //Draw CurrentOrderDate
                        pe.Graphics.DrawString(MiniCenterText, fontMini, new SolidBrush(textColor), x, y + (_regionRectangle.Height / 4), stringFormat);
                    } 
                    else if (IsFocus)
                    {
                        var textColor = color2;
                        pe.Graphics.DrawString(CenterText, font1, new SolidBrush(textColor), _regionRectangle, stringFormat);
                    }
                    else
                    {
                        var textColor = color1;
                        pe.Graphics.DrawString(CenterText, font1, new SolidBrush(textColor), _regionRectangle, stringFormat);
                    }
                }
            }

            if (CenterImage == null) return;
            var rect = new Rectangle(_imageRectangle.X + 12, _imageRectangle.Y + 12,
                _imageRectangle.Width - 24, _imageRectangle.Height - 24);
            pe.Graphics.DrawImage(CenterImage, rect);
        }

        public Color NormalColor { get; set; }

        public Color ActiveColor { get; set; }

        private void CircleButton_Click(object sender, EventArgs e)
        {
           
        }

        protected virtual void OnChangeLayoutProperty()
        {
            var handler = ChangeLayoutProperty;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
