using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using AutoMapper;
using POS.Repository.ViewModels;
using SkyWeb.DatVM.Data;

namespace POS.Repository.Entities.Services
{
    public class ServiceManager
    {
        // This class is used for mapping ViewModel and Entity
        // 1. GetService<>(Type t) is used for create new Service
        // 2. Tranformers area is used for map View Model to Entity or Entity to ViewModel
        //    2.1 When get data from database => map entity to EditViewModel (or ViewModel)
        //    2.2 When use CUD funtions => map EditViewModel (or ViewModel) to entity
        //    2.3 Need to map all references manualy
        // 3. When need to create new mapper => add new CreateMap to CreateAutoMapper

        /// <summary>
        /// Get new Service
        /// </summary>
        /// <typeparam name="T">Service Name</typeparam>
        /// <param name="t">Repository name</param>
        /// <returns>return new service</returns>
        public static T GetService<T>(Type t) where T : class
        {
            var db = GetDbEntities();
            IUnitOfWork uow = new UnitOfWork(db);
            var repo = Activator.CreateInstance(t, new object[] { db });
            return (T)Activator.CreateInstance(typeof(T), new object[] { uow, repo });
        }

        public static PointOfSaleDBEntities GetDbEntities()
        {
            var dataContext = new PointOfSaleDBEntities(BuildConnectionString());

            dataContext.Configuration.LazyLoadingEnabled = true;

            return dataContext;
        }
        private static string BuildConnectionString()
        {
            StoreInfo storeInfo = StoreInfoManager.GetStoreInfo(false);
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            sqlBuilder.DataSource = storeInfo.DatabaseServerName;
            sqlBuilder.InitialCatalog = storeInfo.DatabaseName;
            sqlBuilder.PersistSecurityInfo = true;
            sqlBuilder.IntegratedSecurity = false;
            sqlBuilder.UserID = storeInfo.DatabaseUsername;
            sqlBuilder.Password = storeInfo.DatabasePassword;
            sqlBuilder.MultipleActiveResultSets = true;

            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();
            entityBuilder.Metadata = "res://*/";
            entityBuilder.Provider = "System.Data.SqlClient";

            return entityBuilder.ToString();
        }

   
        public static void CreateAutoMapper()
        {
            #region Account & Customer
            Mapper.CreateMap<Account, AccountViewModel>();
            Mapper.CreateMap<AccountViewModel, Account>();

            Mapper.CreateMap<Customer, CustomerViewModel>();
            #endregion

            #region Order 
 
            Mapper.CreateMap<Order, OrderEditViewModel>();
            Mapper.CreateMap<OrderEditViewModel, Order>();

            Mapper.CreateMap<OrderDetail, OrderDetail>();
            Mapper.CreateMap<OrderDetailEditViewModel, OrderDetailEditViewModel>();
            Mapper.CreateMap<OrderDetail, OrderDetailEditViewModel>();
            Mapper.CreateMap<OrderDetailEditViewModel, OrderDetail>();

            Mapper.CreateMap<Payment, PaymentEditViewModel>();
            Mapper.CreateMap<PaymentEditViewModel, Payment>();
            #endregion

            #region Promotion 
            Mapper.CreateMap<Promotion, PromotionEditViewModel>();
            Mapper.CreateMap<PromotionEditViewModel, Promotion>();

            Mapper.CreateMap<PromotionDetail, PromotionDetailViewModel>();
            Mapper.CreateMap<PromotionDetailViewModel, PromotionDetail>();

            Mapper.CreateMap<OrderPromotionMapping, OrderPromotionMappingEditViewModel>();
            Mapper.CreateMap<OrderPromotionMappingEditViewModel, OrderPromotionMapping>();

            Mapper.CreateMap<OrderDetailPromotionMapping, OrderDetailPromotionMappingEditViewModel>();
            Mapper.CreateMap<OrderDetailPromotionMappingEditViewModel, OrderDetailPromotionMapping>();
            #endregion

            #region Product
            Mapper.CreateMap<Category, CategoryViewModel>();

            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<ProductViewModel, ProductViewModel>();

            Mapper.CreateMap<CategoryExtra, CategoryExtraViewModel>();
            Mapper.CreateMap<ProductExtra, ProductExtraViewModel>();
            #endregion

            #region Store & Table
            Mapper.CreateMap<Store, StoreViewModel>();

            Mapper.CreateMap<Table, TableViewModel>();
            Mapper.CreateMap<TableViewModel, Table>();
            #endregion

            #region Old Mapper
            //            AutoMapper.Mapper.CreateMap<Data.Order, Data.Order>()
            //                .ForMember(q => q.OrderId, opt => opt.Ignore())
            //                .ForMember(q => q.OrderDetails, opt => opt.Ignore())
            //                .ForMember(q => q.Payments, opt => opt.Ignore());
            //            AutoMapper.Mapper.CreateMap<Data.OrderDetail, Data.OrderDetail>()
            //                .ForMember(q => q.OrderId, opt => opt.Ignore())
            //                .ForMember(q => q.Order, opt => opt.Ignore())
            //                .ForMember(q => q.OrderDetailID, opt => opt.Ignore());
            //            AutoMapper.Mapper.CreateMap<Data.Payment, Data.Payment>()
            //                .ForMember(q => q.OrderId, opt => opt.Ignore())
            //                .ForMember(q => q.Order, opt => opt.Ignore())
            //                .ForMember(q => q.PaymentID, opt => opt.Ignore());
            #endregion
            Mapper.CreateMap<DateReportViewModel, DateReport>();
        }


