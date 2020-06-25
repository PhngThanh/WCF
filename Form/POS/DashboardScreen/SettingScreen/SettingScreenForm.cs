using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using log4net;
using Newtonsoft.Json;

namespace POS.DashboardScreen.SettingScreen
{
    public partial class SettingScreenForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static StoreInfo _storeInfo { get; set; }
        public static PosConfig _posConfig { get; set; }

        public static string screenKeyboard = "true";
        public static string generateWifi = "true";
        public static string generateQR = "true";

        private int posTab = 0;
        private List<BootstrapPanel> listPanels = new List<BootstrapPanel>();
        

        public SettingScreenForm(StoreInfo storeInfo, PosConfig posConfig)
        {
            InitializeComponent();
            
            _storeInfo = storeInfo;
            _posConfig = posConfig;
            
            setColorWithHexCode(_storeInfo.MainColor);
            addItemComboBox();

            OnScreenKeyboardDialog.Instance.AddTextbox(txtStoreName);
            OnScreenKeyboardDialog.Instance.AddTextbox(txtAddressStore);
            OnScreenKeyboardDialog.Instance.AddTextbox(txtStoreTel);
            OnScreenKeyboardDialog.Instance.AddTextbox(txtWifiName);
            OnScreenKeyboardDialog.Instance.AddTextbox(txtTextEndingOnBill);

            tabControl.Visible = false;

            this.BackColor = ColorTranslator.FromHtml(_storeInfo.MainColor);

            btpInfo1.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpInfo2.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpMainHeader.BackgroudBootstrapColor = BootstrapColorEnum.MainColor;
            btpPrinter1.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpPrinter2.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpDisplay1.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpDisplay2.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpVATInvoice1.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            btpVATInvoice2.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;      
            btTitle.BackgroudBootstrapColor = BootstrapColorEnum.MainColor;
            btpMainFooter.BackgroudBootstrapColor = BootstrapColorEnum.MainColor;
            btnCancel.BackgroudBootstrapColor = BootstrapColorEnum.Danger;
            btpMain.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;

            btnInfoTab.IsActive = true;

            LoadScreen();

            if (_posConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                btnOnOffScreenKeyboard.ImageCss = "toggle-on";
                btnOnOffScreenKeyboard.TextValue = "ON";
                screenKeyboard = "true";
            }
            else
            {
                btnOnOffScreenKeyboard.ImageCss = "toggle-off";
                btnOnOffScreenKeyboard.TextValue = "OFF";
                screenKeyboard = "false";
            }

            if (_storeInfo.IsGeneratePassWifi.Trim().ToLower() == "true")
            {
                btnOnOffWifi.ImageCss = "toggle-on";
                btnOnOffWifi.TextValue = "ON";
                generateWifi = "true";
                txtWifiPassword.ReadOnly = true;
                txtWifiPassword.Enabled = false;
            }
            else
            {
                btnOnOffWifi.ImageCss = "toggle-off";
                btnOnOffWifi.TextValue = "OFF";
                generateWifi = "false";
                txtWifiPassword.ReadOnly = false;
                txtWifiPassword.Enabled = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtWifiPassword);
            }

