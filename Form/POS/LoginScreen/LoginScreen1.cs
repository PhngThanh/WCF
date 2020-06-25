using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.Repository.ViewModels;
using log4net;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;

namespace POS.LoginScreen
{
    public partial class LoginScreen1 : UserControl
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginScreen1()
        {
            InitializeComponent();

            btnLogin.Caption = MainForm.ResManager.GetString("LoginScreen1_Login", MainForm.CultureInfo);
            btnCancel.Caption = MainForm.ResManager.GetString("LoginScreen1_Exit", MainForm.CultureInfo);
            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtUsername);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtPassword);
            }
            ResetTexts();
            txtUsername.Focus();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //e.Graphics.FillRectangle(new SolidBrush(Constant.BackgroundColor), new Rectangle(Point.Empty, new Size(Width, 52)));
            //e.Graphics.FillRectangle(new SolidBrush(Constant.BackgroundColor), new Rectangle(new Point(0, Height - 52), new Size(Width, 52)));

            BackColor = Constant.Brown;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.MainForm.MainFormClosed();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(username))
            {
                //message:Xin nhập Username
                PosMessageDialog.ShowMessage(
                    MainForm.ResManager.GetString("LoginScreen1_Enter_Username", MainForm.CultureInfo));
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                //message: Xin nhập Password
                PosMessageDialog.ShowMessage(
                    MainForm.ResManager.GetString("LoginScreen1_Enter_Password", MainForm.CultureInfo));
                return;
            }

            //Check to database
            var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            try
            {
                Account account = accountService.CheckLogin(username, password);
                AccountViewModel accountViewModel = ServiceManager.GetAccountViewModel(account);//password unhashed
                if (accountViewModel == null || string.IsNullOrWhiteSpace(accountViewModel.AccountId))
                {
                    //message:Username hoặc Password sai!
                    PosMessageDialog.ShowMessage(
                        MainForm.ResManager.GetString("LoginScreen1_Invalid_Username_Password", MainForm.CultureInfo));
                }
                else
                {
                    MainForm.CurrentAccount = accountViewModel;
                    Program.MainForm.LoadFirstScreen();//Call change form
                }
            }
            catch (Exception ex)
            {
                log.Error("btnLogin_Click - " + ex);
                Program.MainForm.LoadLoginScreen();
            }

        }

        private void ResetTexts()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }


        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
