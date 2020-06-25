using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.ExchangeDataModel;
using log4net;

namespace POS.SaleScreen
{
    public partial class PaymentInfoPanel2 : UserControl
    {
        public static PaymentTypeConfig _paymentConfig { get; set; }
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private PaymentTypeEnum _currentPaymentType;

        public int rowPosition = -1;

        public event Action UpdateMoneyInfo;
        public event Action ReloadMemberPoint;


        public PaymentInfoPanel2()
        {
            InitializeComponent();
            _paymentConfig = MainForm.PaymentType;
            GenerateLayout();
        }


        private void GenerateLayout()
        {
            if (MainForm.PosConfig.EnableOwe.Trim().ToLower() == "false")
            {
                btnDebt.Hide();
            }
            LoadTabs();

            // default textbox numpad
            pnlNumPad.Textbox = txtValue;

            btnDebt.Hide();
            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCode);
            }

            this.btnTab1.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Cash", MainForm.CultureInfo);
            this.btnTab2.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Visa_Card", MainForm.CultureInfo);
            this.btnTab3.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Master_Card", MainForm.CultureInfo);
            this.btnTab4.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Other_CreditCard", MainForm.CultureInfo);
            this.btnTab5.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Member_Card", MainForm.CultureInfo);
            this.btnTab6.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Voucher", MainForm.CultureInfo);
            this.btnTab7.TextValue = MainForm.ResManager.GetString("Sys_Other", MainForm.CultureInfo);
            this.btnTab8.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Debt", MainForm.CultureInfo);

            this.lblCash.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Money_Amount", MainForm.CultureInfo) + ":";
            this.lblCode.Text = "Mã:";
            this.btnPaymentInfoRefresh.TextValue = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
            this.btnAddPayment.TextValue = MainForm.ResManager.GetString("Sys_Confirm", MainForm.CultureInfo);

            this.lblTLP0.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Ordinal_Number", MainForm.CultureInfo);
            this.lblTLP1.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Pay_By", MainForm.CultureInfo);
            this.lblTLP2.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Money_Amount", MainForm.CultureInfo);
            this.lblTLP3.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Time", MainForm.CultureInfo);
            this.btnDebt.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Remain_Debt", MainForm.CultureInfo);

