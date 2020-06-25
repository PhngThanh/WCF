using System;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Repository;

namespace POS.SaleScreen
{
    public delegate void BarcodeReceivedEventHandler(String barCode);
    
    public partial class CustomerInfoPanel2 : UserControl
    {
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        public event BarcodeReceivedEventHandler BarcodeReceived;
        public Action ClearBarcode;
        public event Action ClearMemberProperty;

        public CustomerInfoPanel2()
        {
            InitializeComponent();
            GenerateLayout();
            LoadCustomerInfo();
            UpdateCustomerGroup();
            UpdateNationality();

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCustomerName);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtAddress);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtCustomerNotes);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtPhone);
                OnScreenKeyboardDialog.Instance.AddTextbox(txtMembershipCard);
            }


        }

        private void GenerateLayout()
        {
            if (MainForm.PosConfig.IsShowCustomerNotes.Trim().ToLower() == "false")
            {
                bsBtnCustomerNotes.Hide();
                txtCustomerNotes.Hide();
                //lblPoint.Hide();
                //lblMemberPoint.Hide();
            }

            this.lblCustomerInfo.Text = MainForm.ResManager.GetString("CustomerInfoPanel2_Title", MainForm.CultureInfo);
            this.bsBtnMembershipCard.TextValue = MainForm.ResManager.GetString("Sys_Open_Member_Card_Screen", MainForm.CultureInfo);
            this.bsBtnCustomerName.TextValue = MainForm.ResManager.GetString("Sys_Customer_Name", MainForm.CultureInfo);
            this.bsBtnCustomerPhone.TextValue = MainForm.ResManager.GetString("Sys_Phone_Number", MainForm.CultureInfo);
            this.bsBtnCustomerAddress.TextValue = MainForm.ResManager.GetString("Sys_Delivery_Address", MainForm.CultureInfo);
            this.bsBtnCustomerNotes.TextValue = MainForm.ResManager.GetString("Sys_Note_Title", MainForm.CultureInfo);
            this.bsBtnNumberCustomer.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_GroupType", MainForm.CultureInfo);
            this.btnSingle.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_GroupType_Single", MainForm.CultureInfo);
            this.btnCouple.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_GroupType_Couple", MainForm.CultureInfo);
            this.btnGroup.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_GroupType_Group", MainForm.CultureInfo);
            this.btnFamily.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_GroupType_Family", MainForm.CultureInfo);
            this.bsBtnCustomerType.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_Nation", MainForm.CultureInfo);
            this.btnVietnam.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_Nation_VN", MainForm.CultureInfo);
            this.btnAsian.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_Nation_Asia", MainForm.CultureInfo);
            this.btnEU.TextValue = MainForm.ResManager.GetString("CustomerInfoPanel2_Nation_Eu", MainForm.CultureInfo);
            this.btnOtherNationality.TextValue = MainForm.ResManager.GetString("Sys_Other", MainForm.CultureInfo);

        }

        public void LoadCustomerInfo()
        {
            // if DeliveryCustomer == null => return "" else return DeliveryCustomer
            txtCustomerName.Text = currentOrderManager.getOrderEditViewModel().DeliveryCustomer ?? "";
            txtAddress.Text = currentOrderManager.getOrderEditViewModel().DeliveryAddress ?? "";
            txtPhone.Text = currentOrderManager.getOrderEditViewModel().DeliveryPhone ?? "";
            txtMembershipCard.Text = currentOrderManager.getOrderEditViewModel().BarCode ?? "";

            btnSingle.ButtonValue = ((int)CustomerGroupEnum.Single).ToString();
            btnCouple.ButtonValue = ((int)CustomerGroupEnum.Couple).ToString();
            btnGroup.ButtonValue = ((int)CustomerGroupEnum.Group).ToString();
            btnFamily.ButtonValue = ((int)CustomerGroupEnum.Family).ToString();

            btnVietnam.ButtonValue = ((int)CustomerNationalityEnum.VietNam).ToString();
            btnAsian.ButtonValue = ((int)CustomerNationalityEnum.Asian).ToString();
            btnEU.ButtonValue = ((int)CustomerNationalityEnum.European).ToString();
            btnOtherNationality.ButtonValue = ((int)CustomerNationalityEnum.Other).ToString();
        }

        public void UpdateCustomerGroup()
        {
            var numOfGuest = currentOrderManager.getOrderEditViewModel().NumberOfGuest;

            BootstrapButton currentButton;
            switch (numOfGuest)
            {
                case 1:
                    currentButton = btnSingle;
                    break;
                case 2:
                    currentButton = btnCouple;
                    break;
                case 3:
                    currentButton = btnGroup;
                    break;
                case 4:
                    currentButton = btnFamily;
                    break;
                default:
                    currentButton = btnSingle;
                    break;
            }

            btnCouple.IsActive = false;
            btnSingle.IsActive = false;
            btnGroup.IsActive = false;
            btnFamily.IsActive = false;

            if (currentButton != null)
            {
                currentButton.IsActive = true;
                currentOrderManager.getOrderEditViewModel().NumberOfGuest = int.Parse(currentButton.ButtonValue);
            }
        }

        public void UpdateNationality()
        {
            var nationalityGroup = currentOrderManager.getOrderEditViewModel().CustomerType;

            BootstrapButton currentButton;
            switch (nationalityGroup)
            {
                case 1:
                    currentButton = btnVietnam;
                    break;
                case 2:
                    currentButton = btnAsian;
                    break;
                case 3:
                    currentButton = btnEU;
                    break;
                case 4:
                    currentButton = btnOtherNationality;
                    break;
                default:
                    currentButton = btnVietnam;
                    break;
            }

            btnVietnam.IsActive = false;
            btnAsian.IsActive = false;
            btnEU.IsActive = false;
            btnOtherNationality.IsActive = false;

            if (currentButton != null)
            {
                currentButton.IsActive = true;
                currentOrderManager.getOrderEditViewModel().CustomerType = int.Parse(currentButton.ButtonValue);
            }
        }

        public void ResetTextboxes(bool resetInOrder = false)
        {
            if (resetInOrder)
            {
                currentOrderManager.getOrderEditViewModel().DeliveryCustomer = null;
                currentOrderManager.getOrderEditViewModel().DeliveryAddress = null;
                currentOrderManager.getOrderEditViewModel().DeliveryPhone = null;
                currentOrderManager.getOrderEditViewModel().Notes = null;
            }

            txtCustomerName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtCustomerNotes.Text = "";
        }

        public void LoadCustomerFormModel(string name)
        {
            txtCustomerName.Text = name;
        }

        public void UpdateCustomerInfo()
        {
            currentOrderManager.getOrderEditViewModel().DeliveryCustomer = txtCustomerName.Text;
            currentOrderManager.getOrderEditViewModel().DeliveryAddress = txtAddress.Text;
            currentOrderManager.getOrderEditViewModel().DeliveryPhone = txtPhone.Text;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == ((char)13))
            //{
            //    SearchCustomer();
            //}
        }

        private void pnlCustomerList_VisibleChanged(object sender, EventArgs e)
        {
            var customer = pnlCustomerList.Customer;
            if (customer != null)
            {
                txtCustomerName.Text = customer.CustomerName;
                txtPhone.Text = customer.PhoneNumber;
                txtAddress.Text = customer.Address;

                UpdateCustomerInfo();
                UpdateCustomerGroup();
                //UpdateNotes();

                pnlCustomerList.Hide();
                pnlCustomerList.Customer = null;
            }
        }

        private void SearchCustomer()
        {
            //            var customerService = ServiceManager.GetService<CustomerService>(typeof (CustomerRepository));
            //            pnlCustomerList.ClearItems();
            //            List<CustomerViewModel> customers = customerService.GetCustomerByPhone(txtPhone.Text).ToList();
            //            if (customers.Count > 0)
            //            {
            //                pnlCustomerList.Show();
            //                pnlCustomerList.BringToFront();
            //                for (int i = 0; i < customers.Count && i < 5; i++)
            //                {
            //                    pnlCustomerList.UpdateCustomerList(customers[i], OrderDetailChangeMode.AddOrderDetail);
            //                }
            //            }
            //            else
            //            {
            //                pnlCustomerList.Hide();
            //            }
        }

        public void btnCustomerInfoRefresh_Click(object sender, EventArgs e)
        {
            RefreshPanel();

            UpdateCustomerInfo();

            RemoveBarCode();

            if (ClearMemberProperty != null)
            {
                ClearMemberProperty();
            }


        }

        public void RefreshPanel()
        {
            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtCustomerNotes.Text = "";
            txtPhone.Text = "";

            btnCouple.IsActive = false;
            btnSingle.IsActive = true;
            btnGroup.IsActive = false;
            btnFamily.IsActive = false;

            btnVietnam.IsActive = true;
            btnAsian.IsActive = false;
            btnEU.IsActive = false;
            btnOtherNationality.IsActive = false;
        }

        private void NumberOfGuest_Changed(object sender, EventArgs args)
        {
            btnCouple.IsActive = false;
            btnSingle.IsActive = false;
            btnGroup.IsActive = false;
            btnFamily.IsActive = false;

            var button = (sender as BootstrapButton);
            if (button != null)
            {
                button.IsActive = true;
                currentOrderManager.getOrderEditViewModel().NumberOfGuest = int.Parse(button.ButtonValue);
            }
        }

        private void Nationality_Changed(object sender, EventArgs args)
        {
            btnEU.IsActive = false;
            btnVietnam.IsActive = false;
            btnAsian.IsActive = false;
            btnOtherNationality.IsActive = false;

            var button = (sender as BootstrapButton);
            if (button != null)
            {
                button.IsActive = true;
                currentOrderManager.getOrderEditViewModel().CustomerType = int.Parse(button.ButtonValue);
            }

        }

        private void TextBoxCustomerInfo_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateCustomerInfo();
        }

        public void InputMemberCard(string cardCode)
        {
            txtMembershipCard.ResetText();
            txtMembershipCard.Text = cardCode;
        }

        public void btnClearMembershipCard_Click(object sender, EventArgs e)
        {
            RemoveBarCode();
            if (ClearMemberProperty != null)
            {
                ClearMemberProperty();
            }
            if (!currentOrderManager.isCurrentCustomerModelEmpty())
            {
                currentOrderManager.getOrderEditViewModel().DeliveryCustomer = "";
                txtCustomerName.Text = "";
                currentOrderManager.setCurrentCustomerModel(null);
                if (ClearMemberProperty != null)
                {
                    ClearMemberProperty();
                }
            }
        }

        private void RemoveBarCode()
        {
            txtMembershipCard.ResetText();
            if (ClearBarcode != null)
            {
                ClearBarcode();
            }
        }

        public void btnCheck_Click(object sender, EventArgs e)
        {
            String barCode = txtMembershipCard.Text;
            if (BarcodeReceived != null)
            {
                BarcodeReceived(barCode);
            }
        }
    }
}