        #region Tranformers

        /// <summary>
        /// Summary tranform step:
        /// 1. Order
        /// 2. Common OrderDetail 
        ///    & Extra OrderDetail
        /// 3. PromotionDetail Mapping
        /// 4. Gift of OrderDetail
        /// 5. Promotion Mapping
        /// 6. Gift of Order
        /// 7. Payment
        /// </summary>
        public static Order GetOrder(OrderEditViewModel orderEditViewModel)
        {
            // order
            Order order = new Order();
            Mapper.Map<OrderEditViewModel, Order>(orderEditViewModel, order);

            // orderdetail
            foreach (var orderDetailEVM in orderEditViewModel.OrderDetailEditViewModels)
            {
                var orderDetail = new OrderDetail();
                Mapper.Map<OrderDetailEditViewModel, OrderDetail>(orderDetailEVM, orderDetail);

                // orderdetail promotion mapping
                foreach (var pdmEVM in orderDetailEVM.OrderDetailPromotionMappingEditViewModels)
                {
                    var pdm = new OrderDetailPromotionMapping();
                    Mapper.Map<OrderDetailPromotionMappingEditViewModel, OrderDetailPromotionMapping>(pdmEVM, pdm);
                    orderDetail.OrderDetailPromotionMappings.Add(pdm);
                }
                order.OrderDetails.Add(orderDetail);
            }

            // order promotion mapping
            foreach (var promotionMappingEVM in orderEditViewModel.OrderPromotionMappingEditViewModels)
            {
                var promotionMapping = new OrderPromotionMapping();
                Mapper.Map<OrderPromotionMappingEditViewModel, OrderPromotionMapping>(promotionMappingEVM, promotionMapping);
                order.OrderPromotionMappings.Add(promotionMapping);
            }

            // payment
            foreach (var paymentEVM in orderEditViewModel.getPaymentEditViewModels())
            {
                var payment = new Payment();
                Mapper.Map<PaymentEditViewModel, Payment>(paymentEVM, payment);

                order.Payments.Add(payment);
            }

            return order;
        }

        public static OrderEditViewModel GetOrderEditViewModel(Order order)
        {
            OrderEditViewModel orderEditViewModel = new OrderEditViewModel();
            Mapper.Map<Order, OrderEditViewModel>(order, orderEditViewModel);
            if (order.OrderDetails != null)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    var orderDetailEditViewModel = GetOrderDetailEditViewModel(orderDetail);
                    orderEditViewModel.OrderDetailEditViewModels.Add(orderDetailEditViewModel);
                }
            }

