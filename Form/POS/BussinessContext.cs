
using POS.Repository;
using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using POS.SaleScreen;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class BussinessContext
    {
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager CurrentOrderManager = new CurrentOrderManager();
        private static SerialPort mySerialPort;
        private static List<ProductViewModel> AvailableSingleProducts;
        private static List<CategoryViewModel> AvailableCategories;
        private static List<ProductViewModel> AllProducts;
        private static List<CategoryExtraViewModel> AllCategoryExtras;
        private static List<PromotionEditViewModel> Promotions;
        private static List<PromotionDetailViewModel> PromotionDetails;
        private static List<ProductExtraViewModel> AllProductExtras;
        /// <summary>
        /// This list only use for set table number in Receipt.
        /// Don't use this list to get current table status
        /// </summary>
        private static List<TableViewModel> AllTables;
        public List<SortedProduct> MostProducts { get; set; }

        private static BussinessContext _context;
        private BussinessContext()
        {
            
        }

        public static BussinessContext GetInstance()
        {
            if (_context == null)
            {
                _context = new BussinessContext();
            }
            return _context;
        }

        #region Contructor

        //contructor for AvailableSingleProducts
        public List<ProductViewModel> getAvailableSingleProducts()
        {
            return AvailableSingleProducts;
        }

        public void setAvailableSingleProducts(List<ProductViewModel> listModel)
        {
            AvailableSingleProducts = listModel;
        }

        public void addAvailableSingleProduct(ProductViewModel model)
        {
            AvailableSingleProducts.Add(model);
        }

        //constructor for AllProducts
        public List<ProductViewModel> getAllProducts()
        {
            return AllProducts;
        }

        public void setAllProducts(List<ProductViewModel> listModel)
        {
            AllProducts = listModel;
        }

        public void addProduct(ProductViewModel model)
        {
            AllProducts.Add(model);
        }

        //coonstructor for CurrentOrderManager
        public CurrentOrderManager getCurrentOrderManager()
        {
            return CurrentOrderManager;
        }

        //constructor for promotion List<PromotionEditViewModel> Promotions;
        public List<PromotionEditViewModel> getPromotions()
        {
            return Promotions;
        }

        public void setPromotions(List<PromotionEditViewModel> listModel)
        {
            Promotions = listModel;
        }

        public void addPromotion(PromotionEditViewModel model)
        {
            Promotions.Add(model);
        }

        //Constuctor for PromotionDetails;
        public List<PromotionDetailViewModel> getPromotionDetails()
        {
            return PromotionDetails;
        }

        public void setPromotionDetails(List<PromotionDetailViewModel> listModel)
        {
            PromotionDetails = listModel;
        }

        public void addPromotionDetail(PromotionDetailViewModel model)
        {
            PromotionDetails.Add(model);
        }

        //Constuctor for SerialPort mySerialPort
        public SerialPort getSerialPort()
        {
            return mySerialPort;
        }

        public void setSerialPort(SerialPort serialPort)
        {
            mySerialPort = serialPort;
        }

        // Constructor for AllCategoryExtras;
        public List<CategoryExtraViewModel> getAllCategoryExtras()
        {
            return AllCategoryExtras;
        }

        public void setAllCategoryExtras(List<CategoryExtraViewModel> listModel)
        {
            AllCategoryExtras = listModel;
        }

        public void addAllCategoryExtra(CategoryExtraViewModel model)
        {
            AllCategoryExtras.Add(model);
        }

        //Contrustor for AvailableCategories;
        public List<CategoryViewModel> getAvailableCategories()
        {
            return AvailableCategories;
        }

        public void setAllCategoryExtras(List<CategoryViewModel> listModel)
        {
            AvailableCategories = listModel;
        }

        public void addAvailableCategories(CategoryViewModel model)
        {
            AvailableCategories.Add(model);
        }
        //Contructor for  List<TableViewModel> AllTables
        public List<TableViewModel> getAllTables()
        {
            return AllTables;
        }

        public void setAllTables(List<TableViewModel> listModel)
        {
            AllTables = listModel;
        }

        public void addAllTables(TableViewModel model)
        {
            AllTables.Add(model);
        }


        #endregion


        #region Bussiness function 
        // Dùng cho chức năng update products / categories 
        public void LoadProductsAndCategories()
        {
            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
            var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
            var categoryExtraService = ServiceManager.GetService<CategoryExtraService>(typeof(CategoryExtraRepository));
            var tableServer = ServiceManager.GetService<TableService>(typeof(TableRepository));
            var productExtraService = ServiceManager.GetService<ProductExtraService>(typeof(ProductExtraRepository));
            var orderDetailService = ServiceManager.GetService<OrderDetailService>(typeof(OrderDetailRepository));
            AllProducts = null;
            AvailableSingleProducts = null;
            AvailableCategories = null;
            AllCategoryExtras = null;
            AllTables = null;
            AllProductExtras = null;

            ProductViewModel code = null;
            //Load hết product
            AllProducts = ServiceManager.GetProductViewModels(productService.GetAllAvailableProducts().ToList());
            //foreach(ProductViewModel product in AllProducts)
            //{
            //    if (product.ProductName.Equals("Raspberry Chiller-L"))
            //    {
            //        code = product;
            //    }
            //        Console.Write(product.Code)
            //        ;
            //}
            //Chỉ load product, không load child (size)
            AvailableSingleProducts = ServiceManager.GetProductViewModels(productService.GetAvailableSingleProducts().ToList());

            // Load tất cả CategoryExtra
            AllCategoryExtras = ServiceManager.GetCategoryExtraViewModels(categoryExtraService.GetAvailableCategoriesExtra().ToList());

            ////Load tat ca productExtras
            AllProductExtras = ServiceManager.GetProductExtraViewModels(productExtraService.GetAvailableProductExtras().ToList());

            //Load tất cả các categories 
            AvailableCategories = ServiceManager.GetCategoryViewModels(categoryService.GetAvailableCategories().ToList());

            // Load tất cả các bàn  trong database, dùng để hiển thị thông tin về bàn khi in hóa đơn
            AllTables = ServiceManager.GetTableViewModels(tableServer.GetAvailableTables().ToList());

            MostProducts = orderDetailService.GetMostProducts().ToList();
            AllProducts.ForEach(s => {
                var product = MostProducts.FirstOrDefault(f => f.Code == s.Code);
                s.Position = product != null ? product.Count : 0;
            });
        }

        public void LoadPromotions()
        {
            try
            {
                Promotions = null;
                PromotionDetails = null;

                var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
                var promotionDetailService =
                    ServiceManager.GetService<PromotionDetailService>(typeof(PromotionDetailRepository));

                Promotions = ServiceManager.GetPromotionEditViewModels(promotionService.GetAvailablePromotions().ToList());
                PromotionDetails = ServiceManager.GetPromotionDetailViewModels(promotionDetailService.Get().ToList());

                foreach (var promotion in Promotions)
                {
                    foreach (var detail in PromotionDetails)
                    {
                        if (promotion.PromotionDetailViewModels == null)
                        {
                            promotion.PromotionDetailViewModels = new List<PromotionDetailViewModel>();
                        }

                        if (detail.PromotionCode == promotion.PromotionCode)
                        {
                            promotion.PromotionDetailViewModels.Add(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Program._log.SendLogError(ex);
                //log.Error("LoadPromotions - " + ex);
            }
        }

        //Dùng để add thêm event cho CurrentManager 

        public void addNotifyChangeOrderDetail(Action<OrderDetailEditViewModel, OrderDetailChangeModeEnum> method)
        {
            CurrentOrderManager.NotifyChangeOrderDetail += method;
        }

        public static ProductViewModel getProductVMByProductCode(string productCode)
        {
            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
            var productEntity = productService.GetActive().Where(p => p.Code == productCode).FirstOrDefault();
            if (productEntity != null)
            {
                return ServiceManager.GetProductViewModel(productEntity);
            }
           
            return null;
        }
        #endregion


    }
}
