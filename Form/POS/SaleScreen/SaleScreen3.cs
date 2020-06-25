using System;
using System.Linq;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using POS.Common;
using POS.PrintManager;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using log4net;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.Utils;
using POS.Repository.Entities;
using AutoMapper;
using System.Web.Script.Serialization;

namespace POS.SaleScreen
{
    public partial class SaleScreen3 : UserControl
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private static SerialPort mySerialPort = Program.context.getSerialPort();
        public static OrderDetailForm _orderDetailForm;
        public static OrderPropertyForm2 _orderPropertyForm;
        public static TableViewModel _table;
        public static Printer PosPrinter;
        public static TableChangeForm FrmTableChange { get; set; }
        

        public SaleScreen3()
        {
           
            Program.context.LoadProductsAndCategories();
            Program.context.LoadPromotions();
            PosPrinter = new Printer();

            InitializeComponent();

            btnAtStoreMode.ActiveBackgroudColor = Color.Black;
            btnDeliveryMode.ActiveBackgroudColor = Color.Black;
            btnTakeAwayMode.ActiveBackgroudColor = Color.Black;

            pnlCategory = new CategoryPanel1();
            // 
            // pnlCategory
            // 
            this.pnlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategory.BackColor = System.Drawing.Color.Transparent;
            this.pnlCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCategory.Location = new System.Drawing.Point(2, 62);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(682, 445);
            this.pnlCategory.TabIndex = 2;
            this.Controls.Add(this.pnlCategory);

            //this.ptbLogo.ImageLocation = "./Resources/" + MainForm.StoreInfo.LogoSimple;
            //this.ptbLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            MainForm.SetLogo( this.ptbLogo, "./Resources/" + MainForm.StoreInfo.LogoSimple);
            if (MainForm.PosConfig.SaveTableStatus.Trim().ToLower() == "true")
            {
                btnCancelOrder.Show();
            }

            if (MainForm.PosConfig.EnableChangeOrderType.Trim().ToLower() == "true")
            {
                btnAtStoreMode.Show();
                btnDeliveryMode.Show();
                btnTakeAwayMode.Show();
            }
            
            if (MainForm.PosConfig.EnableScanBarcodeForProdcut != null && MainForm.PosConfig.EnableScanBarcodeForProdcut.Trim().ToLower() == "true")
            {
                btnScanBarcode.Visible = true;
            } else
            {
                btnScanBarcode.Visible = false;
            }

            //Add event to currentOrderManager
            Program.context.addNotifyChangeOrderDetail(pnlOrder.UpdateWhenOrderDetailChange);
            Program.context.addNotifyChangeOrderDetail(pnlCategory.UpdateWhenOrderDetailChange);

            this.btnCancelOrder.TextValue = MainForm.ResManager.GetString("SaleScreen3_Cancel_Bill", MainForm.CultureInfo);
            this.btnChangeTable.TextValue = MainForm.ResManager.GetString("SaleScreen3_Change_Table", MainForm.CultureInfo);
            this.btnSplitOrderDetail.TextValue = MainForm.ResManager.GetString("SaleScreen3_Split_Order", MainForm.CultureInfo);
            this.btnAtStoreMode.TextValue = MainForm.ResManager.GetString("Sys_At_Store", MainForm.CultureInfo);
            this.btnTakeAwayMode.TextValue = MainForm.ResManager.GetString("Sys_Take_Away", MainForm.CultureInfo);
            this.btnDeliveryMode.TextValue = MainForm.ResManager.GetString("Sys_Delivery", MainForm.CultureInfo);
        }

        public void InitOrderBoard(OrderEditViewModel order, TableViewModel table, bool isNewOrder)
        {
            try
            {
                if (MainForm.PosConfig.IsUsingScale.ToLower().Equals("true"))
                {
                    InitiateSerialPort();
                }

                _table = table;

                currentOrderManager.setOrderEditViewModel(order);

                if (currentOrderManager.getOrderEditViewModel().OrderType == (int)OrderTypeEnum.TakeAway)
                {
                    DeactiveAllOrderTypeControls();
                    btnTakeAwayMode.IsActive = true;
                }
                else if (currentOrderManager.getOrderEditViewModel().OrderType == (int)OrderTypeEnum.AtStore)
                {
                    DeactiveAllOrderTypeControls();
                    btnAtStoreMode.IsActive = true;
                }
                else if (currentOrderManager.getOrderEditViewModel().OrderType == (int)OrderTypeEnum.Delivery)
                {
                    DeactiveAllOrderTypeControls();
                    btnDeliveryMode.IsActive = true;
                }

                OrderTypeEnum type = (OrderTypeEnum)order.OrderType;

                if (type == OrderTypeEnum.Delivery)
                {
                    pnlOrder.TableNo = _table.Number;
                }
                else if (type == OrderTypeEnum.DropProduct)
                {
                    pnlOrder.TableNo = _table.Number;
                }
                else
                {
                    //At store and take away => have tableNumber
                    pnlOrder.TableNo = _table.Number;
                }

                //Chỉ hiện chức năng tách bàn / tách món khi OrderEditViewModel At Store 
                if (MainForm.PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                    && type == OrderTypeEnum.AtStore)
                {
                    btnChangeTable.Show();
                    btnSplitOrderDetail.Show();
                }
                else
                {
                    btnChangeTable.Hide();
                    btnSplitOrderDetail.Hide();
                }

                pnlCategory.UpdateFromOrder();
                pnlOrder.DisplayOrder();

                if (_orderPropertyForm == null || _orderPropertyForm.IsDisposed)
                {
                    _orderPropertyForm = new OrderPropertyForm2();
                    _orderPropertyForm.TopLevel = false;
                    this.Controls.Add(_orderPropertyForm);
                }
                else
                {
                    _orderPropertyForm.ReGenerateLayout();
                }
            }
            catch (Exception ex)
            {
                log.Error("InitOrderBoard - " + ex);
            }
        }


