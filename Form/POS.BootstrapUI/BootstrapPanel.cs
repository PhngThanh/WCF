using System.ComponentModel;
using System.Windows.Forms;

namespace POS.CustomControl
{
    public partial class BootstrapPanel : Panel
    {
        public BootstrapPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

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
                this.BackColor = ColorScheme.GetColor(value);
                Refresh();
            }
        }
    }
}
