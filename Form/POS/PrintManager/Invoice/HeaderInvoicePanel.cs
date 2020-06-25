using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.PrintManager.Invoice
{
    public partial class HeaderInvoicePanel : UserControl
    {
        public HeaderInvoicePanel()
        {
            InitializeComponent();
            LoadCompanyInfo();
        }

        public void LoadCompanyInfo()
        {
            this.lblCompanyNameVI.Text = MainForm.VATInvoice.InvoiceCompanyNameVi;
            this.lblCompanyNameEn.Text = MainForm.VATInvoice.InvoiceCompanyNameEn;
            this.lblAddressInput.Text = MainForm.VATInvoice.InvoiceCompanyAddress;
            this.lblPhoneInput.Text = MainForm.VATInvoice.InvoiceCompanyTel;
            this.lblVATCodeInput.Text = MainForm.VATInvoice.InvoiceCompanyVATCode;
        }
    }
}
