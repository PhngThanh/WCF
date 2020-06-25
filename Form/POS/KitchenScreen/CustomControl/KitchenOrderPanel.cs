using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using POS.Repository;
using POS.Repository.ViewModels;
using log4net;

namespace POS.SaleScreen
{

    public partial class KitchenOrderPanel : UserControl
    {

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public OrderEditViewModel OrderEditViewModel { get; set; }
        public bool IsDirty;

        public Action<OrderEditViewModel> SaveKitchenOrderItemListEvent;

        public KitchenOrderPanel()
        {
            InitializeComponent();
            GenerateLayout();

            IsDirty = false;
        }

        private void GenerateLayout()
        {
            btnShowAll.ActiveBackgroudColor = Color.Red;
            btnShowProcessing.ActiveBackgroudColor = Color.Red;
            btnSelectAll.ActiveBackgroudColor = Color.Red;
        }

        public void UpdateOrder(OrderEditViewModel orderEditViewModel = null)
        {
            if (orderEditViewModel != null)
            {
                IsDirty = false;
                
                btnShowProcessing.IsActive = true;
                btnShowAll.IsActive = false;
                btnSelectAll.IsActive = false;

                this.OrderEditViewModel = orderEditViewModel;
                pnlItemList.GenerateOrderPanelItemList(OrderEditViewModel);
            }

            var totalQuantity = OrderEditViewModel.OrderDetailEditViewModels.Where(
                od => od.Status != (int) OrderDetailStatusEnum.Cancel 
                    && od.Status != (int) OrderDetailStatusEnum.PreCancel 
                    && od.Status != (int) OrderDetailStatusEnum.PosPreCancel 
                    && od.Status != (int) OrderDetailStatusEnum.PosCancel).
                Sum(o => o.Quantity);

            var completeQuantity = OrderEditViewModel.OrderDetailEditViewModels.
                    Where(o => o.Status == (int)OrderDetailStatusEnum.Finish
                        || o.Status == (int)OrderDetailStatusEnum.PosFinished).
                    Sum(o => o.Quantity);

            lblQuantity.Text = completeQuantity + " / " + totalQuantity;

            lblTable.Text = "Bàn: " + OrderEditViewModel.TableNumber;
            lblTime.Text = OrderEditViewModel.CheckInDate.ToString("HH:mm");
            var orderType = "Tại quán";
            if (OrderEditViewModel.OrderType == (int)OrderTypeEnum.AtStore)
            {
                orderType = "Tại quán";
            }
            else if (OrderEditViewModel.OrderType == (int)OrderTypeEnum.Delivery)
            {
                orderType = "Giao hàng";
            }
            else if (OrderEditViewModel.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                orderType = "Mang đi";
            }

            lblOrderType.Text = orderType;
            UpdateOrderItemList();
        }

        public void UpdateOrderItemList()
        {
            var showOptions = new List<OrderDetailStatusEnum>()
                {
                    OrderDetailStatusEnum.Processing,
                };

            if (btnShowAll.IsActive)
            {
                showOptions.Add(OrderDetailStatusEnum.Finish);
                showOptions.Add(OrderDetailStatusEnum.PosFinished);
            }

            pnlItemList.RenderLayoutFromOrder(showOptions);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            btnShowAll.IsActive = true;

            UpdateOrderItemList();
        }

        private void btnShowProcessing_Click(object sender, EventArgs e)
        {
            btnShowProcessing.IsActive = true;

            UpdateOrderItemList();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (btnSelectAll.IsActive)
            {
                pnlItemList.ActiveAllControls();
                btnSelectAll.TextValue = "Bỏ chọn hết";
            }
            else
            {
                pnlItemList.DeactiveAllControls();
                btnSelectAll.TextValue = "Chọn hết";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IsDirty = true;
            btnSelectAll.IsActive = false;
            btnSelectAll.TextValue = "Chọn hết";

            var selectedList = pnlItemList.GetSelectedOrderDetails();

            foreach (var item in selectedList)
            {
                var orderDetailEditViewModels = OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == item.OrderDetailID);
                if (orderDetailEditViewModels != null)
                {
                    if (orderDetailEditViewModels.Status == (int)OrderDetailStatusEnum.Processing)
                    {
                        orderDetailEditViewModels.Status = (int)OrderDetailStatusEnum.PosFinished;
                    }
                }
            }


            var processingQty = OrderEditViewModel.OrderDetailEditViewModels
                .Where(od => od.Status == (int)OrderDetailStatusEnum.Processing)
                .Sum(o => o.Quantity);
            var totalQty = OrderEditViewModel.OrderDetailEditViewModels
                .Where(od => od.Status != (int)OrderDetailStatusEnum.Cancel
                    && od.Status != (int)OrderDetailStatusEnum.PreCancel
                    && od.Status != (int)OrderDetailStatusEnum.PosPreCancel
                    && od.Status != (int)OrderDetailStatusEnum.PosCancel)
                .Sum(o => o.Quantity);

            //In bill hoàn thành món
            //SaleScreen3.PosPrinter.PrintCooking(selectedList,
            //                                    OrderEditViewModel.OrderCode,
            //                                    OrderEditViewModel.TableNumber,
            //                                    MainForm.CurrentAccount.AccountId,
            //                                    OrderEditViewModel.Notes,
            //                                    processingQty,
            //                                    totalQty);

            // ???
            //Chuyển OrderEditViewModel status nếu tất cả OrderDetailViewModel đã được chuyển status
            var odProcessing = OrderEditViewModel.OrderDetailEditViewModels.Where(od => od.Status == (int)OrderDetailStatusEnum.Processing).FirstOrDefault();
            if (odProcessing == null)
            {
                OrderEditViewModel.OrderStatus = (int)OrderStatusEnum.PosFinished;
            }

            UpdateOrder();

            //Save 
            if (SaveKitchenOrderItemListEvent != null)
            {
                SaveKitchenOrderItemListEvent(OrderEditViewModel);
            }
        }
    }
}
