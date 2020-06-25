using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Resources;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Forms;
using POS.Utils;
using POS.Splash;
using POS.Common;
using POS.SaleScreen;
using POS.LoginScreen;
using POS.TableScreen;
using POS.ExchangeData;
using POS.CustomControl;
using POS.DashboardScreen.ReportScreen;
using POS.DashboardScreen;
using POS.DashboardScreen.OnlineOrderScreen;
using POS.DashboardScreen.ViewOrderScreen;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using WMPLib;
using POS.PrintManager;
using System.Reflection;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using AutoUpdaterDotNET;
using System.Net;
using System.Net.Cache;
using System.Text;
using SkyConnect.POSLib.Utils;
using POS.SaleScreen.SecondScreen;
using Microsoft.AspNet.SignalR.Client;
//using UniLogLibFramework.Library;

namespace POS
{
    public partial class MainForm : Form
    {
        private static readonly string StoreId = ConfigurationManager.AppSettings["storeId"];
        //private static readonly LogMonitor _log = new LogMonitor();
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Thread _getDataThread;
        private Thread _checkOnineThread;
        private WindowsFormsSynchronizationContext _mUiContext = new WindowsFormsSynchronizationContext();

        public TableScreen2 _tablePanel;

        private SaleScreen3 _saleScreen;
        private ReviewOrderScreen _reviewOrderScreen;


        public static PaymentTypeConfig PaymentType { get; set; }
        public static AccountViewModel CurrentAccount { get; set; }
        public static StoreInfo StoreInfo { get; set; }
        public static PosConfig PosConfig { get; set; }
        public static MenuInfo MenuInfo { get; set; }
        public static SkyConnectConfig SkyConnectInfo { get; set; }
        public static CultureInfo CultureInfo { get; set; } //Declare culture info
        public static ResourceManager ResManager { get; set; } //Declare Resource manager to access to specific cultureinfo
        private static String configuarationUrl;


        public int TotalNewOnlineOrders = 0;
        public bool hasUpdate;
        public bool IsChangeTableMode = false;
        public static HashSet<int> Messagequeue = new HashSet<int>();

        private bool _isShownMessage = false;
        private static bool _stopExchanger = false;
        private static bool _isGetDataRunning = false;
        private static bool _isCheckOnline = true;
        private static int _delayExchange = 0;
        private static string fileCodeName = "Code.txt";




        public MainForm()
        {
            try
            {
                // CurrentAccount = new AccountViewModel { StaffName = "Staff" };

                if (PriorProcess()) // check chi 1 process POS duoc chay
                {
                    Environment.Exit(0);
                }
                else
                {
                    StoreInfo = StoreInfoManager.GetStoreInfo(true);
                    PosConfig = StoreInfoManager.GetPosConfig(true);
                    //VATInvoice = StoreInfoManager.GetVATInvoice(true);
                    PaymentType = StoreInfoManager.GetPaymentTypeConfig(true);
                    MenuInfo = StoreInfoManager.GetMenuInfo(true);
                    SkyConnectInfo = StoreInfoManager.GetSkyConnectConfig(true);

                    //default value when null
                    if (string.IsNullOrEmpty(StoreInfo.MomoEnable.Trim().ToLower()))
                        StoreInfo.MomoEnable = "false";

                    ColorScheme.MainColor = ColorTranslator.FromHtml((string)StoreInfo.MainColor);


                    if (PosConfig.Language.ToLower().Equals("vi"))
                    {
                        SetLanguage("vi");
                    }
                    else if (PosConfig.Language.ToLower().Equals("en"))
                    {
                        SetLanguage("en");
                    }
                    //TODO:
                    //Because just have vi now
                    SetLanguage("vi");
                    ////checkStoreCode();

                    checkUpdate();

                    InitializeComponent();

                    SetLogo( this.ptbLogo, "./Resources/" + StoreInfo.LogoSimple);

                    //this.ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    //this.ptbLogo.ImageLocation = "./Resources/" + StoreInfo.LogoSimple;
                    this.btnConfig.TextValue = ResManager.GetString("Mainform_Control_Board", CultureInfo);
                    this.btnHideApplication.TextValue = ResManager.GetString("Mainform_Minimize_Screen", CultureInfo);
                    OnScreenKeyboardDialog.CreateInstance();
                    CreateNotiSound();
                    POSVersion();
                    //GetPromotions();

                    CurrentAccount = new AccountViewModel()
                    {
                        AccountId = "quanly"
                    };

                    LoadLoginScreen();

                    _saleScreen = new SaleScreen3();
                    if (PosConfig.EnableSecondScreen != null && PosConfig.EnableSecondScreen.Trim().ToLower() == "true")
                    {
                        loadSecondScreen();
                    }
                    
                    //_reviewOrder = new ReviewOrderScreen();

                    //UpdateOnlineOrderFromDatabase();
                }
                this.KeyPreview = true;
                //this.KeyDown += MainForm_KeyDown;
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
                //log.Error("MainForm - " + ex);
            }
        }

        private void loadSecondScreen()
        {
            OrderOnSecondScreen pnlSecondScreen = new OrderOnSecondScreen();
            Screen[] sc = Screen.AllScreens;
            //get all the screen width and heights 
            pnlSecondScreen.FormBorderStyle = FormBorderStyle.None;
            pnlSecondScreen.Left = sc[0].Bounds.Width + 1;
            pnlSecondScreen.StartPosition = FormStartPosition.Manual;
            pnlSecondScreen.Show();
            Program.context.addNotifyChangeOrderDetail(pnlSecondScreen.UpdateWhenOrderDetailChange);
        }

        private void checkUpdate()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            //AutoUpdater.StoreId = StoreInfo.StoreId;
            AutoUpdater.Start(System.Configuration.ConfigurationManager.AppSettings["domainSourceVersion"] + StoreInfo.TerminalName + ".xml");
        }

