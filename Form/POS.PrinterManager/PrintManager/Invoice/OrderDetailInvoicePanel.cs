using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Repository.ViewModels;

namespace POS.PrintManager.Invoice
{
    public partial class OrderDetailInvoicePanel : UserControl
    {
        public OrderDetailInvoicePanel()
        {
            InitializeComponent();
        }

        public void LoadOrderDetail(List<OrderDetailEditViewModel> detailViewModels, int countBegin)
        {
            int count = countBegin + 1;
            Font font = new System.Drawing.Font("Times New Roman,", 9.75F);

            //Dòng đầu tiên + thứ hai của TableViewModel dùng để chứa header & note
            int row = 2;
            //Row height = 30
            //Maximum type 1.1 = 14 row = 420
            //Maximum type 1.2 = 
            //Maximum type 2.1 = 
            //Maximum type 2.2 = 
            tlpOrderDetail.RowCount = row + 13;
            for (int i = 0; i < tlpOrderDetail.RowCount; i++)
            {
                tlpOrderDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            }

            var descendingOrder = detailViewModels.OrderByDescending(d => d.FinalAmount);

            foreach (var detail in descendingOrder)
            {
                if (count > 12) break;
                if (detail.Quantity != 0
                    && detail.Status != (int)OrderStatusEnum.PosCancel
                    && detail.Status != (int)OrderStatusEnum.Cancel
                    && detail.Status != (int)OrderStatusEnum.PosPreCancel
                    && detail.Status != (int)OrderStatusEnum.PreCancel)
                {
                    //Add index
                    Label lblIndex = new Label()
                    {
                        ForeColor = Color.Black,
                        Font = font,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    lblIndex.AutoSize = true;
                    lblIndex.Text = count.ToString();
                    tlpOrderDetail.Controls.Add(lblIndex, 0, row);

                    //Add ProductViewModel Name
                    Label lblProductName = new Label()
                    {
                        ForeColor = Color.Black,
                        Font = font,
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    lblProductName.AutoSize = true;
                    lblProductName.Text = detail.ProductName;
                    tlpOrderDetail.Controls.Add(lblProductName, 1, row);

                    //Add Unit

                    //Add Quantity
                    Label lblQuatity = new Label()
                    {
                        ForeColor = Color.Black,
                        Font = font,
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                    lblQuatity.Text = detail.Quantity.ToString();
                    tlpOrderDetail.Controls.Add(lblQuatity, 3, row);

                    //Add Unit Price
                    Label lblUnitPrice = new Label()
                    {
                        ForeColor = Color.Black,
                        Font = font,
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    lblUnitPrice.Text = detail.UnitPrice.ToString("N0");
                    tlpOrderDetail.Controls.Add(lblUnitPrice, 4, row);

                    //Add Total
                    Label lblDetailTotal = new Label()
                    {
                        ForeColor = Color.Black,
                        Font = font,
                        TextAlign = ContentAlignment.MiddleRight
                    };
                    lblDetailTotal.Text = detail.FinalAmount.ToString("N0");
                    tlpOrderDetail.Controls.Add(lblDetailTotal, 5, row);

                    count++;
                    row++;
                }
            }

            double totalOther = 0;
            int totalQuantity = 0;
            if (descendingOrder.Count() > 12)
            {
                var tmpList = descendingOrder.ToList();
                for (int i = 12; i < tmpList.Count(); i++)
                {
                    totalOther += tmpList[i].FinalAmount;
                    totalQuantity += tmpList[i].Quantity;
                }
                //Add index
                Label lblIndex2 = new Label()
                {
                    ForeColor = Color.Black,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lblIndex2.AutoSize = true;
                lblIndex2.Text = "13";
                tlpOrderDetail.Controls.Add(lblIndex2, 0, 14);

                //Add ProductViewModel Name
                Label lblProductName2 = new Label()
                {
                    ForeColor = Color.Black,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                lblProductName2.AutoSize = true;
                lblProductName2.Text = "Khác";
                tlpOrderDetail.Controls.Add(lblProductName2, 1, 14);

                //Add Unit

                //Add Quantity
                Label lblQuatity2 = new Label()
                {
                    ForeColor = Color.Black,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                lblQuatity2.Text = totalQuantity.ToString();
                tlpOrderDetail.Controls.Add(lblQuatity2, 3, row);

                //Add Unit Price

                //Add Total
                Label lblDetailTotal2 = new Label()
                {
                    ForeColor = Color.Black,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleRight
                };
                lblDetailTotal2.Text = totalOther.ToString("N0");
                tlpOrderDetail.Controls.Add(lblDetailTotal2, 5, 14);
            }
        }
    }
}
