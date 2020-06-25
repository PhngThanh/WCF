using System;
using System.Drawing;
using System.Windows.Forms;
using PointOfSale.Interface2;

namespace POS.TableScreen
{
    public partial class NotificationItemControl : UserControl
    {
        private Notification _notification;

        public NotificationItemControl()
        {
            InitializeComponent();
            Margin = new Padding(0, 0, 0, 2);
        }

        public Notification Notification
        {
            get { return _notification; }
            set
            {
                _notification = value;
                lblTitle.Text = _notification.Title;
                lblArriveTime.Text = _notification.CreateTime.ToString("dd/MM/yyyy HH:mm:ss");
                if (!_notification.IsReaded)
                {
                    lblEstimate.Text = (DateTime.Now - _notification.CreateTime).ToString(@"mm\:ss");
                }
                lblNewNotification.Visible = !_notification.IsReaded;
            }
        }


        private bool _active;

        public bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                BackColor = _active ? Color.FromArgb(80, 80, 80) : Color.FromArgb(49, 49, 49);
            }
        }

        public bool IsReaded
        {
            get { return !lblNewNotification.Visible; }
            set { lblNewNotification.Visible = !value; }
        }

        public string Title
        {
            get { return lblTitle.Text; }
        }

        protected override void OnClick(EventArgs e)
        {
            IsReaded = true;
            _notification.IsReaded = true;
            Active = !Active;
            base.OnClick(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            OnClick(e);//Goi ham cua Parent Control
        }

        private void lblArriveTime_Click(object sender, EventArgs e)
        {
            OnClick(e);//Goi ham cua Parent Control
        }

        private void lblEstimate_Click(object sender, EventArgs e)
        {
            OnClick(e);//Goi ham cua Parent Control
        }
    }
}
