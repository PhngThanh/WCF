using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using POS.Repository.ViewModels;
using POS.Repository.Entities.Repositories;
//using UniLogLibFramework.Library;

namespace POS.Repository.Entities.Services
{
    public class ReportService
    {
        //private static readonly  LogMonitor _log = new LogMonitor();
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Total Repot

        //Báo cáo tổng hợp
        public StoreReportModel GenerateStoreReport(DateTime startTime, DateTime endTime, string username,DateReportViewModel reportVM=null)
        {
            try
            {
                //log.Info("Start Report - " + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                
                Stopwatch sw = new Stopwatch();
               
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                //                var orderDetailService = ServiceManager.GetService<OrderService>(typeof(OrderDetail));
                var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));

                var model = new StoreReportModel();
                model.CheckInPerson = username;
                var categories = categoryService.Get(c => c.IsUsed)
                                                .ToList()
                                                .GroupBy(cat => cat.Code)
                                                .Distinct()
                                                .Select(catGrp => catGrp.LastOrDefault())
                                                .ToList();
                var products = productService.Get(p => p.IsUsed).ToList();

                var startDate = startTime;
                var endDate = endTime;
                model.FromDate = startDate;
                model.ToDate = endDate;
                model.TotalVATAmount = 0;

                //Lấy ra tất cả order trong ngày
                List<Order> orders;
                if ((username == "All Staff") || (username == "Tất cả nhân viên"))
                {
                    //                    orders = orderService.GetOrderByDate(startDate, endDate)
                    //                        .Where(a => a.OrderStatus == (int)OrderStatusEnum.PosFinished || a.OrderStatus == (int)OrderStatusEnum.Finish).ToList();

                    orders = orderService.GetOrderByDate(startDate, endDate).ToList();
                }
                else
                {
                    //                    orders = orderService.GetOrderByDate(startDate, endDate)
                    //                        .Where(o => o.CheckInPerson == username &&
                    //                            (o.OrderStatus == (int)OrderStatusEnum.PosFinished || o.OrderStatus == (int)OrderStatusEnum.Finish)).ToList();
                    orders = orderService.GetOrderByDate(startDate, endDate)
                       .Where(o => o.CheckInPerson == username).ToList();
                }
                #region Product

