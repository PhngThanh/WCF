using System;
using System.Linq;
using System.Diagnostics;
using POS.Utils;
using POS.ExchangeData;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;
using System.IO;
//using UniLogLibFramework.Library;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        public static MainForm MainForm;
        public static BussinessContext context = BussinessContext.GetInstance();
        //public static LogMonitor _log = new LogMonitor();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                ServiceManager.CreateAutoMapper();
                CheckToGetData();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm = new MainForm();
                if (Ultis.EnableConnection())
                {
                    if (MainForm.PosConfig.EnableAutoExchange == null || MainForm.PosConfig.EnableAutoExchange.Trim().ToLower() == "true")
                    {
                        RunAutoData(); //Start Auto Send Data: AutoExchangeData.exe
                                       //RunNoti();
                    }
                    if(MainForm.StoreInfo.SignalrEnable!=null && MainForm.StoreInfo.SignalrEnable.Equals("true"))
                    {
                        RunWcfAndSignalr();
                        MainForm.StartSignalr();
                    }
                    //MainForm.StartCheckOnlineThread();
                    MainForm.StartGetThreads(); //Start Auto Get Data: Thread
                    
                }

                Application.Run(MainForm);
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
                MessageBox.Show(MainForm.ResManager.GetString("Check_Config", MainForm.CultureInfo));
            }

        }

        private static bool _autoExchangeDataExists = true;

        public static void RunAutoData()
        {
            Process[] pname = Process.GetProcessesByName("AutoExchangeData");
            //ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (pname.Length == 0)
            {
                //log.Info("AutoExchangeData.exe - Unstarted - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                try
                {
                    var currentDir = Environment.CurrentDirectory;
                    var path = currentDir + @"\AutoExchangeData.exe";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                        //log.Info("AutoExchangeData.exe - Started - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                    }
                    else //Chưa có auto data -> chỉ log error 1 lần
                    {
                        if (_autoExchangeDataExists)
                        {
                            _autoExchangeDataExists = false;
                            //log.Error("AutoExchangeData.exe not exists !!! --- "
                            //+ UtcDateTime.Now().ToString("HH:mm:ss"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //_log.SendLogError(ex);
                    //log.Error("RunAutoData - " + ex);
                }
            }
            else
            {
                //Do nothing: AutoExchangeData is running
            }
        }

        public static void RunNoti()
        {
            Process[] pname = Process.GetProcessesByName("POS.Noti");
            //ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (pname.Length == 0)
            {
                //log.Info("POS.Noti - Starting - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                try
                {
                    var currentDir = Environment.CurrentDirectory;
                    var path = currentDir + @"\POS.Noti.exe";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                        //log.Info("POS.Noti.exe - Started - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                    }
                }
                catch (Exception ex)
                {
                    //_log.SendLogError(ex);
                    //log.Error("RunNoti - " + ex);
                }
            }
            else
            {
                //Do nothing: AutoExchangeData is running
            }
        }

        static void CheckToGetData()
        {
            //Debug.WriteLine("Exchange Data");
            var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            var account = accountService.CntAccount().Count();
            if (account == 0)
            {
                DataExchanger.GetNewAccount();
            }

            var categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
            var category = categoryService.GetAvailableCategories().Count();
            if (category == 0)
            {
                DataExchanger.GetNewProductCategory();
            }

            var productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
            var product = productService.GetAvailableSingleProducts().Count();
            if (product == 0)
            {
                DataExchanger.GetNewProduct();
            }

            var promotionService = ServiceManager.GetService<PromotionService>(typeof(PromotionRepository));
            var countPromotion = promotionService.GetAvailablePromotions().Count();
            if (countPromotion == 0)
            {
                DataExchanger.GetNewPromotion();
            }
        }

        #region run local api
        static void RunWcfAndSignalr()
        {
            
                Process[] pname = Process.GetProcessesByName("WcfAndSignalr");
            //ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            if (pname.Length == 0)
            {
                //log.Info("AutoExchangeData.exe - Unstarted - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                try
                {
                    var currentDir = Environment.CurrentDirectory;
                    var path = currentDir + @"\WcfAndSignalr\WcfAndSignalr.exe";
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                        //log.Info("AutoExchangeData.exe - Started - " + UtcDateTime.Now().ToString("HH:mm:ss"));
                    }
                    else //Chưa có auto data -> chỉ log error 1 lần
                    {
                        if (_autoExchangeDataExists)
                        {
                            _autoExchangeDataExists = false;
                            //log.Error("AutoExchangeData.exe not exists !!! --- "
                            //+ UtcDateTime.Now().ToString("HH:mm:ss"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    //_log.SendLogError(ex);
                    //log.Error("RunAutoData - " + ex);
                }
            }
            else
            {
                //Do nothing: AutoExchangeData is running
            }
        }
        #endregion
    }


}
