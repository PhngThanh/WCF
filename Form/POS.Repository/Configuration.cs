using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using Newtonsoft.Json;
using POS.Repository.ViewModels;
using SkyConnect.POSLib.Utils;
//using UniLogLibFramework.Library;

namespace POS.Repository
{
    public class StoreInfoManager
    {
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly LogMonitor _log = new LogMonitor();

        private static StoreInfo storeInfo;
        private static PosConfig posConfig;
        private static PaymentTypeConfig paymentType;
        private static MenuInfo menuInfo;
        private static SkyConnectConfig SkyConnectInfo;

        //private static List<ProductViewModel> AvailableSingleProducts;
        //private static List<CategoryViewModel> AvailableCategories;
        //private static List<ProductViewModel> AllProducts;
        //private static List<CategoryExtraViewModel> AllCategoryExtras;
        //private static List<PromotionEditViewModel> Promotions;
        //private static List<PromotionDetailViewModel> PromotionDetails;
        //private static List<TableViewModel> AllTables;

        private static CultureInfo CultureInfo; //Declare culture info
        private static ResourceManager ResManager;

        private static POS.Repository.Entities.Services.ProductService productService
            = Entities.Services.ServiceManager.GetService<Entities.Services.ProductService>(
                typeof(Entities.Repositories.ProductRepository));
        private static POS.Repository.Entities.Services.CategoryService categoryService 
            = Entities.Services.ServiceManager.GetService<Entities.Services.CategoryService>(
                typeof(Entities.Repositories.CategoryRepository));
        private static POS.Repository.Entities.Services.CategoryExtraService categoryExtraService 
            = Entities.Services.ServiceManager.GetService<Entities.Services.CategoryExtraService>(
                typeof(Entities.Repositories.CategoryExtraRepository));
        private static POS.Repository.Entities.Services.PromotionService promotionService
            = Entities.Services.ServiceManager.GetService<Entities.Services.PromotionService>(
                typeof(Entities.Repositories.PromotionRepository));
        private static POS.Repository.Entities.Services.PromotionDetailService promotionDetailService 
            = Entities.Services.ServiceManager.GetService<Entities.Services.PromotionDetailService>(
                typeof(Entities.Repositories.PromotionDetailRepository));
        private static POS.Repository.Entities.Services.TableService tableService
            = Entities.Services.ServiceManager.GetService<Entities.Services.TableService>(
                typeof(Entities.Repositories.TableRepository));

        public static List<ProductViewModel> GetAvailableSingleProducts()
        {
            return Entities.Services.ServiceManager.GetProductViewModels(productService.GetAvailableSingleProducts().ToList());
        }
        public static List<CategoryViewModel> GetAvailableCategories()
        {
            return Entities.Services.ServiceManager.GetCategoryViewModels(categoryService.GetAvailableCategories().ToList());
        }
        public static List<ProductViewModel> GetAllProducts()
        {
            return Entities.Services.ServiceManager.GetProductViewModels(productService.GetAllAvailableProducts().ToList());
        }
        public static List<CategoryExtraViewModel> GetAllCategoryExtras()
        {
            return Entities.Services.ServiceManager.GetCategoryExtraViewModels(categoryExtraService.GetAvailableCategoriesExtra().ToList()); ;
        }
        public static List<PromotionEditViewModel> GetPromotions()
        {
            return Entities.Services.ServiceManager.GetPromotionEditViewModels(promotionService.GetAvailablePromotions().ToList());
        }

        public static List<PromotionDetailViewModel> GetPromotionDetails()
        {
            return Entities.Services.ServiceManager.GetPromotionDetailViewModels(promotionDetailService.Get().ToList());
        }

        public static List<TableViewModel> GetAllTable()
        {
            return Entities.Services.ServiceManager.GetTableViewModels(tableService.GetAvailableTables().ToList());
        }
        public static CultureInfo GetCultureInfo()
        {
            return CultureInfo;
        }
        public static void SetCultureInfo(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
        }
        public static ResourceManager GetResourceManager()
        {
            return ResManager;
        }
        public static void SetResourceManager(ResourceManager resourceManager)
        {
            ResManager = resourceManager;
        }

