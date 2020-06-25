using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using POS.Utils;
using POS.Repository;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ViewModels;
using POS.Repository.ExchangeDataModel;
using POS.SaleScreen;

namespace POS
{


    /// <summary>
    /// Quan ly OrderEditViewModel hien tai. Co cac Event dung de Notify khi co su thay doi thong tin cua OrderEditViewModel, OrderDetail, Payment
    /// </summary>
    public class CurrentOrderManager
    {
        public OrderEditViewModel OrderEditViewModel { get; set; }
        public OrderEditViewModel TmpOrderEditViewModel { get; set; }
        public int? CardType { get; set; }
        public PaymentTypeEnum paymentType { get; set; }

        public CardCustomerModel CurrentCustomerModel { get; set; }
        public VoucherResultModel CurrentVoucherModel { get; set; }

        public event Action<OrderDetailEditViewModel, OrderDetailChangeModeEnum> NotifyChangeOrderDetail;

        //public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int _currentOrderDetailId = 0;
        public int _currentMappingId = 0;
        public bool isChange = false;

        /// <summary>
        /// True: khi order được edit
        /// False: khi order được lưu vào database
        /// </summary>
        public bool isDirty = false;

        #region getter and setter
        //Contructor for orderEditViewModel
        public OrderEditViewModel getOrderEditViewModel()
        {
            return OrderEditViewModel;
        }

        public List<PaymentEditViewModel> getPaymentEditViewModels()
        {
            return OrderEditViewModel.getPaymentEditViewModels();
        }

        public void setOrderEditViewModel(OrderEditViewModel order)
        {
            OrderEditViewModel = order;
        }

        public bool hasOrder()
        {
            if (OrderEditViewModel == null)
            {
                return false;
            }
            return true;
        }

        //Contructor for CurrentCustomerModel
        public CardCustomerModel getCurrentCustomerModel()
        {
            return CurrentCustomerModel;
        }

        public void setCurrentCustomerModel(CardCustomerModel currentCustomer)
        {
            CurrentCustomerModel = currentCustomer;
        }

        public Boolean isCurrentCustomerModelEmpty()
        {
            if (CurrentCustomerModel != null)
            {
                return false;
            }
            return true;
        }

        //contructor for cardType 
        public int? getCardType()
        {
            return CardType;
        }

        public void setCardType(int? cardType)
        {
            CardType = cardType;
        }

        //contructor for CurrentVoucherModel
        public VoucherResultModel getCurrentVoucherModel()
        {
            return CurrentVoucherModel;
        }

        public void setCurrentVoucherModel(VoucherResultModel model)
        {
            CurrentVoucherModel = model;
        }

        //contrutor for TmpOrderEditViewModel
        public OrderEditViewModel getTmpOrderEditViewModel()
        {
            return TmpOrderEditViewModel;
        }

        public void setTmpOrderEditViewModel(OrderEditViewModel tmpOrderView)
        {
            TmpOrderEditViewModel = tmpOrderView;
        }

        //contructor for _currentOrderDetailId
        public int getCurrentOrderDetailId()
        {
            return _currentOrderDetailId;
        }
        #endregion


        #region OrderDetail

