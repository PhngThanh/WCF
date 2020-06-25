using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using POS.Utils;
using POS.PrintManager;
using POS.Common;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.Entities;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;
using log4net;

namespace POS.DashboardScreen
{
    public partial class ViewOrderDetailDialog : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private OrderEditViewModel _currentOrder;
        private string TempOrderCode;

        public Action OrderChanged;
        public static Printer PosPrinter { get; set; }

        public ViewOrderDetailDialog()
        {
            InitializeComponent();
            PosPrinter = new Printer();
            GenerateLayout();
            StartPosition = FormStartPosition.CenterScreen;
            if (!MainForm.StoreInfo.PrintWifiPassword.Trim().ToLower().Equals("true"))
            {
                btnPrintWifiPass.Hide();
            }
        }

        private void GenerateLayout()
        {
            btnHide.Caption = MainForm.ResManager.GetString("Sys_Hide", MainForm.CultureInfo);
            btnCancel.Caption = MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo);
            btnAccept.Caption = MainForm.ResManager.GetString("OrderDetailDialog_Accept", MainForm.CultureInfo);
            btnReject.Caption = MainForm.ResManager.GetString("OrderDetailDialog_Reject", MainForm.CultureInfo);
            btnPrint.Caption = MainForm.ResManager.GetString("OrderDetailDialog_Print_Bill", MainForm.CultureInfo);
        }

        public void LoadOrder(OrderEditViewModel order)
        {
            try
            {
                if ((order.OrderStatus == (int)OrderStatusEnum.Finish
                        || order.OrderStatus == (int)OrderStatusEnum.PosFinished)
                    && (order.OrderType == (int)OrderTypeEnum.AtStore
                        || order.OrderType == (int)OrderTypeEnum.TakeAway
                        || order.OrderType == (int)OrderTypeEnum.Delivery
                        || order.OrderType == (int)OrderTypeEnum.OrderCard))
                {
                    btnCancel.Show();
                }
                else
                {
                    btnCancel.Hide();
                }

                //Load button reject
                if (order.DeliveryStatus != (int)DeliveryStatusEnum.Assigned)
                {
                    TempOrderCode = order.OrderCode;
                    btnReject.Hide();
                    btnAccept.Hide();
                }
                else
                {
                    TempOrderCode = order.OrderCode;
                    btnReject.Show();
                    btnAccept.Show();
                }
                if (order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery)
                {
                    btnAccept.Text = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);
                    btnAccept.Show();
                }
                _currentOrder = order;
                orderDetailControl.LoadOrder(order);
            }
            catch (Exception ex)
            {
                log.Error("LoadOrder - " + ex);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(124, 124, 124), 5))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainForm.ShowSplashForm(
                        MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
                        MainForm.CultureInfo));

                var orderCode = TempOrderCode;
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var order = orderService.GetOrderByOrderCode(orderCode);
                order.OrderStatus = (int)OrderStatusEnum.PosFinished;
                order.CheckInPerson = MainForm.CurrentAccount.AccountId;

                //Payment
                Payment p = new Payment()
                {
                    PaymentID = 0,
                    Order = order,
                    OrderId = order.OrderId,
                    Amount = order.FinalAmount,
                    Type = (int)PaymentTypeEnum.Cash,
                    PayTime = UtcDateTime.Now()
                };

                if (order.Payments == null)
                {
                    order.Payments = new HashSet<Payment>();
                    order.Payments.Add(p);
                }
                else
                {
                    if (CheckAddableOrderPayments(order, order.Payments))
                    {
                        order.Payments.Add(p);
                    }
                }

                


                if (order.OrderType == (int)OrderTypeEnum.Delivery)
                {
                    var orderEditViewModel = ServiceManager.GetOrderEditViewModel(order);

                    if (MainForm.PosConfig.EnableDeliveryStatus.Trim().ToLower() == "true")
                    {
                        if (order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery)
                        {
                            order.DeliveryStatus = (int)DeliveryStatusEnum.Finish;
                            order.OrderStatus = (int)OrderStatusEnum.PosFinished;

                            orderEditViewModel.DeliveryStatus = (int)DeliveryStatusEnum.Finish;
                            orderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosFinished;

                            Program.MainForm.HideSplashForm();
                            PosPrinter.PrintBill(orderEditViewModel, BillTypeEnum.Customer,
                                        MainForm.StoreInfo.PrinterBill, true);
                        }
                    }

                    if (order.DeliveryStatus == (int)DeliveryStatusEnum.Assigned)
                    {
                        order.DeliveryStatus = (int)DeliveryStatusEnum.Finish;
                        order.OrderStatus = (int)OrderStatusEnum.PosFinished;

                        orderEditViewModel.DeliveryStatus = (int)DeliveryStatusEnum.Finish;
                        orderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosFinished;

                        Program.MainForm.HideSplashForm();
                        PrintBills(orderEditViewModel);
                    }

                    //orderService.Update(order);
                    orderService.UpdateOrder(order);

                    //Refresh btnOnlineOrder
                    Program.MainForm.TotalNewOnlineOrders -= 1;
                    Program.MainForm.UpdateButtonOnlineOrder();
                    Program.MainForm.HideSplashForm();

                    CloseForm(true);

                    Program.MainForm.LoadOnlineOrderScreen();
                }
            }
            catch (Exception ex)
            {
                log.Error("btnAccept_Click - " + ex);
            }

        }

        private bool CheckAddableOrderPayments(Order order, ICollection<Payment> payments)
        {
            var sum = 0.0;
            foreach(var payment in payments)
            {
                sum += payment.Amount;
            }
            return sum < order.FinalAmount;
        }

        private void PrintBills(OrderEditViewModel order)
        {
            if (!string.IsNullOrEmpty(MainForm.StoreInfo.PrintBillOrder))
            {
                var list = MainForm.StoreInfo.PrintBillOrder.Split('|');
                foreach (var item in list)
                {
                    var printerName = MainForm.StoreInfo.PrinterBill;
                    var type = BillTypeEnum.Customer;
                    if (item.Contains("cook"))
                    {
                        printerName = MainForm.StoreInfo.PrinterCook1;
                        type = BillTypeEnum.Cook;
                    }
                    PosPrinter.PrintBill(order, type, printerName, true);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                var orderCode = TempOrderCode;
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var order = orderService.GetOrderByOrderCode(orderCode);

                order.OrderStatus = (int)OrderStatusEnum.PosPreCancel;
                order.DeliveryStatus = (int)DeliveryStatusEnum.PreCancel;

                foreach (var detail in order.OrderDetails)
                {
                    detail.TotalAmount = 0;
                    detail.Discount = 0;
                    detail.FinalAmount = 0;
                    detail.OrderPromotionMappingId = null;
                    detail.OrderDetailPromotionMappingId = null;

                    foreach (var mapping in detail.OrderDetailPromotionMappings)
                    {
                        mapping.DiscountAmount = 0;
                        mapping.DiscountRate = 0;
                    }

                    detail.Status = (int)OrderDetailStatusEnum.PosPreCancel;
                }

                foreach (var p in order.Payments)
                {
                    p.Amount = 0;
                }

                foreach (var mapping in order.OrderPromotionMappings)
                {
                    mapping.DiscountAmount = 0;
                    mapping.DiscountRate = 0;
                }

                order.DiscountOrderDetail = 0;
                order.Discount = 0;
                order.TotalAmount = 0;
                order.FinalAmount = 0;
                order.VAT = 0;
                order.VATAmount = 0;

                orderService.UpdateOrder(order);

                Program.MainForm.TotalNewOnlineOrders -= 1;
                Program.MainForm.UpdateButtonOnlineOrder();
                CloseForm(true);
            }
            catch (Exception ex)
            {
                log.Error("btnReject_Click - " + ex);
            }

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            CloseForm(false);
        }


        private void CloseForm(bool isOrderChanged)
        {
            if (isOrderChanged)
            {
                if (OrderChanged != null)
                {
                    OrderChanged();
                }
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                var isRequiredPassword = MainForm.PosConfig.RequiredPasswordCancel.Trim().ToLower() == "true";
                var checkLogin = MainForm.CheckRole(isRequiredPassword);
                if (checkLogin)
                {
                    var cancelSelectType = PosMessageDialog.YesNoCancelDialogWithInput(
                                "Xin điền ghi chú và chọn loại Hủy:",
                                "Trước chế biến", "Sau chế biến", "Không Hủy", true, "");
                    if (cancelSelectType != null)
                    {
                        var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                        var orderCode = TempOrderCode;
                        var order = orderService.GetOrderByOrderCode(orderCode);
                        var cancelType = (int)OrderDetailStatusEnum.PosCancel;

                        if (cancelSelectType[1] == "OK")
                        {
                            order.OrderStatus = (int)OrderStatusEnum.PosPreCancel;
                            order.DeliveryStatus = (int)DeliveryStatusEnum.PreCancel;
                            order.Notes += cancelSelectType[0];

                            cancelType = (int)OrderDetailStatusEnum.PosPreCancel;
                        }
                        else
                        {
                            order.OrderStatus = (int)OrderStatusEnum.PosCancel;
                            order.DeliveryStatus = (int)DeliveryStatusEnum.Cancel;
                            order.Notes += cancelSelectType[0];
                        }

                        foreach (var detail in order.OrderDetails)
                        {
                            detail.TotalAmount = 0;
                            detail.Discount = 0;
                            detail.FinalAmount = 0;
                            detail.OrderPromotionMappingId = null;
                            detail.OrderDetailPromotionMappingId = null;

                            foreach (var mapping in detail.OrderDetailPromotionMappings)
                            {
                                mapping.DiscountAmount = 0;
                                mapping.DiscountRate = 0;
                            }

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

                        foreach (var p in order.Payments)
                        {
                            p.Amount = 0;
                        }

                        foreach (var mapping in order.OrderPromotionMappings)
                        {
                            mapping.DiscountAmount = 0;
                            mapping.DiscountRate = 0;
                        }

                        order.DiscountOrderDetail = 0;
                        order.Discount = 0;
                        order.TotalAmount = 0;
                        order.FinalAmount = 0;
                        order.VAT = 0;
                        order.VATAmount = 0;

                        orderService.UpdateOrder(order);

                        CloseForm(true);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("btnCancel_Click - " + ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var isRequiredPassword = MainForm.PosConfig.RequiredPasswordExportReport.Trim().ToLower() == "true";
                var checkLogin = MainForm.CheckRole(isRequiredPassword);

                if (checkLogin)
                {
                    var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                    var orderCode = TempOrderCode;
                    var order = orderService.GetOrderByOrderCode(orderCode);
                    var orderViewModel = ServiceManager.GetOrderEditViewModel(order);
                    PosPrinter.PrintBill(orderViewModel, BillTypeEnum.Customer,
                                    MainForm.StoreInfo.PrinterBill, true);
                }
            }
            catch (Exception ex)
            {
                log.Error("btnPrint_Click - " + ex);
            }
        }

        private void btnPrintWifiPass_Click(object sender, EventArgs e)
        {
            if (MainForm.StoreInfo.PrintWifiPassword.Trim().ToLower().Equals("true"))
            {
                Printer printer = new Printer();
                printer.PrintWifiPassword(_currentOrder);
            }
        }
    }
}