        private void checkStoreCode()
        {
            Boolean isExit = checkKeyFromFile();
            string data = string.Empty;
            Boolean isSuccess = false;
            if (!isExit)
            {
                string key = string.Empty;
                while (!isSuccess)
                {
                    var isEnableOnscreenKeyboard = MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true";
                    var inputVoucherCode = PosMessageDialog.YesNoDialogWithInput(
                                //message:Xin điền mã code
                                MainForm.ResManager.GetString("Mainform_Please_Enter_Store_Code", MainForm.CultureInfo) + ":", MainForm.ResManager.GetString("Sys_Yes", MainForm.CultureInfo), MainForm.ResManager.GetString("Sys_No", MainForm.CultureInfo),
                                isEnableOnscreenKeyboard, "");
                    if (inputVoucherCode != null)
                    {
                        key = inputVoucherCode[0];
                        if (checkCodeExit(key))
                        {
                            var currentDir = Environment.CurrentDirectory;
                            string filepath = currentDir + "\\" + fileCodeName;
                            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
                            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
                            sWriter.WriteLine(key);
                            // Ghi và đóng file
                            sWriter.Flush();
                            fs.Close();
                            isSuccess = true;
                        }
                        else
                        {
                            //message:Mã cửa hàng không đúng. Vui lòng nhập lại!
                            PosMessageDialog.ShowMessage(MainForm.ResManager.GetString("Mainform_Wrong_Store_Code", MainForm.CultureInfo));
                        }
                    }
                    else
                    {
                        // exit neu chon cancel
                        Environment.Exit(0);
                    }

                }
            }

            if (isSuccess)
            {
                //write string to file
                System.IO.File.WriteAllText(@"key.json", data);
            }

        }

        private bool checkCodeExit(string code)
        {
           if(code == String.Empty)
            {
                return false;
            }
            var config = StoreInfoManager.GetStoreInfo(true).SkyConnectConfig;
            var pDomain = new SkyConnect.POSLib.Domains.APIs.StoreAPI(config);
            var apiReponse = pDomain.getStoreConfigByCode(code);
            if(apiReponse.Result.Success)
            {
                return true;
            }

            return false;
        }

        private Boolean checkKeyFromFile()
        {
            var currentDir = Environment.CurrentDirectory;
            string filepath = currentDir + "\\" + fileCodeName;
            string result = string.Empty;
            string key = string.Empty;
            var isCodeExist = false;

            if (File.Exists(filepath))
            {
                using (StreamReader r = new StreamReader(filepath))
                {
                    string json = r.ReadToEnd();
                    isCodeExist = checkCodeExit(json);
                }
            }

            return isCodeExist;
        }

