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
    public partial class MainInvoicePanel : UserControl
    {
        public MainInvoicePanel()
        {
            InitializeComponent();
        }

        private HeaderInvoicePanel _pnlHeader;              //1
        private TitleInvoicePanel _pnlTitle;                //2
        private CustomerInfoPanel _pnlCustInfo;             //3
        private OrderDetailInvoicePanel _pnlOrderDetail;    //4
        private PaymentInvoicePanel _pnlPayment;            //5
        private FooterInvoicePanel _pnlFooter;              //6

        public void GenerateLayout(OrderEditViewModel orderViewModel, CustomerInfoModel cusInfo)
        {
            var x = 5; //border bên ngoài = 5
            var y = 5; //border bên ngoài = 5

            _pnlHeader = new HeaderInvoicePanel();
            _pnlHeader.Location = new Point(x, y);
            pnlMain.Controls.Add(_pnlHeader);

            y += _pnlHeader.Height;
            y += 3; //border giữa = 3

            _pnlTitle = new TitleInvoicePanel();
            _pnlTitle.Location = new Point(x, y);
            pnlMain.Controls.Add(_pnlTitle);

            y += _pnlTitle.Height;
            y += 3; //border giữa = 3

            _pnlCustInfo = new CustomerInfoPanel(cusInfo);
            _pnlCustInfo.Location = new Point(x, y);

            pnlMain.Controls.Add(_pnlCustInfo);

            y += _pnlCustInfo.Height;
            y += 3; //border giữa = 3

            _pnlOrderDetail = new OrderDetailInvoicePanel();
            _pnlOrderDetail.Location = new Point(x, y);
            _pnlOrderDetail.LoadOrderDetail(orderViewModel.OrderDetailEditViewModels, 0);
            pnlMain.Controls.Add(_pnlOrderDetail);

            y += _pnlOrderDetail.Height;
            //không có border ở đây

            _pnlPayment = new PaymentInvoicePanel();
            _pnlPayment.Location = new Point(x, y);
            _pnlPayment.LoadPayment(orderViewModel);
            pnlMain.Controls.Add(_pnlPayment);

            y += _pnlPayment.Height;

            _pnlFooter = new FooterInvoicePanel();
            _pnlFooter.Location = new Point(x, y);
            pnlMain.Controls.Add(_pnlFooter);
        }

    }
}
