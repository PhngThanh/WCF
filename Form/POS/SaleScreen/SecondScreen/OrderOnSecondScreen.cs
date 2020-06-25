using log4net;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.SaleScreen.SecondScreen
{
    public partial class OrderOnSecondScreen : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();

        public OrderOnSecondScreen()
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
                Screen[] sc = Screen.AllScreens;
                this.Width = sc[1].Bounds.Width - 5;
                //width for orderlist = 3/10 of screen -5(border)

                //var panelItemsListWidth = ((this.Width / 10) * 4)- 5;
                //pnlItemList.Width = panelItemsListWidth;
                //var pictureBox1 = sc[1].Bounds.Width - panelItemsListWidth;

                //currentOrderManager.NotifyChangeOrderDetail += CurrentOrderManager_NotifyChangeOrderDetail;
                //lblReceived.Click += lblReceived_Click;
            }
            catch (Exception ex)
            {
                log.Error("OrderPanel - " + ex);
            }
        } 
            /// <summary>
            /// Cập nhật lại giao diện OrderPanelItemList & Summary
            /// </summary>
            public void UpdateWhenOrderDetailChange(OrderDetailViewModel orderDetail, OrderDetailChangeModeEnum mode)
            {
                try
                {
                DisplayOrder();
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



        public void ResetPanelSummary()
        {
            lblTotalAmount.Text = "0";
            lblTotalProduct.Text = "0";
        }
    }
}
