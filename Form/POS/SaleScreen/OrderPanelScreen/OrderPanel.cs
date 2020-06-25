using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using System.Drawing.Drawing2D;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.SaleScreen.CustomControl;

namespace POS.SaleScreen
{
    public partial class OrderPanel : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        public const int TopLine = 59;
        public const int DeliverButtonRadius = 20;
        public const int TableButtonRadius = 29;
        public const int Bottom = 290;
        public const int Radius = 4;
        public const int Center = 57;
        public const int PaymentButtonHeight = 42;
        public const int PaymentButtonWidth = 180;
        public const int MarginLeft = 6;
        public const int ExchangeMarginBottom = 82;
        public const int ReceivedTextBoxHeight = 35;
        public const int OrderTotalPanelHeight = 100;


        public OrderPanel()
        {
            try
            {
                //Width = 500;
                //BackColor = Color.Red;
                //Height = PaymentButtonHeight
                //         + ExchangeMarginBottom
                //         + 200;

                InitializeComponent();
                pnlItemList.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
                //                pnlItemList.BackColor = Constant.Yellow;
                pnlSummary.BackColor = Constant.Brown;

                lblTable.Paint += DrawControlLibrary.OrderPanel.DrawTableButton;
                lblDelivery.Paint += DrawControlLibrary.OrderPanel.DrawTypeToggleButton;
                lblTakeAway.Paint += DrawControlLibrary.OrderPanel.DrawTypeToggleButton;
                lblPayment.Paint += DrawControlLibrary.OrderPanel.DrawPaymentButton;
                lblCancel.Paint += DrawControlLibrary.OrderPanel.DrawCancelButton;

                lblPayment.Click += lblPayment_Click;
                lblCancel.Click += lblCancel_Click;

                GenerateLayout();

                //orderPropertyPanel = new OrderPropetyPanel();

                //currentOrderManager.NotifyChangeOrderDetail += CurrentOrderManager_NotifyChangeOrderDetail;

                pnlItemList.UpdateOrderItemListEvent += SaleScreen3.UpdateOrderDetailForm;
                pnlItemList.OrderItemClickEvent += (orderDetails) =>
                    {
                        SaleScreen3.ShowOrderDetailForm(orderDetails);
                    };
                //pnlItemList.OrderItemClickEvent =OrderItemClicked;

                //lblReceived.Click += lblReceived_Click;
            }
            catch (Exception ex)
            {
                log.Error("OrderPanel - " + ex);
            }

        }

        void lblCancel_Click(object sender, EventArgs e)
        {
            var isSaveTableStatus = MainForm.PosConfig.SaveTableStatus.Trim().ToLower() == "true";
            SaleScreen3.ExitOrCancelOrder(isSaveTableStatus);
        }

        private void GenerateLayout()
        {
            lblPayment.Tag = MainForm.ResManager.GetString("Sys_Payment", MainForm.CultureInfo);
        }

            //void CurrentOrderManager_NotifyChangeOrderDetail(OrderDetailViewModel arg1, OrderDetailChangeModeEnum arg2)
            //{
            //    try
            //    {
            //        var totalPayment = currentOrderManager.getOrderEditViewModel().TotalPayment;

            //        //TODO:
            //        //lblReceived.Text = totalPayment.ToString("N0");
            //        //lblExchange.Text = (totalPayment - currentOrderManager.getOrderEditViewModel().FinalAmount).ToString("N0");
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error("CurrentOrderManager_NotifyChangeOrderDetail - " + ex);
            //    }
            //}


