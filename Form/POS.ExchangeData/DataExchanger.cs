using System;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Text;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.ExchangeDataModel;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
//using log4net;
using Newtonsoft.Json;
using SkyConnect.POSLib.ResponseModels;
using SkyConnect.POSLib.Domains;
using SkyConnect.POSLib.Utils;
//using UniLogLibFramework.Library;

namespace POS.ExchangeData
{
    public class DataExchanger
    {
        public static PosConfig PosConfig { get; set; }
        public static bool isCardAvailable = true;
        //private static readonly LogMonitor _log = new LogMonitor();
        private static StoreInfo StoreInfo = StoreInfoManager.GetStoreInfo(true);
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Giới hạn số order tối đa được gửi lên server 1 lần
        private static readonly int _maxOrderSendToServer = 10;


        //public static async Task SendListStoreOrderToServer()
        //{
        //    //Call wepApi
        //    using (var client = new HttpClient())
        //    {
        //        var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
        //        int storeId = Convert.ToInt32(int.Parse(StoreInfo.StoreId));

        //        List<OrderModel> orders = new List<OrderModel>();
        //        var listOrder = orderService.Get(a => (a.OrderStatus == (int)OrderStatusEnum.PosFinished
        //            || a.OrderStatus == (int)OrderStatusEnum.PosPreCancel
        //            || a.OrderStatus == (int)OrderStatusEnum.PosCancel) && a.OrderCode != null)
        //            .Take(50).ToList();

        //        try
        //        {
        //            foreach (var item in listOrder)
        //            {
        //                var order = DataConverter.ConvertOrderModel(item, storeId);
        //                orders.Add(order);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error("SendListStoreOrderToServer(ConvertOrderModel) - " + ex);
        //        }

        //        client.BaseAddress = new Uri(StoreInfo.ServerUri);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        try
        //        {
        //            HttpResponseMessage response = await client.PostAsJsonAsync<List<OrderModel>>("OrderApi/SendOrderToServerClone", orders);
        //            //log.Info("Đẩy lên(Resposse): " + response.IsSuccessStatusCode);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                List<OrderStatusModel> listOrderStatus = await response.Content.ReadAsAsync<List<OrderStatusModel>>();

        //                orderService.EditListOrderFromServer(listOrderStatus);

        //                log.Info("Send ListStoreOrder to server - "
        //                    + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error("SendListStoreOrderToServer(EditOrder) - " + ex);
        //        }

        //    }
        //}


        public static async Task SendStoreOrderToServer()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                int storeId = Convert.ToInt32(int.Parse(StoreInfo.StoreId));

                PosConfig = StoreInfoManager.GetPosConfig(true);

                var dataOrder = orderService
                    .Get(o => !string.IsNullOrEmpty(o.OrderCode)
                            && (o.OrderStatus == (int)OrderStatusEnum.PosFinished
                                || o.OrderStatus == (int)OrderStatusEnum.PosPreCancel
                                || o.OrderStatus == (int)OrderStatusEnum.PosCancel
                                || (o.OrderStatus == (int)OrderStatusEnum.PosProcessing
                                    && PosConfig.SaveTableStatus.Trim().ToLower() == "true")))
                    .OrderByDescending(o => o.CheckInDate)
                    .Take(_maxOrderSendToServer)
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
                    //log.Error("SendStoreOrderToServer(ConvertOrderModel) - " + ex);
                    //_log.SendLogError(ex);
                }

                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    foreach (var orderModel in orders)
                    {
                        if (orderModel.CustomerID == 0) orderModel.CustomerID = null;
                        HttpResponseMessage response = await client.PostAsJsonAsync<OrderModel>("OrderApi/SendOrderToServer", orderModel);

                        if (response.IsSuccessStatusCode)
                        {
                            OrderStatusModel orderStatus = await response.Content.ReadAsAsync<OrderStatusModel>();

                            if (orderStatus.OrderStatus > 0)
                            {
                                var checkOrder = orderService.GetOrderByOrderCode(orderStatus.InvoiceId);
                                checkOrder.OrderStatus = orderStatus.OrderStatus;
                                checkOrder.DeliveryStatus = orderStatus.DeliveryStatus;
                                checkOrder.CheckInPerson = orderStatus.CheckInPerson;
                                orderService.Update(checkOrder);
                            }

                            //log.Info("Send StoreOrder " + orderModel.OrderCode + " to server - "
                            //    + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                        }
                        else
                        {
                            Thread.Sleep(5000);
                            if (!CheckForInternetConnection(true))
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //if (ex.Message.Contains("An error occurred while sending the request"))
                    //{
                    //    log.Error("Can't connect to server !!! --- "
                    //        + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    //}
                    //else if (ex.Message.Contains("An exception occurred during a Ping request"))
                    //{
                    //    log.Error("Internet problem !!! --- "
                    //        + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    //}
                    //else
                    //{
                    //    log.Error("SendStoreOrderToServer - " + ex);
                    //}
                    //_log.SendLogError(ex);
                }
            }
        }

        #region Delivery Order

