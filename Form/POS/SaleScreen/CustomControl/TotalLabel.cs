using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace POS.SaleScreen.CustomControl
{
    public partial class TotalLabel : Panel
    {
        public TotalLabel()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
        public string Amount { get; set; }
        public TotalLabel(string title, string amount, int width)
        {
            Height = 35;
            Width = width;
            Title = title;
            Amount = amount;
        }

        float titleFontSize = 15;
        [Browsable(true)]
        [Description("Set font size of title"), Category("Data")]
        public float TitleFontSize
        {
            get
            {
                return titleFontSize;
            }
            set
            {
                titleFontSize = value;
            }
        }

        float amountFontSize = 15;
        [Browsable(true)]
        [Description("Set font size of amount"), Category("Data")]
        public float AmountFontSize
        {
            get
            {
                return amountFontSize;
            }
            set
            {
                amountFontSize = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var titleFont = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], TitleFontSize, FontStyle.Bold);
            var amountFont = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], AmountFontSize, FontStyle.Regular);

            var format = new StringFormat
            {
                Alignment = StringAlignment.Far
            };

            e.Graphics.DrawString(
                Title
                , titleFont, new SolidBrush(Constant.Brown), 5, 5);
            e.Graphics.DrawString(Amount, amountFont, new SolidBrush(Constant.Brown), Width, 5, format);
            //e.Graphics.DrawString(Amount, fontM, new SolidBrush(Constant.Brown), Width - 22, 5, format);
        }
    }
}
