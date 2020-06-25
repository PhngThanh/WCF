using Newtonsoft.Json;
using POS.ExchangeData;
using POS.Repository;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FixBugProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            StoreInfo = StoreInfoManager.GetStoreInfo(true);
            SendStoreOrderToServer();
        }

        private static void Log(string text)
        {
            File.WriteAllText("temp-log.txt", text + "\r\n");
        }

        private static StoreInfo StoreInfo { get; set; }
        private static void SendStoreOrderToServer()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                int storeId = Convert.ToInt32(int.Parse(StoreInfo.StoreId));

                //PosConfig = StoreInfoManager.GetPosConfig(true);
                var start = DateTime.ParseExact(ConfigurationManager.AppSettings["start"], "dd/MM/yyyy", null);
                var end = DateTime.ParseExact(ConfigurationManager.AppSettings["start"], "dd/MM/yyyy", null).AddDays(1);

                var dataOrder = orderService
                    .Get(o => !string.IsNullOrEmpty(o.OrderCode)
                            && (/*o.OrderStatus == (int)OrderStatusEnum.PosFinished*/
                                o.OrderStatus == (int)OrderStatusEnum.Finish
                                || o.OrderStatus == (int)OrderStatusEnum.Cancel
                                || o.OrderStatus == (int)OrderStatusEnum.Processing
                                //|| o.OrderStatus == (int)OrderStatusEnum.PosPreCancel
                                //|| o.OrderStatus == (int)OrderStatusEnum.PosCancel
                                /*|| (o.OrderStatus == (int)OrderStatusEnum.PosProcessing*/))
                                .Where(o => o.CheckInDate >= start && o.CheckInDate < end)
                    .OrderByDescending(o => o.CheckInDate)
                    .AsEnumerable();

                var listOrder = dataOrder.ToList();
                var orders = new List<OrderModel>();

                try
                {
                    foreach (var item in listOrder)
                    {
                        var order = DataConverter.ConvertOrderModel(item, storeId);
                        orders.Add(order);
                    }
                }
                catch (Exception ex)
                {
                    Log("SendStoreOrderToServer(ConvertOrderModel) - " + ex);
                }

                client.BaseAddress = new Uri(StoreInfo.ServerUri); //fix new: ...
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    foreach (var orderModel in orders)
                    {
                        if (orderModel.CustomerID == 0) orderModel.CustomerID = null;
                        HttpResponseMessage response = client.PostAsJsonAsync("OrderApi/SendOrderToServer", orderModel).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            //OrderStatusModel orderStatus = response.Content.ReadAsAsync<OrderStatusModel>().Result;

                            //if (orderStatus.OrderStatus > 0)
                            //{
                            //    var checkOrder = orderService.GetOrderByOrderCode(orderStatus.InvoiceId);

                            //    checkOrder.OrderStatus = orderStatus.OrderStatus;
                            //    checkOrder.DeliveryStatus = orderStatus.DeliveryStatus;
                            //    checkOrder.CheckInPerson = orderStatus.CheckInPerson;

                            //    orderService.Update(checkOrder);
                            //}

                            Log("Send StoreOrder " + orderModel.OrderCode + " to server - "
                                + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                        }
                        else
                        {
                            Log(response.Content.ToString());
                            Thread.Sleep(5000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("An error occurred while sending the request"))
                    {
                        Log("Can't connect to server !!! --- "
                            + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    }
                    else if (ex.Message.Contains("An exception occurred during a Ping request"))
                    {
                        Log("Internet problem !!! --- "
                            + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    }
                    else
                    {
                        Log("SendStoreOrderToServer - " + ex);
                    }
                }
            }
        }
    }
}
