using System;
using System.Linq;
using System.Threading;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using POS.Utils;
using POS.Repository;
using POS.PrintManager;
using POS.ExchangeData;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;
using POS.Repository.ViewModels;
using POS.Repository.ViewModels.VposDTO;
using Newtonsoft.Json;

namespace AutoExchangeData
{
    public partial class Service1 : ServiceBase
    {
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static bool _isExchangerRunning = false;
        private PosConfig _posConfig;
        private StoreInfo _storeInfo;
        private static int _delayExchange = 0;
        private static bool _firstStartSendReport = true;
        public Service1()
        {
            InitializeComponent();

            _posConfig = StoreInfoManager.GetPosConfig(true);
            _storeInfo = StoreInfoManager.GetStoreInfo(true);
        }

        public void OnDebug()
        {
            //Thread t = new Thread(SendReportDate);
            //t.Start();
            OnStart(null);
        }


        protected override void OnStart(string[] args)
        {
            try
            {
                //TODO: comment for build
                //Thread tcpThread = new Thread(this.StartTcpServer);
                //tcpThread.Start();
            }
            catch (Exception ex)
            {
                //log.Error("OnStart - " + ex);
                //Program._log.SendLogError(ex);
            }
            finally
            {
                SendDataToServer();
            }
        }

        protected override void OnStop()
        {
        }

        private void SendReportDate()
        {
            try
            {
                DateReportViewModel reportVM = new DateReportViewModel();
                int sleep = 0;
                DateTime dt = DateTime.UtcNow.AddHours(7);
                DateTime start = DateTime.UtcNow.AddHours(-dt.Hour).AddMinutes(-dt.Minute);
                if (_firstStartSendReport)
                {
                    sleep = (60 - dt.Minute + 5) * 60 + (60 - dt.Second);
                }
                else
                {
                    sleep = 3600;
                }
                _firstStartSendReport = false;
                //goi report
                ReportService rs = new ReportService();
                rs.GenerateStoreReport(start, dt.AddMinutes(-dt.Minute).AddSeconds(-dt.Second), "All Staff", reportVM);
                var datereport = ServiceManager.GetService<DateReportService>(typeof(DateReportRepository));
                bool b = datereport.CreateReportAsync(reportVM).Result;
                DataExchanger.SendReportDate(reportVM).Wait();
                Thread.Sleep(sleep * 1000);

            }
            catch (Exception ex)
            {
                //Program._log.SendLogError(ex);
            }
            finally
            {
                SendReportDate();
            }
        }