            if (_storeInfo.QRCodeEnable.Trim().ToLower() == "true")
            {
                btnOnOffQR.ImageCss = "toggle-on";
                btnOnOffQR.TextValue = "ON";
                generateQR = "true";
                txtQRLink.ReadOnly = false;
                txtQRLink.Enabled = true;
                txtQRDescription.ReadOnly = false;
                txtQRDescription.Enabled = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtQRLink);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtQRDescription);
            }
            else
            {
                btnOnOffQR.ImageCss = "toggle-off";
                btnOnOffQR.TextValue = "OFF";
                generateQR = "false";
                txtQRLink.ReadOnly = true;
                txtQRLink.Enabled = false;
                txtQRDescription.ReadOnly = true;
                txtQRDescription.Enabled = false;
            }

            this.btnInfoTab.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Information", MainForm.CultureInfo);
            this.btnPrinterTab.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Print", MainForm.CultureInfo);
            this.btnDisplayTab.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Interface", MainForm.CultureInfo);
            this.btnCancel.TextValue = MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo);
            this.btnFinish.TextValue = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);


            //info tab
            //message: Thông tin cửa hàng được hiển thị trên phần mềm
            this.lblMessageInfoTab.TextValue = MainForm.ResManager.GetString("SettingScreenForm_InfoTab_Message", MainForm.CultureInfo);
            this.lblStoreName.TextValue = MainForm.ResManager.GetString("SettingScreenForm_InfoTab_Store_Name", MainForm.CultureInfo)+":";
            this.lblAddressStore.TextValue = MainForm.ResManager.GetString("Sys_Store_Addresss", MainForm.CultureInfo)+":";
            this.lblHotline.TextValue = MainForm.ResManager.GetString("Sys_Store_Hotline", MainForm.CultureInfo) + ":";

            //Print and wifi
            this.lblPrinterBill.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_Guest_Printer", MainForm.CultureInfo) + ":";
            this.lblWifiMode.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_AutoWifi", MainForm.CultureInfo) ;
            this.btnOnOffWifi.TextValue = MainForm.ResManager.GetString("Sys_On", MainForm.CultureInfo);
            this.lblPrinterCook1.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_Kitchen_Printer", MainForm.CultureInfo)+":";
            this.lblWifiName.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_Wifi_Name", MainForm.CultureInfo);
            this.lblEndingOnBill.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_Wifi_Sign", MainForm.CultureInfo)+":";
            this.lblWifiPassword.TextValue = MainForm.ResManager.GetString("SettingScreenForm_PrintWifiTab_Wifi_Pass", MainForm.CultureInfo);

            //Interface
            this.lblMainColor.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Interface_Color", MainForm.CultureInfo) + ":";
            this.lblScreenResolution.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Interface_Resolution", MainForm.CultureInfo) + ":";
            this.lblScreenKeyboard.TextValue = MainForm.ResManager.GetString("SettingScreenForm_Interface_ScreenKeyboard", MainForm.CultureInfo) + ":";
            this.btnOnOffScreenKeyboard.TextValue = MainForm.ResManager.GetString("Sys_On", MainForm.CultureInfo) + ":";

            //VAT Invoice
            //Message: Thông tin được hiện thị trên hóa đơn.
            this.lblMessageInvoiceTab.TextValue = MainForm.ResManager.GetString("SettingScreenForm_VAT_Message", MainForm.CultureInfo) ;
            this.lblInvoiceCompanyNameVi.TextValue= MainForm.ResManager.GetString("SettingScreenForm_VAT_VnCom_Name", MainForm.CultureInfo);
            this.lblInvoiceCompanyNameEn.TextValue= MainForm.ResManager.GetString("SettingScreenForm_VAT_EnCom_Name", MainForm.CultureInfo);
            this.lblInvoiceCompanyAddress.TextValue = MainForm.ResManager.GetString("Sys_Store_Addresss", MainForm.CultureInfo) + ":";
            this.lblInvoiceCompanyTel.TextValue = MainForm.ResManager.GetString("Sys_Store_Hotline", MainForm.CultureInfo) + ":";
        }

        public void addItemComboBox()
        {
            cbbPrinterBill.Items.Add(_storeInfo.PrinterCook1);
            cbbPrinterBill.Items.Add(_storeInfo.PrinterCook2);
            cbbPrinterBill.Items.Add(_storeInfo.PrinterCook3);

            cbbPrinterCook.Items.Add(_storeInfo.PrinterCook1);
            cbbPrinterCook.Items.Add(_storeInfo.PrinterCook2);
            cbbPrinterCook.Items.Add(_storeInfo.PrinterCook3);
        }

        private void setColorWithHexCode(string hexCode)
        {
            txtCorlorChoose.Text = hexCode;
            txtCorlorChoose.ForeColor = System.Drawing.ColorTranslator.FromHtml(hexCode);
        }

        private void LoadScreen()
        {
            btpMain.Controls.Clear();

            txtStoreName.Text = !string.IsNullOrEmpty(_storeInfo.TerminalName) ? _storeInfo.TerminalName : "";
            txtAddressStore.Text = !string.IsNullOrEmpty(_storeInfo.TerminalAddress) ? _storeInfo.TerminalAddress : "";
            txtStoreTel.Text = !string.IsNullOrEmpty(_storeInfo.HotLine) ? _storeInfo.HotLine : "";
            txtTextEndingOnBill.Text = !string.IsNullOrEmpty(_storeInfo.EndingTextOnBill) ? _storeInfo.EndingTextOnBill : "";
            txtWifiName.Text = !string.IsNullOrEmpty(_storeInfo.WifiName) ? _storeInfo.WifiName : "";
            txtWifiPassword.Text = !string.IsNullOrEmpty(_storeInfo.WifiPassword) ? _storeInfo.WifiPassword : "";
            txtQRLink.Text = !string.IsNullOrEmpty(_storeInfo.QRCodeURL) ? _storeInfo.QRCodeURL : "";
            txtQRDescription.Text = !string.IsNullOrEmpty(_storeInfo.QRCodeDescription) ? _storeInfo.QRCodeDescription : "";
            txtResolution.Text = !string.IsNullOrEmpty(_storeInfo.ComputerScreenResolution) ? _storeInfo.ComputerScreenResolution : "";
            txtResolution.ReadOnly = true;
            cbbPrinterBill.Text = !string.IsNullOrEmpty(_storeInfo.PrinterBill) ? _storeInfo.PrinterBill : "";
            cbbPrinterCook.Text = !string.IsNullOrEmpty(_storeInfo.PrinterCook1) ? _storeInfo.PrinterCook1 : "";
            
            if (posTab == 0)
            {
                btpMain.Controls.Add(btpInfo1);
                btpMain.Controls.Add(btpInfo2);
            } else if (posTab == 1)
            {
                btpMain.Controls.Add(btpPrinter1);
                btpMain.Controls.Add(btpPrinter2);
            } else if (posTab == 2)
            {
                btpMain.Controls.Add(btpDisplay1);
                btpMain.Controls.Add(btpDisplay2);
            }else if (posTab == 3)
            {
                btpMain.Controls.Add(btpVATInvoice1);
                btpMain.Controls.Add(btpVATInvoice2);
            }
        }

        private void SaveSetting()
        {
            _storeInfo.TerminalName = txtStoreName.Text;
            _storeInfo.TerminalAddress = txtAddressStore.Text;
            _storeInfo.HotLine = txtStoreTel.Text;

            _storeInfo.MainColor = txtCorlorChoose.Text;

            _storeInfo.IsGeneratePassWifi = generateWifi;
            _storeInfo.WifiName = txtWifiName.Text;
            _storeInfo.WifiPassword = txtWifiPassword.Text;

            _storeInfo.QRCodeEnable = generateQR;
            _storeInfo.QRCodeURL = txtQRLink.Text;
            _storeInfo.QRCodeDescription = txtQRDescription.Text;

            _storeInfo.EndingTextOnBill = txtTextEndingOnBill.Text;
            _storeInfo.PrinterBill = cbbPrinterBill.Text;
            _storeInfo.PrinterCook1 = cbbPrinterCook.Text;

            _posConfig.EnableOnscreenKeyboard = screenKeyboard;

            try
            {
                string jsonStoreInfo = JsonConvert.SerializeObject(_storeInfo, Formatting.Indented);
                string jsonPosConfig = JsonConvert.SerializeObject(_posConfig, Formatting.Indented);
                
                //save
                var currentDir = Environment.CurrentDirectory;
                var pathStoreInfo = currentDir + @"\Configuration\storeInfo.json";
                var pathPosConfig = currentDir + @"\Configuration\posConfig.json";

                System.IO.File.WriteAllText(pathStoreInfo, jsonStoreInfo);
                System.IO.File.WriteAllText(pathPosConfig, jsonPosConfig);
            }
            catch (Exception ex)
            {
                log.Error("SaveSetting - " + ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOnOffWifi_Click(object sender, EventArgs e)
        {
            if (btnOnOffWifi.ImageCss.ToString().Trim().Equals("toggle-on"))
            {
                btnOnOffWifi.ImageCss = "toggle-off";
                btnOnOffWifi.TextValue = "OFF";
                generateWifi = "false";
                txtWifiPassword.ReadOnly = false;
                txtWifiPassword.Enabled = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtWifiPassword);
            }
            else
            {
                btnOnOffWifi.ImageCss = "toggle-on";
                btnOnOffWifi.TextValue = "ON";
                generateWifi = "true";
                txtWifiPassword.ReadOnly = true;
                txtWifiPassword.Enabled = false;
            }
        }

        private void btnOnOffQR_Click(object sender, EventArgs e)
        {
            if (btnOnOffQR.ImageCss.ToString().Trim().Equals("toggle-on"))
            {
                btnOnOffQR.ImageCss = "toggle-off";
                btnOnOffQR.TextValue = "OFF";
                generateQR = "false";
                txtQRLink.ReadOnly = true;
                txtQRLink.Enabled = false;
                txtQRDescription.ReadOnly = true;
                txtQRDescription.Enabled = false;
            }
            else
            {
                btnOnOffQR.ImageCss = "toggle-on";
                btnOnOffQR.TextValue = "ON";
                generateQR = "true";
                txtQRLink.ReadOnly = false;
                txtQRLink.Enabled = true;
                txtQRDescription.ReadOnly = false;
                txtQRDescription.Enabled = true;
                OnScreenKeyboardDialog.Instance.AddTextbox(txtQRLink);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtQRDescription);
            }
        }

        private void txtCorlorChoose_Click(object sender, EventArgs e)
        {
            DialogResult result = ColorChoose.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                string hexColor = ColorChoose.Color.R.ToString("X2") + ColorChoose.Color.G.ToString("X2") + ColorChoose.Color.B.ToString("X2");

                if (!hexColor.StartsWith("#"))
                {
                    hexColor = "#" + hexColor;
                }
                setColorWithHexCode(hexColor);
            }

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            var rs = PosMessageDialog.ConfirmMessage("Bạn có muốn lưu thay đổi? (Thay đổi sẽ được thiết lập sau khi khởi động lại.)");
            if (rs)
            {
                SaveSetting();
            }
            this.Close();
            Program.MainForm.LoadDashboard();
        }

        private void btnOnOffScreenKeyboard_Click(object sender, EventArgs e)
        {         
            if (btnOnOffScreenKeyboard.ImageCss.ToString().Trim().Equals("toggle-on"))
            {
                btnOnOffScreenKeyboard.ImageCss = "toggle-off";
                btnOnOffScreenKeyboard.TextValue = "OFF";
                screenKeyboard = "false";
            }
            else
            {
                btnOnOffScreenKeyboard.ImageCss = "toggle-on";
                btnOnOffScreenKeyboard.TextValue = "ON";
                screenKeyboard = "true";
            }
        }

        private void btnInfoTab_Click(object sender, EventArgs e)
        {
            posTab = 0;
            this.LoadScreen();
        }

        private void btnPrinterAndWifiTab_Click(object sender, EventArgs e)
        {
            posTab = 1;
            this.LoadScreen();
        }

        private void btnDisplayTab_Click(object sender, EventArgs e)
        {
            posTab = 2;
            this.LoadScreen();
        }

        private void btnVATInvoiceTab_Click(object sender, EventArgs e)
        {
            posTab = 3;
            this.LoadScreen();
        }

        
    }
}