        public static StoreInfo GetStoreInfo(bool isRefesh)
        {
            if (storeInfo == null || isRefesh)
            {
                var currentDir = Environment.CurrentDirectory;
                var path = currentDir + @"\Configuration\storeInfo.json";
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    try
                    {
                        storeInfo = JsonConvert.DeserializeObject<StoreInfo>(json);

                        //init value if don't have in config file
                        if (String.IsNullOrWhiteSpace(storeInfo.MomoEnable))
                            storeInfo.MomoEnable = "false";

                        if (String.IsNullOrEmpty(storeInfo.PrintWifiPassword))
                            storeInfo.PrintWifiPassword = "false";

                        if (String.IsNullOrEmpty(storeInfo.GiftTalkCardEnable))
                            storeInfo.GiftTalkCardEnable = "false";
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetStoreInfo - " + ex);
                        //_log.SendLogError(ex);
                    }
                }
            }

            return storeInfo;
        }

        public static PosConfig GetPosConfig(bool isRefesh)
        {
            if (posConfig == null || isRefesh)
            {
                var currentDir = Environment.CurrentDirectory;
                var path = currentDir + @"\Configuration\posConfig.json";
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    try
                    {
                        posConfig = JsonConvert.DeserializeObject<PosConfig>(json);
                    }
                    catch (Exception ex)
                    {
                        //log.Error("GetPosConfig - " + ex);
                        //_log.SendLogError(ex);
                    }
                }
            }