        private void SendDataToServer()
        {
            try
            {
                if (!_isExchangerRunning)
                {
                    _isExchangerRunning = true;
                    while (_isExchangerRunning)
                    {
                        
                        var sleepTime = 15000;                          //15s
                        if (_delayExchange > 1) sleepTime = 300000;     //300s = 5 min 

                        if (sleepTime > 30000)
                        {
                            //log.Info("SendDataToServer delay " + sleepTime.ToString() + " - "
                            //    + UtcDateTime.Now().ToString("HH:mm:ss"));
                        }

                        Thread.Sleep(sleepTime); //so processor can rest for a while
                                                 //reduce for test !!!

                        if (DataExchanger.CheckForInternetConnection(true))
                        {
                            DataExchanger.SendStoreOrderToServer().Wait();
                            _delayExchange = _delayExchange > 0 ? _delayExchange - 1 : 0;
                        }
                        else
                        {
                            _delayExchange = _delayExchange < 3 ? _delayExchange + 1 : 3;
                        }

                        _isExchangerRunning = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("SendDataToServer - " + ex);
                //Program._log.SendLogError(ex);
                _isExchangerRunning = false;
            }
            finally
            {
                //Debug.WriteLine("Exchanger crash !!!");
                SendDataToServer();
            }
        }

        #region TCP Server for mobile
        private static string _productList = "";
        private string _orderModelListToSend = "";
        // Order Service Locker
        //public static object OrderServiceLocker = new object();
        public static List<ProductViewModel> AllProducts;
        Printer PosPrinter = new Printer();

        private void StartTcpServer()
        {
            ServiceManager.CreateAutoMapper();
            clientList = new ArrayList();
            this.SetProductListString();
            this.SetOrderModelListString();

            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
            //Load hết product
            AllProducts = ServiceManager.GetProductViewModels(productService.GetAllAvailableProducts().ToList());
            try
            {
                //We are using TCP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                                          SocketType.Stream,
                                          ProtocolType.Tcp);

                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1000);

                //Bind and listen on the given address
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(4);

                //Accept the incoming clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
            catch (Exception ex)
            {
                //Program._log.SendLogError(ex);
                MessageBox.Show(ex.Message, "SGSserverTCP Form1_Load",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //The ClientInfo structure holds the required information about every
        //client connected to the server
        private struct ClientInfo
        {
            public Socket socket; //Socket of the client
            public string strName; //Name by which the user logged into the chat room
        }

        //The collection of all clients logged into the room (an array of type ClientInfo)
        private ArrayList clientList;

        //The main socket on which the server listens to the clients
        private Socket serverSocket;

        const int bufferSize = 1024;
        byte[] byteData = new byte[bufferSize];

        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);
                var isNew = true;
                foreach (ClientInfo client in clientList)
                {
                    if (client.socket == clientSocket)
                    {
                        isNew = false;
                    }
                }
                //Start listening for more clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
                if (isNew)
                {
                    //Once the client connects then start receiving the commands from her
                    clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                new AsyncCallback(OnReceive), clientSocket);
                }

            }
            catch (Exception ex)
            {
                //Program._log.SendLogError(ex);
                MessageBox.Show(ex.Message, "SGSserverTCP OnAccept",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = (Socket)ar.AsyncState;

                try
                {
                    clientSocket.EndReceive(ar);
                    //Transform the array of bytes received from the user into an
                    //intelligent form of object Data
                    VposViewModel msgReceived = new VposViewModel(byteData);

                    //We will send this object in response the users request
                    VposViewModel msgToSend = new VposViewModel();

                    byte[] message;

                    //If the message is to login, logout, or simple text message
                    //then when send to others the type of the message remains the same
                    msgToSend.cmdCommand = msgReceived.cmdCommand;
                    if (msgReceived.strName != null)
                    {
                        string[] clientInfor = msgReceived.strName.Split('|');
                        msgToSend.strName = clientInfor[0];
                        msgReceived.strName = clientInfor[0];
                        msgReceived.strPassword = clientInfor[1];
                    }
                    switch (msgReceived.cmdCommand)
                    {
                        case Command.Login:
                            var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
                            if (accountService.CheckLogin(msgReceived.strName, msgReceived.strPassword) != null)
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.socket = clientSocket;
                                clientInfo.strName = msgReceived.strName;
                                clientList.Add(clientInfo);

                                VposViewModel ProductList = new VposViewModel();
                                ProductList.cmdCommand = Command.ProductList;
                                ProductList.strMessage = _productList;
                                byte[] msgProductListByte;
                                if (clientSocket.Connected)
                                {
                                    msgProductListByte = ProductList.ToByte();
                                    clientSocket.BeginSend(msgProductListByte, 0, msgProductListByte.Length, SocketFlags.None,
                                        new AsyncCallback(OnSend), clientSocket);
                                }

                                msgToSend.strMessage = "<<<" + msgReceived.strName + " has joined the room>>>";
                            }
                            else
                            {
                                VposViewModel msgSendToAndroid = new VposViewModel();
                                msgSendToAndroid.cmdCommand = Command.LoginFail;
                                msgSendToAndroid.strMessage = "This Username doesn't exist. Please try again!";
                                byte[] msg;
                                msg = msgSendToAndroid.ToByte();
                                if (clientSocket.Connected)
                                {
                                    clientSocket.BeginSend(msg, 0, msg.Length, SocketFlags.None,
                                        new AsyncCallback(OnSend), clientSocket);
                                }
                            }

                            //Set the text of the message that we will broadcast to all users
                            break;
                        case Command.OldOrder:
                            if (_orderModelListToSend != null)
                            {
                                VposViewModel oldOrderToAndroid = new VposViewModel();
                                oldOrderToAndroid.cmdCommand = Command.OldOrder;
                                oldOrderToAndroid.strMessage = _orderModelListToSend;
                                byte[] msgBytes;
                                msgBytes = oldOrderToAndroid.ToByte();
                                if (clientSocket.Connected)
                                {
                                    clientSocket.BeginSend(msgBytes, 0, msgBytes.Length, SocketFlags.None,
                                        new AsyncCallback(OnSend), clientSocket);
                                }
                                //msgReceived.cmdCommand = Command.ProductList;
                            }
                            break;

                        case Command.ProductList:
                            //Send product List to Android
                            VposViewModel msgProductListData = new VposViewModel();
                            msgProductListData.cmdCommand = Command.ProductList;
                            msgProductListData.strMessage = _productList;
                            byte[] msgProductList;
                            if (clientSocket.Connected)
                            {
                                msgProductList = msgProductListData.ToByte();
                                clientSocket.BeginSend(msgProductList, 0, msgProductList.Length, SocketFlags.None,
                                    new AsyncCallback(OnSend), clientSocket);
                            }
                            break;

                        case Command.OrderByTable:
                            VposViewModel orderByTableData = new VposViewModel();
                            orderByTableData.cmdCommand = Command.OrderByTable;
                            orderByTableData.strMessage = GetOrderByTable(int.Parse(msgReceived.strMessage));
                            byte[] orderToSend;
                            orderToSend = orderByTableData.ToByte();
                            if (clientSocket.Connected)
                            {
                                clientSocket.BeginSend(orderToSend, 0, orderToSend.Length, SocketFlags.None,
                                    new AsyncCallback(OnSend), clientSocket);
                            }
                            break;
                        case Command.Order:
                            var order = msgReceived.strMessage;
                            if (clientSocket.Available == 0)
                            {
                                // TODO: continue here
                                bool isSuccess = GetOrderFromClient(order);
                            }
                            else
                            {
                                byteData = new byte[1024];

                                clientSocket.BeginReceive(byteData,
                                    0,
                                    byteData.Length,
                                    SocketFlags.None,
                                    new AsyncCallback(OnReceive),
                                    byteData);
                            }
                            break;
                        case Command.Logout:

                            //When a user wants to log out of the server then we search for her 
                            //in the list of clients and close the corresponding connection

                            int nIndex = 0;
                            foreach (ClientInfo client in clientList)
                            {
                                if (client.socket == clientSocket)
                                {
                                    clientList.RemoveAt(nIndex);
                                    break;
                                }
                                ++nIndex;
                            }

                            clientSocket.Close();

                            msgToSend.strMessage = "<<<" + msgReceived.strName + " has left the room>>>";
                            message = msgToSend.ToByte();
                            break;

                        case Command.Message:

                            //Set the text of the message that we will broadcast to all users
                            msgToSend.strMessage = msgReceived.strName + ": " + msgReceived.strMessage;
                            message = msgToSend.ToByte();

                            //foreach (ClientInfo clientInfo in clientList)
                            //{
                            //    if (clientInfo.socket != clientSocket)
                            //    {
                            //        //Send the message to all users
                            //        clientInfo.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                            //            new AsyncCallback(OnSend), clientInfo.socket);
                            //    }
                            //}
                            //System.Diagnostics.Debug.Write(msgReceived.strMessage); 
                            break;

                        case Command.List:

                            //Send the names of all users in the chat room to the new user
                            msgToSend.cmdCommand = Command.List;
                            msgToSend.strName = null;
                            msgToSend.strMessage = null;

                            ////Collect the names of the user in the chat room
                            //foreach (ClientInfo client in clientList)
                            //{
                            //    //To keep things simple we use asterisk as the marker to separate the user names
                            //    msgToSend.strMessage += client.strName + "*";
                            //}

                            //message = msgToSend.ToByte();

                            ////Send the name of the users in the chat room
                            //clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                            //    new AsyncCallback(OnSend), clientSocket);
                            break;
                    }

                    //If the user is logging out then we need not listen from it
                    if (clientSocket != null)
                    {
                        if (msgReceived.cmdCommand != Command.Logout)
                        {
                            //Start listening to the message send by the user
                            clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                                new AsyncCallback(OnReceive), clientSocket);
                        }
                    }

                }
                catch (Exception ex)
                {
                    //Program._log.SendLogError(ex);
                    if (ex.Message.Equals("An established connection was aborted by the software in your host machine") ||
                       ex.Message.Equals("An existing connection was forcibly closed by the remote host"))
                    {
                        VposViewModel msgReceived = new VposViewModel(byteData);

                        //We will send this object in response the users request
                        VposViewModel msgToSend = new VposViewModel();

                        byte[] message;

                        //If the message is to login, logout, or simple text message
                        //then when send to others the type of the message remains the same
                        msgToSend.cmdCommand = msgReceived.cmdCommand;
                        int nIndex = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.socket == clientSocket)
                            {
                                clientList.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }
                        clientSocket.Close();
                        msgToSend.strMessage = "<<<" + msgReceived.strName + " has left the room>>>";
                        message = msgToSend.ToByte();
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("OnReceive - " + ex);
                //Program._log.SendLogError(ex);
            }
        }

