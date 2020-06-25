using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using log4net;
using POS.CustomControl;
using POS.SaleScreen;
using POS.Repository;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ViewModels;
using POS.Properties;
using POS.Utils;

namespace POS.DashboardScreen
{
    public partial class KitchenScreen : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        int column = 4;
        int row = 4;
        int pageSize = 3;

        private int currentPage = 0;
        private int totalPage = 0;

        /// <summary>
        /// List order hiển thị trong current page
        /// </summary>
        private List<OrderEditViewModel> _orderList; // list OrderEditViewModel in current Page

        /// <summary>
        /// Tất cả order processing
        /// </summary>
        private List<OrderEditViewModel> _totalOrderList; // list all OrderEditViewModel in process or new
        private List<TableViewModel> _tables;

        private Thread AutoReLoadThread;

        public DateTime SelectedDate { get; set; }

        public KitchenScreen()
        {
            InitializeComponent();

            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.lineGreen.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            MainForm.SetLogo( ptbLogo, "./Resources/" + MainForm.StoreInfo.LogoSimple);
            //this.ptbLogo.ImageLocation = "./Resources/" + MainForm.StoreInfo.LogoSimple;

            //this.ptbLogo.SizeMode = PictureBoxSizeMode.CenterImage;

            if (MainForm.StoreInfo.ComputerScreenResolution.Trim().ToLower() == "mhd")
            {
                pageSize = 3;
            }
            else if (MainForm.StoreInfo.ComputerScreenResolution.Trim().ToLower() == "hd")
            {
                pageSize = 4;
            }
            else if (MainForm.StoreInfo.ComputerScreenResolution.Trim().ToLower() == "fhd")
            {
                pageSize = 5;
            }

            SelectedDate = UtcDateTime.Now().Date;

            LoadItems();

            //btnAutoRefresh.IsActive = true;
        }

        public void LoadItems()
        {
            OrderService orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
            var orders = orderService.GetAllProcessingOrder();

            _totalOrderList = ServiceManager.GetOrderEditViewModels(orders);
            _orderList = _totalOrderList.Skip(currentPage * pageSize).Take(pageSize).ToList();

            var count = _totalOrderList.Count;
            totalPage = count / pageSize;
            if (count % pageSize != 0) { totalPage++; }
            lblTotalPage.Text = "/" + totalPage;

            RefreshOrderList();
        }

