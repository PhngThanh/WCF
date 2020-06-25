using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PointOfSale.Interface2;

namespace POS.TableScreen
{
    public partial class NotificationForm : Form
    {
        //private readonly List<Notification> _notifications = new List<Notification>();
        public NotificationForm()
        {
            InitializeComponent();
         
        }


        public int GenerateListNotifications(List<Notification> notifications)
        {
            notificationDetailOnlineOrder1.Visible = false;
            return notificationListControl1.GenerateListNotifications(notifications);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>Number of notification in list</returns>
        public int AddNotification(Notification notification)
        {
           return notificationListControl1.AddNotification(notification);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>Number of notification in list</returns>
        public int RemoveNotification(Notification notification)
        {
            return notificationListControl1.RemoveNotification(notification);
            
        }

        public void LoadNotificationDetail(Notification notification)
        {
            notificationDetailOnlineOrder1.LoadNotification(notification);
        }

       

       
    }
}