        public string GetOrderByTable(int tableNumber)
        {
            string code = POS.InvoiceCodeGenerator.GenerateInvoiceCode();
            PosConfig posConfig = StoreInfoManager.GetPosConfig(true);
            StoreInfo storeInfo = StoreInfoManager.GetStoreInfo(true);

            string orderCode = posConfig.InvoideCodepattern.Replace("{StoreId}", storeInfo.StoreId)
                            .Replace("{StoreName}", storeInfo.TerminalName)
                            .Replace("{Code}", code);
            // If the order is not existed or the table is free to use
            var orderModel = new POS.Repository.ViewModels.VposDTO.OrderModel()
            {
                DiscountPercent = 0,
                FinalAmount = 0,
                Note = string.Empty,
                OrderDetailList = new List<OrderDetail>(),
                TableNumber = tableNumber,
                TotalAmount = 0,
                Code = orderCode,
                Status = (int)OrderStatusEnum.PosProcessing
            };

            string _orderModelByTable = "";

            var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
            var table = tableService.GetAvailableTables().FirstOrDefault(t => t.Number == tableNumber.ToString());

            if (table != null && table.Status == (int)TableStatusEnum.InUse)
            {
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var order = orderService.FirstOrDefault(o => o.OrderId == table.CurrentOrderId);

                if (order != null)
                {
                    var sortedOrderDetail = this.GetSortedOrderDetail(order);
                    var listOrderDetails = new List<POS.Repository.ViewModels.VposDTO.OrderDetail>();
                    foreach (var orderDetail in sortedOrderDetail)
                    {
                        var orderDetailMapping = new POS.Repository.ViewModels.VposDTO.OrderDetail()
                        {
                            ProductName = orderDetail.ProductName,
                            DiscountPercent = orderDetail.TotalAmount != 0 ?
                                orderDetail.Discount / orderDetail.TotalAmount : 0,
                            FinalAmount = orderDetail.FinalAmount,
                            TotalAmount = orderDetail.TotalAmount,
                            IsExtra = orderDetail.ParentId != null,
                            Note = orderDetail.Notes,
                            IsShowed = true,
                            OrderDetailId = orderDetail.OrderDetailID,
                            ProductCode = orderDetail.ProductCode,
                            Quantity = orderDetail.Quantity,
                            UnitPrice = orderDetail.UnitPrice,
                            Status = orderDetail.Status
                            
                        };

                        listOrderDetails.Add(orderDetailMapping);
                    }

                    orderModel = new POS.Repository.ViewModels.VposDTO.OrderModel()
                    {
                        DiscountPercent = order.TotalAmount != 0
                            ? order.Discount / order.TotalAmount
                            : 0,
                        FinalAmount = order.FinalAmount,
                        Note = order.Notes,
                        OrderDetailList = listOrderDetails,
                        TableNumber = int.Parse(table.Number),
                        TotalAmount = order.TotalAmount,
                        Code = order.OrderCode,
                        Status = order.OrderStatus
                    };
                }
            }

            _orderModelByTable = JsonConvert.SerializeObject(orderModel);
            return _orderModelByTable;
        }

