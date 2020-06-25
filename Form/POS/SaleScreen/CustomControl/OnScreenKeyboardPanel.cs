using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using POS.Properties;

namespace POS.Common
{
    public partial class OnScreenKeyboardPanel : Panel
    {
        #region Constants

        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        #endregion

        #region Windows APIs

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        private Control _textBox;
        private bool _allowDeactive = true;
        private static OnScreenKeyboardPanel _instance;

        public OnScreenKeyboardPanel()
        {
            InitializeComponent();
        }

        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new OnScreenKeyboardPanel();
            }
        }

        public static OnScreenKeyboardPanel Instance { get { return _instance; } }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            SendKeyToControl(e.KeyChar.ToString());
        }

        private void SendKeyToControl(string keyValue)
        {
            if (_textBox != null)
            {
                _allowDeactive = false;
                _textBox.Focus();
                SendKeys.Send(keyValue);
                _allowDeactive = true;
            }
        }


        public void AddTextbox(Control textBox)
        {
            textBox.Click += _textbox_Click;
            textBox.KeyUp += _textbox_KeyUp;
        }

        private void _textbox_KeyUp(object sender, KeyEventArgs e)
        {
            Focus();
        }

        private void _textbox_Click(object sender, EventArgs e)
        {
            _textBox = (Control)sender;
            Show();
            //TopMost = true;
            Left = (Screen.PrimaryScreen.Bounds.Width - Width) / 2;
            Top = Screen.PrimaryScreen.Bounds.Height - Height - 38;
        }

        private void lbSwitch1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbSwitch1.BackColor = Color.White;
            lbSwitch1.ForeColor = Color.Black;
        }

        private void lbSwitch1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbSwitch1.BackColor = Color.FromArgb(29, 28, 33);
            lbSwitch1.ForeColor = Color.White;

            // Process.
            panelMainKeyboard.Visible = false;
            panelSubContainer.Visible = true;
            panelSubContainer.Top = 30;
            panelSubContainer.Left = 0;
        }

        private void lbSwitch2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbSwitch2.BackColor = Color.White;
            lbSwitch2.ForeColor = Color.Black;
        }

        private void lbSwitch2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbSwitch2.BackColor = Color.FromArgb(70, 70, 70);
            lbSwitch2.ForeColor = Color.White;

            // Process.
            panelSubContainer.Visible = false;
            panelMainKeyboard.Visible = true;
            panelMainKeyboard.Top = 30;
            panelMainKeyboard.Left = 0;
        }

        private void lbTab_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbTab.BackColor = Color.White;
            lbTab.ForeColor = Color.Black;
        }

        private void lbTab_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbTab.BackColor = Color.FromArgb(29, 28, 33);
            lbTab.ForeColor = Color.White;

            // Process.
            SendKeyToControl("{TAB}");
        }

        private void lbEnter2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbEnter2.BackColor = Color.White;
            lbEnter2.ForeColor = Color.Black;
        }

        private void lbEnter2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbEnter2.BackColor = Color.FromArgb(29, 28, 33);
            lbEnter2.ForeColor = Color.White;

            // Process.
            SendKeyToControl("{ENTER}");
        }

        private void lbPrevious_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbPrevious.BackColor = Color.White;
            lbPrevious.Image = Resources.key_previous_b;

            // Process.
            lbNext.Enabled = true;
            lbNext.Image = Resources.key_next_w;
            ToPrevious();
        }

        private void lbPrevious_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbPrevious.BackColor = Color.FromArgb(29, 28, 33);
            lbPrevious.Enabled = false;
        }

        private void lbNext_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbNext.BackColor = Color.White;
            lbNext.Image = Resources.key_next_b;

            // Process.
            lbPrevious.Enabled = true;
            lbPrevious.Image = Resources.key_previous_w;
            ToNext();
        }

        private void lbNext_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            lbNext.BackColor = Color.FromArgb(29, 28, 33);
            lbNext.Enabled = false;
        }

        private void numChar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.White;
            lb.ForeColor = Color.Black;
        }

        private void numChar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.FromArgb(69, 68, 76);
            lb.ForeColor = Color.White;

            // Process.
            SendKeyToControl(string.Format("{{{0}}}", lb.Text));
        }

        private void lbChar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.White;
            lb.ForeColor = Color.Black;
        }

        private void lbChar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.FromArgb(48, 47, 55);
            lb.ForeColor = Color.White;

            // Process.
            switch (lb.Text)
            {
                case "Enter":

                    SendKeyToControl("{ENTER}");
                    break;
                case "":
                case "Space":
                    SendKeyToControl(" ");
                    break;
                case "&&":
                    SendKeyToControl("{&}");
                    break;
                default:
                    SendKeyToControl(string.Format("{{{0}}}", lb.Text));
                    break;
            }
        }

        private void backspace_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.White;
            lb.Image = Resources.erase1a;
        }

        private void backspace_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.FromArgb(48, 47, 55);
            lb.Image = Resources.erase2a;

            // Process.
            SendKeyToControl("{BACKSPACE}");
        }

        private void moveLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.White;
            lb.Image = Resources.key_move_left_b;
        }

        private void moveLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.FromArgb(29, 28, 33);
            lb.Image = Resources.key_move_left_w;

            // Process.
            SendKeyToControl("{LEFT}");
        }

        private void moveRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.White;
            lb.Image = Resources.key_move_right_b;
        }

        private void moveRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var lb = sender as Label;
            if (lb == null) return;

            lb.BackColor = Color.FromArgb(29, 28, 33);
            lb.Image = Resources.key_move_right_w;

            // Process.
            SendKeyToControl("{RIGHT}");
        }

        private void shift_Click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var normalColor = Color.FromArgb(29, 28, 33);
            var activeColor = Color.White;
            var normalImage = Resources.shift_w;
            var activeImage = Resources.shift_b;

            if (lbShiftLeft.BackColor == normalColor) // Normal mode.
            {
                lbShiftLeft.BackColor = activeColor;
                lbShiftRight.BackColor = activeColor;
                lbShiftLeft.Image = activeImage;
                lbShiftRight.Image = activeImage;

                ToShiftMode();
            }
            else if (lbShiftLeft.BackColor == activeColor) // Active mode.
            {
                lbShiftLeft.BackColor = normalColor;
                lbShiftRight.BackColor = normalColor;
                lbShiftLeft.Image = normalImage;
                lbShiftRight.Image = normalImage;

                ToNormalMode();
            }
        }

        private void ToNext()
        {
            lbExclamation.Text = @"•";
            lbAtSign.Text = @"©";
            lbSharp.Text = @"€";
            lbDollar.Text = @"£";
            lbPercent.Text = @"µ";
            lbAnd.Text = @"½";
            lbOpenParenthesis.Text = @"<";
            lbCloseParenthesis.Text = @">";
            lbHyphen.Text = @"[";
            lbUnderscore.Text = @"]";
            lbEqual.Text = @"{";
            lbPlus.Text = @"}";
            lbBackslash.Text = @"|";
            lbSemiColon.Text = @"¦";
            lbColon.Text = @"¶";
            lbDoubleQuote.Text = @"°";
            lbStar.Text = @"~";
            lbSlash.Text = @"^";
        }

        private void ToPrevious()
        {
            lbExclamation.Text = @"!";
            lbAtSign.Text = @"@";
            lbSharp.Text = @"#";
            lbDollar.Text = @"$";
            lbPercent.Text = @"%";
            lbAnd.Text = @"&&";
            lbOpenParenthesis.Text = @"(";
            lbCloseParenthesis.Text = @")";
            lbHyphen.Text = @"-";
            lbUnderscore.Text = @"_";
            lbEqual.Text = @"=";
            lbPlus.Text = @"+";
            lbBackslash.Text = @"\\";
            lbSemiColon.Text = @";";
            lbColon.Text = @":";
            lbDoubleQuote.Text = "\"";
            lbStar.Text = @"*";
            lbSlash.Text = @"/";
        }

        private void ToShiftMode()
        {
            lbQ.Text = @"Q";
            lbW.Text = @"W";
            lbE.Text = @"E";
            lbR.Text = @"R";
            lbT.Text = @"T";
            lbY.Text = @"Y";
            lbU.Text = @"U";
            lbI.Text = @"I";
            lbO.Text = @"O";
            lbP.Text = @"P";
            lbA.Text = @"A";
            lbS.Text = @"S";
            lbD.Text = @"D";
            lbF.Text = @"F";
            lbG.Text = @"G";
            lbH.Text = @"H";
            lbJ.Text = @"J";
            lbK.Text = @"K";
            lbL.Text = @"L";
            lbApostrophe.Text = "\"";
            lbZ.Text = @"Z";
            lbX.Text = @"X";
            lbC.Text = @"C";
            lbV.Text = @"V";
            lbB.Text = @"B";
            lbN.Text = @"N";
            lbM.Text = @"M";
            lbComma.Text = @";";
            lbDot1.Text = @":";
            lbQuestion.Text = @"!";
        }

        private void ToNormalMode()
        {
            lbQ.Text = @"q";
            lbW.Text = @"w";
            lbE.Text = @"e";
            lbR.Text = @"r";
            lbT.Text = @"t";
            lbY.Text = @"y";
            lbU.Text = @"u";
            lbI.Text = @"i";
            lbO.Text = @"o";
            lbP.Text = @"p";
            lbA.Text = @"a";
            lbS.Text = @"s";
            lbD.Text = @"d";
            lbF.Text = @"f";
            lbG.Text = @"g";
            lbH.Text = @"h";
            lbJ.Text = @"j";
            lbK.Text = @"k";
            lbL.Text = @"l";
            lbApostrophe.Text = @"'";
            lbZ.Text = @"z";
            lbX.Text = @"x";
            lbC.Text = @"c";
            lbV.Text = @"v";
            lbB.Text = @"b";
            lbN.Text = @"n";
            lbM.Text = @"m";
            lbComma.Text = @",";
            lbDot1.Text = @".";
            lbQuestion.Text = @"?";
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        //private void KeypadDialog_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    e.Cancel = true;
        //}

        //private void KeypadDialog_Deactivate(object sender, EventArgs e)
        //{
        //    if (_allowDeactive) Hide();
        //}
    }
}
