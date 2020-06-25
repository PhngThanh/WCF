using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.PrintManager;
using POS.Repository.ViewModels;
using POS.SaleScreen.CustomControl;

namespace POS.DashboardScreen.ReportScreen
{
    public partial class ReceiptReportDialog : Form
    {
        Printer printer = new Printer();

       // private readonly bool _isPrintDetail;
        private readonly string _account;
        public ReceiptReportDialog(OrderEditViewModel order)
        {
            InitializeComponent();
            //_isPrintDetail = isDetail;
            _account = MainForm.CurrentAccount.AccountId;
       

            pBox.Image = printer.GetImageReport(order); ;
            AdjustContainerInnerHeight();
            lblUp.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;
            lblDown.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;

            lblUp.Click += lblUp_Click;
            lblDown.Click += lblDown_Click;
//            lblUp.Enabled = pnlItemContainer.Height > Height;
//            lblDown.Enabled = pnlItemContainer.Top < 0;
        }

        private void AdjustContainerInnerHeight()
        {
            pBox.Top = 0;

            // Scrolling.
            var ratio = (float)pBox.Height / containerOuter.Height;
            if (ratio <= 1)
            {
                lblUp.Enabled = false;
                lblDown.Enabled = false;
            }
            else
            {
                lblDown.Enabled = true;
                lblUp.Enabled = false;
            }
        }

        private void lblDown_Click(object sender, EventArgs e)
        {
            var top = pBox.Top - containerOuter.Height * 3 / 4;
            if (top + pBox.Height <= containerOuter.Height)
            {
                lblDown.Enabled = false;
                top = containerOuter.Height - pBox.Height;
            }
            pBox.Top = top;
            lblUp.Enabled = true;
        }

        private void lblUp_Click(object sender, EventArgs e)
        {
            var top = pBox.Top + containerOuter.Height * 3 / 4;
            if (top >= 0)
            {
                lblUp.Enabled = false;
                top = 0;
            }
            pBox.Top = top;
            lblDown.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(124, 124, 124), 5))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void lblUp_Click_1(object sender, EventArgs e)
        {

        }

        //private void btnPrint_Click(object sender, EventArgs e)
        //{

        //    //var pic = printer.GetImageReport(_orders.ToList(), Program.MainForm.CurrentAccount.AccountId);   \


        //    printer.PrintStoreReport(_storeReport,_account);
        //    //printer.PrintReportNonDetail(_orders.ToList(), _account);
        //}
    }
}