        public bool GetOrderFromClient(string msgReceived)
        {
            int orderId = 0;
            bool isSuccess = false;

            var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
            var orderAndroid =
                JsonConvert.DeserializeObject<POS.Repository.ViewModels.VposDTO.OrderModel>(msgReceived);
            int tableId = orderAndroid.TableNumber;

            orderAndroid.Status = (int)OrderStatusEnum.PosProcessing;

            int currentMainOdId = 0;
            for (int i = 0; i < orderAndroid.OrderDetailList.Count; i++)
            {
                var od = orderAndroid.OrderDetailList[i];

                if (od.IsExtra == false)
                {
                    if (od.OrderDetailId == 0)
                    {
                        od.OrderDetailId = i;
                    }

                    od.ParentId = null;
                    currentMainOdId = od.OrderDetailId;
                }
                else
                {
                    if (od.OrderDetailId == 0)
                    {
                        od.OrderDetailId = i;
                    }

                    od.ParentId = currentMainOdId;
                }
            }

            var orderPos = orderService.GetOrderByOrderCode(orderAndroid.Code);

            if (orderPos == null)
            {
                //string code = POS.InvoiceCodeGenerator.GenerateInvoiceCode();
                PosConfig posConfig = StoreInfoManager.GetPosConfig(true);
                StoreInfo storeInfo = StoreInfoManager.GetStoreInfo(true);

                if (string.IsNullOrEmpty(orderAndroid.Code))
                {
                    string code = POS.InvoiceCodeGenerator.GenerateInvoiceCode();
                    string orderCode = posConfig.InvoideCodepattern.Replace("{StoreId}", storeInfo.StoreId)
                   .Replace("{StoreName}", storeInfo.TerminalName)
                   .Replace("{Code}", code);

                    orderAndroid.Code = orderCode;
                }


                var order = new POS.Repository.Entities.Order()
                {
                    OrderCode = orderAndroid.Code,
                    CheckInDate = UtcDateTime.Now(),
                    TotalAmount = orderAndroid.TotalAmount,
                    Discount = orderAndroid.TotalAmount - orderAndroid.FinalAmount,
                    //DiscountOrderDetail = orderOnline.DiscountOrderDetail,
                    FinalAmount = orderAndroid.FinalAmount,
                    OrderStatus = (int)OrderStatusEnum.PosProcessing,
                    OrderType = (int)OrderTypeEnum.AtStore, // hard-code, cause this mode just support AtStore now
                    CheckInPerson = "VPOS", // hard-code, waiting for Duc update model
                    IsFixedPrice = true,
                    SourceID = null,
                    DeliveryStatus = 0, // hard-code
                    DeliveryAddress = "", // hard-code
                    DeliveryCustomer = "", // hard-code
                    DeliveryPhone = "", // hard-code
                    GroupPaymentStatus = 0, //Tạm thời để vậy,
                    TableId = orderAndroid.TableNumber
                };

                foreach (var item in orderAndroid.OrderDetailList)
                {
                    var product = AllProducts.FirstOrDefault(p => p.ProductName == item.ProductName);
                    var productCode = string.Empty;

                    if (product != null)
                    {
                        productCode = product.Code;
                    }
                    //var product = AllProducts.FirstOrDefault(a => a.ProductId == Order)
                    var orderDetail = new POS.Repository.Entities.OrderDetail()
                    {
                        ProductCode = productCode,
                        ProductId = 0, // hard-code
                        ProductName = item.ProductName,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        ItemQuantity = item.Quantity,
                        TotalAmount = item.TotalAmount,
                        FinalAmount = item.FinalAmount,
                        Discount = item.TotalAmount - item.FinalAmount,
                        OrderDate = UtcDateTime.Now(),
                        Status = (int)OrderStatusEnum.PosProcessing,
                        ParentId = item.ParentId,
                        ProductType = 0, // hard-code
                        OrderGroup = 0 //Tạm thời để như vậy
                    };
                    order.DiscountOrderDetail += orderDetail.Discount;
                    order.OrderDetails.Add(orderDetail);
                }

                //customerService.CreateCustomer(customer);
                // Lock orderService de create / edit order
                //lock (OrderServiceLocker)
                //{
                //orderService.CreateOrder2(order);
                orderId = orderService.CreateOrder(order);

                if (orderId != 0)
                {
                    isSuccess = true;
                }
                //}
            }
            else
            {
                orderId = 0;

                MapOrderAndOrderAndroid(ref orderPos, ref orderAndroid);

                // Lock orderService de create / edit order
                //lock (OrderServiceLocker)
                //{
                //orderId = orderService.UpdateOrder(orderPos);
                //}

                if (orderId > 0)
                {
                    isSuccess = true;
                }
            }

            //if (orderPos != null && (orderPos.OrderStatus == (int) OrderStatusEnum.Finish ||
            //                         orderPos.OrderStatus == (int) OrderStatusEnum.PosFinished))
            //{
            //    var order = ServiceManager.GetOrderEditViewModel(orderPos);
            //    var printerCashier = _storeInfo.PrinterBill;
            //    PosPrinter.PrintBill(order, BillType.Cook, printerCashier, true);
            //}

            if (isSuccess)
            {
                try
                {
                    var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                    var tableEntity = tableService.FirstOrDefault(t => t.Id == tableId);
                    TableViewModel tableViewModel =
                        ServiceManager.GetTableViewModel(tableEntity);
                    var tableStatus = TableStatusEnum.InUse;
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

                                tableViewModel.CurrentOrderId = orderId;
                                tableViewModel.CurrentOrderDate = UtcDateTime.Now();
                            }

                            tableService.UpdateTableStatus(tableViewModel);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("GetOrderFromClient - " + ex);
                    //Program._log.SendLogError(ex);
                }
            }

