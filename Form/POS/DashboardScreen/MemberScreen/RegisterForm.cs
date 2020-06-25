using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using POS.CustomControl;
using POS.Common;
using POS.ExchangeData;
using POS.Repository;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using POS.Utils;
using System.Text.RegularExpressions;
using System.Drawing;
using POS.SaleScreen;

namespace POS.DashboardScreen.MemberScreen
{
    public partial class RegisterForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static StoreInfo _storeInfo { get; set; }
        public static PosConfig _posConfig { get; set; }

        //public static List<MembershipCardSampleModel> memberShipCard;
        public static List<CustomerTypeEditViewModel> customerType;
        public static List<MembershipCardSampleModel> cardSampleList;
        int customerId = 0;

        //check card :
        //-Card must be filled in
        //-Card must be valid
        bool isValidCard = false;
        public Nullable<System.DateTime> tmpDate;
        public RegisterForm(StoreInfo storeInfo, PosConfig posConfig)
        {
            InitializeComponent();
            _storeInfo = storeInfo;
            _posConfig = posConfig;

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCardCode);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtAddress);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCity);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCustomerName);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtDistrict);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtEmail);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtPhone);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCMND);
                OnScreenKeyboardDialog.Instance.AddTextbox(phone);
            }

            this.txtCardCode.KeyPress += CardCode_KeyPress;
            ddlCardType.Text = "";
            ddlCardType.Enabled = false;
            //    notShowOnlyReadIcon();
            for (int i = 1; i <= 31; i++) ddlDay.Items.Add(i);
            for (int i = 1; i <= 12; i++) ddlMonth.Items.Add(i);
            for (int i = int.Parse(UtcDateTime.Now().Year.ToString()); i >= 1890; i--) ddlYear.Items.Add(i);
            GenerateLayout();
        }


        private string tmpTextInput = "";
        private bool isBarcode = false;

        private DateTime lastKeyDownTime;
        private int _barcodeRegTime = 100;
        private int _barcodeDurTime = 200;

        private void CardCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            DateTime currentKeyDown = UtcDateTime.Now();
            //Debug.WriteLine((currentKeyDown - lastKeyDownTime).TotalMilliseconds);

            if (isBarcode)
            {
                //Đang ở chế độ scan barcode | input nhanh
                if ((currentKeyDown - lastKeyDownTime).TotalMilliseconds < _barcodeDurTime)
                {
                    //Key != enter (vẫn đang scan | input)
                    if (e.KeyChar != 13)
                    {
                        tmpTextInput += e.KeyChar;
                    }
                    //Key == enter (scan hoàn tất)
                    else
                    {
                        //TO TEST:
                        //tmpTextInput = "0010231234";

                        GenerateLayout();
                        txtCardCode.Text = tmpTextInput;

                        //  GetCardInfo(tmpTextInput);
                        CheckCustomerCardCode(tmpTextInput);

                        isBarcode = false;
                        this.Invalidate();
                        tmpTextInput = "";
                    }
                }
                else
                {
                    isBarcode = false;
                    tmpTextInput = e.KeyChar.ToString(); //Chi luu ky tu hien tai
                }
            }
            else
            {
                //isBarcode false
                if ((currentKeyDown - lastKeyDownTime).TotalMilliseconds < _barcodeRegTime)
                {
                    //txtOrderNotes.ReadOnly = false;
                    isBarcode = true;
                    tmpTextInput += e.KeyChar.ToString(); //Ky tu truoc do thuoc ve day barcode

                    //SaleScreen3.CurrentOrderManager().getOrderEditViewModel().BarCode = string.Empty;
                }
                else
                {
                    isBarcode = false;
                    tmpTextInput = e.KeyChar.ToString(); //Chi luu ky tu hien tai
                }
            }

            lastKeyDownTime = currentKeyDown;
        }
        //validate input
        public bool ValidateInput()
        {
            bool berror = false;
            //Customer can not be empty 
            if (txtCustomerName.Text.Count() == 0)
            {
                errorCustomerName.SetError(txtCustomerName, "Tên khách hàng không được bỏ trống");
                berror = true;
            }
            else errorCustomerName.Clear();
            //Phone can not be empty + length from 10 to 12 only number 
            if (txtPhone.Text.Count() == 0)
            {
                errorTxtPhone.SetError(txtPhone, "Số điện thoại không được bỏ trống");
                berror = true;
            }
            else if (!Regex.IsMatch(txtPhone.Text, @"[0-9]{10,12}"))
            {
                errorTxtPhone.SetError(txtPhone, "Số điện thoại không hợp lệ");
                berror = true;
            }
            else errorTxtPhone.Clear();
            //Email             
            if (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") && txtEmail.Text.Trim().Count() > 0)
            {
                errorEmail.SetError(txtEmail, "Địa chỉ email không hợp lệ");
                berror = true;
            }
            else errorEmail.Clear();

            if (Regex.IsMatch(ddlDay.Text, @"^[0-9]") || Regex.IsMatch(ddlMonth.Text, @"^[0-9]") || Regex.IsMatch(ddlYear.Text, @"^[0-9]"))
            {
                try
                {
                    String txtDate = ddlMonth.Text + "/" + ddlDay.Text + "/" + ddlYear.Text;
                    tmpDate = Convert.ToDateTime(txtDate);
                    errorDateTime.Clear();
                }
                catch (Exception)
                {
                    errorDateTime.SetError(ddlYear, "Ngày sinh không hợp lệ");
                    tmpDate = null;
                }
            }
            else errorDateTime.Clear();

            if (!Regex.IsMatch(txtCMND.Text, @"[0-9]{9}") && txtCMND.TextLength > 0)
            {
                errorIDCard.SetError(txtCMND, "Số CMND không hợp lệ");
                berror = true;
            }
            else errorIDCard.Clear();
            return !berror;
        }
        public void UnLockAllFields()
        {
            //make text not readonly
            txtCustomerName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtDistrict.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtCMND.ReadOnly = false;
            rdbMale.Enabled = true;
            rdbFemale.Enabled = true;
            ddlDay.Enabled = true;
            ddlMonth.Enabled = true;
            ddlYear.Enabled = true;

            //ddlCardType.Enabled = true;
            ddlType.Enabled = true;

            //change background color to normal
            txtCustomerName.BackColor = Color.FromArgb(70, 66, 67);
            txtAddress.BackColor = Color.FromArgb(70, 66, 67);
            txtPhone.BackColor = Color.FromArgb(70, 66, 67);
            txtEmail.BackColor = Color.FromArgb(70, 66, 67);
            txtDistrict.BackColor = Color.FromArgb(70, 66, 67);
            txtCity.BackColor = Color.FromArgb(70, 66, 67);
            txtCMND.BackColor = Color.FromArgb(70, 66, 67);

            //change fore color to normal
            txtCustomerName.ForeColor = SystemColors.Info;
            txtAddress.ForeColor = SystemColors.Info;
            txtPhone.ForeColor = SystemColors.Info;
            txtEmail.ForeColor = SystemColors.Info;
            txtDistrict.ForeColor = SystemColors.Info;
            txtCity.ForeColor = SystemColors.Info;
            txtCMND.ForeColor = SystemColors.Info;

            //set cursor to default
            txtCustomerName.Cursor = Cursors.Default;
            txtAddress.Cursor = Cursors.Default;
            txtPhone.Cursor = Cursors.Default;
            txtEmail.Cursor = Cursors.Default;
            txtDistrict.Cursor = Cursors.Default;
            txtCity.Cursor = Cursors.Default;
            txtCMND.Cursor = Cursors.Default;
            rdbMale.Cursor = Cursors.Default;
            rdbFemale.Cursor = Cursors.Default;
            ddlDay.Cursor = Cursors.Default;
            ddlMonth.Cursor = Cursors.Default;
            ddlYear.Cursor = Cursors.Default;
            //btnFinish.Cursor = Cursors.Default;
            //  ddlCardType.Enabled = false;
            ddlType.Cursor = Cursors.Default;

            GetCustomerType();
        }
        private void LockAllFields()
        {
            txtCustomerName.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtDistrict.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtCMND.ReadOnly = true;

            txtCustomerName.BackColor = Color.DimGray;
            txtAddress.BackColor = Color.DimGray;
            txtPhone.BackColor = Color.DimGray;
            txtEmail.BackColor = Color.DimGray;
            txtDistrict.BackColor = Color.DimGray;
            txtCity.BackColor = Color.DimGray;
            txtCMND.BackColor = Color.DimGray;

            txtCustomerName.ForeColor = Color.WhiteSmoke;
            txtAddress.ForeColor = Color.WhiteSmoke;
            txtPhone.ForeColor = Color.WhiteSmoke;
            txtEmail.ForeColor = Color.WhiteSmoke;
            txtDistrict.ForeColor = Color.WhiteSmoke;
            txtCity.ForeColor = Color.WhiteSmoke;
            txtCMND.ForeColor = Color.WhiteSmoke;


            txtCustomerName.Cursor = Cursors.No;
            txtAddress.Cursor = Cursors.No;
            txtPhone.Cursor = Cursors.No;
            txtEmail.Cursor = Cursors.No;
            txtDistrict.Cursor = Cursors.No;
            txtCity.Cursor = Cursors.No;
            txtCMND.Cursor = Cursors.No;
            rdbMale.Cursor = Cursors.No;
            rdbFemale.Cursor = Cursors.No;
            ddlDay.Cursor = Cursors.No;
            ddlMonth.Cursor = Cursors.No;
            ddlYear.Cursor = Cursors.No;
            //  btnFinish.Cursor = Cursors.No;
            //  ddlCardType.Enabled = false;
            ddlType.Cursor = Cursors.No;
            //  ddlCardType.Text = "";
            //  ddlType.Text = "";

            rdbMale.Enabled = false;
            rdbFemale.Enabled = false;
            ddlDay.Enabled = false;
            ddlMonth.Enabled = false;
            ddlYear.Enabled = false;
            btnFinish.Enabled = false;
            //  ddlCardType.Enabled = false;
            ddlType.Enabled = false;
            //  ddlCardType.Text = "";
            //  ddlType.Text = "";
        }

        //Call API - Check valid cardcode (if card empty you can use it ) 
        async void CheckCustomerCardCode(string cardcode)
        {
            try
            {
                Program.MainForm.ShowSplashForm(
                MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
                MainForm.CultureInfo));
                var result = await DataExchanger.CheckCardAvailable(cardcode);
                if (result.Success == true)
                {
                    isValidCard = true;
                    Program.MainForm.HideSplashForm();
                    txtCardStatus.Text = result.Message;
                    GetCardType();
                    ddlCardType.Enabled = true;
                }
                else
                {
                    isValidCard = false;
                    Program.MainForm.HideSplashForm();
                    txtCardStatus.Text = result.Message;
                    ddlCardType.Text = "";
                    ddlCardType.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("CheckCustomerCardCode (" + cardcode + ") - " + ex);
            }
        }

        //call API -send CustomerInfo to server
        async Task<ResultModel> CreateCustomer()
        {
            int typeId = 0;
            if (customerType != null && customerType.Count > 0)
            {
                foreach (var item in customerType)
                {
                    if (item.CustomerType.Equals(ddlType.Text)) typeId = item.ID;
                }
            }
            var Customer = new CustomerEditViewModel()
            {
                CustomerName = txtCustomerName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text.Trim().Count() == 0 ? null : txtEmail.Text.Trim(),
                IDCard = txtCMND.Text,
                BirthDay = tmpDate,
                District = txtDistrict.Text,
                City = txtCity.Text,
                Gender = (rdbMale.Checked) ? "Male" : "Female",
                Type = typeId,
                MembershipCardCode = txtCardCode.Text,
                CreatedTime = UtcDateTime.Now(),
            };
            ResultModel result = await DataExchanger.SendCustomerInfo(Customer);

            return result;
        }

        //call API- Send customer info with card info from field to server 
        async Task<ResultModel> CreateMembershipCard()
        {
            var cardSample = (MembershipCardSampleModel)ddlCardType.SelectedItem;
            var Customer = new MembershipCustomerModel()
            {
                CustomerID = customerId,
                CustomerName = txtCustomerName.Text,
                MembershipCardCode = txtCardCode.Text,
                CreatedTime = UtcDateTime.Now(),
                StoreId = _storeInfo.StoreId,
                SampleShipCardCode = ddlCardType.Text,
                ProductCode = cardSample.ProductCode
            };
            ResultModel result = await DataExchanger.CreateMembershipCard(Customer);
            return result;
        }
        protected override void OnShown(EventArgs e)
        {
            this.txtCardCode.Focus();
            base.OnShown(e);
        }
        private void GenerateLayout()
        {

            //  GetCardType();
            GetCustomerType();
            btnCreateCustomer.Hide();
            btnRefreshInfo.Hide();
            ResetAllText();

            txtCardStatus.Text = "";
            txtCardType.Text = "";
            txtDefaultBalance.Text = "";

            txtCardCode.Focus();
            LockAllFields();

            lblTitle.TextValue = MainForm.ResManager.GetString("MemberForm_Title", MainForm.CultureInfo);
            bsBtnMembershipCard.TextValue = MainForm.ResManager.GetString("Sys_MemberCardId", MainForm.CultureInfo);
            bootstrapButton3.TextValue = MainForm.ResManager.GetString("MemberForm_Account_Payment", MainForm.CultureInfo);
            btnCancel.TextValue = MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo);
            btnFinish.TextValue = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);
            btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;

            this.ddlDay.Text = "Ngày";
            this.ddlMonth.Text = "Tháng";
            this.ddlYear.Text = "Năm";

            rdbMale.Checked = true;
        }
        //call API- Get list card and add to ddlCardType
        private async void GetCardType()
        {
            var tmpList = await DataExchanger.GetListCard();
            var cardSampleList = tmpList.OrderBy(c => c.ProductCode).ToList();

            ddlCardType.DataSource = cardSampleList;
            ddlCardType.ValueMember = "ProductCode";
            ddlCardType.DisplayMember = "MembershipCardCode";
        }

        //call API- Get the list from Server and add it to dropdownlist ddlType
        private async void GetCustomerType()
        {
            customerType = await DataExchanger.GetListCustomerType();
            if (customerType != null)
            {
                ddlType.Items.Clear();
                foreach (var item in customerType)
                {
                    ddlType.Items.Add(item.CustomerType);
                }
            }
            if (this.ddlType.Items != null && this.ddlType.Items.Count > 0)
            {
                this.ddlType.SelectedIndex = 0;
            }
        }

        //Reset all text . Except for ddlCardType
        private void ResetAllText()
        {
            //     ddlCardType.Text = "";
            ddlType.Text = "";
            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtDistrict.Text = "";
            txtCity.Text = "";
            txtCMND.Text = "";

            if (rdbMale.Checked == false)
            {
                rdbMale.Checked = true;
            }
            if (rdbFemale.Checked == true)
            {
                rdbFemale.Checked = false;
            }

            this.ddlDay.Text = "Ngày";
            this.ddlMonth.Text = "Tháng";
            this.ddlYear.Text = "Năm";

            errorCustomerName.Clear();
            errorTxtPhone.Clear();
            errorEmail.Clear();
            errorDateTime.Clear();
            errorIDCard.Clear();
        }

        private void CloseForm()
        {
            this.Close();
            Program.MainForm.LoadDashboard();
        }
        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            btnSearchMember.Enabled = false;
            var cardcode = txtCardCode.Text;
            //Check cardcode can not be empty
            if (string.IsNullOrEmpty(txtCardCode.Text))
            {
                Program.MainForm.HideSplashForm();
                errorCardCode.SetError(txtCardCode, "Mã thẻ không được bỏ trống");
            }
            else
            {
                Program.MainForm.HideSplashForm();
                errorCardCode.Clear();
                CheckCustomerCardCode(cardcode);

            }
            btnSearchMember.Enabled = true;
        }
        //only refresh the fields refer to cardCode
        private void btnRefreshCode_Click(object sender, EventArgs e)
        {
            isValidCard = false;
            ddlCardType.Enabled = false;
            txtCardCode.Text = "";
            txtCardStatus.Text = "";
            ddlCardType.Text = "";
            txtCardType.Text = "";
            txtDefaultBalance.Text = "";
            errorCardCode.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        //call API- Send customer info and card info to server to create Membership card
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            //Check Flag
            btnFinish.Enabled = false;
            String message;
            Program.MainForm.ShowSplashForm(
                            MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
                            MainForm.CultureInfo));
            var cardSample = (MembershipCardSampleModel)(ddlCardType.SelectedItem);
            var product = Program.context.getAvailableSingleProducts().FirstOrDefault(p => p.Code.Equals(cardSample.ProductCode));

            if (txtCardCode.Text.Trim().Length == 0) message = "Chưa nhập mã thẻ";
            else if (!isValidCard) message = " Mã thẻ chưa hợp lệ";
            else if (ddlCardType.Text == "") message = "Chưa chọn mẫu thẻ";
            else if (customerId == 0) message = "Chưa có khách hàng";
            else if (product == null) message = "Mẫu thẻ hiện tại chưa có. Hãy cập nhật sản phẩm";
            else
            {
                //bool rs = await FinishPayment();
                //PosPrinter.PrintBillPaymentMember(_customerModel.Code, _customerModel.CustomerName, currentAmount, _payment.Amount);
                var result = await CreateMembershipCard();
                if (result.Success)
                {
                    SaleScreen3.CreateOrderCard(product, product.Price, customerId);
                    message = "Đăng ký thẻ thành viên thành công";
                    CloseForm();
                }
                else
                {
                    message = result.Message;
                }
            }
            Program.MainForm.HideSplashForm();
            PosMessageDialog.ShowMessage(message);
            btnFinish.Enabled = true;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bootstrapButton1_Click_1(object sender, EventArgs e)
        {
            ResetAllText();
        }

        //refresh all fields customer input (Except cardCode) and left phone input  
        private void bootstrapButton5_Click(object sender, EventArgs e)
        {
            GenerateLayout();
            phone.Text = "";
            customerId = 0;
            errorPhone.Clear();
        }

        //just unlock all text fields and show the btnCreateCustomer


        //call API- Check customer phone exist 
        //- If exist get customer info from server and auto fill and lock all fields
        //- Else reset all text input fields  
        private async void btnSearchPhone_Click(object sender, EventArgs e)
        {
            btnSearchPhone.Enabled = false;
            //Check Phone can not be empty
            if (string.IsNullOrEmpty(phone.Text))
            {
                errorPhone.SetError(phone, "Số điện thoại không được bỏ trống");
            }
            else
            {
                errorPhone.Clear();
                var result = await DataExchanger.CheckCustomerPhone(phone.Text);
                ResetAllText();
                LockAllFields();
                btnCreateCustomer.Hide();
                btnRefreshInfo.Hide();
                if (result.success == true)
                {
                    autoFill(result.customer);
                    btnRefreshInfo.Hide();
                    btnFinish.Enabled = true;
                    btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.Primary;
                }
                else
                {

                    PosMessageDialog.ShowMessage(result.message);
                    btnCreateCustomer.Hide();
                    btnRefreshInfo.Hide();
                    customerId = 0;
                    btnFinish.Enabled = false;
                    btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                }
            }
            btnSearchPhone.Enabled = true;
        }
        //Use customer info to automatically fill in all fields 
        private void autoFill(CustomerEditViewModel2 customer)
        {
            customerId = customer.CustomerID;
            txtCustomerName.Text = customer.CustomerName;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email.Trim();
            txtDistrict.Text = customer.District;
            txtCity.Text = customer.City;
            txtCMND.Text = customer.IDCard;

            if (customer.Gender.Equals("Nam"))
            {
                rdbMale.Checked = true;
            }
            if (customer.Gender.Equals("Nữ"))
            {
                rdbFemale.Checked = true;
            }
            if (!customer.BirthDay.Equals("N/A"))
            {

                String day = customer.BirthDay.Substring(0, 2);
                String month = customer.BirthDay.Substring(3, 2);
                String year = customer.BirthDay.Substring(6, 4);
                this.ddlDay.Text = day;
                this.ddlMonth.Text = month;
                this.ddlYear.Text = year;
            }
            else
            {
                this.ddlDay.Text = "";
                this.ddlMonth.Text = "";
                this.ddlYear.Text = "";
            }

            if (customer.Type != null && customer.Type != 0)
            {
                foreach (var item in customerType)
                {
                    if (item.ID == customer.Type) ddlType.Text = item.CustomerType;

                }
            }
            else ddlType.Text = "";
        }
        //call API- send customer info to server
        private async void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            btnCreateCustomer.Enabled = false;

            if (ValidateInput())
            {
                Program.MainForm.ShowSplashForm(
                MainForm.ResManager.GetString("Sys_Wait_For_Progressing",
                MainForm.CultureInfo));
                var result = await CreateCustomer();
                if (result.Success)
                {
                    Program.MainForm.HideSplashForm();
                    PosMessageDialog.ShowMessage(result.Message);
                    phone.Text = txtPhone.Text;

                    var result2 = await DataExchanger.CheckCustomerPhone(phone.Text);
                    ResetAllText();
                    LockAllFields();
                    btnCreateCustomer.Hide();
                    btnRefreshInfo.Hide();

                    if (result2.success == true)
                    {
                        autoFill(result2.customer);
                        btnCreateCustomer.Hide();
                        btnRefreshInfo.Hide();
                        customerId = result2.customer.CustomerID;

                        btnFinish.Enabled = true;
                        btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.Primary;
                    }
                    else
                    {
                        PosMessageDialog.ShowMessage("Có lỗi xảy ra . Xin thử kiểm tra thông tin bằng số điện thoại mới tạo");
                        UnLockAllFields();
                        btnFinish.Enabled = false;
                        btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                    }
                }
                else
                {
                    Program.MainForm.HideSplashForm();
                    PosMessageDialog.ShowMessage(result.Message);
                    btnFinish.Enabled = true;
                    btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
                }
            }
            btnCreateCustomer.Enabled = true;
        }

        private void LoadAllSampleCard()
        {

        }

        private void ddlType_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ddlCardType_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void ddlDay_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void ddlYear_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void ddlMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void txtCardCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void phone_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void txtCMND_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9) && e.KeyCode != Keys.Back && e.KeyCode != Keys.OemOpenBrackets && (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9))
                e.SuppressKeyPress = true;
        }

        private void ddlCardType_Click(object sender, EventArgs e)
        {
            this.ddlCardType.DroppedDown = true;
        }

        //get the information of cardcode when change cardcode type
        private void ddlCardType_TextChanged(object sender, EventArgs e)
        {
            if (ddlCardType.Items != null && ddlCardType.Items.Count > 0)
            {
                var cardSample = (MembershipCardSampleModel)ddlCardType.SelectedItem;
                txtCardType.Text = cardSample.MembershipCardCode;
                txtDefaultBalance.Text = (cardSample.Account != null &&
                                          cardSample.Account.Count > 0 &&
                                          cardSample.Account.FirstOrDefault(a => a.Type == (int)AccountTypeEnum.CreditAccount) != null)
                                          ? string.Format("{0:n0}", cardSample.Account.FirstOrDefault(a => a.Type == (int)AccountTypeEnum.CreditAccount).Balance)
                                          : "";
            }
            if (ddlCardType.Text == "")
            {
                txtCardType.Text = "";
                txtDefaultBalance.Text = "";
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //lock and reset Customer input text
            UnLockAllFields();
            //ddlCardType.Enabled = false;
            ResetAllText();
            //lock btn finish
            btnFinish.Enabled = false;
            btnFinish.BackgroudBootstrapColor = BootstrapColorEnum.BackColor;
            //show btnCreateCustomer
            btnCreateCustomer.Show();
            btnRefreshInfo.Show();
        }

        private void btnRefreshInfo_Click(object sender, EventArgs e)
        {
            //  UnLockAllFields();
            GetCustomerType();
            ResetAllText();
        }
    }
}
