using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using POS.Utils;
using POS.Common;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.DashboardScreen.ViewOrderScreen
{
    public partial class ReviewOrderControl : UserControl
    {
        private readonly Color _borderColor;
        private readonly Color _statusColor;
        private DateTime _orderTime;
        private string _tableNumber;
        private string _orderCode;
        private int _completeQuantity;
        private string _totalQuantity;
        private double _totalAmount;
        private double _finalAmount;

        public string TableNumber
        {
            get { return _tableNumber; }
            set
            {
                _tableNumber = value;
                lbTableNumber.Text = "Bàn: " + _tableNumber;
            }
        }

        public DateTime OrderTime
        {
            get { return _orderTime; }
            set
            {
                _orderTime = value;
                lbTime.Text = _orderTime.ToString("HH:mm");
            }
        }

        public string OrderCode
        {
            get { return _orderCode; }
            set
            {
                _orderCode = value ?? "";
                lbOrderCode.Text = "Mã hóa đơn: " + _orderCode.ToUpper();
            }
        }

        public string TotalQuantity
        {
            get { return _totalQuantity; }
            set
            {
                _totalQuantity = value ?? "";
                if (_completeQuantity == -1)
                {
                    lbQuantity.Text = "Số lượng: " + _totalQuantity;
                }
                else
                {
                    lbQuantity.Text = "Số lượng: " + _completeQuantity + " / " + _totalQuantity;
                }
            }
        }

        public double TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                _totalAmount = value;
                lblTotalAmount.Text = "Tổng: " + String.Format("{0:n0}", _totalAmount) + " (VNĐ)";
            }
        }

        public double FinalAmount
        {
            get { return _finalAmount; }
            set
            {
                _finalAmount = value;
                lblFinalAmount.Text = "Thanh toán: " + String.Format("{0:n0}", _finalAmount) + " (VNĐ)";
            }
        }

        public OrderEditViewModel OrderEditViewModel { get; set; }

        public ReviewOrderControl(Color boderColor, Color statusColor, OrderEditViewModel order)
        {
            InitializeComponent();
            
            OrderEditViewModel = order;
            TableNumber = order.TableNumber;
            OrderTime = order.CheckInDate;
            OrderCode = order.OrderCode;
            
            var totalQuantity = order.OrderDetailEditViewModels.Sum(o => o.Quantity);

            var completeQuantity = order.OrderDetailEditViewModels.
                    Where(o => o.Status == (int)OrderDetailStatusEnum.Finish
                        || o.Status == (int)OrderDetailStatusEnum.PosFinished).
                    Sum(o => o.Quantity);
            
            if (completeQuantity == totalQuantity)
            {
                _completeQuantity = -1;
            }
            else
            {
                _completeQuantity = completeQuantity;
            }

            TotalQuantity = totalQuantity.ToString();
            TotalAmount = order.TotalAmount;
            FinalAmount = order.FinalAmount + order.VATAmount;

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


            switch ((OrderStatusEnum)OrderEditViewModel.OrderStatus)
            {
                case OrderStatusEnum.New:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.New);
                    break;
                case OrderStatusEnum.PosProcessing:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.PosProcessing);
                    break;
                case OrderStatusEnum.PosPreCancel:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.PosPreCancel);
                    break;
                case OrderStatusEnum.PosCancel:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.PosCancel);
                    break;
                case OrderStatusEnum.PosFinished:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.PosFinished);
                    break;
                case OrderStatusEnum.PreCancel:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.PreCancel);
                    break;
                case OrderStatusEnum.Cancel:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.Cancel);
                    break;
                case OrderStatusEnum.Finish:
                    tagName = Ultis.GetOrderStatusNameByEnum(OrderStatusEnum.Finish);
                    break;
            }

            var stringFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            e.Graphics.DrawString(tagName, lbOrderCode.Font, new SolidBrush(Color.White),
                new Rectangle(Width - 118, Height - 21, 110, 18), stringFormat);
        }

        private void child_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