            if (order.OrderPromotionMappings != null)
            {
                foreach (var promotionMapping in order.OrderPromotionMappings)
                {
                    var promotionEditViewModel = new OrderPromotionMappingEditViewModel();
                    Mapper.Map<OrderPromotionMapping, OrderPromotionMappingEditViewModel>(promotionMapping, promotionEditViewModel);

                    promotionEditViewModel.OrderEditViewModel = orderEditViewModel;

                    //foreach (var orderDetail in promotionMapping.OrderDetails)
                    //{
                    //    var orderDetailEditViewModel = GetOrderDetailEditViewModel(orderDetail);
                    //    promotionEditViewModel.OrderDetailEditViewModels.Add(orderDetailEditViewModel);
                    //}
                    orderEditViewModel.OrderPromotionMappingEditViewModels.Add(promotionEditViewModel);
                }
            }

            if (order.Payments != null)
            {
                foreach (var payment in order.Payments)
                {
                    var paymentEditViewModel = new PaymentEditViewModel();
                    Mapper.Map<Payment, PaymentEditViewModel>(payment, paymentEditViewModel);

                    paymentEditViewModel.OrderEditViewModel = orderEditViewModel;
                    orderEditViewModel.getPaymentEditViewModels().Add(paymentEditViewModel);
                }
            }