        // Cannot add general product
        public static bool AddOrderDetailWithProduct(ProductViewModel product)
        {
            if (product.GeneralProductId == null)
            {
                currentOrderManager.ChangeItemQuantityOfOrderDetail(
                    OrderDetailChangeModeEnum.AddOrderDetail, product, null, 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateStaffInfo(string staffName)
        {
            btnStaffInfo.TextValue = staffName;
        }

        public static void ChangeTableStatus(TableStatusEnum tableStatus, bool isTempOrder = false)
        {
            try
            {
                var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                var orderEditVM = currentOrderManager.getOrderEditViewModel();
                var tableId = orderEditVM.TableId;
                TableViewModel tableViewModel =
                    ServiceManager.GetTableViewModel(
                        tableService.FirstOrDefault(t => t.Id == tableId));

                if (isTempOrder)
                {
                    tableViewModel =
                        ServiceManager.GetTableViewModel(
                            tableService.FirstOrDefault(t => t.Id == currentOrderManager.getTmpOrderEditViewModel().TableId));
                }

                if (tableViewModel != null)
                {
                    if (tableViewModel.Status != (int)tableStatus)
                    {
                        tableViewModel.Status = (int)tableStatus;
                        if (tableStatus == (int)TableStatusEnum.Ready)
                        {
                            tableViewModel.CurrentOrderId = -1;
                            tableViewModel.CurrentOrderDate = null;
                        }
                        else
                        {
                            if (isTempOrder)
                            {
                                tableViewModel.CurrentOrderId = currentOrderManager.getTmpOrderEditViewModel().OrderId;
                                tableViewModel.CurrentOrderDate = currentOrderManager.getTmpOrderEditViewModel().CheckInDate;
                            }
                            else
                            {
                                tableViewModel.CurrentOrderId = currentOrderManager.getOrderEditViewModel().OrderId;
                                tableViewModel.CurrentOrderDate = currentOrderManager.getOrderEditViewModel().CheckInDate;
                            }
                        }

                        tableService.UpdateTableStatus(tableViewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("ChangeTableStatus - " + ex);
            }
        }


        private static void PrintBills(OrderEditViewModel order)
        {
            if (!string.IsNullOrEmpty(MainForm.StoreInfo.PrintBillOrder))
            {
                var bills = MainForm.StoreInfo.PrintBillOrder.Split('|');
                foreach (var bill in bills)
                {
                    var printerName = MainForm.StoreInfo.PrinterBill;
                    var type = BillTypeEnum.Customer;
                    if (bill.Contains("cook") )
                    {
                        printerName = MainForm.StoreInfo.PrinterCook1;
                        type = BillTypeEnum.Cook;
                        PosPrinter.PrintBill(order, type, printerName, true);
                        if(MainForm.PosConfig.SaveTableStatus.ToLower() != "true")
                        {
                            var tmpOrders = order.OrderDetailEditViewModels;
                            if (MainForm.StoreInfo.PrinterDetail.ToLower() == "true")
                            {
                                printerName = MainForm.StoreInfo.PrinterLabel;
                                type = BillTypeEnum.Extra;
                                if (order.PaymentEditViewModels.Any(pev => pev.Type == (int)PaymentTypeEnum.MoMo))
                                {
                                    PosPrinter.PrintBillMomo(order, type, printerName, true);
                                }
                                else
                                {
                                    PosPrinter.PrintBill(order, type, printerName, true);
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (order.PaymentEditViewModels.Any(pev => pev.Type == (int)PaymentTypeEnum.MoMo))
                        {
                            PosPrinter.PrintBillMomo(order, type, printerName, true);
                        }
                        else
                        {
                            PosPrinter.PrintBill(order, type, printerName, true);
                        }
                    }
                    
                }
            }
        }



        public static void ShowOrderDetailForm(List<OrderDetailEditViewModel> orderDetails)
        {
            if (_orderDetailForm != null)
            {
                _orderDetailForm.Close();
            }

            var mainOrderDetail = orderDetails.FirstOrDefault(od => od.ParentId == null);

            _orderDetailForm = new OrderDetailForm(mainOrderDetail);
            _orderDetailForm.Show();
        }

        public static void UpdateOrderDetailForm()
        {
            if (_orderDetailForm != null && _orderDetailForm.Visible)
            {
                _orderDetailForm.UpdateOrderDetailForm();
            }
        }


        #region Change table

        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            if (FrmTableChange == null)
            {
                FrmTableChange = new TableChangeForm();
            }
            else
            {
                FrmTableChange.ResetTableChangeForm();
            }


            FrmTableChange.FastChangeTableShow();
        }

        private void btnSplitOrderDetail_Click(object sender, EventArgs e)
        {
            if (FrmTableChange == null)
            {
                FrmTableChange = new TableChangeForm();
            }
            else
            {
                FrmTableChange.ResetTableChangeForm();
            }

            FrmTableChange.SplitOrderDetailShow();
        }

        #endregion

        #region OrderPropertyForm
        public static void ShowOrderPropertyForm()
        {
            if (_orderPropertyForm == null || _orderPropertyForm.IsDisposed)
            {
                _orderPropertyForm = new OrderPropertyForm2();
            }
            else
            {
                _orderPropertyForm.UpdateMoneyInfo();
            }


            _orderPropertyForm.BringToFront();

            _orderPropertyForm.LoadPanel();

            _orderPropertyForm.ShowForm();
            _orderPropertyForm.Focus();
        }


        public static void ExitOrCancelOrder(bool isSaveTableStatus)
        {
            try
            {
                //Close Form
                if (_orderPropertyForm != null)
                {
                    _orderPropertyForm.HideForm();
                    _orderPropertyForm.isDirty = true;
                    _orderPropertyForm.RefreshAllPanel();
                }

                int totalProduct = currentOrderManager.GetTotalProduct();

                if (totalProduct > 0)
                {
                    if (!isSaveTableStatus)
                    {
                        //Take away => CANCEL
                        //Confirm CANCEL

                        var isContinue = true;

                        if (MainForm.PosConfig.RequiredPasswordCancel.Trim().ToLower() == "true")
                        {
                            isContinue = MainForm.CheckRole(true);
                        }

                        var type = OrderStatusEnum.PosPreCancel;
                        bool? cancelTypeSelect = null;

                        if (isContinue)
                        {
                            if (MainForm.PosConfig.EnableKitchenMode.Trim().ToLower() == "true")
                            {
                                //Có bếp: precancel <> cancel    
                                cancelTypeSelect = PosMessageDialog.
                                    YesNoCancelDialog("Xin chọn loại Hủy:",
                                        "Trước chế biến", "Sau chế biến", "Không Hủy");

                                if (cancelTypeSelect != null)
                                {
                                    if (!(bool)cancelTypeSelect)
                                    {
                                        type = OrderStatusEnum.PosCancel;
                                    }
                                }
                                else
                                {
                                    isContinue = false;
                                }
                            }
                            else
                            {
                                //Không bếp
                                var rs = PosMessageDialog.
                                    ConfirmMessage("Hủy hóa đơn?", "Hủy", "Không hủy");
                                if (!rs)
                                {
                                    isContinue = false;
                                }
                            }
                        }

                        if (isContinue)
                        {
                            //CANCEL
                            //Lúc này đơn hàng chưa được tạo -> tạo đơn hàng trạng thái PreCancel
                            currentOrderManager.PreCancelOrder(type);
                            ChangeTableStatus(TableStatusEnum.Ready);
                            currentOrderManager.ResetOrderInfo();
                            //Program.MainForm.UpdateTableScreen(currentOrderManager.OrderEditViewModel.TableId.GetValueOrDefault());
                            Program.MainForm.LoadFirstScreen();
                        }
                        else
                        {
                            //Do nothing: không thoát
                        }
                    }
                    else
                    {
                        //Restaurant => SAVE
                        //Kiem tra hoa don chua luu thi luu xuong database
                        if (MainForm.StoreInfo.IsPrintBillCookWhenSaveTable.Trim().ToLower() == "true")
                        {
                            if (currentOrderManager.GetNumOfNewOrderDetail() > 0)
                            {
                                //Mode nhà hàng - Chỉ in món mới được order
                                //PosPrinter.PrintBill(currentOrderManager.getOrderEditViewModel(),
                                //    BillTypeEnum.Cook, MainForm.StoreInfo.PrinterCook1, false);

                                //foreach(var printGroup in currentOrderManager.getOrderEditViewModel().pri)
                                //foreach(var printGroup in currentOrderManager.OrderEditViewModel.OrderDetailEditViewModels.Select(s=>s.PrintGroup).Distinct())
                                //{
                                //    switch(printGroup)
                                //    {
                                //        case (int)PrintGroupEnum.Printer1:
                                //            PrintCookBillWithDetail( (int) PrintGroupEnum.Printer1, MainForm.StoreInfo.PrinterCook1);
                                //           break;

                                //        case (int)PrintGroupEnum.Printer2:
                                //            PrintCookBillWithDetail((int)PrintGroupEnum.Printer2, MainForm.StoreInfo.PrinterCook2);
                                //            break;

                                //        case (int)PrintGroupEnum.Printer3:
                                //            PrintCookBillWithDetail((int)PrintGroupEnum.Printer3, MainForm.StoreInfo.PrinterCook3);
                                //            break;
                                //    }
                                //}
                                PosPrinter.PrintBill(currentOrderManager.getOrderEditViewModel(),
                                    BillTypeEnum.Cook, MainForm.StoreInfo.PrinterCook1, MainForm.StoreInfo.PrinterDetail.Trim().ToLower() == "true");
                                //print bill detail
                                //if(MainForm.StoreInfo.PrinterDetail.Trim().ToLower() == "true")
                                //{
                                //    foreach (var orderDetail in currentOrderManager.getOrderEditViewModel().OrderDetailEditViewModels.Where(w=>w.Status== (int)OrderDetailStatusEnum.New))

                                //        PosPrinter.PrintBillDetail(currentOrderManager.getOrderEditViewModel(), orderDetail, MainForm.StoreInfo.PrinterCook2);
                                //}
                            }
                        }
                        // else use Kitchen screen to view

                        //OrderEditViewModel mới và chưa được lưu vào database
                         currentOrderManager.ReleaseAndSaveOrder();
                        ChangeTableStatus(TableStatusEnum.InUse);
                        currentOrderManager.ResetOrderInfo();
                        Program.MainForm.LoadFirstScreen();
                    }
                }
                else
                {
                    if (currentOrderManager.getOrderEditViewModel().HasOrderId)
                    {
                        currentOrderManager.PreCancelOrder(OrderStatusEnum.PosPreCancel);
                    }

                    ChangeTableStatus(TableStatusEnum.Ready);
                    currentOrderManager.ResetOrderInfo();
                    Program.MainForm.LoadFirstScreen();
                }

                if (_orderDetailForm != null)
                {
                    _orderDetailForm.Hide();
                }
            }
            catch (Exception ex)
            {
                log.Error("ExitOrCancelOrder - " + ex);
            }
        }

        //private static void PrintCookBillWithDetail(int printGroup,string printerName)
        //{
        //    PosPrinter.PrintBill(currentOrderManager.getOrderEditViewModel(),
        //                            BillTypeEnum.Cook, printerName, MainForm.StoreInfo.PrinterDetail.Trim().ToLower() == "true", printGroup);
        //    //print bill detail
        //    if (MainForm.StoreInfo.PrinterDetail.Trim().ToLower() == "true")
        //    {
        //        foreach (var orderDetail in currentOrderManager.getOrderEditViewModel().OrderDetailEditViewModels.Where(w => w.Status == (int)OrderDetailStatusEnum.New && w.PrintGroup==printGroup))
        //        {
        //            PosPrinter.PrintBillDetail(currentOrderManager.getOrderEditViewModel(), orderDetail, MainForm.StoreInfo.PrinterCook2);
        //            // ngu 1 giay de may in kip in
        //            Thread.Sleep(1000);
        //        }
                    
        //    }
        //}
        public static void FinishAndCloseOrder()
        {
            try
            {
                //Barcode
                var input = currentOrderManager.getOrderEditViewModel().BarCode;

                if (!string.IsNullOrEmpty(input))
                {
                    foreach (var mapping in currentOrderManager.getOrderEditViewModel().OrderPromotionMappingEditViewModels)
                    {
                        var promotionDetail = Program.context.getPromotionDetails().FirstOrDefault
                            (d => d.PromotionCode == mapping.PromotionCode
                            && d.PromotionDetailCode == mapping.PromotionDetailCode);
                        if (promotionDetail != null)
                        {
                            if (!string.IsNullOrEmpty(promotionDetail.RegExCode))
                            {
                                var canApply = false;
                                if (currentOrderManager.getOrderEditViewModel().PrefixBarCodes.Any())
                                {
                                    foreach (var code in currentOrderManager.getOrderEditViewModel().PrefixBarCodes)
                                    {
                                        var apiCode = code + input;
                                        canApply = Regex.IsMatch(apiCode, promotionDetail.RegExCode);
                                        if (canApply) break;
                                    }
                                }
                                else
                                {
                                    canApply = Regex.IsMatch(input, promotionDetail.RegExCode);
                                }

                                if (canApply)
                                {
                                    currentOrderManager.getOrderEditViewModel().Att1 =
                                        promotionDetail.PromotionCode + ":" +
                                        currentOrderManager.getOrderEditViewModel().BarCode;
                                    break;
                                }
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(currentOrderManager.getOrderEditViewModel().Att1))
                    {
                        var regexcode = "";
                        foreach (var od in currentOrderManager.getOrderEditViewModel().OrderDetailEditViewModels)
                        {
                            foreach (var mapping in od.OrderDetailPromotionMappingEditViewModels)
                            {
                                var promotionDetail = Program.context.getPromotionDetails().FirstOrDefault
                                    (d => d.PromotionCode == mapping.PromotionCode
                                    && d.PromotionDetailCode == mapping.PromotionDetailCode);
                                if (promotionDetail != null)
                                {
                                    if (!string.IsNullOrEmpty(promotionDetail.RegExCode))
                                    {
                                        var canApply = false;
                                        if (currentOrderManager.getOrderEditViewModel().PrefixBarCodes.Any())
                                        {
                                            foreach (var code in currentOrderManager.getOrderEditViewModel().PrefixBarCodes)
                                            {
                                                var apiCode = code + input;
                                                canApply = Regex.IsMatch(apiCode, promotionDetail.RegExCode);
                                                if (canApply) break;
                                            }
                                        }
                                        else
                                        {
                                            canApply = Regex.IsMatch(input, promotionDetail.RegExCode);
                                        }

                                        if (canApply)
                                        {
                                            if (regexcode == "")
                                            {
                                                regexcode = promotionDetail.PromotionCode;
                                            }
                                        }
                                    }
                                }
                            }

                            if (regexcode != "")
                            {
                                currentOrderManager.getOrderEditViewModel().Att1 =
                                    regexcode + ":" + currentOrderManager.getOrderEditViewModel().BarCode;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(currentOrderManager.getOrderEditViewModel().Att1))
                    {
                        currentOrderManager.getOrderEditViewModel().Att1 = " :" + input;
                    }
                }

                //Save OrderEditViewModel
                var result = true;
                if (MainForm.StoreInfo.SkyConnectEnable.ToString().Trim() == "true" && MainForm.StoreInfo.SkyConnectForCustomer.ToString().Trim() == "true")
                {
                    result = SkyConnectComfirmPayment();
                }
                if (result)
                {
                    currentOrderManager.FinishAndCloseOrder();



                    Program.MainForm.HideSplashForm();

                   
                  
                    if(MainForm.StoreInfo.EnableRedis != "true")
                    {
                        //Print Bill version cũ không dùng redis
                        PrintBills(currentOrderManager.OrderEditViewModel);
                    }
                    else
                    {  
                        POS.Repository.StoreInfoManager.SetResourceManager(POS.MainForm.ResManager);
                        POS.Repository.StoreInfoManager.SetCultureInfo(POS.MainForm.CultureInfo);

                        #region Mapping OrderEditViewModel ==> Repository.PrinterModel.OrderPrinterModel

                        //Nên để cấu hình Mapper ở một chỗ nào đó
                        MapperConfiguration mapperConfig = new MapperConfiguration(cfg =>
                        {
                            cfg.CreateMap<Repository.ViewModels.OrderEditViewModel, Repository.PrinterModel.OrderPrinterModel>()
                                .ForMember(dest => dest.OrderDetailPrinterModels, opt => opt.Ignore())
                                .ForMember(dest => dest.OrderPromotionMappingPrinterModels, opt => opt.Ignore())
                                .ForMember(dest => dest.PaymentPrinterModels, opt => opt.Ignore())
                                .ForMember(dest => dest.AppliedPromotions, opt => opt.Ignore())
                                .ForMember(dest => dest.GuestPayment, opt => opt.Ignore());

                            cfg.CreateMap<Repository.ViewModels.OrderDetailEditViewModel, Repository.PrinterModel.OrderDetailPrinterModel>()
                                .ForMember(dest => dest.IsExtraProduct, opt => opt.MapFrom(src => src.IsExtra));

                            cfg.CreateMap<Repository.ViewModels.PaymentEditViewModel, Repository.PrinterModel.PaymentPrinterModel>();

                            cfg.CreateMap<Repository.ViewModels.PromotionEditViewModel, Repository.PrinterModel.PromotionPrinterModel>();
                        });

                        POS.Repository.PrinterModel.OrderPrinterModel orderPrinterModel = mapperConfig.CreateMapper()
                            .Map<POS.Repository.PrinterModel.OrderPrinterModel>(currentOrderManager.OrderEditViewModel);

                        orderPrinterModel.OrderDetailPrinterModels = mapperConfig.CreateMapper().Map<List<OrderDetailEditViewModel>, 
                            List<Repository.PrinterModel.OrderDetailPrinterModel>>(currentOrderManager.OrderEditViewModel.OrderDetailEditViewModels);

                        orderPrinterModel.PaymentPrinterModels = mapperConfig.CreateMapper().Map<List<Repository.ViewModels.PaymentEditViewModel>,
                            List<Repository.PrinterModel.PaymentPrinterModel>>(currentOrderManager.OrderEditViewModel.PaymentEditViewModels);

                        var appliedPromotions = new List<PromotionEditViewModel>();
                        foreach (var mapping in currentOrderManager.OrderEditViewModel.OrderPromotionMappingEditViewModels)
                        {
                            var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                            if (applied == null)
                            {
                                var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                                if (promotion != null)
                                {
                                    if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                                    {
                                        appliedPromotions.Add(promotion);
                                    }
                                }
                            }
                        }
                        foreach (var od in currentOrderManager.OrderEditViewModel.OrderDetailEditViewModels)
                        {
                            foreach (var mapping in od.OrderDetailPromotionMappingEditViewModels)
                            {
                                var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                                if (applied == null)
                                {
                                    var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                                    if (promotion != null)
                                    {
                                        if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                                        {
                                            appliedPromotions.Add(promotion);
                                        }
                                    }
                                }
                            }
                        }
                        orderPrinterModel.AppliedPromotions = mapperConfig.CreateMapper().Map<List<Repository.PrinterModel.PromotionPrinterModel>>(appliedPromotions);
                        #endregion

                        string orderPrinterModelJson = Newtonsoft.Json.JsonConvert.SerializeObject(orderPrinterModel);
                        string channel = Repository.PrinterHelper.RadisConnectorHelper.ReceiptChannel;
                        
                        bool isLeftPushSuccessful = POS.Repository.PrinterHelper.RadisConnectorHelper.ListLeftPush(channel, orderPrinterModelJson);
                        if (isLeftPushSuccessful)
                        {
                            bool isPublishSuccessful = POS.Repository.PrinterHelper.RadisConnectorHelper.Publish(channel, "print pls");
                            if (!isPublishSuccessful)
                            {
                                throw new Exception($"Cannot publish message to {channel} Redis");
                            }
                        }
                        else
                        {
                            throw new Exception($"Cannot left push message to {channel} in Redis");
                        }

                    }

                    ChangeTableStatus(TableStatusEnum.Ready);
                    currentOrderManager.ResetOrderInfo();

                    if (_orderPropertyForm != null)
                    {
                        _orderPropertyForm.HideForm();
                        _orderPropertyForm.isDirty = true;
                        _orderPropertyForm.RefreshAllPanel();
                    }

                    if (_orderDetailForm != null)
                    {
                        _orderDetailForm.Hide();
                    }
                    Program.MainForm.LoadFirstScreen();
                }
            }
            catch (Exception ex)
            {
                Program.MainForm.HideSplashForm();
                log.Error("FinishAndCloseOrder - " + ex);
            }
        }

        private static Boolean SkyConnectComfirmPayment()
        {

            var currentOrder = currentOrderManager.getOrderEditViewModel();
            var currentCustomer = currentOrderManager.getCurrentCustomerModel();
            if (currentCustomer != null)
            {
                var creditAccount = currentCustomer.Accounts
                    .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                Boolean isIncreaseTransation = false;
                var transactionType = (int)SkyConnectTransactionTypeEnum.MemberPayment;
                if (currentOrder.OrderType == (int)OrderTypeEnum.OrderCard)
                {
                    isIncreaseTransation = true;
                    transactionType = (int)SkyConnectTransactionTypeEnum.MemberCharge;
                }
                Boolean isSendToSkyConnect = true;
                if (currentOrderManager.getCardType() == (int)PaymentTypeEnum.Cash)
                {

                    isSendToSkyConnect = false;
                    return false;
                }
                if (isSendToSkyConnect)
                {
                    List<TransactionVM> listTrans = new List<TransactionVM>();
                    if (creditAccount != null)
                    {
                        TransactionVM transaction = new TransactionVM()
                        {
                            Amount = (decimal)currentOrder.FinalAmount,
                            CardCode = currentOrder.BarCode,
                            AccountCode = creditAccount.AccountCode,
                            CurrencyCode = "VNĐ",
                            Date = currentOrder.CheckInDate,
                            IsIncreaseTransaction = isIncreaseTransation,
                            Notes = "Thanh toán membership " + currentOrder.BarCode + " từ storeID " + MainForm.StoreInfo.StoreId,
                            TransactionType = transactionType,

                        };
                        listTrans.Add(transaction);
                    }

                    OrderVM order = new OrderVM
                    {
                        ApproveDate = currentOrder.ApproveDate,
                        ApprovePerson = currentOrder.ApprovePerson,
                        Att1 = currentOrder.Att1,
                        Att2 = currentOrder.Att2,
                        Att3 = currentOrder.Att3,
                        Att4 = currentOrder.Att4,
                        Att5 = currentOrder.Att5,
                        CardCode = currentOrder.BarCode,
                        CheckInDate = currentOrder.CheckInDate,
                        CheckOutDate = currentOrder.CheckOutDate,
                        CustomerID = currentOrder.CustomerID,
                        Discount = currentOrder.Discount,
                        FinalAmount = currentOrder.FinalAmount,
                        Notes = currentOrder.Notes,
                        OrderCode = currentOrder.OrderCode,
                        OrderID = currentOrder.OrderId,
                        OrderStatus = currentOrder.OrderStatus,
                        OrderType = currentOrder.OrderType,
                        StoreID = int.Parse(MainForm.StoreInfo.StoreId),
                        TableNumber = currentOrder.TableNumber,
                        TotalAmount = currentOrder.TotalAmount,
                        VAT = currentOrder.VAT,
                        VATAmount = currentOrder.VATAmount,
                        ListTransaction = listTrans
                    };

                    var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
                    var pDomain = new SkyConnectPaymentDomain(config);
                    var orderResponse = pDomain.ConfirmPayment(order, (int)SkyConnectPartnerEnum.InHouse);
                    if (orderResponse == null)
                    {
                        var msg = "Thanh toán SkyConnect không thành công";
                        Program.MainForm.HideSplashForm();
                        PosMessageDialog.ShowMessage(msg);
                        return false;
                    }
                }
            }
            

            return true;
        }


        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            var isSaveTableStatus = false;
            ExitOrCancelOrder(isSaveTableStatus);
        }

        private void DeactiveAllOrderTypeControls()
        {
            btnAtStoreMode.IsActive = false;
            btnDeliveryMode.IsActive = false;
            btnAtStoreMode.IsActive = false;
        }

        #endregion

        private void OrderType_Clicked(object sender, EventArgs e)
        {
            var button = sender as BootstrapButton;

            if (button != null)
            {
                var buttonValue = int.Parse(button.ButtonValue);

                currentOrderManager.getOrderEditViewModel().OrderType = buttonValue;
            }
        }

        private void InitiateSerialPort()
        {
            try
            {
                // Make sure that no exceptions happen 
                CloseSerialPort();

                var portName = MainForm.PosConfig.ScaleCommunicatePort;
                Program.context.setSerialPort(new SerialPort(portName, 9600, Parity.None, 8, StopBits.One));

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

                mySerialPort.Open();
            }
            catch (Exception ex)
            {
                log.Error("InitiateSerialPort - " + ex);
                PosMessageDialog.ShowMessage("Vui lòng kiểm tra lại bàn cân và khởi động lại!");
            }
        }

        private int loopCounter = 0;
        private void CloseSerialPort()
        {
            if (mySerialPort != null && mySerialPort.IsOpen)
                mySerialPort.Close();
            if (mySerialPort != null)
                mySerialPort.Dispose();
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                lock (mySerialPort)
                {
                    SerialPort sp = (SerialPort)sender;
                    //                    string mydata = "";
                    //                    while (sp.BytesToRead > 0)
                    //                    {
                    //                        mydata = string.Format("{0:X2} ", sp.ReadByte());
                    //                    }
                    Thread.Sleep(300);
                    string indata = sp.ReadExisting();
                    if (string.IsNullOrWhiteSpace(indata))
                    {
                        //                        loopCounter++;
                        //                        if (loopCounter > 20)
                        //                        {
                        //                            return;
                        //                        }
                        serialPort_DataReceived(sender, e);
                    }
                    var data = indata.Split(':')[1].Trim();
                    // if success, reset loopcounter;
                    loopCounter = 0;
                    string weight = "";
                    string unit = "";
                    double rsWeight = 0;
                    for (int i = data.Length - 1; i >= 0; i--)
                    {
                        if (data[i] == ' ')
                        {
                            unit = data.Substring(i + 1).Trim();
                            weight = data.Substring(0, i).Trim();

                            if (double.TryParse(weight, out rsWeight))
                            {
                                rsWeight = this.ConvertWeightUnit(rsWeight * MainForm.PosConfig.RatioToGram
                                    , unit, MainForm.PosConfig.ResultWeightUnit);
                            }

                            break;
                        }
                    }

                    SetQuantity(rsWeight);
                }
            }
            catch (Exception ex)
            {
                log.Error("serialPort_DataReceived - " + ex);
            }
        }

        public void SetQuantity(double rsWeight)
        {
            try
            {
                if (_orderDetailForm != null && _orderDetailForm.Visible)
                {
                    int quantity = Convert.ToInt32(rsWeight);
                    if (quantity > 0)
                    {
                        _orderDetailForm.UpdateQuantity(quantity);
                    }
                }
                else
                {
                    int quantity = Convert.ToInt32(rsWeight);

                    if (quantity > 0)
                    {
                        OrderDetailEditViewModel lastMainOrderDetail = new OrderDetailEditViewModel();

                        for (int i = currentOrderManager.
                            getOrderEditViewModel().OrderDetailEditViewModels.Count - 1;
                            i >= 0;
                            i++)
                        {
                            var orderDetail = currentOrderManager.
                                getOrderEditViewModel().OrderDetailEditViewModels[i];
                            if (orderDetail.ParentId == null)
                            {
                                lastMainOrderDetail = orderDetail;
                                break;
                            }
                        }

                        var newQuantity = quantity - lastMainOrderDetail.Quantity;

                        currentOrderManager.ChangeItemQuantityOfOrderDetail(
                            OrderDetailChangeModeEnum.ModifiedOrderDetail, null, lastMainOrderDetail,
                            newQuantity);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("SetQuantity - " + ex);
                PosMessageDialog.ShowMessage("Cập nhật giá thất bại!");
            }
        }

        private double ConvertWeightUnit(double weight, string originalWeightUnit, string resultWeightUnit)
        {
            double result = weight;
            var originalUnit = string.IsNullOrEmpty(originalWeightUnit) ? "" : originalWeightUnit.Trim().ToLower();
            var resultUnit = string.IsNullOrEmpty(resultWeightUnit) ? "" : resultWeightUnit.Trim().ToLower();

            if (!string.IsNullOrEmpty(originalWeightUnit) && !string.IsNullOrEmpty(resultWeightUnit))
            {
                switch (originalUnit)
                {
                    case "g":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "gam":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "gram":
                        if (resultUnit.Equals("kg"))
                        {
                            result = weight / 1000;
                        }
                        break;
                    case "kg":
                        if (!resultUnit.Equals("kg"))
                        {
                            result = weight * 1000;
                        }
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        public static void OpenSafe(string name, string reason)
        {
            try
            {
                PosPrinter.PrintOpenSafe(name, reason);
            }
            catch
            {

            }
        }

        public static List<ProductViewModel> GetProductExtraByPrimaryCate(int primaryCateCode)
        {
            List<ProductViewModel> productExtraList = new List<ProductViewModel>();
            //var productExtraService = ServiceManager.GetService<ProductExtraService>(typeof(ProductExtraRepository));
            //List<CategoryExtraViewModel> categoryExtraList = Program.context.getAllCategoryExtras();
            productExtraList.AddRange(Program.context.getAllProducts().Where(p => p.CatID == 21));
            //AllCategoryExtras.Where(c => c.PrimaryCategoryCode == primaryCateCode).ToList();

            //foreach (var cateExra in categoryExtraList)
            //{
            //    //productExtraList.AddRange(AllProducts.Where(p => p.CatID == cateExra.ExtraCategoryCode));
            //    productExtraList.AddRange(Program.context.getAllProducts().Where(p => p.CatID == cateExra.CategoryExtraId));
            //}

            return productExtraList;
        }

        #region Order Card 

        public static void CreateOrderCard(ProductViewModel product, double money, int? customerId)
        {
            var order = MainForm.CreateOrderEditViewModel(OrderTypeEnum.OrderCard);
            order.Notes = "";
            order.CustomerID = customerId != null ? customerId : null;
            currentOrderManager.setOrderEditViewModel(order);

            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, product, null, 1);
            currentOrderManager.UpdatePayment(PaymentTypeEnum.Cash, money, null);

            FinishAndCloseOrder();
        }
        #endregion

        private void btnScanBarcode_Click_1(object sender, EventArgs e)
        {
            var isEnableOnscreenKeyboard = MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true";
            var inputProductBarcode = PosMessageDialog.YesNoDialogWithInput(
                        //message:Xin điền mã voucher
                        MainForm.ResManager.GetString("SaleScreen3_Barcode_Input", MainForm.CultureInfo) + ":", MainForm.ResManager.GetString("Sys_Confirm", MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo),
                        true, "");

            if (inputProductBarcode != null)
            {
                string code = inputProductBarcode[0];

                var productVM = BussinessContext.getProductVMByProductCode(code);
                if (productVM != null)
                {
                    if (productVM.ProductType == (int)ProductTypeEnum.General)
                    {
                        if (productVM.ProductParentId != null)
                        {
                            var childProducts = Program.context.getAllProducts().Where(p => p.GeneralProductId == productVM.ProductParentId).ToList();

                            productVM = childProducts.FirstOrDefault();
                            foreach (var childProduct in childProducts)
                            {
                                if (childProduct.IsDefaultChildProduct)
                                {
                                    productVM = childProducts.FirstOrDefault(p => p.IsDefaultChildProduct);
                                }
                            }
                        }
                    }
                    currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, productVM, null, 1);
                    btnScanBarcode_Click_1(null, null);
                }
                else
                {
                    PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("SaleScreen3_Not_Found_Product", MainForm.CultureInfo));
                    btnScanBarcode_Click_1(null, null);
                    //TimeOut 5s
                }
            }
        }
    }
}