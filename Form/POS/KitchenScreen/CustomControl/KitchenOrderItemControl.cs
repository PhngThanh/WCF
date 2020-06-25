using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.SaleScreen
{
    public class KitchenOrderItemControl : Label
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
                                oi.Status != (int)OrderDetailStatusEnum.PosCancel &&
                                oi.Status != (int)OrderDetailStatusEnum.PosPreCancel).ToList();
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

        public KitchenOrderItemControl(List<OrderDetailEditViewModel> od)
        {
            OrderItems = od;
            Height = itemHeight + (OrderItems.Count - 1) * extraHeight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            // Nếu là main item thì đường đen
            // DraweSingleItem(OrderItems, e, true);


            //item.Width = 290;
            OrderItems = OrderItems.Where(oi => oi.Status != (int)OrderDetailStatusEnum.PosCancel &&
            oi.Status != (int)OrderDetailStatusEnum.PosPreCancel).ToList();
            var mainOrderDetail = OrderItems[0];

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

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
            //var brush1 = new SolidBrush(Constant.Brown);
            var brush1 = new SolidBrush(Constant.White);
            var brush2 = new SolidBrush(Color.Black);
            var pen = new Pen(Constant.Brown);

            //Change color
            if (IsActive)
            {
                brush1 = new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                pen = new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                brush2 = new SolidBrush(Constant.Brown);
                e.Graphics.FillRectangle(brush2, 0, 0, Width, Height);
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
                    //main item

                    //draw quantity
                    e.Graphics.DrawString(od.ItemQuantity.ToString(), fontB, brush1, xPos, yPos);
                    xPos += 18; //20-quantity
                                //draw name
                    int charPerLine = 20;
                    int firstLineYPos = yPos;
                    var addItemHeight = 0;
                    if (productName.Length > charPerLine)
                    {
                        var multipleLines = this.BreakLines(productName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            e.Graphics.DrawString(line, fontB, brush1, xPos, yPos);
                            yPos += 15;
                            addItemHeight += 5;
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString(productName, fontB, brush1, xPos, yPos);
                    }
                    //e.Graphics.DrawString(productName, fontB, brush1, xPos, yPos);

                    xPos += 120;
                    if (!string.IsNullOrEmpty(mainOrderDetail.Notes) && productName.Length > charPerLine)
                    {
                        itemHeight = 60 + addItemHeight;
                    }

                    //draw ordertime or status
                    if (od.Status == (int)OrderDetailStatusEnum.Processing)
                    {
                        xPos += 75;

                        string time = od.OrderDate.ToString("HH:mm");
                        Rectangle rect = new Rectangle(xPos, firstLineYPos, 70, 40);

                        e.Graphics.DrawString(time, fontB, brush1, rect, formatCr);
                    }
                    else
                    {
                        xPos += 85;

                        string status = "Hoàn tất";
                        Rectangle rect = new Rectangle(xPos, firstLineYPos, 70, 40);

                        e.Graphics.DrawString(status, fontB, brush1, rect, formatCr);
                    }
                }
                else
                {
                    //extra item


                    yPos = 2 + extraHeight * i;
                    xPos = 20;

                    if (itemHeight == 60)
                    {
                        itemHeight = 50;
                    }

                    string strTmpQuantity = od.ItemQuantity.ToString();
                    //draw quantity
                    e.Graphics.DrawString(od.Quantity.ToString(), fontB, brush1, xPos, yPos);
                    xPos += 20;//40
                               //draw name
                    string itemQuantity = " (x " + od.ItemQuantity + ")";
                    e.Graphics.DrawString(od.ProductName + itemQuantity, fontR, brush1, xPos, yPos);

                }
            }

            //draw additional field
            if (!string.IsNullOrEmpty(mainOrderDetail.Notes))
            {
                string notes = mainOrderDetail.Notes.Replace("|", " ");
                notes = notes.Replace("@~", "");
                var size = e.Graphics.MeasureString(mainOrderDetail.Notes, fontBs);
                var path = DrawUtility.DrawBorderRadiusRectangle(40, Height - 20, (int)(40 + size.Width + 8), Height - 5, 1);
                e.Graphics.FillPath(brush1, path);
                e.Graphics.DrawString(notes, fontBs, brush2, 45, Height - 10, formatCl);
            }

            var pen1 = new Pen(Constant.Brown);
            e.Graphics.DrawLine(pen1, 2, Height - 1, Width - 2, Height - 1);

        }

        public void RenewUi()
        {
            Height = itemHeight + (OrderItems.Count - 1) * extraHeight;
            Invalidate();
        }

        /// <summary>
        /// Break down long single string to multiple string 
        /// </summary>
        /// <param name="singleLineText">text need to be broken</param>
        /// <param name="charPerLine">characters per line</param>
        /// <returns>return list of line</returns>
        private List<string> BreakLines(string singleLineText, int charPerLine)
        {
            var multipleLines = new List<string>();
            string charInLine = "";
            int currentLenght = 0;
            List<string> words = singleLineText.Split(' ').ToList();

            for (int i = 0; i < words.Count; i++)
            {
                currentLenght += words[i].Length;

                if (currentLenght > charPerLine)
                {
                    multipleLines.Add(charInLine);
                    charInLine = "   ";
                    charInLine += words[i] + " ";
                    currentLenght = 0;
                }
                else
                {
                    charInLine += words[i] + " ";
                }

                if (i == words.Count - 1)
                {
                    multipleLines.Add(charInLine);
                }
            }

            return multipleLines;
        }
    }
}
