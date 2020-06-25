using System;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.SaleScreen;
using POS.ExchangeData;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.Entities;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;
using POS.Repository.ViewModels;
using POS.DashboardScreen.MemberScreen;
using POS.DashboardScreen.SettingScreen;
using POS.PrintManager;

namespace POS.DashboardScreen
{
    public partial class DashboardScreen4 : UserControl
    {
        private readonly TableViewModel _defaultTable;

        public DashboardScreen4(bool needUpdate = false)
        {
            InitializeComponent();

            if (!MainForm.StoreInfo.PrintWifiPassword.Trim().ToLower().Equals("true"))
            {
                btnPrintWifi.Hide();
            }

            GenerateLayout();

            btnUpdatePassword.Hide();
            btnOpenSalescreen.Hide();
            //btnOpenKitchenScreen.Hide();
            btnPaymentMember.Hide();

            btnUpdate.Text = "Cập nhật ";
            this.btnUpdate.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);


            if (needUpdate)
            {
                btnUpdate.Text = "Có cập nhật mới ";
                this.btnUpdate.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.Danger);
            }
            if (MainForm.PosConfig.EnableKitchenMode.Trim().ToLower() == "true")
            {
                //btnOpenKitchenScreen.Show();
            }
            if (MainForm.PosConfig.EnableQuickSaleMode.Trim().ToLower() == "true")
            {
                //btnOpenSalescreen.Show();
                //if (_defaultTable == null)
                //{
                //    var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                //    const int notUse = (int)TableStatusEnum.NotUse;
                //    var table = tableService.Get(t => t.Status != notUse).FirstOrDefault();
                //    _defaultTable = ServiceManager.GetTableViewModel(table);
                //}
            }
            if (MainForm.PosConfig.EnableUpdatePassword.Trim().ToLower() == "true")
            {
                btnUpdatePassword.Show();
            }
            if (MainForm.PaymentType.Tab1.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab2.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab3.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab4.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab5.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab6.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab7.Trim().ToLower() == "users"
                || MainForm.PaymentType.Tab8.Trim().ToLower() == "users")
            {
                btnPaymentMember.Show();
            }
        }

        private void GenerateLayout()
        {
            btnUpdatePassword.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_Change_Password_Screen", MainForm.CultureInfo);
            btnButtonOpenSafe.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_OpenSafe_Screen", MainForm.CultureInfo);
            btnOpenSalescreen.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_Sale_Screen", MainForm.CultureInfo);
            btnUpdate.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_Update_Screen", MainForm.CultureInfo);
            btnOpenKitchenScreen.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_Kitchen_Screen", MainForm.CultureInfo);
            btnPaymentMember.Caption = MainForm.ResManager.GetString("Sys_Open_Member_Card_Screen", MainForm.CultureInfo);
            btnSetting.Caption = MainForm.ResManager.GetString("DashboardScreen4_Open_Setting_Screen", MainForm.CultureInfo);

            MainForm.SetLogo( ptbLogo, "./Resources/" + MainForm.StoreInfo.LogoSimple);
            //this.ptbLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            //this.ptbLogo.ImageLocation = "./Resources/" + MainForm.StoreInfo.LogoSimple;

            this.pnlOrder.BackColor = ColorScheme.GetColor(BootstrapColorEnum.BackColor);
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnBack2.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnButtonOpenSafe.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnOpenKitchenScreen.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnOpenSalescreen.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdate.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdatePassword.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnPaymentMember.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.lineGreen.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnSetting.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnPrintWifi.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadTableScreen();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            var isEnableOnscreenKeyboard = MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true";
            var rs = PosMessageDialog.ConfirmMessageWithInput(
                    MainForm.ResManager.GetString("DashboardScreen4_Old_Password", MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo),
                    isEnableOnscreenKeyboard, '*');

            var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            if (rs == null)
            {
                //Close ConfirmMessageWithInput
            }
            else
            {
                var username = MainForm.CurrentAccount.AccountId;
                var acc = accountService.CheckLogin(username, rs);
                if (acc == null)
                {
                    //message:Mật khẩu sai!!!
                    PosMessageDialog.ShowMessage(
                        MainForm.ResManager.GetString("Sys_Wrong_Password", MainForm.CultureInfo));
                }
                else
                {
                    var rs1 = PosMessageDialog.ConfirmMessageWithInput(
                    MainForm.ResManager.GetString("DashboardScreen4_New_Password", MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo),
                    isEnableOnscreenKeyboard,
                    '*');

                    if (rs1 == null)
                    {
                        //Close ConfirmMessageWithInput
                    }
                    else
                    {
                        //Save NEW password
                        acc.AccountPassword = rs1;
                        var accountViewModel = new AccountViewModel();
                        AutoMapper.Mapper.Map<Account, AccountViewModel>(acc, accountViewModel);
                        var passwordHashed = DataExchanger.SendAccountToUpdateUserInfo(accountViewModel);
                        if (!string.IsNullOrWhiteSpace(passwordHashed))
                        {
                            accountService.EditAccountPassword(acc);
                            //message:Mật khẩu đã được thay đổi!!!
                            PosMessageDialog.ShowMessage(
                                MainForm.ResManager.GetString("DashboardScreen4_Password_Changed", MainForm.CultureInfo));
                        }
                        else
                        {
                            //message:Thay đổi mật khẩu thất bại! Xin vui lòng thử lại!
                            PosMessageDialog.ShowMessage(
                                MainForm.ResManager.GetString("DashboardScreen4_Update_Password_Failed", MainForm.CultureInfo));
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            UpForm updateForm = new UpForm(Program.MainForm.hasUpdate);
            updateForm.Show();
        }

        private void btnOpenSalescreen_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadSaleScreen(null, OrderTypeEnum.AtStore, _defaultTable);
        }

        private void btnOpenKitchenScreen_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadKitchenScreen();
        }

        private void btnButtonOpenSafe_Click(object sender, EventArgs e)
        {
            SaleScreen3.OpenSafe(MainForm.CurrentAccount.StaffName, MainForm.ResManager.GetString("DashboardScreen4_Please_Enter_Reason_Open_Safe", MainForm.CultureInfo));
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingScreenForm settingform = new SettingScreenForm(MainForm.StoreInfo, MainForm.PosConfig);
            settingform.ShowDialog();
        }

        private void btnPaymentMember_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(MainForm.StoreInfo, MainForm.PosConfig);
            memberForm.ShowDialog();
        }

        private void btnPrintWifi_Click(object sender, EventArgs e)
        {
            if (MainForm.StoreInfo.PrintWifiPassword.Trim().ToLower().Equals("true"))
            {
                Printer printer = new Printer();
                printer.PrintWifiPassword();
            }
        }

        private void btnUpdate_Load(object sender, EventArgs e)
        {

        }
    }
}
