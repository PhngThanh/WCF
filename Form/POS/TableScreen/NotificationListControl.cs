using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Interface2;

namespace POS.TableScreen
{
    public partial class NotificationListControl : UserControl
    {
         List<Notification> _notifications = new List<Notification>();
        private bool _expanded;

        //public event Action<NotificationListControl> ExpandChanged;
        //private readonly Action<Control> _showNotificationDetail;
        //private readonly NotifierBase _notifierBase;
        public NotificationListControl()
        {
            InitializeComponent();
            lblListCount.Text = @"0";
            pnlListInfo.Click += pnlListInfo_Click;
            Expanded = false;
        }

        public int AddNotification(Notification notification)
        {
                _notifications.Add(notification);
                var notificationControl = new NotificationItemControl
                {
                    Notification = notification
                };
                notificationControl.Click += notificationControl_Click;
                pnlListDetail.Controls.Add(notificationControl);
                pnlListDetail.Controls.SetChildIndex(notificationControl, 0);

                int count = _notifications.Count;
                lblListCount.Text = count.ToString();
               

            return count;

        }

        public int GenerateListNotifications(List<Notification> notifications)
        {
            _notifications = notifications;
            pnlListDetail.Controls.Clear();

            foreach (var notification in notifications)
            {
                var notificationControl = new NotificationItemControl
                {
                    Notification = notification
                };
                notificationControl.Click += notificationControl_Click;
                pnlListDetail.Controls.Add(notificationControl);
                pnlListDetail.Controls.SetChildIndex(notificationControl, 0);
            }
            int count = _notifications.Count;
            lblListCount.Text = count.ToString();
            return count;
        }

        public int RemoveNotification(Notification notification)
        {
                var ic = pnlListDetail.Controls.Cast<NotificationItemControl>()
                    .FirstOrDefault(a => a.Notification == notification);
                if (ic != null)
                {
                    pnlListDetail.Controls.Remove(ic);
                }
                _notifications.Remove(notification);
                int count = _notifications.Count;
                lblListCount.Text = count.ToString();
            return count;

        }

        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                //if (_expanded == value) return;
                //foreach (var ic in pnlListDetail.Controls.Cast<NotificationItemControl>())
                //{
                //    ic.Active = false;
                //}
                //_expanded = value;
                //if (!value)
                //{
                //    Height = pnlListInfo.Height;
                //}
                //else
                //{
                //    OnExpandChanged();
                //}
            }
        }

        private void pnlListInfo_Click(object sender, EventArgs e)
        {
            Expanded = true;
        }

        private void notificationControl_Click(object sender, EventArgs e)
        {
            var itemControl = (NotificationItemControl)sender;
            ((NotificationForm)this.Parent.Parent).LoadNotificationDetail(itemControl.Notification);
           
            foreach (var ic in pnlListDetail.Controls.Cast<NotificationItemControl>().Where(ic => ic != sender))
            {
                ic.Active = false;
            }
        }

        //protected virtual void OnExpandChanged()
        //{
        //    foreach (var control in Parent.Controls)
        //    {
        //        if (control != this)
        //        {
        //            var list = (NotificationListControl)control;
        //            list.Expanded = false;
        //        }
        //    }
        //    Height = Parent.Height - (Parent.Controls.Count - 1) * pnlListInfo.Height;
        //    var handler = ExpandChanged;
        //    if (handler != null) handler(this);
        //}
    }
}
