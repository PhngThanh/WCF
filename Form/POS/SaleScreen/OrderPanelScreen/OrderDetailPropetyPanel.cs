using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS.SaleScreen.CustomControl;
using POS.Repository.ViewModels;
using log4net;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ExchangeDataModel;
using POS.Utils;
using System.Threading.Tasks;
using POS.ExchangeData;
using POS.Common;

namespace POS.SaleScreen
{
    public partial class OrderDetailPropetyPanel : UserControl
    {
        private List<OrderDetailEditViewModel> _orderDetails;
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        public event Action HideOrderDetail;
        private OrderDetailEditViewModel _mainOrderDetail;

        public static AvailableOrderDetailPromotion availableOrderDetailPromotionForm;

        // Note
        //private PropertyGroupControl _adjustmentNoteGroup;
        private string _adjustmentNote = "";

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public OrderDetailPropetyPanel()
        {
            InitializeComponent();
            GenerateLayout();
            GenerateOrderDetailPromotion();
            pnlNumPad.Textbox = txtQuantity;

            btnPromotionRefresh.Enabled = false;
            btnPromotionRefresh.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;

            if (currentOrderManager.getOrderEditViewModel().FinalAmount <= 0)
            {
                foreach (var button in pnlDiscountControls.Controls.Cast<BootstrapButton>())
                {
                    if (button.Tag != null)
                    {
                        button.Enabled = false;
                        button.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                    }
                }
            }
        }

        #region Generate Layout
        private void GenerateLayout()
        {
            try
            {
                GenerateExtraOrderItem();
                this.lblDiscountOnProduct.Text = MainForm.ResManager.GetString("OrderDetailPropetyPanel_Product_Discount", MainForm.CultureInfo);
                this.btnPromotionRefresh.TextValue = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
                this.lblQuantity.Text = MainForm.ResManager.GetString("Sys_Reset", MainForm.CultureInfo);
            }
            catch (Exception ex)
            {
                log.Error("GenerateLayout - " + ex);
            }

        }

        private void GenerateExtraOrderItem()
        {
            _extraPanel.ColumnCount = 3;
            _extraPanel.RowCount = 3;
            _extraPanel.ColumnStyles.Clear();
            _extraPanel.RowStyles.Clear();
            for (var i = 0; i < _extraPanel.ColumnCount; i++)
            {
                _extraPanel.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, (float)100.0 / _extraPanel.ColumnCount));
            }

