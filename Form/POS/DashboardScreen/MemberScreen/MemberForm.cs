using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.CustomControl;
using POS.Common;
using POS.ExchangeData;
using POS.Repository;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using POS.Utils;
using POS.SaleScreen;
using log4net;
using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Utils;

namespace POS.DashboardScreen.MemberScreen
{
    public partial class MemberForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static StoreInfo _storeInfo { get; set; }
        public static PosConfig _posConfig { get; set; }

        public bool isLinked = true;

        public CardCustomerModel _customerModel { get; set; }
        public PaymentEditViewModel _payment { get; set; }
        private string _transactioncode = "";

        double receivedAmount = 0;
        //double paymentAmount = 0;

        public MemberForm(StoreInfo storeInfo, PosConfig posConfig)
        {
            InitializeComponent();
            LoadAllSampleCard();
            _storeInfo = storeInfo;
            _posConfig = posConfig;

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCardCode);
            }
            this.pnlNumPad.Textbox = txtValue;
            this.txtCardCode.KeyPress += CardCode_KeyPress;

            GenerateLayout();
            UpdateMoneyInfo();
        }

        private string tmpTextInput = "";
        private bool isBarcode = false;

        private DateTime lastKeyDownTime;
        private int _barcodeRegTime = 100;
        private int _barcodeDurTime = 200;

        private void CardCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime currentKeyDown = UtcDateTime.Now();
            //Debug.WriteLine((currentKeyDown - lastKeyDownTime).TotalMilliseconds);

            if (isBarcode)
            {
                //Đang ở chế độ scan barcode | input nhanh
                if ((currentKeyDown - lastKeyDownTime).TotalMilliseconds < _barcodeDurTime)
                {
                    //Key != enter (vẫn đang scan | input)
                    if (e.KeyChar != 13)
                    {
                        tmpTextInput += e.KeyChar;
                    }
                    //Key == enter (scan hoàn tất)
                    else
                    {
                        //TO TEST:
                        //tmpTextInput = "0010231234";

                        GenerateLayout();
                        txtCardCode.Text = tmpTextInput;
                        if (MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.Trim().ToLower() == "true")
                        {
                            SkyConnectGetCardInfo(tmpTextInput);
                        }
                        else
                        {
                            GetCardInfo(tmpTextInput);
                        }

                        isBarcode = false;
                        this.Invalidate();
                        tmpTextInput = "";
                    }
                }
                else
                {
                    isBarcode = false;
                    tmpTextInput = e.KeyChar.ToString(); //Chi luu ky tu hien tai
                }
            }
            else
            {
                //isBarcode false
                if ((currentKeyDown - lastKeyDownTime).TotalMilliseconds < _barcodeRegTime)
                {
                    //txtOrderNotes.Enabled = false;
                    isBarcode = true;
                    tmpTextInput += e.KeyChar.ToString(); //Ky tu truoc do thuoc ve day barcode

                    //SaleScreen3.CurrentOrderManager().getOrderEditViewModel().BarCode = string.Empty;
                }
                else
                {
                    isBarcode = false;
                    tmpTextInput = e.KeyChar.ToString(); //Chi luu ky tu hien tai
                }
            }

            lastKeyDownTime = currentKeyDown;
        }

        private string GenTransactionCode()
        {
            string transactioncode = MainForm.StoreInfo.StoreId.ToString() + "-" +
            InvoiceCodeGenerator.GenerateInvoiceCode();
            return transactioncode;
        }
        //Call API
      void SkyConnectGetCardInfo(string cardcode)
        {
            var customer = new CardCustomerModel();
            try
            {
                _customerModel = null;

                var cardModel = DataExchanger.SkyConnectGetMemberCardInfo(cardcode).Result;
                //var customerModel = DataExchanger.GetMemberCardInfo(cardcode);

                    if (cardModel != null)
                    {
                        customer = new CardCustomerModel()
                        {
                            CustomerID = cardModel.CustomerId,
                            CustomerName = cardModel.CustomerName,
                            Code = cardModel.Code,
                            Accounts = Converter.convertAccounts(cardModel.Accounts),
                            Status = ((SkyConnectMembershipStatusEnum)cardModel.MembershipStatus).ToString(),
                        };
                        this._customerModel = customer;
                        CurrentOrderManager currentOrder = Program.context.getCurrentOrderManager();
                        currentOrder.setCurrentCustomerModel(customer);
                        ShowMemberInfo();

                        var creditAccount = _customerModel.Accounts
                             .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);

                        if (creditAccount == null) PosMessageDialog.ShowMessage("Thông tin thẻ không hợp lệ . Liên hệ admin để được giải quyết ");
                    
                }
                else
                {
                    PosMessageDialog.ShowMessage("Không tìm thấy thẻ");
                }

            }
            catch (Exception ex)
            {
                log.Error("GetCardInfo (" + cardcode + ") - " + ex);
            }
        }

        //Call API
        async void GetCardInfo(string cardcode)
        {
            var customer = new CardCustomerModel();
            try
            {
                _customerModel = null;

                var customerModel = DataExchanger.GetMemberCardInfo(cardcode).Result;

                    if (customerModel != null)
                    {
                        customer = new CardCustomerModel()
                        {
                            CustomerID = customerModel.CustomerID,
                            CustomerName = customerModel.CustomerName,
                            Code = customerModel.Code,
                            Status = customerModel.Status,
                            Accounts = customerModel.Accounts
                        };
                        this._customerModel = customer;

                        ShowMemberInfo();

                        var creditAccount = _customerModel.Accounts
                             .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);

                        if (creditAccount == null) PosMessageDialog.ShowMessage("Thông tin thẻ không hợp lệ . Liên hệ admin để được giải quyết ");
                    }
                
            }
            catch (Exception ex)
            {
                log.Error("GetCardInfo (" + cardcode + ") - " + ex);
            }
        }

        //Call API
        async Task<bool> FinishPayment()
        {
            var listTransactionAccounts = new List<TransactionAccountModel>();
            decimal changeAmount = 0;
            if (_payment != null)
            {
                changeAmount = (decimal)_payment.Amount;
            }
            else
            {
                return false;
            }

            var creditAccount = _customerModel.Accounts
                    .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);

            if (creditAccount != null)
            {
                var accountModel = new TransactionAccountModel
                {
                    AccountCode = creditAccount.AccountCode,
                    IsChange = false,
                    IsIncrease = true,
                    ChangeAmount = changeAmount,
                    TransactionCode = _transactioncode
                };

                if (changeAmount > 0)
                {
                    accountModel.IsChange = true;       //co thay doi
                    accountModel.IsIncrease = true;     //tang credit
                }

                listTransactionAccounts.Add(accountModel);
            }

            foreach (var account in _customerModel.Accounts)
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

            if (listTransactionAccounts.Any())
            {
                var userID = MainForm.CurrentAccount.AccountId;
                var transaction = DataExchanger.SendTransaction((int)PaymentTypeEnum.MemberPayment, listTransactionAccounts, userID);

                if (await Task.WhenAny(transaction) == transaction)
                {
                    return transaction.Result.success;
                }
                else
                {
                    //time out
                    return false;
                }
            }
            else
            {
                isLinked = false;
                return false;
            }
        }

        //private async Task<bool> SkyConnectFinishPayment(OrderVM orderVM, int partnerId)
        //{
        //    var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
        //    var pDomain = new SkyConnectPaymentDomain(config);
        //    decimal changeAmount = 0;
        //    if (_payment != null)
        //    {
        //        changeAmount = (decimal)_payment.Amount;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    var payment = pDomain.ConfirmPayment(orderVM, partnerId);
        //    return true;

        //}



        private void ShowMemberInfo()
        {
            if (_customerModel != null)
            {
                this.txtName.Visible = true;
                this.txtPhone.Visible = true;
                this.txtCardStatus.Visible = true;

                this.txtName.Text = _customerModel.CustomerName;
                //this.txtPhone.Text = CustomerModel.;
                if (_customerModel.Status == CustomerTypeEnum.Active.ToString())
                {
                    //message:Thẻ đã kích hoạt
                    this.txtCardStatus.Text = MainForm.ResManager.GetString("Memberform_Active_Card", MainForm.CultureInfo);
                }
                else if (_customerModel.Status == CustomerTypeEnum.Inactive.ToString())
                {
                    //message:Thẻ chưa kích hoạt
                    this.txtCardStatus.Text = MainForm.ResManager.GetString("Sys_Inactive_Card", MainForm.CultureInfo);
                }
                else if (_customerModel.Status == CustomerTypeEnum.Suspensed.ToString())
                {
                    //message:Thẻ tạm dừng
                    this.txtCardStatus.Text = MainForm.ResManager.GetString("Sys_Suspend_Card", MainForm.CultureInfo);
                }

                var accountCredit = _customerModel.Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                if (accountCredit != null
                    && _customerModel.Status == CustomerTypeEnum.Active.ToString())
                {
                    this.txtCreditMoney.Visible = true;
                    this.txtCreditMoney.Text = string.Format("{0:n0}", accountCredit.Balance);
                }

                //this.btnPrintHistory.Show();
            }
            else
            {
                this.txtCardStatus.Visible = true;
                //message:Không tìm thấy thông tin thẻ
                this.txtCardStatus.Text = MainForm.ResManager.GetString("Sys_No_Finding_Card", MainForm.CultureInfo);
            }

            PaymentMemberChange();
        }

        private void PaymentMemberChange()
        {
            double amount = 0;
            if (_payment != null)
            {
                amount = _payment.Amount;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            this.txtCardCode.Focus();
            base.OnShown(e);
        }

        private void GenerateLayout()
        {
            _customerModel = null;
            ResetAllText();
            HideText();
            txtCardCode.Focus();

            lblTitle.TextValue = MainForm.ResManager.GetString("MemberForm_Title", MainForm.CultureInfo);
            bsBtnMembershipCard.TextValue = MainForm.ResManager.GetString("Sys_MemberCardId", MainForm.CultureInfo);
            //bootstrapButton3.TextValue = MainForm.ResManager.GetString("MemberForm_Account_Payment", MainForm.CultureInfo);
            bootstrapButton1.TextValue = MainForm.ResManager.GetString("MemberForm_Extra_Pay", MainForm.CultureInfo);
            btnRefreshCode.TextValue = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
            btnSearchMember.TextValue = MainForm.ResManager.GetString("MemberForm_Find", MainForm.CultureInfo);
            btnAddPayment.TextValue = MainForm.ResManager.GetString("Sys_Confirm", MainForm.CultureInfo);
            bsBtnCustomerName.TextValue = MainForm.ResManager.GetString("Sys_Customer_Name", MainForm.CultureInfo);
            bsBtnCustomerPhone.TextValue = MainForm.ResManager.GetString("Sys_Phone_Number", MainForm.CultureInfo);
            bootstrapButton2.TextValue = MainForm.ResManager.GetString("Memberform_Card_Status", MainForm.CultureInfo);
            btnCancel.TextValue = MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo);
            btnFinish.TextValue = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);

            btnPrintHistory.Hide();
        }

        private void ResetAllText()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtCardCode.Text = "";
            txtCardStatus.Text = "";
            txtCreditMoney.Text = "";
            txtMoneyUnit.Text = "VNĐ";
        }

        private void HideText()
        {
            txtName.Hide();
            txtPhone.Hide();
            txtCreditMoney.Hide();
            txtMoneyUnit.Hide();
        }

        private void CloseForm()
        {
            this.Close();
            Program.MainForm.LoadDashboard();
        }

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            var cardcode = txtCardCode.Text;
            if (!string.IsNullOrEmpty(cardcode))
            {
                if (MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.Trim().ToLower() == "true")
                {
                    SkyConnectGetCardInfo(cardcode);
                }
                else
                {
                    GetCardInfo(cardcode);
                }

            }
        }

        private void btnRefreshCode_Click(object sender, EventArgs e)
        {
            GenerateLayout();
        }

        private void btnRefreshAllPayment_Click(object sender, EventArgs e)
        {
            _payment = null;
            PaymentMemberChange();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private bool CheckMember()
        {
            if (_customerModel != null)
            {
                var custName = this._customerModel.CustomerName;
                if (custName == null || string.Empty.Equals(custName))
                {
                    return false;
                }
                return true;
            }
            else return false;
        }
        private void DisableMemberForm()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = false;
            }
        }

        private void EnableMemberForm()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = true;
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            //Check Flag
            var result = true;
            var message = "";

            //message:Đang xử lý
            Program.MainForm.ShowSplashForm(
                    MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
                    MainForm.CultureInfo));
            DisableMemberForm();
            try
            {
                if (!CheckMember())
                {
                    result = false;
                    message = MainForm.ResManager.GetString("OrderPropetyPanel_Customer_Empty", MainForm.CultureInfo);
                    //message:Thông tin khách hàng thiếu. Vui lòng nhập đầy đủ và lưu
                }

                if (result)
                {
                    var selected = ddlSampleCard.SelectedItem;
                    if (selected == null)
                    {
                        result = false;
                        message = "Chưa chọn mệnh giá nạp!";
                    }
                }

                if (result)
                {
                    if ((_payment == null) || _payment != null && _payment.Amount <= 0)
                    {
                        result = false;
                        message = MainForm.ResManager.GetString("Sys_Payment_Not_Enough", MainForm.CultureInfo);
                        //message:Tiền thanh toán chưa đủ!
                    }
                }

                if (result)
                {

                    if (MainForm.StoreInfo.SkyConnectEnable.ToString().Trim() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.ToString().Trim() == "true")
                    {
                        var creditAccount = _customerModel.Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                        var currentAmount = (double)creditAccount.Balance;

                        var product = (ProductViewModel)ddlSampleCard.SelectedItem;

                        //SaleScreen3.CreateOrderCard(product, receivedAmount, _customerModel.CustomerID);
                        SaleScreen3.CreateOrderCard(product, _payment.Amount, _customerModel.CustomerID);
                        Program.MainForm.HideSplashForm();
                        CloseForm();
                    }
                    else
                    {
                        var rs = await FinishPayment();
                        if (rs == true)
                        {
                            var creditAccount = _customerModel.Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                            var currentAmount = (double)creditAccount.Balance;

                            var product = (ProductViewModel)ddlSampleCard.SelectedItem;

                            SaleScreen3.CreateOrderCard(product, _payment.Amount, _customerModel.CustomerID);
                            Program.MainForm.HideSplashForm();
                            
                            PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("Buy_Card_Success", MainForm.CultureInfo));
                            CloseForm();
                        }
                        else
                        {
                            result = false;
                            message = MainForm.ResManager.GetString("OrderPropertyForm2_Payment_No_Connection_Error", MainForm.CultureInfo);
                            if (!isLinked)
                            {
                                message = "Thẻ chưa được kích hoạt vui lòng kiểm tra lại ";
                                isLinked = true;
                            }
                        }
                    }
                    
                }
                if (!result)
                {
                    Program.MainForm.HideSplashForm();
                    PosMessageDialog.ShowMessage(message);
                }
            }
            catch (Exception ex)
            {
                Program.MainForm.HideSplashForm();
                PosMessageDialog.ShowMessage(message);
                log.Error("btnFinish_Click - " + ex);
            }
            EnableMemberForm();
        }

        //Money quick click
        private void btnQuickMoney_Click(object sender, EventArgs e)
        {
            try
            {
                var button = (BootstrapButton)sender;
                var value = Int32.Parse(button.Tag.ToString());
            }
            catch (Exception ex)
            {
                log.Error("btnQuickMoney_Click - " + ex);
            }
        }

        private void LoadAllSampleCard()
        {
            var tmpList = Program.context.getAvailableSingleProducts().Where(p => p.ProductType == (int)ProductTypeEnum.CardPayment);

            var productList = tmpList.OrderBy(p => p.Price).ToList();

            ddlSampleCard.DataSource = productList;
            ddlSampleCard.ValueMember = "Code";
            ddlSampleCard.DisplayMember = "ProductName";

            ddlSampleCard.SelectedValue = "-";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(MainForm.StoreInfo, MainForm.PosConfig);

            if (DataExchanger.CheckForInternetConnection())
            {
                registerForm.ShowDialog();
            }
            else PosMessageDialog.ShowMessage("Kiểm tra lại kết nối mạng ! Không thể đăng ký được");
        }

        private void btnRefreshPayment_Click(object sender, EventArgs e)
        {
            txtValue.Value = string.Format("{0:####}", 0);
            txtValue.TextValue = string.Format("{0:n0}", 0);
            if (_payment != null)
            {
                _payment.Amount = -1;
            }
            receivedAmount = 0;
            UpdateMoneyInfo();

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_transactioncode))
                _transactioncode = GenTransactionCode();
            double amount = 0;
            if (_customerModel != null
                && txtValue.Value != null
                && txtValue.Value != "")
            {
                amount = double.Parse(txtValue.Value);
                //if (amount == 0) 
                //    amount = double.Parse(txtValue.TextValue);

                if (_payment == null)
                {
                    _payment = new PaymentEditViewModel()
                    {
                        PaymentID = 0,
                        Type = (int)PaymentTypeEnum.MemberPayment,
                        Amount = 0,
                        PayTime = UtcDateTime.Now(),
                        //OrderId = OrderEditViewModel.OrderId,
                        //OrderEditViewModel = OrderEditViewModel,
                    };
                }

                var selected = ddlSampleCard.SelectedItem;
                var price = 0;

                if (selected != null)
                {
                    var currentProduct = (ProductViewModel)selected;

                    price = (int)currentProduct.Price;
                }

                _payment.Amount = price;

                if (txtValue.Value != null && txtValue.Value != "")
                {
                    receivedAmount = int.Parse(txtValue.Value);
                }
                //kiem tra xem tong tien nhan duoc co it hon tien mua khong 
                if (_payment.Amount > receivedAmount)
                {
                    //_payment.Amount<0 ==> khong du tien tra
                    _payment.Amount = -1;
                }
                txtValue.Value = string.Format("{0:####}", 0);
                txtValue.TextValue = string.Format("{0:n0}", 0);
            }

            PaymentMemberChange();
            UpdateMoneyInfo();
        }

        public void UpdateMoneyInfo()
        {
            try
            {
                lblFinalAmount.Text = "0";
                lblReceived.Text = "0";
                lblExchange.Text = "0";

                var selected = ddlSampleCard.SelectedItem;

                if (selected != null)
                {
                    var currentProduct = (ProductViewModel)selected;

                    var finalAmount = currentProduct.Price;
                    var final = string.Format("{0:n0}", finalAmount);
                    var received = string.Format("{0:n0}", receivedAmount);
                    var exchange = string.Format("{0:n0}", receivedAmount - finalAmount);

                    // udpate payment amount
                    //paymentAmount = finalAmount;

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
                }
            }
            catch (Exception ex)
            {
                log.Error("UpdateMoneyInfo - " + ex);
            }
        }

        private void ddlSampleCard_Click(object sender, EventArgs e)
        {
            this.ddlSampleCard.DroppedDown = true;
        }

        private void ddlSampleCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMoneyInfo();

            var selected = ddlSampleCard.SelectedItem;
            var price = 0;

            if (selected != null)
            {
                var currentProduct = (ProductViewModel)selected;

                price = (int)currentProduct.Price;
            }

            txtValue.TextValue = string.Format("{0:n0}", price);
            txtValue.Value = price.ToString();
        }

        private void btnPrintHistory_Click(object sender, EventArgs e)
        {

        }
    }
}
