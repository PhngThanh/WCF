using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class CircleButton : Panel
    {
        private Pen _pen;
        private Rectangle _regionRectangle;
        private Rectangle _imageRectangle;
       
        private int _margin = 5;
        private int _padding = 5;
        private int _radius = 30;

        
        public CircleButton()
        {
            InitializeComponent();
            ChangeLayoutProperty += CircleButton_ChangeLayoutProperty;
            BackColor = Color.Transparent;
        }

        private void CircleButton_ChangeLayoutProperty(object sender, EventArgs e)
        {
            Height = Width = (_radius + _margin) * 2;
            _regionRectangle = new Rectangle(_margin, _margin, _radius * 2, _radius * 2);
            _imageRectangle = new Rectangle(_margin + _padding, _margin + _padding, (_radius - _padding) * 2,
                (_radius - _padding) * 2);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(_regionRectangle);
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

        [Browsable(true), Category("Appearance"), DefaultValue(30), Description("Radius of circle")]
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
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
                pe.Graphics.FillEllipse(new SolidBrush(color1), _regionRectangle);//Fill all circle
            }
            else
            {
                _pen = new Pen(new SolidBrush(color1), 2);
                pe.Graphics.FillEllipse(new SolidBrush(color2), _regionRectangle);//Fill all circle
                pe.Graphics.DrawEllipse(_pen, 11,11, _regionRectangle.Width - 2, _regionRectangle.Height - 2);//Draw circle border
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
                    Color textColor = IsFocus ? color2 : color1;
                    pe.Graphics.DrawString(CenterText, font1, new SolidBrush(textColor), _regionRectangle, stringFormat);
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
