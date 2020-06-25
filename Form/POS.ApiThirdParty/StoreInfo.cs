using System.Configuration;

namespace POS.ApiThirdPartyDLL
{
    public class StoreInfo
    {
        public StoreInfo()
        {
            BrandName = ConfigurationManager.AppSettings["BrandName"];
            TerminalName = ConfigurationManager.AppSettings["TerminalName"];
            TerminalAddress = ConfigurationManager.AppSettings["TerminalAddress"];
            TerminalPhone = ConfigurationManager.AppSettings["TerminalPhone"];
            WifiName = ConfigurationManager.AppSettings["WifiName"];
            WifiPassword = ConfigurationManager.AppSettings["WifiPassword"];
            ApplicationKey = ConfigurationManager.AppSettings["ApplicationKey"];
            UseLongLifeOrder = ConfigurationManager.AppSettings["UseLongLifeOrder"];
            UseCookerBill = ConfigurationManager.AppSettings["UseCookerBill"];
            TerminalKey = ConfigurationManager.AppSettings["TerminalKey"];
            HotLine = ConfigurationManager.AppSettings["HotLine"];
            SaveTableStatus = ConfigurationManager.AppSettings["SaveTableStatus"];
            LoadTableScreenFirst = ConfigurationManager.AppSettings["LoadTableScreenFirst"];
            //BrandMode = ConfigurationManager.AppSettings["BrandMode"];
            NotiSoundName = ConfigurationManager.AppSettings["NotiSoundName"];
            ProcessingCode = ConfigurationManager.AppSettings["ProcessingCode"];
            TerminalId = ConfigurationManager.AppSettings["TerminalID"];
            MerchantId = ConfigurationManager.AppSettings["MerchantID"];
            StaffId = ConfigurationManager.AppSettings["staffID"];
            DiscountPercent = ConfigurationManager.AppSettings["DiscountPercentage"];
            Saving = ConfigurationManager.AppSettings["Saving"];
            SmileCardUri = ConfigurationManager.AppSettings["api.SmileCard.Uri"];
        }
        public string BrandName { get; set; }
        public string TerminalName { get; set; }
        public string TerminalAddress { get; set; }
        public string TerminalPhone { get; set; }
        public string WifiName { get; set; }
        public string WifiPassword { get; set; }
        public string ApplicationKey { get; set; }
        public string UseLongLifeOrder { get; set; }
        public string UseCookerBill { get; set; }
        public string TerminalKey { get; set; }
        public string HotLine { get; set; }
        public string SaveTableStatus { get; set; }
        public string LoadTableScreenFirst { get; set; }
       // public string BrandMode { get; set; }
        public string NotiSoundName { get; set; }
        public string ProcessingCode { get; set; }
        public string TerminalId { get; set; }
        public string MerchantId { get; set; }
        public string StaffId { get; set; }
        public string DiscountPercent { get; set; }
        public string Saving { get; set; }
        public string SmileCardUri { get; set; }

    }
}
