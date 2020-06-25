using System.Collections.Generic;
using POS.Repository.ViewModels;
//using log4net;

namespace POS.ExchangeData
{
    public class MessageProcess
    {
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<ProductViewModel> AvailableSingleProducts { get; set; }
        public static List<CategoryViewModel> AvailableCategories { get; set; }
        public static List<ProductViewModel> AllProducts { get; set; }
        public static List<CategoryExtraViewModel> AllCategoryExtras { get; set; }
        public static List<PromotionEditViewModel> Promotions { get; set; }
        public static List<PromotionDetailViewModel> PromotionDetails { get; set; }
        public static List<TableViewModel> AllTables;

        public void ProcessMessage(MessageSend message)
        {
            DataExchanger.GetOrder(message.OrderId).Wait();
        }

        //public static void LoadProductsAndCategories()
        //{
        //    var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
        //    var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
        //    var categoryExtraService = ServiceManager.GetService<CategoryExtraService>(typeof(CategoryExtraRepository));
        //    var tableServer = ServiceManager.GetService<TableService>(typeof(TableRepository));
        //    //var productExtraService = ServiceManager.GetService<ProductExtraService>(typeof(ProductExtraRepository));

        //    AllProducts = null;
        //    AvailableSingleProducts = null;
        //    AvailableCategories = null;
        //    AllTables = null;

        //    //Load hết product
        //    AllProducts = ServiceManager.GetProductViewModels(productService.GetAllAvailableProducts().ToList());

        //    //Chỉ load product, không load child (size)
        //    AvailableSingleProducts = ServiceManager.GetProductViewModels(productService.GetAvailableSingleProducts().ToList());

        //    // Load tất cả CategoryExtra
        //    AllCategoryExtras =
        //        ServiceManager.GetCategoryExtraViewModels(categoryExtraService.Get(ce => ce.IsEnable == true).ToList());

        //    ////Load tat ca productExtras
        //    //AllProductExtras = ServiceManager.GetProductExtraViewModels(productExtraService.GetAvailableProductExtras().ToList());

        //    AvailableCategories = ServiceManager.GetCategoryViewModels(categoryService.GetAvailableCategories().ToList());

        //    // Load tất cả các bàn  trong database, dùng để hiển thị thông tin về bàn khi in hóa đơn
        //    AllTables = ServiceManager.GetTableViewModels(tableServer.GetAvailableTables().ToList());
        //}

        //public static void LoadPromotions()
        //{
        //    try
        //    {
        //        Promotions = null;
        //        PromotionDetails = null;

        //        var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
        //        var promotionDetailService =
        //            ServiceManager.GetService<PromotionDetailService>(typeof(PromotionDetailRepository));

        //        Promotions = ServiceManager.GetPromotionEditViewModels(promotionService.GetAvailablePromotions().ToList());
        //        PromotionDetails = ServiceManager.GetPromotionDetailViewModels(promotionDetailService.Get().ToList());

        //        foreach (var promotion in Promotions)
        //        {
        //            foreach (var detail in PromotionDetails)
        //            {
        //                if (promotion.PromotionDetailViewModels == null)
        //                {
        //                    promotion.PromotionDetailViewModels = new List<PromotionDetailViewModel>();
        //                }

        //                if (detail.PromotionCode == promotion.PromotionCode)
        //                {
        //                    promotion.PromotionDetailViewModels.Add(detail);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

    }
}
