using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.Common
{
    public partial class MessageDialog : Form
    {
        public MessageDialog(string message, string okText, string cancelText)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            //TRUNGLQ:
            //Add ShowInTaskBar = False trong Property

            lbMessage.Text = message;
            btnNegative.Caption = cancelText;
            btnPositive.Caption = okText;

            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = false;

        }

        public MessageDialog(string message, string normalButton)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            lbMessage.Text = message;
            btnNormal.Caption = normalButton;

            btnNegative.Visible = false;
            btnPositive.Visible = false;
            btnNormal.Visible = true;
        }

        public MessageDialog(string message, string positiveButtonText, string negativeButtonText, string normalButtonText)
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            //Set Caption
            lbMessage.Text = message;
            btnPositive.Caption = positiveButtonText;
            btnNegative.Caption = negativeButtonText;
            btnNormal.Caption = normalButtonText;

            //Change position
            btnPositive.Location = new Point(20, 103);
            btnNegative.Location = new Point(150, 103);
            btnNormal.Location = new Point(280, 103);

            //Change Color
            btnNormal.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnNormal.PressColor = Color.White;
            btnNegative.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnNegative.PressColor = Color.White;
            btnPositive.NormalColor = Color.White;
            btnPositive.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

            //Show all buttons
            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(124, 124, 124), 5))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void btnPositive_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Thread.Sleep(200);
            Hide();
        }

        protected override void OnShown(EventArgs e)
        {
            this.TopMost = true;
            base.OnShown(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {

            base.OnDeactivate(e);
        }
    }
}
