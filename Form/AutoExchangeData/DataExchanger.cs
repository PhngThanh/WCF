using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoExchangeData;
using POS.Service;
using POS.Service.AccountService;
using POS.Service.CustomerService;
using POS.Service.OrderService;
using POS.Service.ProductService;
using POS.Data;
using System.Configuration;
using System.Threading;
using POS.Service.StoreService;
using log4net;

namespace AutoExchangeData
{
    public class DataExchanger
    {

        private static readonly string ServerUri = ConfigurationManager.AppSettings["api.Server.Uri"];
        private static readonly string StoreId = ConfigurationManager.AppSettings["storeId"];
        private static readonly string Token = ConfigurationManager.AppSettings["server.Token"];

        private static readonly ILog log = LogManager.GetLogger(typeof(Service1));

        // Order Service Locker
        public static object OrderServiceLocker = new object();

        //Đẩy order phat sinh tai cua hang từ POS lên server
        //public static async Task SendStoreOrderToServer(List<OrderModel> orders)
        public static async Task SendStoreOrderToServer()
        {
            //Call wepApi
            log.Info("Test");
            log.Info("Đẩy lên: "+ ServerUri);
            log.Info("Đẩy lên: " + StoreId);
            log.Info("Đẩy lên: " + Token);

            using (var client = new HttpClient())
            {
                var orderService = new OrderService();
                int storeId = Convert.ToInt32(StoreId);

                List<OrderModel> orders = new List<OrderModel>();
                var listOrder = orderService.GetOrders().Where(a => (a.OrderStatus == (int)OrderStatusEnum.PosFinished
                    || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel
                    || a.OrderStatus == (int)OrderStatusEnum.PosCancel) && a.OrderCode != null).ToList();
                foreach (var item in listOrder)
                {
                    var order = DataConverter.ConvertOrderModel(item, storeId);
                    orders.Add(order);
                }

                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                foreach (var orderModel in orders)
                {

                    HttpResponseMessage response = await client.PostAsJsonAsync<OrderModel>("OrderApi/SendOrderToServer", orderModel);
                    log.Info("Đẩy lên(Resposse): " + response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        OrderStatusModel orderStatus = await response.Content.ReadAsAsync<OrderStatusModel>();

                        var checkOrder = orderService.GetOrderByInvoiceId(orderStatus.InvoiceId);
                        checkOrder.OrderStatus = orderStatus.OrderStatus;
                        checkOrder.DeliveryStatus = orderStatus.DeliveryStatus;
                        checkOrder.CheckInPerson = orderStatus.CheckInPerson;
                        // Lock orderService de create / edit order
                        orderService.EditOrder(checkOrder);

                    }
                }
            }
        }

