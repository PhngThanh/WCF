using System;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;
using POS.Repository.ViewModels;
using POS.Repository.Entities.Repositories;
using AutoMapper;

namespace POS.Repository.Entities.Services
{
    public partial interface IOrderService
    {
        Order GetOrderByOrderCode(string invoiceId);
        int CreateOrder(Order order);
        int UpdateOrder(OrderEditViewModel orderEditViewModel);
        IEnumerable<Order> GetOrderByDate(DateTime startTime, DateTime endTime);
        List<Order> GetProcessingOrder(int pageIndex, int pageSize);
        List<Order> GetAllProcessingOrder();
        //void EditListOrderFromServer(List<OrderStatusModel> orders);
    }

    public partial class OrderService
    {
        public Order GetOrderByOrderCode(string code)
        {
            return this.FirstOrDefault(a => a.OrderCode == code);
        }

        public int CreateOrder(Order order)
        {
            using (TransactionScope scope =
                new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                repository.Add(order);
                repository.Save();

                UpdateOrderDetailId(order);

                repository.Edit(order);
                repository.Save();

                scope.Complete();
                return order.OrderId;
            }
        }

        /// <summary>
        /// Update Order
        /// </summary>
        public int UpdateOrder(OrderEditViewModel orderEditViewModel)
        {
            var order = repository.FirstOrDefault(o => o.OrderId == orderEditViewModel.OrderId);
            var needRefresh = false;

            //Remove và load lại order service
            if (order != null)
            {
                //Lock
                using (TransactionScope scope =
                    new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
                {
                    needRefresh = RemoveOldEntities(orderEditViewModel, order);

                    if (needRefresh)
                    {
                        ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                        order = repository.FirstOrDefault(o => o.OrderId == orderEditViewModel.OrderId);
                    }
                    scope.Complete();   //Unlock
                }

                if (order != null)
                {
                    //Lock
                    using (TransactionScope scope =
                        new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
                    {
                        UpdateEntities(orderEditViewModel, order);

                        repository.Edit(order);
                        repository.Save();

                        UpdateOrderDetailId(order);

                        repository.Edit(order);
                        repository.Save();

                        scope.Complete();   //Unlock
                        return order.OrderId;
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// Update Order without change number of orderdetail or payment
        /// </summary>
        public int UpdateOrder(Order order)
        {
            if (order != null)
            {
                //Lock
                using (TransactionScope scope =
                    new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead }))
                {
                    repository.Edit(order);
                    repository.Save();

                    scope.Complete();   //Unlock
                    return order.OrderId;
                }
            }
            return 0;
        }

        //public void EditListOrderFromServer(List<OrderStatusModel> orders)
        //{
        //    foreach (var item in orders)
        //    {
        //        var order = repository.FirstOrDefault(a => a.OrderCode == item.InvoiceId);

        //        if (order != null)
        //        {
        //            order.OrderStatus = item.OrderStatus;
        //            order.DeliveryStatus = item.DeliveryStatus;
        //            order.CheckInPerson = item.CheckInPerson;

        //            repository.Edit(order);
        //        }
        //    }

        //    Save();
        //}

        public IEnumerable<Order> GetOrderByDate(DateTime startTime, DateTime endTime)
        {
            // TODO: review this code
            var orderRepository = new OrderRepository(ServiceManager.GetDbEntities());
            var orders = orderRepository.GetOrderReportViewModels(startTime, endTime);
            return orders;
        }

        public List<Order> GetProcessingOrder(int pageIndex, int pageSize)
        {
            return repository.Get(o => o.OrderStatus == (int)OrderStatusEnum.PosProcessing).AsEnumerable().
                Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public List<Order> GetAllProcessingOrder()
        {
            return repository.Get(o => (o.OrderStatus == (int)OrderStatusEnum.PosProcessing || o.OrderStatus == (int)OrderStatusEnum.Processing)
                                    && (o.OrderDetails.Any(d => d.Status == (int)OrderDetailStatusEnum.Processing)))
                                .AsEnumerable()
                                .ToList();
        }





        /// <summary>
        /// Check lại parentId của extra orderdetail,
        /// Check lại tmpId của mapping,
        /// Check lại orderId của mapping,
        /// Check lại orderdetailId của mapping,
        /// </summary>
        private void UpdateOrderDetailId(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                if (orderDetail.ParentId != null && orderDetail.ParentId > -1)
                {
                    var parentOrderDetail = order.OrderDetails.FirstOrDefault(od => od.TmpDetailId == orderDetail.ParentId);
                    if (parentOrderDetail != null)
                    {
                        orderDetail.ParentId = parentOrderDetail.OrderDetailID;
                    }
                }
                if (orderDetail.OrderPromotionMappingId != null)
                {
                    var mapping = order.OrderPromotionMappings.FirstOrDefault(m => m.TmpMappingId == orderDetail.OrderPromotionMappingId);
                    if (mapping != null)
                    {
                        orderDetail.OrderPromotionMappingId = mapping.Id;
                    }
                    else
                    {
                        orderDetail.OrderPromotionMappingId = null;
                    }
                }
                if (orderDetail.OrderDetailPromotionMappingId != null)
                {
                    OrderDetailPromotionMapping mapping = null;
                    foreach (var od in order.OrderDetails)
                    {
                        mapping = od.OrderDetailPromotionMappings.FirstOrDefault(m => m.TmpMappingId == orderDetail.OrderDetailPromotionMappingId);
                        if (mapping != null) break;
                    }
                    if (mapping != null)
                    {
                        orderDetail.OrderDetailPromotionMappingId = mapping.Id;
                    }
                    else
                    {
                        orderDetail.OrderDetailPromotionMappingId = null;
                    }
                }
            }

            foreach (var mapping in order.OrderPromotionMappings)
            {
                mapping.TmpMappingId = mapping.Id;
            }
            foreach (var orderDetail in order.OrderDetails)
            {
                foreach (var mapping in orderDetail.OrderDetailPromotionMappings)
                {
                    mapping.TmpMappingId = mapping.Id;
                }
                orderDetail.TmpDetailId = orderDetail.OrderDetailID;
            }
        }

        private bool RemoveOldEntities(OrderEditViewModel orderEditViewModel, Order order)
        {
            Mapper.Map<OrderEditViewModel, Order>(orderEditViewModel, order);

            var removeOd = RemoveOrderDetails(orderEditViewModel.getOrderDetailEditViewModels(), order.OrderDetails);
            var removeP = RemovePayments(orderEditViewModel.getPaymentEditViewModels(), order.Payments);
            var removePm = RemoveOrderPromotionMappings(orderEditViewModel.OrderPromotionMappingEditViewModels, order.OrderPromotionMappings);

            if (removeOd || removeP || removePm) return true;
            else return false;
        }

        private void UpdateEntities(OrderEditViewModel orderEditViewModel, Order order)
        {
            //orderEditViewModel.Att1 = "testMapper2";
            Mapper.Map<OrderEditViewModel, Order>(orderEditViewModel, order);

            UpdateOrderDetails(orderEditViewModel.OrderDetailEditViewModels, order.OrderDetails, order.OrderId);
            UpdatePayments(orderEditViewModel.getPaymentEditViewModels(), order.Payments, order.OrderId);
            UpdateOrderPromotionMappings(orderEditViewModel.OrderPromotionMappingEditViewModels, order.OrderPromotionMappings, order.OrderId);
        }


        private bool RemoveOrderDetails(List<OrderDetailEditViewModel> orderDetailEditViewModels, ICollection<OrderDetail> orderDetails)
        {
            var toRemoveList = new List<OrderDetail>();
            bool deleted = false;
            foreach (var orderDetail in orderDetails)
            {
                var orderDetailEditViewModel =
                        orderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == orderDetail.OrderDetailID);

                if (orderDetailEditViewModel == null)
                {
                    // Có cũ nhưng mới không -> Remove
                    toRemoveList.Add(orderDetail);
                    deleted = RemoveOrderDetailPromotionMappings(null, orderDetail.OrderDetailPromotionMappings);
                }
                else
                {
                    deleted = RemoveOrderDetailPromotionMappings(orderDetailEditViewModel.OrderDetailPromotionMappingEditViewModels, orderDetail.OrderDetailPromotionMappings);
                }
            }

            if (toRemoveList.Any())
            {
                var orderDetailService = ServiceManager.GetService<OrderDetailService>(typeof(OrderDetailRepository));
                orderDetailService.RemoveRange(toRemoveList);
                return true;
            }
            if (deleted) return true;
            else return false;
        }
        private bool RemovePayments(List<PaymentEditViewModel> paymentEditViewModels, ICollection<Payment> payments)
        {
            var toRemoveList = new List<Payment>();
            foreach (var payment in payments)
            {
                var paymentEditViewModel =
                        paymentEditViewModels.FirstOrDefault(p => p.PaymentID == payment.PaymentID);

                if (paymentEditViewModel == null)
                {
                    // Có cũ nhưng mới không -> Remove
                    toRemoveList.Add(payment);
                }
            }

            if (toRemoveList.Any())
            {
                var paymentService = ServiceManager.GetService<PaymentService>(typeof(PaymentRepository));
                paymentService.RemoveRange(toRemoveList);
                return true;
            }
            return false;
        }
        private bool RemoveOrderPromotionMappings(List<OrderPromotionMappingEditViewModel> orderPromotionMappingEditViewModels, ICollection<OrderPromotionMapping> orderPromotionMappings)
        {
            var toRemoveList = new List<OrderPromotionMapping>();
            foreach (var mapping in orderPromotionMappings)
            {
                var mappingEditViewModels =
                        orderPromotionMappingEditViewModels.FirstOrDefault(m => m.Id == mapping.Id);

                if (mappingEditViewModels == null)
                {
                    // Có cũ nhưng mới không -> Remove
                    toRemoveList.Add(mapping);
                }
            }


            if (toRemoveList.Any())
            {
                var mappingService = ServiceManager.GetService<OrderPromotionMappingService>(typeof(OrderPromotionMappingRepository));
                mappingService.RemoveRange(toRemoveList);
                return true;
            }
            return false;
        }
        private bool RemoveOrderDetailPromotionMappings(List<OrderDetailPromotionMappingEditViewModel> orderDetailPromotionMappingEditViewModels, ICollection<OrderDetailPromotionMapping> orderDetailPromotionMappings)
        {
            var toRemoveList = new List<OrderDetailPromotionMapping>();
            foreach (var mapping in orderDetailPromotionMappings)
            {
                if (orderDetailPromotionMappingEditViewModels != null)
                {
                    var mappingEditViewModels =
                            orderDetailPromotionMappingEditViewModels.FirstOrDefault(m => m.Id == mapping.Id);

                    if (mappingEditViewModels == null)
                    {
                        // Có cũ nhưng mới không -> Remove
                        toRemoveList.Add(mapping);
                    }
                }
                else
                {
                    toRemoveList.Add(mapping);
                }
            }

            if (toRemoveList.Any())
            {
                var mappingService = ServiceManager.GetService<OrderDetailPromotionMappingService>(typeof(OrderDetailPromotionMappingRepository));
                mappingService.RemoveRange(toRemoveList);
                return true;
            }
            return false;
        }

        private void UpdateOrderDetails(List<OrderDetailEditViewModel> orderDetailEditViewModels, ICollection<OrderDetail> orderDetails, int orderId)
        {
            foreach (var orderDetail in orderDetails)
            {
                var orderDetailEditViewModel =
                        orderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == orderDetail.OrderDetailID);

                if (orderDetailEditViewModel != null)
                {
                    // Đã có -> Update
                    Mapper.Map<OrderDetailEditViewModel, OrderDetail>
                        (orderDetailEditViewModel, orderDetail);
                    orderDetail.OrderId = orderId;

                    UpdateOrderDetailPromotionMappings(
                        orderDetailEditViewModel.OrderDetailPromotionMappingEditViewModels,
                        orderDetail.OrderDetailPromotionMappings, orderDetail);
                }
            }

            foreach (var orderDetailEditViewModel in orderDetailEditViewModels)
            {
                var orderDetail =
                    orderDetails.FirstOrDefault(od => od.OrderDetailID == orderDetailEditViewModel.OrderDetailID);

                if (orderDetail == null)
                {
                    // Chưa có -> Add
                    orderDetail = new OrderDetail();
                    Mapper.Map<OrderDetailEditViewModel, OrderDetail>
                        (orderDetailEditViewModel, orderDetail);
                    orderDetail.OrderId = orderId;

                    UpdateOrderDetailPromotionMappings(
                        orderDetailEditViewModel.OrderDetailPromotionMappingEditViewModels,
                        orderDetail.OrderDetailPromotionMappings, orderDetail);

                    orderDetails.Add(orderDetail);
                }
            }
        }
        private void UpdatePayments(List<PaymentEditViewModel> paymentEditViewModels, ICollection<Payment> payments, int orderId)
        {
            foreach (var payment in payments)
            {
                var paymentEditViewModel =
                        paymentEditViewModels.FirstOrDefault(p => p.PaymentID == payment.PaymentID);

                if (paymentEditViewModel != null)
                {
                    // Đã có -> Update
                    Mapper.Map<PaymentEditViewModel, Payment>
                        (paymentEditViewModel, payment);
                    payment.OrderId = orderId;
                }
            }

            foreach (var paymentEditViewModel in paymentEditViewModels)
            {
                var payment =
                    payments.FirstOrDefault(p => p.PaymentID == paymentEditViewModel.PaymentID);

                if (payment == null)
                {
                    // Chưa có -> Add
                    payment = new Payment();
                    Mapper.Map<PaymentEditViewModel, Payment>
                        (paymentEditViewModel, payment);
                    payment.OrderId = orderId;

                    payments.Add(payment);
                }
            }
        }
        private void UpdateOrderPromotionMappings(List<OrderPromotionMappingEditViewModel> mappingEditViewModels, ICollection<OrderPromotionMapping> mappings, int orderId)
        {
            foreach (var mapping in mappings)
            {
                var mappingEditViewModel =
                        mappingEditViewModels.FirstOrDefault(p => p.Id == mapping.Id);

                if (mappingEditViewModel != null)
                {
                    // Đã có -> Update
                    Mapper.Map<OrderPromotionMappingEditViewModel, OrderPromotionMapping>
                        (mappingEditViewModel, mapping);
                    mapping.OrderId = orderId;
                }
            }

            foreach (var mappingEditViewModel in mappingEditViewModels)
            {
                var mapping =
                    mappings.FirstOrDefault(p => p.Id == mappingEditViewModel.Id);

                if (mapping == null)
                {
                    // Chưa có -> Add
                    mapping = new OrderPromotionMapping();
                    Mapper.Map<OrderPromotionMappingEditViewModel, OrderPromotionMapping>
                        (mappingEditViewModel, mapping);
                    mapping.OrderId = orderId;

                    mappings.Add(mapping);
                }
            }
        }
        private void UpdateOrderDetailPromotionMappings(List<OrderDetailPromotionMappingEditViewModel> mappingEditViewModels, ICollection<OrderDetailPromotionMapping> mappings, OrderDetail orderDetail)
        {
            foreach (var mapping in mappings)
            {
                var mappingEditViewModel =
                        mappingEditViewModels.FirstOrDefault(p => p.Id == mapping.Id);

                if (mappingEditViewModel != null)
                {
                    // Đã có -> Update
                    Mapper.Map<OrderDetailPromotionMappingEditViewModel, OrderDetailPromotionMapping>
                        (mappingEditViewModel, mapping);

                    mapping.OrderDetail = orderDetail;
                    mapping.OrderDetailId = orderDetail.OrderDetailID;
                }
            }

            foreach (var mappingEditViewModel in mappingEditViewModels)
            {
                var mapping =
                    mappings.FirstOrDefault(p => p.Id == mappingEditViewModel.Id);

                if (mapping == null)
                {
                    // Chưa có -> Add
                    mapping = new OrderDetailPromotionMapping();
                    Mapper.Map<OrderDetailPromotionMappingEditViewModel, OrderDetailPromotionMapping>
                        (mappingEditViewModel, mapping);

                    mapping.OrderDetail = orderDetail;
                    mapping.OrderDetailId = orderDetail.OrderDetailID;
                    mappings.Add(mapping);
                }
            }
        }
    }
}
