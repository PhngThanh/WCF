using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Properties;
using POS.Repository;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ViewModels;
using POS.Utils;
using log4net;

namespace POS.DashboardScreen.ViewOrderScreen
{
    public partial class ReviewOrderScreen : UserControl
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        int _column = 4;
        int _row = 3;
        private int currentPage = 0;
        private int totalPage = 0;
        private List<OrderEditViewModel> _orderList;
        private List<TableViewModel> _tables;

        public DateTime SelectedDate { get; set; }

        public ReviewOrderScreen()
        {
            InitializeComponent();

            GenerateLayout();

            SelectedDate = UtcDateTime.Now().Date;
            btnDate.Caption = SelectedDate.ToString("dd/MM/yyyy");

            CreateOrderPanel();
        }

        private void GenerateLayout()
        {
            //this.ptbLogo.SizeMode = PictureBoxSizeMode.CenterImage;
            //this.ptbLogo.ImageLocation = "./Resources/" + MainForm.StoreInfo.LogoSimple;
            MainForm.SetLogo( ptbLogo, "./Resources/" + MainForm.StoreInfo.LogoSimple);
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.lineGreen.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnDate.BorderColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnDate.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.lblTotalPage.ForeColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }

        private void CreateOrderPanel()
        {
            orderContainerInner.ColumnCount = _column; //So luong san pham thao chieu ngang
            orderContainerInner.RowCount = _row; //So luong san pham theo chieu doc
            //Set grid layout column x row
            orderContainerInner.ColumnStyles.Clear();
            orderContainerInner.RowStyles.Clear();
            for (var i = 0; i < _column; i++)
            {
                orderContainerInner.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, (float)100.0 / _column));
            }

            for (var i = 0; i < _row; i++)
            {
                orderContainerInner.RowStyles.Add(
                    new RowStyle(SizeType.Percent, (float)100.0 / _row));
            }

        }

        public void LoadItems()
        {
            try
            {
                //message:Đang thống kê...
                var text = MainForm.ResManager.GetString(
                                "ReportDateFilterDialog_Generate_Report_Waiting",
                                MainForm.CultureInfo);

                Program.MainForm.ShowSplashForm(text);

                OrderService orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));

                if (orderService != null)
                    _orderList = ServiceManager.GetOrderEditViewModels(orderService.GetOrderByDate(SelectedDate, SelectedDate).ToList());

                FilterLoad();

                RefreshOrderList();

                // Get print image.
                Program.MainForm.HideSplashForm();
            }
            catch (Exception ex)
            {
                log.Error("LoadItems - " + ex);
                Program.MainForm.HideSplashForm();

                //message:Vui lòng thử lại sau!
                var msg = new MessageDialog(
                    MainForm.ResManager.GetString("Sys_Generate_Report_Failed", MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo));
                msg.ShowDialog();
            }
        }

        private Color GetOrderItemColor(OrderTypeEnum orderType)
        {
            switch (orderType)
            {
                //case OrderTypeEnum.AtStore:
                //    return Color.FromArgb(223, 168, 23);
                //case OrderTypeEnum.TakeAway:
                //    return Color.FromArgb(146, 3, 205);
                //case OrderTypeEnum.Delivery:
                //    return Color.FromArgb(124, 124, 124);
                case OrderTypeEnum.AtStore:
                    return ColorScheme.GetColor(BootstrapColorEnum.Default);
                case OrderTypeEnum.TakeAway:
                    return ColorScheme.GetColor(BootstrapColorEnum.Primary);
                case OrderTypeEnum.Delivery:
                    return ColorScheme.GetColor(BootstrapColorEnum.Warning);
                case OrderTypeEnum.OrderCard:
                    return ColorScheme.GetColor(BootstrapColorEnum.Success);
            }
            return ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }

        private Color GetOrderStatusColor(OrderStatusEnum orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatusEnum.New:
                    return ColorScheme.GetColor(BootstrapColorEnum.Info);
                case OrderStatusEnum.PosProcessing:
                    return ColorScheme.GetColor(BootstrapColorEnum.Primary);
                case OrderStatusEnum.PosPreCancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Warning);
                case OrderStatusEnum.PreCancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Warning);
                case OrderStatusEnum.PosCancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Danger);
                case OrderStatusEnum.Cancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Danger);
                case OrderStatusEnum.PosFinished:
                    return ColorScheme.GetColor(BootstrapColorEnum.Default);
                case OrderStatusEnum.Finish:
                    return ColorScheme.GetColor(BootstrapColorEnum.Default);
            }
            return Color.Empty;
        }

        /// <summary>
        /// First time load, set default = All
        /// </summary>
        private void FilterLoad()
        {
            if (btnAtStoreMode.IsActive == false
                && btnDeliveryMode.IsActive == false
                && btnTakeAwayMode.IsActive == false
                && btnOrderCardMode.IsActive == false
                && btnProcessingStatus.IsActive == false
                && btnFinishStatus.IsActive == false
                && btnCancelStatus.IsActive == false)
            {
                btnAllMode.ActiveBackgroudColor = Color.Black;
                btnAtStoreMode.ActiveBackgroudColor = Color.Black;
                btnDeliveryMode.ActiveBackgroudColor = Color.Black;
                btnTakeAwayMode.ActiveBackgroudColor = Color.Black;
                btnOrderCardMode.ActiveBackgroudColor = Color.Black;
                btnAllStatus.ActiveBackgroudColor = Color.Black;
                btnProcessingStatus.ActiveBackgroudColor = Color.Black;
                btnFinishStatus.ActiveBackgroudColor = Color.Black;
                btnCancelStatus.ActiveBackgroudColor = Color.Black;

                btnAllMode.IsActive = true;
                btnAllStatus.IsActive = true;
            }
        }


        private void orderControl_Click(object sender, EventArgs e)
        {
            // CommunicationBridge.PlayClickSound();
            var orControl = sender as ReviewOrderControl;
            if (orControl == null) return;
            var order = orControl.OrderEditViewModel;
            if (order == null) return;

            //Program.MainForm.LoadSaleScreen(order,(OrderTypeEnum)order.OrderType,null);

            var viewDialog = new ViewOrderDetailDialog();
            viewDialog.OrderChanged += delegate { this.LoadItems(); };
            viewDialog.LoadOrder(order);
            viewDialog.ShowDialog();
        }

        private void RefreshOrderList()
        {
            #region Check Status & Mode Selected

            int mode = -1;

            if (btnAtStoreMode.IsActive)
            {
                mode = (int)OrderTypeEnum.AtStore;
            }
            else if (btnTakeAwayMode.IsActive)
            {
                mode = (int)OrderTypeEnum.TakeAway;
            }
            else if (btnDeliveryMode.IsActive)
            {
                mode = (int)OrderTypeEnum.Delivery;
            }
            else if (btnOrderCardMode.IsActive)
            {
                mode = (int)OrderTypeEnum.OrderCard;
            }
            else if (btnAllMode.IsActive)
            {
                //Do nothing
            }

            List<int> status = new List<int>();

            if (btnProcessingStatus.IsActive)
            {
                status.Add((int)OrderStatusEnum.PosProcessing);
            }
            else if (btnFinishStatus.IsActive)
            {
                status.Add((int)OrderStatusEnum.PosFinished);
                status.Add((int)OrderStatusEnum.Finish);
            }
            else if (btnCancelStatus.IsActive)
            {
                status.Add((int)OrderStatusEnum.PosPreCancel);
                status.Add((int)OrderStatusEnum.PreCancel);
                status.Add((int)OrderStatusEnum.PosCancel);
                status.Add((int)OrderStatusEnum.Cancel);
            }
            else
            {
                //Do nothing
            }

            List<OrderEditViewModel> list;

            if (status.Count == 0 && mode == -1)
            {
                list = _orderList
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 1 && mode == -1)
            {
                list = _orderList
                    .Where(a => a.OrderStatus == status.FirstOrDefault())
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 2 && mode == -1)
            {
                list = _orderList
                    .Where(a => a.OrderStatus == status[0] || a.OrderStatus == status[1])
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 4 && mode == -1)
            {
                list = _orderList
                    .Where(a => a.OrderStatus == status[0] || a.OrderStatus == status[1]
                            || a.OrderStatus == status[2] || a.OrderStatus == status[3])
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 1 && mode != -1)
            {
                list = _orderList
                    .Where(a => a.OrderStatus == status.FirstOrDefault() && a.OrderType == mode)
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 2 && mode != -1)
            {
                list = _orderList
                    .Where(a => (a.OrderStatus == status[0] || a.OrderStatus == status[1]) && a.OrderType == mode)
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else if (status.Count == 4 && mode != -1)
            {
                list = _orderList
                    .Where(a => (a.OrderStatus == status[0] || a.OrderStatus == status[1]
                                    || a.OrderStatus == status[2] || a.OrderStatus == status[3]) && a.OrderType == mode)
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }
            else // status.Count == 0 && mode != -1
            {
                list = _orderList
                    .Where(a => a.OrderType == mode)
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }

            #endregion

            #region Update Page

            int pageSize = _column * _row;
            totalPage = (int)Math.Ceiling(((double)list.Count) / pageSize);

            lblPage.Text = (currentPage + 1).ToString();
            lblTotalPage.Text = "/" + totalPage;

            if (totalPage < 2)
            {
                pnlPaging.Visible = false;
            }
            else
            {
                pnlPaging.Visible = true;
            }

            var currentPageSize = (currentPage == totalPage - 1) ? (list.Count - currentPage * pageSize) : pageSize;

            orderContainerInner.Controls.Clear();
            foreach (Control c in this.orderContainerInner.Controls)
            {
                c.Dispose();
            }

            if (_tables == null)
            {
                _tables = Program.MainForm._tablePanel.GetCurrentTables(true);
            }

            var tmpList = list.Skip(pageSize * currentPage).Take(currentPageSize).ToList();

            foreach (var order in tmpList)
            {
                var firstOrDefault = _tables.FirstOrDefault(t => t.Id == order.TableId);
                if (firstOrDefault != null)
                    order.TableNumber = firstOrDefault.Number;

                var borderColor = GetOrderItemColor((OrderTypeEnum)order.OrderType);
                var statusColor = GetOrderStatusColor((OrderStatusEnum)order.OrderStatus);

                var orderControl = new ReviewOrderControl(borderColor, statusColor, order);

                // Add click handler.
                orderControl.Margin = new Padding(0, 10, 15, 10);
                orderControl.Click += orderControl_Click;

                orderContainerInner.Controls.Add(orderControl);
            }

            #endregion
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            var control = (BootstrapButton)sender;
            control.IsActive = true;

            currentPage = 0;
            RefreshOrderList();
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.DimGray;
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            using (var mbox = new DateSelectDialog(SelectedDate))
            {
                var rs = mbox.ShowDialog();
                if (rs != DialogResult.OK) return;
                btnDate.Caption = mbox.SelectedDate.ToString("dd/MM/yyyy");
                btnDate.Invalidate();
                if (SelectedDate == mbox.SelectedDate) return;
                SelectedDate = mbox.SelectedDate;
                LoadItems();
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadTableScreen();
        }

        private void btnPageBack_MouseUp(object sender, MouseEventArgs e)
        {
            btnPageBack.Image = Resources.arrow_w_u;
            if (currentPage > 0)
            {
                currentPage--;
                LoadItems();
            }
        }

        private void btnPageBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnPageBack.Image = Resources.arrow_g_u;
        }

        private void btnPageNext_MouseDown(object sender, MouseEventArgs e)
        {
            btnPageNext.Image = Resources.arrow_g_d;
        }

        private void btnPageNext_MouseUp(object sender, MouseEventArgs e)
        {
            btnPageNext.Image = Resources.arrow_w_d;
            if (currentPage < totalPage - 1)
            {
                currentPage++;
                LoadItems();
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadReportScreen();
        }

        private void btnViewNoti_Click(object sender, EventArgs e)
        {

        }
    }
}