        #region Delivery Order
        //Danh rieng cho Delivery Order
        public static async Task UpdateDeliveryOrders(List<OrderStatusModel> orderStatusList)
        {
            var orderService = new OrderService();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                foreach (var orderStatus in orderStatusList)
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("OrderApi/ChangeStatusOrder", orderStatus);
                    if (response.IsSuccessStatusCode)
                    {
                        OrderStatusModel orderOnline = await response.Content.ReadAsAsync<OrderStatusModel>();


                        var order = orderService.GetOrderByInvoiceId(orderOnline.InvoiceId);

                        //Trường hợp giao hàng thành công
                        if (orderOnline.OrderStatus == (int)OrderStatusEnum.Finish &&
                            orderOnline.DeliveryStatus == (int)DeliveryStatus.Finish)
                        {
                            //Trạng thái order POS => Finish
                            order.OrderStatus = (int)OrderStatusEnum.Finish;
                        }

                        //Trường hợp giao hàng không thành công
                        else if (orderOnline.OrderStatus == (int)OrderStatusEnum.Cancel &&
                            orderOnline.DeliveryStatus == (int)DeliveryStatus.Fail)
                        {
                            order.OrderStatus = (int)OrderStatusEnum.Cancel;
                            order.DeliveryStatus = (int)DeliveryStatus.Fail;
                        }

                        //Trường hợp cửa hàng tứ chối đơn hàng
                        else if (orderOnline.OrderStatus == (int)OrderStatusEnum.Processing &&
                            orderOnline.DeliveryStatus == (int)DeliveryStatus.PosRejected)
                        {
                            order.OrderStatus = (int)OrderStatusEnum.PreCancel;
                            order.DeliveryStatus = (int)DeliveryStatus.PosRejected;
                        }

                        //Trường hợp đơn hàng hủy trước khi chế biến
                        else if (orderOnline.OrderStatus == (int)OrderStatusEnum.PreCancel &&
                            orderOnline.DeliveryStatus == (int)DeliveryStatus.PreCancel)
                        {
                            order.OrderStatus = (int)OrderStatusEnum.PreCancel;
                            order.DeliveryStatus = (int)DeliveryStatus.PreCancel;
                        }

                        //Trường hợp đơn hàng hủy sau khi chế biến
                        else if (orderOnline.OrderStatus == (int)OrderStatusEnum.Cancel &&
                            orderOnline.DeliveryStatus == (int)DeliveryStatus.Cancel)
                        {
                            order.OrderStatus = (int)OrderStatusEnum.Cancel;
                            order.DeliveryStatus = (int)DeliveryStatus.Cancel;
                        }

                        // Lock orderService de create / edit order
                        lock (OrderServiceLocker)
                        {
                            orderService.EditOrder(order);
                        }

                    }
                }

            }
        }

        //Lấy order từ trên server
        public static async Task GetAndProcessOrderFromServer()
        {
            log.Info("Lấy xuống:" + ServerUri);
            log.Info("Lấy xuống: " + StoreId);
            log.Info("Lấy xuống: " + Token);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                MessageProcess messageProcess = new MessageProcess();
                bool isContinue = false;
                do
                {
                    // HTTP GET: Lần đầu tiên kiểm tra Queue
                    //HttpResponseMessage response = await client.GetAsync("api/message/GetMessage/494EC308-7344-41A9-9347-D05754002CFC/13");
                    HttpResponseMessage response = await client.GetAsync("api/message/GetMessage/" + Token + "/" + StoreId);
                    log.Info("Lấy xuống(Resposse): " + response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        //Dữ liệu của queue được lấy về
                        MessageSend msg = await response.Content.ReadAsAsync<MessageSend>();
                        if (msg.NotifyType != (int)NotifyMessageType.NoThing)
                        {
                            messageProcess.ProcessMessage(msg);
                            //Sau khi xử lý queue xong. Tiếp tục gọi Api để xóa queue
                            //response = await client.GetAsync("api/message/GetDone/" + Token + "/" + StoreId);
                        }
                        isContinue = msg.CheckFlag;
                    }

                } while (isContinue);
            }

        }



        #endregion

        #region Other Data
        #region Account
        //Get All Accout from webApi and Save DB
        public static async Task GetAccount()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET WebApi
                HttpResponseMessage response = await client.GetAsync("api/account/GetAccountList/" + Token + "/" + StoreId);
                if (response.IsSuccessStatusCode)
                {
                    List<Account> account = await response.Content.ReadAsAsync<List<Account>>();
                    var accountService = new AccountService();
                    var listAccount = accountService.GetAccounts().Where(a => a.IsUsed).ToList();
                    foreach (var item in listAccount)
                    {
                        //Delete account in DB
                        item.IsUsed = false;
                        accountService.DeleteAccount(item.AccountId);
                    }
                    //Excute Database
                    foreach (var item in account)
                    {
                        //Add account into DB
                        accountService.CreateAccount(item);
                    }
                }
            }
        }

        #endregion

        

        #region Store Info
        public static async Task GetStoreInfo()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET WebApi
                HttpResponseMessage response = await client.GetAsync("api/store/GetStore/" + Token + "/" + StoreId);
                if (response.IsSuccessStatusCode)
                {
                    StoreModel storeModel = await response.Content.ReadAsAsync<StoreModel>();
                    var storeService = new StoreService();

                    var stores = storeService.GetStores().Where(a => a.IsUsed);

                    foreach (var item in stores)
                    {
                        //Delete account in DB
                        item.IsUsed = false;
                        storeService.EditStore(item);
                    }

                    //Excute Database
                    var store = new Store()
                    {
                        StoreCode = storeModel.StoreCode,
                        Type = storeModel.Type,
                        IsUsed = storeModel.IsUsed,
                        Address = storeModel.Address,
                        CreateDate = storeModel.CreateDate,
                        Email = storeModel.Email,
                        Fax = storeModel.Fax,
                        Lat = storeModel.Lat,
                        Lon = storeModel.Lon,
                        Name = storeModel.Name,
                        Phone = storeModel.Phone,
                        ReportDate = storeModel.ReportDate,
                        ShortName = storeModel.ShortName,
                        isAvailable = storeModel.IsAvailable
                    };
                    //Add account into DB
                    storeService.CreateStore(store);
                }
            }
        }
        #endregion

        #region Order
        public static async Task GetOrder(int rentId)
        {
            var orderService = new OrderService();
            var orderDetailService = new OrderDetailService();
            var customerService = new CustomerService();
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET WebApi Product
                HttpResponseMessage response = await client.GetAsync("api/message/GetOrder/" + Token + "/" + rentId);
                if (response.IsSuccessStatusCode)
                {
                    //OrderOnlineModel orderOnline = await response.Content.ReadAsAsync<OrderOnlineModel>();
                    OrderModel orderOnline = await response.Content.ReadAsAsync<OrderModel>();
                    //var customer = new Customer()
                    //{
                    //    CustomerName = orderOnline.CustomerInfo.CustomerName,
                    //    Address = orderOnline.CustomerInfo.Address,
                    //    Email = orderOnline.CustomerInfo.Email,
                    //    PhoneNumber = orderOnline.CustomerInfo.CustomerPhone
                    //};
                    var orderPos = orderService.GetOrderByInvoiceId(orderOnline.OrderCode);
                    if (orderPos == null)
                    {
                        var order = new Order()
                        {
                            CheckInDate = orderOnline.CheckInDate,
                            TotalAmount = orderOnline.TotalAmount,
                            Discount = orderOnline.Discount,
                            DiscountOrderDetail = orderOnline.DiscountOrderDetail,
                            FinalAmount = orderOnline.FinalAmount,
                            OrderStatus = orderOnline.OrderStatus,
                            OrderType = orderOnline.OrderType,
                            CheckInPerson = orderOnline.CheckInPerson,
                            IsFixedPrice = orderOnline.IsFixedPrice,
                            SourceID = orderOnline.SourceID,
                            OrderCode = orderOnline.OrderCode,
                            DeliveryStatus = orderOnline.DeliveryStatus,
                            DeliveryAddress = orderOnline.DeliveryAddress == null ? "" : orderOnline.DeliveryAddress,
                            DeliveryCustomer = orderOnline.DeliveryCustomer == null ? "" : orderOnline.DeliveryCustomer,
                            DeliveryPhone = orderOnline.DeliveryPhone == null ? "" : orderOnline.DeliveryPhone,
                            GroupPaymentStatus = 0 //Tạm thời để vậy
                        };
                        foreach (var item in orderOnline.OrderDetailMs)
                        {
                            var orderDetail = new OrderDetail()
                            {
                                ProductId = item.ProductId,
                                ProductName = item.ProductName,
                                UnitPrice = item.UnitPrice,
                                Quantity = item.Quantity,
                                ItemQuantity = 0,
                                ProductCode = item.ProductCode,
                                TotalAmount = item.TotalAmount,
                                FinalAmount = item.FinalAmount,
                                Discount = item.Discount,
                                OrderDate = item.OrderDate,
                                Status = item.Status,
                                ProductType = item.ProductType
                            };
                            order.OrderDetails.Add(orderDetail);
                        }
                        //customerService.CreateCustomer(customer);

                        // Lock orderService de create / edit order
                        lock (OrderServiceLocker)
                        {
                            orderService.CreateOrder(order);
                        }

                        response = await client.GetAsync("api/message/GetDone/" + Token + "/" + StoreId);
                    }
                    else
                    {
                        orderPos.OrderStatus = (int)OrderStatusEnum.New;
                        orderPos.DeliveryStatus = (int)DeliveryStatus.Assigned;

                        // Lock orderService de create / edit order
                        lock (OrderServiceLocker)
                        {
                            orderService.EditOrder(orderPos);
                        }

                        response = await client.GetAsync("api/message/GetDone/" + Token + "/" + StoreId);
                    }
                }
            }
        }


        #endregion
        #endregion

    }
}
