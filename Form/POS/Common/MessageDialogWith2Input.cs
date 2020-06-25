using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class MessageDialogWith2Input : Form
    {
        public List<string> Input;

        public MessageDialogWith2Input(string message, string title1, string title2,string okText,
            string cancelText, bool isEnableOnscreenKeyboard = true)
        {
            InitializeComponent();

            if (isEnableOnscreenKeyboard)
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtFirstInput);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtSecondInput);
            }

            StartPosition = FormStartPosition.CenterScreen;

            lbMessage.Text = message;
            lblTitleFirstTextbox.Text = title1;
            lblTitleSecondTextbox.Text = title2;
            btnNegative.Caption = cancelText;
            btnPositive.Caption = okText;
            
            btnNegative.Visible = true;
            btnPositive.Visible = true;
            btnNormal.Visible = false;

            txtSecondInput.PasswordChar = '*';
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
            Input = new List<string>() { txtFirstInput.Text, txtSecondInput.Text };
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
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
    }
}