            return posConfig;
        }

        public static PaymentTypeConfig GetPaymentTypeConfig(bool isRefesh)
        {
            if (paymentType == null || isRefesh)
            {
                paymentType = GetPosConfig(true).paymentType;
            }

            return paymentType;
        }

        public static MenuInfo GetMenuInfo(bool isRefresh)
        {
            if (menuInfo == null || isRefresh)
            {
                menuInfo = GetPosConfig(true).menuInfo;
            }
            return menuInfo;
        }

        public static SkyConnectConfig GetSkyConnectConfig(bool isRefresh)
        {
            if (SkyConnectInfo == null || isRefresh)
            {
                SkyConnectInfo = GetStoreInfo(true).SkyConnectConfig;
            }
            return SkyConnectInfo;
        }


        public static bool UpdateMenuInfo()
        {
            var currentDir = Environment.CurrentDirectory;
            var path = currentDir + @"\Configuration\menuInfo.json";

            using (StreamWriter w = new StreamWriter(path, false))
            {
                w.AutoFlush = true;
                String json = JsonConvert.SerializeObject(menuInfo);
                w.WriteLine(json);
            }
            return true;
        }
    }
    
    public class StoreInfo
    {
        //SERVER
        public string ServerUri { get; set; }
        public string ServerToken { get; set; }
        public string StoreId { get; set; }
        public string DatabaseServerName { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }

        //STORE
        public string TerminalName { get; set; }
        public string TerminalAddress { get; set; }
        public string HotLine { get; set; }

        public string ComputerScreenResolution { get; set; }

        public string MainColor { get; set; }
        public string LogoSimple { get; set; }
        public string LogoPrint { get; set; }

        public string QRCodeEnable { get; set; }
        public string QRCodeURL { get; set; }
        public string QRCodeDescription { get; set; }
        public string MomoEnable { get; set; }
        public string ZaloEnable { get; set; }

        //WIFI
        public string IsShowWifiInfo { get; set; }
        public string WifiName { get; set; }
        public string WifiPassword { get; set; }
        public string IsGeneratePassWifi { get; set; }
        public string WiSkyLocationId { get; set; }

        //ENDING TEXT
        public string EndingTextOnBill { get; set; }

        public string OrderCodeText { get; set; }
        public string TakeAwayText { get; set; }
        public string AtStoreText { get; set; }
        public string DeliveryText { get; set; }
        public string OnlineOrderText { get; set; }

        //PRINTER

        public string EnablePrintPreview { get; set; }
        public string EnablePrintBillCook { get; set; }

        //"Microsoft Print to PDF",
        public string PrintBillOrder { get; set; }
        public string IsPrintBillCookWhenSaveTable { get; set; }
        // Main Bill
        public string PrinterBill { get; set; }
        // Cook Bill
        public string PrinterCook1 { get; set; }
        public string PrinterCook2 { get; set; }
        public string PrinterCook3 { get; set; }

        // Label Bill
        public string PrinterLabel { get; set; }
        public string PrinterDetail { get; set; }
        public string MomoConnection { get; set; }

        public string PrintWifiPassword { get; set; }
        public string Whitelist { get; set; }

        //ThirdParty
        public string GiftTalkCardEnable { get; set; }
        public SkyConnectConfig SkyConnectConfig { get; set; }
        public string SkyConnectEnable { get; set; }
        public string SkyConnectForCustomer { get; set; }
        //signalr
        public string SignalrEnable { get; set; }
        public Signalr Signalr { get; set; }

        //Redis
        public string EnableRedis { get; set; }
    }

    public class PosConfig
    {
        //SKYPOS
        public string LoadTableScreenFirst { get; set; }

        //SEVER - STORE
        public string EnableRunningAutoData { get; set; }
        public string EnableGetAndProcessOrderFromServer { get; set; }

        //--------------DO NOT CHANGE THIS !!!--------------
        //"InvoideCodepattern": "TEST-{StoreId}-{Code}",
        public string InvoideCodepattern { get; set; }
        //--------------DO NOT CHANGE THIS !!!--------------

        //POS
        public string Language { get; set; }
        public string EnableSound { get; set; }
        public string EnableOnscreenKeyboard { get; set; }
        public string NotiSoundName { get; set; }

        public string SaveTableStatus { get; set; }
        public string EnableUpdatePassword { get; set; }
        public string EnableAutoExchange { get; set; }

        //MAIN SCREEN
        public string HasDelivery { get; set; }
        public string HasTakeAway { get; set; }
        public string HasAtStore { get; set; }
        public string TakeAwayDifferDelivery { get; set; }
        public string EnableServeTypeDialog { get; set; }

        //Floor name
        public string Floor0 { get; set; }
        public string Floor1 { get; set; }
        public string Floor2 { get; set; }
        public string Floor3 { get; set; }
        public string Floor4 { get; set; }
        public string Floor5 { get; set; }

        //SALE SCREEN
        //Scale (cân) area
        public string ScaleCommunicatePort { get; set; }
        public double RatioToGram { get; set; }
        public string ResultWeightUnit { get; set; }
        public string IsUsingScale { get; set; }
        public string IsUpdateExtraWhenUpdateOrderDetail { get; set; }

        public string IsShowMostOrderMenu { get; set; }
        public string UsingCategoryLevel { get; set; }

        public string IsShowMemberPoint { get; set; }
        public string IsShowCustomerNotes { get; set; }

        public string EnableVAT { get; set; }
        public string EnableOwe { get; set; }
        public string EnableTakeNote { get; set; }
        public string EnableChangeTable { get; set; }
        public string EnableQuickSaleMode { get; set; }
        public string EnableChangeOrderType { get; set; }
        public string EnableChangeServedStaff { get; set; }

        public int BarcodeDurationTime { get; set; }
        public int BarcodeRecognizeTime { get; set; }
        public string BarcodeCompletedPromotion { get; set; }
        public string EnableSecondScreen { get; set; }
        public string EnableScanBarcodeForProdcut { get; set; }

        //VIEW ORDER
        public string EnableDeliveryStatus { get; set; }
        public string RequiredPasswordExportReport { get; set; }
        public string RequiredPasswordUpdate { get; set; }
        public string RequiredPasswordCancel { get; set; }
        public string IsShowMoneyReport { get; set; }
        public string EnableReceiptPrintPreview { get; set; }
        public string EnableViewCancelDetail { get; set; }
        public string EnableQuantityColor { get; set; }

        public PaymentTypeConfig paymentType { get; set; }
        public MenuInfo menuInfo { get; set; }

        //KITCHEN SCREEN
        public string EnableKitchenMode { get; set; }
        public string IsOnlyUseKitchen { get; set; }
        public string EnableAutoRefreshKitchenScreen { get; set; }

       
    }

    public class Signalr
    {
        public string Url { get; set; }
        public string UserId { get; set; }
    }
    public class PaymentTypeConfig
    {
        //money|cc-visa|cc-mastercard|ticket|cc|users|hashtag|star-half-o|
        public string Tab1 { get; set; }
        public string Tab2 { get; set; }
        public string Tab3 { get; set; }
        public string Tab4 { get; set; }
        public string Tab5 { get; set; }
        public string Tab6 { get; set; }
        public string Tab7 { get; set; }
        public string Tab8 { get; set; }
    }

    public class MenuInfo
    {
        public List<MenuItemInfo> MenuList { get; set; }
    }

    public class MenuItemInfo
    {
        public String Code { get; set; }
        public int Quantity { get; set; }
    }
}
