using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Repository.ViewModels;

namespace POS.PrintManager.Invoice
{
    public partial class CustomerInfoPanel : UserControl
    {
        public static CustomerInfoModel _cusInfo = new CustomerInfoModel();
        public CustomerInfoPanel(CustomerInfoModel cusInfo)
        {
            _cusInfo = cusInfo;
            InitializeComponent();
            LoadCustomerInfo();
        }

        public void LoadCustomerInfo()
        {
            txtCustName.Text = !string.IsNullOrEmpty(_cusInfo.CustomerName) ? _cusInfo.CustomerName : "";
            txtCustCompany.Text = !string.IsNullOrEmpty(_cusInfo.CustomerCompany) ? _cusInfo.CustomerCompany : "";
            txtCustCompanyAddress.Text = !string.IsNullOrEmpty(_cusInfo.CustomerCompanyAddress) ? _cusInfo.CustomerCompanyAddress : "";
            txtPaymentMethod.Text = !string.IsNullOrEmpty(_cusInfo.PaymentMethod) ? _cusInfo.PaymentMethod : "";
            txtCustTaxCode.Text = !string.IsNullOrEmpty(_cusInfo.CustomerTaxCode) ? _cusInfo.CustomerTaxCode : "";
            txtCustAccountNo.Text = !string.IsNullOrEmpty(_cusInfo.CustomerAccountNo) ? _cusInfo.CustomerAccountNo : "";
        }
    }
}
