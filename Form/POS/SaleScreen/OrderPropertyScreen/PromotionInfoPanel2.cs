using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using log4net;
using POS.Common;
using POS.CustomControl;
using POS.SaleScreen.CustomControl;
using POS.ExchangeData;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.ExchangeDataModel;
using POS.Utils;
using POS.SaleScreen;
using static POS.SaleScreen.OrderPropertyForm2;

namespace POS.SaleScreen
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PromotionInfoPanel2 : UserControl
    {
        /// <summary>
        /// List Promotions form DB
        /// </summary>
        private static List<PromotionEditViewModel> _promotionEditViewModels;
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        public static AvailablePromotion availablePromotionForm;
        public event Action UpdateMoneyInfo;

        public List<OrderPromotionMappingEditViewModel> _appliedMappings;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PromotionInfoPanel2()
        {
            InitializeComponent();

            this.btnPromotionRefresh.Text = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
            this.lblActivedPromotion.Text = MainForm.ResManager.GetString("PromotionInfoPanel2_Promotion_Is_Used", MainForm.CultureInfo);

            //message:* Khuyến mãi dành cho thẻ thành viên
            this.lblNoti.Text = MainForm.ResManager.GetString("PromotionInfoPanel2_Promotion_Noti", MainForm.CultureInfo);
            //message:(1) Giảm giá trực tiếp (áp dụng được với 2 && 3)
            this.lblInternalPromotion.Text = MainForm.ResManager.GetString("PromotionInfoPanel2_Internal_Promotion", MainForm.CultureInfo);
            //message:(2) Khuyến mãi chung (có thể áp dụng nhiều)
            this.lblCommonPromotion.Text = MainForm.ResManager.GetString("PromotionInfoPanel2_Common_Promotion", MainForm.CultureInfo);
            //message:(3) Khuyến mãi độc lập (chỉ được áp dụng duy nhất)
            this.lblSeparatePromotion.Text = MainForm.ResManager.GetString("PromotionInfoPanel2_Separate_Promotion", MainForm.CultureInfo);


        }

        #region Load Promotion To From

        public void LoadPromotion()
        {
            _promotionEditViewModels = null;
            _promotionEditViewModels = Program.context.getPromotions();
            _appliedMappings = new List<OrderPromotionMappingEditViewModel>();

            if (_promotionEditViewModels != null)
            {
                HideAllControl();
                foreach (var promotion in _promotionEditViewModels)
                {

                    if ((promotion.PromotionType == (int)PromotionTypeEnum.Internal)
                        && (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail))
                    {
                        //Không load direct orderDetail
                    }
                    else
                    {
                        if (promotion.PromotionType == (int)PromotionTypeEnum.Internal)
                        {
                            LoadPromotionToPanelButtons(pnlStorePromotion, promotion);
                        }
                        else if (promotion.PromotionType == (int)PromotionTypeEnum.Common)
                        {
                            LoadPromotionToPanelButtons(pnlCommonPromotion, promotion);
                        }
                        else if (promotion.PromotionType == (int)PromotionTypeEnum.Separate)
                        {
                            LoadPromotionToPanelButtons(pnlSpecialPromotion, promotion);
                        }
                    }
                }
            }

            ReloadAllActivedPanel();
            RecheckAllActivedButton();
        }

        private void RecheckAllActivedButton()
        {
            RecheckActivedButton(pnlSpecialPromotion);
            RecheckActivedButton(pnlCommonPromotion);
            RecheckActivedButton(pnlStorePromotion);
        }

        private void ReloadAllActivedPanel()
        {
            RemoveAllPromotionPanel();

            _appliedMappings = currentOrderManager.GetAppliedMappings();

            foreach (var mapping in _appliedMappings)
            {
                var panel = pnlActivedPromotion.Controls
                    .Cast<ActivedPromotionPanel>()
                    .FirstOrDefault(p => p.PromotionMapping.PromotionCode == mapping.PromotionCode);
                if (panel == null)
                {
                    var promotion =
                        _promotionEditViewModels.FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);

                    if (promotion != null)
                    {
                        var promotionResult = new ActivedPromotionPanel
                            (promotion.PromotionName, promotion.Description, mapping);
                        promotionResult.RemovePromotionEvent += RemovePromotion;
                        pnlActivedPromotion.Controls.Add(promotionResult);
                    }
                }
            }
        }

        private void RecheckActivedButton(Panel panel)
        {
            foreach (var button in panel.Controls.Cast<BootstrapButton>())
            {
                LoadColorToButton(button, null);
            }
        }

        private void LoadPromotionToPanelButtons(Panel panel, PromotionEditViewModel promotion)
        {
            foreach (var button in panel.Controls.Cast<BootstrapButton>())
            {
                if (button.Tag == null)
                {
                    LoadPromotionToButton(button, promotion);
                    break;
                }
            }
        }

        private void LoadPromotionToButton(BootstrapButton button, PromotionEditViewModel promotion)
        {
            if (promotion != null)
            {
                button.Tag = promotion;
                button.ImageCss = promotion.ImageCss;
                button.TextValue = promotion.PromotionName;
                button.ButtonValue = promotion.PromotionCode;

                button.Visible = true;
                button.ActiveBackgroudColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

                LoadColorToButton(button, promotion);
            }
        }

        private void LoadColorToButton(BootstrapButton button, PromotionEditViewModel promotion)
        {
            button.IsActive = false;
            if (button.Tag != null)
            {
                if (promotion == null)
                {
                    promotion = (PromotionEditViewModel)button.Tag;
                }

                if (currentOrderManager.IsAppliedPromotion(promotion.PromotionCode))
                {
                    button.IsActive = true;
                }

                button.Enabled = true;
                button.BackgroudBootstrapColor = BootstrapColorEnum.Default;

                var availablePromotionDetails = currentOrderManager
                        .GetAvailablePromotionDetails(promotion);
                if (!promotion.IsAvailableDate(currentOrderManager.getOrderEditViewModel().CheckInDate)
                        || availablePromotionDetails == null
                        || !availablePromotionDetails.Any())
                {
                    button.Enabled = false;
                    button.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                }
            }
        }

        private void HideAllControl()
        {
            HideControl(pnlStorePromotion);
            HideControl(pnlSpecialPromotion);
            HideControl(pnlCommonPromotion);
        }

        private void HideControl(Panel panel)
        {
            foreach (var button in panel.Controls.Cast<BootstrapButton>())
            {
                button.Tag = null;
                button.Visible = false;
            }
        }


        public void ShowAvailablePromotionForm(PromotionEditViewModel promotion)
        {
            if (availablePromotionForm == null || availablePromotionForm.IsDisposed)
            {
                availablePromotionForm = new AvailablePromotion(promotion);
                availablePromotionForm.TryApplyPromotionDetail += ApplyPromotionDetail;
            }
            availablePromotionForm.GenerateLayout();

            availablePromotionForm.Show();
            availablePromotionForm.BringToFront();
        }
        #endregion

        #region Event for button
        private async void PromotionButton_Click(object sender, EventArgs e)
        {
            var notSwitch = false;
            try
            {
                var button = (BootstrapButton)sender;
                var promotion = (PromotionEditViewModel)button.Tag;
                currentOrderManager.setCurrentVoucherModel(null);

                //Check voucher code
                if (promotion.IsVoucher == true)
                {
                    var isEnableOnscreenKeyboard = MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true";
                    var inputVoucherCode = PosMessageDialog.YesNoDialogWithInput(
                                //message:Xin điền mã voucher
                                MainForm.ResManager.GetString("PromotionInfoPanel2_Voucher_Please_Enter_Code", MainForm.CultureInfo) + ":", MainForm.ResManager.GetString("Sys_Yes", MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_No", MainForm.CultureInfo),
                                isEnableOnscreenKeyboard, "");

                    var voucher = new VoucherResultModel()
                    {
                        PromotionCode = null,
                        VoucherCode = null,
                        Status = false,
                        //message:Xin vui lòng thử lại sau
                        Message = MainForm.ResManager.GetString("PromotionInfoPanel2_Please_Try_Later", MainForm.CultureInfo)
                    };

                    //yes => chuoi nhap vao; 
                    //no => null
                    if (inputVoucherCode != null)
                    {
                        string membershipCardCode = currentOrderManager.getOrderEditViewModel().BarCode ?? "";
                        string code = inputVoucherCode[0];

                        var voucherModel = DataExchanger.CheckVoucher(code,membershipCardCode);
                        if (await Task.WhenAny(voucherModel) == voucherModel)
                        {
                            voucher.PromotionVM = voucherModel.Result.PromotionVM;
                            voucher.PromotionCode = voucher.PromotionVM.PromotionCode;
                            voucher.VoucherCode = voucherModel.Result.VoucherCode;
                            voucher.Status = voucherModel.Result.Status;
                            voucher.Message = voucherModel.Result.Message;
                            voucher.Customer = voucherModel.Result.Customer;
                            
                        }
                        else
                        {
                            //TimeOut 5s
                        }
                    } else
                    {
                        notSwitch = true;
                    }

                    currentOrderManager.setCurrentVoucherModel(voucher);

                    //
                    if (inputVoucherCode != null
                        && !currentOrderManager.getCurrentVoucherModel().Status)
                    {
                        notSwitch = true;
                        PosMessageDialog.ShowMessage(currentOrderManager.getCurrentVoucherModel().Message);
                    }
                }

                //Không phải voucher
                //hoặc voucher thì promotion code = current promotion
                if (currentOrderManager.getCurrentVoucherModel() == null
                    || (currentOrderManager.getCurrentVoucherModel() != null
                        && currentOrderManager.getCurrentVoucherModel().PromotionCode != null
                        && currentOrderManager.getCurrentVoucherModel().PromotionCode == promotion.PromotionCode))
                {
                    var availablePromotionDetails = currentOrderManager.GetAvailablePromotionDetails(promotion);
                    var count = availablePromotionDetails.Count();

                    if (count > 0)
                    {
                        if (count == 1 || promotion.IsApplyOnce == false)
                        {
                            foreach (var promoDetail in availablePromotionDetails)
                            {
                                TryApplyPromotion(promoDetail);
                            }
                        }
                        else if (count > 1)
                        {
                            var showPromotion = (PromotionEditViewModel)promotion.Clone();
                            showPromotion.PromotionDetailViewModels = availablePromotionDetails;
                            ShowAvailablePromotionForm(showPromotion);
                        }
                    }
                }
                else if (currentOrderManager.getCurrentVoucherModel() != null
                            && currentOrderManager.getCurrentVoucherModel().Status
                            && currentOrderManager.getCurrentVoucherModel().PromotionCode != promotion.PromotionCode)
                {
                    //message:Voucher không dành cho khuyến mãi này
                    PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("PromotionInfoPanel2_Voucher_Not_Suitable", MainForm.CultureInfo));
                }
            }
            catch (Exception ex)
            {
                //message:Xin vui lòng thử lại sau
                PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("PromotionInfoPanel2_Please_Try_Later", MainForm.CultureInfo));
                log.Error("PromotionButton_Click - " + ex);
            }
            //quay lai payment
            if (!notSwitch)
            {
                var orderPropertyForm2 = (OrderPropertyForm2)this.ParentForm;

                orderPropertyForm2.LoadTab(OrderPropertyForm2.OrderPropertyTabEnum.Payment);
            }
        }

        public void btnPromotionRefresh_Click(object sender, EventArgs e)
        {
            RemoveAllPromotionPanel(false);

        }
        #endregion

        #region Apply Promotion

        //Review
        public void ApplyPromotionDetail(PromotionEditViewModel promotion)
        {
            var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault();
            if (promotionDetail != null)
            {
                if (TryApplyPromotion(promotionDetail))
                {
                    ReloadAllActivedPanel();
                    RecheckAllActivedButton();
                }
            }
        }

        private bool TryApplyPromotion(PromotionDetailViewModel promotionDetail)
        {
           
            if (promotionDetail.MinOrderAmount > Program.context.getCurrentOrderManager().getOrderEditViewModel().TotalAmount)
            {
                var text = MainForm.ResManager.GetString(
                        "PromotionInfoPanel2_Promotion_TotalAmout_Small",
                        MainForm.CultureInfo);
                PosMessageDialog.ShowMessage(text + promotionDetail.MinOrderAmount);
                return false;
            }
            var rs = currentOrderManager.ApplyPromotion(promotionDetail);

            if (!rs)
            {
                rs = currentOrderManager.IsAppliedPromotion(promotionDetail.PromotionCode);
            }

            if (rs)
            {
                PaymentEditViewModel specialPayment = null;

                do
                {
                    specialPayment = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels
                                        .FirstOrDefault(p => p.Type == (int)PaymentTypeEnum.MemberPayment
                                                    || p.Type == (int)PaymentTypeEnum.MasterCard
                                                    || p.Type == (int)PaymentTypeEnum.VisaCard
                                                    || p.Type == (int)PaymentTypeEnum.Card
                                                    || p.Type == (int)PaymentTypeEnum.Cash
                                                    || p.Type == (int)PaymentTypeEnum.ExchangeCash);
                    if (specialPayment != null)
                    {
                        if (specialPayment.Type == (int)PaymentTypeEnum.MemberPayment)
                        {
                            if (!currentOrderManager.isCurrentCustomerModelEmpty())
                            {
                                var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                                if (accountCredit != null)
                                {
                                    accountCredit.Balance = accountCredit.Balance + specialPayment.Amount;
                                }
                            }
                        }
                        currentOrderManager.getOrderEditViewModel().PaymentEditViewModels
                            .Remove(specialPayment);
                    }
                }
                while (specialPayment != null);
            }

            currentOrderManager.AfterAppliedPromotion();

            if (UpdateMoneyInfo != null)
            {
                UpdateMoneyInfo();
            }

            ReloadAllActivedPanel();
            RecheckAllActivedButton();

            if (rs)
            {
                var promotion =
                    _promotionEditViewModels.FirstOrDefault(p => p.PromotionCode == promotionDetail.PromotionCode);
                if (promotion.IsVoucher == true)
                {
                    currentOrderManager.getOrderEditViewModel().Att3 =
                        promotion.PromotionCode + ":" +
                        currentOrderManager.getCurrentVoucherModel().VoucherCode;
                }
            }

            return rs;
        }

        private void RemovePromotion(OrderPromotionMappingEditViewModel mapping)
        {
            var promotion = _promotionEditViewModels.FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
            if (promotion != null)
            {
                var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault(pd => pd.PromotionDetailCode == mapping.PromotionDetailCode);
                if (promotionDetail == null)
                {
                    currentOrderManager.RemoveAppliedPromotion(promotion);
                }
                else
                {
                    currentOrderManager.RemoveAppliedPromotion(promotionDetail);
                }

                currentOrderManager.AfterAppliedPromotion();

                if (UpdateMoneyInfo != null)
                {
                    UpdateMoneyInfo();
                }

                ReloadAllActivedPanel();
                RecheckAllActivedButton();

                if (promotion.IsVoucher == true)
                {
                    var rs = currentOrderManager.IsAppliedPromotion(promotion.PromotionCode);
                    var voucherApplied = currentOrderManager.getOrderEditViewModel().Att3.Split(':');
                    if (!rs && voucherApplied[0] == promotion.PromotionCode)
                    {
                        currentOrderManager.getOrderEditViewModel().Att3 = null;
                    }
                }
                PaymentEditViewModel specialPayment = null;

                do
                {
                    specialPayment = currentOrderManager.getOrderEditViewModel().PaymentEditViewModels
                                        .FirstOrDefault(p => p.Type == (int)PaymentTypeEnum.MemberPayment
                                                    || p.Type == (int)PaymentTypeEnum.MasterCard
                                                    || p.Type == (int)PaymentTypeEnum.VisaCard
                                                    || p.Type == (int)PaymentTypeEnum.Card
                                                    || p.Type == (int)PaymentTypeEnum.Cash
                                                    || p.Type == (int)PaymentTypeEnum.ExchangeCash);
                    if (specialPayment != null)
                    {
                        if (specialPayment.Type == (int)PaymentTypeEnum.MemberPayment)
                        {
                            if (!currentOrderManager.isCurrentCustomerModelEmpty())
                            {
                                var accountCredit = currentOrderManager.getCurrentCustomerModel().Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                                if (accountCredit != null)
                                {
                                    accountCredit.Balance = accountCredit.Balance + specialPayment.Amount;
                                }
                            }
                        }
                        currentOrderManager.getOrderEditViewModel().PaymentEditViewModels
                            .Remove(specialPayment);
                    }
                }
                while (specialPayment != null);
            }
        }

        private void RemoveAllPromotionPanel(bool isRefreshOnly = true)
        {
            var removeList = new List<ActivedPromotionPanel>();
            foreach (var panel in pnlActivedPromotion.Controls.Cast<ActivedPromotionPanel>())
            {
                removeList.Add(panel);
            }
            foreach (var panel in removeList)
            {
                if (isRefreshOnly)
                {
                    pnlActivedPromotion.Controls.Remove(panel);
                }
                else
                {
                    var mapping = panel.PromotionMapping;
                    RemovePromotion(mapping);
                }
            }
        }

        public void RefreshPanel()
        {
            RemoveAllPromotionPanel(false);
            HideAllControl();
        }

        #endregion

        private async void btnScanBarcode_Click(object sender, EventArgs e)
        {
            try{
                var isEnableOnscreenKeyboard = MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true";
                var inputVoucherCode = PosMessageDialog.YesNoDialogWithInput(
                            //message:Xin điền mã voucher
                            MainForm.ResManager.GetString("PromotionInfoPanel2_Voucher_Please_Enter_Code", MainForm.CultureInfo) + ":", MainForm.ResManager.GetString("Sys_Yes", MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_No", MainForm.CultureInfo),
                            isEnableOnscreenKeyboard, "");

                var voucher = new VoucherResultModel()
                {
                    PromotionCode = null,
                    VoucherCode = null,
                    Status = false,
                    //message:Xin vui lòng thử lại sau
                    Message = MainForm.ResManager.GetString("PromotionInfoPanel2_Please_Try_Later", MainForm.CultureInfo)
                };

                //yes => chuoi nhap vao; 
                //no => null
                if (inputVoucherCode != null)
                {
                    string code = inputVoucherCode[0];
                    string membershipCardCode = currentOrderManager.getOrderEditViewModel().BarCode ?? "";
                    var voucherModel = DataExchanger.CheckVoucher(code,membershipCardCode);
                    if (await Task.WhenAny(voucherModel) == voucherModel)
                    {
                        voucher.VoucherCode = voucherModel.Result.VoucherCode;
                        voucher.Status = voucherModel.Result.Status;
                        voucher.Message = voucherModel.Result.Message;
                        voucher.Customer = voucherModel.Result.Customer;
                        if (voucherModel.Result.PromotionVM != null)
                        {
                            voucher.PromotionVM = voucherModel.Result.PromotionVM;
                            voucher.PromotionCode = voucherModel.Result.PromotionVM.PromotionCode;
                        }
                        else
                        {
                            voucher.PromotionCode = voucherModel.Result.PromotionCode;
                        }
                        
                    }
                    else
                    {
                        //TimeOut 5s
                    }
                }

                currentOrderManager.setCurrentVoucherModel(voucher);
                if (inputVoucherCode != null
                            && !currentOrderManager.getCurrentVoucherModel().Status)
                {
                    PosMessageDialog.ShowMessage(currentOrderManager.getCurrentVoucherModel().Message);
                }

                CardCustomerModel customerModel = voucher.Customer;
                OrderPropertyForm2 orderPropertyForm2 = new OrderPropertyForm2();
                if (voucher.Customer != null)
                {
                    currentOrderManager.setCurrentCustomerModel(customerModel);
                    string[] tokens = customerModel.Code.Split('_');
                    currentOrderManager.getOrderEditViewModel().BarCode = tokens[1];
                    orderPropertyForm2.updateCustomerInfo();
                    UpdateMoneyInfo();
                    orderPropertyForm2.LoadTab(OrderPropertyTabEnum.Customer, true);
                }
                
                //if (voucher.Customer != null)
                //{
                //    //TEST
                //    customerModel = orderPropertyForm2.loadCustomer(voucher.Customer);
                //}
                //else
                //{
                //    //TimeOut 5s
                ////}
                //currentOrderManager.setCurrentCustomerModel(customerModel);
                //string[] tokens = customerModel.Code.Split('_');
                //currentOrderManager.getOrderEditViewModel().BarCode = tokens[1];
                //orderPropertyForm2.updateCustomerInfo();
                //UpdateMoneyInfo();
                //orderPropertyForm2.LoadTab(OrderPropertyTabEnum.Customer, true);
                var promotion = getPromotionEditViewModel(voucher.PromotionVM);
                if (promotion != null)
                {
                    ApplyPromotionDetail(promotion);
                } else
                {
                    PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("PromotionInfoPanel2_Not_Apply", MainForm.CultureInfo));
                }
                //orderPropertyForm2.LoadTab(OrderPropertyTabEnum.Customer, true);
                //OrderDetailPropetyPanel.ShowAvailablePromotionForm(voucher);

            }
            catch (Exception ex)
            {
                log.Debug(ex.StackTrace);
            }
            
        }

        private PromotionEditViewModel getPromotionEditViewModel(PromotionViewModel promo)
        {
            var promotions = Program.context.getPromotions();
            foreach(var promotion in promotions)
            {
                if(promotion.PromotionCode == promo.PromotionCode)
                {
                    return promotion;
                }
            }
            return null;
        }
    }
}