        /// <summary>
        /// Cập nhật lại giao diện OrderPanelItemList & Summary
        /// </summary>
        public void UpdateWhenOrderDetailChange(OrderDetailViewModel orderDetail, OrderDetailChangeModeEnum mode)
        {
            try
            {
                //Cập nhật lại giao diện OrderPanelItemList
                if (mode == OrderDetailChangeModeEnum.ModifiedOrderDetail
                    || mode == OrderDetailChangeModeEnum.UpdateOrderDetailInfo)
                {
                    //Modify & Update
                    pnlItemList.ModifyLayout();
                }
                else
                {
                    //Add & Remove
                    pnlItemList.RenderLayoutFromOrder();
                }

                //Cập nhật lại Summary
                UpdateSummary();
            }
            catch (Exception ex)
            {
                log.Error("UpdateWhenOrderDetailChange - " + ex);
            }
        }

        private void OrderChanged(OrderEditViewModel order)
        {
            try
            {
                if (order.OrderType == (int)OrderTypeEnum.Delivery)
                {
                    lblDelivery.TabIndex = 0;
                    lblTakeAway.TabIndex = 1;
                    //lblServType.Text = @"Delivery";
                }
                else if (order.OrderType == (int)OrderTypeEnum.TakeAway)
                {
                    lblTakeAway.TabIndex = 0;
                    lblDelivery.TabIndex = 1;
                    //lblServType.Text = @"Take Away";
                }
                else
                {
                    lblTakeAway.TabIndex = 1;
                    lblDelivery.TabIndex = 1;
                    //lblServType.Text = @"At Store";
                }
                lblDelivery.Invalidate();
                lblTakeAway.Invalidate();
            }
            catch (Exception ex)
            {
                log.Error("OrderChanged - " + ex);
            }
        }

        public string TableNo
        {
            get
            {
                return lblTable != null ? lblTable.Text : "";
            }
            set
            {
                if (lblTable != null)
                {
                    lblTable.Text = value;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (lblTable != null)
            {
                lblTable.Left = Width / 2 - 30;
                lblTakeAway.Left = Width - 45;
            }

            Invalidate();

        }

        private void UpdateSummary()
        {
            //currentOrderManager.UpdateDiscountOrder();// Calculate before update.
            lblTotalProduct.Text = currentOrderManager.GetTotalProduct().ToString("N0");
            lblTotalAmount.Text = currentOrderManager.getOrderEditViewModel().FinalAmount.ToString("N0");

        }

        public void DisplayOrder()
        {
            try
            {
                pnlItemList.GenerateOrderPanelItemList(currentOrderManager.getOrderEditViewModel());

                //Cap nhat lai Summary
                UpdateSummary();
            }
            catch (Exception ex)
            {
                log.Error("DisplayOrder - " + ex);
            }


        }

        private bool _isBillCookPrinted = false;

        private void lblPayment_Click(object sender, EventArgs e)
        {
            //if (MainForm.StoreInfo.IsPrintBillCookBeforePayment.Trim().ToLower() == "true" 
            //        && !_isBillCookPrinted)
            //{
            //    SaleScreen3.PosPrinter.PrintBillForCook(currentOrderManager.getOrderEditViewModel(), true);
            //    _isBillCookPrinted = true;
            //}

            SaleScreen3.ShowOrderPropertyForm();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var path = DrawUtility.DrawSmoothEdgeRectangle(0, 4, Width, Height - 5, 4, 0, 4,
                0);
            pe.Graphics.FillPath(new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), path);
            pe.Graphics.DrawPath(new Pen(Constant.White, 1), path);

            path = new GraphicsPath();
            path.AddLine(6 + 20 * 2, 60, Width / 2 - 30, 60);
            pe.Graphics.FillPath(new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), path);
            pe.Graphics.DrawPath(new Pen(Constant.Brown, 2), path);
            path = new GraphicsPath();
            path.AddLine(Width - 6 - 20 * 2, 60, Width / 2 + 30, 60);
            pe.Graphics.FillPath(new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), path);
            pe.Graphics.DrawPath(new Pen(Constant.Brown, 2), path);

            var font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 12, FontStyle.Regular);
            var format = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };


        }

        public void ResetPanelSummary()
        {
            lblTotalAmount.Text = "0";
            lblTotalProduct.Text = "0";
        }

        private void OrderPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