            return false;
        }


        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                try
                {
                    client.EndSend(ar);
                }
                catch (Exception ex)
                {
                    //log.Error("OnSend - " + ex);
                    //Program._log.SendLogError(ex);
                    //client.Disconnect(true);
                    //client.Close();
                }
            }
            catch (Exception)
            {
            }

        }

        //Set Product List to send to Mobile
        public void SetProductListString()
        {
            var listProduct = new List<POS.Repository.ViewModels.VposDTO.Product>();

            var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));

            var allProducts = productService.GetAllAvailableProducts().ToList();
            var allCategories = categoryService.GetAvailableCategories().ToList();

            foreach (var category in allCategories)
            {
                bool blIsExtra = false;
                var productOfCate = allProducts.Where(p => p.CatID == category.Code);
                if (category.IsExtra.GetValueOrDefault() == 0)
                {
                    blIsExtra = false;
                }
                else
                {
                    blIsExtra = true;
                }

                foreach (var product in productOfCate)
                {
                    var productMapping = new POS.Repository.ViewModels.VposDTO.Product()
                    {
                        Name = product.ProductName,
                        Code = product.Code,
                        DiscountPercent = product.DiscountPercent,
                        IsExtra = blIsExtra,
                        Price = product.Price
                    };

                    listProduct.Add(productMapping);
                }
            }

            _productList = JsonConvert.SerializeObject(listProduct);
        }

        //Set old order that hasn't been paied 
        public void SetOrderModelListString()
        {
            var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
            var tables = tableService.GetAvailableTables().ToList();
            var listOrderModel = new List<POS.Repository.ViewModels.VposDTO.OrderModel>();

            foreach (var table in tables)
            {
                if (table.Status == (int)TableStatusEnum.InUse && table.CurrentOrderId != null)
                {
                    int orderId = (int)table.CurrentOrderId;
                    var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                    var order = orderService.FirstOrDefault(o => o.OrderId == orderId);
                    if (order != null)
                    {
                        var sortedOrderDetail = this.GetSortedOrderDetail(order);
                        var listOrderDetails = new List<POS.Repository.ViewModels.VposDTO.OrderDetail>();
                        foreach (var orderDetail in sortedOrderDetail)
                        {
                            var orderDetailMapping = new POS.Repository.ViewModels.VposDTO.OrderDetail()
                            {
                                ProductName = orderDetail.ProductName,
                                DiscountPercent = orderDetail.TotalAmount != 0 ?
                                    orderDetail.Discount / orderDetail.TotalAmount : 0,
                                FinalAmount = orderDetail.FinalAmount,
                                TotalAmount = orderDetail.TotalAmount,
                                IsExtra = orderDetail.ParentId != null,
                                Note = orderDetail.Notes,
                                IsShowed = true,
                                OrderDetailId = 0,
                                ProductCode = orderDetail.ProductCode,
                                Quantity = orderDetail.Quantity,
                                UnitPrice = orderDetail.UnitPrice
                            };

                            listOrderDetails.Add(orderDetailMapping);
                        }

                        var orderModel = new POS.Repository.ViewModels.VposDTO.OrderModel()
                        {
                            DiscountPercent = order.TotalAmount != 0
                                ? order.Discount / order.TotalAmount
                                : 0,
                            FinalAmount = order.FinalAmount,
                            Note = order.Notes,
                            OrderDetailList = listOrderDetails,
                            TableNumber = int.Parse(table.Number),
                            TotalAmount = order.TotalAmount
                        };

                        listOrderModel.Add(orderModel);
                    }
                }
            }
            // Serialize object to send to Client 
            _orderModelListToSend = JsonConvert.SerializeObject(listOrderModel);
        }


        private void MapOrderAndOrderAndroid(ref POS.Repository.Entities.Order orderPOS,
                               ref POS.Repository.ViewModels.VposDTO.OrderModel orderAndroid)
        {
            orderPOS.Discount = orderAndroid.TotalAmount - orderAndroid.FinalAmount;
            orderPOS.FinalAmount = orderAndroid.FinalAmount;
            orderPOS.Notes = orderAndroid.Note;
            orderPOS.OrderStatus = orderAndroid.Status;
            orderPOS.TotalAmount = orderAndroid.TotalAmount;

            foreach (var odAndroid in orderAndroid.OrderDetailList)
            {


                var orderDetail = orderPOS.OrderDetails.FirstOrDefault(od => od.OrderDetailID == odAndroid.OrderDetailId);
                if (orderDetail != null)
                {
                    orderDetail.Notes = odAndroid.Note;
                    orderDetail.Quantity = odAndroid.Quantity;
                    orderDetail.Status = odAndroid.Status;
                    orderDetail.TotalAmount = odAndroid.TotalAmount;
                    orderDetail.FinalAmount = odAndroid.FinalAmount;
                    orderDetail.Discount = odAndroid.TotalAmount - odAndroid.FinalAmount;
                    orderDetail.UnitPrice = odAndroid.UnitPrice;
                    orderDetail.ParentId = odAndroid.ParentId;
                }
                else
                {
                    var product = AllProducts.FirstOrDefault(p => p.ProductName == odAndroid.ProductName);
                    var productCode = string.Empty;

                    if (product != null)
                    {
                        productCode = product.Code;
                    }

                    orderDetail = new POS.Repository.Entities.OrderDetail()
                    {
                        ProductCode = productCode,
                        ProductId = 0, // hard-code
                        ProductName = odAndroid.ProductName,
                        UnitPrice = odAndroid.UnitPrice,
                        Quantity = odAndroid.Quantity,
                        ItemQuantity = odAndroid.Quantity,
                        TotalAmount = odAndroid.TotalAmount,
                        FinalAmount = odAndroid.FinalAmount,
                        Discount = odAndroid.TotalAmount - odAndroid.FinalAmount,
                        OrderDate = UtcDateTime.Now(),
                        Status = odAndroid.Status,
                        ProductType = 0, // hard-code
                        OrderGroup = 0, //Tạm thời để như vậy
                        ParentId = odAndroid.ParentId
                    };

                    orderPOS.OrderDetails.Add(orderDetail);
                }
            }
        }

        /// <summary>
        /// Get all valid OrderDetailViewModel and sort by OrderEditViewModel : mainitem -> extraitem of mainitem
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private List<POS.Repository.Entities.OrderDetail> GetSortedOrderDetail(POS.Repository.Entities.Order order)
        {
            var sortedOrderDetailList = new List<POS.Repository.Entities.OrderDetail>();


            foreach (var mainOrderDetail in order.OrderDetails.Where(od => od.ParentId == null))
            {
                sortedOrderDetailList.AddRange(
                    order.OrderDetails.Where(od => od.OrderDetailID == mainOrderDetail.OrderDetailID ||
                                                   od.ParentId == mainOrderDetail.OrderDetailID)
                        .OrderBy(od => od.ParentId)
                        .ToList());
            }
            return sortedOrderDetailList;
        }

        #endregion
    }
}
