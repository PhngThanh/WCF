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
using POS.Repository.Entities;
using AutoMapper;

namespace POS.DashboardScreen.OnlineOrderScreen
{
    public partial class OnlineOrdersScreen : UserControl
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        int column = 4;
        int row = 3;
        private List<OrderEditViewModel> _orderList;
        public DateTime SelectedDate { get; set; }
        private int currentPage = 0;
        private int totalPage = 0;
        //private readonly DataLoader _dataLoader;

        public OnlineOrdersScreen()
        {
            //_dataLoader = dataLoader;
            InitializeComponent();

            GenerateLayout();

            SelectedDate = UtcDateTime.Now().Date;
            btnDate.Caption = SelectedDate.ToString("dd/MM/yyyy");
            LoadItems();
        }

        private void GenerateLayout()
        {
            MainForm.SetLogo( ptbLogo, "./Resources/" + MainForm.StoreInfo.LogoSimple);
            //this.ptbLogo.ImageLocation = "./Resources/" + MainForm.StoreInfo.LogoSimple;
            //this.ptbLogo.SizeMode = PictureBoxSizeMode.CenterImage;

            lblTotalPage.ForeColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnDate.BorderColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnDate.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            lineGreen.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

            CreateOnlineOrderPanel();
        }

        private void CreateOnlineOrderPanel()
        {
            orderContainerInner.ColumnCount = column; //So luong san pham thao chieu ngang
            orderContainerInner.RowCount = row; //So luong san pham theo chieu doc
            //Set grid layout column x row
            orderContainerInner.ColumnStyles.Clear();
            orderContainerInner.RowStyles.Clear();
            for (var i = 0; i < column; i++)
            {
                orderContainerInner.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, (float)100.0 / column));
            }

            for (var i = 0; i < row; i++)
            {
                orderContainerInner.RowStyles.Add(
                    new RowStyle(SizeType.Percent, (float)100.0 / row));
            }

        }

        private void cboFilter_ItemSelected(object sender, EventArgs e)
        {
            RefreshOrderList();
        }

        public void Reset()
        {
        }

        public void LoadItems()
        {
            try
            {
                //message:Đang thống kê...
                var text = MainForm.ResManager.GetString(
                                "ReportDateFilterDialog_Generate_Report_Waiting",
                                MainForm.CultureInfo);
                //Program.MainForm.ShowSplashForm(text);

                OrderService orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                var x = orderService.Get(c => c.OrderType == (int)OrderTypeEnum.Delivery && c.CheckInDate>SelectedDate).ToList();
                //_orderList=                    
                //    ServiceManager.GetOrderEditViewModels(
                //        orderService.GetOrderByDate(SelectedDate, SelectedDate)
                //            //.Where(w => (int)w.OrderType!=0)
                //            .ToList()
                //            );
                _orderList = new List<OrderEditViewModel>();
               foreach (var item in x)
                {
                    var dto =new OrderEditViewModel();
                    dto = Mapper.Map<Order, OrderEditViewModel>(item);
                    foreach (var orderDetail in item.OrderDetails)
                    {
                        var detail = Mapper.Map<OrderDetail, OrderDetailEditViewModel>(orderDetail);
                        dto.OrderDetailEditViewModels.Add(detail);
                    }
                    foreach (var promotion in item.OrderPromotionMappings)
                    {
                        var detail = Mapper.Map<OrderPromotionMapping, OrderPromotionMappingEditViewModel>(promotion);
                        dto.OrderPromotionMappingEditViewModels.Add(detail);
                    }
                    foreach (var payment in item.Payments)
                    {
                        var detail = Mapper.Map<Payment, PaymentEditViewModel>(payment);
                        dto.PaymentEditViewModels.Add(detail);
                    }
                    _orderList.Add(dto);
                }
               
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

        private Color GetOrderStatusColor(DeliveryStatusEnum orderStatus)
        {
            switch (orderStatus)
            {
                //case DeliveryStatus.New
                //case DeliveryStatus.Fail
                //case DeliveryStatus.Delivery

                case DeliveryStatusEnum.Assigned:
                    return ColorScheme.GetColor(BootstrapColorEnum.Primary);
                case DeliveryStatusEnum.PosRejected:
                    return ColorScheme.GetColor(BootstrapColorEnum.Warning);
                case DeliveryStatusEnum.PreCancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Warning);
                case DeliveryStatusEnum.Cancel:
                    return ColorScheme.GetColor(BootstrapColorEnum.Danger);
                case DeliveryStatusEnum.PosAccepted:
                    return ColorScheme.GetColor(BootstrapColorEnum.Default);
                case DeliveryStatusEnum.Finish:
                    return ColorScheme.GetColor(BootstrapColorEnum.Default);
            }
            return Color.Empty;
        }


        private void FilterLoad()
        {
            if (btnAllDeliveryStatus.IsActive == false
                && btnAssignedDeliveryStatus.IsActive == false
                && btnAcceptedDeliveryStatus.IsActive == false
                && btnRejectedDeliveryStatus.IsActive == false)
            {
                btnAllDeliveryStatus.ActiveBackgroudColor = Color.Black;
                btnAssignedDeliveryStatus.ActiveBackgroudColor = Color.Black;
                btnAcceptedDeliveryStatus.ActiveBackgroudColor = Color.Black;
                btnRejectedDeliveryStatus.ActiveBackgroudColor = Color.Black;

                btnAllDeliveryStatus.IsActive = true;
            }
        }


        private void orderControl_Click(object sender, EventArgs e)
        {
            var orControl = sender as OnlineOrderControl;
            if (orControl == null) return;
            var order = orControl.OrderEditViewModel;
            if (order == null) return;

            var viewDialog = new ViewOrderDetailDialog();
            viewDialog.OrderChanged += delegate { this.LoadItems(); };//Update lai giao dien khi OrderEditViewModel thay doi trang thai
            viewDialog.LoadOrder(order);
            viewDialog.ShowDialog();
        }

        public void RefreshOrderList()
        {
            #region Check Status Selected

            int type = -1;

            if (btnAssignedDeliveryStatus.IsActive)
            {
                type = (int)DeliveryStatusEnum.Assigned;
            }
            else if (btnAcceptedDeliveryStatus.IsActive)
            {
                type = (int)DeliveryStatusEnum.PosAccepted;
            }
            else if (btnRejectedDeliveryStatus.IsActive)
            {
                type = (int)DeliveryStatusEnum.PosRejected;
            }
            else
            {
                //Do nothing
            }

            List<OrderEditViewModel> list;

            if (type == -1)
            {
                list = _orderList.OrderByDescending(a => a.CheckInDate).ToList();
            }
            else
            {
                int type2 = type;
                if (type == (int)DeliveryStatusEnum.PosAccepted)
                {
                    type = (int)DeliveryStatusEnum.Finish;
                }
                else if (type == (int)DeliveryStatusEnum.PosRejected)
                {
                    type = (int)DeliveryStatusEnum.PreCancel;
                    type2 = (int)DeliveryStatusEnum.Cancel;
                }
                list = _orderList
                    .Where(a => a.DeliveryStatus == type || a.DeliveryStatus == type2)
                    .OrderByDescending(a => a.CheckInDate).ToList();
            }

            #endregion

            #region Update Page

            int pageSize = column * row;
            totalPage = (int)Math.Ceiling(((double)list.Count) / pageSize);

            lblPage.Text = (currentPage + 1).ToString();
            lblTotalPage.Text = "/" + totalPage;

            if (totalPage <= 1)
            {
                pnlPaging.Visible = false;
            }
            else
            {
                pnlPaging.Visible = true;
            }

            int currentPageSize = (currentPage == totalPage - 1) ? (list.Count - currentPage * pageSize) : pageSize;

            orderContainerInner.Controls.Clear();
            foreach (Control c in this.orderContainerInner.Controls)
            {
                c.Dispose();
            }

            foreach (var order in list.Skip(pageSize * currentPage).Take(currentPageSize))
            {
                var borderColor = GetOrderItemColor((OrderTypeEnum)order.OrderType);
                var statusColor = GetOrderStatusColor((DeliveryStatusEnum)order.DeliveryStatus);

                var orderControl = new OnlineOrderControl(borderColor, statusColor, order);

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

        private void txtDate_Click(object sender, EventArgs e)
        {
            using (var mbox = new DateSelectDialog(DateTime.Now))
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

        private void btnPageBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnPageBack.Image = Resources.arrow_g_u;
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

        private void btnPageNext_MouseUp(object sender, MouseEventArgs e)
        {
            btnPageNext.Image = Resources.arrow_g_d;
        }

        private void btnPageNext_MouseDown(object sender, MouseEventArgs e)
        {
            btnPageNext.Image = Resources.arrow_w_d;
            if (currentPage < totalPage - 1)
            {
                currentPage++;
                LoadItems();
            }
        }
    }
}