        /// <summary>
        /// Handle all service related to quantity of OrderEditViewModel detail .
        /// CASE 1: ProductViewModel not null , OrderDetailViewModel null -> add or change main item in MAIN ProductViewModel PANEL
        /// CASE 2: ProductViewModel null, OrderDetailViewModel not null -> edit orderetail of mainitem in OrderEditViewModel DETAIL PROPERTYPANEL/ NEW ORDERDETAIL
        /// CASE 3: ProductViewModel not null, ordertetail not null -> add or edit EXTRA OrderDetailViewModel in OrderEditViewModel DETAIL PROPERTYPANEL. (ProductViewModel is extra)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="productViewModel">null:productinfo is stored in orderdetail</param>
        /// <param name="orderDetailEditViewModel">null: manipulate on last item, not null: update existing OrderEditViewModel detail(main item and extra)</param>
        /// <param name="adjustItemQuantity">adjustItemQuantity of ProductViewModel to be updated (positive ADD, negative DESCREASE), 0 when REMOVED item</param>
        public void ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum mode, ProductViewModel productViewModel, OrderDetailEditViewModel orderDetailEditViewModel, int adjustItemQuantity)
        {
            try
            {
                isDirty = true;

                if (orderDetailEditViewModel == null)
                {
                    //thêm mới hoăc giảm bớt nhanh sản phẩm
                    // OrderDetailViewModel == null, it means this is the MainItem

                    var orderDetails = GetOrderDetails(true);
                    var lastOrderDetail = orderDetails.LastOrDefault(od => od.ProductCode == productViewModel.Code);

                    if (lastOrderDetail != null
                        && (lastOrderDetail.Status == ((int)OrderDetailStatusEnum.New) || lastOrderDetail.Status == ((int)OrderDetailStatusEnum.Processing)))
                    {
                        var extraList = GetExtraAndMainOrderDetails(lastOrderDetail.OrderDetailID);
                        var extra = extraList.FirstOrDefault(c => (c.ParentId ?? (-1)) == lastOrderDetail.OrderDetailID);

                        // Neu ton tai phan tu con co ProductId trung => cap nhat quantity

                        if (extra != null)
                        {
                            if ((extra.Quantity + adjustItemQuantity * lastOrderDetail.Quantity) == 0)
                            {
                                extra.SetItemQuantity(0, 0);
                                extra.Status = (int)OrderDetailStatusEnum.PosPreCancel;
                                RemoveOrderDetail(extra);
                            }
                            else if ((extra.Quantity + adjustItemQuantity * lastOrderDetail.Quantity) > 0)
                            {
                                int extraQuantity = extra.ItemQuantity * (lastOrderDetail.Quantity + adjustItemQuantity);
                                extra.SetItemQuantity(extra.ItemQuantity, extraQuantity);
                                extra.Status = (int)OrderDetailStatusEnum.New;
                            }
                        }

                        if (lastOrderDetail.ItemQuantity + adjustItemQuantity == 0)//delete
                        {
                            //Xoa orderDetail
                            lastOrderDetail.SetItemQuantity(0, 0);
                            lastOrderDetail.Status = (int)OrderDetailStatusEnum.PosPreCancel;
                            RemoveOrderDetail(lastOrderDetail);
                            CallNotifyOrderDetail(lastOrderDetail, OrderDetailChangeModeEnum.RemoveOrderDetail);//kg -1 vi da remove phan tu truoc
                        }
                        else if (mode == OrderDetailChangeModeEnum.AddOrderDetail)
                        {
                            //trung voi last OrderEditViewModel detail nhung van case Add
                            if (adjustItemQuantity > 0)//redudant 
                            {
                                String code = InvoiceCodeGenerator.GenerateInvoiceCode();
                                var od = new OrderDetailEditViewModel()
                                {
                                    OrderDetailID = _currentOrderDetailId,
                                    TmpDetailId = _currentOrderDetailId++,
                                    OrderDate = UtcDateTime.Now(),
                                    ProductId = productViewModel.ProductId,
                                    ProductCode = productViewModel.Code, //code of child (if type general)
                                    ProductName = productViewModel.ProductName, //name of child
                                    ProductType = productViewModel.ProductType,
                                    ParentId = productViewModel.ProductParentId,
                                    Status = (int)OrderDetailStatusEnum.New,
                                    UnitPrice = productViewModel.Price, //price of child (if type general)
                                    CatId = productViewModel.CatID,
                                    ProductViewModel = productViewModel,
                                    OrderEditViewModel = OrderEditViewModel, //important
                                    OrderGroup = 0,
                                    //PrintGroup = productViewModel.PrintGroup,
                                    Code = MainForm.PosConfig.InvoideCodepattern.Replace("{StoreId}", MainForm.StoreInfo.StoreId).Replace("{StoreName}", MainForm.StoreInfo.TerminalName).Replace("{Code}", code),
                                };
                                od.SetItemQuantity(adjustItemQuantity, adjustItemQuantity);//Mainproduct => itemquantity, quantity : same
                                OrderEditViewModel.OrderDetailEditViewModels.Add(od);
                                //Cap nhat lai OrderEditViewModel
                                CallNotifyOrderDetail(od, OrderDetailChangeModeEnum.AddOrderDetail);
                            }
                        }
                        else if (lastOrderDetail.ItemQuantity + adjustItemQuantity > 0)
                        {
                            int lastQuantity = lastOrderDetail.ItemQuantity;
                            int newQuantity = lastOrderDetail.ItemQuantity + adjustItemQuantity;
                            lastOrderDetail.Status = (int)OrderDetailStatusEnum.New;
                            lastOrderDetail.SetItemQuantity(newQuantity, newQuantity);//Do la main product

                            //Kich hoat su kien de cap nhat lai giao dien
                            // Cap nhat lai lastOrderDetail vua bi xoa
                            if (lastQuantity == 0 && newQuantity == 1)
                            {
                                CallNotifyOrderDetail(lastOrderDetail, OrderDetailChangeModeEnum.AddOrderDetail);
                            }
                            // Thay doi quantity lastOrderDetail
                            else
                            {
                                CallNotifyOrderDetail(lastOrderDetail, OrderDetailChangeModeEnum.ModifiedOrderDetail);
                            }
                        }
                    }
                    else
                    {
                        //khong trung voi last OrderEditViewModel detail
                        //Chon ProductViewModel moi add vao
                        //Tao moi OrderDetail, kg can xet extra
                        if (adjustItemQuantity > 0)//redudant 
                        {
                            string code = InvoiceCodeGenerator.GenerateInvoiceCode();
                            var od = new OrderDetailEditViewModel()
                            {
                                OrderDetailID = _currentOrderDetailId,
                                TmpDetailId = _currentOrderDetailId++,
                                OrderDate = UtcDateTime.Now(),
                                ProductId = productViewModel.ProductId,
                                ProductCode = productViewModel.Code, //code of child (if type general)
                                ProductName = productViewModel.ProductName, //name of child
                                ProductType = productViewModel.ProductType,
                                ParentId = productViewModel.ProductParentId,
                                Status = (int)OrderDetailStatusEnum.New,
                                UnitPrice = productViewModel.Price, //price of child (if type general)
                                CatId = productViewModel.CatID,
                                ProductViewModel = productViewModel,
                                OrderEditViewModel = OrderEditViewModel, //important
                                OrderGroup = 0,
                                //PrintGroup= productViewModel.PrintGroup,
                                Code = MainForm.PosConfig.InvoideCodepattern.Replace("{StoreId}", MainForm.StoreInfo.StoreId).Replace("{StoreName}", MainForm.StoreInfo.TerminalName).Replace("{Code}", code),
                            };
                            od.SetItemQuantity(adjustItemQuantity, adjustItemQuantity);//Mainproduct => itemquantity, quantity : same
                            OrderEditViewModel.OrderDetailEditViewModels.Add(od);
                            //Cap nhat lai OrderEditViewModel
                            CallNotifyOrderDetail(od, OrderDetailChangeModeEnum.AddOrderDetail);
                        }
                    }
                }
                else //orderdetail != null
                {
                    //modify orderitem đã có sẵn, khi chon property panel
                    //orderdetail not null : co 2 truong hop: thay doi item quantity cua mainitem, hoac extra

                    if (productViewModel == null)
                    {
                        //Day la mainitem
                        //cap nhat lai quantity cua mainItem
                        //cap nhat lai quantity cua extra ung voi item nay
                        if (mode == OrderDetailChangeModeEnum.RemoveOrderDetail || mode == OrderDetailChangeModeEnum.ModifiedOrderDetail)
                        {
                            if (orderDetailEditViewModel.ItemQuantity + adjustItemQuantity == 0 || adjustItemQuantity == 0)
                            {
                                //xóa mainitem => xóa tất cả extra

                                //orderDetail.SetItemQuantity(0, 0);//Set về 0 để cập nhật giao diện
                                //if (orderDetail.Status == (int)OrderDetailStatusEnum.PosFinished)
                                //{
                                //    orderDetail.Status = (int)OrderDetailStatusEnum.PosCancel;
                                //}
                                //else if (orderDetail.Status == (int)OrderDetailStatusEnum.Finish)
                                //{
                                //    orderDetail.Status = (int)OrderDetailStatusEnum.Cancel;
                                //}
                                //else
                                //{
                                //    orderDetail.Status = (int)OrderDetailStatusEnum.PreCancel;
                                //}
                                //RemoveOrderDetail(orderDetail);

                                var extraAndMainList = GetExtraAndMainOrderDetails(orderDetailEditViewModel.OrderDetailID);
                                // Xoa tất cả extra
                                foreach (var item in extraAndMainList)
                                {
                                    //OrderEditViewModel.OrderDetailEditViewModels.Remove(extra);
                                    if (item.Status == (int)OrderDetailStatusEnum.PosFinished
                                        || item.Status == (int)OrderDetailStatusEnum.Finish)
                                    {
                                        item.Status = (int)OrderDetailStatusEnum.PosCancel;
                                    }
                                    else
                                    {
                                        //Chỉ set lại quantity nếu sản phẩn chưa được chế biến
                                        item.SetItemQuantity(0, 0);
                                        item.Status = (int)OrderDetailStatusEnum.PreCancel;
                                    }
                                    RemoveOrderDetail(item);
                                }

                                //Cap nhat lai OrderEditViewModel
                                CallNotifyOrderDetail(orderDetailEditViewModel, OrderDetailChangeModeEnum.RemoveOrderDetail);
                            }
                            else if (orderDetailEditViewModel.ItemQuantity + adjustItemQuantity > 0 || adjustItemQuantity > 0)
                            {
                                //Khong xoa, chi cap nhat so luong cua MainItem
                                //Step 1: Cap nhat lai itemquantity cua mainItem
                                //Step2:  cap nhat lai cac extra của mainitem này 

                                // Cap nhat lau itemQuantity cua mainItem
                                var mainItem = GetOrderDetailById(orderDetailEditViewModel.OrderDetailID);
                                if (mainItem != null)
                                {
                                    int newQuantity = mainItem.ItemQuantity + adjustItemQuantity;
                                    mainItem.SetItemQuantity(newQuantity, newQuantity);
                                }
                                // Lay tat ca extra thuoc ve mainItem do
                                var extraList = GetExtraAndMainOrderDetails(orderDetailEditViewModel.OrderDetailID).Skip(1);
                                // Cap nhat la tat ca extra cua mainItem do

                                // TODO: them mode cap nhat extra theo mainItem hay khong tuy theo cua hang yeu cau
                                if (MainForm.PosConfig.IsUpdateExtraWhenUpdateOrderDetail.Trim().ToLower() == "true")
                                {
                                    foreach (var extra in extraList)
                                    {
                                        extra.UpdateExtraQuantity(orderDetailEditViewModel.Quantity);
                                    }
                                }

                                CallNotifyOrderDetail(mainItem, OrderDetailChangeModeEnum.ModifiedOrderDetail);
                            }
                        }
                        //Chuc nang tao OrderDetailViewModel mới từ OrderDetailViewModel hiện tại 
                        else if (mode == OrderDetailChangeModeEnum.AddOrderDetail)
                        {
                            var tmpProduct = new ProductViewModel();
                            if (orderDetailEditViewModel.ProductViewModel.GeneralProductId == null)
                            {
                                tmpProduct =
                                    Program.context.getAvailableSingleProducts().
                                    FirstOrDefault(p => p.Code == orderDetailEditViewModel.ProductCode);
                            }
                            else
                            {
                                tmpProduct = Program.context.getAllProducts().
                                    FirstOrDefault(p => p.Code == orderDetailEditViewModel.ProductCode);
                            }
                            if (tmpProduct != null)
                            {
                                string code = InvoiceCodeGenerator.GenerateInvoiceCode();
                                var newOrderDetail = new OrderDetailEditViewModel()
                                {
                                    OrderDetailID = _currentOrderDetailId,
                                    TmpDetailId = _currentOrderDetailId++,
                                    OrderDate = UtcDateTime.Now(),
                                    ProductId = orderDetailEditViewModel.ProductId,
                                    ProductCode = orderDetailEditViewModel.ProductCode,
                                    ProductName = orderDetailEditViewModel.ProductName,
                                    ProductType = tmpProduct.ProductType,
                                    UnitPrice = orderDetailEditViewModel.UnitPrice,
                                    ParentId = tmpProduct.ProductParentId,
                                    Status = (int)OrderDetailStatusEnum.New,
                                    CatId = orderDetailEditViewModel.CatId,
                                    ProductViewModel = orderDetailEditViewModel.ProductViewModel,
                                    OrderEditViewModel = OrderEditViewModel, //important
                                    OrderGroup = 0,
                                    Code = MainForm.PosConfig.InvoideCodepattern.Replace("{StoreId}", MainForm.StoreInfo.StoreId).Replace("{StoreName}", MainForm.StoreInfo.TerminalName).Replace("{Code}", code),
                                };
                                newOrderDetail.SetItemQuantity(1, 1);
                                OrderEditViewModel.OrderDetailEditViewModels.Add(newOrderDetail);
                                CallNotifyOrderDetail(newOrderDetail, OrderDetailChangeModeEnum.AddOrderDetail);
                            }
                        }
                    }
                    else
                    {
                        //truong hop add san pham extra vao 1 OrderEditViewModel item
                        //phải đảm bảo OrderDetailViewModel  ở trạng thái New - Duy hoặc Processing - mới được Add
                        if (orderDetailEditViewModel.Status == (int)OrderDetailStatusEnum.New ||
                            orderDetailEditViewModel.Status == (int)OrderDetailStatusEnum.Processing)
                        {

                            //step 1: tim phan tu OrderDetailViewModel trong list
                            //step 2: duyet qua cac extra cua OrderDetailViewModel nay
                            //step 3: neu ton tai extra co productid trung => cap nhat quantity
                            //step 3.2: neu chua ton tai productid trong extra => them moi 1 extra 
                            var extraList = GetExtraAndMainOrderDetails(orderDetailEditViewModel.OrderDetailID);

                            var extra = extraList.FirstOrDefault(c => c.ProductCode == productViewModel.Code);

                            // Neu ton tai phan tu con co ProductId trung => cap nhat quantity

                            if (extra != null)
                            {
                                if (extra.ItemQuantity + adjustItemQuantity == 0 || adjustItemQuantity == 0)
                                {
                                    extra.SetItemQuantity(0, 0);
                                    extra.Status = (int)OrderDetailStatusEnum.PosPreCancel;
                                    RemoveOrderDetail(extra);
                                }
                                else if (extra.ItemQuantity + adjustItemQuantity > 0 || adjustItemQuantity > 0)
                                {
                                    int extraItemQuantity = extra.ItemQuantity + adjustItemQuantity;
                                    int extraQuantity = extraItemQuantity * orderDetailEditViewModel.Quantity;
                                    extra.SetItemQuantity(extraItemQuantity, extraQuantity);
                                    extra.Status = (int)OrderDetailStatusEnum.New;
                                }
                            }
                            else
                            {
                                //product not null - OrderDetailViewModel not null
                                // Neu khong thi tao moi extra
                                if (adjustItemQuantity > 0)
                                {
                                    extra = new OrderDetailEditViewModel()
                                    {
                                        OrderDetailID = _currentOrderDetailId,
                                        TmpDetailId = _currentOrderDetailId++,
                                        //OrderDetailID = 0,
                                        OrderDate = UtcDateTime.Now(),
                                        ProductId = productViewModel.ProductId,
                                        ProductCode = productViewModel.Code,
                                        ProductName = productViewModel.ProductName,
                                        ProductType = productViewModel.ProductType,
                                        UnitPrice = productViewModel.Price,
                                        ParentId = orderDetailEditViewModel.OrderDetailID,
                                        Status = (int)OrderDetailStatusEnum.New,
                                        CatId = productViewModel.CatID,
                                        ProductViewModel = productViewModel,
                                        OrderEditViewModel = OrderEditViewModel, //important
                                        OrderGroup = 0
                                    };

                                    //extra được add thêm sau sẽ không có discount
                                    //trường hợp main ProductViewModel discount nhưng extra không discount
                                    //extra.SetDiscount(orderDetail.DiscountRate);
                                    if (MainForm.PosConfig.IsUpdateExtraWhenUpdateOrderDetail.Trim().ToLower() == "false")
                                    {
                                        extra.SetItemQuantity(1, 1);
                                    }
                                    else
                                    {
                                        extra.SetItemQuantity(adjustItemQuantity,
                                            adjustItemQuantity * orderDetailEditViewModel.Quantity);
                                    }
                                    OrderEditViewModel.OrderDetailEditViewModels.Add(extra);
                                }
                            }
                            //Goi chung 1 hàm cho tất cả các trường hợp có thay đổi extra
                            CallNotifyOrderDetail(orderDetailEditViewModel, OrderDetailChangeModeEnum.ModifiedOrderDetail);
                        }
                    }
                }

                AfterAppliedPromotion();
            }
            catch (Exception ex)
            {
                ////log.Error("ChangeItemQuantityOfOrderDetail - " + ex);
                //Program._log.SendLogError(ex);
            }
        }

