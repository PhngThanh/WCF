using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using POS.Utils;
using POS.Common;
using POS.Repository;
using POS.ExchangeData;
using POS.PrintManager;
using POS.CustomControl;
using POS.ApiThirdPartyDLL;
using POS.DashboardScreen.ReportScreen;
using POS.Repository.ExchangeDataModel;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;
using log4net;
using Newtonsoft.Json;
using ThirdPartyInteractor.Momo;
using POS.Repository.ViewModels;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;
using SkyConnect.POSLib.Domains;
using System.Threading;

namespace POS.SaleScreen
{

    public delegate void BarcodeReaderEventHandler(string barcode);
    public partial class OrderPropertyForm2 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private static CustomerInfoPanel2 _pnlCustomerInfo;
        private static PaymentInfoPanel2 _pnlPaymentInfo;
        private static PromotionInfoPanel2 _pnlPromotionInfo;
        //
        //private static MembershipTypePanel _pnlMembershiptype;
        //
        public event BarcodeReceivedEventHandler BarcodeReceived2;
        private static OrderPanel _orderPanel;
        private static Form _staffSelectForm;
        private int _barcodeRegTime = 100;
        private int _barcodeDurTime = 200;
        private DateTime _lastKeyDownTime;
        private bool _isBarcode = false;

        public bool isDirty = false;    //use to refresh panel after finish / cancel order
        public static Printer PosPrinter;
        public event EventHandler Refresh;
        private string _transactionCode = "";

        public enum OrderPropertyTabEnum
        {
            Payment,
            Promotion,
            Customer
        }