                List<ProductReportModel> productReportModels = new List<ProductReportModel>();
                var categoryReportModel = new List<CategoryReportModel>();
                sw.Start();
                var finisehOrders = orders.Where(a => a.OrderStatus == (int)OrderStatusEnum.PosFinished || a.OrderStatus == (int)OrderStatusEnum.Finish).ToList();                
                try
                {
                    foreach (var order in finisehOrders)
                    {
                        var type = (OrderTypeEnum)order.OrderType;
                        model.TotalVATAmount += order.VATAmount;

                        foreach (var orderDetail in order.OrderDetails)
                        {
                            if(products.FirstOrDefault(f=>f.Code.Equals(orderDetail.ProductCode))==null)
                            {
                                products.Add(productService.FirstOrDefault(f => f.Code.Equals(orderDetail.ProductCode)));
                            }
                            if (orderDetail.Status != (int)OrderDetailStatusEnum.PosPreCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.PreCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.PosCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.Cancel)
                            {
                                //var productModel = productReportModels.Find(p => p.ProductId == orderDetail.ProductId);
                                var productModel = productReportModels.FirstOrDefault(p => (p.ProductCode == orderDetail.ProductCode));
                                //if (productModel == null && productModel.ProductCode != orderDetail.ProductCode)
                                if (productModel == null)
                                {
                                    //var productCode = products.LastOrDefault(a=> a.Code == orderDetail.ProductCode);
                                    productModel = new ProductReportModel()
                                    {
                                        ProductId = orderDetail.ProductId,
                                        ProductCode = orderDetail.ProductCode,
                                        ProductName = orderDetail.ProductName,
                                        UnitPrice = orderDetail.UnitPrice,
                                        ProductType = orderDetail.ProductType == null ? (int)ProductGroupEnum.Other : (int)orderDetail.ProductType,
                                        //Group = productCode.Group,
                                        Quantity = orderDetail.Quantity,
                                        AtStoreQuantity = (type == OrderTypeEnum.AtStore) ? orderDetail.Quantity : 0,
                                        TakeAwayQuantity = (type == OrderTypeEnum.TakeAway) ? orderDetail.Quantity : 0,
                                        DeliveryQuantity = (type == OrderTypeEnum.Delivery) ? orderDetail.Quantity : 0,

                                        TotalAmount = orderDetail.TotalAmount,
                                        AtStoreAmount = (type == OrderTypeEnum.AtStore) ? orderDetail.TotalAmount : 0,
                                        TakeAwayAmount = (type == OrderTypeEnum.TakeAway) ? orderDetail.TotalAmount : 0,
                                        DeliveryAmount = (type == OrderTypeEnum.Delivery) ? orderDetail.TotalAmount : 0,
                                        TotalDiscount = orderDetail.Discount,
                                        AtStoreDiscount = (type == OrderTypeEnum.AtStore) ? orderDetail.Discount : 0,
                                        TakeAwayDiscount = (type == OrderTypeEnum.TakeAway) ? orderDetail.Discount : 0,
                                        DeliveryDiscount = (type == OrderTypeEnum.Delivery) ? orderDetail.Discount : 0,
                                    };
                                    productReportModels.Add(productModel);
                                }
                                else
                                {
                                    productModel.Quantity += orderDetail.Quantity;
                                    productModel.AtStoreQuantity += (type == OrderTypeEnum.AtStore) ? orderDetail.Quantity : 0;
                                    productModel.TakeAwayQuantity += (type == OrderTypeEnum.TakeAway) ? orderDetail.Quantity : 0;
                                    productModel.DeliveryQuantity += (type == OrderTypeEnum.Delivery) ? orderDetail.Quantity : 0;
                                    productModel.TotalAmount += orderDetail.TotalAmount;
                                    productModel.AtStoreAmount += (type == OrderTypeEnum.AtStore) ? orderDetail.TotalAmount : 0;
                                    productModel.TakeAwayAmount += (type == OrderTypeEnum.TakeAway) ? orderDetail.TotalAmount : 0;
                                    productModel.DeliveryAmount += (type == OrderTypeEnum.Delivery) ? orderDetail.TotalAmount : 0;
                                    productModel.TotalDiscount += orderDetail.Discount;
                                    productModel.AtStoreDiscount += (type == OrderTypeEnum.AtStore) ? orderDetail.Discount : 0;
                                    productModel.TakeAwayDiscount += (type == OrderTypeEnum.TakeAway) ? orderDetail.Discount : 0;
                                    productModel.DeliveryDiscount += (type == OrderTypeEnum.Delivery) ? orderDetail.Discount : 0;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("GenerateStoreReport - " + ex);
                    //_log.SendLogError(ex);
                }
                try
                {
                    //var listProducts = products.Select(p => new Tuple<string, int>(p.Code, p.CatID));

                    foreach (var category in categories)
                    {
                        //Lay tat ca ProductID cua category
                        var categoryProductId = products.Where(p => p.CatID == category.Code).Select(p => p.Code).ToList();
                        
                        var productModel = productReportModels
                            .Where(p => categoryProductId.Contains(p.ProductCode)).ToList();
                        CategoryReportModel categoryModel = new CategoryReportModel()
                        {
                            Code = category.Code,
                            CategoryName = category.Name,
                            ProductReportModels = productModel,
                            Discount = productModel.Sum(a => a.TotalDiscount),
                            TotalAmount = productModel.Sum(a => a.TotalAmount),
                            TotalQuantity = productModel.Sum(a => a.Quantity),
                        };
                        categoryReportModel.Add(categoryModel);
                    }
                    model.Categories = categoryReportModel;
                }
                catch (Exception ex)
                {
                    //log.Error("GenerateStoreReport - " + ex);
                    //_log.SendLogError(ex);
                }
                
                #endregion

                sw.Restart();

                #region AtStoreReport

                //Trường hợp order là atStore
                var atStoreOrder = orders.Where(a => a.OrderType == (int)OrderTypeEnum.AtStore).ToList();

                var atStoreModel = new TypeReportModel();


                //Tổng số hóa đơn
                atStoreModel.OrderQuantity = atStoreOrder.Count();

                ////Tổng hóa đơn đã hoàn thành POSFinished, Finished
                atStoreModel.OrderFinish = atStoreOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished);

                //Tổng hóa đơn hủy trước chế biến
                atStoreModel.OrderPrecancel = atStoreOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.PreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel);

                // Tổng hóa đơn hủy sau chế biến
                atStoreModel.OrderCancel = atStoreOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Cancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosCancel);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) chưa giảm giá
                atStoreModel.TotalAmount = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.TotalAmount);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) đã giảm giá
                atStoreModel.FinalAmount = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.FinalAmount);

                atStoreModel.TotalAmountCanceled = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Cancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosCancel).Sum(a => a.FinalAmount);

                atStoreModel.TotalAmountPreCanceled = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.PreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel).Sum(a => a.FinalAmount);

                //Tổng giám giá trên từng sản phẩm
                atStoreModel.DetailDiscountAmount = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.DiscountOrderDetail);

                //Tổng giám giá trên từng hóa đơn
                atStoreModel.OrderDiscountAmount = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Discount);

                //Tổng thanh toán bằng tiền mặt. 
                atStoreModel.CashPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Cash
                                || b.Type == (int)PaymentTypeEnum.ExchangeCash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                atStoreModel.MembershipPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                atStoreModel.CreditCardPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Card
                                || b.Type == (int)PaymentTypeEnum.MasterCard
                                || b.Type == (int)PaymentTypeEnum.VisaCard).Sum(c => c.Amount));
                //Tổng thanh toán bằng loại khác
                atStoreModel.OtherPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Other
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng MoMo
                atStoreModel.MoMoPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MoMo
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng ZaloPay
                atStoreModel.ZaloPayPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.ZaloPay
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng GiftTalk
                atStoreModel.GiftTalkPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));

                //thanh toán bằng grabpay
                atStoreModel.GrabPayPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GrabPay
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.AtStoreReport = atStoreModel;
                atStoreModel.GrabFoodPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GrabFood
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.AtStoreReport = atStoreModel;
                #endregion

                #region TakeAwayReport
                //Trường hợp order là TakeAway
                var takeAwayOrder = orders.Where(a => a.OrderType == (int)OrderTypeEnum.TakeAway).ToList();

                var takeAwayModel = new TypeReportModel();
                //Tổng số hóa đơn
                takeAwayModel.OrderQuantity = takeAwayOrder.Count();

                ////Tổng hóa đơn đã hoàn thành POSFinished, Finished
                takeAwayModel.OrderFinish = takeAwayOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished);

                //Tổng hóa đơn hủy trước chế biến
                takeAwayModel.OrderPrecancel = takeAwayOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.PreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel);

                // Tổng hóa đơn hủy sau chế biến
                takeAwayModel.OrderCancel = takeAwayOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Cancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) chưa giảm giá
                takeAwayModel.TotalAmount = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.TotalAmount);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) đã giảm giá
                takeAwayModel.FinalAmount = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.FinalAmount);

                //Tổng giám giá trên từng sản phẩm
                takeAwayModel.DetailDiscountAmount = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.DiscountOrderDetail);

                //Tổng giám giá trên từng hóa đơn
                takeAwayModel.OrderDiscountAmount = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Discount);

                //Tổng thanh toán bằng tiền mặt. 
                takeAwayModel.CashPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                        .Where(b => b.Type == (int)PaymentTypeEnum.Cash
                                || b.Type == (int)PaymentTypeEnum.ExchangeCash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                takeAwayModel.MembershipPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                        .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                takeAwayModel.CreditCardPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                        .Where(b => b.Type == (int)PaymentTypeEnum.Card
                                || b.Type == (int)PaymentTypeEnum.MasterCard
                                || b.Type == (int)PaymentTypeEnum.VisaCard).Sum(c => c.Amount));
                //Tổng thanh toán bằng loại khác
                takeAwayModel.OtherPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Other
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng MoMo
                takeAwayModel.MoMoPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MoMo
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng ZaloPay
                takeAwayModel.ZaloPayPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.ZaloPay
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng GiftTalk
                takeAwayModel.GiftTalkPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng GrabPay
                takeAwayModel.GrabPayPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk
                                || b.Type == (int)PaymentTypeEnum.GrabPay
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.TakeAwayReport = takeAwayModel;

                takeAwayModel.GrabFoodPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                  || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                  .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk
                              || b.Type == (int)PaymentTypeEnum.GrabFood
                              || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.TakeAwayReport = takeAwayModel;
                #endregion

                #region DeliveryReport
                //Trường hợp order là Delivery
                var deliveryOrder = orders.Where(a => a.OrderType == (int)OrderTypeEnum.Delivery).ToList();

                var deliveryModel = new TypeReportModel();

                //Tổng số hóa đơn
                deliveryModel.OrderQuantity = deliveryOrder.Count();

                ////Tổng hóa đơn đã hoàn thành POSFinished, Finished
                deliveryModel.OrderFinish = deliveryOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished);

                //Tổng hóa đơn hủy trước chế biến
                deliveryModel.OrderPrecancel = deliveryOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.PreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel);

                // Tổng hóa đơn hủy sau chế biến
                deliveryModel.OrderCancel = deliveryOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Cancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosCancel);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) chưa giảm giá
                deliveryModel.TotalAmount = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.TotalAmount);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) đã giảm giá
                deliveryModel.FinalAmount = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.FinalAmount);

                //Tổng giám giá trên từng sản phẩm
                deliveryModel.DetailDiscountAmount = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.DiscountOrderDetail);

                //Tổng giám giá trên từng hóa đơn
                deliveryModel.OrderDiscountAmount = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Discount);

                //Tổng thanh toán bằng tiền mặt. 
                deliveryModel.CashPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Cash
                                || b.Type == (int)PaymentTypeEnum.ExchangeCash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                deliveryModel.MembershipPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                deliveryModel.CreditCardPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Card
                                || b.Type == (int)PaymentTypeEnum.MasterCard
                                || b.Type == (int)PaymentTypeEnum.VisaCard).Sum(c => c.Amount));
                //Tổng thanh toán bằng loại khác
                deliveryModel.OtherPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Other
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng MoMo
                deliveryModel.MoMoPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MoMo
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng ZaloPay
                deliveryModel.ZaloPayPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.ZaloPay
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng GiftTalk
                deliveryModel.GiftTalkPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                //thanh toán bằng grabpay
                deliveryModel.GrabPayPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GrabPay
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.DeliveryReport = deliveryModel;

                deliveryModel.GrabFoodPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
    .Where(b => b.Type == (int)PaymentTypeEnum.GrabFood
                || b.Type == (int)PaymentTypeEnum.Voucher
                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));
                model.DeliveryReport = deliveryModel;
                #endregion

                #region CardReport
                //Trường hợp order là Delivery
                var cardOrder = orders.Where(a => a.OrderType == (int)OrderTypeEnum.OrderCard).ToList();

                var cardModel = new TypeReportModel();

                //Tổng số hóa đơn
                cardModel.OrderQuantity = cardOrder.Count();

                ////Tổng hóa đơn đã hoàn thành POSFinished, Finished
                cardModel.OrderFinish = cardOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished);

                //Tổng hóa đơn hủy trước chế biến
                cardModel.OrderPrecancel = cardOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.PreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel);

                // Tổng hóa đơn hủy sau chế biến
                cardModel.OrderCancel = cardOrder.Count(a => a.OrderStatus == (int)OrderStatusEnum.Cancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosCancel);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) chưa giảm giá
                cardModel.TotalAmount = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.TotalAmount);

                //Tổng doanh số của tất cả hóa đơn đã hoàn thành (PosFinish, Finish) đã giảm giá
                cardModel.FinalAmount = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.FinalAmount);

                //Tổng giám giá trên từng sản phẩm
                cardModel.DetailDiscountAmount = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.DiscountOrderDetail);

                //Tổng giám giá trên từng hóa đơn
                cardModel.OrderDiscountAmount = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Discount);

                //Tổng thanh toán bằng tiền mặt. 
                cardModel.CashPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Cash
                                || b.Type == (int)PaymentTypeEnum.ExchangeCash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                cardModel.MembershipPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                cardModel.CreditCardPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Card
                                || b.Type == (int)PaymentTypeEnum.MasterCard
                                || b.Type == (int)PaymentTypeEnum.VisaCard).Sum(c => c.Amount));

                //Tổng thanh toán bằng loại khác
                cardModel.OtherPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Other
                                || b.Type == (int)PaymentTypeEnum.Voucher
                                || b.Type == (int)PaymentTypeEnum.AccountReceivable).Sum(c => c.Amount));

                //thanh toán bằng MoMo ????
                cardModel.MoMoPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MoMo).Sum(c => c.Amount));
                //thanh toán bằng ZaloPay ????
                cardModel.ZaloPayPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.ZaloPay).Sum(c => c.Amount));
                //thanh toán bằng GiftTalk ????
                cardModel.GiftTalkPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GiftTalk).Sum(c => c.Amount));

                //thanh toán bằng GrabPay
                cardModel.GrabPayPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.GrabPay).Sum(c => c.Amount));

                cardModel.GrabFoodPayment = cardOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                  || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                  .Where(b => b.Type == (int)PaymentTypeEnum.GrabFood).Sum(c => c.Amount));
                model.CardReport = cardModel;
                #endregion

                //Debug.WriteLine("Report:", sw.ElapsedMilliseconds);
                //log.Info("End Report " + sw.ElapsedMilliseconds + " - " + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                sw.Reset();
                if (reportVM != null)
                {
                    reportVM.Date = endTime;
                    reportVM.TotalAmount = atStoreModel.TotalAmount + deliveryModel.TotalAmount + takeAwayModel.TotalAmount + cardModel.TotalAmount;
                    reportVM.FinalAmount = atStoreModel.FinalAmount + deliveryModel.FinalAmount + takeAwayModel.FinalAmount + cardModel.FinalAmount;
                    reportVM.Discount = atStoreModel.OrderDiscountAmount + deliveryModel.OrderDiscountAmount + takeAwayModel.OrderDiscountAmount + cardModel.OrderDiscountAmount;
                    reportVM.DiscountOrderDetail = atStoreModel.DetailDiscountAmount + deliveryModel.DetailDiscountAmount + takeAwayModel.DetailDiscountAmount + cardModel.DetailDiscountAmount;
                    reportVM.TotalCash = atStoreModel.CashPayment + deliveryModel.CashPayment + takeAwayModel.CashPayment + cardModel.CashPayment;
                    reportVM.TotalOrder = atStoreModel.OrderQuantity + deliveryModel.OrderQuantity + takeAwayModel.OrderQuantity + cardModel.OrderQuantity;
                    reportVM.TotalOrderAtStore = atStoreModel.OrderQuantity;
                    reportVM.TotalOrderDelivery = deliveryModel.OrderQuantity;
                    reportVM.TotalOrderTakeAway = takeAwayModel.OrderQuantity;
                    //reportVM.TotalOrderDetail = atStoreModel.Deta + deliveryModel.OrderQuantity + takeAwayModel.OrderQuantity + cardModel.OrderQuantity;
                    reportVM.TotalOrderCard = cardModel.OrderQuantity;
                    reportVM.TotalOrderCanceled = atStoreModel.OrderCancel + deliveryModel.OrderCancel + takeAwayModel.OrderCancel + cardModel.OrderCancel;
                    reportVM.TotalOrderPreCanceled = atStoreModel.OrderPrecancel + deliveryModel.OrderPrecancel + takeAwayModel.OrderPrecancel + cardModel.OrderPrecancel;
                    reportVM.FinalAmountAtStore = atStoreModel.FinalAmount;
                    reportVM.FinalAmountTakeAway = takeAwayModel.FinalAmount;
                    reportVM.FinalAmountDelivery = deliveryModel.FinalAmount;
                    reportVM.FinalAmountCard = cardModel.FinalAmount;
                    reportVM.FinalAmountCanceled = atStoreModel.TotalAmountCanceled + deliveryModel.TotalAmountCanceled + takeAwayModel.TotalAmountCanceled + cardModel.TotalAmountCanceled;
                    reportVM.FinalAmountPreCanceled = atStoreModel.TotalAmountPreCanceled + deliveryModel.TotalAmountPreCanceled + takeAwayModel.TotalAmountPreCanceled + cardModel.TotalAmountPreCanceled;
                    
                }
                return model;
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
                return null;
            }
        }
        #endregion


    }
}