        /// <summary>
        /// Add OrderEditViewModel detail form OrderEditViewModel to TempOrder
        /// </summary>
        /// <param name="orderDetail"></param>
        public void AddOrderDetailOfTempOrder(OrderDetailEditViewModel orderDetail)
        {
            try
            {
                var newOrderDetail = new OrderDetailEditViewModel();
                AutoMapper.Mapper.Map<OrderDetailEditViewModel, OrderDetailEditViewModel>(orderDetail, newOrderDetail);

                newOrderDetail.OrderDetailID = orderDetail.OrderDetailID;   //Cập nhật Id
                newOrderDetail.TmpDetailId = newOrderDetail.OrderDetailID;

                newOrderDetail.HasOrderDetailId = false;        //new orderdetail
                newOrderDetail.SplitState = (int)SplitOrderDetailStateEnum.New;
                newOrderDetail.OrderDate = UtcDateTime.Now();

                newOrderDetail.OrderEditViewModel = TmpOrderEditViewModel;               //important
                newOrderDetail.OrderId = TmpOrderEditViewModel.OrderId;     //important

                // Nếu status là Cancel -> Finish , PosCancel -> PosFinished
                if (newOrderDetail.Status == (int)OrderDetailStatusEnum.New)
                {
                    newOrderDetail.Status = (int)OrderDetailStatusEnum.Processing;
                }

                TmpOrderEditViewModel.OrderDetailEditViewModels.Add(newOrderDetail);
                TmpOrderEditViewModel.TotalAmount += newOrderDetail.TotalAmount;    //Cập nhật Amount
                TmpOrderEditViewModel.FinalAmount += newOrderDetail.FinalAmount;
            }
            catch (Exception ex)
            {
                //log.Error("AddOrderDetailOfTempOrder - " + ex);
                //Program._log.SendLogError(ex);
            }
        }





        #region Update OrderDetail

        //public void UpdateDiscountRateOfOrderDetail(OrderDetailEditViewModel orderDetail)
        //{
        //    if (orderDetail.Discount > 0)
        //    {
        //        orderDetail.DiscountRate = orderDetail.Discount / orderDetail.TotalAmount * 100;

        //        if (orderDetail.ParentId == null)
        //        {
        //            //var extraList = OrderEditViewModel.OrderDetailEditViewModels.Where(od => od.ParentId == orderDetail.OrderDetailID);
        //            var extraList = GetExtraOrderDetails(orderDetail.OrderDetailID);
        //            // Xoa tất cả extra
        //            foreach (var extra in extraList)
        //            {
        //                extra.DiscountRate = rate;
        //                extra.Discount = extra.TotalAmount * extra.DiscountRate / 100;
        //                extra.FinalAmount = extra.TotalAmount - extra.Discount;
        //            }
        //        }
        //    }

        //    CallNotifyOrderDetail(orderDetail, OrderDetailChangeMode.UpdateOrderDetailInfo);
        //}

        public void UpdateNoteOfOrderDetail(OrderDetailEditViewModel orderDetail, string notes)
        {
            orderDetail.Notes = notes;
            if (NotifyChangeOrderDetail != null)
            {
                CallNotifyOrderDetail(orderDetail, OrderDetailChangeModeEnum.UpdateOrderDetailInfo);
            }
        }

        public void UpdateMainItemOfOrderDetail(OrderDetailEditViewModel orderDetail, ProductViewModel newProduct)
        {
            orderDetail.ProductViewModel = newProduct;
            orderDetail.ProductId = newProduct.ProductId;
            orderDetail.ProductCode = newProduct.Code; //code of child (if type general)
            orderDetail.ProductName = newProduct.ProductName; //name of child
            orderDetail.ProductType = newProduct.ProductType;
            orderDetail.ParentId = newProduct.ProductParentId;
            orderDetail.UnitPrice = newProduct.Price; //price of child (if type general)
            orderDetail.CatId = newProduct.CatID;
            // Update quantity, amount
            orderDetail.SetItemQuantity(orderDetail.ItemQuantity, orderDetail.Quantity);
            //orderDetail.TempSize = newProduct.Att1; //size of child (if type general)

            if (NotifyChangeOrderDetail != null)
            {
                CallNotifyOrderDetail(orderDetail, OrderDetailChangeModeEnum.UpdateOrderDetailInfo);
                //NotifyChangeOrderDetail(orderDetail, OrderDetailChangeMode.UpdateOrderDetailInfo);
            }
        }

        #endregion

        /// <summary>
        /// Remove OrderDetailViewModel in list of OrderEditViewModel
        /// </summary>
        /// <param name="orderDetail"></param>
        private void RemoveOrderDetail(OrderDetailEditViewModel orderDetail)
        {
            var od = OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(o => o == orderDetail);
            if (od != null
                && od.OrderDetailPromotionMappingEditViewModels != null
                && od.OrderDetailPromotionMappingEditViewModels.Any())
            {

                od.OrderDetailPromotionMappingEditViewModels = new List<OrderDetailPromotionMappingEditViewModel>();
            }
            OrderEditViewModel.OrderDetailEditViewModels.Remove(orderDetail);
            CallNotifyOrderDetail(orderDetail, OrderDetailChangeModeEnum.RemoveOrderDetail);
        }


        #region Get OrderDetails
        /// <summary>
        /// Get OrderDetailViewModel of current OrderEditViewModel
        /// </summary>
        /// <param name="isRemoveCancel">True: remove items with CANCEL status- False: Get all</param>
        public List<OrderDetailEditViewModel> GetOrderDetails(bool isRemoveCancel)
        {
            if (isRemoveCancel)
            {

                return OrderEditViewModel.getOrderDetailEditViewModels().Where(od => od.Status == (int)OrderDetailStatusEnum.New ||
                                                       od.Status == (int)OrderDetailStatusEnum.Processing ||
                                                       od.Status == (int)OrderDetailStatusEnum.PosFinished ||
                                                       od.Status == (int)OrderDetailStatusEnum.Finish).ToList();
            }
            else
            {
                return OrderEditViewModel.getOrderDetailEditViewModelsList();
            }
        }

        //public List<OrderDetailEditViewModel> GetTempOrderDetails(bool isRemoveCancel)
        //{
        //    if (TmpOrderEditViewModel == null)
        //    {
        //        TmpOrderEditViewModel = new OrderEditViewModel();
        //    }
        //    if (isRemoveCancel)
        //    {
        //        return TmpOrderEditViewModel.OrderDetailEditViewModels.Where(od => od.Status == (int)OrderDetailStatusEnum.New ||
        //                                               od.Status == (int)OrderDetailStatusEnum.Processing ||
        //                                               od.Status == (int)OrderDetailStatusEnum.PosFinished ||
        //                                               od.Status == (int)OrderDetailStatusEnum.Finish).ToList();
        //    }
        //    else
        //    {
        //        return TmpOrderEditViewModel.getOrderDetailEditViewModelsList()();
        //    }
        //}

        public List<OrderDetailEditViewModel> GetExtraAndMainOrderDetails(int mainItemId)
        {
            //Dam bao Main Item luon duong truoc trong danh sach
            return OrderEditViewModel.OrderDetailEditViewModels.Where(od => od.OrderDetailID == mainItemId || od.ParentId == mainItemId
                 && (od.Status == (int)OrderDetailStatusEnum.New
                    || od.Status == (int)OrderDetailStatusEnum.Processing
                    || od.Status == (int)OrderDetailStatusEnum.PosFinished
                    || od.Status == (int)OrderDetailStatusEnum.Finish
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.Cancel)).
                OrderBy(od => od.ParentId).ToList();
        }

