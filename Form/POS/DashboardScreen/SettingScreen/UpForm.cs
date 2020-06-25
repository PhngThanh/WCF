using System;
using System.Windows.Forms;
using log4net;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;

namespace POS.DashboardScreen.SettingScreen
{
    public partial class UpForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CardCustomerModel _customerModel { get; set; }
        public PaymentEditViewModel _payment { get; set; }

        public UpForm(bool needUpdate = false)
        {
            InitializeComponent();

            GenerateLayout();

            //TODO: hide it before complete
            //btnPaymentMember.Hide();

            if (needUpdate)
            {
                foreach (var message in MainForm.Messagequeue)
                {
                    if (message == (int)NotifyMessageType.AccountChange)
                    {
                        this.btnUpdateAccount.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.Danger);

                    }
                    else if (message == (int)NotifyMessageType.CategoryChange)
                    {
                        this.btnUpdateCategory.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.Danger);

                    }
                    else if (message == (int)NotifyMessageType.ProductChange)
                    {
                        this.btnUpdateProduct.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.Danger);

                    }
                    else if (message == (int)NotifyMessageType.PromotionChange)
                    {
                        this.btnUpdatePromotion.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.Danger);

                    }
                }
            }
            UnlockAllButton();
        }
        private void UnlockAllButton()
        {
            btnUpdateAll.Enabled = true;
            btnUpdateCategory.Enabled = true;
            btnUpdateProduct.Enabled = true;
            btnUpdatePromotion.Enabled = true;
            btnUpdateAccount.Enabled = true;
        }
        private void LockAllButton() {
            btnUpdateAll.Enabled = false;
            btnUpdateCategory.Enabled = false;
            btnUpdateProduct.Enabled = false;
            btnUpdatePromotion.Enabled = false;
            btnUpdateAccount.Enabled = false;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.TopMost = true;
        }

        private void GenerateLayout()
        {
            _customerModel = null;
            this.btnUpdateAll.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdateAccount.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdateProduct.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdatePromotion.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnUpdateCategory.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }



        private void CloseForm()
        {
            this.Close();
            Program.MainForm.LoadDashboard();
        }

        private async void btnUpdateAll_Click(object sender, EventArgs e)
        {
            LockAllButton();
            var rs = await Program.MainForm.SyncData();
            if (rs)
            {
                this.btnUpdateAccount.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                this.btnUpdateProduct.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                this.btnUpdatePromotion.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                this.btnUpdateCategory.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            }
            UnlockAllButton();
            MainForm.Messagequeue.Clear();
        }

        private async void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            LockAllButton();
            var rs = await Program.MainForm.SyncProduct();
            if (rs)
            {
                this.btnUpdateProduct.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                MainForm.Messagequeue.Remove((int)NotifyMessageType.ProductChange);
            }
            UnlockAllButton();
        }

        private async void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            LockAllButton();
            var rs = await Program.MainForm.SyncAccount();
            if (rs)
            {
                this.btnUpdateAccount.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                MainForm.Messagequeue.Remove((int)NotifyMessageType.AccountChange);
            }
            UnlockAllButton();
        }

        private async void btnUpdatePromotion_Click(object sender, EventArgs e)
        {
            LockAllButton();

            var rs = await Program.MainForm.SyncPromotion();
            if (rs)
            {
                this.btnUpdatePromotion.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                MainForm.Messagequeue.Remove((int)NotifyMessageType.PromotionChange);
            }
            UnlockAllButton();
        }

        private async void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            LockAllButton();

            var rs = await Program.MainForm.SyncCategory();
            if (rs)
            {
                this.btnUpdateCategory.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                MainForm.Messagequeue.Remove((int)NotifyMessageType.CategoryChange);
            }
            UnlockAllButton();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            if (MainForm.Messagequeue.Count == 0)
            {
                Program.MainForm.hasUpdate = false;
            }
            CloseForm();

        }

       
    }
}