        public static System.Drawing.Bitmap GetImage(string imageName)
        {
            string imagePath = Path.Combine(Environment.CurrentDirectory, @"Resources\", imageName);
            try
            {
                Bitmap bitmap = new Bitmap(imagePath);
                return bitmap;
            }
            catch (Exception)
            {
                string imagePathDefault = Path.Combine(Environment.CurrentDirectory, @"Resources\", "logo-skypos.png");
                Bitmap bitmap = new Bitmap(imagePathDefault);
                return bitmap;
            }
        }
        public static void SetLogo( PictureBox ptbLogo,string logoPath)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(logoPath);
            ptbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbLogo.Width = img.Width * ptbLogo.Height / img.Height ;
            ptbLogo.ImageLocation = logoPath;
            //ptbLogo.Image = img;
        }
        private void POSVersion()
        {
            try
            {
                lblSkyPOSVersion.Text = "Version_" + Application.ProductVersion;
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
                //log.Error("POSVersion - " + ex);
            }
        }

        public void StartSignalr()
        {
            IHubProxy _hub;
            string url = StoreInfo.Signalr.Url;
            var userId = StoreInfo.Signalr.UserId;
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("TestHub");
            connection.Headers.Add("userId", userId);
            connection.Start().Wait();

            _hub.On("send", x => updateOnPOS(true));
        }

        public void StartGetThreads()
        {
            _getDataThread = new Thread(GetDataFormServer);
            _getDataThread.Start();
        }

        public void StartCheckOnlineThread()
        {
            _checkOnineThread = new Thread(checkOnline);
            _checkOnineThread.Start();
        }

        private async void checkOnline()
        {
            try
            {
                var sleepTime = 5000;
                if (!_isCheckOnline)
                {
                   if (DataExchanger.CheckForInternetConnection())
                   {
                        updateOnPOS(true);
                        _isCheckOnline = true;
                   }
                   else
                   {
                     _isCheckOnline = false;
                   }
                }
                Thread.Sleep(sleepTime);
            }
            catch (Exception ex)
            {
                //_log.SendLogError(ex);
                //log.Error("checkOnline - " + ex);
                _isCheckOnline = false;
            }
            finally
            {
                if (!_stopExchanger)
                {
                    checkOnline();
                }
               
            }
        }

        private async void GetDataFormServer()
        {
            try
            {
                if (!_isGetDataRunning)
                {
                    _isGetDataRunning = true;

                    while (_isGetDataRunning)
                    {
                        var sleepTime = 30000;                          //30s
                        if (_delayExchange > 1) sleepTime = 300000;     //300s = 5 min 

                        if (sleepTime > 30000)
                        {
                            //_log.SendLogError(ex);
                            //log.Info("GetDataFormServer delay " + sleepTime.ToString() + " - "
                            //    + UtcDateTime.Now().ToString("HH:mm:ss"));
                        }

                        Thread.Sleep(sleepTime);

                        if (PosConfig.EnableRunningAutoData.Trim().ToLower() == "true")
                        {
                            Program.RunAutoData();
                        }

                        var hasConnection = false;
                        if (DataExchanger.CheckForInternetConnection())
                        {
                            hasConnection = true;
                            if (PosConfig.EnableGetAndProcessOrderFromServer.Trim().ToLower() == "true")
                            {
                                //Lay don hang o Server ve POS
                                this.hasUpdate = await GetAndProcessMessageFromServer();
                            }
                        }
                        else
                        {
                            //Không có kết nối internet
                           _delayExchange++;
                           _isCheckOnline = false;
                        }
                        updateOnPOS(hasConnection);
                        //Update on POS

                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("GetDataFormServer - " + ex);
                //_log.SendLogError(ex);
                _isGetDataRunning = false;
            }
            finally
            {
                if (!_stopExchanger)
                {
                    GetDataFormServer();
                }
            }
        }

        private void updateOnPOS(Boolean hasConnection)
        {
            if (_tablePanel != null)
            {
                var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var today = UtcDateTime.Now().Date;
                var countDeliOrder = orderService
                    .Get(o => o.DeliveryStatus == (int)DeliveryStatusEnum.Assigned
                        && o.OrderType == (int)OrderTypeEnum.Delivery
                        && o.CheckInDate.Day == today.Day
                        && o.CheckInDate.Month == today.Month
                        && o.CheckInDate.Year == today.Year)
                    .AsEnumerable();
                var cnt = countDeliOrder.Count();
                this.Invoke((MethodInvoker)delegate
                {
                    this.UpdateInternetStatus(hasConnection);
                    this.UpdateDashboardStatus(hasUpdate);

                    if (countDeliOrder.Any())
                    {
                        TotalNewOnlineOrders = countDeliOrder.Count();
                        this.PlayNotiSound();
                        this.UpdateButtonOnlineOrder();
                    }
                    else
                    {
                        TotalNewOnlineOrders = 0;
                        this.UpdateButtonOnlineOrder();
                    }
                });
            }
        }

        private static async Task<bool> GetAndProcessMessageFromServer()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(StoreInfo.ServerUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                MessageProcess messageProcess = new MessageProcess();

                var isContinue = false;
                var needUpdate = false;

                do
                {
                    try
                    {
                        // HTTP GET: Lần đầu tiên kiểm tra Queue
                        HttpResponseMessage response = client.GetAsync((string)("api/message/GetMessage/" + StoreInfo.ServerToken + "/" + StoreInfo.StoreId)).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            _delayExchange = 0;

                            //Dữ liệu của queue được lấy về
                            MessageSend message = await response.Content.ReadAsAsync<MessageSend>();

                            if (message.NotifyType == (int)NotifyMessageType.NoThing)
                            {
                                //Do nothing
                            }
                            else if (message.NotifyType == (int)NotifyMessageType.OrderChange)
                            {
                                //Get Order
                                messageProcess.ProcessMessage(message);
                                isContinue = message.CheckFlag;
                            }
                            else if (message.NotifyType == (int)NotifyMessageType.AccountChange
                                    || message.NotifyType == (int)NotifyMessageType.CategoryChange
                                    || message.NotifyType == (int)NotifyMessageType.ProductChange
                                    || message.NotifyType == (int)NotifyMessageType.PromotionChange)
                            {
                                //Need Update
                                needUpdate = true;
                                Messagequeue.Add(message.NotifyType);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //_log.SendLogError(ex);
                        //if (ex.Message.Contains("An error occurred while sending the request"))
                        //{
                        //    log.Error("Can't connect to server !!! --- "
                        //        + UtcDateTime.Now().ToString("HH:mm:ss"));
                        //}
                        //else if (ex.Message.Contains("An exception occurred during a Ping request"))
                        //{
                        //    log.Error("Internet problem !!! --- "
                        //        + UtcDateTime.Now().ToString("HH:mm:ss"));
                        //}
                        //else
                        //{
                        //    log.Error("GetAndProcessMessageFromServer - " + ex);
                        //}

                        _delayExchange++;
                        return needUpdate;
                    }
                }
                while (isContinue);

                return needUpdate;
            }
        }

        private void UpdateInternetStatus(bool hasConnection)
        {
            try
            {
                //Đang xử lý
                //Tổng đài
                //Xem hóa đơn
                //Rớt mạng
                var doing = ResManager.GetString("Sys_Wait_For_Progressing", CultureInfo);
                var onlineOrder = ResManager.GetString("Mainform_Telephone_Exchange", CultureInfo);
                var viewOrder = ResManager.GetString("Mainform_View_Bill", CultureInfo);
                var noConnect = ResManager.GetString("Sys_Connection_Error", CultureInfo);

                if (hasConnection)
                {
                    if (!btnOnlineOrder.TextValue.Contains(doing))
                    {
                        btnOnlineOrder.TextValue = onlineOrder;
                    }

                    btnViewOrder.TextValue = viewOrder;
                    btnOnlineOrder.BackgroudBootstrapColor = BootstrapColorEnum.Primary;
                    btnViewOrder.BackgroudBootstrapColor = BootstrapColorEnum.Primary;

                    _isShownMessage = false;
                }
                else
                {
                    //RỚT MẠNG
                    if (!btnOnlineOrder.TextValue.Contains(doing))
                    {
                        btnOnlineOrder.TextValue = noConnect;
                    }

                    btnViewOrder.TextValue = noConnect;
                    btnOnlineOrder.BackgroudBootstrapColor = BootstrapColorEnum.Danger;
                    btnViewOrder.BackgroudBootstrapColor = BootstrapColorEnum.Danger;
                    if (!_isShownMessage)
                    {
                        var time = UtcDateTime.Now();
                        //message: Xin kiểm tra lại ngày giờ hệ thống. \n Giờ hệ thống đang được cài đặt:\n
                        var str = ResManager.GetString("Mainform_Please_Check_Time", CultureInfo)
                            + ":"
                            + "\n" + ResManager.GetString("Mainform_Time_Now", CultureInfo)
                            + "\n" + time.ToString("dd/MMM/yyyy HH:mm:ss");

                        //PosMessageDialog.ShowMessage(str);
                        _isShownMessage = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("UpdateInternetStatus - " + ex);
                //_log.SendLogError(ex);
            }
        }

        public void UpdateButtonOnlineOrder()
        {
            try
            {
                //Đang xử lý
                //Tổng đài
                var doing = ResManager.GetString("Sys_Wait_For_Progressing", CultureInfo);
                var onlineOrder = ResManager.GetString("Mainform_Telephone_Exchange", CultureInfo);

                if (TotalNewOnlineOrders > 0)
                {
                    this.btnOnlineOrder.TextValue = doing + " (" + TotalNewOnlineOrders + ")";
                    this.btnOnlineOrder.TextColor = Color.Black;
                    this.btnOnlineOrder.ImageColor = Color.Black;
                }
                else
                {
                    this.btnOnlineOrder.TextValue = onlineOrder;
                    this.btnOnlineOrder.TextColor = Color.White;
                    this.btnOnlineOrder.ImageColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                //log.Error("UpdateButtonOnlineOrder - " + ex);
                //_log.SendLogError(ex);
            }
        }

        public void UpdateDashboardStatus(bool hasUpdate)
        {
            try
            {
                if (hasUpdate)
                {
                    this.btnConfig.TextValue = ResManager.GetString("Mainform_Has_Update", CultureInfo);
                    this.btnConfig.BackgroudBootstrapColor = BootstrapColorEnum.Warning;
                }
                else
                {
                    this.btnConfig.TextValue = ResManager.GetString("Mainform_Control_Board", CultureInfo);
                    this.btnConfig.BackgroudBootstrapColor = BootstrapColorEnum.Primary;
                }
            }
            catch (Exception ex)
            {
                //log.Error("UpdateDashboardStatus - " + ex);
                //_log.SendLogError(ex);
            }
        }

        /// <summary>
        /// Check if 1 time only 1 process run
        /// </summary>
        public bool PriorProcess()
        {
            try
            {
                Process curr = Process.GetCurrentProcess();
                Process[] procs = Process.GetProcessesByName(curr.ProcessName);
                foreach (Process p in procs)
                {
                    if ((p.Id != curr.Id) &&
                        (p.MainModule.FileName == curr.MainModule.FileName))
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log.Error("PriorProcess - " + ex);
                //_log.SendLogError(ex);
                return false;
            }
        }

        /// <summary>
        /// Without this, need 2 clicks to come back from numpad.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            // WM_MOUSEACTIVATE = 0x21
            if (m.Msg == 0x21 && CanFocus && !Focused) Focus();
            base.WndProc(ref m);
        }

        public void SetLanguage(string language = "en")
        {
            CultureInfo = CultureInfo.CreateSpecificCulture(language);
            ResManager = new ResourceManager("POS.LanguageResources.LangRes", typeof(MainForm).Assembly);
        }


        #region ScreencCommunication

        public void LoadLoginScreen()
        {
            var loginScreen = new LoginScreen1();

            if (MainForm.PosConfig.LoadTableScreenFirst.Trim().ToLower() == "true")
            {
                LoadFirstScreen(); //For dev fast login
                MainForm.PosConfig.LoadTableScreenFirst = "false"; //For Logout  
            }
            else
            {
                LoadScreen(loginScreen, true, false);
            }
        }

        public void LoadFirstScreen()
        {
            if (MainForm.PosConfig.IsOnlyUseKitchen.Trim().ToLower() == "true")
            {
                LoadKitchenScreen();
            }
            else
            {
                LoadTableScreen();
            }
        }

        /// <summary>
        /// Check if first time open screen 
        /// Then set Button Control of TableViewModel : Hide / Show / IsActive 
        /// </summary>
        private void LoadButtonControlTable()
        {
            try
            {
                //Check if first time open screen
                //(all control IsActive = false)
                if (btnAtStoreMode.IsActive == false
                    && btnDeliveryMode.IsActive == false
                    && btnTakeAwayMode.IsActive == false
                    && btnFloor0.IsActive == false
                    && btnFloor1.IsActive == false
                    && btnFloor2.IsActive == false
                    && btnFloor3.IsActive == false
                    && btnFloor4.IsActive == false
                    && btnFloor5.IsActive == false)
                {
                    #region Button ServeTypeMode

                    btnAtStoreMode.ActiveBackgroudColor = Color.Black;
                    btnDeliveryMode.ActiveBackgroudColor = Color.Black;
                    btnTakeAwayMode.ActiveBackgroudColor = Color.Black;

                    if (PosConfig.EnableServeTypeDialog.Trim().ToLower() == "true")
                    {
                        //Màn hình chọn loại sẽ hiện ở giữa
                        btnAtStoreMode.Hide();
                        btnTakeAwayMode.Hide();
                        btnDeliveryMode.Hide();
                    }
                    else
                    {
                        //At store
                        if (PosConfig.HasAtStore.Trim().ToLower() == "true")
                        {
                            btnAtStoreMode.Visible = true;
                            btnAtStoreMode.IsActive = true;
                        }
                        else
                        {
                            btnAtStoreMode.Visible = false;
                        }

                        //Takeaway
                        if (PosConfig.HasTakeAway.Trim().ToLower() == "true")
                        {
                            btnTakeAwayMode.Visible = true;
                        }
                        else
                        {
                            btnTakeAwayMode.Visible = false;
                        }

                        //Delivery
                        if (PosConfig.HasDelivery.Trim().ToLower() == "true")
                        {
                            btnDeliveryMode.Visible = true;
                        }
                        else
                        {
                            btnDeliveryMode.Visible = false;
                        }
                    }

                    #endregion

                    #region Button SelectFloor

                    //Get max floor
                    var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                    int maxFloor = tableService.StoreHasFloor();

                    //Update floor button
                    btnFloor0.ActiveBackgroudColor = Color.Black;
                    btnFloor0.TextValue = MainForm.PosConfig.Floor0;
                    btnFloor1.ActiveBackgroudColor = Color.Black;
                    btnFloor1.TextValue = MainForm.PosConfig.Floor1;
                    btnFloor2.ActiveBackgroudColor = Color.Black;
                    btnFloor2.TextValue = MainForm.PosConfig.Floor2;
                    btnFloor3.ActiveBackgroudColor = Color.Black;
                    btnFloor3.TextValue = MainForm.PosConfig.Floor3;
                    btnFloor4.ActiveBackgroudColor = Color.Black;
                    btnFloor4.TextValue = MainForm.PosConfig.Floor4;
                    btnFloor5.ActiveBackgroudColor = Color.Black;
                    btnFloor5.TextValue = MainForm.PosConfig.Floor5;

                    btnFloor0.IsActive = true;
                    btnFloor1.IsActive = false;
                    btnFloor2.IsActive = false;
                    btnFloor3.IsActive = false;
                    btnFloor4.IsActive = false;
                    btnFloor5.IsActive = false;

                    //Hide floor not use
                    if (maxFloor != 5)
                    {
                        btnFloor5.Hide();
                        if (maxFloor != 4)
                        {
                            btnFloor4.Hide();
                            if (maxFloor != 3)
                            {
                                btnFloor3.Hide();
                                if (maxFloor != 2)
                                {
                                    btnFloor2.Hide();
                                    if (maxFloor != 1)
                                    {
                                        btnFloor1.Hide();
                                        btnFloor0.Hide();
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                //log.Error("LoadButtonControlTable - " + ex);
                //_log.SendLogError(ex);
            }
        }

        public void LoadTableScreen()
        {
            try
            {
                //Load button control Table
                LoadButtonControlTable();

                //TablePanel duoc giu xuyen suot trong chuong trinh
                if (_tablePanel == null)
                {
                    _tablePanel = new TableScreen.TableScreen2();
                }

                #region Floor selected
                int floor = 0;
                if (btnFloor0.IsActive)
                {
                    floor = 0;
                }
                if (btnFloor1.IsActive)
                {
                    floor = 1;
                }
                else if (btnFloor2.IsActive)
                {
                    floor = 2;
                }
                else if (btnFloor3.IsActive)
                {
                    floor = 3;
                }
                else if (btnFloor4.IsActive)
                {
                    floor = 4;
                }
                else if (btnFloor5.IsActive)
                {
                    floor = 5;
                }
                #endregion

                //Nếu không saveTableStatus
                //  && không tách bàn / tách hóa đơn
                //  && trạng thái TableTypeEnum trùng với lần load tiếp theo
                //  && khu vực LastFloorSelected trùng với lần load tiếp theo
                // -> không cần load lại TableScreen (updateUI)
                if (PosConfig.EnableServeTypeDialog.Trim().ToLower() == "true")
                {
                    if (PosConfig.SaveTableStatus.Trim().ToLower() == "true"
                        || PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                        || _tablePanel.LastTableTypeSelected != TableTypeEnum.All
                        || _tablePanel.LastFloorSelected != floor)
                    {
                        _tablePanel.LoadTables(TableTypeEnum.All, TableOrderTypeEnum.All, floor);
                    }
                }
                else
                {
                    if (btnAtStoreMode.IsActive)
                    {
                        if (PosConfig.SaveTableStatus.Trim().ToLower() == "true"
                            || PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                            || _tablePanel.LastTableTypeSelected != TableTypeEnum.Rectangle
                            || _tablePanel.LastFloorSelected != floor)
                        {
                            _tablePanel.LoadTables(TableTypeEnum.Rectangle, TableOrderTypeEnum.All, floor);
                        }
                    }
                    else
                    {
                        if (PosConfig.TakeAwayDifferDelivery.Trim().ToLower() == "true")
                        {
                            if (btnTakeAwayMode.IsActive)
                            {
                                if (PosConfig.SaveTableStatus.Trim().ToLower() == "true"
                                || PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                                || _tablePanel.LastOrderTypeSelected != TableOrderTypeEnum.CircleTakeAway
                                || _tablePanel.LastFloorSelected != floor)
                                {
                                    _tablePanel.LoadTables(TableTypeEnum.Circle, TableOrderTypeEnum.CircleTakeAway, floor);
                                }
                            }
                            else if (btnDeliveryMode.IsActive)
                            {
                                if (PosConfig.SaveTableStatus.Trim().ToLower() == "true"
                                || PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                                || _tablePanel.LastOrderTypeSelected != TableOrderTypeEnum.CircleDelivery
                                || _tablePanel.LastFloorSelected != floor)
                                {
                                    _tablePanel.LoadTables(TableTypeEnum.Circle, TableOrderTypeEnum.CircleDelivery, floor);
                                }
                            }
                        }
                        else
                        {
                            if (PosConfig.SaveTableStatus.Trim().ToLower() == "true"
                                || PosConfig.EnableChangeTable.Trim().ToLower() == "true"
                                || _tablePanel.LastTableTypeSelected != TableTypeEnum.Circle
                                || _tablePanel.LastFloorSelected != floor)
                            {
                                _tablePanel.LoadTables(TableTypeEnum.Circle, TableOrderTypeEnum.All, floor);
                            }
                        }
                    }
                }


                LoadScreen(_tablePanel, true, true);
                //this.Invoke((MethodInvoker)delegate
                this.UpdateDashboardStatus(hasUpdate);
            }
            catch (Exception ex)
            {
                //log.Error("LoadTableScreen - " + ex);
                //_log.SendLogError(ex);
            }
        }

        public void LoadSaleScreen(OrderEditViewModel order, OrderTypeEnum type, TableViewModel table)
        {
            try
            {
                //Close other form
                bool isNewOrder = false;
                if (order == null)
                {
                    isNewOrder = true;
                    order = CreateOrderEditViewModel(type);
                    order.TableId = table.Id;
                }

                order.TableNumber = table.Number;

                if (_saleScreen == null)
                {
                    _saleScreen = new SaleScreen3();
                }
                _saleScreen.InitOrderBoard(order, table, isNewOrder);

                LoadScreen(_saleScreen, false, false);

                _saleScreen.UpdateStaffInfo(CurrentAccount.StaffName);
            }
            catch (Exception ex)
            {
                //log.Error("LoadSaleScreen - " + ex);
                //_log.SendLogError(ex);
            }

        }

        public void LoadDashboard()
        {
            DashboardScreen4 dashboard = new DashboardScreen4(hasUpdate);
            LoadScreen(dashboard, false, false);
        }

        public void LoadViewOrderScreen()
        {
            if (_reviewOrderScreen == null)
            {
                _reviewOrderScreen = new ReviewOrderScreen();
            }
            _reviewOrderScreen.LoadItems();
            LoadScreen(_reviewOrderScreen, false, false);
        }

        public void LoadOnlineOrderScreen()
        {
            OnlineOrdersScreen onlineOrdersScreen = new OnlineOrdersScreen();
            LoadScreen(onlineOrdersScreen, false, false);
        }

        public void LoadReportScreen()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordExportReport.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                ReportDateFilterDialog dialog = new ReportDateFilterDialog();
                dialog.ShowDialog();
            }
        }

        public void LoadKitchenScreen()
        {
            LoadTableScreen();
            if (MainForm.PosConfig.IsOnlyUseKitchen.Trim().ToLower() == "true")
            {
                //Mode kitchen không có auto data, cần dùng fastsyncdata update
                FastSyncData();
            }

            KitchenScreen kitchen = new KitchenScreen();
            LoadScreen(kitchen, false, false);
            kitchen.StartAutoReLoad();
        }

        private void LoadScreen(UserControl screen, bool showFramePanel, bool showDashboard)
        {
            if (screen == _tablePanel)
            {
                soundEnable = true;
            }
            else
            {
                StopNotiSound();
                soundEnable = false;
            }

            while (pnlMain.Controls.Count > 2)
            {
                var c = pnlMain.Controls[pnlMain.Controls.Count - 1];
                pnlMain.Controls.Remove(c);
            }

            if (showFramePanel)
            {
                pnlMain.Controls[0].BringToFront();
                pnlMain.Controls[1].BringToFront();
                pnlMain.Controls[0].Visible = true;
                pnlMain.Controls[1].Visible = true;
            }
            else
            {
                pnlMain.Controls[0].Visible = false;
                pnlMain.Controls[1].Visible = false;
            }

            if (showDashboard)
            {
                pnlDashboard.Visible = true;
                pnlDashboard.BringToFront();
            }
            else
            {
                pnlDashboard.Visible = false;
                pnlDashboard.SendToBack();
            }

            if (screen is LoginScreen1)
            {
                this.btnLogout.Visible = false;
                pnlBottom.BackgroudBootstrapColor = BootstrapColorEnum.MainColor;
                btnAtStoreMode.Hide();
                btnTakeAwayMode.Hide();
                btnDeliveryMode.Hide();
            }
            else
            {
                this.btnLogout.Visible = true;
                if (PosConfig.EnableServeTypeDialog.Trim().ToLower() == "false")
                {
                    //Màn hình chọn loại sẽ hiện ở giữa
                    btnAtStoreMode.Show();
                    btnTakeAwayMode.Show();
                    btnDeliveryMode.Show();
                }
                pnlBottom.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                if (CurrentAccount != null)
                {
                    this.btnLogout.TextValue = CurrentAccount.StaffName;
                }
            }

            screen.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(screen);
            screen.Focus();
            Activate();
        }

        #endregion


        private static SplashForm _splashForm;

        public void ShowSplashForm(string displayText)
        {
            if (_splashForm == null)
            {
                _splashForm = new SplashForm();
            }
            _splashForm.ChangeText(displayText);
            
            // Nếu là câu lệnh wait thì sẽ tạo gif loading
            var waitingText = MainForm.ResManager.GetString(
                            "ReportDateFilterDialog_Generate_Payment_Waiting",
                            MainForm.CultureInfo);
            
            if (displayText != waitingText)
            {
                _splashForm.TurnOffLoading();
            }

            _splashForm.Show();
            //_splashForm.DisableClick();
            //_splashForm.Enabled = false;
            _splashForm.TopMost = true;
        }

        public void HideSplashForm()
        {
            if (_splashForm != null)
            {
                _splashForm.Close();
                _splashForm.EnableMouse();
            }
            _splashForm = null;
        }


        #region Sync Data

        public void FastSyncData()
        {
            DataExchanger.GetNewAccount();
            DataExchanger.GetNewProductCategory();
            DataExchanger.GetNewProduct();
            DataExchanger.GetNewPromotion();
        }

        public async Task<bool> SyncData()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordUpdate.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                var result = UpdateAccount();
                if (result)
                {
                    result = UpdateCategory();
                }
                if (result)
                {
                    result = UpdateProduct();
                }
                if (result)
                {
                    result = UpdatePromotion();
                }

                if (result)
                {
                    //goi api xoa queue
                    result = await AfterUpdate((int)NotifyMessageType.NoThing);
                }
                //if (this.hasUpdate = true)
                //{
                this.hasUpdate = !result;
                //}
                return !result;
            }
            return false;
        }

        public async Task<bool> SyncAccount()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordUpdate.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                var result = UpdateAccount();
                if (result)
                {
                    //goi api xoa queue
                    result = await AfterUpdate((int)NotifyMessageType.AccountChange);
                }
                return result;
            }
            return false;
        }

        public async Task<bool> SyncProduct()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordUpdate.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                var result = UpdateProduct();
                if (result)
                {
                    //goi api xoa queue
                    result = await AfterUpdate((int)NotifyMessageType.ProductChange);
                }
                return result;
            }
            return false;
        }

        public async Task<bool> SyncCategory()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordUpdate.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                var result = UpdateCategory();
                if (result)
                {
                    //goi api xoa queue
                    result = await AfterUpdate((int)NotifyMessageType.CategoryChange);
                }
                return !result;
            }
            return false;
        }

        public async Task<bool> SyncPromotion()
        {
            var isRequiredPassword = PosConfig.RequiredPasswordUpdate.Trim().ToLower() == "true";
            var checkLogin = CheckRole(isRequiredPassword);

            if (checkLogin)
            {
                var result = UpdatePromotion();
                if (result)
                {
                    //goi api xoa queue
                    result = await AfterUpdate((int)NotifyMessageType.PromotionChange);
                }
                return !result;
            }
            return false;
        }

        private bool UpdateAccount()
        {
            //message:Tài khoản đang được cập nhật...
            Program.MainForm.ShowSplashForm(
                    ResManager.GetString("DashboardScreen4_Updating_Accounts",
                    CultureInfo));

            var result = DataExchanger.GetNewAccount();
            if (result)
            {
                Program.MainForm.HideSplashForm();
                return true;
            }
            else
            {
                Program.MainForm.HideSplashForm();
                //message: Tài khoản chưa được cập nhật. Xin thử lại sau!
                var msg = new MessageDialog(
                    ResManager.GetString("DashboardScreen4_Update_Fail_Accounts", CultureInfo),
                    ResManager.GetString("Sys_OK", CultureInfo));
                msg.ShowDialog();
                return false;
            }
        }

        private bool UpdateProduct()
        {
            //message:Sản phẩm đang được cập nhật...
            Program.MainForm.ShowSplashForm(
                    ResManager.GetString("DashboardScreen4_Updating_Products",
                    CultureInfo));

            var result = DataExchanger.GetNewProduct();
            if (result)
            {
                Program.MainForm.HideSplashForm();
                return true;
            }
            else
            {
                Program.MainForm.HideSplashForm();
                //message:Sản phẩm chưa được cập nhật. Xin thử lại sau!
                var msg = new MessageDialog(
                    ResManager.GetString("DashboardScreen4_Update_Fail_Products",
                        CultureInfo),
                    ResManager.GetString("Sys_OK", CultureInfo));
                msg.ShowDialog();
                return false;
            }
        }

        private bool UpdateCategory()
        {
            //message:Danh mục đang được cập nhật...

            Program.MainForm.ShowSplashForm(
                    ResManager.GetString("DashboardScreen4_Updating_Categories",
                    CultureInfo));

            var result = DataExchanger.GetNewProductCategory();
            if (result)
            {
                Program.MainForm.HideSplashForm();
                return true;
            }
            else
            {
                Program.MainForm.HideSplashForm();
                //message: Danh mục sản phẩm chưa được cập nhật. Xin thử lại sau!
                var msg = new MessageDialog(
                        ResManager.GetString("DashboardScreen4_Update_Fail_Categories", CultureInfo),
                        ResManager.GetString("Sys_OK", CultureInfo));
                msg.ShowDialog();
                return false;
            }
        }

        private bool UpdatePromotion()
        {
            //message:Khuyến mãi đang được cập nhật…
            Program.MainForm.ShowSplashForm(
                    ResManager.GetString("DashboardScreen4_Promotion_Is_Being_Updated_Message",
                    CultureInfo));

            var result = DataExchanger.GetNewPromotion();
            if (result)
            {
                Program.MainForm.HideSplashForm();
                //AfterUpdate();
                return true;
            }
            else
            {
                //throw ex;
                Program.MainForm.HideSplashForm();
                //message:Khuyến mãi chưa được cập nhật. Xin thử lại sau
                var msg = new MessageDialog(ResManager.GetString("DashboardScreen4_Promotion_Is_Not_Updated_Please_Message", CultureInfo),
                    ResManager.GetString("Sys_OK", CultureInfo));
                msg.ShowDialog();
                return false;
            }
        }

        public static bool CheckRole(bool isRequiredPassword)
        {
            if (isRequiredPassword)
            {
                var isEnableOnscreenKeyboard = PosConfig.EnableOnscreenKeyboard == "true";

                var rs = PosMessageDialog.ConfirmMessageWith2Input(
                    //message:Vui lòng đăng nhập tài khoản quản lý
                    ResManager.GetString("Sys_Manager_Account", CultureInfo),
                    ResManager.GetString("Sys_Manager_Username", CultureInfo),
                    ResManager.GetString("Sys_Manager_Password", CultureInfo),
                    ResManager.GetString("Sys_OK", CultureInfo),
                    ResManager.GetString("Sys_Cancel", CultureInfo),
                    isEnableOnscreenKeyboard);

                if (rs == null)
                {
                    //Close ConfirmMessageWithInput
                    return false;
                }
                else
                {
                    var accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
                    var account = accountService.CheckLogin(rs[0], rs[1]);
                    if (account == null)
                    {
                        //message:Mật khẩu sai!!!
                        PosMessageDialog.ShowMessage(
                            ResManager.GetString("Sys_Wrong_Password", CultureInfo));
                        return false;
                    }
                    else
                    {
                        if (account.Role == "StoreManager")
                        {
                            return true;
                        }
                        else
                        {
                            //message:Tài khoản không phù hợp!!!
                            PosMessageDialog.ShowMessage(
                                ResManager.GetString("Sys_Manager_Required", CultureInfo));
                            return false;
                        }
                    }
                }
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> AfterUpdate(int type)
        {
            //Load lại Product, Category, Promotion
            Program.context.LoadProductsAndCategories();
            Program.context.LoadPromotions();

            return await DataExchanger.DataUpdated(type);
        }

        #endregion

        public static OrderEditViewModel CreateOrderEditViewModel(OrderTypeEnum type)
        {
            //"InvoideCodepattern": "TEST-{StoreId}-{Type}-{Code}",
            string typeCode = "";
            switch (type)
            {
                case OrderTypeEnum.AtStore:
                    typeCode = "AS";
                    break;
                case OrderTypeEnum.Delivery:
                    typeCode = "DL";
                    break;
                case OrderTypeEnum.DropProduct:
                    break;
                case OrderTypeEnum.OnlineProduct:
                    typeCode = "OP";
                    break;
                case OrderTypeEnum.TakeAway:
                    typeCode = "TA";
                    break;
                case OrderTypeEnum.OrderCard:
                    typeCode = "OC";
                    break;
                default:
                    break;
            }

            string code = PosConfig.InvoideCodepattern.Replace("{StoreId}", (string)StoreInfo.StoreId)
                    .Replace("{StoreName}", (string)StoreInfo.TerminalName)
                    .Replace("{Type}", typeCode)
                    .Replace("{Code}", InvoiceCodeGenerator.GenerateInvoiceCode());
            var order = new OrderEditViewModel()
            {
                OrderCode = code,
                CheckInDate = UtcDateTime.Now(),
                CheckInPerson = CurrentAccount.AccountId,
                ServedPerson = CurrentAccount.AccountId,
                OrderStatus = (int)OrderStatusEnum.New,
                OrderType = (int)type,
            };
            return order;
        }


        public OrderTypeEnum GetCurrentOrderType()
        {
            if (btnAtStoreMode.IsActive)
            {
                return OrderTypeEnum.AtStore;
            }
            else if (btnDeliveryMode.IsActive)
            {
                return OrderTypeEnum.Delivery;
            }
            else if (btnTakeAwayMode.IsActive)
            {
                return OrderTypeEnum.TakeAway;
            }
            else
            {
                return OrderTypeEnum.DropProduct;
            }
        }

        public void UpdateTableScreen(int id)
        {
            _tablePanel.UpdateTables(id);
            LoadFirstScreen();
            //LoadScreen(_tablePanel, true, true);
        }

        public void HideMainForm()
        {
            //TODO: When click Hide POS. Application disappear in taskbar (still running in backgroud)
            Program.MainForm.Visible = true;
            Program.MainForm.Opacity = 100;
            Program.MainForm.WindowState = FormWindowState.Minimized;
            Program.MainForm.ShowInTaskbar = true;
        }

        public void MainFormClosed()
        {
            Application.Exit(); //This will call event MainFormClosed
            Environment.Exit(0);
        }

        private void MainFormClosed(object sender, FormClosedEventArgs e)
        {
            _stopExchanger = true; //stop exchanger
            _isGetDataRunning = false; //stop exchanger

            Environment.Exit(0);
        }

        public void Logout()
        {
            CurrentAccount = null;
            this.LoadLoginScreen();
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Logout();
        }

        private void btnHideApplication_Click(object sender, EventArgs e)
        {
            this.HideMainForm();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnAtStoreMode_Click(object sender, EventArgs e)
        {
            btnAtStoreMode.IsActive = true;
            LoadTableScreen();
        }

        private void btnTakeAwayMode_Click(object sender, EventArgs e)
        {
            btnTakeAwayMode.IsActive = true;
            LoadTableScreen();
        }

        private void btnDeliveryMode_Click(object sender, EventArgs e)
        {
            btnDeliveryMode.IsActive = true;
            LoadTableScreen();
        }

        private void btnFloor_Click(object sender, EventArgs e)
        {
            var button = (BootstrapButton)sender;
            button.IsActive = true;
            LoadTableScreen();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            this.LoadViewOrderScreen();
        }

        private void btnOnlineOrder_Click(object sender, EventArgs e)
        {
            this.LoadOnlineOrderScreen();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }


        #region Sound
        private static WindowsMediaPlayer windowsMediaPlayer;
        private bool soundEnable;

        //Noti Sound for OrderEditViewModel online
        public void CreateNotiSound()
        {
            if (PosConfig.EnableSound.Trim().ToLower() == "true")
            {
                try
                {
                    string soundName = PosConfig.NotiSoundName;
                    string path = Path.Combine(Environment.CurrentDirectory, @"Resources\", soundName);

                    windowsMediaPlayer = new WMPLib.WindowsMediaPlayer();
                    windowsMediaPlayer.URL = path;

                    StopNotiSound();
                    soundEnable = true;
                }
                catch (Exception ex)
                {
                    //log.Error("CreateNotiSound - " + ex);
                    //_log.SendLogError(ex);
                }
            }
        }

        public void PlayNotiSound()
        {
            if (PosConfig.EnableSound.Trim().ToLower() == "true")
            {
                try
                {
                    if (soundEnable)
                    {
                        StopNotiSound();
                        windowsMediaPlayer.controls.play(); //play noti sound
                                                            // soundEnable = false;
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("PlayNotiSound - " + ex);
                    //_log.SendLogError(ex);
                }
            }
        }

        public void StopNotiSound()
        {
            if (PosConfig.EnableSound.Trim().ToLower() == "true")
            {
                try
                {
                    windowsMediaPlayer.controls.stop(); //stop noti sound
                }
                catch (Exception ex)
                {
                    //log.Error("StopNotiSound - " + ex);
                    //_log.SendLogError(ex);
                }
            }
        }
        #endregion

    }
}