        public OrderPropertyForm2()
        {
            InitializeComponent();

            GenerateLayout();

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtOrderNotes);
            }
            if (MainForm.PosConfig.BarcodeRecognizeTime != 0)
            {
                _barcodeRegTime = MainForm.PosConfig.BarcodeRecognizeTime;
            }
            if (MainForm.PosConfig.BarcodeDurationTime != 0)
            {
                _barcodeDurTime = MainForm.PosConfig.BarcodeDurationTime;
            }
            if (MainForm.PosConfig.EnableReceiptPrintPreview.Trim().ToLower() == "false")
            {
                this.btnPreview.Hide();
            }
            if (MainForm.StoreInfo.EnablePrintPreview.Trim().ToLower() == "false")
            {
                this.btnPrintReceipt.Hide();
            }
            if (MainForm.StoreInfo.EnablePrintBillCook.Trim().ToLower() == "false")
            {
                this.btnPrintCook.Hide();
            }
            this.btnCheckMomo.Hide();
            this.btnPrintMomo.Hide();
            this.BtnMomoPay.Hide();

            if (MainForm.StoreInfo.QRCodeEnable.Trim().ToLower() != "true")
            {

            }
            if (BarcodeReceived2 != null)
            {
                this.BarcodeReceived2 += CheckCustomer;
            }
            this.TopLevel = true;
            this.isDirty = false;

            LoadTab(OrderPropertyTabEnum.Payment);
        }

        private void GenerateLayout()
        {
            ReGenerateLayout();

            this.btnCustomerInfo.TextValue = MainForm.ResManager.GetString("OrderPropertyForm2_Customer", MainForm.CultureInfo);
            this.btnPromotionInfo.TextValue = MainForm.ResManager.GetString("Sys_Promotion", MainForm.CultureInfo);
            this.btnPaymentInfo.TextValue = MainForm.ResManager.GetString("Sys_Payment", MainForm.CultureInfo);
            this.bsBtnOrderNotes.TextValue = MainForm.ResManager.GetString("Sys_Note_Title", MainForm.CultureInfo);
            this.bootstrapButton9.TextValue = MainForm.ResManager.GetString("OrderPropertyForm2_Payment_Info", MainForm.CultureInfo);
            this.lblTotal.Text = MainForm.ResManager.GetString("Sys_FinalAmount", MainForm.CultureInfo);
            this.lblDiscout.Text = MainForm.ResManager.GetString("Sys_Discount", MainForm.CultureInfo);
            this.label1.Text = MainForm.ResManager.GetString("OrderPropertyForm2_Remain", MainForm.CultureInfo);
            this.label4.Text = MainForm.ResManager.GetString("Sys_Received", MainForm.CultureInfo);
            this.label5.Text = MainForm.ResManager.GetString("OrderPropertyForm2_Give_Back", MainForm.CultureInfo);
            this.bsbtnCloseNote.TextValue = MainForm.ResManager.GetString("Sys_Close", MainForm.CultureInfo);
            this.btnFinish.TextValue = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);
            this.btnCustomerInfo.TextValue = MainForm.ResManager.GetString("OrderPropertyForm2_Customer", MainForm.CultureInfo);
            this.btnHide.TextValue = MainForm.ResManager.GetString("Sys_Hide", MainForm.CultureInfo);
            this.btnPrintCook.TextValue = MainForm.ResManager.GetString("OrderPropertyForm2_Print_Cook_Bill", MainForm.CultureInfo);
            this.btnRefreshAllTab.TextValue = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
            if (currentOrderManager.getOrderEditViewModel().VAT > 0)
            {
                this.btnAddVAT.Hide();
                this.btnDecreaseVAT.Show();
            }
            else
            {
                this.btnAddVAT.Show();
                this.btnDecreaseVAT.Hide();
            }
        }

        public void ReGenerateLayout()
        {
            UpdateMoneyInfo();
            lblTable.Text = MainForm.ResManager.GetString("OrderPropertyForm2_Table", MainForm.CultureInfo) + " : " + currentOrderManager.getOrderEditViewModel().TableNumber;
            lblOrderCode.Text = currentOrderManager.getOrderEditViewModel().OrderCode;

            var checkindate = currentOrderManager.getOrderEditViewModel().CheckInDate.ToString("dd/MM/yyyy \nHH:mm");
            lblCheckinDate.Text = checkindate;

            btnCustomerInfo.ActiveBackgroudColor = Color.Black;
            btnPromotionInfo.ActiveBackgroudColor = Color.Black;
            btnPaymentInfo.ActiveBackgroudColor = Color.Black;
            btnCustomerInfo.IsActive = false;
            btnPromotionInfo.IsActive = false;
            btnPaymentInfo.IsActive = true;
            pnlNote.Hide();

            if (MainForm.PosConfig.EnableChangeServedStaff.Trim().ToLower() == "true")
            {
                InitStaffDialog();
            }

            ChangeServedPerson(currentOrderManager.getOrderEditViewModel().CheckInPerson);
            txtServedStaff.Select();
        }

        private void InitStaffDialog()
        {
            AccountService accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            var accounts = accountService.Get().ToList();
            //var accounts = accounts.

            _staffSelectForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
            };

            var pnlStaffContainer = new FlowLayoutPanel
            {
                Width = 450,
                Height = (int)((txtServedStaff.Height + 2 + 6) * Math.Round((accounts.Count + 1) / 2.0f)),
                BackColor = txtServedStaff.BorderColor
            };

            foreach (var account in accounts)
            {
                var staffControl = new Label
                {
                    Text = account.AccountId,
                    Width = 438 / 2,
                    Height = txtServedStaff.Height + 2,
                    BackColor = Color.LimeGreen,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Tahoma", 15, FontStyle.Bold),
                    Margin = new Padding(3)
                };
                staffControl.Click += staffControl_Click;
                pnlStaffContainer.Controls.Add(staffControl);
            }
            _staffSelectForm.Size = pnlStaffContainer.Size;
            pnlStaffContainer.Dock = DockStyle.Fill;
            _staffSelectForm.Controls.Add(pnlStaffContainer);
        }

        public void LoadTab(OrderPropertyTabEnum tab, bool isRefresh = false)
        {
            var changeTab = false;

            EnablePrintMomo(false);
            if (tab == OrderPropertyTabEnum.Payment
                    && !this.btnPaymentInfo.IsActive)
            {
                changeTab = true;
                this.btnPaymentInfo.IsActive = true;
                this.btnCustomerInfo.IsActive = false;
                this.btnPromotionInfo.IsActive = false;
            }
            else if (tab == OrderPropertyTabEnum.Customer
                        && !this.btnCustomerInfo.IsActive)
            {
                changeTab = true;
                this.btnCustomerInfo.IsActive = true;
                this.btnPaymentInfo.IsActive = false;
                this.btnPromotionInfo.IsActive = false;
            }
            else if (tab == OrderPropertyTabEnum.Promotion
                        && !this.btnPromotionInfo.IsActive)
            {
                changeTab = true;
                this.btnPromotionInfo.IsActive = true;
                this.btnPaymentInfo.IsActive = false;
                this.btnCustomerInfo.IsActive = false;
            }

            if (changeTab || isRefresh)
            {
                LoadPanel();
            }
        }

        public void LoadPanel()
        {
            pnlContainer.Controls.Clear();


            if (btnCustomerInfo.IsActive)
            {
                if (_pnlCustomerInfo == null || _pnlCustomerInfo.IsDisposed)
                {
                    _pnlCustomerInfo = new CustomerInfoPanel2();
                    _pnlCustomerInfo.ClearBarcode += ClearBarcode;
                    _pnlCustomerInfo.ClearMemberProperty += ClearMemberProperty;
                    _pnlCustomerInfo.BarcodeReceived += CheckCustomer;

                }
                _pnlCustomerInfo.LoadCustomerInfo();
                _pnlCustomerInfo.UpdateCustomerGroup();
                _pnlCustomerInfo.UpdateNationality();

                pnlContainer.Controls.Add(_pnlCustomerInfo);
            }
            else if (btnPromotionInfo.IsActive)
            {
                if (_pnlPromotionInfo == null || _pnlPromotionInfo.IsDisposed)
                {
                    _pnlPromotionInfo = new PromotionInfoPanel2();
                    _pnlPromotionInfo.UpdateMoneyInfo += UpdateMoneyInfo;
                }
                _pnlPromotionInfo.LoadPromotion();
                pnlContainer.Controls.Add(_pnlPromotionInfo);
            }
            else if (btnPaymentInfo.IsActive)
            {
                if (_pnlPaymentInfo == null || _pnlPaymentInfo.IsDisposed)
                {
                    _pnlPaymentInfo = new PaymentInfoPanel2();
                    _pnlPaymentInfo.UpdateMoneyInfo += UpdateMoneyInfo;
                    _pnlPaymentInfo.ReloadMemberPoint += LoadMemberPoint;
                }
                _pnlPaymentInfo.RefreshPanel();
                _pnlPaymentInfo.LoadPayment();
                pnlContainer.Controls.Add(_pnlPaymentInfo);
            }
            //else
            //{
            //    if (_pnlMembershiptype == null || _pnlMembershiptype.IsDisposed)
            //    {
            //        _pnlMembershiptype = new MembershipTypePanel();
            //    }
            //    //_pnlMembershiptype.RefreshPanel();
            //    //_pnlMembershiptype.LoadPayment();
            //    pnlContainer.Controls.Add(_pnlMembershiptype);
            //}

            if (currentOrderManager.getCurrentCustomerModel() == null)
            {
                ClearMemberProperty();

            }
            if (currentOrderManager.getOrderEditViewModel().BarCode == null)
            {
                ClearMemberProperty();
            }
        }

        public void UpdateMoneyInfo()
        {
            var totalAmount = currentOrderManager.getOrderEditViewModel().TotalAmount;
            var discountOrderDetail = currentOrderManager.getOrderEditViewModel().DiscountOrderDetail;
            var discountOrder = currentOrderManager.getOrderEditViewModel().Discount;
            var totalDiscountAmount = discountOrderDetail + discountOrder;
            var vatAmount = currentOrderManager.getOrderEditViewModel().VAT * currentOrderManager.getOrderEditViewModel().FinalAmount / 100;
            var finalAmount = currentOrderManager.getOrderEditViewModel().FinalAmount + vatAmount;
            var receivedAmount = currentOrderManager.getOrderEditViewModel().GuestPayment;
            var exchangedAmount = currentOrderManager.getOrderEditViewModel().ExchangedCash;

            //Tính toán tiền còn thiếu
            var totalPaymentAmount = currentOrderManager.getOrderEditViewModel().TotalPayment;
            var inNeedAmount = (int)Math.Abs(totalPaymentAmount - finalAmount);

            //Update VAT
            currentOrderManager.getOrderEditViewModel().VATAmount = vatAmount;

            var total = string.Format("{0:n0}", totalAmount);                                   //Tổng hóa đơn
            var discount = string.Format("{0:n0}", totalDiscountAmount);                        //Tổng giảm giá
            var afterDiscount = string.Format("{0:n0}", totalAmount - totalDiscountAmount);     //Tổng tiền sau giảm giá
            var vat = string.Format("{0:n0}", vatAmount);                                       //VAT
            var final = string.Format("{0:n0}", finalAmount);                                   //Tổng tiền (+VAT)
            var received = string.Format("{0:n0}", receivedAmount);                             //Tổng tiền nhận từ khách
            var exchange = string.Format("{0:n0}", exchangedAmount);                            //Tiền mặt đã trả lại khách
            var inNeed = string.Format("{0:n0}", inNeedAmount);                                 //Tiền còn thiếu

            if (lblTotalAmount.Text != total)
            {
                lblTotalAmount.Text = total;
                lblTotalAmount.Invalidate();
            }
            if (lblTotalDiscount.Text != discount)
            {
                lblTotalDiscount.Text = discount;
                lblTotalDiscount.Invalidate();
            }
            if (lblAfterDiscount.Text != afterDiscount)
            {
                lblAfterDiscount.Text = afterDiscount;
                lblAfterDiscount.Invalidate();
            }
            if (lblVATAmount.Text != vat)
            {
                lblVATAmount.Text = vat;
                lblVATAmount.Invalidate();
            }
            if (lblFinalAmount.Text != final)
            {
                lblFinalAmount.Text = final;
                lblFinalAmount.Invalidate();
            }
            if (lblReceived.Text != received)
            {
                lblReceived.Text = received;
                lblReceived.Invalidate();
            }
            if (lblExchange.Text != exchange)
            {
                lblExchange.Text = exchange;
                lblExchange.Invalidate();
            }
            if (lblInNeed.Text != inNeed)
            {
                lblInNeed.Text = inNeed;
                lblInNeed.Invalidate();
            }

            LoadMemberPoint();
        }

        public void ClearBarcode()
        {
            currentOrderManager.RemoveBarCode();
            UpdateMoneyInfo();
        }

        public void ClearMemberProperty()
        {
            txtMoney.Text = "";
            txtMoney.Visible = false;
            lblMoney.Visible = false;

            txtPoint.Text = "";
            txtPoint.Visible = false;
            lblPoint.Visible = false;

            lblNoti.Visible = false;
            txtAvailPromo.Text = "";
            txtAvailPromo.Visible = false;
        }

        public void HideForm()
        {
            EnablePrintMomo(false);
            this.Hide();
        }

        private async Task<bool> CheckCreateTransaction()
        {
            string input = currentOrderManager.getOrderEditViewModel().BarCode;
            if (!string.IsNullOrEmpty(input)
                && !currentOrderManager.isCurrentCustomerModelEmpty())
            {
                var listTransactionAccounts = new List<TransactionAccountModel>();

                decimal creditAPIAmount = 0;
                switch (currentOrderManager.getCardType())
                {
                    case null:
                        break;
                    case (int)PaymentTypeEnum.MemberPayment:
                        creditAPIAmount = (decimal)currentOrderManager.getOrderEditViewModel().getPaymentEditViewModels()
                            .Where(q => q.Type == (int)PaymentTypeEnum.MemberPayment)
                            .Sum(p => p.Amount);
                        var creditAccount = currentOrderManager.getCurrentCustomerModel().Accounts
                            .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);

                        if (creditAccount != null)
                        {
                            var accountModel = new TransactionAccountModel
                            {
                                AccountCode = creditAccount.AccountCode,
                                IsChange = false,
                                IsIncrease = false,
                                ChangeAmount = creditAPIAmount,
                                TransactionCode = _transactionCode
                            };

                            if (creditAPIAmount > 0)
                            {
                                accountModel.IsChange = true;       //co thay doi
                                accountModel.IsIncrease = false;    //tru credit
                            }

                            listTransactionAccounts.Add(accountModel);
                        }

                        foreach (var account in currentOrderManager.getCurrentCustomerModel().Accounts)
                        {
                            if (account.Type != (int)CardAccountTypeEnum.CreditAccount)
                            {
                                var accountModel = new TransactionAccountModel
                                {
                                    AccountCode = account.AccountCode,
                                    ChangeAmount = 0,
                                    IsChange = false,
                                    IsIncrease = false,
                                };

                                listTransactionAccounts.Add(accountModel);
                            }
                        }
                        break;
                    case (int)PaymentTypeEnum.GiftTalk:
                        creditAPIAmount = (decimal)currentOrderManager.getOrderEditViewModel().getPaymentEditViewModels()
                            .Where(q => q.Type == (int)PaymentTypeEnum.GiftTalk)
                            .Sum(p => p.Amount);
                        var cardAccount =
                            currentOrderManager.getCurrentCustomerModel().Accounts.SingleOrDefault(a =>
                                a.Type == (int)CardAccountTypeEnum.GiftAccount);
                        if (cardAccount != null)
                        {
                            var accountModel = new TransactionAccountModel
                            {
                                AccountCode = cardAccount.AccountCode,
                                ChangeAmount = creditAPIAmount,
                                IsChange = false,
                                IsIncrease = false,
                            };

                            if (creditAPIAmount > 0)
                            {
                                accountModel.IsChange = true;
                                accountModel.IsIncrease = false;
                            }

                            listTransactionAccounts.Add(accountModel);
                        }

                        break;
                    default:
                        goto case (int)PaymentTypeEnum.MemberPayment;
                }

                if (listTransactionAccounts.Any(a=>a.IsChange))
                {
                    var userId = MainForm.CurrentAccount.AccountId;
                    var orderId = currentOrderManager.getOrderEditViewModel().OrderCode;
                    var customer = currentOrderManager.getCurrentCustomerModel().CustomerName;
                    var tableId = currentOrderManager.getOrderEditViewModel().TableNumber;

                    var transactionService = DataExchanger.SendTransaction(currentOrderManager.getCardType() ?? (int)PaymentTypeEnum.MemberPayment
                        , listTransactionAccounts, userId, tableId, orderId, customer);


                    if (await Task.WhenAny(transactionService) == transactionService)
                    {
                        return transactionService.Result.success;
                    }
                    else
                    {
                        //time out
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        //private void CreateTransationPayment(int Enum, List<TransactionAccountModel> accounts, string userId,
        //    string tableNumber = null, string billId = null, string customer = null)
        //{
        //    switch (Enum)
        //    {
        //        case (int)PaymentTypeEnum.MemberPayment:
        //            return CreateTransactionInSystem(model);
        //        case (int)PaymentTypeEnum.GiftTalk:
        //            return CreateTransactionForGiftTalk(model);
        //        default:
        //            goto case (int)PaymentTypeEnum.MemberPayment;
        //    }
        //}

        private async Task<bool> CheckUseVoucher()
        {
            var voucher = currentOrderManager.getCurrentVoucherModel();
            var order = currentOrderManager.getOrderEditViewModel();
            var appliedVoucher = currentOrderManager.getOrderEditViewModel().Att3;
            var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
            var applyPromotion = new PromotionEditViewModel();
            var Promotions = ServiceManager.GetPromotionEditViewModels(promotionService.GetAvailablePromotions().ToList());
            foreach (var promotion in Promotions)
            {
                if (promotion.IsActive && voucher != null)
                {
                    if (promotion.PromotionCode == voucher.PromotionCode)
                    {
                        applyPromotion = promotion;
                        break;
                    }
                }

            }

            if (voucher != null && !string.IsNullOrEmpty(appliedVoucher))
            {
                var appliedPromotionCode = appliedVoucher.Split(':')[0];
                if (voucher.PromotionCode != null
                    && voucher.PromotionCode == appliedPromotionCode)
                {
                    var useVoucher = DataExchanger.UseVoucher(voucher, order, applyPromotion);

                    if (await Task.WhenAny(useVoucher) == useVoucher)
                    {
                        return useVoucher.Result.success;
                    }
                    else
                    {
                        //time out
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckDeliveriedCustomer()
        {
            var custName = currentOrderManager.getOrderEditViewModel().DeliveryCustomer;
            var custPhone = currentOrderManager.getOrderEditViewModel().DeliveryPhone;
            var custAddress = currentOrderManager.getOrderEditViewModel().DeliveryAddress;
            //if ((custName == null || string.Empty.Equals(custName))
            //    && (custPhone == null || string.Empty.Equals(custPhone))
            //    &&( custAddress == null || string.Empty.Equals(custAddress))
            //    )
            //{
            //    return true;
            //}
            if (custName == null || string.Empty.Equals(custName)
                || custPhone == null || string.Empty.Equals(custPhone)
                || custAddress == null || string.Empty.Equals(custAddress))
            {
                return false;
            }
            return true;
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                //chưa hiểu lý do vì sao, form bị thay đổi, tạm thời set cứng
                this.Width = 1024;this.Height = 704;
                this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
                this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
                base.OnShown(e);
            }
            catch (Exception ex)
            {
                log.Error("OnShown - " + ex);
            }
        }

        public void ShowForm()
        {
            try
            {
                this.btnFinish.Enabled = true;

                if (currentOrderManager.getOrderEditViewModel().VAT > 0)
                {
                    this.btnAddVAT.Hide();
                    this.btnDecreaseVAT.Show();
                }
                else
                {
                    this.btnAddVAT.Show();
                    this.btnDecreaseVAT.Hide();
                }

                var tmpList = currentOrderManager.getPaymentEditViewModels();
                foreach (var item in tmpList)
                {
                    var payment = currentOrderManager.getOrderEditViewModel().getPaymentEditViewModels()
                                    .FirstOrDefault(p => p == item);
                    if (payment != null
                        && (payment.Type == (int)PaymentTypeEnum.MemberPayment
                        || payment.Type == (int)PaymentTypeEnum.VisaCard
                        || payment.Type == (int)PaymentTypeEnum.MasterCard)
                        && !currentOrderManager.isCurrentCustomerModelEmpty())
                    {
                        var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                        accountCredit.Balance +=payment.Amount;
                        currentOrderManager.RemovePayment(payment);
                    }
                }
                this.Show();
            }
            catch (Exception ex)
            {
                log.Error("ShowForm - " + ex);
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            var control = (BootstrapButton)sender;
            control.IsActive = true;
            LoadPanel();
        }
        //private void member_Click(object sender, EventArgs e)
        //{
        //    var control = (BootstrapButton)sender;
        //    control.IsActive = true;
        //    _pnlMembershiptype = new MembershipTypePanel();
        //    _pnlMembershiptype.Visible = true;
        //    _pnlMembershiptype.Show();
        //}

        public void RefreshAllPanel()
        {
            if (_pnlCustomerInfo != null && _pnlCustomerInfo.IsDisposed == false)
            {
                _pnlCustomerInfo.RefreshPanel();
            }
            if (_pnlPaymentInfo != null && _pnlPaymentInfo.IsDisposed == false)
            {
                _pnlPaymentInfo.RefreshPanel();
            }
            if (_pnlPromotionInfo != null && _pnlPromotionInfo.IsDisposed == false)
            {
                _pnlPromotionInfo.RefreshPanel();
            }

            UpdateMoneyInfo();
        }

        private void ChangeServedPerson(string name)
        {
            txtServedStaff.Text = name;
            currentOrderManager.getOrderEditViewModel().ServedPerson = name;
        }

        private void btnVAT_Click(object sender, EventArgs e)
        {
            if (MainForm.PosConfig.EnableVAT.Trim().ToLower() == "false")
                return;

            if (sender == btnAddVAT)
            {
                btnAddVAT.Hide();
                btnDecreaseVAT.Show();
                currentOrderManager.getOrderEditViewModel().VAT = 10;
            }
            else
            {
                btnAddVAT.Show();
                btnDecreaseVAT.Hide();

                currentOrderManager.getOrderEditViewModel().VAT = 0;
            }

            UpdateMoneyInfo();
            _pnlPaymentInfo.SetDefaultCashValue();
        }

        private void bsBtnOrderNotes_Click(object sender, EventArgs e)
        {
            pnlNote.Show();
        }

        private void bsbtnCloseNote_Click(object sender, EventArgs e)
        {
            pnlNote.Hide();
        }

        private void staffControl_Click(object sender, EventArgs e)
        {
            var staffControl = (Label)sender;
            _staffSelectForm.Hide();

            ChangeServedPerson(staffControl.Text);
        }

        private void txtServedStaff_Click(object sender, EventArgs e)
        {
            if (MainForm.PosConfig.EnableChangeServedStaff.Trim().ToLower() == "true")
            {
                _staffSelectForm.Top = Top + 110;
                _staffSelectForm.Left = Right - 450;
                _staffSelectForm.ShowDialog();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                //message:Đang thống kê...
                var text = MainForm.ResManager.GetString(
                            "ReportDateFilterDialog_Generate_Report_Waiting",
                            MainForm.CultureInfo);
                Program.MainForm.ShowSplashForm(text);
                // Get print image.
                Program.MainForm.HideSplashForm();

                btnPreview.IsActive = false;

                // Showing.
                //Tính toán phần tiền mặt trả lại cho khách => Giảm cash payment 
                //var returnMoney = currentOrderManager.getOrderEditViewModel().TotalPayment
                //                   - currentOrderManager.getOrderEditViewModel().FinalAmount
                //                   - currentOrderManager.getOrderEditViewModel().VATAmount;

                //if (returnMoney > 0)
                //{
                //    //Tiền trả lại cho khách
                //    currentOrderManager.UpdatePayment(PaymentTypeEnum.ExchangeCash, -returnMoney, true, null);
                //}
                //else
                //{
                //    currentOrderManager.UpdatePayment(PaymentTypeEnum.ExchangeCash, 0, true, null);
                //}

                using (var rpDialog = new ReceiptReportDialog(currentOrderManager.getOrderEditViewModel()))
                {
                    rpDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("btnPreview_Click - " + ex);

                Program.MainForm.HideSplashForm();
                //message:Vui lòng thử lại sau!
                var msg = new MessageDialog(
                    MainForm.ResManager.GetString("Sys_Generate_Report_Failed",
                    MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo));
                msg.ShowDialog();
            }
        }

        private async void btnFinish_ClickAsync(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            //Splash Form
            //message:Đang xử lý!
            //Program.MainForm.ShowSplashForm(
            //        MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
            //        MainForm.CultureInfo));
            try
            {
                //Save note 
                currentOrderManager.getOrderEditViewModel().Notes = txtOrderNotes.Text;

                //Check Flag
                var result = true;
                var message = "";
                var tab = OrderPropertyTabEnum.Payment;

                //Check không có product
                if (currentOrderManager.GetTotalProduct() < 1)
                {
                    result = false;
                    //message:Chưa chọn sản phẩm!
                    message = MainForm.ResManager.GetString("OrderPropetyPanel_Product_Empty", MainForm.CultureInfo);
                }

                //Check không có thông tin khách hàng cho delivery
                if (result &&
                    currentOrderManager.getOrderEditViewModel().OrderType
                        == (int)OrderTypeEnum.Delivery)
                {
                    if (!CheckDeliveriedCustomer())
                    {
                        result = false;
                        //message:Thông tin khách hàng thiếu. Vui lòng nhập đầy đủ và lưu
                        message = MainForm.ResManager.GetString("OrderPropetyPanel_Customer_Empty", MainForm.CultureInfo);
                        tab = OrderPropertyTabEnum.Customer;
                    }
                }

                //Check tiền thanh toán không đủ
                if (result &&
                    currentOrderManager.getOrderEditViewModel().TotalPayment
                        < (currentOrderManager.getOrderEditViewModel().FinalAmount
                           + currentOrderManager.getOrderEditViewModel().VATAmount))
                {
                    result = false;
                    //message:Tiền thanh toán chưa đủ!
                    message = MainForm.ResManager.GetString("Sys_Payment_Not_Enough", MainForm.CultureInfo);
                    tab = OrderPropertyTabEnum.Payment;
                }

                //Check áp dụng voucher
                if (result)
                {
                    result = await CheckUseVoucher();

                    if (!result)
                    {
                        //Message:Lỗi kết nối mạng, không áp dụng voucher được
                        message = MainForm.ResManager.GetString("OrderPropertyForm2_Voucher_No_Connection_Error", MainForm.CultureInfo);
                        tab = OrderPropertyTabEnum.Promotion;
                    }
                }
                if (MainForm.StoreInfo.SkyConnectEnable.ToString().Trim() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.ToString().Trim() == "true")
                {

                }
                else
                {
                    //Check thanh toán thẻ thành viên
                    if (result)
                    {
                        result = await CheckCreateTransaction();

                        if (!result)
                        {
                            if (currentOrderManager.getCardType() != null)
                            {
                                if (currentOrderManager.getCardType() == (int)PaymentTypeEnum.GiftTalk)
                                {
                                    message = MainForm.ResManager.GetString(
                                        "OrderPropertyForm2_GiftTalkPayment_No_Connection_Error", MainForm.CultureInfo);
                                    tab = OrderPropertyTabEnum.Payment;
                                }
                                else
                                {
                                    message = MainForm.ResManager.GetString(
                                        "OrderPropertyForm2_Payment_No_Connection_Error", MainForm.CultureInfo);
                                    tab = OrderPropertyTabEnum.Payment;
                                }
                            }
                            else
                            {
                                message = MainForm.ResManager.GetString("OrderPropertyForm2_Payment_No_Connection_Error", MainForm.CultureInfo);
                                tab = OrderPropertyTabEnum.Payment;
                            }
                            //message: Lỗi kết nối mạng, thanh toán thất bại

                        }
                    }
                }



                //Hoàn tất 
                if (result)
                {
                    //Save customer ID
                    if (!currentOrderManager.isCurrentCustomerModelEmpty()
                        && currentOrderManager.getCurrentCustomerModel().CustomerID >= 0)
                    {
                        currentOrderManager.getOrderEditViewModel().CustomerID
                                = currentOrderManager.getCurrentCustomerModel().CustomerID;
                    }

                    //Generate wifi password
                    if (MainForm.StoreInfo.IsShowWifiInfo.Trim().ToLower() == "true"
                        && MainForm.StoreInfo.IsGeneratePassWifi.Trim().ToLower() == "true"
                        && string.IsNullOrWhiteSpace(currentOrderManager.getOrderEditViewModel().PasswordWifi))
                    {
                        var passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), currentOrderManager.getOrderEditViewModel().CheckInDate);
                        currentOrderManager.getOrderEditViewModel().PasswordWifi = passWifi;
                    }
                    // btnFinish.Enabled = true;
                    //Complete Order
                    _transactionCode = "";
                    SaleScreen3.FinishAndCloseOrder();
                }

                //End Splash Form + thông báo lỗi
                if (!result)
                {
                    Program.MainForm.HideSplashForm();
                    PosMessageDialog.ShowMessage(message);
                    LoadTab(tab);
                    btnFinish.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Program.MainForm.HideSplashForm();
                btnFinish.Enabled = true;
                log.Error("btnFinish_ClickAsync - " + ex);
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }


        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            SaleScreen3.PosPrinter.PrintBill(currentOrderManager.getOrderEditViewModel(),
                                    BillTypeEnum.Customer, MainForm.StoreInfo.PrinterBill, true);

            currentOrderManager.getOrderEditViewModel().TotalInvoicePrint += 1;
        }

        private void btnPrintCook_Click(object sender, EventArgs e)
        {
            SaleScreen3.PosPrinter.PrintBill(currentOrderManager.getOrderEditViewModel(),
                                    BillTypeEnum.Cook, MainForm.StoreInfo.PrinterCook1, true);
        }

        private void btnRefreshAllTab_Click(object sender, EventArgs e)
        {
            if (_pnlCustomerInfo == null || _pnlCustomerInfo.IsDisposed)
            {
                _pnlCustomerInfo = new CustomerInfoPanel2();
                _pnlCustomerInfo.ClearBarcode += ClearBarcode;
                _pnlCustomerInfo.ClearMemberProperty += ClearMemberProperty;
                _pnlCustomerInfo.BarcodeReceived += CheckCustomer;
            }
            if (_pnlPromotionInfo == null || _pnlPromotionInfo.IsDisposed)
            {
                _pnlPromotionInfo = new PromotionInfoPanel2();
                _pnlPromotionInfo.UpdateMoneyInfo += UpdateMoneyInfo;
            }
            if (_pnlPromotionInfo == null || _pnlPromotionInfo.IsDisposed)
            {
                _pnlPromotionInfo = new PromotionInfoPanel2();
                _pnlPromotionInfo.UpdateMoneyInfo += UpdateMoneyInfo;
            }
            _pnlCustomerInfo.btnClearMembershipCard_Click(sender, e);
            _pnlPaymentInfo.btnRemoveAll_Click(sender, e);
            _pnlPromotionInfo.btnPromotionRefresh_Click(sender, e);
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            HideForm();
        }


        //TODO
        //private void txtMembershipCard_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
        //        || (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
        //        || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)))
        //    {
        //        var text = this.txtMembershipCard.Text + (char)e.KeyValue;
        //        if (currentOrderManager.getOrderEditViewModel().BarCode != text)
        //        {
        //            currentOrderManager.getOrderEditViewModel().BarCode = text;
        //        }
        //    }
        //}


        private string _tmpTextInput = "";
        private void OrderPropetyPanel_KeyDown(object sender, KeyEventArgs e)
        {
            txtServedStaff.Select();

            DateTime currentKeyDown = UtcDateTime.Now();

            if (_isBarcode)
            {
                //Đang ở chế độ scan barcode | input nhanh
                if ((currentKeyDown - _lastKeyDownTime).TotalMilliseconds < _barcodeDurTime)
                {
                    //Key != enter (vẫn đang scan | input)
                    if (e.KeyCode != Keys.Enter)
                    {
                        _tmpTextInput += (char)e.KeyValue;
                    }
                    //Key == enter (scan hoàn tất)
                    else
                    {
                        //Loại bỏ các ký tự khác a-z, A-Z, 0-9
                        _tmpTextInput = Regex.Replace(_tmpTextInput, "[^0-9a-zA-Z]+", "");

                        CheckCustomer(_tmpTextInput);
                    }
                }
                else
                {
                    _isBarcode = false;
                    _tmpTextInput = ((char)e.KeyValue).ToString(); //Chi luu ky tu hien tai
                }
            }
            else
            {
                //isBarcode false
                if ((currentKeyDown - _lastKeyDownTime).TotalMilliseconds < _barcodeRegTime)
                {
                    _isBarcode = true;
                    _tmpTextInput += (char)e.KeyValue; //Ky tu truoc do thuoc ve day barcode
                }
                else
                {
                    _isBarcode = false;
                    _tmpTextInput = ((char)e.KeyValue).ToString(); //Chi luu ky tu hien tai
                }
            }
            _lastKeyDownTime = currentKeyDown;
        }

        public async void CheckCustomer(String barCode)
        {
            currentOrderManager.getOrderEditViewModel().BarCode = barCode;
            currentOrderManager.setCurrentCustomerModel(null);
            var customer = new CardCustomerModel();

            //message:Đang tìm thông tin thẻ
            var msg = MainForm.ResManager.GetString("OrderPropertyForm2_Card_Finding", MainForm.CultureInfo);
            LoadNotification(msg);

            try
            {
                CardCustomerModel customerModel = null;
                if (MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.Trim().ToLower() == "true")
                {
                    var cardDetailModel = DataExchanger.SkyConnectGetMemberCardInfo(barCode).Result;
                    //TEST
                    if (cardDetailModel != null)
                    {
                        customerModel = SkyConnectLoadCustomer(cardDetailModel);
                    }
                    LoadTab(OrderPropertyTabEnum.Customer);
                    if (string.IsNullOrEmpty(_transactionCode))
                        _transactionCode = GenTransactionCode();

                }
                else
                {
                    var cardDetailModel = DataExchanger.GetMemberCardInfo(barCode).Result;

                        //TEST
                        if (cardDetailModel != null)
                        {
                            customerModel = loadCustomer(cardDetailModel);
                        }
                        LoadTab(OrderPropertyTabEnum.Customer);
                        if (string.IsNullOrEmpty(_transactionCode))
                            _transactionCode = GenTransactionCode();
                }
                currentOrderManager.setCurrentCustomerModel(customerModel);
            }
            catch (Exception ex)
            {
                log.Error("CheckCustomer - " + ex);
                //lblNoti.Visible = false;
            }
            loadPromotion();
        }
        private string GenTransactionCode()
        {
            string transactioncode = MainForm.StoreInfo.StoreId.ToString() + "-" +
            InvoiceCodeGenerator.GenerateInvoiceCode();
            return transactioncode;
        }
        public CardCustomerModel loadCustomer(Object cardDetailModel)
        {
            //Remove all memberCard payment
            currentOrderManager.RemoveAllPayment(PaymentTypeEnum.MemberPayment);
            currentOrderManager.RemoveAllPayment(PaymentTypeEnum.GiftTalk);
            var customer = new CardCustomerModel();
            if (cardDetailModel != null)
            {
                dynamic result = cardDetailModel;
                switch ((int)(result.cardType ?? (int)PaymentTypeEnum.MemberPayment))
                {
                    case (int)PaymentTypeEnum.GiftTalk:
                        if (MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
                        {
                            var giftTalkModel = (GiftTalkModel)result.data;
                            customer = new CardCustomerModel()
                            {
                                CustomerName = giftTalkModel.name,
                                CustomerPhone = giftTalkModel.phone,
                                Code = giftTalkModel.account,
                                Status = CustomerTypeEnum.GiftTalk.ToString(),
                                Accounts = new List<CardAccountModel>()
                                        {
                                            new CardAccountModel()
                                            {
                                                AccountCode = giftTalkModel.account,
                                                Balance = giftTalkModel.balance,
                                                Type = (int)CardAccountTypeEnum.GiftAccount,
                                            }
                                        }
                            };
                            currentOrderManager.setCardType((int)PaymentTypeEnum.GiftTalk);
                        }
                        break;

                    case (int)PaymentTypeEnum.MemberPayment:
                        var customerModel = result;
                        customer = new CardCustomerModel()
                        {
                            CustomerID = customerModel.CustomerID,
                            CustomerName = customerModel.CustomerName,
                            Code = customerModel.Code,
                            Status = customerModel.Status,
                            Accounts = customerModel.Accounts,
                            CustomerPhone = customerModel.CustomerPhone,
                            CustomerAddress = customerModel.CustomerAddress,
                        };
                        if (customer != null && customer.CustomerID <= 0)
                        {
                            customer.CustomerID = null;
                        }
                        currentOrderManager.setCardType((int)PaymentTypeEnum.MemberPayment);
                        break;
                }
            }
            return customer;
        }

        public CardCustomerModel SkyConnectLoadCustomer(CardVM cardDetailModel)
        {
            //Remove all memberCard payment
            currentOrderManager.RemoveAllPayment(PaymentTypeEnum.MemberPayment);
            currentOrderManager.RemoveAllPayment(PaymentTypeEnum.GiftTalk);
            var customer = new CardCustomerModel();
            if (cardDetailModel != null)
            {
                dynamic result = cardDetailModel;
                if (MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
                {
                    customer = new CardCustomerModel()
                    {
                        CustomerName = cardDetailModel.CustomerName,
                        CustomerPhone = cardDetailModel.CustomerPhone,
                        Code = cardDetailModel.Code,
                        Status = CustomerTypeEnum.GiftTalk.ToString(),
                        Accounts = Converter.convertAccounts(cardDetailModel.Accounts)
                    };
                    currentOrderManager.setCardType((int)PaymentTypeEnum.GiftTalk);
                }

                customer = new CardCustomerModel()
                {
                    CustomerID = cardDetailModel.CustomerId,
                    CustomerName = cardDetailModel.CustomerName,
                    Code = cardDetailModel.Code,
                    Status = ((SkyConnectMembershipStatusEnum)cardDetailModel.MembershipStatus).ToString(),
                    Accounts = Converter.convertAccounts(cardDetailModel.Accounts),
                    CustomerPhone = cardDetailModel.CustomerPhone,
                    CustomerAddress = cardDetailModel.CustomerAddress,
                };
                if (customer != null && customer.CustomerID <= 0)
                {
                    customer.CustomerID = null;
                }
                currentOrderManager.setCardType((int)PaymentTypeEnum.MemberPayment);
            }
            return customer;
        }


        public void updateCustomerInfo()
        {
            string msg = "";

            //Load Point membership
            if (!currentOrderManager.isCurrentCustomerModelEmpty())
            {
                currentOrderManager.getOrderEditViewModel().DeliveryCustomer =
                    currentOrderManager.getCurrentCustomerModel().CustomerName ?? "";
                currentOrderManager.getOrderEditViewModel().DeliveryPhone =
                    currentOrderManager.getCurrentCustomerModel().CustomerPhone ?? "";
                currentOrderManager.getOrderEditViewModel().DeliveryAddress =
                    currentOrderManager.getCurrentCustomerModel().CustomerAddress ?? "";
                var custStatus = currentOrderManager.getCurrentCustomerModel().Status;
                if (custStatus == CustomerTypeEnum.Active.ToString())
                {
                    //Tiền:...
                    LoadMemberPoint();
                }
                else if (custStatus == CustomerTypeEnum.Inactive.ToString())
                {
                    //message:Thẻ chưa kích hoạt
                    msg = MainForm.ResManager.GetString("Sys_Inactive_Card", MainForm.CultureInfo);
                    LoadNotification(msg);
                }
                else if (custStatus == CustomerTypeEnum.Suspensed.ToString())
                {
                    //message:Thẻ tạm dừng
                    msg = MainForm.ResManager.GetString("Sys_Suspend_Card", MainForm.CultureInfo);
                    LoadNotification(msg);
                }
                else if (custStatus == CustomerTypeEnum.GiftTalk.ToString()
                    && MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
                {
                    LoadGiftCardDetail();
                }
                else
                {
                    //message:Không tìm thấy thông tin thẻ
                    msg = MainForm.ResManager.GetString("Sys_No_Finding_Card", MainForm.CultureInfo);
                    LoadNotification(msg);
                }
            }
            else
            {
                //message:RỚT MẠNG
                msg = MainForm.ResManager.GetString("Sys_Connection_Error", MainForm.CultureInfo);
                LoadNotification(msg);
            }
        }

        public void loadPromotion()
        {
            updateCustomerInfo();
            var barCode = currentOrderManager.getOrderEditViewModel().BarCode;
            //Tach prefix code tu server
            currentOrderManager.getOrderEditViewModel().PrefixBarCodes = new List<string>();
            if (!currentOrderManager.isCurrentCustomerModelEmpty()
                && currentOrderManager.getCurrentCustomerModel().Status
                    == CustomerTypeEnum.Active.ToString())
            {
                var apiCode = currentOrderManager.getCurrentCustomerModel().Code;

                if (barCode != apiCode)
                {
                    var codes = apiCode.Split('_');
                    foreach (var code in codes)
                    {
                        if (!string.IsNullOrEmpty(code) && code != barCode)
                        {
                            currentOrderManager.getOrderEditViewModel().PrefixBarCodes.Add(code + "_");
                        }
                    }
                }
            }

            if (_pnlCustomerInfo == null || _pnlCustomerInfo.IsDisposed)
            {
                _pnlCustomerInfo = new CustomerInfoPanel2();
                _pnlCustomerInfo.ClearBarcode += ClearBarcode;
                _pnlCustomerInfo.ClearMemberProperty += ClearMemberProperty;
                _pnlCustomerInfo.BarcodeReceived += CheckCustomer;
            }
            _pnlCustomerInfo.InputMemberCard(barCode);

            if (_pnlPromotionInfo == null || _pnlPromotionInfo.IsDisposed)
            {
                _pnlPromotionInfo = new PromotionInfoPanel2();
                _pnlPromotionInfo.UpdateMoneyInfo += UpdateMoneyInfo;
            }
            _pnlPromotionInfo.LoadPromotion();


            // Kiểm tra promotion có thể áp dụng với mã thẻ / account
            var availablePromo = new List<string>();
            foreach (var promotion in Program.context.getPromotions())
            {
                var canApply = false;

                // Check Regular Expression constrain:
                // Ko RegEx + Ko Barcode    -> false
                // Ko RegEx + Có Barcode    -> false
                // Có RegEx + Ko Barcode    -> false
                // Có RegEx + Có Barcode    -> check regex
                foreach (var promotionDetail in promotion.PromotionDetailViewModels)
                {
                    if (string.IsNullOrEmpty(promotionDetail.RegExCode))
                    {
                        //false
                    }
                    else if (string.IsNullOrEmpty(barCode))
                    {
                        //false
                    }
                    else
                    {
                        if (currentOrderManager.getOrderEditViewModel().PrefixBarCodes.Any())
                        {
                            foreach (var code in currentOrderManager.getOrderEditViewModel().PrefixBarCodes)
                            {
                                // prefix_barCode
                                string apiCode = code + barCode;
                                canApply = Regex.IsMatch(apiCode, promotionDetail.RegExCode);
                                if (canApply) break;
                            }
                        }
                        else
                        {
                            // barCode only
                            canApply = Regex.IsMatch(barCode, promotionDetail.RegExCode);
                        }
                    }
                    // chỉ cần check ít nhất 1 regex trùng là đc
                    if (canApply) break;
                }
                if (canApply)
                {
                    availablePromo.Add(promotion.PromotionName);
                }
            }

            //chuyển tab promotion nếu có khuyến mãi có thể áp dụng
            // ngược lại > tab payment
            if (availablePromo.Any())
            {
                lblNoti.Visible = false;
                txtAvailPromo.Visible = true;
                txtAvailPromo.Text = "Các khuyến mãi cho thẻ:\n ";
                foreach (var promo in availablePromo)
                {
                    txtAvailPromo.Text = txtAvailPromo.Text + "+" + promo.Trim() + ", ";
                }

                LoadTab(OrderPropertyTabEnum.Promotion);
            }
            else
            {
                UpdateMoneyInfo();
                LoadTab(OrderPropertyTabEnum.Payment, true);
            }

            this.Invalidate();
        }

        private void LoadNotification(string noti)
        {
            lblNoti.Text = noti;
            lblNoti.Visible = true;

            txtMoney.Visible = false;
            lblMoney.Visible = false;
            txtPoint.Visible = false;
            lblPoint.Visible = false;
            txtAvailPromo.Visible = false;
        }

        private void LoadMemberPoint()
        {
            if (!currentOrderManager.isCurrentCustomerModelEmpty())
            {
                var custStatus = currentOrderManager.getCurrentCustomerModel().Status;
                var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts
                                        .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);

                if (accountCredit != null && custStatus == CustomerTypeEnum.Active.ToString())
                {
                    lblNoti.Visible = false;

                    lblMoney.Visible = true;
                    txtMoney.Visible = true;
                    lblPoint.Visible = true;
                    txtPoint.Visible = false;   //TODO:

                    lblPoint.Text = "Điểm:";
                    lblMoney.Text = MainForm.ResManager.GetString("OrderPropertyForm2_Score", MainForm.CultureInfo) + ": ";
                    txtMoney.Text = string.Format("{0:n0}", accountCredit.Balance);
                }
            }
        }

        private void LoadGiftCardDetail()
        {
            if (MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
            {
                if (!currentOrderManager.isCurrentCustomerModelEmpty())
                {
                    var custStatus = currentOrderManager.getCurrentCustomerModel().Status;
                    var account =
                        currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a =>
                            a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    if (account != null && custStatus == CustomerTypeEnum.GiftTalk.ToString())
                    {
                        lblNoti.Visible = false;

                        lblMoney.Visible = true;
                        txtMoney.Visible = true;
                        lblPoint.Visible = false;
                        txtPoint.Visible = false;

                        lblMoney.Text = MainForm.ResManager.GetString("OrderPropertyForm2_Score", MainForm.CultureInfo) + ": ";
                        txtMoney.Text = string.Format("{0:n0}", account.Balance ?? 0);
                    }
                }
            }
        }

        private void btnPrintMomo_Click(object sender, EventArgs e)
        {
            if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
            {
                SaleScreen3.PosPrinter.PrintBillMomo(currentOrderManager.getOrderEditViewModel(),
                    BillTypeEnum.Customer, MainForm.StoreInfo.PrinterBill, true);

                currentOrderManager.getOrderEditViewModel().TotalInvoicePrint += 1;
            }

        }

        public void EnablePrintZalo(bool enable)
        {
            if (MainForm.StoreInfo.ZaloEnable.Trim().ToLower() == "true")
            {
                btnPrintMomo.Enabled = false;
                btnCheckMomo.Enabled = enable;
                BtnMomoPay.Enabled = false;
                btnFinish.Enabled = !enable;
            }
        }

        public void EnablePrintMomo(bool enable)
        {
            if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
            {
                btnPrintMomo.Enabled = false;
                btnCheckMomo.Enabled = enable;
                BtnMomoPay.Enabled = enable;
                btnFinish.Enabled = !enable;
            }
        }

        private async void btnCheckMomo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
                {
                    var text = MainForm.ResManager.GetString(
                        "ReportDateFilterDialog_Generate_Report_Waiting",
                        MainForm.CultureInfo);
                    Program.MainForm.ShowSplashForm(text);
                    var isSkyConnectEnable = bool.Parse(MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower());
                    OrderEditViewModel order = currentOrderManager.getOrderEditViewModel();
                    var message = "";
                    if (isSkyConnectEnable)
                    {
                        var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
                        var pDomain = new SkyConnectPaymentDomain(config);
                        //test data
                        //var orderMomo = pDomain.GetOrder("rpmp-test-1015", DateTime.Parse("2018-07-20 00:00:00"), (int)SkyConnectPartnerEnum.Momo);
                        var paymentType = Program.context.getCurrentOrderManager().paymentType;
                        OrderVM orderMomo = null;
                        if (paymentType == PaymentTypeEnum.MoMo)
                        {
                            orderMomo = pDomain.GetPaymentInformation(order.OrderCode, order.CheckInDate, (int)SkyConnectPartnerEnum.Momo);
                        }
                        else if (paymentType == PaymentTypeEnum.ZaloPay)
                        {
                            orderMomo = pDomain.GetPaymentInformation(order.OrderCode, order.CheckInDate, (int)SkyConnectPartnerEnum.ZaloPay);
                        }

                        if (orderMomo != null)
                        {
                            btnFinish.Enabled = true;
                            message = "Khách hàng đã thanh toán";

                        }
                        else
                        {
                            btnFinish.Enabled = true;
                            message = message = "Khách hàng chưa thanh toán";
                        }
                    }
                    else
                    {
                        var stringTime = DateTime.UtcNow;
                        var json = new
                        {
                            requestId = order.OrderCode + stringTime.ToString("dd-MM-yyyy HH:mm:ss"),
                            reference = order.OrderCode + order.CheckInDate.ToString("-yyMMdd-HHmm"),
                            created = order.CheckInDate.ToString("yyyy-MM-dd")
                        };

                        var jsonString = JsonConvert.SerializeObject(json);
                        #region Call API Momo
                        //call api momo TODO: Private Key
                        var connection = MainForm.StoreInfo.MomoConnection;
                        var resultMomo = await MomoService.callMomoService(connection, jsonString);
                        Program.MainForm.HideSplashForm();
                        if (resultMomo != null)
                        {
                            dynamic objectResultMomo = JsonConvert.DeserializeObject(resultMomo);
                            int responseCode = objectResultMomo.resultCode;
                            btnFinish.Enabled = true;

                            message = "";
                            if (responseCode == 0)
                            {
                                message = "Khách hàng đã thanh toán";
                            }
                            else if (responseCode == 4)
                            {
                                message = "Đang xử lý! Xin kiểm tra lại sau";
                            }
                            else if (responseCode == 1)
                            {
                                message = "Không có hóa đơn yêu cầu";
                            }
                            else
                            {
                                message = "Unexpected Error";
                            }

                            PosMessageDialog.ShowMessage(message);

                        }
                        else
                        {
                            PosMessageDialog.ShowMessage("Không kết nối được dịch vụ Momo");
                            btnFinish.Enabled = true;
                        }
                        //
                        #endregion
                    }

                    Program.MainForm.HideSplashForm();
                    PosMessageDialog.ShowMessage(message);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }



            // create inital value
            //TODO: create new call api
            //int storeId = Convert.ToInt32(int.Parse(MainForm.StoreInfo.StoreId));
            //OrderModel order = DataConverter.ConvertOrderModel(currentOrderManager.getOrderEditViewModel(), storeId);
            //SkyConnect.POS.Partners.Momo momo = new SkyConnect.POS.Partners.Momo();
            ////partner momo  is 0 
            //var resultMomo = momo.CheckMomoPayment(0, order);
            //var stringTime = DateTime.UtcNow;
            //#region Call API Momo
            //Program.MainForm.HideSplashForm();
            //if (resultMomo != null)

            //else
            //{
            //    PosMessageDialog.ShowMessage("Không kết nối được dịch vụ Momo");
            //    btnFinish.Enabled = true;
            //}


            //
            //#endregion
            //var client = new HttpClient();
            //client.Timeout = new TimeSpan(0, 2, 0);

            //var request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/pgp-encrypted"));

            //var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/pgp-encrypted");
            //request.Content = content;
            //var response = await client.SendAsync(request);

            //if (response.IsSuccessStatusCode)
            //{
            //    //MemoryStream receiveStream = new MemoryStream();
            //    //response.Content.CopyToAsync(receiveStream).Wait();
            //    //StreamReader sr = new StreamReader(receiveStream);

            //    //string responseMessage = await response.Content.ReadAsStringAsync();

            //    //dynamic responseObj = JsonConvert.DeserializeObject(responseMessage);

            //}
        }

        public async Task btnMoMoPayment_ClickAsync()
        {
            try
            {
                var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
                var pDomain = new SkyConnectPaymentDomain(config);
                var isEnableOnscreenKeyboard = true;
                var inputMomoCode = PosMessageDialog.YesNoDialogWithInput(
                                //message:Xin điền mã thanh toán
                                MainForm.ResManager.GetString("OrderPropertyForm2_Input_PaymentCode", MainForm.CultureInfo) + ":", MainForm.ResManager.GetString("Sys_Yes", MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_No", MainForm.CultureInfo),
                                isEnableOnscreenKeyboard, "");

                var paymentType = Program.context.getCurrentOrderManager().paymentType;
                var paymentTypeName = ((PaymentTypeEnum)paymentType).GetDisplayName();

                var message = "";
                if (inputMomoCode != null)
                {
                    if (inputMomoCode[0].Length != 0 && inputMomoCode[0] != null && inputMomoCode[1].Equals("OK"))
                    {

                        var text = MainForm.ResManager.GetString(
                            "ReportDateFilterDialog_Generate_Payment_Waiting",
                            MainForm.CultureInfo);
                        Program.MainForm.ShowSplashForm(text);


                        #region Logic enxternal payment

                        string code = "";
                        if (paymentType == PaymentTypeEnum.MoMo)
                        {
                            code = inputMomoCode[0].Replace("MM", "");
                            code = code.Replace("mm", "");
                        }
                        else
                        {
                            code = inputMomoCode[0];
                        }
                        OrderEditViewModel currentOrder = currentOrderManager.getOrderEditViewModel();
                        var order = new OrderVM()
                        {
                            OrderCode = currentOrder.OrderCode,
                            CheckInDate = currentOrder.CheckInDate,
                            TotalAmount = currentOrder.TotalAmount,
                            Discount = currentOrder.Discount,
                            FinalAmount = currentOrder.FinalAmount,
                            OrderStatus = currentOrder.OrderType,
                            OrderType = currentOrder.OrderType,
                            CustomerID = currentOrder.CustomerID,
                            PaymentCode = code
                        };
                        OrderVM orderExternalPaymentGateways = null;
                        switch (paymentType)
                        {
                            case PaymentTypeEnum.MoMo:
                                orderExternalPaymentGateways = await pDomain.ConfirmPayment(order, (int)SkyConnectPartnerEnum.Momo);
                                break;
                            case PaymentTypeEnum.ZaloPay:
                                orderExternalPaymentGateways = await pDomain.ConfirmPayment(order, (int)SkyConnectPartnerEnum.ZaloPay);
                                break;

                        }
                        if (orderExternalPaymentGateways != null)
                        {
                            message = $"Thanh toán {paymentTypeName} thành công";
                            _pnlPaymentInfo.addPayment();
                            Program.MainForm.HideSplashForm();
                            btnFinish_ClickAsync(null, null);
                        }
                        else
                        {
                            message = $"Thanh toán qua {paymentTypeName} thất bại.";
                            Program.MainForm.HideSplashForm();
                            PosMessageDialog.ShowMessage(message);
                            await btnMoMoPayment_ClickAsync();
                        }
                        #endregion

                    }
                    else
                    {
                        message = $"Vui lòng nhập lại mã {paymentTypeName}";
                        Program.MainForm.HideSplashForm();
                        PosMessageDialog.ShowMessage(message);
                        await btnMoMoPayment_ClickAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                PosMessageDialog.ShowMessage("Hệ thống có lỗi xảy ra!");
                Program.MainForm.HideSplashForm();
                log.Error(ex);
            }
        }
    }
}