        public static async Task GetAndProcessOrderFromServer()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                MessageProcess messageProcess = new MessageProcess();
                bool isContinue = false;
                do
                {
                    HttpResponseMessage response = await client.GetAsync("api/message/GetMessage/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId);
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            //Dữ liệu của queue được lấy về
                            MessageSend msg = await response.Content.ReadAsAsync<MessageSend>();
                            if (msg.NotifyType != (int)NotifyMessageType.NoThing)
                            {
                                messageProcess.ProcessMessage(msg);
                            }
                            isContinue = msg.CheckFlag;
                        }
                        catch (Exception ex)
                        {
                            //log.Error("GetAndProcessOrderFromServer - " + ex);
                            //_log.SendLogError(ex);
                        }
                    }
                }
                while (isContinue);
            }
        }


        #endregion

        #region Other Data

        //Xác nhận đã cập nhật
        public static async Task<bool> DataUpdated(int type)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //MessageProcess messageProcess = new MessageProcess();

                    HttpResponseMessage response =
                        await client.GetAsync("api/message/GetUpdated/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId + "/" + type);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    //log.Error("DataUpdated - " + ex);
                    //_log.SendLogError(ex);
                    return false;
                }
            }
        }



        #region Account
        //Get All Accout from webApi and Save DB
        public static async Task GetAccount()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    // HTTP GET WebApi
                    HttpResponseMessage response =
                        await
                            client.GetAsync("AccountApi/GetAccountList?token=" + StoreInfo.ServerToken + "&terminalId=" +
                                            StoreInfo.StoreId);
                    if (response.IsSuccessStatusCode)
                    {
                        List<AccountModel> accounts = await response.Content.ReadAsAsync<List<AccountModel>>();
                        var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
                        var listAccount = accountService.Get(a => a.IsUsed).ToList();
                        foreach (var item in listAccount)
                        {
                            //Delete account in DB
                            item.IsUsed = false;
                            var account = accountService.FirstOrDefault(a => a.AccountId == item.AccountId);
                            accountService.Delete(account);
                        }
                        //Excute Database
                        foreach (var item in accounts)
                        {
                            Account newAccount = new Account()
                            {
                                AccountId = item.AccountId,
                                AccountPassword = item.AccountPassword,
                                IsUsed = item.IsUsed,
                                Role = item.Role,
                                StaffName = item.StaffName
                            };
                            //Add account into DB
                            accountService.Create(newAccount);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("GetAccount - " + ex);
                    //_log.SendLogError(ex);
                }
            }
        }
        public static Boolean GetNewAccount()//[tung]
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // HTTP GET WebApi
                    //HttpResponseMessage response = client.GetAsync("AccountApi/GetAccountList?token=" + StoreInfo.ServerToken + "&terminalId=" +
                    //                        StoreInfo.StoreId).Result;
                    HttpResponseMessage response = client.GetAsync("api/account/GetAccountList/" + StoreInfo.ServerToken + "/" +
                                            StoreInfo.StoreId).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        List<AccountModel> accounts = response.Content.ReadAsAsync<List<AccountModel>>().Result;
                        var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
                        var listAccount = accountService.Get(a => a.IsUsed).ToList();

                        foreach (var item in listAccount)
                        {
                            //Delete all account in DB
                            var account = accountService.FirstOrDefault(a => a.AccountId == item.AccountId);
                            accountService.Delete(account);
                        }
                        //Excute Database
                        foreach (var item in accounts)
                        {
                            Account newAccount = new Account()
                            {
                                AccountId = item.AccountId,
                                AccountPassword = item.AccountPassword,
                                IsUsed = item.IsUsed,
                                Role = item.Role,
                                StaffName = item.StaffName
                            };
                            //Add account into DB
                            accountService.Create(newAccount);
                        }
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    //log.Error("GetNewAccount - " + ex);
                    //_log.SendLogError(ex);
                    return false;
                }
            }
        }
        /// <summary>
        /// Send new account info to server to update
        /// </summary>
        /// <param name="newAccountInfo">new info</param>
        /// <returns></returns>
        public static string SendAccountToUpdateUserInfo(AccountViewModel newAccountInfo)
        {
            //Call wepApi
            //log.Info("Test");
            //log.Info("Đẩy lên: " + StoreInfo.ServerUri);
            //log.Info("Đẩy lên: " + StoreInfo.StoreId);
            //log.Info("Đẩy lên: " + StoreInfo.ServerToken);
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    AccountModel newAccountModel = new AccountModel()
                    {
                        AccountId = newAccountInfo.AccountId,
                        AccountPassword = newAccountInfo.AccountPassword,
                        IsUsed = newAccountInfo.IsUsed,
                        Role = newAccountInfo.Role,
                        StaffName = newAccountInfo.StaffName,
                        StoreId = int.Parse(StoreInfo.StoreId),
                        Token = StoreInfo.ServerToken
                    };

                    HttpResponseMessage response =
                        client.PostAsJsonAsync<AccountModel>("AccountApi/UpdateAccount", newAccountModel).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var passwordHashed = response.Content.ReadAsAsync<string>().Result;
                        return passwordHashed;
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("SendAccountToUpdateUserInfo - " + ex);
                    //_log.SendLogError(ex);
                }
                return "";
            }
        }

        #endregion

        #region Product

        //public static async Task GetProduct()
        //{
        //    {
        //        //            //Call wepApi
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(StoreInfo.ServerUri);
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            try
        //            {
        //                // HTTP GET WebApi Product
        //                HttpResponseMessage response =
        //                    await
        //                        client.GetAsync("api/product/GetProductList/" + StoreInfo.ServerToken + "/" +
        //                                        StoreInfo.StoreId);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    List<ProductModel> products = await response.Content.ReadAsAsync<List<ProductModel>>();
        //                    var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
        //                    //var listProduct = productService.GetAvailableProducts().Where(a => a.IsUsed).ToList();
        //                    var listProduct = productService.Get(a => a.IsUsed).ToList();
        //                    foreach (var itemO in listProduct)
        //                    {
        //                        //Delete product in DB
        //                        itemO.IsUsed = false;
        //                        productService.Update(itemO);
        //                    }
        //                    List<Product> newProductList = new List<Product>();
        //                    //Excute Database
        //                    foreach (var item in products)
        //                    {
        //                        var pro = new Product()
        //                        {
        //                            Att1 = item.Att1,
        //                            Att2 = item.Att2,
        //                            Att3 = item.Att3,
        //                            IsAvailable = item.IsAvailable,
        //                            CatID = item.CatID,
        //                            Code = item.Code,
        //                            ColorGroup = item.ColorGroup,
        //                            DiscountPercent = item.DiscountPercent,
        //                            DiscountPrice = item.DiscountPrice,
        //                            DisplayOrder = item.DisplayOrder,
        //                            ShortName = item.ShortName,
        //                            IsMenuDisplay = item.IsMenuDisplay,
        //                            Group = item.Group,
        //                            IsUsed = true,
        //                            PosX = item.PosX,
        //                            PosY = item.PosY,
        //                            PicURL = item.PicURL,
        //                            ProductName = item.ProductName,
        //                            Price = item.Price,
        //                            ProductType = item.ProductType,
        //                            IsFixedPrice = item.IsFixedPrice,
        //                            HasExtra = item.HasExtra,
        //                            IsMostOrder = item.IsMostOrder,
        //                            GeneralProductId = item.GeneralProductId,
        //                            IsDefaultChildProduct = item.IsDefaultChildProduct
        //                        };
        //                        if (item.ProductType == (int)ProductTypeEnum.General
        //                            && item.GeneralProductId != null)
        //                        {
        //                            pro.ProductParentId = item.ProductId;
        //                        }
        //                        newProductList.Add(pro);
        //                        //                            //Add product into DB
        //                        //                            productService.CreateProduct(pro);
        //                    }
        //                    //                            productService.AddProductsRange(newProductList.Take(newProductList.Count - 1));
        //                    productService.AddProductsRange(newProductList);
        //                    //                            var pr = newProductList.LastOrDefault();
        //                    //                            productService.Create(pr);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }
        //    }
        //}

        public static bool GetNewProduct()
        {
            {
                //Call wepApi
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP GET WebApi Product
                        HttpResponseMessage response = client.GetAsync("api/product/GetProductList/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            List<ProductModel> products = response.Content.ReadAsAsync<List<ProductModel>>().Result;
                            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
                            var dbProducts = productService.GetProductsToUpdate().ToList();

                            List<Product> newProductList = new List<Product>();

                            //Excute Database
                            foreach (var item in products)
                            {
                                var product = dbProducts.LastOrDefault(p => p.Code == item.Code);
                                if (product == null)
                                {
                                    product = new Product();
                                    product.ProductId = -1;
                                }
                                product.Code = item.Code;
                                product.ProductName = item.ProductName;
                                product.ShortName = item.ShortName;
                                product.Price = item.Price;
                                product.PicURL = item.PicURL;
                                product.CatID = item.CatID;
                                product.IsAvailable = item.IsAvailable;
                                product.DiscountPercent = item.DiscountPercent;
                                product.DiscountPrice = item.DiscountPrice;
                                product.ProductType = item.ProductType;
                                product.DisplayOrder = item.DisplayOrder;
                                product.HasExtra = item.HasExtra;
                                product.IsFixedPrice = item.IsFixedPrice;
                                product.PosX = item.PosX;
                                product.PosY = item.PosY;
                                product.ColorGroup = item.ColorGroup;
                                product.Group = item.Group;
                                product.IsMenuDisplay = item.IsMenuDisplay;
                                product.GeneralProductId = item.GeneralProductId;
                                product.Att1 = item.Att1;
                                product.Att2 = item.Att2;
                                product.Att3 = item.Att3;
                                product.MaxExtra = item.MaxExtra;
                                product.IsMostOrder = item.IsMostOrder;
                                product.IsUsed = true;
                                //product.ProductParentId = item.ProductId;
                                product.PrintGroup = item.PrintGroup;
                                product.IsDefaultChildProduct = item.IsDefaultChildProduct;
                        

                                if (item.ProductType == (int)ProductTypeEnum.General
                                && item.GeneralProductId == null)
                                {
                                    product.ProductParentId = item.ProductId;
                                }

                                if (product.ProductId != -1)
                                {
                                    //Update product
                                    productService.Update(product);
                                }
                                else
                                {
                                    newProductList.Add(product);
                                }
                            }

                            foreach (var item in dbProducts)
                            {
                                var product = products.LastOrDefault(p => p.Code == item.Code);
                                if (product == null)
                                {
                                    //Delete product
                                    item.IsUsed = false;
                                    item.IsAvailable = false;
                                    productService.Update(item);
                                }
                            }

                            //Add products
                            productService.AddProductsRange(newProductList);

                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetNewProduct - " + ex);
                        //_log.SendLogError(ex);
                        return false;
                    }
                }
            }
        }

        public static async Task GetProductExtra()
        {
            {
                //Call wepApi
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        // HTTP GET WebApi Product
                        HttpResponseMessage response =
                            await
                                client.GetAsync("api/product/GetProductExtraList/" + StoreInfo.ServerToken + "/" +
                                                StoreInfo.StoreId);
                        if (response.IsSuccessStatusCode)
                        {
                            List<ProductExtraModel> products =
                                response.Content.ReadAsAsync<List<ProductExtraModel>>().Result;
                            var productExtraService =
                                ServiceManager.GetService<ProductExtraService>(typeof(ProductExtraRepository));
                            //var listProduct = productService.GetAvailableProducts().Where(a => a.IsUsed).ToList();
                            //                            var listProductExtrasOld = productExtraService.GetAvailableProductExtras().ToList();
                            //                            foreach (var itemO in listProduct)
                            //                            {
                            //                                //Delete product in DB
                            //                                itemO.IsUsed = false;
                            //                                productExtraService.EditProductExtra(itemO);
                            //                            }
                            //Excute Database
                            var listProductExtrasNew = new List<ProductExtra>();
                            foreach (var item in products)
                            {
                                var pro = new ProductExtra()
                                {
                                    PrimaryProductCode = item.PrimaryProductCode,
                                    ExtraProductCode = item.ExtraProductCode,
                                    IsEnable = item.IsEnable,
                                    IsDisplayed = item.IsDisplayed,
                                    MaxItem = item.MaxItem,
                                    Price = item.Price,
                                    TimeStamp = (decimal)item.TimeStamp,
                                    IsUsed = true
                                };
                                listProductExtrasNew.Add(pro);
                            }
                            productExtraService.DeleteAllProductExtras();
                            productExtraService.AddRangeProductExtras(listProductExtrasNew);
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetProductExtra - " + ex);
                        //_log.SendLogError(ex);
                    }
                }
            }
        }

        public static void GetNewProductExtra()
        {
            {
                //Call wepApi
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP GET WebApi Product
                        HttpResponseMessage response =
                            client.GetAsync("api/product/GetProductExtraList/" + StoreInfo.ServerToken + "/" +
                                            StoreInfo.StoreId).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            List<ProductExtraModel> products =
                                response.Content.ReadAsAsync<List<ProductExtraModel>>().Result;
                            var productExtraService =
                                ServiceManager.GetService<ProductExtraService>(typeof(ProductExtraRepository));
                            //                            var listProductExtrasOld = productExtraService.GetAvailableProductExtras().ToList();

                            var listProductExtrasNew = new List<ProductExtra>();
                            foreach (var item in products)
                            {
                                var pro = new ProductExtra()
                                {
                                    PrimaryProductCode = item.PrimaryProductCode,
                                    ExtraProductCode = item.ExtraProductCode,
                                    IsEnable = item.IsEnable,
                                    IsDisplayed = item.IsDisplayed,
                                    MaxItem = item.MaxItem,
                                    Price = item.Price,
                                    TimeStamp = (decimal)item.TimeStamp,
                                    IsUsed = true
                                };

                                listProductExtrasNew.Add(pro);
                            }
                            productExtraService.DeleteAllProductExtras();
                            productExtraService.AddRangeProductExtras(listProductExtrasNew);
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetNewProductExtra - " + ex);
                        //_log.SendLogError(ex);
                    }
                }
            }

        }
        #endregion

        #region ProductCategory

        public static bool GetNewProductCategory()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // HTTP GET WebApi
                    HttpResponseMessage response =
                        client.GetAsync("api/category/GetCategoryList/" + StoreInfo.ServerToken + "/" +
                                        StoreInfo.StoreId).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        ProductCategoryExtraMappingViewModel categories = response.Content.ReadAsAsync<ProductCategoryExtraMappingViewModel>().Result;

                        var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
                        var categoryExtraService = ServiceManager.GetService<CategoryExtraService>(typeof(CategoryExtraRepository));
                        var dbCategories = categoryService.GetAvailableCategories().ToList();
                        var otherCategories = categoryService.GetOtherCategories().ToList();
                        //var dbCategoryExtras = categoryExtraService.Get().ToList();

                        //full categories
                        foreach (var item in otherCategories)
                        {
                            dbCategories.Add(item);
                        }

                        #region delete FIRST
                        foreach (var item in dbCategories)
                        {
                            //var cate = categories.ProductCategory.FirstOrDefault(c => c.Code == item.Code && c.IsUsed == true);
                            //if (cate == null)
                            item.IsUsed = false;
                            item.IsDisplayed = false;
                            categoryService.Update(item);
                        }
                        #endregion

                        #region update 
                        //Excute Database
                        foreach (var item in categories.ProductCategory)
                        {
                            var cate = dbCategories.LastOrDefault(c => c.Code == item.Code);
                            if (cate == null)
                            {
                                cate = new Category();
                                cate.Id = -1;
                            }
                            //Add account into DB
                            cate.Code = item.Code;
                            cate.Name = item.Name;
                            cate.Type = item.Type;
                            cate.DisplayOrder = item.DisplayOrder;
                            cate.IsDisplayed = item.IsDisplayed;
                            cate.IsUsed = item.IsUsed;
                            cate.IsExtra = item.IsExtra;
                            cate.AdjustmentNote = item.AdjustmentNote;
                            cate.ImageFontAwsomeCss = item.ImageFontAwsomeCss ?? "glass";
                            cate.ParentCateId = item.ParentCateId;

                            if (cate.Id == -1)
                            {
                                categoryService.Create(cate);
                            }
                            else
                            {
                                categoryService.Update(cate);
                            }
                        }
                        #endregion

                        //foreach (var item in categories.CategoryExtra)
                        //{
                        //    var extra = dbCategoryExtras.LastOrDefault(c => c.PrimaryCategoryCode == item.PrimaryCategoryId);
                        //    if (extra == null)
                        //    {
                        //        extra = new CategoryExtra()
                        //        {
                        //            CategoryExtraId = -1
                        //        };
                        //    }

                        //    extra.PrimaryCategoryCode = item.PrimaryCategoryId;
                        //    extra.ExtraCategoryCode = item.ExtraCategoryId;
                        //    extra.IsEnable = item.IsEnable;

                        //    if (extra.CategoryExtraId == -1)
                        //    {
                        //        categoryExtraService.Create(extra);
                        //    }
                        //    else
                        //    {
                        //        categoryExtraService.Update(extra);
                        //    }
                        //}

                        //foreach (var item in dbCategoryExtras)
                        //{
                        //    var cateExtra = categories.CategoryExtra.LastOrDefault(ce => ce.PrimaryCategoryId == item.PrimaryCategoryCode);
                        //    if (cateExtra == null)
                        //    {
                        //        //Delete cate
                        //        item.IsEnable = false;
                        //        categoryExtraService.Delete(item);
                        //    }
                        //}

                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    //log.Error("GetNewProductCategory - " + ex);
                    //_log.SendLogError(ex);
                    return false;
                }
            }
        }

        #endregion

        #region Promotion
        public static bool GetNewPromotion()
        {
            {
                //Call wepApi
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP GET WebApi Product
                        HttpResponseMessage response = client.GetAsync("api/promotionNew/GetPromotionList/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            List<PromotionModel> promotions = response.Content.ReadAsAsync<List<PromotionModel>>().Result;

                            var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
                            var promotionDetailService = ServiceManager.GetService<PromotionDetailService>(typeof(PromotionDetailRepository));
                            var listPromotions = promotionService.Get().ToList();
                            var listPromotionDetails = promotionDetailService.Get().ToList();

                            foreach (var promotion in listPromotions)
                            {
                                promotionService.Delete(promotion);
                            }
                            foreach (var promotionDetail in listPromotionDetails)
                            {
                                promotionDetailService.Delete(promotionDetail);
                            }

                            List<Promotion> newPromotionList = new List<Promotion>();
                            List<PromotionDetail> newPromotionDetailList = new List<PromotionDetail>();

                            //Excute Database
                            foreach (var promotion in promotions)
                            {
                                var newPro = new Promotion()
                                {
                                    PromotionID = promotion.PromotionID,
                                    PromotionCode = promotion.PromotionCode,
                                    PromotionName = promotion.PromotionName,
                                    PromotionClassName = promotion.PromotionClassName,
                                    Description = promotion.Description,
                                    ImageCss = promotion.ImageCss,
                                    PromotionType = promotion.PromotionType,
                                    GiftType = promotion.GiftType,
                                    ApplyLevel = promotion.ApplyLevel,
                                    IsForMember = promotion.IsForMember,
                                    FromDate = promotion.FromDate,
                                    ToDate = promotion.ToDate,
                                    ApplyFromTime = promotion.ApplyFromTime,
                                    ApplyToTime = promotion.ApplyToTime,
                                    IsActive = promotion.Active,
                                    IsApplyOnce = promotion.IsApplyOnce,
                                    IsVoucher = promotion.IsVoucher
                                };
                                newPromotionList.Add(newPro);

                                foreach (var promotionDetail in promotion.PromotionDetails)
                                {
                                    var newPromoDetail = new PromotionDetail()
                                    {
                                        PromotionDetailID = promotionDetail.PromotionDetailID,
                                        PromotionCode = promotionDetail.PromotionCode,
                                        PromotionDetailCode = promotionDetail.PromotionDetailCode,
                                        RegExCode = promotionDetail.RegExCode,
                                        MinOrderAmount = promotionDetail.MinOrderAmount,
                                        MaxOrderAmount = promotionDetail.MaxOrderAmount,
                                        BuyProductCode = promotionDetail.BuyProductCode,
                                        MinBuyQuantity = promotionDetail.MinBuyQuantity,
                                        MaxBuyQuantity = promotionDetail.MaxBuyQuantity,
                                        GiftProductCode = promotionDetail.GiftProductCode,
                                        GiftQuantity = promotionDetail.GiftQuantity,
                                        DiscountAmount = promotionDetail.DiscountAmount.HasValue ? (decimal)promotionDetail.DiscountAmount.Value : 0
                                    };

                                    if (promotionDetail.DiscountRate != null)
                                    {
                                        newPromoDetail.DiscountRate = (int)promotionDetail.DiscountRate;
                                    }
                                    newPromotionDetailList.Add(newPromoDetail);
                                }
                            }

                            promotionService.AddPromotionsRange(newPromotionList);
                            promotionDetailService.AddPromotionDetailsRange(newPromotionDetailList);
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetNewPromotion - " + ex);
                        //_log.SendLogError(ex);
                        return false;
                    }
                }
            }
        }

        public static async Task<VoucherResultModel> CheckVoucher(string code,string membershipCardCode)
        {
            VoucherResultModel voucherResultModel = null;

            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //HTTP POST WebApi
                    VoucherModel voucherModel = new VoucherModel()
                    {
                        token = StoreInfo.ServerToken,
                        terminalId = Int32.Parse(StoreInfo.StoreId),
                        voucherCode = code,
                        MembershipCardCode=membershipCardCode
                    };

                    HttpResponseMessage response =
                        await client.PostAsJsonAsync<VoucherModel>("VoucherApi/CheckVoucherCode", voucherModel);

                    if (response.IsSuccessStatusCode)
                    {
                        voucherResultModel = await response.Content.ReadAsAsync<VoucherResultModel>();
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("CheckVoucher - " + ex);
                    //_log.SendLogError(ex);
                }
            }
            return voucherResultModel;
        }

        public static async Task<Object> getVoucherMember(string code)
        {
            VoucherResultModel voucherResultModel = null;

            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //HTTP POST WebApi
                    VoucherModel voucherModel = new VoucherModel()
                    {
                        token = StoreInfo.ServerToken,
                        terminalId = Int32.Parse(StoreInfo.StoreId),
                        voucherCode = code,

                    };

                    HttpResponseMessage response =
                        await client.PostAsJsonAsync<VoucherModel>("VoucherApi/CheckVoucherCode", voucherModel);

                    if (response.IsSuccessStatusCode)
                    {
                        voucherResultModel = await response.Content.ReadAsAsync<VoucherResultModel>();
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("CheckVoucher - " + ex);
                    //_log.SendLogError(ex);
                }
            }
            return voucherResultModel;
        }

        public static async Task<APIResultModel> UseVoucher(VoucherResultModel voucher, OrderEditViewModel currentOrder, PromotionEditViewModel promotion)
        {
            //Call wepApi
            var result = new APIResultModel()
            {
                success = false,
            };

            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    List<ItemsUserVoucherModel> orderItems = getItemsUserVoucherModel(currentOrder);
                    try
                    {
                        var newOrderDetail = new OrderEditViewModel();
                        AutoMapper.Mapper.Map<OrderEditViewModel, OrderEditViewModel>(currentOrder, newOrderDetail);
                        var orderVM = (OrderViewModel)currentOrder;
                        var orderAPIVM = new OrderAPIViewModel(orderVM, AutoMapHelper.GetMapperInstance())
                        {
                            OrderDetailViewModels = currentOrder.OrderDetailEditViewModels
                        };
                        VoucherModel model = new VoucherModel()
                        {
                            token = StoreInfo.ServerToken,
                            terminalId = Int32.Parse(StoreInfo.StoreId),
                            storeId = Int32.Parse(StoreInfo.StoreId),
                            voucherCode = voucher.VoucherCode,
                            Order = orderAPIVM
                        };

                        // HTTP POST WebApi
                        //UseVoucherModel model = new UseVoucherModel()
                        //{
                        //    voucher = new VoucherModel()
                        //    {
                        //        token = StoreInfo.ServerToken,
                        //        terminalId = Int32.Parse(StoreInfo.StoreId),
                        //        voucherCode = voucher.VoucherCode
                        //    },
                        //    transactionId = currentOrder.OrderCode,
                        //    applyToPartner = promotion.ApplyToPartner,
                        //    items = orderItems
                        //};

                            HttpResponseMessage response =
                            await client.PostAsJsonAsync<VoucherModel>
                            ("VoucherApi/UseVoucherCode", model);

                        if (response.IsSuccessStatusCode)
                        {
                            var apiResult = await response.Content.ReadAsAsync<APIResultModel>();
                            result = apiResult;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("UseVoucher - " + ex);
                        //_log.SendLogError(ex);
                        return result;
                    }
                }
            }
            return result;
        }

        private static List<ItemsUserVoucherModel> getItemsUserVoucherModel(OrderEditViewModel currentOrder)
        {
            List<ItemsUserVoucherModel> items = new List<ItemsUserVoucherModel>();
             foreach (var order in currentOrder.OrderDetailEditViewModels)
             {
                ItemsUserVoucherModel item = new ItemsUserVoucherModel
                {
                    item_id = order.ProductId,
                    item_name = order.ProductName,
                    quantity = order.Quantity,
                    amount = order.FinalAmount,
                    discount_amount = order.Discount,
                    price = order.UnitPrice
                };
                items.Add(item);
             }
             return items;
        }

        #endregion

        #region Store Info
        public static async Task GetStoreInfo()
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // HTTP GET WebApi
                    HttpResponseMessage response =
                        await client.GetAsync("api/store/GetStore/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId);
                    if (response.IsSuccessStatusCode)
                    {
                        StoreModel storeModel = await response.Content.ReadAsAsync<StoreModel>();
                        var storeService = ServiceManager.GetService<StoreService>(typeof(StoreRepository));

                        var stores = storeService.Get(a => a.IsUsed);

                        foreach (var item in stores)
                        {
                            //Delete account in DB
                            item.IsUsed = false;
                            storeService.Update(item);
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
                        storeService.Create(store);
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("GetStoreInfo - " + ex);
                    //_log.SendLogError(ex);
                }
            }
        }
        #endregion

        #region Order

        public static async Task GetOrder(int rentId)
        {
            var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
            var orderDetailService = ServiceManager.GetService<OrderDetailService>(typeof(OrderDetailRepository));
            var paymentService = ServiceManager.GetService<PaymentService>(typeof(PaymentRepository));
            var orderPromotionService = ServiceManager.GetService<OrderPromotionMappingService>(typeof(OrderPromotionMappingRepository));
            var orderDetailPromotionService = ServiceManager.GetService<OrderDetailPromotionMappingService>(typeof(OrderDetailPromotionMappingRepository));


            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // HTTP GET WebApi Product
                    HttpResponseMessage response =
                        await client.GetAsync("api/message/GetOrder/" + StoreInfo.ServerToken + "/" + rentId);
                    if (response.IsSuccessStatusCode)
                    {
                        OrderModel onlineOrder = await response.Content.ReadAsAsync<OrderModel>();

                        var isNewOrder = true;
                        var orderPos = orderService.GetOrderByOrderCode(onlineOrder.OrderCode);

                        if (orderPos != null)   //Delete
                        {
                            foreach (var payment in orderPos.Payments)
                            {
                                paymentService.Delete(payment);
                            }

                            foreach (var orderPromotion in orderPos.OrderPromotionMappings)
                            {
                                orderPromotionService.Delete(orderPromotion);
                            }

                            foreach (var orderDetail in orderPos.OrderDetails)
                            {
                                foreach (var orderDetailPromotion in orderDetail.OrderDetailPromotionMappings)
                                {
                                    orderDetailPromotionService.Delete(orderDetailPromotion);
                                }
                                orderDetailService.Delete(orderDetail);
                            }

                            orderService.Delete(orderPos);
                            isNewOrder = false;
                        }

                        var order = new Order()
                        {
                            OrderId = onlineOrder.OrderId,
                            CheckInDate = onlineOrder.CheckInDate,
                            TotalAmount = onlineOrder.TotalAmount,
                            Discount = onlineOrder.Discount,
                            DiscountOrderDetail = onlineOrder.DiscountOrderDetail,
                            FinalAmount = onlineOrder.FinalAmount,
                            OrderStatus = onlineOrder.OrderStatus,
                            OrderType = onlineOrder.OrderType,
                            CheckInPerson = onlineOrder.CheckInPerson,
                            IsFixedPrice = onlineOrder.IsFixedPrice,
                            SourceID = onlineOrder.SourceID,
                            OrderCode = onlineOrder.OrderCode,
                            Notes = onlineOrder.Notes,
                            DeliveryStatus = onlineOrder.DeliveryStatus,
                            DeliveryAddress = onlineOrder.DeliveryAddress ?? "",
                            DeliveryCustomer =
                                onlineOrder.DeliveryCustomer ?? "",
                            DeliveryPhone = onlineOrder.DeliveryPhone ?? "",
                            GroupPaymentStatus = 0, //Tạm thời để vậy
                        };

                        foreach (var m in onlineOrder.OrderPromotioMappingMs)
                        {
                            var mapping = new OrderPromotionMapping()
                            {
                                //Id = m.Id,
                                OrderId = order.OrderId,
                                PromotionCode = m.PromotionCode,
                                PromotionDetailCode = m.PromotionDetailCode,
                                MappingIndex = m.MappingIndex,
                                DiscountAmount = (decimal)m.DiscountAmount,
                                DiscountRate = m.DiscountRate,
                            };
                            order.OrderPromotionMappings.Add(mapping);
                        }

                        foreach (var onlineOrderDetail in onlineOrder.OrderDetailViewModels)
                        {
                            var orderDetail = new OrderDetail()
                            {
                                OrderDetailID = onlineOrderDetail.OrderDetailID,
                                OrderId = order.OrderId,
                                ProductId = onlineOrderDetail.ProductId,
                                ProductName = onlineOrderDetail.ProductName,
                                UnitPrice = onlineOrderDetail.UnitPrice,
                                Quantity = onlineOrderDetail.Quantity,
                                ItemQuantity = 0,
                                ProductCode = onlineOrderDetail.ProductCode,
                                TotalAmount = onlineOrderDetail.TotalAmount,
                                FinalAmount = onlineOrderDetail.FinalAmount,
                                Discount = onlineOrderDetail.Discount,
                                OrderDate = onlineOrderDetail.OrderDate,
                                Notes = onlineOrderDetail.Notes,
                                Status = onlineOrderDetail.Status,
                                ProductType = onlineOrderDetail.ProductType,
                                ParentId = onlineOrderDetail.ParentId,
                                TmpDetailId = onlineOrderDetail.TmpDetailId,
                                OrderGroup = 0, //Tạm thời để như vậy
                                OrderPromotionMappingId = onlineOrderDetail.OrderPromotionMappingId,
                                OrderDetailPromotionMappingId = onlineOrderDetail.OrderDetailPromotionMappingId,
                            };

                            foreach (var m in onlineOrderDetail.OrderDetailPromotioMappingMs)
                            {
                                var mapping = new OrderDetailPromotionMapping()
                                {
                                    //Id = m.Id,
                                    OrderDetailId = orderDetail.OrderDetailID,
                                    PromotionCode = m.PromotionCode,
                                    PromotionDetailCode = m.PromotionDetailCode,
                                    MappingIndex = m.MappingIndex,
                                    DiscountAmount = (decimal)m.DiscountAmount,
                                    DiscountRate = m.DiscountRate,
                                };
                                orderDetail.OrderDetailPromotionMappings.Add(mapping);
                            }

                            order.OrderDetails.Add(orderDetail);
                        }

                        foreach (var onlinePayment in onlineOrder.PaymentMs)
                        {
                            var payment = new Payment()
                            {
                                PaymentID = onlinePayment.PaymentID,
                                OrderId = order.OrderId,
                                Amount = onlinePayment.Amount,
                                CurrencyCode = onlinePayment.CurrencyCode ?? "",
                                FCAmount = (decimal)onlinePayment.FCAmount,
                                Notes = onlinePayment.Notes ?? "",
                                PayTime = onlinePayment.PayTime,
                                Status = onlinePayment.Status,
                                Type = onlinePayment.Type,
                                CardCode = onlinePayment.CardCode ?? "",
                            };
                            order.Payments.Add(payment);
                        }

                        //customerService.CreateCustomer(customer);
                        bool isCreated = false;

                        int orderId = orderService.CreateOrder(order);
                        if (orderId > 0)
                        {
                            isCreated = true;
                        }

                        // if Create Order Success -> remove Order in Server's Queue
                        if (isCreated)
                        {
                            response = await client.GetAsync(
                                "api/message/GetDone/"
                                + StoreInfo.ServerToken + "/"
                                + StoreInfo.StoreId);

                            var action = isNewOrder ? "Get" : "Update";

                            //log.Info(action + " Order " + order.OrderCode + " from server - "
                            //    + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //if (ex.Message.Contains("An error occurred while sending the request"))
                    //{
                    //    log.Error("Can't connect to server !!! --- "
                    //        + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    //}
                    //else if (ex.Message.Contains("An exception occurred during a Ping request"))
                    //{
                    //    log.Error("Internet problem !!! --- "
                    //        + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                    //}
                    //else
                    //{
                    //    log.Error("GetOrder - " + ex);
                    //}
                    //_log.SendLogError(ex);
                }
            }
        }

        #endregion

        #endregion

        public static async Task SendReportDate(DateReportViewModel reportVM)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var result =await client.PostAsJsonAsync("report/compare/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId, reportVM);
                }
                catch (Exception ex)
                {

                    //_log.SendLogError(ex);
                }
            }
        }

        public static async Task<CardVM> SkyConnectGetMemberCardInfo(string cardcode)
        {
            var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
            var pDomain = new SkyConnectPaymentDomain(config);
            CardVM customerCard = null;
            customerCard = pDomain.GetCardDetail(cardcode, (int)SkyConnectPartnerEnum.InHouse);
            if (customerCard == null)
            {
                customerCard = pDomain.GetCardDetail(cardcode, (int)SkyConnectPartnerEnum.GiftTalk);
            }
            return customerCard;

        }

        #region Pay via Customer balance
        public static async Task<CardCustomerModel> GetMemberCardInfo(string cardcode)
        {
            //Call wepApi
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //HTTP POST WebApi
                    CardModel cardModel = new CardModel()
                    {
                        token = StoreInfo.ServerToken,
                        terminalId = Int32.Parse(StoreInfo.StoreId),
                        membershipCardCode = cardcode
                    };

                    HttpResponseMessage response =
                        client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/GetMembershipCardDetail", cardModel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseMessage =  response.Content.ReadAsAsync<dynamic>().Result;
                        var Enum = responseMessage.Enum;
                        if ((bool)responseMessage.success == true)
                        {
                            if (Enum != null)
                            {
                                if ((int)Enum == (int)PaymentTypeEnum.MemberPayment)
                                {
                                    var customerModel =
                                        JsonConvert.DeserializeObject<CardCustomerModel>(
                                            JsonConvert.SerializeObject(responseMessage.result));
                                    return customerModel;
                                }
                            }
                            else
                            {
                                var customerModel = JsonConvert.DeserializeObject<CardCustomerModel>(JsonConvert.SerializeObject(responseMessage));
                                return customerModel;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("GetCardInfo - " + ex);
                    //_log.SendLogError(ex);
                    return null;
                }
            }
            return null;
        }

        public static async Task<object> GetCardInfo(string cardcode)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //HTTP POST WebApi
                    CardModel cardModel = new CardModel()
                    {
                        token = StoreInfo.ServerToken,
                        terminalId = Int32.Parse(StoreInfo.StoreId),
                        membershipCardCode = cardcode
                    };

                    HttpResponseMessage response =
                        await client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/GetCardDetail", cardModel);

                    if (response.IsSuccessStatusCode)
                    {
                        dynamic responseMessage = await response.Content.ReadAsAsync<dynamic>();
                        if (((bool)responseMessage.success) == true)
                        {
                            dynamic returnObj;
                            var Enum = responseMessage.Enum;
                            if (Enum != null)
                            {
                                if ((int)responseMessage.Enum == (int)PaymentTypeEnum.MemberPayment)
                                {
                                    var customerModel = JsonConvert.DeserializeObject<CardCustomerModel>(JsonConvert.SerializeObject(responseMessage.result));
                                    returnObj = new ExpandoObject();
                                    returnObj.cardType = responseMessage.Enum;
                                    returnObj.data = customerModel;
                                    return returnObj;
                                }
                            }
                            else
                            {
                                var customerModel = JsonConvert.DeserializeObject<CardCustomerModel>(JsonConvert.SerializeObject(responseMessage));
                                returnObj = new ExpandoObject();
                                returnObj.cardType = (int)PaymentTypeEnum.MemberPayment;
                                returnObj.data = customerModel;
                                return returnObj;
                            }

                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        response =
                            await client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/GetMembershipCardDetail", cardModel);
                        if (response.IsSuccessStatusCode)
                        {
                            dynamic responseMessage = await response.Content.ReadAsAsync<dynamic>();
                            var Enum = responseMessage.Enum;
                            if ((bool)responseMessage.success == true)
                            {
                                if (Enum != null)
                                {
                                    if ((int)Enum == (int)PaymentTypeEnum.MemberPayment)
                                    {
                                        var customerModel =
                                            JsonConvert.DeserializeObject<CardCustomerModel>(
                                                JsonConvert.SerializeObject(responseMessage.result));
                                        return customerModel;
                                    }
                                }
                                else
                                {
                                    var customerModel = JsonConvert.DeserializeObject<CardCustomerModel>(JsonConvert.SerializeObject(responseMessage));
                                    dynamic returnObj = new ExpandoObject();
                                    returnObj.cardType = (int)PaymentTypeEnum.MemberPayment;
                                    returnObj.data = customerModel;
                                    return returnObj;
                                }
                            }
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    //log.Error("GetCardInfo - " + ex);
                    //_log.SendLogError(ex);
                    return null;
                }
            }

        }


        public static async Task<APIResultModel> SendTransaction(int Enum, List<TransactionAccountModel> accounts, string userId,
            string tableNumber = null, string billId = null, string customer = null)
        {
            //Call wepApi
            var result = new APIResultModel()
            {
                success = false,
            };

            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP POST WebApi
                        TransactionCardModel transactionCard = new TransactionCardModel()
                        {
                            Token = StoreInfo.ServerToken,
                            TerminalId = Int32.Parse(StoreInfo.StoreId),
                            Accounts = accounts,
                            UserId = userId,
                            table_number = tableNumber,
                            bill_id = billId,
                            Customer = customer,
                            TransactionCode=accounts.FirstOrDefault(f=>f.IsChange).TransactionCode
                        };
                        var sendInfo = new
                        {
                            Enum = Enum,
                            model = transactionCard
                        };
                        HttpResponseMessage response =
                             client.PostAsJsonAsync<dynamic>
                            ("TransactionApi/CreateTransaction2", sendInfo).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var transactionResult = await response.Content.ReadAsAsync<APIResultModel>();
                            result = transactionResult;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("SendTransaction - " + ex);
                        //_log.SendLogError(ex);
                        return result;
                    }
                }
            }

            //var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
            //var pDomain = new SkyConnectPaymentDomain(config);


            return result;
        }
        #endregion

        #region Register api
        public static async Task<ResultModel> CheckCardAvailable(String cardcode)
        {
            if (CheckForInternetConnection())
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {

                        // HTTP POST WebApi
                        ResultModel result = new ResultModel();
                        CardModel cardModel = new CardModel()
                        {
                            token = StoreInfo.ServerToken,
                            terminalId = Int32.Parse(StoreInfo.StoreId),
                            membershipCardCode = cardcode
                        };

                        HttpResponseMessage response =
                            await client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/CheckAvailableCard", cardModel);


                        if (response.IsSuccessStatusCode)
                        {
                            result = await response.Content.ReadAsAsync<ResultModel>();
                            return result;
                        }
                        else
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("CheckCardAvailable - " + ex);
                        //_log.SendLogError(ex);
                        return new ResultModel
                        {
                            Message = "Có lỗi xảy ra, vui lòng thử lại. ",
                            Success = false
                        };
                    }
                }
            }
            return new ResultModel
            {
                Message = "Rớt mạng . Xin kiểm tra lại hệ thống ",
                Success = false
            };
        }

        public static async Task<ResultModel> SendCustomerInfo(CustomerEditViewModel customer)
        {
            //Call wepApi
            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP POST WebApi
                        customer.TerminalId = Int32.Parse(StoreInfo.StoreId);
                        HttpResponseMessage response =
                            await client.PostAsJsonAsync<CustomerEditViewModel>
                            ("CustomerApi/CreateCustomer", customer);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<ResultModel>();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("SendCustomerInfo - " + ex);
                        //_log.SendLogError(ex);
                        return new ResultModel
                        {
                            Message = "Có lỗi xảy ra, vui lòng thử lại. ",
                            Success = false
                        };
                    }
                }
            }
            return new ResultModel
            {
                Message = "Rớt mạng . Xin kiểm tra lại hệ thống ",
                Success = false
            };
        }

        public static async Task<CustomerEditViewModel3> CheckCustomerPhone(String phone)
        {
            //Call wepApi
            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP POST WebApi
                        PhoneCustomerModel model = new PhoneCustomerModel
                        {
                            Phone = phone,
                            TerminalID = Int32.Parse(StoreInfo.StoreId)
                        };
                        HttpResponseMessage response =
                           await client.PostAsJsonAsync<PhoneCustomerModel>
                           ("CustomerApi/CheckCustomer", model);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<CustomerEditViewModel3>();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("CheckCustomerPhone - " + ex);
                        //_log.SendLogError(ex);
                        return new CustomerEditViewModel3
                        {
                            message = "Có lỗi xảy ra . Liên hệ admin để được giải quyết",
                            success = false
                        };
                    }
                }
            }
            return new CustomerEditViewModel3
            {
                message = "Rớt mạng! Xin kiểm tra lại hệ thống ",
                success = false
            };
        }

        public static async Task<ResultModel> CreateMembershipCard(MembershipCustomerModel customer)
        {
            //Call wepApi
            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        // HTTP POST WebApi
                        customer.TerminalId = Int32.Parse(StoreInfo.StoreId);

                        HttpResponseMessage response =
                           await client.PostAsJsonAsync<MembershipCustomerModel>
                           ("MembershipCardNewApi/CreateMemberShipCardWithAccounts", customer);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<ResultModel>();
                            return result;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("CreateMembershipCard - " + ex);
                        //_log.SendLogError(ex);
                        return new ResultModel
                        {
                            Message = "Có lỗi xảy ra, vui lòng thử lại. ",
                            Success = false
                        };
                    }
                }
            }
            return new ResultModel
            {
                Message = "Rớt mạng . Xin kiểm tra lại hệ thống ",
                Success = false
            };
        }

        public async static Task<List<MembershipCardSampleModel>> GetListCard()
        {
            //Call wepApi
            List<MembershipCardSampleModel> list = null;
            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {

                        // HTTP POST WebApi
                        CardModel cardModel = new CardModel()
                        {
                            token = StoreInfo.ServerToken,
                            terminalId = Int32.Parse(StoreInfo.StoreId)
                        };
                        HttpResponseMessage response =
                       await
                           client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/GetSampleMembershipCard", cardModel);
                        if (response.IsSuccessStatusCode)
                        {
                            var list2 = await response.Content.ReadAsAsync<JsonString>();
                            list = JsonConvert.DeserializeObject<List<MembershipCardSampleModel>>(list2.list);
                            return list;
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetListCard - " + ex);
                        //_log.SendLogError(ex);
                    }
                }
            }
            return list;
        }

        public async static Task<List<POS.Repository.ViewModels.CustomerTypeEditViewModel>> GetListCustomerType()
        {
            //Call wepApi
            List<POS.Repository.ViewModels.CustomerTypeEditViewModel> list = null;

            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    try
                    {
                        // HTTP POST WebApi
                        CardModel cardModel = new CardModel()
                        {
                            token = StoreInfo.ServerToken,
                            terminalId = Int32.Parse(StoreInfo.StoreId)
                        };
                        HttpResponseMessage response = await
                           client.PostAsJsonAsync<CardModel>("MembershipCardNewApi/GetAllCustomerType/", cardModel);

                        if (response.IsSuccessStatusCode)
                        {
                            var list2 = await response.Content.ReadAsAsync<JsonString>();
                            list = JsonConvert.DeserializeObject<List<CustomerTypeEditViewModel>>(list2.list);
                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetListCustomerType - " + ex);
                     //_log.SendLogError(ex);
                        return null;
                    }
                }
            }
            return list;
        }

        public async static Task<ResultModelWithContent> getPosConfigByCode(string code)
        {
            //Call wepApi
            if (CheckForInternetConnection(true))
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(StoreInfo.ServerUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    try
                    {
                        var path = "api/store/get-pos-config-by-code/" + code;
                        HttpResponseMessage response =
                           await client.GetAsync(path);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = response.Content;
                            return new ResultModelWithContent
                            {
                                Content = result,
                                Success = true
                            };

                        }
                    }
                    catch (Exception ex)
                    {
                        //log.Error("CreateMembershipCard - " + ex);
                        //_log.SendLogError(ex);
                        return new ResultModelWithContent
                        {
                            Message = "Có lỗi xảy ra, vui lòng thử lại. ",
                            Success = false
                        };
                    }
                }
            }
            return new ResultModelWithContent
            {
                Message = "Rớt mạng . Xin kiểm tra lại hệ thống ",
                Success = false
            };
        }

        #endregion

        public static bool CheckForInternetConnection(bool pingServer = false)
        {
            try
            {
                var storeInfo = StoreInfoManager.GetStoreInfo(true);
                var myPing = new Ping();
                var pingOptions = new PingOptions();
                var timeout = 10000;
                byte[] buffer = new byte[32];
                var host = "google.com";

                if (pingServer)
                {
                    host = storeInfo.ServerUri; //server uri
                    host = host.Split('/')[2];  //remove http://
                    host = host.Split(':')[0];  //remove :8051
                }

                var reply = myPing.Send(host, timeout, buffer, pingOptions);

                int s = (int)reply.Status;
                if (s == 11010)
                {
                    //request timeout
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                //    if (ex.Message.Contains("An error occurred while sending the request"))
                //    {
                //        log.Error("Can't connect to server !!! --- "
                //            + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                //    }
                //    else if (ex.Message.Contains("An exception occurred during a Ping request"))
                //    {
                //        log.Error("Internet problem !!! --- "
                //            + Utils.UtcDateTimeNow().ToString("HH:mm:ss"));
                //    }
                //    else
                //    {
                //        log.Error("CheckForInternetConnection - " + ex);
                //    }
                //_log.SendLogError(ex);
            return false;
            }
        }
    }
}

