using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.Repository;
using POS.Repository.ViewModels;
using log4net;

namespace POS.DashboardScreen
{
    public partial class ViewOrderDetailControl : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ViewOrderDetailControl()
        {
            InitializeComponent();
            GenerateLayout();
        }

        private void GenerateLayout()
        {

            lblTitle.Text = MainForm.ResManager.GetString("Sys_Online_Order", MainForm.CultureInfo);
            lblDeliveryAddress.Text = MainForm.ResManager.GetString("Sys_Delivery_Address", MainForm.CultureInfo);
            label1.Text = MainForm.ResManager.GetString("OrderDetailControl_Product_Name", MainForm.CultureInfo);
            label12.Text = MainForm.ResManager.GetString("OrderDetailControl_Unit", MainForm.CultureInfo);
            label8.Text = MainForm.ResManager.GetString("Sys_Discount_Percent", MainForm.CultureInfo);
            label9.Text = "Tổng";
            label13.Text = MainForm.ResManager.GetString("Sys_Quantity", MainForm.CultureInfo);
            label11.Text = MainForm.ResManager.GetString("Sys_Total_Amount", MainForm.CultureInfo);

            label7.Text = "TỔNG THANH TOÁN";
            label15.Text = MainForm.ResManager.GetString("OrderDetailControl_Cash_Payment", MainForm.CultureInfo);
            lblExchangeCash.Text = "Tiền thừa";
            label17.Text = MainForm.ResManager.GetString("OrderDetailControl_Membership", MainForm.CultureInfo);
            label6.Text = MainForm.ResManager.GetString("Sys_Credit_Card", MainForm.CultureInfo);
            label2.Text = MainForm.ResManager.GetString("Sys_Total", MainForm.CultureInfo);
            label3.Text = MainForm.ResManager.GetString("OrderDetailControl_Discount_Amount", MainForm.CultureInfo);
            label4.Text = "VAT";
            label5.Text = MainForm.ResManager.GetString("Sys_Total_Amount", MainForm.CultureInfo)
                            .ToUpper();
        }

