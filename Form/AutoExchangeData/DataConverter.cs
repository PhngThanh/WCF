using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoExchangeData;
using POS.Data;
using POS.Service;

namespace AutoExchangeData
{
    public class DataConverter
    {
        public static Order ConvertOrder(OrderModel model)
        {
            var order = new Order()
            {
                OrderId = model.OrderId,
                OrderCode = model.OrderCode,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                ApproveDate = model.ApproveDate,
                TotalAmount = model.TotalAmount,
                Discount = model.Discount,
                DiscountOrderDetail = model.DiscountOrderDetail,
                FinalAmount = model.FinalAmount,
                OrderStatus = model.OrderStatus,
                OrderType = model.OrderType,
                Notes = model.Notes,
                FeeDescription = model.FeeDescription,
                CheckInPerson = model.CheckInPerson,
                CheckOutPerson = model.CheckOutPerson,
                ApprovePerson = model.ApprovePerson,
                CustomerID = model.CustomerID,
                SourceID = model.SourceID,
                TableId = model.TableId,
                IsFixedPrice = model.IsFixedPrice,
                LastRecordDate = model.LastRecordDate,
                ServedPerson = model.ServedPerson,
                DeliveryAddress = model.DeliveryAddress,
                DeliveryStatus = model.DeliveryStatus,
                DeliveryPhone = model.DeliveryPhone,
                DeliveryCustomer = model.DeliveryCustomer,
                VAT = model.VAT,
                VATAmount = model.VATAmount,
                NumberOfGuest = model.NumberOfGuest,
                TotalInvoicePrint = model.NumberOfGuest,
                Att1 = model.Att1,
                Att2 = model.Att2,
                Att3 = model.Att3,
                Att4 = model.Att4,
                Att5 = model.Att5,
            };
            foreach (var item in model.OrderDetailMs)
            {
                var orderD = ConvertOrderDetail(item);
                order.OrderDetails.Add(orderD);
            }

            foreach (var item in model.PaymentMs)
            {
                var paymentD = ConvertPayment(item);
                order.Payments.Add(paymentD);
            }
            return order;
        }

        public static OrderModel ConvertOrderModel(Order order, int storeId)
        {
            var model = new OrderModel()
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                CheckInDate = order.CheckInDate,
                CheckOutDate = order.CheckOutDate,
                ApproveDate = order.ApproveDate,
                TotalAmount = order.TotalAmount,
                Discount = order.Discount,
                DiscountOrderDetail = order.DiscountOrderDetail,
                FinalAmount = order.FinalAmount,
                OrderStatus = order.OrderStatus,
                OrderType = order.OrderType,
                Notes = order.Notes,
                FeeDescription = order.FeeDescription,
                CheckInPerson = order.CheckInPerson,
                CheckOutPerson = order.CheckOutPerson,
                ApprovePerson = order.ApprovePerson,
                CustomerID = order.CustomerID,
                SourceID = order.SourceID,
                TableId = order.TableId,
                IsFixedPrice = order.IsFixedPrice,
                LastRecordDate = order.LastRecordDate,
                ServedPerson = order.ServedPerson,
                DeliveryAddress = order.DeliveryAddress,
                DeliveryStatus = order.DeliveryStatus,
                DeliveryPhone = order.DeliveryPhone,
                DeliveryCustomer = order.DeliveryCustomer,
                VAT = (int)order.VAT,
                TotalInvoicePrint = (int)order.TotalInvoicePrint,
                NumberOfGuest = (int)order.NumberOfGuest,
                VATAmount = (int)order.VATAmount,
                StoreId = storeId,
                Att1 = order.Att1,
                Att2 = order.Att2,
                Att3 = order.Att3,
                Att4 = order.Att4,
                Att5 = order.Att5,
            };
            foreach (var item in order.OrderDetails)
            {
                if (item.Status == (int)OrderDetailStatusEnum.PosFinished)
                {
                    var orderDetailM = ConvertOrderDetailModel(item);
                    model.OrderDetailMs.Add(orderDetailM);
                }
            }

            foreach (var item in order.Payments)
            {
                var paymentM = ConvertPaymentModel(item);
                model.PaymentMs.Add(paymentM);
            }
            return model;
        }

        public static OrderDetail ConvertOrderDetail(OrderDetailModel model)
        {
            var orderDetail = new OrderDetail()
            {
                OrderDetailID = model.OrderDetailID,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                ProductCode = model.ProductCode,
                ProductName = model.ProductName,
                FinalAmount = model.FinalAmount,
                TotalAmount = model.TotalAmount,
                Discount = model.Discount,
                Quantity = model.Quantity,
                OrderDate = model.OrderDate,
                Status = model.Status,
                Notes = model.Notes,
                TaxValue = model.TaxValue,
                UnitPrice = model.UnitPrice,
                ProductType = model.ProductType,
                ParentId = model.ParentId,
                ProductOrderType = model.ProductOrderType,
                ItemQuantity = model.ItemQuantity,
            };
            return orderDetail;
        }

        public static OrderDetailModel ConvertOrderDetailModel(OrderDetail orderDetail)
        {
            var model = new OrderDetailModel()
            {
                OrderDetailID = orderDetail.OrderDetailID,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                ProductCode = orderDetail.ProductCode,
                ProductName = orderDetail.ProductName,
                FinalAmount = orderDetail.FinalAmount,
                TotalAmount = orderDetail.TotalAmount,
                Discount = orderDetail.Discount,
                Quantity = orderDetail.Quantity,
                OrderDate = orderDetail.OrderDate,
                Status = orderDetail.Status,
                Notes = orderDetail.Notes,
                TaxValue = orderDetail.TaxValue,
                UnitPrice = orderDetail.UnitPrice,
                ProductType = orderDetail.ProductType,
                ParentId = orderDetail.ParentId,
                ProductOrderType = orderDetail.ProductOrderType,
                ItemQuantity = orderDetail.ItemQuantity,
            };
            return model;
        }

        public static Payment ConvertPayment(PaymentModel paymentModel)
        {
            var model = new Payment()
            {
                PaymentID = paymentModel.PaymentID,
                Amount = paymentModel.Amount,
                FCAmount = paymentModel.FCAmount,
                CurrencyCode = paymentModel.CurrencyCode,
                Notes = paymentModel.Notes,
                OrderId = paymentModel.OrderId,
                PayTime = paymentModel.PayTime,
                Status = paymentModel.Status,
                Type = paymentModel.Type
            };
            return model;
        }

        public static PaymentModel ConvertPaymentModel(Payment payment)
        {
            var model = new PaymentModel()
            {
                PaymentID = payment.PaymentID,
                Amount = payment.Amount,
                FCAmount = payment.FCAmount,
                CurrencyCode = payment.CurrencyCode,
                Notes = payment.Notes,
                OrderId = payment.OrderId,
                PayTime = payment.PayTime,
                Status = payment.Status,
                Type = payment.Type
            };
            return model;
        }

    }
}
