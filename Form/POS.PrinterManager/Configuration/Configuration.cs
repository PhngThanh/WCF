using POS.Repository;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager.Configuration
{
    public class Configuration
    {
        private static StoreInfo storeInfo;
        private static PosConfig posConfig;
        private static List<ProductViewModel> AvailableSingleProducts;
        private static List<CategoryViewModel> AvailableCategories;
        private static List<ProductViewModel> AllProducts;
        private static List<CategoryExtraViewModel> AllCategoryExtras;
        private static List<PromotionEditViewModel> Promotions;
        private static List<PromotionDetailViewModel> PromotionDetails;
        private static List<TableViewModel> AllTables;
        private static CultureInfo CultureInfo; //Declare culture info
        private static ResourceManager ResManager;
        public static StoreInfo GetStoreInfo()
        {
            if(storeInfo==null)
            {
                storeInfo = StoreInfoManager.GetStoreInfo(true);
            }
            return storeInfo;
        }
        public static PosConfig GetPosConfig()
        {
            if (posConfig == null)
            {
                posConfig = StoreInfoManager.GetPosConfig(true);
            }
            return posConfig;
        }

        public static List<ProductViewModel> GetAvailableSingleProducts()
        {
            AvailableSingleProducts = StoreInfoManager.GetAvailableSingleProducts();
            return AvailableSingleProducts;

        }
        public static List<CategoryViewModel> GetAvailableCategories()
        {
            AvailableCategories = StoreInfoManager.GetAvailableCategories();
            return AvailableCategories;

        }
        public static List<ProductViewModel> GetAllProducts()
        {
            AllProducts = StoreInfoManager.GetAllProducts();
            return AllProducts;

        }
        public static List<CategoryExtraViewModel> GetAllCategoryExtras()
        {
            AllCategoryExtras = StoreInfoManager.GetAllCategoryExtras();
            return AllCategoryExtras;

        }
        public static List<PromotionEditViewModel> GetPromotions()
        {
            Promotions = StoreInfoManager.GetPromotions();
            return Promotions;
        }
        public static List<PromotionDetailViewModel> GetPromotionDetails()
        {
            PromotionDetails = StoreInfoManager.GetPromotionDetails();
            return PromotionDetails;
        }

        public static List<TableViewModel> GetAllTable()
        {
            AllTables = StoreInfoManager.GetAllTable();
            return AllTables;
        }
        public static CultureInfo GetCultureInfo()
        {
            CultureInfo = StoreInfoManager.GetCultureInfo();
            return CultureInfo;
        }
        public static ResourceManager GetResourceManager()
        {
            ResManager = StoreInfoManager.GetResourceManager();
            return ResManager;
        }
    }
}