        public void LoadOrder(OrderEditViewModel order)
        {
            try
            {
                //Tổng tiền sau khi đã discount từng sản phẩm
                lblTotal.Text = order.SumFinalOrderDetail().ToString("N0");

                //Discount 
                lblDiscountAmount.Text = order.Discount > 0 ?
                        "-" + order.Discount.ToString("N0") : "0";

                //VAT
                lblVATAmount.Text = order.VATAmount > 0 ?
                        "+" + order.VATAmount.ToString("N0") : "0";

                //Thành tiền
                lblFinalAmount.Text = (order.FinalAmount + order.VATAmount).ToString("N0");

                lblOrderCode.Text = order.OrderCode;
                lblOrderDate.Text = order.CheckInDate.ToString("dd-MM-yyyy HH:mm");

                if (order.OrderType == (int)OrderTypeEnum.AtStore)
                {
                    lblTitle.Text = "Tại quán";
                }
                else if (order.OrderType == (int)OrderTypeEnum.Delivery)
                {
                    lblTitle.Text = "Giao hàng";
                }
                else if (order.OrderType == (int)OrderTypeEnum.TakeAway)
                {
                    lblTitle.Text = "Mang đi";
                }

                //Delivery Info
                lblCustomerName.Text = string.IsNullOrEmpty(order.DeliveryCustomer) 
                                            ? "N/A" : order.DeliveryCustomer;
                lblDeliveryAddress.Text = string.IsNullOrEmpty(order.DeliveryAddress)
                                            ? "N/A" : order.DeliveryAddress;
                lblNote.Text = string.IsNullOrEmpty(order.Notes)
                                            ? "N/A" : order.Notes;
                lblPhone.Text = string.IsNullOrEmpty(order.DeliveryPhone)
                                            ? "N/A" : order.DeliveryPhone;
                lblOrderDate.Text = order.CheckInDate.ToString("dd-MM-yyyy HH:mm");

                //Load Payment     
                double cash = 0;
                double other = 0;
                double credit = 0;

                foreach (var p in order.PaymentEditViewModels)
                {
                    if (p.Type == (int)PaymentTypeEnum.Cash)
                    {
                        cash += p.Amount;
                    }
                    else if (p.Type == (int)PaymentTypeEnum.MemberPayment || p.Type == (int)PaymentTypeEnum.Other || p.Type == (int)PaymentTypeEnum.Voucher)
                    {
                        other += p.Amount;
                    }
                    else if (p.Type == (int)PaymentTypeEnum.MasterCard || p.Type == (int)PaymentTypeEnum.VisaCard || p.Type == (int)PaymentTypeEnum.Card)
                    {
                        credit += p.Amount;
                    }
                }

                lblCashPayment.Text = cash.ToString("N0");
                lblOther.Text = other.ToString("N0");
                lblCreditCard.Text = credit.ToString("N0");
                lblPayment.Text = order.PaymentEditViewModels.Sum(
                        p => {
                            if (p.Type == (int)PaymentTypeEnum.ExchangeCash && p.Amount >= 0)
                            {
                                return -p.Amount;
                            } else if (p.Type == (int)PaymentTypeEnum.ExchangeCash)
                            {
                                return p.Amount;
                            } else
                            {
                                return p.Amount > 0 ? p.Amount : 0;
                            }
                        }
                    ).ToString("N0");
                lblExchangeCashValue.Text = order.PaymentEditViewModels.Sum(
                        p => {
                            if (p.Type == (int)PaymentTypeEnum.ExchangeCash && p.Amount >= 0)
                            {
                                return -p.Amount;
                            }
                            else if (p.Type == (int)PaymentTypeEnum.ExchangeCash)
                            {
                                return p.Amount;
                            } else
                            {
                                return 0;
                            }
                        }
                    ).ToString("N0");
                //Load OrderDetail
                var sorttedOds = this.GetSortedValidOrderDetail(order);
                for (int i = 0; i < sorttedOds.ToList().Count; i++)
                {
                    OrderDetailViewModel tmpOrderDetail = sorttedOds[i];
                    if (tmpOrderDetail.Quantity != 0)
                    {
                        RowStyle style = new RowStyle(SizeType.AutoSize);
                        tlpOrderDetail.RowStyles.Add(style);
                        var orderDetailViewModel = sorttedOds[i];
                        //Dong đầu tiên của TableViewModel dùng để chưa Header
                        int index = i + 1;

                        Font f = new Font("Segoe UI", 10F, FontStyle.Bold);
                        Font fs = new Font("Segoe UI", 10F, FontStyle.Strikeout);

                        //Add ProductViewModel Name                      
                        Label lblProductName = new Label()
                        {
                            ForeColor = Color.White,
                            AutoSize = true,
                            Font = f,
                        };
                        lblProductName.Text = orderDetailViewModel.ProductName;

                        if (orderDetailViewModel.Status == (int)OrderStatusEnum.PosCancel
                            || orderDetailViewModel.Status == (int)OrderStatusEnum.Cancel
                            || orderDetailViewModel.Status == (int)OrderStatusEnum.PosPreCancel
                            || orderDetailViewModel.Status == (int)OrderStatusEnum.PreCancel)
                        {
                            lblProductName.Font = fs;
                        }
                        if (IsExtraProduct(orderDetailViewModel.ProductCode))
                        {
                            lblProductName.Text = "+" + orderDetailViewModel.ProductName;
                        }

                        tlpOrderDetail.Controls.Add(lblProductName, 0, index);

                        //Add Unit Price
                        Label lblUnitPrice = new Label()
                        {
                            ForeColor = Color.White,
                            Font = f,
                            TextAlign = ContentAlignment.MiddleRight
                        };
                        lblUnitPrice.Text = orderDetailViewModel.UnitPrice.ToString("N0");
                        tlpOrderDetail.Controls.Add(lblUnitPrice, 1, index);

                        //Add Quantity
                        Label lblQuatity = new Label()
                        {
                            ForeColor = Color.White,
                            Font = f,
                            TextAlign = ContentAlignment.MiddleRight
                        };
                        lblQuatity.Text = orderDetailViewModel.Quantity.ToString();
                        tlpOrderDetail.Controls.Add(lblQuatity, 2, index);

                        //Add Total
                        Label lblDetailTotal = new Label()
                        {
                            ForeColor = Color.White,
                            Font = f,
                            TextAlign = ContentAlignment.MiddleRight
                        };
                        lblDetailTotal.Text = orderDetailViewModel.TotalAmount.ToString("N0");
                        tlpOrderDetail.Controls.Add(lblDetailTotal, 3, index);

                        //Add Percentage discount
                        Label lblPercentage = new Label()
                        {
                            ForeColor = Color.White,
                            Font = f,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        var percentage = orderDetailViewModel.TotalAmount != 0
                                ? 100 - orderDetailViewModel.FinalAmount * 100
                                        / orderDetailViewModel.TotalAmount
                                : 0;
                        lblPercentage.Text = string.Format("{0:0.00}%", percentage);
                        tlpOrderDetail.Controls.Add(lblPercentage, 4, index);

                        //Add Final
                        Label lblFinal = new Label()
                        {
                            ForeColor = Color.White,
                            Font = f,
                            TextAlign = ContentAlignment.MiddleRight
                        };
                        lblFinal.Text = orderDetailViewModel.FinalAmount.ToString("N0");

                        if (orderDetailViewModel.Status == (int)OrderStatusEnum.PosCancel
                            || orderDetailViewModel.Status == (int)OrderStatusEnum.Cancel)
                        {
                            lblFinal.Text = "Hủy sau.";
                        }
                        else if (orderDetailViewModel.Status == (int)OrderStatusEnum.PosPreCancel
                            || orderDetailViewModel.Status == (int)OrderStatusEnum.PreCancel)
                        {
                            lblFinal.Text = "Hủy trước.";
                        }

                        tlpOrderDetail.Controls.Add(lblFinal, 5, index);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("LoadOrder - " + ex);
            }
        }

        private bool IsExtraProduct(string productCode)
        {
            var product = Program.context.getAllProducts().FirstOrDefault(p => p.Code == productCode);
            var category = Program.context.getAvailableCategories().LastOrDefault(c => product != null && c.Code == product.CatID);

            if (category != null && (category.IsExtra == 0 || category.IsExtra == null))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get all valid OrderDetailViewModel and sort by OrderEditViewModel : mainitem -> extraitem of mainitem
        /// </summary>
        private List<OrderDetailEditViewModel> GetSortedValidOrderDetail(OrderEditViewModel order)
        {
            var validOrderDetils = order.OrderDetailEditViewModels;

            if (MainForm.PosConfig.EnableViewCancelDetail.Trim().ToLower() == "false")
            {
                validOrderDetils = validOrderDetils
                        .Where(od => od.Status != (int)OrderDetailStatusEnum.Cancel
                            && od.Status != (int)OrderDetailStatusEnum.PosCancel
                            && od.Status != (int)OrderDetailStatusEnum.PosPreCancel
                            && od.Status != (int)OrderDetailStatusEnum.PreCancel)
                        .ToList();
            }

            var sortedOrderDetailList = new List<OrderDetailEditViewModel>();

            //Thêm sản phẩm bình thường
            foreach (var mainOrderDetail in validOrderDetils
                            .Where(od => od.ParentId == null
                                && od.Status != (int)OrderDetailStatusEnum.Cancel
                                && od.Status != (int)OrderDetailStatusEnum.PosCancel
                                && od.Status != (int)OrderDetailStatusEnum.PosPreCancel
                                && od.Status != (int)OrderDetailStatusEnum.PreCancel))
            {
                sortedOrderDetailList.AddRange(validOrderDetils
                            .Where(od => od.OrderDetailID == mainOrderDetail.OrderDetailID
                                || od.ParentId == mainOrderDetail.OrderDetailID)
                            .OrderBy(od => od.ParentId)
                            .ToList());
            }

            //Thêm sản phẩm hủy (nếu có)
            foreach (var mainOrderDetail in validOrderDetils
                            .Where(od => od.Status == (int)OrderDetailStatusEnum.Cancel
                                || od.Status == (int)OrderDetailStatusEnum.PosCancel
                                || od.Status == (int)OrderDetailStatusEnum.PosPreCancel
                                || od.Status == (int)OrderDetailStatusEnum.PreCancel))
            {
                sortedOrderDetailList.Add(mainOrderDetail);
            }
            return sortedOrderDetailList;
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblExchangeCash_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
