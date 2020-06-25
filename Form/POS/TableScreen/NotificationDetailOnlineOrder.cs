using System;
using System.Windows.Forms;

using PointOfSale.Interface2;
using POS.Common;
using POS.Service.OrderService;
using POSSql.Data;

namespace POS.TableScreen
{
    public partial class NotificationDetailOnlineOrder : UserControl
    {
        OrderService orderService = new OrderService();
        public NotificationDetailOnlineOrder()
        {
            InitializeComponent();
        }

        private Order _currentOrder;
        public void LoadNotification(Notification notification)
        {
          
            var order = orderService.GetOrderById((int) notification.Tag);

            if (order != null)
            {
                lblTitle.Text = @"ONLINE ORDER #" + order.OrderCode;
                lblCustomerName.Text = order.DeliveryCustomer;
                lblDeliveryAddress.Text = order.DeliveryAddress;
                lblNote.Text = order.Notes;
                lblPhone.Text = order.DeliveryPhone;
                lblEstimate.Text = notification.IsReaded
                    ? "--:--"
                    : (DateTime.Now - notification.CreateTime).ToString(@"mm\:ss");
                if (order.DeliveryStatus == (int)DeliveryStatus.PosAccepted ||
                    order.DeliveryStatus == (int)DeliveryStatus.PosRejected)
                {
                    btnAccept.Visible = false;
                    btnReject.Visible = false;
                }
                else
                {
                    btnAccept.Visible = true;
                    btnReject.Visible = true;
                }
                lblStatus.Text = order.OrderStatus.ToString();
                _currentOrder = order;
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            _currentOrder.OrderStatus = (int) OrderStatusEnum.Processing;
            _currentOrder.DeliveryStatus = (int) DeliveryStatus.PosAccepted;
            //Call API
            orderService.SaveOrder();



            Program.MainForm.LoadSaleScreen(_currentOrder,OrderTypeEnum.Delivery, null);
        }

    
        

        private void btnReject_Click(object sender, EventArgs e)
        {
            var rs = PosMessageDialog.ConfirmMessage("Do you want to reject this order?","Yes","No");
            if (rs)
            {
                _currentOrder.OrderStatus = (int) OrderStatusEnum.PosPreCancel;
                _currentOrder.DeliveryStatus= (int)DeliveryStatus.PosRejected;
                orderService.SaveOrder();
                //Disable Reload
                btnAccept.Visible = false;
                btnReject.Visible = false;
            }

           
        }
    }
}