            return orderEditViewModel;
        }

        public static OrderDetailEditViewModel GetOrderDetailEditViewModel(OrderDetail entity)
        {
            var orderDetailEditViewModel = new OrderDetailEditViewModel();
            Mapper.Map<OrderDetail, OrderDetailEditViewModel>(entity, orderDetailEditViewModel);

            var orderEditViewModel = new OrderEditViewModel();
            Mapper.Map<Order, OrderEditViewModel>(entity.Order, orderEditViewModel);

            orderDetailEditViewModel.OrderEditViewModel = orderEditViewModel;

            foreach (var promotionMapping in entity.OrderDetailPromotionMappings)
            {
                var promotionDetailEditViewModel = new OrderDetailPromotionMappingEditViewModel();
                Mapper.Map<OrderDetailPromotionMapping, OrderDetailPromotionMappingEditViewModel>(promotionMapping, promotionDetailEditViewModel);

                promotionDetailEditViewModel.OrderDetailEditViewModel = orderDetailEditViewModel;
                orderDetailEditViewModel.OrderDetailPromotionMappingEditViewModels.Add(promotionDetailEditViewModel);
            }

            //TODO: Need to map Product & ProductViewModel
            return orderDetailEditViewModel;
        }

        public static List<OrderEditViewModel> GetOrderEditViewModels(List<Order> entities)
        {
            List<OrderEditViewModel> orderEditViewModels = new List<OrderEditViewModel>();

            foreach (var entity in entities)
            {
                var orderEditViewModel = GetOrderEditViewModel(entity);
                orderEditViewModels.Add(orderEditViewModel);
            }

            return orderEditViewModels;
        }

        public static Table GetTable(TableViewModel tableViewModel)
        {
            Table table = new Table();
            Mapper.Map<TableViewModel, Table>(tableViewModel, table);

            return table;
        }

        public static TableViewModel GetTableViewModel(Table entity)
        {
            //TableViewModel tableViewModel = new TableViewModel();
            return Mapper.Map<Table, TableViewModel>(entity);

            //return tableViewModel;
        }

        public static List<PromotionEditViewModel> GetPromotionEditViewModels(List<Promotion> entities)
        {
            List<PromotionEditViewModel> promotionEditViewModels = new List<PromotionEditViewModel>();

            foreach (var entity in entities)
            {
                PromotionEditViewModel promotionEditViewModel = new PromotionEditViewModel();
                AutoMapper.Mapper.Map<Promotion, PromotionEditViewModel>(entity, promotionEditViewModel);
                promotionEditViewModels.Add(promotionEditViewModel);
            }

            return promotionEditViewModels;
        }

        public static List<PromotionDetailViewModel> GetPromotionDetailViewModels(List<PromotionDetail> entities)
        {
            List<PromotionDetailViewModel> promotionDetailViewModels = new List<PromotionDetailViewModel>();

            foreach (var entity in entities)
            {
                PromotionDetailViewModel promotionDetailViewModel = new PromotionDetailViewModel();
                AutoMapper.Mapper.Map<PromotionDetail, PromotionDetailViewModel>(entity, promotionDetailViewModel);
                promotionDetailViewModels.Add(promotionDetailViewModel);
            }

            return promotionDetailViewModels;
        }

        public static List<TableViewModel> GetTableViewModels(List<Table> entities)
        {
            List<TableViewModel> tableViewModels = new List<TableViewModel>();

            foreach (var entity in entities)
            {
                TableViewModel tableViewModel = new TableViewModel();
                Mapper.Map<Table, TableViewModel>(entity, tableViewModel);
                tableViewModels.Add(tableViewModel);
            }

            return tableViewModels;
        }

        public static List<ProductViewModel> GetProductViewModels(List<Product> entities)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var entity in entities)
            {
                ProductViewModel productViewModel = new ProductViewModel();
                Mapper.Map<Product, ProductViewModel>(entity, productViewModel);
                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }

        public static ProductViewModel GetProductViewModel(Product entitiy)
        {
           

                ProductViewModel productViewModel = new ProductViewModel();
                Mapper.Map<Product, ProductViewModel>(entitiy, productViewModel);


            return productViewModel;
        }

        public static List<ProductExtraViewModel> GetProductExtraViewModels(List<ProductExtra> entities)
        {
            List<ProductExtraViewModel> productExtraViewModels = new List<ProductExtraViewModel>();

            foreach (var entity in entities)
            {
                ProductExtraViewModel productExtraViewModel = new ProductExtraViewModel();
                Mapper.Map<ProductExtra, ProductExtraViewModel>(entity, productExtraViewModel);
                productExtraViewModels.Add(productExtraViewModel);
            }

            return productExtraViewModels;
        }

        public static List<CategoryViewModel> GetCategoryViewModels(List<Category> entities)
        {
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();

            foreach (var entity in entities)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel();
                Mapper.Map<Category, CategoryViewModel>(entity, categoryViewModel);
                categoryViewModels.Add(categoryViewModel);
            }

            return categoryViewModels;
        }

        public static List<CategoryExtraViewModel> GetCategoryExtraViewModels(List<CategoryExtra> entities)
        {
            List<CategoryExtraViewModel> categoryExtraViewModels = new List<CategoryExtraViewModel>();

            foreach (var entity in entities)
            {
                CategoryExtraViewModel categoryExtra = new CategoryExtraViewModel();
                Mapper.Map<CategoryExtra, CategoryExtraViewModel>(entity, categoryExtra);
                categoryExtraViewModels.Add(categoryExtra);
            }

            return categoryExtraViewModels;
        }

        //public static List<CategoryExtraViewModel> GetCategoryExtraViewModels(List<Category> entities)
        //{
        //    List<CategoryExtraViewModel> categoryExtraViewModels = new List<CategoryExtraViewModel>();

        //    foreach (var entity in entities)
        //    {
        //        CategoryExtraViewModel categoryExtra = new CategoryExtraViewModel();
        //        Mapper.Map<Category, CategoryExtraViewModel>(entity, categoryExtra);
        //        categoryExtraViewModels.Add(categoryExtra);
        //    }

        //    return categoryExtraViewModels;
        //}

        public static AccountViewModel GetAccountViewModel(Account entity)
        {
            AccountViewModel accountViewModel = new AccountViewModel();
            Mapper.Map<Account, AccountViewModel>(entity, accountViewModel);

            return accountViewModel;
        }

        public static Account GettAccount(AccountViewModel accountViewModel)
        {
            Account account = new Account();
            Mapper.Map<AccountViewModel, Account>(accountViewModel, account);

            return account;
        }

        #endregion

    }
}