            for (var i = 0; i < _extraPanel.RowCount; i++)
            {
                _extraPanel.RowStyles.Add(
                    new RowStyle(SizeType.Percent, (float)100.0 / _extraPanel.RowCount));
            }
        }

        #endregion

        #region  OrderDetail Promotion

        private void GenerateOrderDetailPromotion()
        {
            HideAllButton(pnlDiscountControls);
            foreach (var promotion in Program.context.getPromotions())
            {
                if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail
                    &&
                    promotion.PromotionType == (int)PromotionTypeEnum.Internal
                    )
                {
                    LoadOrderDetailPromotionToPanel(pnlDiscountControls, promotion);
                }
            }





        }
        public void RecheckActivedButton()
        {
            if (_mainOrderDetail != null)
            {
                foreach (var promotion in _mainOrderDetail.OrderDetailPromotionMappingEditViewModels)
                {
                    foreach (var button in pnlDiscountControls.Controls.Cast<BootstrapButton>())
                    {
                        if (button.Tag != null)
                        {
                            var currentPromotion = (PromotionEditViewModel)button.Tag;

                            if (currentPromotion != null)
                            {
                                if (promotion.PromotionCode == currentPromotion.PromotionCode)
                                {
                                    button.Enabled = false;
                                    button.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                                    break;
                                }
                            }
                        }
                    }

                    if (_mainOrderDetail.FinalAmount <= 0 || currentOrderManager.getOrderEditViewModel().FinalAmount <= 0)
                    {
                        foreach (var button in pnlDiscountControls.Controls.Cast<BootstrapButton>())
                        {
                            if (button.Tag != null)
                            {
                                button.Enabled = false;
                                button.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                            }

                        }
                    }

                    if (_mainOrderDetail.OrderDetailPromotionMappingEditViewModels.Count == 0)
                    {
                        btnPromotionRefresh.Enabled = false;
                        btnPromotionRefresh.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                    }
                    else
                    {
                        btnPromotionRefresh.Enabled = true;
                        btnPromotionRefresh.BackgroudBootstrapColor = BootstrapColorEnum.Default;
                    }

                }
            }
        }
        public void SetAvailableAllButton()
        {
            foreach (var button in pnlDiscountControls.Controls.Cast<BootstrapButton>())
            {
                if (button.Tag != null)
                {
                    button.Enabled = true;
                    button.BackgroudBootstrapColor = BootstrapColorEnum.Default;
                }

            }
        }
        private void LoadOrderDetailPromotionToPanel(Panel panel, PromotionEditViewModel promotion)
        {
            foreach (var button in panel.Controls.Cast<BootstrapButton>())
            {
                if (button.Tag == null)
                {
                    LoadOrderDetailPromotionToButton(button, promotion);
                    break;
                }
            }
        }

        private void LoadOrderDetailPromotionToButton(BootstrapButton button, PromotionEditViewModel promotion)
        {
            if (promotion != null)
            {
                button.Tag = promotion;
                button.ImageCss = promotion.ImageCss;
                button.TextValue = promotion.PromotionName;
                button.ButtonValue = promotion.PromotionCode;

                button.Visible = true;
                button.ActiveBackgroudColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

                button.Enabled = true;
                button.BackgroudBootstrapColor = BootstrapColorEnum.Default;

                if (!promotion.IsAvailableDate(currentOrderManager.getOrderEditViewModel().CheckInDate))
                {
                    button.Enabled = false;
                    button.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                }
            }
        }
        private void HideAllButton(Panel panel)
        {
            foreach (var button in panel.Controls.Cast<BootstrapButton>())
            {
                button.Tag = null;
                button.Visible = false;
            }
        }
        public void ShowAvailablePromotionForm(PromotionEditViewModel promotion)
        {
            if (availableOrderDetailPromotionForm == null || availableOrderDetailPromotionForm.IsDisposed)
            {
                availableOrderDetailPromotionForm = new AvailableOrderDetailPromotion(promotion);
                availableOrderDetailPromotionForm.TryApplyPromotionDetail += TryApplyPromotionDetail;
            }
            availableOrderDetailPromotionForm.Promotion = promotion;
            availableOrderDetailPromotionForm.GenerateLayout();
            availableOrderDetailPromotionForm.Show();
            availableOrderDetailPromotionForm.BringToFront();
        }

        public void TryApplyPromotionDetail(PromotionEditViewModel promotion)
        {
            var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault();
            if (promotion.IsVoucher == true)
            {
                currentOrderManager.getOrderEditViewModel().Att3 =
                    promotion.PromotionCode + ":" +
                    currentOrderManager.getCurrentVoucherModel().VoucherCode;
            }
            if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountRate)
            {
                foreach (var od in _orderDetails)
                {
                    currentOrderManager.ApplyPromotion(promotionDetail, od);
                }
            }
            else
            {
                currentOrderManager.ApplyPromotion(promotionDetail, _mainOrderDetail);
            }

            currentOrderManager.AfterAppliedPromotion();
            RecheckActivedButton();
        }

        #endregion
        /// <summary>
        /// Load OrderEditViewModel Information to panel
        /// </summary>
        public void LoadOrderDetail(List<OrderDetailEditViewModel> orderDetails)
        {
            try
            {
                _orderDetails = orderDetails;
                _mainOrderDetail = orderDetails.FirstOrDefault(od => od.ParentId == null);
                if (_mainOrderDetail != null)
                {
                    txtQuantity.ValueChange -= OnNumpad_Clicked;
                    lblQuantity.Text = _mainOrderDetail.Quantity.ToString();
                    txtQuantity.TextValue = _mainOrderDetail.Quantity.ToString();
                    txtQuantity.ValueChange += OnNumpad_Clicked;

                    // Cap nhat ti le giam gia tren giao dien
                    foreach (Control c in this.Controls)
                    {
                        if (c is BootstrapButton)
                        {
                            var button = c as BootstrapButton;
                            if (button.TextValue == _mainOrderDetail.DiscountRate.ToString())
                            {
                                button.IsActive = true;
                            }
                        }
                    }
                }

                //Cap nhat danh sach extra
                LoadExtraProduct();
            }
            catch (Exception ex)
            {
                log.Error("LoadOrderDetail - " + ex);
            }

        }

        private void LoadExtraProduct()
        {
            _extraPanel.Controls.Clear();

            foreach (Control c in this._extraPanel.Controls)
            {
                c.Dispose();
            }

            int row = 0;
            int column = 0;
            int havePosition = 0;

            for (int i = 1; i < _orderDetails.Count && havePosition < 9; i++)
            {
                var item = _orderDetails[i];
                if (item.Status != (int)OrderDetailStatusEnum.PosPreCancel)
                //item.Status != (int)OrderDetailStatusEnum.PosCancel 
                {
                    ProductItemControl pro = new ProductItemControl();
                    pro.ChangeQuantityEvent += HandleChangeProductQuantiy;
                    pro.UpdateProduct(item.ProductViewModel, item.ItemQuantity, item.Quantity);
                    _extraPanel.Controls.Add(pro, column++, row);

                    if (column == 4)
                    {
                        row++; // =1
                        column = 0;
                    }
                    havePosition++;
                }
            }
            //            this.Controls.Add(_extraPanel);

        }

        private void HandleChangeProductQuantiy(ProductViewModel product, int quantity)
        {
            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail,
                product, _mainOrderDetail, quantity);
        }


        //private void propertyGroup_PropertyClick(PropertyControl obj)
        //{
        //    OnClickOrderDetailControl(obj);
        //}


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="obj">Null for reset all</param>
        //private void OnClickOrderDetailControl(PropertyControl obj)
        //{
        //    try
        //    {
        //        // Reset all
        //        if (obj == null)
        //        {
        //            foreach (var od in _orderDetails)
        //            {
        //                //Reset discount
        //                od.DiscountRate = 0;
        //                od.Discount = 0;
        //                od.FinalAmount = od.TotalAmount;

        //                //Update Adjustment
        //                od.Notes = "";
        //            }


        //        }
        //        else
        //        {
        //            PropertyType type = (PropertyType)obj.Type;
        //            //Xử lý các trường hợp đang thao tác trên OrderDetailPropertyPanel
        //            if (type == PropertyType.Quantity)
        //            {

        //                if (obj.Value == (int)OrderDetailPropertyCommandCode.NewOrderDetail)
        //                {

        //                    //Nhấn nút New OrderEditViewModel từ OrderEditViewModel đã có
        //                    currentOrderManager().ChangeItemQuantityOfOrderDetail(OrderDetailChangeMode.AddOrderDetail, null, _mainOrderDetail, 0);
        //                    HideOrderDetail();

        //                }
        //                else if (obj.Value == (int)OrderDetailPropertyCommandCode.DeleteOrderDetail)
        //                {

        //                    //Delete product
        //                    currentOrderManager().ChangeItemQuantityOfOrderDetail(OrderDetailChangeMode.RemoveOrderDetail, null, _mainOrderDetail, 0);
        //                    HideOrderDetail();

        //                }
        //                else
        //                {
        //                    //Nhấn nút Increase or descrease

        //                    if (obj.Value == (int)OrderDetailPropertyCommandCode.IncreaseQuantity)
        //                    {
        //                        //+
        //                        currentOrderManager().ChangeItemQuantityOfOrderDetail(OrderDetailChangeMode.ModifiedOrderDetail, null, _mainOrderDetail, 1);
        //                    }
        //                    else if (obj.Value == (int)OrderDetailPropertyCommandCode.DecreaseQuantity)
        //                    {
        //                        //-
        //                        //Chỉ cho giảm xuống 1
        //                        if (_mainOrderDetail.ItemQuantity > 1)
        //                        {
        //                            currentOrderManager().ChangeItemQuantityOfOrderDetail(OrderDetailChangeMode.ModifiedOrderDetail, null, _mainOrderDetail, -1);
        //                        }
        //                    }

        //                }
        //            }
        //            else
        //            {
        //                if (type == PropertyType.Discount)
        //                {
        //                    //Reset discount
        //                    //_orderDetail.DiscountRate = 0;
        //                    //_orderDetail.Discount = 0;
        //                    //_orderDetail.FinalAmount = _orderDetail.TotalAmount;
        //                    //foreach (var property in discountGroup.Properties)
        //                    //{
        //                    //    if (property.IsActive)
        //                    //    {
        //                    //        _orderDetail.DiscountRate = property.Value;
        //                    //        _orderDetail.Discount = _orderDetail.TotalAmount * _orderDetail.DiscountRate / 100;
        //                    //        _orderDetail.FinalAmount = _orderDetail.TotalAmount - _orderDetail.Discount;
        //                    //    }
        //                    //}
        //                    if (obj.IsActive)
        //                    {
        //                        currentOrderManager().UpdateDiscountRateOfOrderDetail(_mainOrderDetail, obj.Value);
        //                    }
        //                    else
        //                    {
        //                        currentOrderManager().UpdateDiscountRateOfOrderDetail(_mainOrderDetail, 0);
        //                    }


        //                }
        //                else if (type == PropertyType.IngredientAdjustment)
        //                {
        //                    //string notes = "";

        //                    //foreach (var property in _ingredientAdjustGroup.Properties)
        //                    // {
        //                    //                                if (property.IsActive)
        //                    //                                {
        //                    //                                    nodes += property.Name + "|";
        //                    //                                    notes += property.DisplayText + "|";
        //                    //                                }
        //                    //                            }

        //                    //                            currentOrderManager().UpdateNoteOfOrderDetail(_mainOrderDetail, notes);
        //                }
        //            }
        //        }
        //        // Update and view new OrderEditViewModel detail
        //        // currentOrderManager().UpdateOrderDetail(_orderDetail, addValue);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void lblReset_Click(object sender, EventArgs e)
        //{
        //    ResetPanel();
        //}

        //private void lblFinish_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.Hide();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //protected override void OnDeactivate(EventArgs e)
        //{
        //    base.OnDeactivate(e);
        //    this.Hide();
        //}

        public void ResetPanel()
        {
            try
            {
                var controls =
                this.Controls.Cast<Control>()
                    .Where(a => a.GetType() == typeof(PropertyGroupControl))
                    .Cast<PropertyGroupControl>()
                    .SelectMany(control1 => control1.Controls.Cast<Control>()
                        .Where(a => a.GetType() == typeof(PropertyControl))
                        .Cast<PropertyControl>());
                foreach (var control2 in controls)
                {
                    control2.IsActive = false;
                }


                //Update data
                foreach (var od in _orderDetails)
                {
                    //Reset discount
                    od.DiscountRate = 0;
                    od.Discount = 0;
                    od.FinalAmount = od.TotalAmount;

                    //Update Adjustment
                    od.Notes = "";
                }
            }
            catch (Exception ex)
            {
                log.Error("ResetPanel - " + ex);
            }

        }

        private void btnIncreaseQuantity_Click(object sender, EventArgs e)
        {
            var quantity = 1;

            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail,
               null, _mainOrderDetail, quantity);

            OnQuantity_Changed();
        }

        private void btnDecreaseQuantity_Click(object sender, EventArgs e)
        {
            var quantity = -1;

            if (lblQuantity.Text == "1")
            {
                return;
            }

            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail,
                null, _mainOrderDetail, quantity);

            OnQuantity_Changed();
        }

        private void OnQuantity_Changed()
        {
            lblQuantity.Text = _mainOrderDetail.ItemQuantity.ToString();
            txtQuantity.ValueChange -= OnNumpad_Clicked;
            txtQuantity.TextValue = _mainOrderDetail.ItemQuantity.ToString();

            pnlNumPad.Textbox.Value = _mainOrderDetail.ItemQuantity.ToString();
            pnlNumPad.Textbox.TextValue = _mainOrderDetail.ItemQuantity.ToString();

            txtQuantity.ValueChange += OnNumpad_Clicked;
        }

        private void DeactiveAllDiscountControls()
        {
            foreach (BootstrapButton bootstrapButton in this.pnlDiscountControls.Controls)
            {
                bootstrapButton.IsActive = false;
            }
        }

        private async void OnDiscount_ClickedAsync(object sender, EventArgs e)
        {
            var button = (BootstrapButton)sender;
            var promotion = (PromotionEditViewModel)button.Tag;
            var availablePromotionDetails = currentOrderManager.GetAvailablePromotionDetails(promotion);
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
                if (inputVoucherCode != null)
                {
                    string code = inputVoucherCode[0];
                    string membershipCardCode = currentOrderManager.getOrderEditViewModel().BarCode ?? "";
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
                }

                currentOrderManager.setCurrentVoucherModel(voucher);

                //
                if (inputVoucherCode != null
                    && !currentOrderManager.getCurrentVoucherModel().Status)
                {
                    PosMessageDialog.ShowMessage(currentOrderManager.getCurrentVoucherModel().Message);
                } else
                if (inputVoucherCode != null
                    && currentOrderManager.getCurrentVoucherModel().Status)
                {
                    var showPromotion = (PromotionEditViewModel)promotion.Clone();
                    showPromotion.PromotionDetailViewModels = availablePromotionDetails;

                    if (_mainOrderDetail.FinalAmount > 0 && availablePromotionDetails.Count > 0)
                    {
                        ShowAvailablePromotionForm(showPromotion);
                    }
                }
            }
            else
            {
                var showPromotion = (PromotionEditViewModel)promotion.Clone();
                showPromotion.PromotionDetailViewModels = availablePromotionDetails;

                if (_mainOrderDetail.FinalAmount > 0 && availablePromotionDetails.Count > 0)
                {
                    ShowAvailablePromotionForm(showPromotion);
                }
            }
           

            //TODO: 
            //var button = sender as BootstrapButton;

            //if (button != null)
            //{
            //    if (button.IsActive)
            //    {
            //        //Đã discount > hủy
            //        DeactiveAllDiscountControls();
            //        currentOrderManager().UpdateDiscountRateOfOrderDetail(_mainOrderDetail, 0);
            //    }
            //    else
            //    {
            //        DeactiveAllDiscountControls();
            //        button.IsActive = true;
            //        var discountRate = int.Parse(button.ButtonValue);
            //        currentOrderManager().UpdateDiscountRateOfOrderDetail(_mainOrderDetail, discountRate);
            //    }
            //}
        }


        private void OnNumpad_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_mainOrderDetail != null)
                {
                    int adjustItemQuantity = 0;
                    var currentQuantity = _mainOrderDetail.Quantity;

                    var quantity = 0;

                    txtQuantity.ValueChange -= OnNumpad_Clicked;
                    if (!string.IsNullOrWhiteSpace(txtQuantity.Value))
                    {
                        quantity = int.Parse(txtQuantity.Value.Replace(",", ""));
                    }
                    else
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            UpdateQuantityOnView(1);
                        });
                        txtQuantity.Value = "1";
                        adjustItemQuantity = 1 - currentQuantity;

                        if (adjustItemQuantity == -1 && currentQuantity == 1 || adjustItemQuantity == 0)
                        {
                            return;
                        }

                        currentOrderManager.ChangeItemQuantityOfOrderDetail(
                        OrderDetailChangeModeEnum.ModifiedOrderDetail, null, _mainOrderDetail,
                        adjustItemQuantity);
                        return;
                    }

                    if (quantity == 0)
                    {
                        adjustItemQuantity = 1 - currentQuantity;
                    }
                    else if (quantity > 9999999)   //TODO: hardcode check quantity quá lớn
                    {
                        adjustItemQuantity = 9999999;
                    }
                    else
                    {
                        adjustItemQuantity = quantity;
                    }

                    UpdateQuantity(adjustItemQuantity);
                }
            }
            catch (Exception ex)
            {
                log.Error("OnNumpad_Clicked - " + ex);
            }
        }

        public void UpdateQuantity(int adjustItemQuantity)
        {
            if (_mainOrderDetail != null)
            {
                // using quantity received from serial port (override the current quantity)
                var quantity = adjustItemQuantity - _mainOrderDetail.Quantity;
                currentOrderManager.ChangeItemQuantityOfOrderDetail(
                        OrderDetailChangeModeEnum.ModifiedOrderDetail, null, _mainOrderDetail,
                        quantity);

                this.Invoke((MethodInvoker)delegate
                {
                    UpdateQuantityOnView(_mainOrderDetail.Quantity);
                });
            }
        }

        private void UpdateQuantityOnView(int quantity)
        {
            lblQuantity.Text = quantity.ToString();
            if (lblQuantity.Text.Length >= 3)
            {
                lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            txtQuantity.ValueChange -= OnNumpad_Clicked;
            txtQuantity.TextValue = quantity.ToString();
            txtQuantity.ValueChange += OnNumpad_Clicked;
        }

        private void btnPromotionRefresh_Click(object sender, EventArgs e)
        {
            //TODO

            var emptyODPromotionMappings = new List<OrderDetailPromotionMappingEditViewModel>();
            _mainOrderDetail.OrderDetailPromotionMappingEditViewModels = emptyODPromotionMappings;
            _mainOrderDetail.Discount = 0;
            _mainOrderDetail.DiscountRate = 0;
            _mainOrderDetail.FinalAmount = _mainOrderDetail.TotalAmount;
            //SaleScreen3.ShowOrderDetailForm(currentOrderManager().getOrderEditViewModel().OrderDetailEditViewModels);
            currentOrderManager.AfterAppliedPromotion();
            SetAvailableAllButton();

            btnPromotionRefresh.Enabled = false;
            btnPromotionRefresh.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
        }
    }
}
