using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class MessageDialogWithInput : Form
    {
        public string Input = "";

        public MessageDialogWithInput(string message, string okText, string cancelText, bool isEnableOnscreenKeyboard, char passwordChar)
        {
            InitializeComponent();

            if (isEnableOnscreenKeyboard)
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtInput);
            }

            StartPosition = FormStartPosition.CenterScreen;

            //if (passwordChar != ' ') { txtInput.PasswordChar = passwordChar; }
            txtInput.PasswordChar = passwordChar;
            lbMessage.Text = message;
            btnNegative.Caption = cancelText;
            btnPositive.Caption = okText;
            
            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = false;
        }

        public MessageDialogWithInput(string message, string yesText, string noText, string cancelText, bool isEnableOnscreenKeyboard, string inputString)
        {
            InitializeComponent();

            if (isEnableOnscreenKeyboard)
            {
                txtInput.Visible = false;
                txtInput1.Visible = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtInput1);
            }

            StartPosition = FormStartPosition.CenterScreen;


            txtInput1.Text = inputString;
            lbMessage.Text = message;
            btnNegative.Caption = cancelText;      
            btnNormal.Caption = noText;
            btnPositive.Caption = yesText;

            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = true;
        }

        public MessageDialogWithInput(string message, string yesText, string cancelText, bool isEnableOnscreenKeyboard, string inputString)
        {
            InitializeComponent();

            if (isEnableOnscreenKeyboard)
            {
                txtInput.Visible = false;
                txtInput1.Visible = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtInput1);
            }

            StartPosition = FormStartPosition.CenterScreen;


            txtInput1.Text = inputString;
            lbMessage.Text = message;
            btnNegative.Caption = cancelText;
            btnPositive.Caption = yesText;

            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = false;
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
            if (txtInput1.Visible)
            {
                Input = txtInput1.Text;
            } else
            {
                Input = txtInput.Text;
            }           
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (txtInput1.Visible)
            {
                Input = txtInput1.Text;
            }
            else
            {
                Input = txtInput.Text;
            }
            DialogResult = DialogResult.No;
            Thread.Sleep(200);
            Hide();
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPositive_Click(null, null);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            if (txtInput1.Visible)
            {
                txtInput1.Focus();
            }
            else
            {
                txtInput.Focus();
            }
            base.OnShown(e);
        }
    }
}
