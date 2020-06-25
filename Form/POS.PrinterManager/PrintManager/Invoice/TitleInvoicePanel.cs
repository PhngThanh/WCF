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
    public partial class TitleInvoicePanel : UserControl
    {
        public TitleInvoicePanel()
        {
            InitializeComponent();
            LoadDate(DateTime.Today);
        }

        public void LoadDate(DateTime date)
        {
            this.lblDayInput.Text = date.Day.ToString();
            this.lblMonthInput.Text = date.Month.ToString();
            this.lblYearInput.Text = date.Year.ToString();
        }
    }
}
