using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Interface2;
using POSSql.Data;

namespace POS.PrintManager
{
    public class ReportModel
    {
        public List<ProductStatistic> ProductItems { get; set; }
        public int TotalDiscount { get; set; }
        public int HotCount { get; set; }
        public int IceCount { get; set; }
        public int OtherCount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsRangeReport { get; set; }
     
        public OrdersStatistic OrdersStatistic { get; set; }

        public void Init(List<Order> orders)
        {
            ProductItems = new List<ProductStatistic>();
            OrdersStatistic = new OrdersStatistic();

            // Read all orders.
            foreach (var order in orders)
            {
                OrdersStatistic.OrderQuantity++;
                OrdersStatistic.OrderTotal += order.TotalAmount;
                TotalDiscount += order.Discount;
                switch ((OrderTypeEnum)order.OrderType)
                {
                    case OrderTypeEnum.AtStore:
                        OrdersStatistic.AtStoreQuantity++;
                        OrdersStatistic.AtStoreTotal += order.OrderPayment.FinalPayment;
                        break;
                    case OrderTypeEnum.TakeAway:
                        OrdersStatistic.TakeAwayQuantity++;
                        OrdersStatistic.TakeAwayTotal += order.OrderPayment.FinalPayment;
                        break;
                    case OrderTypeEnum.Delivery:
                        if ((order.OrderStatus == (int)OrderStatusEnum.Finish) || (order.DeliveryStatus == (int)DeliveryStatus.PosAccepted))
                        {
                            OrdersStatistic.DeliveryDoneQuantity++;
                            OrdersStatistic.DeliveryDoneTotal += order.OrderPayment.FinalPayment;
                        }
                        if (order.OrderStatus == OrderStatusEnum.Cancel)
                        {
                            OrdersStatistic.DeliveryCancelQuantity++;
                            OrdersStatistic.DeliveryCancelTotal += order.OrderPayment.FinalPayment;
                        }
                        break;
                }

                foreach (var orderDetail in order.OrderDetails)
                {
                    AddToList(orderDetail, (OrderTypeEnum)order.OrderType, (OrderStatusEnum) order.OrderStatus);
                }
            }
        }
        private void AddToList(OrderDetail orderDetail, OrderTypeEnum orderType, OrderStatusEnum rentStatus)
        {
            var item = ProductItems.FirstOrDefault(c => c.ProductId == orderDetail.ProductId) ?? new ProductStatistic
            {
                ProductId = orderDetail.ProductId,
               // ProductName = orderDetail.ProductName,
            };

            //if (!ProductItems.Contains(item))
            //{
            //    ProductItems.Add(item);
            //    item.Price = orderDetail.FinalAmount;
            //    item.ProductCode = orderDetail.ProductId;
            //}
            //item.Quantity += orderDetail.Quantity;
            //item.Discount += orderDetail.Discount;
            //switch (orderDetail.ProductGroup)
            //{
            //    case ProductGroup.Hot:
            //        HotCount += orderDetail.Quantity;
            //        break;
            //    case ProductGroup.Ice:
            //        IceCount += orderDetail.Quantity;
            //        break;
            //    default:
            //        OtherCount += orderDetail.Quantity;
            //        break;
            //}
            //switch (orderType)
            //{
            //    case OrderType.AtStore:
            //        item.AtStore += orderDetail.Quantity;
            //        item.Total += orderDetail.Payment;
            //        break;
            //    case DeliveryStatus.Delivery:
            //        if (rentStatus == OrderStatusEnum.Finish || rentStatus == OrderStatusEnum.PosAccepted)
            //        {
            //            item.Delivery += orderDetail.Quantity;
            //            item.Total += orderDetail.Payment;
            //        }
            //        break;
            //    case OrderTypeEnum.TakeAway:
            //        item.TakeAway += orderDetail.Quantity;
            //        item.Total += orderDetail.Payment;
            //        break;
            //}

        }
    }

    public class OrdersStatistic
    {
        public int OrderQuantity { get; set; }
        public int AtStoreQuantity { get; set; }
        public int TakeAwayQuantity { get; set; }
        public int DeliveryDoneQuantity { get; set; }
        public int DeliveryCancelQuantity { get; set; }
        public int OrderTotal { get; set; }
        public int AtStoreTotal { get; set; }
        public int TakeAwayTotal { get; set; }
        public int DeliveryDoneTotal { get; set; }
        public int DeliveryCancelTotal { get; set; }
    }

    public class ProductStatistic
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int AtStore { get; set; }
        public int TakeAway { get; set; }
        public int Delivery { get; set; }
        public string ProductCode { get; set; }


        public ProductStatistic()
        {
            Total = 0;
            Quantity = 0;
            AtStore = 0;
            TakeAway = 0;
            Delivery = 0;
        }
    }
    public class PrintProduct
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }

        public PrintProduct()
        {
            Total = 0;
            Quantity = 0;
        }
    }
}