        public List<OrderDetailEditViewModel> GetExtraOrderDetails(int mainOrderDetailId)
        {
            return OrderEditViewModel.OrderDetailEditViewModels.Where(od => (od.ParentId == mainOrderDetailId)
                 && (od.Status == (int)OrderDetailStatusEnum.New
                    || od.Status == (int)OrderDetailStatusEnum.Processing
                    || od.Status == (int)OrderDetailStatusEnum.PosFinished
                    || od.Status == (int)OrderDetailStatusEnum.Finish
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.Cancel)).ToList();
        }


        public OrderDetailEditViewModel GetOrderDetailById(int orderDetailId)
        {
            return OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == orderDetailId);
        }
        #endregion


        private void CallNotifyOrderDetail(OrderDetailEditViewModel orderDetail, OrderDetailChangeModeEnum mode)
        {
            UpdateOrder(OrderChangeModeEnum.OrderDetailChange);
            OrderEditViewModel.LastModifiedOrderDetail = UtcDateTime.Now();
            isChange = true;
            if (NotifyChangeOrderDetail != null) NotifyChangeOrderDetail(orderDetail, mode);
        }


        /// <summary>
        /// Tách OrderEditViewModel details từ OrderEditViewModel -> TempOrder
        /// </summary>
        public void SplitOrderDetails()
        {
            var tmpDetails = OrderEditViewModel.getOrderDetailEditViewModels().
                Where(od => od.SplitState == (int)SplitOrderDetailStateEnum.Moved).ToList();

            //Lấy tất cả OrderDetailViewModel có split state = moved vào tmpDetails

            //Tạo TotalAmount + FinalAmount nếu chưa có
            if (!TmpOrderEditViewModel.HasOrderId)
            {
                TmpOrderEditViewModel.TotalAmount = 0;
                TmpOrderEditViewModel.FinalAmount = 0;
            }

            //Add OrderDetailViewModel vào TempOrder
            //Remove OrderDetailViewModel khỏi OrderEditViewModel
            foreach (var item in tmpDetails)
            {
                foreach (var promotion in Program.context.getPromotions())
                {
                    RemoveAppliedPromotion(promotion, item);
                }
                AfterAppliedPromotion();
                AddOrderDetailOfTempOrder(item);

                var od = OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(o => o.OrderDetailID == item.OrderDetailID);
                if (od != null)
                {
                    od.SetItemQuantity(0, 0);
                    od.Status = (int)OrderDetailStatusEnum.PosPreCancel;
                    RemoveOrderDetail(od);
                }

            }

            int orderId = 0;
            var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
            var orderExist = orderService.GetOrderByOrderCode(TmpOrderEditViewModel.OrderCode);
            foreach (var paymentViewModel in TmpOrderEditViewModel.getPaymentEditViewModels())
            {
                if (orderExist.Payments.Where(p => p.Type == paymentViewModel.Type).FirstOrDefault() != null)
                {
                    RemovePayment(paymentViewModel);
                }
            }
            if (TmpOrderEditViewModel.getPaymentEditViewModels().Count() == 0)
            {
                return;
            }
            //Save TempOrder 
            if (!TmpOrderEditViewModel.HasOrderId) //Tạo data nếu là OrderEditViewModel mới
            {
                string code = InvoiceCodeGenerator.GenerateInvoiceCode();


                TmpOrderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosProcessing;
                TmpOrderEditViewModel.CheckInDate = UtcDateTime.Now();
                TmpOrderEditViewModel.CheckInPerson = MainForm.CurrentAccount.AccountId;
                TmpOrderEditViewModel.OrderType = (int)OrderTypeEnum.AtStore;

                //OrderDetails = new List<OrderDetailEditViewModel>(),
                //Payments = new List<Payment>(),

                TmpOrderEditViewModel.OrderCode = MainForm.PosConfig.InvoideCodepattern.Replace("{StoreId}", MainForm.StoreInfo.StoreId).Replace("{StoreName}", MainForm.StoreInfo.TerminalName).Replace("{Code}", code);
                //{StoreId}-{StoreName}-{Code}

                var order = ServiceManager.GetOrder(TmpOrderEditViewModel);

                orderId = orderService.CreateOrder(order);   //create
            }
            else
            {
                //var order = ServiceManager.GetOrder(TmpOrderEditViewModel);

                orderId = orderService.UpdateOrder(TmpOrderEditViewModel);     //edit
            }

            //Cập nhật orderId
            TmpOrderEditViewModel.OrderId = orderId;

            bool isTempOrder = true;

            //Cập nhật status bàn TempOrder đang sử dụng sang InUse
            SaleScreen3.ChangeTableStatus(TableStatusEnum.InUse, isTempOrder);

            //Release TempOrder
            TmpOrderEditViewModel = null;
        }

        #endregion


        #region Payment

        /// <summary>
        /// Cap nhat thong tin Payment cua hoa don, Moi hoa don co 3 loai payment: Cash, CreditCard, Membership va Other CC
        /// </summary>
        /// isRefresh = true : refresh payment sau khi xoa / false = add new
        public void UpdatePayment(PaymentTypeEnum type, double amount, string cardCode)
        {
            try
            {
                isDirty = true;
                var payment = new PaymentEditViewModel();
                payment.PaymentID = -1;

                //if (isRefresh)
                //{
                //    payment = orderEditViewModel.getPaymentEditViewModels()
                //                    .LastOrDefault(p => p.Type == (int)type);
                //    if (payment != null)
                //    {
                //        payment.Amount = amount;
                //        payment.CardCode = cardCode;
                //    }
                //}

                if (payment == null
                    || (payment != null && payment.PaymentID == -1))
                {
                    var id = 0;
                    if (Program.context.getCurrentOrderManager().getPaymentEditViewModels() != null)
                    {
                        if (Program.context.getCurrentOrderManager().getPaymentEditViewModels().Any())
                        {
                            var lastPayment = Program.context.getCurrentOrderManager().getPaymentEditViewModels().OrderBy(p => p.PaymentID).Last();
                            if (lastPayment != null)
                            {
                                id = lastPayment.PaymentID + 1;
                            }
                        }
                    }

                    payment = new PaymentEditViewModel()
                    {
                        PaymentID = id,
                        Type = (int)type,
                        Amount = amount,
                        CardCode = cardCode,
                        PayTime = UtcDateTime.Now(),
                        OrderId = OrderEditViewModel.OrderId,
                        OrderEditViewModel = OrderEditViewModel,
                    };

                    Program.context.getCurrentOrderManager().getPaymentEditViewModels().Add(payment);
                }

                //Notify change
                UpdateOrder(OrderChangeModeEnum.PaymentChange);
                OrderEditViewModel.LastModifiedPayment = UtcDateTime.Now();
                isChange = true;
                if (NotifyChangeOrderDetail != null)
                {
                    NotifyChangeOrderDetail(null, OrderDetailChangeModeEnum.UpdateOrderDetailInfo);
                }
            }
            catch (Exception ex)
            {
                //Program._log.SendLogError(ex);
                //log.Error("UpdatePayment - " + ex);
            }
        }

        public void RemovePayment(PaymentEditViewModel payment = null)
        {
            if (payment == null)
            {
                OrderEditViewModel.getPaymentEditViewModels().Clear();
            }
            else
            {
                OrderEditViewModel.getPaymentEditViewModels().Remove(payment);
            }

            //Notify change
            UpdateOrder(OrderChangeModeEnum.PaymentChange);
            OrderEditViewModel.LastModifiedPayment = UtcDateTime.Now();
            isChange = true;
            if (NotifyChangeOrderDetail != null)
            {
                NotifyChangeOrderDetail(null, OrderDetailChangeModeEnum.UpdateOrderDetailInfo);
            }
        }

        public void RemoveUnusePayment()
        {
            var removeList = new List<PaymentEditViewModel>();

            foreach (var paymentViewModel in OrderEditViewModel.getPaymentEditViewModels())
            {
                if (paymentViewModel.Amount == 0)
                {
                    removeList.Add(paymentViewModel);
                }
            }

            foreach (var item in removeList)
            {
                OrderEditViewModel.getPaymentEditViewModels().Remove(item);
            }
        }

        public void RemoveAllPayment(PaymentTypeEnum type)
        {
            OrderEditViewModel.getPaymentEditViewModels().RemoveAll(p => p.Type == (int)type);

            //Notify change
            UpdateOrder(OrderChangeModeEnum.PaymentChange);
            OrderEditViewModel.LastModifiedPayment = UtcDateTime.Now();
            isChange = true;
            if (NotifyChangeOrderDetail != null)
            {
                NotifyChangeOrderDetail(null, OrderDetailChangeModeEnum.UpdateOrderDetailInfo);
            }
        }

        #endregion
        /// <summary>
        /// Reset Order
        /// </summary>
        public void ResetOrderInfo()
        {
            try
            {
                isDirty = true;

                CurrentCustomerModel = null;
                OrderEditViewModel.BarCode = "";
                OrderEditViewModel.OrderId = -1;
                OrderEditViewModel.OrderCode = "";
                OrderEditViewModel.HasOrderId = false;

                OrderEditViewModel.ResetPayment();

                OrderEditViewModel.PrefixBarCodes = new List<string>();
                OrderEditViewModel.setPaymentEditViewModels(new List<PaymentEditViewModel>());
                OrderEditViewModel.OrderDetailEditViewModels = new List<OrderDetailEditViewModel>();
                OrderEditViewModel.OrderPromotionMappingEditViewModels = new List<OrderPromotionMappingEditViewModel>();
            }
            catch (Exception ex)
            {
                //log.Error("ResetOrderInfo - " + ex);
                //Program._log.SendLogError(ex);
            }
        }



        #region OrderEditViewModel

        private void UpdateOrder(OrderChangeModeEnum mode)
        {
            try
            {
                isDirty = true;
                if (mode == OrderChangeModeEnum.OrderDetailChange)
                {
                    OrderEditViewModel.TotalAmount = 0;

                    foreach (var orderDetail in OrderEditViewModel.OrderDetailEditViewModels)
                    {
                        OrderEditViewModel.TotalAmount += orderDetail.TotalAmount;
                    }

                    UpdateDiscountOrder();
                }
                else if (mode == OrderChangeModeEnum.PaymentChange)
                {
                    //OrderEditViewModel.TotalPayment = orderEditViewModel.getPaymentEditViewModels().ToList().Sum(p => p.Amount);
                }
            }
            catch (Exception ex)
            {
                //log.Error("UpdateOrder - " + ex);
                //Program._log.SendLogError(ex);
            }
        }

        #region Get 
        public int GetTotalProduct()
        {
            return OrderEditViewModel.OrderDetailEditViewModels
                .Where(od => od.ParentId == null
                        && od.Status != (int)OrderDetailStatusEnum.Cancel
                        && od.Status != (int)OrderDetailStatusEnum.PosCancel
                        && od.Status != (int)OrderDetailStatusEnum.PreCancel
                        && od.Status != (int)OrderDetailStatusEnum.PosPreCancel)
                .Sum(od => od.Quantity);
        }

        public int GetTotalProductOfTempOrder()
        {
            if (TmpOrderEditViewModel != null)
            {
                return TmpOrderEditViewModel.OrderDetailEditViewModels.Where(od => od.ParentId == null).Sum(od => od.Quantity);
            }
            else return 0;
        }

        public int GetNumOfProduct(string code, int? parentId = -1)
        {
            if (OrderEditViewModel.OrderDetailEditViewModels == null)
            {
                OrderEditViewModel.OrderDetailEditViewModels = new List<OrderDetailEditViewModel>();
            }
            var product = OrderEditViewModel.OrderDetailEditViewModels.Where(od =>
            {
                if (od.ProductCode.Equals(code))
                {
                    return true;
                }
                else
                {
                    var tmpProduct =
                        Program.context.getAllProducts().FirstOrDefault(p => p.Code.Equals(od.ProductCode));
                    if (tmpProduct != null)
                    {
                        if (tmpProduct.GeneralProductId == (parentId ?? (-1)))
                            return true;
                    }
                    return false;
                }
            });
            return product.Sum(od => od.Quantity);
        }

        public int GetNumOfNewOrderDetail()
        {
            return OrderEditViewModel.OrderDetailEditViewModels.Count(od => od.Status == (int)OrderDetailStatusEnum.New);
        }
        #endregion

        #region OrderEditViewModel Manipulation - With database- Split OrderEditViewModel

        private int SaveOrder()
        {
            try
            {
                int orderId = OrderEditViewModel.OrderId;
                if (isDirty)
                {
                    var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                    if (!OrderEditViewModel.HasOrderId)
                    {
                        //New order - Not Exist in database
                        var order = ServiceManager.GetOrder(OrderEditViewModel);
                        var orderSameCode = orderService.GetOrderByOrderCode(order.OrderCode);

                        if (orderSameCode == null)
                        {
                            orderId = orderService.CreateOrder(order);
                            OrderEditViewModel.OrderId = orderId;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        //var order = ServiceManager.GetOrder(TmpOrderEditViewModel);
                        //orderService.UpdateOrder(TmpOrderEditViewModel);
                        orderService.UpdateOrder(OrderEditViewModel);
                    }
                }
                isDirty = false;
                return orderId;
            }
            catch (Exception ex)
            {
                //log.Error("SaveOrder - " + ex);
                //Program._log.SendLogError(ex);
                return -1;
            }
        }


        /// <summary>
        /// Update OrderEditViewModel and OrderDetai. Save to database and reste CurrentOrderManager 
        /// </summary>
        public void FinishAndCloseOrder()
        {
            lock (this)
            {
                isDirty = true;

                //Lưu OrderEditViewModel & OrderDetailViewModel Status thành PosFinished
                //TODO: review this
                foreach (var detail in OrderEditViewModel.OrderDetailEditViewModels)
                {
                    if (detail.Status != (int)OrderDetailStatusEnum.PosCancel
                        && detail.Status != (int)OrderDetailStatusEnum.PosPreCancel)
                    {
                        if (MainForm.PosConfig.EnableKitchenMode != null && MainForm.PosConfig.EnableKitchenMode.Trim().ToLower() == "true")
                        {
                            detail.Status = (int)OrderDetailStatusEnum.Processing;
                        }
                        else
                        {
                            detail.Status = (int)OrderDetailStatusEnum.PosFinished;
                        }

                    }
                }

                if (MainForm.PosConfig.EnableKitchenMode != null && MainForm.PosConfig.EnableKitchenMode.Trim().ToLower() == "true")
                {
                    OrderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosProcessing;
                }
                else
                {
                    OrderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosFinished;
                }

                // thanh toan bang grabpay thi chuyen sang giao hang de khi in bill hien tam tinh
                if (OrderEditViewModel.PaymentEditViewModels.Any(a => a.Type == (int)PaymentTypeEnum.GrabPay || a.Type == (int)PaymentTypeEnum.GrabFood))

                {
                    //OrderEditViewModel.OrderType = (int)OrderTypeEnum.Delivery;
                }

                // Lưu deliveryStatus nếu là delivery
                if (OrderEditViewModel.OrderType == (int)OrderTypeEnum.Delivery)
                {
                    OrderEditViewModel.DeliveryStatus = (int)DeliveryStatusEnum.Finish;
                }

                


                #region Removed code
                //Xử lý dưới đây không cần thiết vì mỗi lần thanh toán đã tự động cập nhật return money !!!

                ////Tính toán phần tiền mặt trả lại cho khách => Giảm cash payment 
                ////OrderEditViewModel.FinalAmount += OrderEditViewModel.VATAmount;
                //var returnMoney = OrderEditViewModel.TotalPayment
                //                    - OrderEditViewModel.FinalAmount
                //                    - OrderEditViewModel.VATAmount;

                //////Tiền khách trả cho cửa hàng
                //if (returnMoney > 0)
                //{
                //    //Tiền trả lại cho khách
                //    UpdatePayment(PaymentTypeEnum.ExchangeCash, -returnMoney, null);
                //}
                //else
                //{
                //    //Không cần trả tiền lại cho khách => 0
                //    //Vì tiền trả lại luôn < 0
                //    //UpdatePayment(PaymentTypeEnum.ExchangeCash, 0, true, null);
                //}
                #endregion

                //Xóa thông tin thanh toán dư
                RemoveUnusePayment();

                OrderEditViewModel.TotalInvoicePrint++;
                SaveOrder();
            }
        }


        public void PreCancelOrder(OrderStatusEnum orderCancelType)
        {
            isDirty = true;

            //Lưu OrderEditViewModel & OrderDetailViewModel Status thành Status tương ứng
            OrderEditViewModel.OrderStatus = (int)orderCancelType;

            var cancelType = (int)OrderDetailStatusEnum.PosCancel;
            if (orderCancelType == OrderStatusEnum.PosPreCancel)
            {
                cancelType = (int)OrderDetailStatusEnum.PosPreCancel;
            }

            foreach (var detail in OrderEditViewModel.OrderDetailEditViewModels)
            {
                detail.SetAmountToZero();

                if (detail.Status == (int)OrderDetailStatusEnum.Finish
                    || detail.Status == (int)OrderDetailStatusEnum.PosFinished)
                {
                    detail.Status = (int)OrderDetailStatusEnum.PosCancel;
                }
                else
                {
                    detail.Status = cancelType;
                }
            }

            //Lưu deliveryStatus nếu là delivery
            if (OrderEditViewModel.OrderType == (int)OrderTypeEnum.Delivery)
            {
                OrderEditViewModel.DeliveryStatus = (int)DeliveryStatusEnum.PreCancel;
            }

            OrderEditViewModel.ResetPayment();
            RemoveUnusePayment();

            SaveOrder();
        }


        /// <summary>
        /// OrderEditViewModel chua duoc dong , chi thoat tam thoi 
        /// </summary>
        public void ReleaseAndSaveOrder()
        {
            isDirty = true;

            //Lưu OrderEditViewModel & OrderDetailViewModel Status thành PosFinished
            if (MainForm.PosConfig.EnableKitchenMode.Trim().ToLower() == "true")
            {
                if (isChange)
                {
                    OrderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosProcessing;
                    isChange = false;
                }

                foreach (var detail in OrderEditViewModel.OrderDetailEditViewModels)
                {
                    if (detail.Status == (int)OrderDetailStatusEnum.New)
                    {
                        detail.Status = (int)OrderDetailStatusEnum.Processing;
                    }
                }
            }
            else
            {
                foreach (var detail in OrderEditViewModel.OrderDetailEditViewModels)
                {
                    if (detail.Status == (int)OrderDetailStatusEnum.New)
                    {
                        detail.Status = (int)OrderDetailStatusEnum.PosFinished;
                    }
                }
            }

            RemoveAllAppliedPromotion();
            SaveOrder();
        }


        #endregion

        #endregion


        /// <summary>
        /// Remove barcode -> remove promotion apply nhờ barcode
        /// </summary>
        public void RemoveBarCode()
        {
            OrderEditViewModel.BarCode = "";
            OrderEditViewModel.PrefixBarCodes = new List<string>();

            foreach (var promotion in Program.context.getPromotions())
            {
                var applied = IsAppliedPromotion(promotion.PromotionCode);
                if (applied)
                {
                    var canApply = CheckPromotionConstrain(promotion);
                    if (!canApply)
                    {
                        RemoveAppliedPromotion(promotion);
                    }
                }
            }

            AfterAppliedPromotion();
        }


        #region Promotion

        /// <summary>
        /// Sau khi có thay đổi về promotion,
        ///  sẽ gọi function này để tính lại tiền cho order
        ///  và cập nhật các thứ liên quan (giao diện, v..v..)
        /// </summary>
        public void AfterAppliedPromotion()
        {
            isDirty = true;

            UpdateOrder(OrderChangeModeEnum.OrderDetailChange);
            UpdateOrder(OrderChangeModeEnum.PaymentChange);

            if (NotifyChangeOrderDetail != null)
            {
                foreach (var od in OrderEditViewModel.OrderDetailEditViewModels)
                {
                    NotifyChangeOrderDetail(od, OrderDetailChangeModeEnum.ModifiedOrderDetail);
                }
            }
        }


        /// <summary>
        /// Tính lại tiền order sau thay đổi promotion
        /// </summary>
        private void UpdateDiscountOrder()
        {
            //Reset
            OrderEditViewModel.Discount = 0;
            OrderEditViewModel.DiscountOrderDetail = 0;

            //Tính giảm giá ở orderdetail
            foreach (var orderDetail in OrderEditViewModel.OrderDetailEditViewModels)
            {
                UpdateDiscountOrderDetail(orderDetail);
                OrderEditViewModel.DiscountOrderDetail += (int)orderDetail.Discount;
            }

            //Sau giảm giá sản phẩm
            OrderEditViewModel.FinalAmount = OrderEditViewModel.TotalAmount - OrderEditViewModel.DiscountOrderDetail;

            //Giảm giá theo thứ tự
            foreach (var mapping in OrderEditViewModel
                .OrderPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex))
            {
                //Tìm thông tin promotion
                var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault(d => d.PromotionDetailCode == mapping.PromotionDetailCode);

                if (promotion != null && promotionDetail != null)
                {
                    if (promotion.GiftType == (int)PromotionGiftTypeEnum.Gift)
                    {
                        //DO NOTHING:
                        //Tặng quà thì quà là orderdetail
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountRate)
                    {
                        //Lấy amount theo percent
                        var discountAmount = (int)
                            (OrderEditViewModel.FinalAmount * promotionDetail.DiscountRate / 100);
                        //Giảm giá không âm tiền
                        if (discountAmount + OrderEditViewModel.Discount
                            + OrderEditViewModel.DiscountOrderDetail > OrderEditViewModel.TotalAmount)
                        {
                            discountAmount = (int)(OrderEditViewModel.TotalAmount
                                - OrderEditViewModel.DiscountOrderDetail - OrderEditViewModel.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;
                        mapping.DiscountRate = promotionDetail.DiscountRate;

                        //Update orderdetail
                        OrderEditViewModel.Discount += discountAmount;
                        OrderEditViewModel.FinalAmount = OrderEditViewModel.TotalAmount
                            - OrderEditViewModel.DiscountOrderDetail
                            - OrderEditViewModel.Discount;
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountAmount)
                    {
                        //Lấy amount theo promotion
                        var discountAmount = promotionDetail.DiscountAmount;
                        //Giảm giá không âm tiền
                        if ((double)discountAmount + OrderEditViewModel.Discount
                            + OrderEditViewModel.DiscountOrderDetail > OrderEditViewModel.TotalAmount)
                        {
                            discountAmount = (int)(OrderEditViewModel.TotalAmount
                                - OrderEditViewModel.DiscountOrderDetail - OrderEditViewModel.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;

                        //Update orderdetail
                        OrderEditViewModel.Discount +=(double) discountAmount.Value;
                        OrderEditViewModel.FinalAmount = OrderEditViewModel.TotalAmount
                            - OrderEditViewModel.DiscountOrderDetail
                            - OrderEditViewModel.Discount;
                    }
                }
            }
        }

        /// <summary>
        /// Tính lại tiền orderdetail sau thay đổi promotion
        /// </summary>
        private void UpdateDiscountOrderDetail(OrderDetailEditViewModel orderDetail)
        {
            //Reset
            orderDetail.Discount = 0;
            orderDetail.FinalAmount = orderDetail.TotalAmount;

            //Giảm giá theo thứ tự
            foreach (var mapping in orderDetail
                .OrderDetailPromotionMappingEditViewModels
                .OrderBy(m => m.MappingIndex))
            {
                //Tìm thông tin promotion
                var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault(d => d.PromotionDetailCode == mapping.PromotionDetailCode);

                if (promotion != null && promotionDetail != null)
                {
                    if (promotion.GiftType == (int)PromotionGiftTypeEnum.Gift)
                    {
                        if (mapping.DiscountAmount > 0)
                        {
                            orderDetail.Discount = orderDetail.TotalAmount;
                            orderDetail.FinalAmount = 0;
                        }
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountRate)
                    {
                        //Lấy amount theo percent
                        var discountAmount = (int)
                            (orderDetail.FinalAmount * promotionDetail.DiscountRate / 100);
                        //Giảm giá không âm tiền
                        if (discountAmount + orderDetail.Discount > orderDetail.TotalAmount)
                        {
                            discountAmount = (int)(orderDetail.TotalAmount - orderDetail.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;
                        mapping.DiscountRate = promotionDetail.DiscountRate;

                        //Update orderdetail
                        orderDetail.Discount += discountAmount;
                        orderDetail.FinalAmount = orderDetail.TotalAmount - orderDetail.Discount;
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountAmount)
                    {
                        //Lấy amount theo promotion
                        //var discountAmount = promotionDetail.DiscountAmount;
                        var discountAmount = promotionDetail.DiscountAmount * orderDetail.Quantity;

                        //Giảm giá không âm tiền
                        if ((double)discountAmount + orderDetail.Discount > orderDetail.TotalAmount)
                        {

                            discountAmount = (int)(orderDetail.TotalAmount - orderDetail.Discount);
                            //discountAmount = (int)(orderDetail.TotalAmount - (orderDetail.Discount * orderDetail.Quantity) );
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;

                        //Update orderdetail
                        orderDetail.Discount +=(double) discountAmount.Value;
                        orderDetail.FinalAmount = orderDetail.TotalAmount - orderDetail.Discount;
                    }
                }
            }
        }


        #region Get

        /// <summary>
        /// Lấy danh sách promotiondetail có thể áp dụng
        /// </summary>
        public List<PromotionDetailViewModel> GetAvailablePromotionDetails(PromotionEditViewModel promotion, OrderDetailEditViewModel orderDetail = null)
        {
            var rs = new List<PromotionDetailViewModel>();
            var canApply = CheckPromotionConstrain(promotion);
            if (canApply)
            {
                foreach (var promotionDetail in promotion.PromotionDetailViewModels)
                {
                    if (CheckPromotionDetailConstrain(promotionDetail, orderDetail))
                    {
                        rs.Add(promotionDetail);
                    }
                }
            }

            return rs;
        }

        /// <summary>
        /// Lấy danh sách mapping promotion-order
        ///  của tất cả promotion
        /// Nếu là mapping promotion-orderdetail,
        ///  sẽ trả về mapping promotion-order có OrderId = -1
        /// </summary>
        public List<OrderPromotionMappingEditViewModel> GetAppliedMappings()
        {
            var mappings = new List<OrderPromotionMappingEditViewModel>();

            foreach (var promotion in Program.context.getPromotions())
            {
                var mapping = GetAppliedMapping(promotion.PromotionCode);
                if (mapping != null)
                {
                    mappings.Add(mapping);
                }
            }

            var appliedMappings = new List<OrderPromotionMappingEditViewModel>();

            var orderDetailMappings = mappings.
                               Where(q => q.OrderId == -1).OrderBy(q => q.MappingIndex).ToList();

            if (orderDetailMappings != null)
            {
                appliedMappings.AddRange(orderDetailMappings);
            }

            var orderMappings = mappings.
                                Where(q => q.OrderId >= 0).OrderBy(q => q.MappingIndex).ToList();
            if (orderMappings != null)
            {
                appliedMappings.AddRange(orderMappings);
            }

            return appliedMappings;
        }

        /// <summary>
        /// Lấy danh sách mapping promotion-order
        ///  của 1 promotion
        /// Nếu là mapping promotion-orderdetail,
        ///  sẽ trả về mapping promotion-order có OrderId = -1
        /// </summary>
        public OrderPromotionMappingEditViewModel GetAppliedMapping(string promotionCode)
        {
            var mapping = new OrderPromotionMappingEditViewModel();
            var promotion = Program.context.getPromotions().FirstOrDefault(m => m.PromotionCode == promotionCode);
            if (promotion != null)
            {
                if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.Order)
                {
                    mapping = OrderEditViewModel.OrderPromotionMappingEditViewModels
                        .FirstOrDefault(m => m.PromotionCode == promotionCode);

                    return mapping;
                }
                else if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail)
                {
                    var applied = false;
                    mapping.OrderId = -1;
                    mapping.PromotionCode = promotion.PromotionCode;
                    mapping.DiscountAmount = 0;

                    foreach (var orderDetail in OrderEditViewModel.OrderDetailEditViewModels)
                    {
                        var mappingOrderDetail = orderDetail.OrderDetailPromotionMappingEditViewModels
                            .FirstOrDefault(m => m.PromotionCode == promotionCode);
                        if (mappingOrderDetail != null)
                        {
                            applied = true;
                            mapping.DiscountAmount += mappingOrderDetail.DiscountAmount;
                            //mapping.MappingIndex = mappingOrderDetail.MappingIndex;
                        }
                    }

                    if (applied)
                    {
                        return mapping;
                    }
                }
            }

            return null;
        }

        #endregion


        #region Check Promotion Constrain

        /// <summary>
        /// Kiểm tra promotion đã được áp dụng hay chưa 
        /// </summary>
        public bool IsAppliedPromotion(string promotionCode)
        {
            //Check Applied for Order
            var mappingOrder = OrderEditViewModel.OrderPromotionMappingEditViewModels
                .FirstOrDefault(m => m.PromotionCode == promotionCode);
            if (mappingOrder != null)
            {
                return true;
            }

            //Check Applied for OrderDetail
            foreach (var orderDetail in OrderEditViewModel.OrderDetailEditViewModels)
            {
                var mappingOrderDetail = orderDetail.OrderDetailPromotionMappingEditViewModels
                    .FirstOrDefault(m => m.PromotionCode == promotionCode);
                if (mappingOrderDetail != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Kiểm tra thỏa mãn các ràng buộc chung của promotion
        /// </summary>
        public bool CheckPromotionConstrain(PromotionEditViewModel promotion)
        {
            //Check DateTime constrain
            var canApply = promotion.IsAvailableDate(OrderEditViewModel.CheckInDate);

            //Check Applied for Order
            if (canApply)
            {
                var mapping = OrderEditViewModel.OrderPromotionMappingEditViewModels
                    .FirstOrDefault(m => m.PromotionCode == promotion.PromotionCode);
                if (mapping != null)
                {
                    canApply = false;
                }
            }

            //Check FinalAmount of Order
            if (canApply)
            {
                if (Program.context.getCurrentOrderManager().getOrderEditViewModel().FinalAmount <= 0)
                {
                    canApply = false;
                }
            }

            //Check PromotionDetail constrain
            if (canApply)
            {
                canApply = false;
                foreach (var promotionDetail in promotion.PromotionDetailViewModels)
                {
                    if (!canApply && CheckPromotionDetailConstrain(promotionDetail))
                    {
                        canApply = true;
                    }
                }
            }

            //Check if Promotion is apply for voucher
            //if (promotion.IsVoucher == true)
            //{
            //    canApply = true;
            //}

            return canApply;
        }

        /// <summary>
        /// Kiểm tra thỏa mãn ràng buộc của 1 promotion detail cụ thể
        /// </summary>
        public bool CheckPromotionDetailConstrain(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel orderDetail = null)
        {
            var canApply = false;

            // Check Regular Expression constrain:
            // Ko RegEx + Ko Barcode    -> true
            // Ko RegEx + Có Barcode    -> true
            // Có RegEx + Ko Barcode    -> false
            // Có RegEx + Có Barcode    -> check regex
            if (string.IsNullOrEmpty(promotionDetail.RegExCode))
            {
                canApply = true;
            }
            else if (!string.IsNullOrEmpty(OrderEditViewModel.BarCode))
            {
                if (OrderEditViewModel.PrefixBarCodes.Any())
                {
                    foreach (var code in OrderEditViewModel.PrefixBarCodes)
                    {
                        string apiCode = code + Program.context.getCurrentOrderManager().getOrderEditViewModel().BarCode;

                        canApply = Regex.IsMatch(apiCode, promotionDetail.RegExCode);

                        if (canApply) break;
                    }
                }
                else
                {
                    canApply = Regex.IsMatch(OrderEditViewModel.BarCode, promotionDetail.RegExCode);
                }
            }
            else
            {
                // false
            }


            // Check Order Amount constrain
            if (canApply)
            {
                if (promotionDetail.MinOrderAmount != null)
                {
                    if (promotionDetail.MaxOrderAmount == null)
                    {
                        if (OrderEditViewModel.FinalAmount < promotionDetail.MinOrderAmount)
                        {
                            canApply = false;
                        }
                    }
                    else if (promotionDetail.MaxOrderAmount != null)
                    {
                        if (OrderEditViewModel.FinalAmount < promotionDetail.MinOrderAmount
                            || promotionDetail.MaxOrderAmount < OrderEditViewModel.FinalAmount)
                        {
                            canApply = false;
                        }
                    }
                }
            }

            if (canApply)
            {
                canApply = false;
                if (orderDetail != null)
                {
                    //Check Applied for OrderDetail
                    var mapping = orderDetail.OrderDetailPromotionMappingEditViewModels.FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode);
                    if (mapping == null)
                    {
                        // Check Product constrain
                        if (string.IsNullOrEmpty(promotionDetail.BuyProductCode))
                        {
                            canApply = true;
                        }
                        else
                        {
                            if (orderDetail.ProductCode == promotionDetail.BuyProductCode)
                            {
                                canApply = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var od in OrderEditViewModel.OrderDetailEditViewModels)
                    {
                        //Check Applied for OrderDetail
                        var mapping = od.OrderDetailPromotionMappingEditViewModels.FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode);
                        if (mapping == null)
                        {
                            // Check Product constrain
                            if (string.IsNullOrEmpty(promotionDetail.BuyProductCode))
                            {
                                canApply = true;
                            }
                            else
                            {
                                if (od.ProductCode == promotionDetail.BuyProductCode)
                                {
                                    canApply = true;
                                }
                            }
                        }
                    }
                }
            }
            return canApply;
        }

        #endregion


        #region Apply/Remove Promotion

        /// <summary>
        /// Áp dụng promotion
        /// </summary>
        public bool ApplyPromotion(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel orderDetail = null)
        {
            var rs = false;
            var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == promotionDetail.PromotionCode);

            if (promotion != null)
            {
                if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.Order)
                {
                    rs = CreatePromotionMappingOrder(promotionDetail);
                }
                else if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail)
                {
                    if (orderDetail != null)
                    {
                        rs = CreatePromotionMappingOrderDetail(promotionDetail, orderDetail);
                    }
                    else
                    {
                        var tmpList = OrderEditViewModel.getOrderDetailEditViewModelsList();
                        foreach (var od in tmpList)
                        {
                            var checkExist = OrderEditViewModel.getOrderDetailEditViewModels().Where(o => o.OrderDetailID == od.OrderDetailID);
                            if (checkExist != null
                                && promotionDetail.BuyProductCode == od.ProductCode)
                            {
                                rs = CreatePromotionMappingOrderDetail(promotionDetail, od);
                            }
                        }
                    }
                }

            }
            return rs;
        }

        /// <summary>
        /// Xóa tất cả promotion
        /// </summary>
        public void RemoveAllAppliedPromotion()
        {
            foreach (var promotion in Program.context.getPromotions())
            {
                RemoveAppliedPromotion(promotion);
            }
            AfterAppliedPromotion();
        }

        /// <summary>
        /// Xóa 1 promotion
        /// </summary>
        public bool RemoveAppliedPromotion(PromotionEditViewModel promotion, OrderDetailEditViewModel orderDetail = null)
        {
            var rs = false;
            if (promotion != null)
            {
                foreach (var promotionDetail in promotion.PromotionDetailViewModels)
                {
                    if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.Order)
                    {
                        if (RemovePromotionMappingOrder(promotionDetail))
                        {
                            rs = true;
                        }
                    }
                    else if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail)
                    {
                        if (orderDetail != null)
                        {
                            if (RemovePromotionMappingOrderDetail(promotionDetail, orderDetail))
                            {
                                rs = true;
                            }
                        }
                        else
                        {
                            var tmpList = OrderEditViewModel.getOrderDetailEditViewModelsList();
                            foreach (var od in tmpList)
                            {
                                var checkExist = OrderEditViewModel.getOrderDetailEditViewModels().Where(o => o.OrderDetailID == od.OrderDetailID);
                                if (checkExist != null
                                    && RemovePromotionMappingOrderDetail(promotionDetail, od))
                                {
                                    rs = true;
                                }
                            }
                        }
                    }
                }
            }
            return rs;
        }

        /// <summary>
        /// Xóa 1 promotionDetail của promotion
        /// </summary>
        public bool RemoveAppliedPromotion(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel orderDetail = null)
        {
            var rs = false;
            var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == promotionDetail.PromotionCode);

            if (promotion != null)
            {
                if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.Order)
                {
                    if (RemovePromotionMappingOrder(promotionDetail))
                    {
                        rs = true;
                    }
                }
                else if (promotion.ApplyLevel == (int)PromotionApplyLevelEnum.OrderDetail)
                {
                    if (orderDetail != null)
                    {
                        if (RemovePromotionMappingOrderDetail(promotionDetail, orderDetail))
                        {
                            rs = true;
                        }
                    }
                    else
                    {
                        var tmpList = OrderEditViewModel.getOrderDetailEditViewModelsList();
                        foreach (var od in tmpList)
                        {
                            var checkExist = OrderEditViewModel.getOrderDetailEditViewModels().Where(o => o.OrderDetailID == od.OrderDetailID);
                            if (checkExist != null
                                && RemovePromotionMappingOrderDetail(promotionDetail, od))
                            {
                                rs = true;
                            }
                        }
                    }
                }
            }
            return rs;
        }

        #endregion


        #region Create/Remove Mapping

        /// <summary>
        /// Thêm mapping prmotion-order
        /// </summary>
        private bool CreatePromotionMappingOrder(PromotionDetailViewModel promotionDetail)
        {
            try
            {
                var mapping = new OrderPromotionMappingEditViewModel();
                mapping.Id = _currentMappingId;
                mapping.TmpMappingId = _currentMappingId++;
                mapping.PromotionCode = promotionDetail.PromotionCode;
                mapping.PromotionDetailCode = promotionDetail.PromotionDetailCode;
                mapping.OrderId = OrderEditViewModel.OrderId;

                var index = 1;
                if (OrderEditViewModel.OrderPromotionMappingEditViewModels == null)
                {
                    OrderEditViewModel.OrderPromotionMappingEditViewModels = new List<OrderPromotionMappingEditViewModel>();
                }
                if (OrderEditViewModel.OrderPromotionMappingEditViewModels.Any())
                {
                    var lastMapping = OrderEditViewModel.OrderPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex).Last();
                    index = lastMapping.MappingIndex + 1;
                }

                mapping.MappingIndex = index;
                mapping.DiscountRate = promotionDetail.DiscountRate;
                mapping.DiscountAmount = promotionDetail.DiscountAmount;

                OrderEditViewModel.OrderPromotionMappingEditViewModels.Add(mapping);

                if (promotionDetail.GiftProductCode != null)
                {
                    AddOrderDetailGift(promotionDetail, mapping, null);
                }

                return true;
            }
            catch (Exception ex)
            {
                //log.Error("CreatePromotionMappingOrder - " + ex);
                //Program._log.SendLogError(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm mapping prmotion-orderdetail
        /// </summary>
        private bool CreatePromotionMappingOrderDetail(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel orderdetail)
        {
            try
            {
                var mapping = new OrderDetailPromotionMappingEditViewModel();
                mapping.Id = _currentMappingId;
                mapping.TmpMappingId = _currentMappingId++;
                mapping.PromotionCode = promotionDetail.PromotionCode;
                mapping.PromotionDetailCode = promotionDetail.PromotionDetailCode;
                mapping.OrderDetailId = orderdetail.OrderDetailID;

                var index = 1;
                if (orderdetail.OrderDetailPromotionMappingEditViewModels == null)
                {
                    orderdetail.OrderDetailPromotionMappingEditViewModels = new List<OrderDetailPromotionMappingEditViewModel>();
                }
                if (orderdetail.OrderDetailPromotionMappingEditViewModels.Any())
                {
                    var lastMapping = orderdetail.OrderDetailPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex).Last();
                    index = lastMapping.MappingIndex + 1;
                }

                mapping.MappingIndex = index;
                mapping.DiscountRate = promotionDetail.DiscountRate;
                mapping.DiscountAmount = promotionDetail.DiscountAmount;

                orderdetail.OrderDetailPromotionMappingEditViewModels.Add(mapping);

                if (promotionDetail.GiftProductCode != null)
                {
                    AddOrderDetailGift(promotionDetail, null, mapping);
                }

                return true;
            }
            catch (Exception ex)
            {
                //log.Error("CreatePromotionMappingOrderDetail - " + ex);
                //Program._log.SendLogError(ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa mapping promotion-order
        /// </summary>
        private bool RemovePromotionMappingOrder(PromotionDetailViewModel promotionDetail)
        {
            try
            {
                var promotionMapping = OrderEditViewModel.OrderPromotionMappingEditViewModels
                    .FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode
                                        && m.PromotionDetailCode == promotionDetail.PromotionDetailCode);
                if (promotionMapping != null)
                {
                    var listOrderDetailToDetele = new List<OrderDetailEditViewModel>();
                    var listMappingToCheck = new List<OrderDetailPromotionMappingEditViewModel>();
                    foreach (var od in OrderEditViewModel.OrderDetailEditViewModels)
                    {
                        if (od.OrderPromotionMappingId == promotionMapping.Id)
                        {
                            listOrderDetailToDetele.Add(od);
                            if (od.OrderDetailPromotionMappingEditViewModels != null
                                && od.OrderDetailPromotionMappingEditViewModels.Any())
                            {
                                listMappingToCheck.AddRange(od.OrderDetailPromotionMappingEditViewModels);
                            }
                        }
                    }
                    if (listMappingToCheck.Any())
                    {
                        foreach (var mapping in listMappingToCheck)
                        {
                            var listOds = OrderEditViewModel.getOrderDetailEditViewModels().Where(od => od.OrderDetailPromotionMappingId == mapping.Id);
                            foreach (var item in listOds)
                            {
                                if (!listOrderDetailToDetele.Contains(item))
                                {
                                    listOrderDetailToDetele.Add(item);
                                }
                            }
                        }
                    }
                    if (listOrderDetailToDetele.Any())
                    {
                        foreach (var od in listOrderDetailToDetele)
                        {
                            RemoveOrderDetail(od);
                        }
                    }
                    OrderEditViewModel.OrderPromotionMappingEditViewModels.Remove(promotionMapping);
                }
                return true;
            }
            catch (Exception ex)
            {
                //log.Error("RemovePromotionMappingOrder - " + ex);
                //Program._log.SendLogError(ex);
                return false;
            }
        }

        /// <summary>
        /// Xóa mapping promotion-orderdetail
        /// </summary>
        private bool RemovePromotionMappingOrderDetail(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel tmpOd)
        {
            try
            {
                var orderdetail = OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == tmpOd.OrderDetailID);
                var promotionMapping = orderdetail.OrderDetailPromotionMappingEditViewModels
                    .FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode
                                        && m.PromotionDetailCode == promotionDetail.PromotionDetailCode);
                if (promotionMapping != null)
                {
                    var listOrderDetailToDetele = new List<OrderDetailEditViewModel>();
                    var listMappingToCheck = new List<OrderDetailPromotionMappingEditViewModel>();
                    foreach (var od in OrderEditViewModel.OrderDetailEditViewModels)
                    {
                        if (od.OrderDetailPromotionMappingId == promotionMapping.Id)
                        {
                            listOrderDetailToDetele.Add(od);
                            if (od.OrderDetailPromotionMappingEditViewModels != null
                                && od.OrderDetailPromotionMappingEditViewModels.Any())
                            {
                                listMappingToCheck.AddRange(od.OrderDetailPromotionMappingEditViewModels);
                            }
                        }
                    }
                    if (listMappingToCheck.Any())
                    {
                        foreach (var mapping in listMappingToCheck)
                        {
                            var listOds = OrderEditViewModel.getOrderDetailEditViewModels().Where(od => od.OrderDetailPromotionMappingId == mapping.Id);
                            foreach (var item in listOds)
                            {
                                if (!listOrderDetailToDetele.Contains(item))
                                {
                                    listOrderDetailToDetele.Add(item);
                                }
                            }
                        }
                    }
                    if (listOrderDetailToDetele.Any())
                    {
                        foreach (var od in listOrderDetailToDetele)
                        {
                            RemoveOrderDetail(od);
                        }
                    }
                    orderdetail.OrderDetailPromotionMappingEditViewModels.Remove(promotionMapping);
                }
                return true;
            }
            catch (Exception ex)
            {
                //log.Error("RemovePromotionMappingOrderDetail - " + ex);
                //Program._log.SendLogError(ex);
                return false;
            }
        }

        #endregion


        /// <summary>
        /// Thêm quà tặng vào hóa đơn
        /// </summary>
        private void AddOrderDetailGift(PromotionDetailViewModel promotionDetail,
                        OrderPromotionMappingEditViewModel orderPromotionMapping,
                        OrderDetailPromotionMappingEditViewModel orderDetailPromotionDetailMapping)
        {
            try
            {
                isDirty = true;
                var giftCode = promotionDetail.GiftProductCode;
                var giftQuantity = (int)promotionDetail.GiftQuantity;
                var productViewModel = Program.context.getAllProducts().FirstOrDefault(p => p.Code == giftCode);

                if (productViewModel != null)
                {
                    //Add gift
                    ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, productViewModel, null, giftQuantity);

                    var orderDetail = OrderEditViewModel.OrderDetailEditViewModels.LastOrDefault(p => p.ProductCode == giftCode);

                    //Add mapping for gift
                    var mapping = new OrderDetailPromotionMappingEditViewModel();
                    mapping.Id = _currentMappingId;
                    mapping.TmpMappingId = _currentMappingId++;
                    mapping.PromotionCode = promotionDetail.PromotionCode;
                    mapping.PromotionDetailCode = promotionDetail.PromotionDetailCode;
                    mapping.OrderDetailId = orderDetail.OrderDetailID;

                    var index = 1;

                    if (orderDetail.OrderDetailPromotionMappingEditViewModels == null)
                    {
                        orderDetail.OrderDetailPromotionMappingEditViewModels = new List<OrderDetailPromotionMappingEditViewModel>();
                    }
                    if (orderDetail.OrderDetailPromotionMappingEditViewModels.Any())
                    {
                        var lastMapping = orderDetail.OrderDetailPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex).Last();
                        index = lastMapping.MappingIndex + 1;
                    }

                    mapping.MappingIndex = index;
                    mapping.DiscountAmount = (int)orderDetail.TotalAmount;

                    orderDetail.OrderDetailPromotionMappingEditViewModels.Add(mapping);

                    //update gift 
                    orderDetail.Discount = orderDetail.TotalAmount;
                    orderDetail.FinalAmount = 0;

                    if (orderPromotionMapping != null)
                    {
                        orderDetail.OrderPromotionMappingId = orderPromotionMapping.Id;
                    }
                    else if (orderDetailPromotionDetailMapping != null)
                    {
                        orderDetail.OrderDetailPromotionMappingId = orderDetailPromotionDetailMapping.Id;
                    }

                    //notify update
                    CallNotifyOrderDetail(orderDetail, OrderDetailChangeModeEnum.ModifiedOrderDetail);
                    //AfterAppliedPromotion();
                }
            }
            catch (Exception ex)
            {
                //log.Error("AddOrderDetailGift - " + ex);
                //Program._log.SendLogError(ex);
            }
        }


        #endregion
    }
}