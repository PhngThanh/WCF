using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.SaleScreen.CustomControl;

namespace POS.SaleScreen
{
    public partial class OrderPanelItemList : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static int firstHeight { get; set; }


        public OrderEditViewModel OrderEditViewModel { get; set; }

        public Action UpdateOrderItemListEvent;
        public Action<List<OrderDetailEditViewModel>> OrderItemClickEvent;

        public OrderPanelItemList()
        {
            InitializeComponent();
            GenerateLayout();
        }

        private void GenerateLayout()
        {
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

            lblUp.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;
            lblDown.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;
            lblUp.Click += lblUp_Click;
            lblDown.Click += lblDown_Click;
            lblUp.Enabled = pnlItemContainer.Height > Height;
            lblDown.Enabled = pnlItemContainer.Top < 0;
            SizeChanged += ChangeSize;
            pnlItemContainer.SizeChanged += ChangeSize;
        }

        public void GenerateOrderPanelItemList(OrderEditViewModel order)
        {
            OrderEditViewModel = order;

            ReSize();

            RenderLayoutFromOrder();
        }


        // Reset paging in item list for new order
        public void ReSize()
        {
            try
            {
                pnlItemContainer.Top = 0;
                pnlItemContainer.Height = 0;
                ClearItems();
            }
            catch (Exception ex)
            {
                log.Error("ReSize - " + ex);
            }
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            try
            {
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
                //pnlPaging.Visible = pnlItemContainer.Height > Height;
            }
            catch (Exception ex)
            {
                log.Error("ChangeSize - " + ex);
            }

        }

        #region Navigation

        // Di chuyển list lên - show phần tử nằm sau / dưới
        private void lblUp_Click(object sender, EventArgs e)
        {
            try
            {
                pnlItemContainer.Top -= DrawControlLibrary.OrderPanel.OrderItemList.OrderItemHeight;
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
            }
            catch (Exception ex)
            {
                log.Error("lblUp_Click - " + ex);
            }
        }

        // Di chuyển list xuống - show phần tử nằm trước / trên
        private void lblDown_Click(object sender, EventArgs e)
        {
            try
            {
                pnlItemContainer.Top += DrawControlLibrary.OrderPanel.OrderItemList.OrderItemHeight;
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
            }
            catch (Exception ex)
            {
                log.Error("lblDown_Click - " + ex);
            }

        }

        public void CheckPaging()
        {
            try
            {
                if (pnlItemContainer.Height > Height)
                {
                    if (!pnlPaging.Visible)
                    {
                        pnlPaging.Visible = true;                   //show paging
                        pnlItemContainer.Top -= pnlPaging.Height;   //move list up
                    }
                }
                else
                {
                    pnlPaging.Visible = false;  //hide paging
                    pnlItemContainer.Top = 0;   //move to top
                }

                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
            }
            catch (Exception ex)
            {
                log.Error("CheckPaging - " + ex);
            }
        }

        #endregion

        private void OrderItem_Click(object sender, EventArgs e)
        {
            var control = (OrderItemControl)sender;
            var orderDetails = control.OrderItems;

            DeactiveAllControls();
            control.IsActive = true;

            //var mainOrderDetail = orderDetails.FirstOrDefault(od => od.ParentId == null);
            if (OrderItemClickEvent != null)
            {
                OrderItemClickEvent(orderDetails);
            }
        }