        public void SaveOrder(OrderEditViewModel orderEditViewModel)
        {
            OrderService orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));

            orderService.UpdateOrder(orderEditViewModel);
        }

        //private Color GetOrderItemColor(OrderTypeEnum orderType)
        //{
        //    switch (orderType)
        //    {
        //        case OrderTypeEnum.AtStore:
        //            return Color.FromArgb(223, 168, 23);
        //        case OrderTypeEnum.TakeAway:
        //            return Color.FromArgb(146, 3, 205);
        //        case OrderTypeEnum.Delivery:
        //            return Color.FromArgb(124, 124, 124);
        //    }
        //    return Color.Empty;
        //}



        //private void orderControl_Click(object sender, EventArgs e)
        //{
        //    // CommunicationBridge.PlayClickSound();
        //    var orControl = sender as ReviewOrderControl;
        //    if (orControl == null) return;
        //    var OrderEditViewModel = orControl.OrderEditViewModel;
        //    if (OrderEditViewModel == null) return;

        //    var viewDialog = new OrderDetailDialog();
        //    viewDialog.OrderChanged += delegate { this.LoadItems(); };
        //    viewDialog.LoadOrder(order);
        //    viewDialog.ShowDialog();
        //}

        private void RefreshOrderList()
        {
            try
            {
                lblPage.Text = (currentPage + 1).ToString();

                _tables = Program.MainForm._tablePanel.GetCurrentTables();

                foreach (Control control in orderContainerOuter.Controls)
                {
                    control.Dispose();
                }
                orderContainerOuter.Controls.Clear();

                int count = 0;
                foreach (var orderEditViewModel in _orderList)
                {
                    var tableViewModel = _tables.FirstOrDefault(t => t.Id == orderEditViewModel.TableId);
                    if (tableViewModel != null)
                    {
                        orderEditViewModel.TableNumber = tableViewModel.Number;
                    }

                    orderEditViewModel.UpdateDateAfterLoad();

                    int width = 324;
                    KitchenOrderPanel kitchenOrderPanel = new KitchenOrderPanel()
                    {
                        Anchor = ((System.Windows.Forms.AnchorStyles)
                                ((((System.Windows.Forms.AnchorStyles.Top 
                                    | System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left))))),
                        BackColor = System.Drawing.Color.Gray,
                        Name = "kitchenOrderPanel" + count + 1,
                        OrderEditViewModel = null,
                        TabIndex = count,
                        Size = new Size(width, this.orderContainerOuter.Height - 5),
                        Location = new Point(((width + 5) * count), 2),
                        //Padding = new Padding(5,0,0,0)
                    };

                    this.orderContainerOuter.Controls.Add(kitchenOrderPanel);
                    kitchenOrderPanel.UpdateOrder(orderEditViewModel);
                    kitchenOrderPanel.SaveKitchenOrderItemListEvent += (saveOrder) =>
                    {
                        SaveOrder(saveOrder);
                    };
                    count++;
                }
            }
            catch (Exception ex)
            {
                log.Error("RefreshOrderList - " + ex);
            }
        }

        public bool isStartAutoReload = false;
        public void StartAutoReLoad()
        {
            isStartAutoReload = true;
            AutoReLoadThread = new Thread(AutoReLoadItems);
            AutoReLoadThread.Start();
        }

        private void AutoReLoadItems()
        {
            try
            {
                Thread.Sleep(15000);

                OrderService orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));

                var newOrderList = ServiceManager.GetOrderEditViewModels(orderService.GetAllProcessingOrder().ToList());
                var lastOrder = _orderList.FirstOrDefault();
                var lastNewOrder = newOrderList.FirstOrDefault();

                var totalOrderDetails = _totalOrderList.Sum(
                    order => order.OrderDetailEditViewModels.Count(
                        orderDetail => orderDetail.Status == (int)OrderDetailStatusEnum.New 
                        || orderDetail.Status == (int)OrderDetailStatusEnum.Processing));

                var totalNewOrderDetails = newOrderList.Sum(
                    order => order.OrderDetailEditViewModels.Count(
                        orderDetail => orderDetail.Status == (int)OrderDetailStatusEnum.New 
                        || orderDetail.Status == (int)OrderDetailStatusEnum.Processing));

                bool isLoad = false;
                if (lastNewOrder != null)
                {
                    if (lastOrder != null)
                    {
                        if ((_totalOrderList.Count != newOrderList.Count
                             || lastOrder.OrderId != lastNewOrder.OrderId
                             || totalOrderDetails != totalNewOrderDetails))
                        {
                            isLoad = true;
                        }
                    }
                    else if (newOrderList.Count > 0)
                    {
                        isLoad = true;
                    }

                    if (isLoad)
                    {
                        if (MainForm.PosConfig.EnableAutoRefreshKitchenScreen.Trim().ToLower() == "true")
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.LoadItems();
                            });
                        }
                        else
                        {
                            this.btnRefresh.BackgroudBootstrapColor = BootstrapColorEnum.Danger;
                            //btnRefresh.TextValue = "Làm mới !!!";    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("AutoReLoadItems - " + ex);
            }
            finally
            {
                if (isStartAutoReload)
                {
                    AutoReLoadItems();
                }
            }
        }

        private void btnBack_MouseDown(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = Color.DimGray;
        }

        private void btnBack_MouseUp(object sender, MouseEventArgs e)
        {
            btnBack.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            isStartAutoReload = false;
            //Program.MainForm.Logout();
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.btnRefresh.BackgroudBootstrapColor = BootstrapColorEnum.MainColor;
            //btnRefresh.TextValue = "Làm mới";
            LoadItems();
        }

        private List<OrderDetailEditViewModel> GetProcessingOrderDetailAscendingTime(OrderEditViewModel order)
        {
            return order.OrderDetailEditViewModels.Where(od => od.Status == (int)OrderDetailStatusEnum.Processing).OrderBy(od => od.OrderDate).ToList();
        }

    }
}
