using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using POS.ExchangeData;
using POS.Repository;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WcfAndSignalr
{
    [ServiceContract(Name = "ILocalService")]
    interface ILocalService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "Login", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BaseResponse<Account> Login(AccountRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Products",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        BaseResponse<ProductCategoryViewModel> GetProducts();

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateOrder", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<BaseResponse<object>> CreateOrder(RequestOrder order);

        [OperationContract]
        [WebInvoke(UriTemplate = "GetMembership", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
          RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<BaseResponse<CardCustomerModel>> GetMemberShip(BaseRequest request);

        [OperationContract]
        [WebInvoke(UriTemplate = "MookTest", Method = "GET",
            ResponseFormat = WebMessageFormat.Json)]
        RequestOrder MookGenRequestModel();

        //[OperationContract]
        //BaseResponse<ProductCategoryViewModel> GetProducts(AccountRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Orders/{orderCode}",
            ResponseFormat = WebMessageFormat.Json)]
        BaseResponse<OrderViewModel> GetOrderByOrderCode(string orderCode);


        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "checkvoucher/{voucherCode}/{memberCode}",
            ResponseFormat = WebMessageFormat.Json)]
        Task<BaseResponse<POS.Repository.ExchangeDataModel.VoucherResultModel>> CheckAvailableVoucher(string voucherCode, string memberCode);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "ApplyVoucher", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<BaseResponse<ResponseOrder>> ApplyVoucher(string voucherCode, RequestOrder requestOrder);

        [OperationContract]
        [WebInvoke(UriTemplate = "CreateOrder2", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
        RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<BaseResponse<object>> CreateOrder2(RequestOrder requestOrder, string voucherCode);
    }


    public class ResponseOrder
    {
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Payment Payment { get; set; }
        public string Note { get; set; }
        public int TotalAmount { get; set; }
        public int FinalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountOrderDetail { get; set; }
        public double VAT { get; set; }
        public double VATAmount { get; set; }
        public List<OrderPromotionMappingEditViewModel> OrderPromotionMappingEditViewModels { get; set; }

    }

    [DataContract]
    public class RequestOrder
    {
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public List<OrderDetail> OrderDetails { get; set; }
        [DataMember]
        public Payment Payment { get; set; }
        [DataMember]
        public string Note { get; set; }
        [DataMember]
        public int TotalAmount { get; set; }
        [DataMember]
        public List<OrderPromotionMappingEditViewModel> OrderPromotionMappingEditViewModels { get; set; }
    }





    public class OrderDetail
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public double FinalAmount { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public List<OrderDetailPromotionMappingEditViewModel> OrderDetailPromotionMappingEditViewModels { get; set; }
    }
    public class Payment
    {
        public int Type { get; set; }
        public string Code { get; set; }
    }

    //public class BaseResponse<T> where T : class
    //{
    //    [JsonProperty("success")]
    //    public bool Success { get; set; }
    //    [JsonProperty("data")]
    //    public T Data { get; set; }
    //}

    public class LocalService : ILocalService
    {
        private Order SetOrder(RequestOrder resquest, IEnumerable<Product> products, CardCustomerModel card)
        {
            PosConfig posConfig = StoreInfoManager.GetPosConfig(true);
            StoreInfo storeInfo = StoreInfoManager.GetStoreInfo(true);
            string code = InvoiceCodeGenerator.GenerateInvoiceCode();
            string orderCode = posConfig.InvoideCodepattern.Replace("{StoreId}", storeInfo.StoreId)
           .Replace("{StoreName}", storeInfo.TerminalName)
           .Replace("{Code}", code);
            var now = POS.Repository.Entities.Services.Utils.UtcDateTimeNow();
            var order = new POS.Repository.Entities.Order()
            {
                OrderCode = orderCode,
                CheckInDate = now,
                TotalAmount = products.Sum(s => s.Price),
                Discount = 0,
                //DiscountOrderDetail = orderOnline.DiscountOrderDetail,
                FinalAmount = products.Sum(s => s.Price),
                OrderStatus = (int)OrderStatusEnum.PosProcessing,
                OrderType = (int)OrderTypeEnum.Delivery, // hard-code, cause this mode just support AtStore now
                CheckInPerson = "VPOS", // hard-code, waiting for Duc update model
                IsFixedPrice = true,
                SourceID = null,
                CustomerID = card.CustomerID,
                DeliveryStatus = (int)DeliveryStatusEnum.Assigned, // hard-code
                DeliveryAddress = "", // hard-code
                DeliveryCustomer = card.CustomerName, // hard-code
                DeliveryPhone = card.CustomerPhone, // hard-code
                GroupPaymentStatus = 0, //Tạm thời để vậy,
                Notes = resquest.Note
            };

            foreach (var item in resquest.OrderDetails)
            {
                var product = products.FirstOrDefault(f => f.ProductId == item.ProductId);
                if (product == null)
                {
                    continue;
                }
                var orderDetail = new POS.Repository.Entities.OrderDetail()
                {
                    ProductCode = product.Code,
                    ProductId = 0, // hard-code
                    ProductName = product.ProductName,
                    UnitPrice = product.Price,
                    Quantity = item.Quantity,
                    ItemQuantity = item.Quantity,
                    TotalAmount = item.Quantity * product.Price,
                    FinalAmount = item.Quantity * product.Price,
                    Discount = 0,
                    OrderDate = now,
                    Status = (int)OrderStatusEnum.PosProcessing,
                    //ParentId = item.ParentId,
                    ProductType = 0, // hard-code
                    OrderGroup = 0 //Tạm thời để như vậy
                };
                //order.DiscountOrderDetail += orderDetail.Discount;
                order.OrderDetails.Add(orderDetail);
            }
            order.TotalAmount = order.OrderDetails.Sum(s => s.TotalAmount);
            order.FinalAmount = order.TotalAmount;
            var payment = new POS.Repository.Entities.Payment()
            {
                PayTime = now,
                Amount = order.FinalAmount,
                Type = (int)PaymentTypeEnum.MemberPayment,//tam de vay
            };
            order.Payments.Add(payment);
            return order;
        }

        public async Task<BaseResponse<object>> CreateOrder(RequestOrder order)
        {
            var result = new BaseResponse<object>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.OK,
            };
            try
            {
                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                // tam thoi thanh toan bang the thanh vien
                var card = await DataExchanger.GetMemberCardInfo(order.Payment.Code);
                if (card == null)
                {
                    result.Message = "Không tìm thấy thẻ thành viên.";
                }
                else
                {
                    // chua ap dung voucher
                    var products = productService.GetProducts(order.OrderDetails.Select(s => s.ProductId));
                    var creditAccount = card.Accounts.OrderByDescending(o => o.Balance)
                        .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    if (creditAccount == null)
                    {
                        result.Message = "Không tìm thấy tài khoản.";
                    }
                    else
                    {
                        var entity = SetOrder(order, products, card);
                        if (creditAccount.Balance < entity.FinalAmount)
                        {
                            result.Message = "Tài khoản không đủ để thanh toán.";
                            return result;
                        }
                        else
                        {
                            // tao transaction tren server
                            var isCreateTransaction = await CreateTransactionAsync(entity, card);
                            if (!isCreateTransaction)
                            {
                                result.Message = "Thanh toán thất bại.";
                            }
                            else
                            {
                                orderService.CreateOrder(entity);
                                result.Status = (int)ResponseStatusEnum.OK;
                                result.Success = true;
                                PushMessageSignalr();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Success = false;
            }
            return result;
        }

        private Order SetOrder2(ResponseOrder responseOrder, IEnumerable<Product> products, CardCustomerModel card)
        {
            PosConfig posConfig = StoreInfoManager.GetPosConfig(true);
            StoreInfo storeInfo = StoreInfoManager.GetStoreInfo(true);
            string code = InvoiceCodeGenerator.GenerateInvoiceCode();
            string orderCode = posConfig.InvoideCodepattern.Replace("{StoreId}", storeInfo.StoreId)
           .Replace("{StoreName}", storeInfo.TerminalName)
           .Replace("{Code}", code);
            var now = POS.Repository.Entities.Services.Utils.UtcDateTimeNow();
            var order = new POS.Repository.Entities.Order()
            {
                OrderCode = orderCode,
                CheckInDate = now,
                TotalAmount = responseOrder.TotalAmount,
                Discount = responseOrder.Discount,
                DiscountOrderDetail = responseOrder.DiscountOrderDetail,
                //DiscountOrderDetail = orderOnline.DiscountOrderDetail,
                FinalAmount = responseOrder.FinalAmount,
                OrderStatus = (int)OrderStatusEnum.PosProcessing,
                OrderType = (int)OrderTypeEnum.Delivery, // hard-code, cause this mode just support AtStore now
                CheckInPerson = "VPOS", // hard-code, waiting for Duc update model
                IsFixedPrice = true,
                SourceID = null,
                CustomerID = card.CustomerID,
                DeliveryStatus = (int)DeliveryStatusEnum.Assigned, // hard-code
                DeliveryAddress = "", // hard-code
                DeliveryCustomer = card.CustomerName, // hard-code
                DeliveryPhone = card.CustomerPhone, // hard-code
                GroupPaymentStatus = 0, //Tạm thời để vậy,
                Notes = responseOrder.Note
            };

            foreach (var item in responseOrder.OrderDetails)
            {
                var product = products.FirstOrDefault(f => f.ProductId == item.ProductId);
                if (product == null)
                {
                    continue;
                }
                var orderDetail = new POS.Repository.Entities.OrderDetail()
                {
                    ProductCode = product.Code,
                    ProductId = 0, // hard-code
                    ProductName = product.ProductName,
                    UnitPrice = product.Price,
                    Quantity = item.Quantity,
                    ItemQuantity = item.Quantity,
                    TotalAmount = item.TotalAmount,
                    FinalAmount = item.FinalAmount,
                    Discount = item.Discount,
                    OrderDate = now,
                    Status = (int)OrderStatusEnum.PosProcessing,
                    //ParentId = item.ParentId,
                    ProductType = 0, // hard-code
                    OrderGroup = 0 //Tạm thời để như vậy
                };
                //order.DiscountOrderDetail += orderDetail.Discount;
                order.OrderDetails.Add(orderDetail);
            }
            var payment = new POS.Repository.Entities.Payment()
            {
                PayTime = now,
                Amount = order.FinalAmount,
                Type = (int)PaymentTypeEnum.MemberPayment,//tam de vay
            };
            order.Payments.Add(payment);
            return order;
        }

        public async Task<BaseResponse<object>> CreateOrder2(RequestOrder requestOrder, string voucherCode = null)
        {
            var result = new BaseResponse<object>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.OK,
            };
            ResponseOrder order = null;
            if (!string.IsNullOrEmpty(voucherCode))
            {
                var applyVoucher = await ApplyVoucher(voucherCode, requestOrder);
                if (applyVoucher.Success == false)
                {
                    return result;
                }
                order = applyVoucher.Data;
            } else
            {
                order = CreateResponseOrder(requestOrder);
            }

            try
            {
                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                // tam thoi thanh toan bang the thanh vien
                var card = await DataExchanger.GetMemberCardInfo(order.Payment.Code);
                if (card == null)
                {
                    result.Message = "Không tìm thấy thẻ thành viên.";
                }
                else
                {
                    // chua ap dung voucher
                    var products = productService.GetProducts(order.OrderDetails.Select(s => s.ProductId));
                    var creditAccount = card.Accounts.OrderByDescending(o => o.Balance)
                        .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    if (creditAccount == null)
                    {
                        result.Message = "Không tìm thấy tài khoản.";
                    }
                    else
                    {
                        var entity = SetOrder2(order, products, card);
                        if (creditAccount.Balance < entity.FinalAmount)
                        {
                            result.Message = "Tài khoản không đủ để thanh toán.";
                            return result;
                        }
                        else
                        {
                            // tao transaction tren server
                            var isCreateTransaction = await CreateTransactionAsync(entity, card);
                            if (!isCreateTransaction)
                            {
                                result.Message = "Thanh toán thất bại.";
                            }
                            else
                            {
                                result.Message = orderService.CreateOrder(entity).ToString();
                                result.Status = (int)ResponseStatusEnum.OK;
                                result.Success = true;
                                //PushMessageSignalr();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Success = false;
            }
            return result;
        }

        private async Task<bool> CreateTransactionAsync(Order order, CardCustomerModel card)
        {
            try
            {
                var creditAccount = card.Accounts
                    .FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                var listTransactionAccounts = new List<TransactionAccountModel>();
                if (creditAccount != null)
                {
                    var accountModel = new TransactionAccountModel
                    {
                        AccountCode = creditAccount.AccountCode,
                        IsChange = true,
                        IsIncrease = false,
                        ChangeAmount = (decimal)order.FinalAmount,
                        //TransactionCode = _transactioncode
                    };
                    listTransactionAccounts.Add(accountModel);
                }

                foreach (var item in card.Accounts.Where(a => a.Type != (int)CardAccountTypeEnum.CreditAccount))
                {
                    var accountModel = new TransactionAccountModel
                    {
                        AccountCode = item.AccountCode,
                        ChangeAmount = 0,
                        IsChange = false,
                        IsIncrease = false,
                    };
                    listTransactionAccounts.Add(accountModel);
                }
                if (listTransactionAccounts.Any())
                {
                    var userID = "";
                    var rs = await DataExchanger.SendTransaction((int)PaymentTypeEnum.MemberPayment, listTransactionAccounts, userID);
                    return rs.success;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }


        }

        public async Task<BaseResponse<CardCustomerModel>> GetMemberShip(BaseRequest request)
        {
            var result = new BaseResponse<CardCustomerModel>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.OK,
                Message = "Không tìm thấy thẻ thành viên"
            };
            var membership = await DataExchanger.GetMemberCardInfo(request.Message);
            if (membership != null)
            {
                result.Success = true;
                result.Data = membership;
                result.Message = "";
            }

            return result;
        }

        private void PushMessageSignalr()
        {
            IHubProxy _hub;
            var storeConfig = StoreInfoManager.GetStoreInfo(true);
            string url = storeConfig.Signalr.Url;
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("TestHub");

            // userid will be param
            connection.Headers.Add("userId", "random");
            connection.Start().Wait();

            _hub.On("send", x => Console.WriteLine(x));

            string line = null;
            List<string> a = new List<string>();

            //thay doi sau
            a.Add(storeConfig.Signalr.UserId);
            _hub.Invoke("Send", a, line).Wait();
        }

        public T GetFromQueryString<T>() where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties(); // to get all properties from Class(Object)  
            foreach (var property in properties)
            {
                var valueAsString = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters[property.Name];
                object value = Parse(property.PropertyType, valueAsString); // parse data types  

                if (value == null)
                    continue;

                property.SetValue(obj, value, null); //set values to properties.  
            }
            return obj;
        }

        public object Parse(Type dataType, string ValueToConvert)
        {
            TypeConverter obj = TypeDescriptor.GetConverter(dataType);
            object value = obj.ConvertFromString(null, CultureInfo.InvariantCulture, ValueToConvert);
            return value;
        }

        public BaseResponse<ProductCategoryViewModel> GetProducts()
        {
            var acc = GetFromQueryString<AccountRequest>();
            var result = new BaseResponse<ProductCategoryViewModel>()
            {
                Success = false,
                Data = null,
                Status = (int)ResponseStatusEnum.OK
            };
            try
            {
                var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
                var categories = categoryService.GetAvailableCategories().ToList();
                var allProduct = productService.GetAllAvailableProducts().Where(w => w.ProductType != (int)ProductTypeEnum.CardPayment);
                var products = allProduct.Where(w => w.GeneralProductId == null);
                var childrenProduct = allProduct.Where(w => w.GeneralProductId != null);
                var productData = products.Select(s => new ProductViewModel()
                {
                    ProductId = s.ProductId,
                    ProductName = s.ProductName,
                    Price = s.Price,
                    CateId = s.CatID,
                    HasExtra = s.HasExtra ?? false,
                    PicUrl = s.PicURL,
                    ChildrenProducts = childrenProduct.Where(w => w.GeneralProductId == s.ProductParentId)
                }).ToList();
                var data = new ProductCategoryViewModel()
                {
                    Categories = categories.Select(s => new Category()
                    {
                        Id = s.Code,
                        Name = s.Name
                    }).ToList(),
                    Products = productData.ToList()
                };
                // add data response
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
            }
            return result;
        }

        //[WebInvoke(Method = "GET",
        //            ResponseFormat = WebMessageFormat.Json,
        //            UriTemplate = "GetProducts")]
        //public BaseResponse<ProductCategoryViewModel> GetProducts()
        //{
        //    var result = new BaseResponse<ProductCategoryViewModel>()
        //    {
        //        Success = false,
        //        Data = null,
        //        Status = (int)ResponseStatusEnum.OK
        //    };
        //    try
        //    {
        //        var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
        //        var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
        //        var categories = categoryService.GetAvailableCategories().ToList();
        //        var products = productService.GetAvailableSingleProducts();
        //        var childrenProduct = productService.GetAvailableChildrenProducts();
        //        var productData = products.Select(s => new ProductViewModel()
        //        {
        //            ProductId = s.ProductId,
        //            ProductName = s.ProductName,
        //            Price = s.Price,
        //            CateId = s.CatID,
        //            HasExtra = s.HasExtra ?? false,
        //            PicUrl = s.PicURL,
        //            ChildrenProducts = childrenProduct.Where(w => w.GeneralProductId == s.ProductId)
        //        }).ToList();
        //        var data = new ProductCategoryViewModel()
        //        {
        //            Categories = categories.Select(s => new Category() { 
        //            Id=s.Code,
        //            Name=s.Name
        //            }).ToList(),
        //            Products = productData.ToList()
        //        };
        //        // add data response
        //        result.Success = true;
        //        result.Status = (int)ResponseStatusEnum.OK;
        //        result.Data = data;
        //    }
        //    catch (Exception)
        //    {
        //        result.Success = false;
        //        result.Status = (int)ResponseStatusEnum.ERROR;
        //    }
        //    return result;
        //}

        public BaseResponse<Account> Login(AccountRequest request)
        {
            var success = false;
            string message = "Đăng nhập thất bại.";
            var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            var account = accountService.CheckLogin(request.Username, request.Password);
            if (account != null)
            {
                success = true;
                message = "Đăng nhập thành công";
            }

            return new BaseResponse<Account>()
            {
                Success = success,
                Status = 200,
                Message = message,
                Data = account
            };
        }

        public RequestOrder MookGenRequestModel()
        {
            var requestOrder = new RequestOrder()
            {
                OrderDetails = new List<OrderDetail>()
            };
            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
            var products = productService.GetAvailableSingleProducts();
            var childrenProduct = productService.GetAvailableChildrenProducts();
            var productData = products.Select(s => new ProductViewModel()
            {
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                Price = s.Price,
                CateId = s.CatID,
                HasExtra = s.HasExtra ?? false,
                PicUrl = s.PicURL,
                ChildrenProducts = childrenProduct.Where(w => w.GeneralProductId == s.ProductId)
            }).ToList();
            var count = 5;
            var temp = 0;
            foreach (var item in productData)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = item.ProductId,
                    Quantity = count
                };
                requestOrder.OrderDetails.Add(orderDetail);
                if (temp++ > 10) break;
            }
            requestOrder.Payment = new Payment()
            {
                Type = (int)PaymentTypeEnum.Card,
                Code = "hihihungzday"
            };

            return requestOrder;
        }

        public BaseResponse<OrderViewModel> GetOrderByOrderCode(string orderCode)
        {
            BaseResponse<OrderViewModel> result = new BaseResponse<OrderViewModel>()
            {
                Status = (int)ResponseStatusEnum.ERROR,
                Success = false
            };

            var orderService = ServiceManager.GetService<POS.Repository.Entities.Services.OrderService>(typeof(OrderRepository));

            try
            {
                Order entity = orderService.GetOrderByOrderCode(orderCode);
                if (entity == null)
                {
                    result.Status = (int)ResponseStatusEnum.NOTFOUND;
                    return result;
                }
                else
                {
                    result.Success = true;
                    result.Status = (int)ResponseStatusEnum.OK;
                    AutoMapper.MapperConfiguration mapper = new AutoMapper.MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap(typeof(Order), typeof(OrderViewModel));
                    });
                    result.Data = mapper.CreateMapper().Map<Order, OrderViewModel>(entity);
                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
                return result;
            }
        }

        /// <summary>
        /// Kiểm tra voucher hiện tại còn sử dụng được hay không
        /// </summary>
        public async Task<BaseResponse<POS.Repository.ExchangeDataModel.VoucherResultModel>> CheckAvailableVoucher(string voucherCode, string memberCode)
        {
            var result = new BaseResponse<VoucherResultModel>
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            var voucherModel = await DataExchanger.CheckVoucher(voucherCode, memberCode);
            string promotionCode = null;
            if (!string.IsNullOrEmpty(voucherModel.PromotionCode))
                promotionCode = voucherModel.PromotionCode;
            else if (!string.IsNullOrEmpty(voucherModel.PromotionVM?.PromotionCode))
                promotionCode = voucherModel.PromotionVM.PromotionCode;

            bool hasPromotionDetail = false; //Nếu promotion mà không có promotionDetail thì cũng coi như voucher không dùng được
            bool unexpired = false; //kiểm tra promotion còn dùng được hay đã hết hạn
            if (!string.IsNullOrEmpty(promotionCode))
            {
                hasPromotionDetail = GetPromotionEditViewModel(promotionCode)?.PromotionDetailViewModels.Any() ?? false;
                unexpired = GetPromotionEditViewModel(promotionCode)?.IsAvailableDate(DateTime.Now) ?? false;
            }
            //if (voucherModel.Status == true && (voucherModel.PromotionVM == null 
            //    || string.IsNullOrEmpty(voucherModel.PromotionVM.PromotionCode)) 
            //    || voucherModel.Status == false)
            //{
            //    result.Success = false;
            //    result.Status = (int)ResponseStatusEnum.OK;
            //    result.Message = "Voucher không được áp dụng";

            //}
            //else
            //{
            //    result.Success = true;
            //    result.Status = (int)ResponseStatusEnum.OK;
            //    result.Message = "Voucher có thể áp dụng";
            //    result.Data = voucherModel;
            //}

            //Voucher cốt cũng để lấy promotionDetail ra để apply vào order, vậy nên nếu voucher không
            //cung cấp được promotionDetail thì coi như voucher không dùng được
            if (hasPromotionDetail == false || unexpired == false)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Message = "Voucher không được áp dụng";
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Message = "Voucher có thể áp dụng";
                result.Data = voucherModel;
            }
            return result;
        }


        /* --For Postman test api--
        Uri: http://localhost:6789/LocalService/ApplyVoucher
        Method: POST
        Body(raw, Json):
        {
	        "voucherCode": "GG20KIPX3Y748NS",
            "memberCode": "12",
            "requestOrder": {
                "OrderId": 1,
                "OrderDetails": [
                    {
                        "ProductId": 22222,
                        "Quantity": 2
                    },
                    {
                        "ProductId": 22222,
                        "Quantity": 5
                    },
                    {
                        "ProductId": 22341,
                        "Quantity": 1
                    }
                ],
                "Payment": {
                    "Type": 0,
                    "Code": 1
                },
                "Note": null
            }
        }
        */
        public async Task<BaseResponse<ResponseOrder>> ApplyVoucher(string voucherCode, RequestOrder requestOrder)
        {
            var result = new BaseResponse<ResponseOrder>
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                ResponseOrder responseOrder = CreateResponseOrder(requestOrder);

                BaseResponse<VoucherResultModel> checkVoucher = await CheckAvailableVoucher(voucherCode, responseOrder.Payment.Code);

                if (checkVoucher.Success == true) //Xử lý khi voucher hợp lệ
                {
                    string promotionCode = string.Empty;
                    if (checkVoucher.Data.PromotionVM != null)
                    {
                        if (!string.IsNullOrEmpty(checkVoucher.Data.PromotionVM.PromotionCode))
                        {
                            promotionCode = checkVoucher.Data.PromotionVM.PromotionCode;
                        }
                    }
                    else if (!string.IsNullOrEmpty(checkVoucher.Data.PromotionCode))
                    {
                        promotionCode = checkVoucher.Data.PromotionCode;
                    }

                    //Vì checkVoucher.Success == true nên chắc chắn  promotionCode != null or empty,
                    //nên không check promotionCode == null nữa mà xử lý luôn
                    var promotionEditViewModel = GetPromotionEditViewModel(promotionCode);
                    var promotionDetailViewModels = promotionEditViewModel.PromotionDetailViewModels;
                    int totalApplyFailed = 0;
                    string errorMessage = null;

                    foreach (var promotionDetail in promotionDetailViewModels)
                    {
                        var apply = ApplyPromotionDetail(promotionDetail, responseOrder, promotionEditViewModel.ApplyLevel);
                        if (apply.Success == false)
                        {
                            totalApplyFailed++;
                            errorMessage = apply.Message;
                        }
                    }

                    if (totalApplyFailed == promotionDetailViewModels.Count())
                    {
                        //trường hợp không có sản phẩm phù hợp trong order để apply vào 
                        //hoặc
                        //order không đạt điệu kiện của voucher
                        result.Success = false;
                        result.Data = null;
                        result.Message = errorMessage;
                    }
                    else
                    {
                        //trường hợp apply voucher thành công
                        UpdateOrder(responseOrder);
                        result.Success = true;
                        result.Status = (int)ResponseStatusEnum.OK;
                        result.Data = responseOrder;
                    }
                }
                else
                {
                    //trường hợp voucher không hợp lệ
                    result.Status = (int)ResponseStatusEnum.NOTFOUND;
                    result.Message = checkVoucher.Message;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        private ResponseOrder CreateResponseOrder(RequestOrder requestOrder)
        {
            ResponseOrder responseOrder = null;
            try
            {
                AutoMapper.MapperConfiguration mapper = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap(typeof(RequestOrder), typeof(ResponseOrder));
                });

                responseOrder = mapper.CreateMapper().Map<ResponseOrder>(requestOrder);

                var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
                //Đổ data từ db vào order để tính giá tiền
                foreach (var orderdeDetail in responseOrder.OrderDetails)
                {
                    orderdeDetail.ProductCode = productService.FirstOrDefault(p => p.ProductId == orderdeDetail.ProductId).Code;
                    orderdeDetail.TotalAmount = productService.FirstOrDefault(p => p.Code == orderdeDetail.ProductCode).Price * orderdeDetail.Quantity;
                    orderdeDetail.FinalAmount = orderdeDetail.TotalAmount;
                }
                responseOrder.TotalAmount = (int)responseOrder.OrderDetails.Sum(od => od.TotalAmount);
            }
            catch (Exception)
            {
                //Nuốt lỗi
            }
            return responseOrder;
        }

        /// <summary>
        /// Apply PromotionDetail vào Order hoặc OrderDetails
        /// </summary>
        /// <param name="applyLevel">Nhận giá trị từ enum (int)POS.Repository.PromotionApplyLevelEnum</param>
        private BaseResponse<string> ApplyPromotionDetail(POS.Repository.ViewModels
            .PromotionDetailViewModel promotionDetail, ResponseOrder responseOrder, int applyLevel)
        {
            var result = new BaseResponse<string>
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            bool isApplied = false;
            
            #region check constrain của promotionDetail với Order
            var checkPromotionDetailConstrainWithOrder = CheckPromotionDetailConstrainWithOrder(promotionDetail, responseOrder);
            if (checkPromotionDetailConstrainWithOrder.Item1 == false)
            {
                result.Message = checkPromotionDetailConstrainWithOrder.Item2;
                return result;
            }
            #endregion

            if (applyLevel == (int)PromotionApplyLevelEnum.Order)
            {
                CreatePromotionMappingOrder(promotionDetail, responseOrder);
                isApplied = true;
            }
            else if (applyLevel == (int)PromotionApplyLevelEnum.OrderDetail)
            {
                foreach (var orderDetail in responseOrder.OrderDetails)
                {
                    //kiểm tra khuyến mãi áp dụng riêng cho 1 sản phẩm
                    if (CheckPromotionDetailConstrainWithOrderDetail(promotionDetail, orderDetail))
                    {
                        CreatePromotionMappingOrderDetail(promotionDetail, orderDetail);
                        isApplied = true;
                    }
                }
            }

            if (isApplied)
            {
                //trường hợp có ít nhất 1 promotionDetail apply thành công vào order
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
            }
            else
            {
                //trường hợp không có promotionDetail nào apply thành công vào order.
                result.Message = "Sản phẩm không phù hợp với khuyến mãi";
            }
            return result;
        }

        //private int _currentorderdetailid = 0;
        private int _currentMappingId = 0;
        private void CreatePromotionMappingOrder(PromotionDetailViewModel promotionDetail, ResponseOrder responseOrder)
        {
            try
            {
                var mapping = new OrderPromotionMappingEditViewModel
                {
                    Id = _currentMappingId,
                    TmpMappingId = _currentMappingId++,
                    PromotionCode = promotionDetail.PromotionCode,
                    PromotionDetailCode = promotionDetail.PromotionDetailCode,
                    OrderId = responseOrder.OrderId
                };

                var index = 1;
                if (responseOrder.OrderPromotionMappingEditViewModels == null)
                {
                    responseOrder.OrderPromotionMappingEditViewModels = new List<OrderPromotionMappingEditViewModel>();
                }
                if (responseOrder.OrderPromotionMappingEditViewModels.Any())
                {
                    var lastMapping = responseOrder.OrderPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex).Last();
                    index = lastMapping.MappingIndex + 1;
                }

                mapping.MappingIndex = index;
                mapping.DiscountRate = promotionDetail.DiscountRate;
                mapping.DiscountAmount = promotionDetail.DiscountAmount;

                responseOrder.OrderPromotionMappingEditViewModels.Add(mapping);

                if (promotionDetail.GiftProductCode != null)
                {
                    //AddOrderDetailGift(promotionDetail, mapping, null);
                }
            }
            catch (Exception ex)
            {
                //log.Error("CreatePromotionMappingOrder - " + ex);
                //Program._log.SendLogError(ex);
            }
        }

        /// <summary>
        /// Mapping PromotionDetail vào OrderDetail
        /// </summary>
        private void CreatePromotionMappingOrderDetail(PromotionDetailViewModel promotionDetail, OrderDetail orderdetail)
        {
            try
            {
                var mapping = new OrderDetailPromotionMappingEditViewModel
                {
                    Id = _currentMappingId,
                    TmpMappingId = _currentMappingId++,
                    PromotionCode = promotionDetail.PromotionCode,
                    PromotionDetailCode = promotionDetail.PromotionDetailCode,
                    OrderDetailId = orderdetail.ProductId
                };

                var index = 1;
                if (orderdetail.OrderDetailPromotionMappingEditViewModels == null)
                {
                    orderdetail.OrderDetailPromotionMappingEditViewModels = new List<OrderDetailPromotionMappingEditViewModel>();
                }
                if (orderdetail.OrderDetailPromotionMappingEditViewModels.Any())
                {
                    var lastMapping = orderdetail.OrderDetailPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex).Last();
                    index = lastMapping.MappingIndex + 1;
                }

                mapping.MappingIndex = index;
                mapping.DiscountRate = promotionDetail.DiscountRate;
                mapping.DiscountAmount = promotionDetail.DiscountAmount;

                orderdetail.OrderDetailPromotionMappingEditViewModels.Add(mapping);

                if (promotionDetail.GiftProductCode != null)
                {
                    //AddOrderDetailGift(promotionDetail, null, mapping);
                }
            }
            catch (Exception ex)
            {
                //log.Error("CreatePromotionMappingOrderDetail - " + ex);
                //Program._log.SendLogError(ex);
            }
        }

        /// <summary>
        /// UNUSED. Kiểm tra thỏa mãn ràng buộc của 1 promotion detail cụ thể
        /// Lý do để nó ở đây là để tham khảo
        /// </summary>
        public bool CheckPromotionDetailConstrain(PromotionDetailViewModel promotionDetail, OrderDetailEditViewModel orderDetail = null)
        {
            var canApply = false;

            // Check Regular Expression constrain:
            // Ko RegEx + Ko Barcode    -> true
            // Ko RegEx + Có Barcode    -> true
            // Có RegEx + Ko Barcode    -> false
            // Có RegEx + Có Barcode    -> check regex
            //if (string.IsNullOrEmpty(promotionDetail.RegExCode))
            //{
            //    canApply = true;
            //}
            //else if (!string.IsNullOrEmpty(OrderEditViewModel.BarCode))
            //{
            //    if (OrderEditViewModel.PrefixBarCodes.Any())
            //    {
            //        foreach (var code in OrderEditViewModel.PrefixBarCodes)
            //        {
            //            string apiCode = code + Program.context.getCurrentOrderManager().getOrderEditViewModel().BarCode;

            //            canApply = Regex.IsMatch(apiCode, promotionDetail.RegExCode);

            //            if (canApply) break;
            //        }
            //    }
            //    else
            //    {
            //        canApply = Regex.IsMatch(OrderEditViewModel.BarCode, promotionDetail.RegExCode);
            //    }
            //}
            //else
            //{
            //    // false
            //}


            // Check Order Amount constrain
            //if (canApply)
            //{
            //    if (promotionDetail.MinOrderAmount != null)
            //    {
            //        if (promotionDetail.MaxOrderAmount == null)
            //        {
            //            if (OrderEditViewModel.FinalAmount < promotionDetail.MinOrderAmount)
            //            {
            //                canApply = false;
            //            }
            //        }
            //        else if (promotionDetail.MaxOrderAmount != null)
            //        {
            //            if (OrderEditViewModel.FinalAmount < promotionDetail.MinOrderAmount
            //                || promotionDetail.MaxOrderAmount < OrderEditViewModel.FinalAmount)
            //            {
            //                canApply = false;
            //            }
            //        }
            //    }
            //}

            //if (canApply)
            //{
            //    canApply = false;
            //    if (orderDetail != null)
            //    {
            //        //Check Applied for OrderDetail
            //        var mapping = orderDetail.OrderDetailPromotionMappingEditViewModels.FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode);
            //        if (mapping == null)
            //        {
            //            // Check Product constrain
            //            if (string.IsNullOrEmpty(promotionDetail.BuyProductCode))
            //            {
            //                canApply = true;
            //            }
            //            else
            //            {
            //                if (orderDetail.ProductCode == promotionDetail.BuyProductCode)
            //                {
            //                    canApply = true;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        foreach (var od in OrderEditViewModel.OrderDetailEditViewModels)
            //        {
            //            //Check Applied for OrderDetail
            //            var mapping = od.OrderDetailPromotionMappingEditViewModels.FirstOrDefault(m => m.PromotionCode == promotionDetail.PromotionCode);
            //            if (mapping == null)
            //            {
            //                // Check Product constrain
            //                if (string.IsNullOrEmpty(promotionDetail.BuyProductCode))
            //                {
            //                    canApply = true;
            //                }
            //                else
            //                {
            //                    if (od.ProductCode == promotionDetail.BuyProductCode)
            //                    {
            //                        canApply = true;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return canApply;
        }
        
        /// <summary>
        /// Kiểm tra 1 sản phẩm cụ thể có đáp ứng được điều kiện để apply promotion hay không,
        /// nếu có trả về true, ngược lại trả về false
        /// </summary>
        private bool CheckPromotionDetailConstrainWithOrderDetail(PromotionDetailViewModel promotionDetail, OrderDetail orderDetail)
        {
            if (promotionDetail.BuyProductCode != null
                        && (promotionDetail.BuyProductCode == null
                            || promotionDetail.BuyProductCode != orderDetail.ProductCode))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Kiểm tra order có đáp ứng đủ điều kiện để apply PromotionDetail hay không
        /// </summary>
        /// <returns>
        /// bool Item1: trả về true nếu order đáp ứng đủ điều kiện apply promotion.
        /// string Item2: trả về error message nếu order không đáp ứng đủ điều kiện để apply promotion
        /// </returns>
        private Tuple<bool, string> CheckPromotionDetailConstrainWithOrder(PromotionDetailViewModel promotionDetail, ResponseOrder responseOrder)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(true, null);
            if (promotionDetail.MinOrderAmount != null && promotionDetail.MinOrderAmount > responseOrder.TotalAmount)
            {
                result = new Tuple<bool, string>(false, $"Tổng giá hóa đơn tối thiểu cần đạt {promotionDetail.MinOrderAmount} để áp dụng khuyến mãi này");
            }
            if (promotionDetail.MaxOrderAmount != null && promotionDetail.MaxOrderAmount < responseOrder.TotalAmount)
            {
                result = new Tuple<bool, string>(false, $"Tổng giá hóa đơn tối đa để áp dụng khuyến mãi là {promotionDetail.MinOrderAmount}");
            }
            return result;
        }

        /// <summary>
        /// Get available PromotionEditViewModel
        /// </summary>
        /// <param name="promotionCode"></param>
        /// <returns></returns>
        private POS.Repository.ViewModels.PromotionEditViewModel GetPromotionEditViewModel(string promotionCode)
        {
            var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
            var promotionDetailService = ServiceManager.GetService<PromotionDetailService>(typeof(PromotionDetailRepository));
            var promotion = promotionService.GetAvailablePromotions().FirstOrDefault(p => p.PromotionCode == promotionCode);
            if (promotion == null)
            {
                return null;
            }
            AutoMapper.MapperConfiguration mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(Promotion), typeof(PromotionEditViewModel));
                cfg.CreateMap(typeof(PromotionDetail), typeof(PromotionDetailViewModel));
            });
            var promotionEditViewModel = mapperConfiguration.CreateMapper().Map<PromotionEditViewModel>(promotion);
            List<PromotionDetail> c = promotionDetailService.Get().Where(p => p.PromotionCode == promotionCode).ToList();
            if (c != null)
            {
                promotionEditViewModel.PromotionDetailViewModels = new List<PromotionDetailViewModel>();
            }
            foreach (var pd in c)
            {
                promotionEditViewModel.PromotionDetailViewModels.Add(mapperConfiguration.CreateMapper().Map<PromotionDetailViewModel>(pd));
            }
            return promotionEditViewModel;
        }

        /// <summary>
        /// Cập nhật lại FinalAmount, Discount,... của Order và OrderDetails
        /// </summary>
        private void UpdateOrder(ResponseOrder responseOrder)
        {
            responseOrder.TotalAmount = (int)responseOrder.OrderDetails.Sum(od => od.TotalAmount);
            UpdateDiscountOrder(responseOrder);
        }

        private void UpdateDiscountOrder(ResponseOrder responseOrder)
        {
            //Reset
            responseOrder.Discount = 0;
            responseOrder.DiscountOrderDetail = 0;

            //Tính giảm giá ở orderdetail
            foreach (var orderDetail in responseOrder.OrderDetails)
            {
                //Có khuyến mãi thì mới update discount
                if (orderDetail.OrderDetailPromotionMappingEditViewModels != null)
                {
                    UpdateDiscountOrderDetail(orderDetail);
                }
                responseOrder.DiscountOrderDetail += (int)orderDetail.Discount;
            }

            //Sau giảm giá sản phẩm
            responseOrder.FinalAmount = (int)(responseOrder.TotalAmount - responseOrder.DiscountOrderDetail);

            //Giảm giá theo thứ tự
            foreach (var mapping in responseOrder
                .OrderPromotionMappingEditViewModels.OrderBy(m => m.MappingIndex))
            {
                //Tìm thông tin promotion
                var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
                var promotion = GetPromotionEditViewModel(mapping.PromotionCode);
                var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault(d => d.PromotionDetailCode == mapping.PromotionDetailCode);

                if (promotion != null && promotionDetail != null)
                {
                    if (promotion.GiftType == (int)PromotionGiftTypeEnum.Gift)
                    {
                        //DO NOTHING:
                        //Tặng quà thì quà là orderdetail
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountRate)
                    {
                        //Lấy amount theo percent
                        var discountAmount = (int)
                            (responseOrder.FinalAmount * promotionDetail.DiscountRate / 100);
                        //Giảm giá không âm tiền
                        if (discountAmount + responseOrder.Discount
                            + responseOrder.DiscountOrderDetail > responseOrder.TotalAmount)
                        {
                            discountAmount = (int)(responseOrder.TotalAmount
                                - responseOrder.DiscountOrderDetail - responseOrder.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;
                        mapping.DiscountRate = promotionDetail.DiscountRate;

                        //Update orderdetail
                        responseOrder.Discount += discountAmount;
                        responseOrder.FinalAmount = (int)(responseOrder.TotalAmount
                            - responseOrder.DiscountOrderDetail
                            - responseOrder.Discount);
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountAmount)
                    {
                        //Lấy amount theo promotion
                        var discountAmount = promotionDetail.DiscountAmount;
                        //Giảm giá không âm tiền
                        if ((double)discountAmount + responseOrder.Discount
                            + responseOrder.DiscountOrderDetail > responseOrder.TotalAmount)
                        {
                            discountAmount = (int)(responseOrder.TotalAmount
                                - responseOrder.DiscountOrderDetail - responseOrder.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;

                        //Update orderdetail
                        responseOrder.Discount += (double)discountAmount.Value;
                        responseOrder.FinalAmount = (int)(responseOrder.TotalAmount
                            - responseOrder.DiscountOrderDetail
                            - responseOrder.Discount);
                    }
                }
            }
        }

        private void UpdateDiscountOrderDetail(OrderDetail orderDetail)
        {
            //Giảm giá theo thứ tự
            foreach (var mapping in orderDetail
                .OrderDetailPromotionMappingEditViewModels
                .OrderBy(m => m.MappingIndex))
            {
                //Tìm thông tin promotion
                var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
                var promotion = GetPromotionEditViewModel(mapping.PromotionCode);
                var promotionDetail = promotion.PromotionDetailViewModels.FirstOrDefault(d => d.PromotionDetailCode == mapping.PromotionDetailCode);

                if (promotion != null && promotionDetail != null)
                {
                    if (promotion.GiftType == (int)PromotionGiftTypeEnum.Gift)
                    {
                        if (mapping.DiscountAmount > 0)
                        {
                            orderDetail.Discount = orderDetail.TotalAmount;
                            orderDetail.FinalAmount = 0;
                        }
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountRate)
                    {
                        //Lấy amount theo percent
                        var discountAmount = (int)
                            (orderDetail.FinalAmount * promotionDetail.DiscountRate / 100);
                        //Giảm giá không âm tiền
                        if (discountAmount + orderDetail.Discount > orderDetail.TotalAmount)
                        {
                            discountAmount = (int)(orderDetail.TotalAmount - orderDetail.Discount);
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;
                        mapping.DiscountRate = promotionDetail.DiscountRate;

                        //Update orderdetail
                        orderDetail.Discount += discountAmount;
                        orderDetail.FinalAmount = orderDetail.TotalAmount - orderDetail.Discount;
                    }
                    else if (promotion.GiftType == (int)PromotionGiftTypeEnum.DiscountAmount)
                    {
                        //Lấy amount theo promotion
                        //var discountAmount = promotionDetail.DiscountAmount;
                        var discountAmount = promotionDetail.DiscountAmount * orderDetail.Quantity;

                        //Giảm giá không âm tiền
                        if ((double)discountAmount + orderDetail.Discount > orderDetail.TotalAmount)
                        {

                            discountAmount = (int)(orderDetail.TotalAmount - orderDetail.Discount);
                            //discountAmount = (int)(orderDetail.TotalAmount - (orderDetail.Discount * orderDetail.Quantity) );
                        }

                        //Update mapping
                        mapping.DiscountAmount = discountAmount;

                        //Update orderdetail
                        orderDetail.Discount += (double)discountAmount.Value;
                        orderDetail.FinalAmount = orderDetail.TotalAmount - orderDetail.Discount;
                    }
                }
            }
        }



    }

    public class OrderViewModel
    {

        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountOrderDetail { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public string Notes { get; set; }
        public string FeeDescription { get; set; }
        public string CheckInPerson { get; set; }
        public string CheckOutPerson { get; set; }
        public string ApprovePerson { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> SourceID { get; set; }
        public Nullable<int> TableId { get; set; }
        public bool IsFixedPrice { get; set; }
        public Nullable<System.DateTime> LastRecordDate { get; set; }
        public string ServedPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryCustomer { get; set; }
        public int TotalInvoicePrint { get; set; }
        public double VAT { get; set; }
        public double VATAmount { get; set; }
        public int NumberOfGuest { get; set; }
        public int GroupPaymentStatus { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }
        public string PromotionCode { get; set; }
        public string PasswordWifi { get; set; }
        public Nullable<int> CustomerType { get; set; }
        public Nullable<System.DateTime> LastModifiedPayment { get; set; }
        public Nullable<System.DateTime> LastModifiedOrderDetail { get; set; }
        public Nullable<bool> Active { get; set; }
        public string PaymentCode { get; set; }
        public Nullable<int> PersonCount { get; set; }
    }

    [DataContract]
    public class AccountRequest
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
    //  response object
    [DataContract]
    public class BaseResponse<T> where T : class
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }
        [DataMember(Name = "status")]
        public int Status { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
    [DataContract]
    public class BaseRequest
    {
        [DataMember(Name = "membership_code")]
        public string Message { get; set; }
    }
    public class ProductCategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int CateId { get; set; }
        public bool HasExtra { get; set; }
        public string PicUrl { get; set; }
        public IEnumerable<Product> ChildrenProducts { get; set; }
    }
    public class InvoiceCodeGenerator
    {
        public static string GenerateInvoiceCode()
        {
            DateTime dt = new DateTime(2016, 1, 1);
            TimeSpan ts = DateTime.UtcNow - dt;

            string code = ShortCodes.LongToShortCode((long)ts.TotalMilliseconds / 10);//1/10s
            return code;
        }
    }

    public static class ShortCodes
    {
        private static Random rand = new Random();

        // You may change the "shortcode_Keyspace" variable to contain as many or as few characters as you
        // please.  The more characters that aer included in the "shortcode_Keyspace" constant, the shorter
        // the codes you can produce for a given long.
        const string shortcode_Keyspace = "0123456789abcdefghijklmnopqrstuvwxyz";

        // Arbitrary constant for the maximum length of ShortCodes generated by the application.
        const int shortcode_maxLen = 12;
        public static string LongToShortCode(long number)
        {
            int ks_len = shortcode_Keyspace.Length;
            string sc_result = "";
            long num_to_encode = number;
            long i = 0;
            do
            {
                i++;
                sc_result = shortcode_Keyspace[(int)(num_to_encode % ks_len)] + sc_result;
                num_to_encode = ((num_to_encode - (num_to_encode % ks_len)) / ks_len);
            }
            while (num_to_encode != 0);
            return sc_result;
        }
        public static long ShortCodeToLong(string shortcode)
        {
            int ks_len = shortcode_Keyspace.Length;
            long sc_result = 0;
            int sc_length = shortcode.Length;
            string code_to_decode = shortcode;
            for (int i = 0; i < code_to_decode.Length; i++)
            {
                sc_length--;
                char code_char = code_to_decode[i];
                sc_result += shortcode_Keyspace.IndexOf(code_char) * (long)(Math.Pow((double)ks_len, (double)sc_length));
            }
            return sc_result;
        }
    }

    public class VoucherResponse
    {
        public string PromotionCode { get; set; }
        public int PromotionId { get; set; }
        public int DiscountRate { get; set; }
        public int DiscountAmount { get; set; }

    }
}
