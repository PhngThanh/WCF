using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.Repository;

namespace POS.Splash
{
    public partial class SplashForm : Form
    {
        Rectangle _boundRect;
        Rectangle _oldRect = Rectangle.Empty;
        public static OrderDetailChangeModeEnum OrderDetail;
        public SplashForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void TurnOffLoading()
        {
            this.ptbLoading.Hide();
        }

        public void ChangeText(string text)
        {
            label1.Text = text;
            //TODO: center text
        }

        private void SplashForm_Click(object sender, EventArgs e)
        {
            this.Click -= SplashForm_Click;
        }

        public void DisableClick()
        {
            this.Click -= SplashForm_Click;
           
            _oldRect = Cursor.Clip;
            // Arbitrary location.
            _boundRect = new Rectangle(1, 1, 1, 1);
            Cursor.Clip = _boundRect;
            Cursor.Hide();
        }

        public void EnableMouse()
        {
            Cursor.Clip = _oldRect;
            Cursor.Show();
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
    }
}
