using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using log4net;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;

namespace POS.Repository.ReportService
{

    public class ReportService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Total Repot

        //Báo cáo tổng hợp
        public StoreReportModel GenerateStoreReport(DateTime startTime, DateTime endTime, string username)
        {
            try
            {
                Stopwatch sw = new Stopwatch();

                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));

                var model = new StoreReportModel();
                model.CheckInPerson = username;
                var categories = categoryService.Get().ToList();
                var products = productService.Get(p => p.IsUsed).ToList();


                var startDate = Utils.GetStartOfDate(startTime);
                var endDate = Utils.GetEndOfDate(endTime);
                model.FromDate = startDate;
                model.ToDate = endDate;
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

                log.Info("Report View " + Utils.UtcDateTimeNow());
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
                        //List<OrderDetail> orderDetails = orderDetailService.GetOrderDetailByOrderIdWithoutCache(order.OrderId).ToList();
                        //List<OrderDetail> orderDetails = orderDetailService.GetOrderDetailByOrderIdWithoutCache(order.OrderId).ToList();
                        foreach (var orderDetail in order.OrderDetails)
                        {
                            if (orderDetail.Status != (int)OrderDetailStatusEnum.PosPreCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.PreCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.PosCancel
                                && orderDetail.Status != (int)OrderDetailStatusEnum.Cancel)
                            {
                                //var productModel = productReportModels.Find(p => p.ProductId == orderDetail.ProductId);
                                var productModel = productReportModels.FirstOrDefault(p => p.ProductCode == orderDetail.ProductCode);
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
                                log.Info("-----------------");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    log.Error("GenerateStoreReport" + ex);
                }

                try
                {
                    var listProducts = products.Select(p => new Tuple<string, int>(p.Code, p.CatID));

                    foreach (var category in categories)
                    {
                        //Lay tat ca ProductID cua category
                        var categoryProductId = listProducts.Where(p => p.Item2 == category.Code).Select(p => p.Item1).ToList();

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
                    log.Error("GenerateStoreReport" + ex);
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
                    .Where(b => b.Type == (int)PaymentTypeEnum.Cash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                atStoreModel.MembershipPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                atStoreModel.CreditCardPayment = atStoreOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Card).Sum(c => c.Amount));


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
                        .Where(b => b.Type == (int)PaymentTypeEnum.Cash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                takeAwayModel.MembershipPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                        .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                takeAwayModel.CreditCardPayment = takeAwayOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                        .Where(b => b.Type == (int)PaymentTypeEnum.Card).Sum(c => c.Amount));


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
                    .Where(b => b.Type == (int)PaymentTypeEnum.Cash).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ thành viên
                deliveryModel.MembershipPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.MemberPayment).Sum(c => c.Amount));

                //Tổng thanh toán bằng thẻ tín dụng
                deliveryModel.CreditCardPayment = deliveryOrder.Where(a => a.OrderStatus == (int)OrderStatusEnum.Finish
                    || a.OrderStatus == (int)OrderStatusEnum.PosFinished).Sum(a => a.Payments
                    .Where(b => b.Type == (int)PaymentTypeEnum.Card).Sum(c => c.Amount));


                model.DeliveryReport = deliveryModel;
                #endregion

                Debug.WriteLine("Report:", sw.ElapsedMilliseconds);
                sw.Reset();
                return model;
            }
            catch
            {
                return null;
            }
        }
        #endregion


    }
}
