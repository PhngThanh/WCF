using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using POS.Utils;
using POS.Common;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.DashboardScreen.OnlineOrderScreen
{
    public partial class OnlineOrderControl : UserControl
    {
        private readonly Color _borderColor;
        private readonly Color _statusColor;
        private DateTime _orderTime;
        private string _orderId;
        private string _orderPerson;
        private string _phoneNumber;
        private int _totalAmount;

        public string OrderId
        {
            get { return _orderId; }
            set
            {
                _orderId = value;
                lbOrderId.Text = _orderId;
            }
        }

        public DateTime OrderTime
        {
            get { return _orderTime; }
            set
            {
                _orderTime = value;
                lbTime.Text = _orderTime.ToString("HH:mm dd/MM/yyyy");
            }
        }

        public string OrderPerson
        {
            get { return _orderPerson; }
            set
            {
                _orderPerson = value ?? "";
                lbPersonName.Text = _orderPerson.ToUpper();
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value ?? "";
                lbPhoneNumber.Text = _phoneNumber;
            }
        }

        public int TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                lbAmount.Text = _totalAmount.ToString();
            }
        }

        public OrderEditViewModel OrderEditViewModel { get; set; }

        public OnlineOrderControl(Color boderColor, Color statusColor, OrderEditViewModel order)
        {
            InitializeComponent();
            OrderEditViewModel = order;
            OrderId = order.OrderCode;
            OrderTime = order.CheckInDate;

            OrderPerson = order.CheckInPerson;

            if (order.DeliveryCustomer != null)
            {
                OrderPerson = order.DeliveryCustomer;
            }

            PhoneNumber = string.IsNullOrEmpty(order.DeliveryPhone)
                ? ""
                : order.DeliveryPhone;
            TotalAmount = order.OrderDetailEditViewModels.Sum(o => o.Quantity);
            
            _borderColor = boderColor;
            _statusColor = statusColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            const int borderRadius = 5;


            // Adjust constant.
            var bottom = Height - 1;
            var right = Width - 1;

            var boundPathB = new GraphicsPath();
            boundPathB.StartFigure();
            boundPathB.AddArc(0, 0, 2 * borderRadius, 2 * borderRadius, 180, 90);
            boundPathB.AddArc(right - 2 * borderRadius, 0, 2 * borderRadius, 2 * borderRadius, 270, 90);
            boundPathB.AddArc(right - 2 * borderRadius, bottom - 2 * borderRadius, 2 * borderRadius, 2 * borderRadius, 0, 90);
            boundPathB.AddArc(0, bottom - 2 * borderRadius, 2 * borderRadius, 2 * borderRadius, 90, 90);
            boundPathB.CloseFigure();
            e.Graphics.FillPath(Brushes.White, boundPathB);

            // Prepare fill brush.
            var borderColor = new SolidBrush(_borderColor);
            var statusColor = new SolidBrush(_statusColor);

            var boundPathA = new GraphicsPath();
            boundPathA.StartFigure();
            boundPathA.AddArc(0, 0, 2 * borderRadius, 2 * borderRadius, 180, 90);
            boundPathA.AddArc(right - 2 * borderRadius, 0, 2 * borderRadius, 2 * borderRadius, 270, 90);
            boundPathA.AddLine(right, borderRadius, right, borderRadius + 30);
            boundPathA.AddLine(right, borderRadius + 30, 0, borderRadius + 30);
            boundPathA.CloseFigure();

            // Fill background.
            e.Graphics.FillPath(borderColor, boundPathA);

            // Draw border.
            var pen = new Pen(_borderColor);
            //var pen2 = new Pen(_statusColor);
            e.Graphics.DrawPath(pen, boundPathB);

            var tagPath = DrawUtility.DrawTagRectangle(Width - 120, Height - 22, 115, 18, 10, false);
            e.Graphics.FillPath(statusColor, tagPath);
            var tagName = "";

            switch ((DeliveryStatusEnum)OrderEditViewModel.DeliveryStatus)
            {
                case DeliveryStatusEnum.New:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.New);
                    break;
                case DeliveryStatusEnum.Assigned:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.Assigned);
                    break;
                case DeliveryStatusEnum.PosAccepted:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.PosAccepted);
                    break;
                case DeliveryStatusEnum.Delivery:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.Delivery);
                    break;
                case DeliveryStatusEnum.Finish:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.Finish);
                    break;
                case DeliveryStatusEnum.PreCancel:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.PreCancel);
                    break;
                case DeliveryStatusEnum.Cancel:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.Cancel);
                    break;
                case DeliveryStatusEnum.Fail:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.Fail);
                    break;
                case DeliveryStatusEnum.PosRejected:
                    tagName = Ultis.GetDeliveryStatusNameByEnum(DeliveryStatusEnum.PosRejected);
                    break;
                default:
                    break;
            }

            var stringFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            e.Graphics.DrawString(tagName, lbPersonName.Font, new SolidBrush(Color.White),
                new Rectangle(Width - 118, Height - 21, 110, 18), stringFormat);
        }

        private void child_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
