using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using POS.Common;
using POS.CustomControl;
using POS.Properties;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.SaleScreen
{
    public class OrderItemControl : Label
    {
        private List<OrderDetailEditViewModel> _orderItems;
        public List<OrderDetailEditViewModel> OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                //Filter
                _orderItems = value.Where(oi =>
                    //oi.Status != (int)OrderDetailStatusEnum.PosCancel &&
                    oi.Status != (int)OrderDetailStatusEnum.PosPreCancel).ToList(); ;
            }
        }

        private bool _isActive;

        int itemHeight = 50;
        int extraHeight = 30;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                Invalidate();
            }
        }

        public OrderItemControl(List<OrderDetailEditViewModel> od)
        {
            OrderItems = od;
            Height = itemHeight + (OrderItems.Count - 1) * extraHeight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Nếu là main item thì đường đen
            // DraweSingleItem(OrderItems, e, true);

            //item.Width = 290;
            OrderItems = OrderItems.Where(oi => oi.Status != (int)OrderDetailStatusEnum.PosPreCancel).ToList();


            var mainOrderDetail = OrderItems[0];


            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //New Size - Sinh
            //            var fontR = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            //            var fontB = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            //            var fontBs = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            //            var fontS = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Strikeout);

            var fontR = new Font("Tahoma", 10, FontStyle.Regular);
            var fontB = new Font("Tahoma", 10, FontStyle.Bold);
            var fontBs = new Font("Tahoma", 8, FontStyle.Bold);
            var fontS = new Font("Tahoma", 10, FontStyle.Strikeout);

            var formatCr = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near
            };
            var formatCl = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            };
            var brush1 = new SolidBrush(Constant.Brown);
            var brush2 = new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
            //var pen = new Pen(Constant.Brown);
            var checkBoxImg = Resources.check_box;

            //Change color
            if (IsActive)
            {
                brush1 = new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                //pen = new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                brush2 = new SolidBrush(Constant.Brown);
                e.Graphics.FillRectangle(brush2, 0, 0, Width, Height);
            }
            if (mainOrderDetail.Status == (int)OrderDetailStatusEnum.New)
            {
                brush1 = new SolidBrush(Color.White);
            }

            for (int i = 0; i < OrderItems.Count; i++)
            {
                var od = OrderItems[i];
                //Short productname
                string productName = od.ProductName;

                int yPos = 5;
                int xPos = 2;
                if (i == 0)
                {
                    if (productName.Length > 13 && !string.IsNullOrEmpty(mainOrderDetail.Notes))
                    {
                        itemHeight = 61; //Neu ten san pham dai thì tăng độ cao khi vẽ notes
                    }
                    //draw quantity
                    //TODO: TTH - DUY
                    e.Graphics.DrawString(od.ItemQuantity.ToString(), fontB, brush1, xPos, yPos);
                    if (od.ItemQuantity > 99)
                    {
                        xPos += 26;
                        if (od.ItemQuantity > 999)
                        {
                            xPos += 10;
                        }
                    }
                    else
                    {
                        xPos += 18; //20-quantity
                    }
                    //draw name

                    if (od.Status == (int)OrderDetailStatusEnum.PosCancel
                        || od.Status == (int)OrderDetailStatusEnum.Cancel)
                    {
                        e.Graphics.DrawString(productName, fontS, brush1, xPos, yPos);
                    }
                    else
                    {
                        e.Graphics.DrawString(productName, fontB, brush1, xPos, yPos);
                    }

                    xPos += 120;
                    if (!string.IsNullOrEmpty(mainOrderDetail.Notes) && productName.Length > 25)
                    {
                        itemHeight = 60;
                    }
                }
                else
                {
                    yPos = 2 + extraHeight * i;
                    xPos = 20;

                    if (itemHeight == 60)
                    {
                        itemHeight = 50;
                    }

                    //string strTmpQuantity = od.ItemQuantity.ToString();
                    //draw quantity
                    e.Graphics.DrawString(od.Quantity.ToString(), fontB, brush1, xPos, yPos);
                    if (od.ItemQuantity > 99)
                    {
                        xPos += 28;
                    }
                    else
                    {
                        xPos += 20; //20-quantity
                    }
                    //draw name
                    string itemQuantity = " (x " + od.ItemQuantity + ")";

                    if (od.Status == (int)OrderDetailStatusEnum.PosCancel
                        || od.Status == (int)OrderDetailStatusEnum.Cancel)
                    {
                        e.Graphics.DrawString(od.ProductName, fontS, brush1, xPos, yPos);
                    }
                    else
                    {
                        e.Graphics.DrawString(od.ProductName + itemQuantity, fontR, brush1, xPos, yPos);
                    }

                    xPos += 100;//product name
                }

                //draw unitprice
                //Unit price => right align
                //                if (productName.Length > 17) yPos += 15; //Neu ten san pham dai thì in thấp xuống
                if (productName.Length > 13)
                {
                    yPos += 15; //Neu ten san pham dai thì in thấp xuống
                }

                if (od.Status != (int)OrderDetailStatusEnum.PosCancel
                        && od.Status != (int)OrderDetailStatusEnum.Cancel)
                {
                    string unitPrice = od.UnitPrice.ToString("N0");
                    int leftPadding = (10 - unitPrice.Length) * 5;

                    e.Graphics.DrawString(unitPrice, fontBs, brush1, xPos + leftPadding, yPos + 2);
                    xPos += 70;

                    //Discount 
                    if (od.GetDiscountRate() > 0)
                    {
                        var path = DrawUtility.DrawTagRectangle(xPos, yPos + 2, 35, 14, 5, false);
                        e.Graphics.FillPath(brush1, path);
                        e.Graphics.DrawString(od.GetDiscountRate().ToString() +"%", fontBs, brush2, new RectangleF(xPos, yPos + 4, 35, 12),
                            formatCl);
                    }
                    xPos += 25;
                    //draw final amount
                    //Final amount => 
                    string finalAmount = od.FinalAmount.ToString("N0");
                    Rectangle rect = new Rectangle(xPos, yPos, 80, 40);

                    e.Graphics.DrawString(finalAmount, fontB, brush1, rect, formatCr);

                    //
                    if (od.Status == (int)OrderDetailStatusEnum.PosFinished
                        || od.Status == (int)OrderDetailStatusEnum.Finish)
                    {
                        e.Graphics.DrawImage(checkBoxImg, 10, Height - 18, 11, 11);
                    }
                }
            }

            if (mainOrderDetail.Status != (int)OrderDetailStatusEnum.PosCancel
                        && mainOrderDetail.Status != (int)OrderDetailStatusEnum.Cancel)
            {
                //draw additional field
                if (!string.IsNullOrEmpty(mainOrderDetail.Notes))
                {
                    string notes = mainOrderDetail.Notes.Replace("|", " ");
                    var size = e.Graphics.MeasureString(mainOrderDetail.Notes, fontBs);
                    var path = DrawUtility.DrawBorderRadiusRectangle(40, Height - 20, (int)(40 + size.Width + 8), Height - 5, 1);
                    e.Graphics.FillPath(brush1, path);
                    e.Graphics.DrawString(notes, fontBs, brush2, 45, Height - 10, formatCl);
                }
            }

            var pen2 = new Pen(Constant.Brown);
            e.Graphics.DrawLine(pen2, 2, Height - 1, Width - 2, Height - 1);

        }

        public void RenewUi()
        {
            Height = itemHeight + (OrderItems.Count - 1) * extraHeight;
            Invalidate();
        }
    }
}