            this.btnRemove.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Delete", MainForm.CultureInfo);
            this.btnRemoveAll.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Delete_All", MainForm.CultureInfo);
        }

        private void ConfigTab(BootstrapButton button, string config)
        {
            switch (config)
            {
                case "money":
                    button.Tag = PaymentTypeEnum.Cash;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Cash", MainForm.CultureInfo);
                    break;
                case "cc-visa":
                    button.Tag = PaymentTypeEnum.VisaCard;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Visa_Card", MainForm.CultureInfo);
                    break;
                case "cc-mastercard":
                    button.Tag = PaymentTypeEnum.MasterCard;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Master_Card", MainForm.CultureInfo);
                    break;
                case "ticket":
                    button.Tag = PaymentTypeEnum.Voucher;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Voucher", MainForm.CultureInfo);
                    break;
                case "cc":
                    button.Tag = PaymentTypeEnum.Card;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Other_CreditCard", MainForm.CultureInfo);
                    break;
                case "users":
                    button.Tag = PaymentTypeEnum.MemberPayment;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Member_Card", MainForm.CultureInfo);
                    break;
                case "hashtag":
                    button.Tag = PaymentTypeEnum.Other;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("Sys_Other", MainForm.CultureInfo);
                    break;
                case "star-half-o":
                    button.Tag = PaymentTypeEnum.AccountReceivable;
                    button.ImageCss = config;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Debt", MainForm.CultureInfo);
                    break;
                case "grabpay":
                    button.Tag = PaymentTypeEnum.GrabPay;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_GrabPay", MainForm.CultureInfo);
                    break;
                case "grabfood":
                    button.Tag = PaymentTypeEnum.GrabFood;
                    button.TextValue = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_GrabFood", MainForm.CultureInfo);
                    break;
                case "btc":
                    if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
                    {
                        button.Tag = PaymentTypeEnum.MoMo;
                        button.ImageCss = config;
                        button.TextValue =
                            MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_MoMo", MainForm.CultureInfo);
                    }
                    else
                    {
                        button.Hide();
                    }
                    break;
                case "square":
                    if (MainForm.StoreInfo.ZaloEnable.Trim().ToLower() == "true")
                    {
                        button.Tag = PaymentTypeEnum.ZaloPay;
                        button.ImageCss = config;
                        button.TextValue =
                            MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_Zalo", MainForm.CultureInfo);
                    }
                    else
                    {
                        button.Hide();
                    }
                    break;
                case "vcard":
                    if (MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
                    {
                        button.Tag = PaymentTypeEnum.GiftTalk;
                        button.ImageCss = config;
                        button.TextValue =
                            MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype_GiftTalk", MainForm.CultureInfo);
                    }
                    else
                    {
                        button.Hide();
                    }
                    break;
                default:
                    button.Hide();
                    break;
            }
        }

        private void LoadTabs()
        {
            //_currentPaymentType = PaymentTypeEnum.Cash;

            ConfigTab(btnTab1, _paymentConfig.Tab1);
            ConfigTab(btnTab2, _paymentConfig.Tab2);
            ConfigTab(btnTab3, _paymentConfig.Tab3);
            ConfigTab(btnTab4, _paymentConfig.Tab4);
            ConfigTab(btnTab5, _paymentConfig.Tab5);
            ConfigTab(btnTab6, _paymentConfig.Tab6);
            ConfigTab(btnTab7, _paymentConfig.Tab7);
            ConfigTab(btnTab8, _paymentConfig.Tab8);

            btnTab1.ActiveBackgroudColor = Color.Black;
            btnTab2.ActiveBackgroudColor = Color.Black;
            btnTab3.ActiveBackgroudColor = Color.Black;
            btnTab4.ActiveBackgroudColor = Color.Black;
            btnTab5.ActiveBackgroudColor = Color.Black;
            btnTab6.ActiveBackgroudColor = Color.Black;
            btnTab7.ActiveBackgroudColor = Color.Black;
            btnTab8.ActiveBackgroudColor = Color.Black;

            btnTab1.IsActive = false;
            btnTab2.IsActive = false;
            btnTab3.IsActive = false;
            btnTab4.IsActive = false;
            btnTab5.IsActive = false;
            btnTab6.IsActive = false;
            btnTab7.IsActive = false;
            btnTab8.IsActive = false;

            var btnGroup = pnlTabs.Controls.Cast<BootstrapButton>();

            foreach (var button in btnGroup)
            {
                if (button.Tag != null)
                {
                    if (button != null)
                    {
                        if ((PaymentTypeEnum)button.Tag == _currentPaymentType)
                        {
                            button.IsActive = true;
                            break;
                        }
                    }
                }
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            var button = (BootstrapButton)sender;
            ChangePaymentType(button);
        }

        private void ChangePaymentType(BootstrapButton button)
        {
            lblPaymentType.Text = MainForm.ResManager.GetString("PaymentInfoPanel2_Paytype", MainForm.CultureInfo) + " " + button.TextValue.ToUpper() + ":";
            _currentPaymentType = (PaymentTypeEnum)button.Tag;
            currentOrderManager.paymentType = _currentPaymentType;

            button.IsActive = true;
            var buttons = pnlTabs.Controls.Cast<BootstrapButton>();
            foreach (var b in buttons)
            {
                if (b.Tag != null)
                {
                    if (b != button)
                    {
                        b.IsActive = false;
                    }
                }
            }

            if (ParentForm != null)
            {
                if (_currentPaymentType == PaymentTypeEnum.MoMo || _currentPaymentType == PaymentTypeEnum.ZaloPay)
                {
                    //if(_currentPaymentType == PaymentTypeEnum.Zalo)
                    //{
                    //    ((OrderPropertyForm2)ParentForm).EnablePrintZalo(true);
                    //} else
                    //{
                    //    ((OrderPropertyForm2)ParentForm).EnablePrintMomo(true);
                    //}
                    OrderPropertyForm2 orderProp = new OrderPropertyForm2();
                    orderProp.btnMoMoPayment_ClickAsync().Wait();
                }
                else
                {
                    ((OrderPropertyForm2)ParentForm).EnablePrintMomo(false);
                }
            }
        }

        private void btnPaymentInfoRefresh_Click(object sender, EventArgs e)
        {
            txtValue.Value = "";
            txtValue.TextValue = "";
            txtCode.Text = null;
            LoadTabs();

            //ChangePaymentType(btnTab1);
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            addPayment();
        }

        public void addPayment()
        {
            double amount = 0;
            if (txtValue.Value != null && txtValue.Value != "")
            {
                amount = double.Parse(txtValue.Value);
                string code = null;
                if (!string.IsNullOrEmpty(txtCode.Text))
                {
                    code = txtCode.Text;
                }

                /// Nợ (chưa xử lý):            AccountReceivable
                /// Các loại voucher, coupon:   Voucher, Other
                /// Tiền mặt:                   Cash
                /// Tiền mặt trả lại:           ExchangeCash  
                /// Các loại thẻ ngân hàng:     Card, MasterCard, VisaCard
                /// Thanh toán thẻ thành viên:  MemberPayment, GiftTalk
                /// Khác:                       MoMo
                if (_currentPaymentType == PaymentTypeEnum.MemberPayment 
                    || (_currentPaymentType == PaymentTypeEnum.GiftTalk && MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true"))
                {
                    if (! currentOrderManager.isCurrentCustomerModelEmpty()
                        && (_currentPaymentType != PaymentTypeEnum.GiftTalk || currentOrderManager.getCardType() != null))
                    {
                        //var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.AccountTypeID == (int)CardAccountTypeEnum.CreditAccount);
                        var tmpReceive = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.Sum(p => p.Amount);
                        if (amount > currentOrderManager.getOrderEditViewModel().FinalAmount
                                    + currentOrderManager.getOrderEditViewModel().VATAmount
                                    - tmpReceive)
                        {
                            amount = currentOrderManager.getOrderEditViewModel().FinalAmount
                                    + currentOrderManager.getOrderEditViewModel().VATAmount
                                    - tmpReceive;
                        }

                        //loại tài khoản trong thẻ
                        var accountType = CardAccountTypeEnum.CreditAccount;
                        if (_currentPaymentType == PaymentTypeEnum.GiftTalk) { accountType = CardAccountTypeEnum.GiftAccount; }

                        //chỉ được thanh toán tối đa số tiền trong tài khoản
                        var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)accountType);
                        if (accountCredit != null)
                        {
                            //trạng thái tài khoản thẻ
                            var accountStatus = currentOrderManager.getCurrentCustomerModel().Status;

                            if (accountCredit.Balance > 0
                                && ((accountStatus == CustomerTypeEnum.Active.ToString() && _currentPaymentType == PaymentTypeEnum.MemberPayment)
                                    || (accountStatus == CustomerTypeEnum.GiftTalk.ToString() && _currentPaymentType == PaymentTypeEnum.GiftTalk)))
                            {
                                if ((double)accountCredit.Balance >= amount)
                                {
                                    //balance > amount thi thanh toan
                                    accountCredit.Balance = accountCredit.Balance - amount;
                                }
                                else
                                {
                                    //balance nho hon amount thi thanh toan bang so balance
                                    amount = (double)accountCredit.Balance;
                                    accountCredit.Balance = 0;
                                }
                            }
                            else
                            {
                                amount = 0;
                            }

                            if (amount > 0)
                            {
                                //thêm lần thanh toán
                                currentOrderManager.UpdatePayment(_currentPaymentType, amount, code);
                            }
                        }
                    }
                }
                else if (_currentPaymentType == PaymentTypeEnum.Card
                         || _currentPaymentType == PaymentTypeEnum.VisaCard
                         || _currentPaymentType == PaymentTypeEnum.MasterCard
                         || _currentPaymentType == PaymentTypeEnum.MoMo 
                         || _currentPaymentType == PaymentTypeEnum.ZaloPay
                         || _currentPaymentType == PaymentTypeEnum.GrabPay
                         || _currentPaymentType == PaymentTypeEnum.GrabFood)
                {
                    var tmpReceive = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.Sum(p => p.Amount);
                    if (amount > currentOrderManager.getOrderEditViewModel().FinalAmount
                        + currentOrderManager.getOrderEditViewModel().VATAmount
                        - tmpReceive)
                    {
                        amount = currentOrderManager.getOrderEditViewModel().FinalAmount
                                 + currentOrderManager.getOrderEditViewModel().VATAmount
                                 - tmpReceive;
                    }
                    if (amount > 0)
                    {
                        //thêm lần thanh toán
                        currentOrderManager.UpdatePayment(_currentPaymentType, amount, code);
                    }
                }
                else if (_currentPaymentType == PaymentTypeEnum.Voucher
                         || _currentPaymentType == PaymentTypeEnum.Other)
                {
                    //TODO:
                }
                else if (_currentPaymentType == PaymentTypeEnum.AccountReceivable)
                {
                    //TODO:
                }
                else if (_currentPaymentType == PaymentTypeEnum.Cash)
                {
                    currentOrderManager.UpdatePayment(_currentPaymentType, amount, code);

                    var tmpReceive =
                        currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.Sum(p => p.Amount);
                    var returnMoney = currentOrderManager.getOrderEditViewModel().FinalAmount
                                      + currentOrderManager.getOrderEditViewModel().VATAmount
                                      - tmpReceive;
                    if (returnMoney < 0)
                    {
                        //thêm lần trả tiền dư
                        currentOrderManager.UpdatePayment(PaymentTypeEnum.ExchangeCash, returnMoney, code);
                    }
                }

                LoadPayment();
                if (ReloadMemberPoint != null)
                {
                    ReloadMemberPoint();
                }
                if (UpdateMoneyInfo != null)
                {
                    UpdateMoneyInfo();
                }
            }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var color = label.BackColor;
            for (int row = 0; row < tlpPayment.RowCount; row++)
            {
                for (int column = 0; column < tlpPayment.ColumnCount; column++)
                {
                    var control = tlpPayment.GetControlFromPosition(column, row);
                    if (control != null)
                    {
                        try
                        {
                            control.BackColor = Color.Transparent;
                        }
                        catch (Exception ex)
                        {
                            log.Error("Lbl_Click - " + ex);
                        }
                    }
                }
            }

            if (color != Color.Black)
            {
                label.BackColor = Color.Black;
                rowPosition = tlpPayment.GetRow(label);
                for (int i = 0; i <= tlpPayment.ColumnCount; i++)
                {
                    var control = tlpPayment.GetControlFromPosition(i, rowPosition);
                    if (control != null)
                    {
                        try
                        {
                            control.BackColor = Color.Black;
                        }
                        catch (Exception ex)
                        {
                            log.Error("Lbl_Click - " + ex);
                        }
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (rowPosition >= 0)
            {
                int paymentId = -1;
                var control = tlpPayment.GetControlFromPosition(4, rowPosition);
                if (control != null)
                {
                    try
                    {
                        paymentId = (int)int.Parse(control.Text);
                        var payment = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.FirstOrDefault(q => q.PaymentID == paymentId);
                        if (payment != null && payment.Type == (int)PaymentTypeEnum.MemberPayment)
                        {
                            var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                            accountCredit.Balance += payment.Amount;
                            if (ReloadMemberPoint != null)
                            {
                                ReloadMemberPoint();
                            }
                        }
                        currentOrderManager.RemovePayment(payment);
                    }
                    catch (Exception ex)
                    {
                        log.Error("btnRemove_Click - " + ex);
                    }
                }

                RemoveRow(rowPosition);
                LoadPayment();

                rowPosition = -1;

                if (UpdateMoneyInfo != null)
                {
                    UpdateMoneyInfo();
                }
            }
        }

        public void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (var payment in currentOrderManager.getOrderEditViewModel().PaymentEditViewModels)
            {
                if (payment != null
                    && payment.Type == (int)PaymentTypeEnum.MemberPayment
                    && ! currentOrderManager.isCurrentCustomerModelEmpty())
                {
                    var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    accountCredit.Balance += payment.Amount;
                }
            }

            currentOrderManager.RemovePayment();
            if (ReloadMemberPoint != null)
            {
                ReloadMemberPoint();
            }

            RemoveAllRow();
            LoadPayment();

            if (UpdateMoneyInfo != null)
            {
                UpdateMoneyInfo();
            }
            SetDefaultCashValue();
        }

        public void LoadPayment()
        {
            try
            {
                var payments = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.ToList();
                for (int i = 0; i < payments.ToList().Count(); i++)
                {
                    PaymentViewModel p = payments[i];
                    var checkType = true;
                    var type = GetPaymentTypeString(p);
                    for (int row = 0; row < tlpPayment.RowCount; row++)
                    {
                        var lblPayId = tlpPayment.GetControlFromPosition(4, row);
                        if (lblPayId != null && checkType)
                        {
                            try
                            {
                                if (int.Parse(lblPayId.Text) == p.PaymentID)
                                {
                                    checkType = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("LoadPayment(Parse) - " + ex);
                            }
                        }
                    }

                    if (p.Amount != 0 && checkType)
                    {
                        for (int row = 0; row < tlpPayment.RowCount; row++)
                        {
                            if (tlpPayment.GetControlFromPosition(1, row) == null)
                            {
                                RowStyle style = new RowStyle(SizeType.AutoSize);
                                tlpPayment.RowStyles.Add(style);

                                int index = row; //i + 1;
                                Font f = new Font("Segoe UI", 11F, FontStyle.Bold);

                                //Add No.
                                Label lblNumber = new Label()
                                {
                                    ForeColor = Color.White,
                                    Font = f,
                                };
                                lblNumber.AutoSize = true;
                                lblNumber.Text = (i + 1).ToString();
                                lblNumber.Click += Lbl_Click;
                                tlpPayment.Controls.Add(lblNumber, 0, index);

                                //Add Type
                                Label lblType = new Label()
                                {
                                    ForeColor = Color.White,
                                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                                    TextAlign = ContentAlignment.MiddleRight,
                                };
                                lblType.AutoSize = true;
                                lblType.Text = type;
                                lblType.Click += Lbl_Click;
                                tlpPayment.Controls.Add(lblType, 1, index);

                                //Add Amount
                                Label lblAmount = new Label()
                                {
                                    ForeColor = Color.White,
                                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                                    TextAlign = ContentAlignment.MiddleRight,
                                };
                                lblAmount.AutoSize = true;
                                lblAmount.Text = p.Amount.ToString("N0");
                                lblAmount.Click += Lbl_Click;
                                tlpPayment.Controls.Add(lblAmount, 2, index);

                                //Add Time
                                Label lblTime = new Label()
                                {
                                    ForeColor = Color.White,
                                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                                    TextAlign = ContentAlignment.MiddleRight,
                                };
                                lblTime.AutoSize = true;
                                lblTime.Text = p.PayTime.ToString("dd/MM H:mm");
                                lblTime.Click += Lbl_Click;
                                tlpPayment.Controls.Add(lblTime, 3, index);

                                //Add paymentId Flag
                                Label lblPaymentId = new Label()
                                {
                                    ForeColor = Color.Transparent,
                                };
                                lblPaymentId.Text = p.PaymentID.ToString();
                                tlpPayment.Controls.Add(lblPaymentId, 4, index);
                            }
                        }
                        tlpPayment.RowCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("LoadPayment - " + ex);
            }

            SetDefaultCashValue();
        }

        private string GetPaymentTypeString(PaymentViewModel p)
        {
            var type = "";
            switch (p.Type)
            {
                case (int)PaymentTypeEnum.Card:
                    type = "Thẻ";
                    break;
                case (int)PaymentTypeEnum.MasterCard:
                    type = "MasterCard";
                    break;
                case (int)PaymentTypeEnum.VisaCard:
                    type = "VisaCard";
                    break;
                case (int)PaymentTypeEnum.MemberPayment:
                    type = "Thẻ thành viên";
                    break;
                case (int)PaymentTypeEnum.Voucher:
                    type = "Voucher";
                    break;
                case (int)PaymentTypeEnum.Other:
                    type = "Khác";
                    break;
                case (int)PaymentTypeEnum.AccountReceivable:
                    type = "Nợ";
                    break;
                case (int)PaymentTypeEnum.MoMo:
                    type = "Momo";
                    break;
                case (int)PaymentTypeEnum.GiftTalk:
                    type = "GiftTalk";
                    break;
                case (int)PaymentTypeEnum.ZaloPay:
                    type = "Zalo";
                    break;
                case (int)PaymentTypeEnum.GrabPay:
                    type = "Grab Pay";
                    break;
                case (int)PaymentTypeEnum.GrabFood:
                    type = "Grab Food";
                    break;
                default:
                    type = "Tiền mặt";
                    break;
            }
            return type;
        }

        public void RemoveRow(int row_index_to_remove)
        {
            if (row_index_to_remove >= tlpPayment.RowCount)
            {
                return;
            }
            //panel.RowStyles.RemoveAt(row_index_to_remove);
            // delete all controls of row that we want to delete
            for (int i = 0; i < tlpPayment.ColumnCount; i++)
            {
                var control = tlpPayment.GetControlFromPosition(i, row_index_to_remove);
                tlpPayment.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = row_index_to_remove + 1; i < tlpPayment.RowCount; i++)
            {
                for (int j = 0; j < tlpPayment.ColumnCount; j++)
                //for (int j = 0; j < 4; j++)
                {
                    var control = tlpPayment.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        tlpPayment.SetRow(control, i - 1);
                    }
                }
            }

            // remove last row
            tlpPayment.RowStyles.RemoveAt(tlpPayment.RowCount - 1);
            tlpPayment.RowCount--;
        }

        public void RefreshPanel()
        {
            RemoveAllRow();
            LoadPayment();
            txtValue.Value = "";
            txtValue.TextValue = "";
            txtCode.Text = null;
            LoadTabs();

            CardAccountModel accountCredit = null;
            if (!currentOrderManager.isCurrentCustomerModelEmpty())
            {
                if (currentOrderManager.getCardType() != null)
                {
                    if ((currentOrderManager.getCardType() ?? -1) == (int)PaymentTypeEnum.GiftTalk
                        && MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true")
                    {
                        accountCredit =
                            currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a =>
                                a.Type == (int)CardAccountTypeEnum.GiftAccount);
                    }
                    else
                    {
                        accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    }
                }
            }

            if (!currentOrderManager.isCurrentCustomerModelEmpty()
                && (currentOrderManager.getCurrentCustomerModel().Status == CustomerTypeEnum.Active.ToString()
                || (currentOrderManager.getCurrentCustomerModel().Status == CustomerTypeEnum.GiftTalk.ToString() && MainForm.StoreInfo.GiftTalkCardEnable.Trim().ToLower() == "true"))
                && accountCredit != null
                && accountCredit.Balance > 0)
            {
                var buttons = pnlTabs.Controls.Cast<BootstrapButton>();
                foreach (var button in buttons)
                {
                    if (button.Tag != null)
                    {
                        if (currentOrderManager.getCardType() != null && (PaymentTypeEnum)button.Tag == (PaymentTypeEnum)(currentOrderManager.getCardType()))
                        {
                            ChangePaymentType(button);
                            break;
                        }
                    }
                }
            }
            else
            {
                ChangePaymentType(btnTab1);
            }

            SetDefaultCashValue();
        }

        public void RemoveAllRow()
        {
            tlpPayment.Controls.Clear();

            for (int row = tlpPayment.RowCount - 1; row > 0; row--)
            {
                for (int column = 0; column < tlpPayment.ColumnCount; column++)
                {
                    var control = tlpPayment.GetControlFromPosition(column, row);
                    if (control == null)
                    {
                        try
                        {

                            column = tlpPayment.ColumnCount;
                            RemoveRow(row);
                        }
                        catch (Exception ex)
                        {
                            log.Error("RemoveAllRow - " + ex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tính receive money cần nhận
        /// </summary>
        public void SetDefaultCashValue()
        {
            var finalAmount = currentOrderManager.getOrderEditViewModel().FinalAmount
                                + currentOrderManager.getOrderEditViewModel().VATAmount;
            var receivedAmount = currentOrderManager.getOrderEditViewModel().TotalPayment;
            if (currentOrderManager.getOrderEditViewModel().PaymentEditViewModels != null &&
                currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.ToList().Count > 0)
            {
                if (currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.Sum(p => p.Amount) > receivedAmount)
                {
                    receivedAmount = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels.Sum(p => p.Amount);
                }
            }
            var exchange = receivedAmount - finalAmount;
            if (exchange >= 0)
            {
                txtValue.ResetText();
                txtValue.Value = "";
                txtValue.TextValue = "";
            }
            else if (exchange < 0)
            {
                txtValue.ResetText();
                txtValue.Value = string.Format("{0:####}", -exchange);
                txtValue.TextValue = string.Format("{0:n0}", -exchange);
            }
        }

        private void btnQuickMoney_Click(object sender, EventArgs e)
        {
            try
            {
                var button = (BootstrapButton)sender;
                var value = Int32.Parse(button.Tag.ToString());

                txtValue.ResetText();
                txtValue.Value = string.Format("{0:####}", value);
                txtValue.TextValue = string.Format("{0:n0}", value);
            }
            catch (Exception ex)
            {
                log.Error("btnQuickMoney_Click - " + ex);
            }
        }
    }
}
