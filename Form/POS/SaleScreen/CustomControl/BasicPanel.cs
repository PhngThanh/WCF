using System.Drawing;
using System.Windows.Forms;
using POS.Common;
using POS.Properties;

namespace POS.SaleScreen.CustomControl
{
    public class BasicPanel : UserControl
    {
        private Bitmap _bmpMainLogo;
        private Panel _pnlContainer;

        public string CashierName { get; set; }
        public string TerminalName { get; set; }
        public Bitmap MainLogo
        {
            get { return _bmpMainLogo; }
            set
            {
                var image = MainForm.GetImage((string)MainForm.StoreInfo.LogoSimple);
                _bmpMainLogo = new Bitmap(image, new Size(image.Width * 25 / image.Height, 25));
            }
        }

        public Panel ContainerPanel
        {
            get { return _pnlContainer; }
            set
            {
                if (_pnlContainer != null)
                {
                    Controls.Remove(_pnlContainer);
                }
                if (value == null)
                {
                    return;
                }
                _pnlContainer = value;
                _pnlContainer.Dock = DockStyle.Fill;
                Controls.Add(_pnlContainer);
                Controls.SetChildIndex(_pnlContainer, 0);
            }
        }

        public BasicPanel()
        {
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = DrawControlLibrary.BasicPanel.TopPanelHeight,
                BackColor = Constant.Brown
            };
            MainLogo = MainForm.GetImage((string)MainForm.StoreInfo.LogoSimple);
            pnlTop.Paint += (sender, args) => DrawControlLibrary.BasicPanel.DrawTopPanel(sender, args, CashierName, TerminalName, MainLogo);
            Controls.Add(pnlTop);

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 65,
                BackColor = Constant.Brown
            };
            Controls.Add(pnlBottom);
            var clock = new ClockControl
            {
                Dock = DockStyle.Left,
            };
            pnlBottom.Controls.Add(clock);
        }
    }
}