        /// <summary>
        /// Update UI (Add / Remove)
        /// </summary>
        /// <param name="isCheckSplitState">If TRUE: not draw OrderDetailViewModel SplitState = Moved</param>
        /// <param name="showOptions"></param>
        public void RenderLayoutFromOrder(bool isCheckSplitState = false, List<OrderDetailStatusEnum> showOptions = null)
        {
            try
            {
                bool sorted = true;

                List<List<OrderDetailEditViewModel>> newOrderDetailsSorted = GetAvailableOrderDetails(sorted, isCheckSplitState, showOptions);         // new control list
                List<List<OrderDetailEditViewModel>> oldOrderDetailsSorted = GetDrawedOrderItemControl(sorted);  // old control list

                var tmpNODs = GetAvailableOrderDetails(!sorted, isCheckSplitState, showOptions);
                var tmpOODs = GetDrawedOrderItemControl(!sorted);

                List<OrderDetailEditViewModel> newOrderDetails = tmpNODs != null ?
                                                            tmpNODs.FirstOrDefault() : null;
                List<OrderDetailEditViewModel> oldOrderDetails = tmpOODs != null ?
                                                            tmpOODs.FirstOrDefault() : null;

                #region Add Control
                // So sánh NEW control list & OLD control list
                // Nếu không tồn tại trong old control list
                // -> add

                var addList = new List<List<OrderDetailEditViewModel>>();

                // Tạo add list
                if (oldOrderDetails != null
                    && newOrderDetailsSorted != null
                    && newOrderDetailsSorted.Count > 0)
                {
                    foreach (List<OrderDetailEditViewModel> items in newOrderDetailsSorted)
                    {
                        var mainItem = items.FirstOrDefault();
                        var tmpOd = oldOrderDetails.Where(od => od.OrderDetailID == mainItem.OrderDetailID).FirstOrDefault();
                        if (tmpOd == null)
                        {
                            addList.Add(items);
                        }
                    }
                }

                if (addList.Count > 0)
                {
                    foreach (List<OrderDetailEditViewModel> items in addList)
                    {
                        var label = new OrderItemControl(items);
                        label.Width = pnlItemContainer.Width;
                        label.Click += OrderItem_Click;

                        //Set active cho item mới vừa add
                        DeactiveAllControls();
                        label.IsActive = true;

                        pnlItemContainer.Controls.Add(label);

                        //Load đến vị trí cuối cùng trong list
                        if (pnlItemContainer.Height > Height)
                        {
                            pnlItemContainer.Top -= label.Height;
                        }
                    }
                }
                #endregion

                #region Remove Control
                // So sanh OLD control list & NEW control list
                // Nếu không tồn tại trong new control list
                // -> Remove

                var removeList = new List<List<OrderDetailEditViewModel>>();

                // Tạo remove list
                if (newOrderDetails != null
                    && oldOrderDetailsSorted != null
                    && oldOrderDetailsSorted.Count > 0)
                {
                    foreach (List<OrderDetailEditViewModel> items in oldOrderDetailsSorted)
                    {
                        var mainItem = items.FirstOrDefault();
                        var tmpOd = newOrderDetails.Where(od => od.OrderDetailID == mainItem.OrderDetailID).FirstOrDefault();
                        if (tmpOd == null)
                        {
                            removeList.Add(items);
                        }
                    }
                }

                // remove control có trong remove list
                if (removeList.Count > 0)
                {
                    foreach (List<OrderDetailEditViewModel> items in removeList)
                    {
                        var mainItem = items.FirstOrDefault();

                        foreach (OrderItemControl control in pnlItemContainer.Controls)
                        {
                            if (control.OrderItems.Any(oi => oi.OrderDetailID == mainItem.OrderDetailID))
                            {
                                pnlItemContainer.Controls.Remove(control);

                                //Giảm chiều cao của list
                                pnlItemContainer.Height = pnlItemContainer.Height - control.Height;

                                if ((pnlItemContainer.Top * -1) > (pnlItemContainer.Height / 2))
                                {
                                    //Nếu đang xem phần dưới của list
                                    //Di chuyển list xuống 
                                    pnlItemContainer.Top += control.Height;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region Modify Control
                //Hiện không check được quantity thay đổi(main item và old main item)
                //->modify control active

                //if (newOrderDetailsSorted.Count > 0 && newOrderDetails != null)
                //{
                //    foreach (List<OrderDetailEditViewModel> items in newOrderDetailsSorted)
                //    {
                //        var mainItem = items.FirstOrDefault();

                //        List<OrderDetailEditViewModel> oldItems = null;
                //        OrderItemControl control = null;

                //        // Tìm control có main item
                //        foreach (var itm in pnlItemContainer.Controls.Cast<OrderItemControl>())
                //        {
                //            List<OrderDetailEditViewModel> orderDetails = itm.OrderItems;
                //            var tmpOd = orderDetails.FirstOrDefault();
                //            if (tmpOd.OrderDetailID == mainItem.OrderDetailID)
                //            {
                //                oldItems = orderDetails;
                //                control = itm;
                //            }
                //        }

                //        if (oldItems != null)
                //        {
                //            if (control.IsActive)
                //            {
                //                control.OrderItems = items;//Cap nhat danh sach moi
                //                control.RenewUi();

                //                if (UpdateOrderItemListEvent != null)
                //                {
                //                    UpdateOrderItemListEvent();
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion

                CheckPaging();
            }
            catch (Exception ex)
            {
                log.Error("RenderLayoutFromOrder - " + ex);
            }
        }

        /// <summary>
        /// Update UI (Modify / Update)
        /// </summary>
        /// <param name="isCheckSplitState">If TRUE: not draw OrderDetailViewModel SplitState = Moved</param>
        /// <param name="showOptions"></param>
        public void ModifyLayout(bool isCheckSplitState = false, List<OrderDetailStatusEnum> showOptions = null)
        {
            bool sorted = true;

            List<List<OrderDetailEditViewModel>> newOrderDetailsSorted = GetAvailableOrderDetails(sorted, isCheckSplitState, showOptions);         // new control list

            var tmpList = GetAvailableOrderDetails(!sorted, isCheckSplitState, showOptions);
            List<OrderDetailEditViewModel> newOrderDetails = tmpList != null ?
                                                    tmpList.FirstOrDefault() : null;

            #region Modify Control
            //Hiện không check được quantity thay đổi(main item và old main item)
            //->modify control active

            if (newOrderDetails != null
                && newOrderDetailsSorted != null
                && newOrderDetailsSorted.Count > 0)
            {
                foreach (List<OrderDetailEditViewModel> items in newOrderDetailsSorted)
                {
                    var mainItem = items.FirstOrDefault();

                    List<OrderDetailEditViewModel> oldItems = null;
                    OrderItemControl control = null;

                    // Tìm control có main item
                    foreach (var itm in pnlItemContainer.Controls.Cast<OrderItemControl>())
                    {
                        List<OrderDetailEditViewModel> orderDetails = itm.OrderItems;
                        var tmpOd = orderDetails.FirstOrDefault();
                        if (tmpOd != null && tmpOd.OrderDetailID == mainItem.OrderDetailID)
                        {
                            oldItems = orderDetails;
                            control = itm;
                        }
                    }

                    if (oldItems != null)
                    {
                        control.OrderItems = items;//Cap nhat danh sach moi
                        control.RenewUi();

                        if (UpdateOrderItemListEvent != null)
                        {
                            UpdateOrderItemListEvent();
                        }
                    }
                }
            }
            #endregion

            CheckPaging();
        }

        /// <summary>
        /// Return drawed OrderDetails 
        /// </summary>
        /// <param name="isSorted"></param>
        /// <returns></returns>
        private List<List<OrderDetailEditViewModel>> GetDrawedOrderItemControl(bool isSorted)
        {
            var rsList = new List<List<OrderDetailEditViewModel>>();
            var rs = new List<OrderDetailEditViewModel>();
            foreach (var itm in pnlItemContainer.Controls.Cast<OrderItemControl>())
            {
                List<OrderDetailEditViewModel> orderDetails = itm.OrderItems;
                rsList.Add(orderDetails);
                rs.AddRange(orderDetails);
            }

            if (isSorted)
            {
                return rsList;
            }
            else
            {
                return new List<List<OrderDetailEditViewModel>> { rs };
            }
        }


        /// <summary>
        /// Return available OrderDetails of current OrderEditViewModel 
        /// </summary>
        /// <param name="isSorted"></param>
        /// <param name="isCheckSplitState">If TRUE: not draw OrderDetailViewModel SplitState = Moved</param>
        /// <returns></returns>
        public List<List<OrderDetailEditViewModel>> GetAvailableOrderDetails(bool isSorted, bool isCheckSplitState, List<OrderDetailStatusEnum> showOptions)
        {
            if (OrderEditViewModel != null)
            {
                List<OrderDetailEditViewModel> orderDetails = new List<OrderDetailEditViewModel>();

                if (showOptions == null)
                {
                    showOptions = new List<OrderDetailStatusEnum>
                    {
                        OrderDetailStatusEnum.New,
                        OrderDetailStatusEnum.Processing,
                        OrderDetailStatusEnum.PosFinished,
                        OrderDetailStatusEnum.Finish,
                        OrderDetailStatusEnum.PosCancel,
                        OrderDetailStatusEnum.Cancel,

                    };
                }

                foreach (var option in showOptions)
                {
                    var tmpList = OrderEditViewModel.OrderDetailEditViewModels.Where(od => od.Status == (int)option).ToList();
                    orderDetails.AddRange(tmpList);
                }

                if (isCheckSplitState)
                {
                    orderDetails = orderDetails.Where(od => od.SplitState != (int)SplitOrderDetailStateEnum.Moved).ToList();
                }

                if (!isSorted)
                {
                    return new List<List<OrderDetailEditViewModel>> { orderDetails };
                }
                else
                {
                    List<List<OrderDetailEditViewModel>> orList = new List<List<OrderDetailEditViewModel>>();

                    //duyet qua danh sach cac OrderDetailViewModel de tao danh sach OrderDetailViewModel moi
                    //Gom nhom cac OrderDetailViewModel theo mainitem và cac extra di kem
                    //Moi nhom la 1 List tuong ung 1 elment cua orList
                    if (orderDetails != null && orderDetails.Count > 0)
                    {
                        // Get all main OrderEditViewModel details
                        foreach (var orderDetail in orderDetails)
                        {
                            //orderDetail.ProductViewModel =
                            //    Program.context.getAllProducts().FirstOrDefault(p => p.ProductId == orderDetail.ProductId);
                            //Change product Id -> product Code
                            orderDetail.ProductViewModel =
                                Program.context.getAllProducts().FirstOrDefault(p => p.Code == orderDetail.ProductCode);
                            if (orderDetail.ParentId == null)
                            {
                                //main item => add to orlist
                                List<OrderDetailEditViewModel> mainItemList = new List<OrderDetailEditViewModel>();
                                mainItemList.Add(orderDetail);
                                orList.Add(mainItemList);
                            }
                        }

                        // Get all extra 
                        foreach (var orderDetail in orderDetails)
                        {
                            if (orderDetail.ParentId != null)
                            {
                                //extra orderitem => find mainitem => add to sub-list
                                foreach (var or in orList)
                                {
                                    if (or[0].OrderDetailID == orderDetail.ParentId)
                                    {
                                        or.Add(orderDetail);
                                    }
                                }
                            }
                        }
                    }

                    return orList;
                }
            }
            return null;
        }


        public void ClearItems()
        {
            pnlItemContainer.Controls.Clear();
            foreach (Control c in this.pnlItemContainer.Controls)
            {
                c.Dispose();
            }

            CheckPaging();
        }

        public void DeactiveAllControls()
        {
            foreach (var itm in pnlItemContainer.Controls.Cast<OrderItemControl>().Where(itm => itm.IsActive))
            {
                itm.IsActive = false;
            }
        }
    }
}