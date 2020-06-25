using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace POS.Common
{
    public partial class MessageDialogWithMultipleInput : Form
    {
        public string Input = "";

        public MessageDialogWithMultipleInput(string message, string okText, string cancelText, bool isEnableOnscreenKeyboard = true)
        {
            InitializeComponent();

            if (isEnableOnscreenKeyboard)
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtNote);
            }

            StartPosition = FormStartPosition.CenterScreen;

            lbMessage.Text = message;
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

        //private void btnNegative_Click(object sender, EventArgs e)
        //{
        //    DialogResult = DialogResult.Cancel;
        //    Hide();
        //}
    }
}
