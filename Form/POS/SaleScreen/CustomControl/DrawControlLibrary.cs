using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using POS.Properties;

namespace POS.SaleScreen.CustomControl
{
    public static class DrawControlLibrary
    {
        private static PrivateFontCollection _privateFontCollection;
        private static PrivateFontCollection _privateFontCollectionExtraBold;

        public static PrivateFontCollection PrivateFontCollection
        {
            get
            {
                if (_privateFontCollection == null)
                {
                    InitFont();
                }
                return _privateFontCollection;
            }
        }

        public static PrivateFontCollection PrivateFontCollectionExtraBold
        {
            get
            {
                if (_privateFontCollectionExtraBold == null)
                {
                    InitExtraBoldFont();
                }
                return _privateFontCollectionExtraBold;
            }
        }

        private static void InitExtraBoldFont()
        {
            var fonts = new PrivateFontCollection();
            var fontFm = Resources.OPENSANS_EXTRABOLD;
            var fontPtr = Marshal.AllocCoTaskMem(fontFm.Length);
            Marshal.Copy(fontFm, 0, fontPtr, fontFm.Length);
            fonts.AddMemoryFont(fontPtr, Resources.OPENSANS_EXTRABOLD.Length);
            _privateFontCollectionExtraBold = fonts;
        }

        public static void InitFont()
        {

            var fonts = new PrivateFontCollection();
            var fontFM = Resources.OPENSANS_REGULAR;
            var fontPtr = Marshal.AllocCoTaskMem(fontFM.Length);
            Marshal.Copy(fontFM, 0, fontPtr, fontFM.Length);
            fonts.AddMemoryFont(fontPtr, Resources.OPENSANS_REGULAR.Length);
            _privateFontCollection = fonts;
        }

        //public static class ProductControl
        //{
        //    //public const int Top = 70;
        //    //public const int Bottom = 102;
        //    //public const int Right = 106;
        //    //public const int Radius = 5;
        //    //public const int Center = 53;

        //    //public const int Top = 75;
        //    //public const int Bottom = 107;
        //    //public const int Right = 111;
        //    //public const int Radius = 5;
        //    //public const int Center = 58;

        //    //public static void DrawProduct(PaintEventArgs e, string productName, string price,
        //    //    string amount, int type)
        //    //{
        //    //    //Full fill with color
        //    //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //    //    var firstColor = Color.Transparent;
        //    //    var secondColor = Color.Transparent;
        //    //    switch (type % 3)
        //    //    {
        //    //        case 0:
        //    //            firstColor = Constant.BlueProduct;
        //    //            secondColor = Constant.White;
        //    //            break;
        //    //        case 1:
        //    //            firstColor = Constant.RedProduct;
        //    //            secondColor = Constant.White;
        //    //            break;
        //    //        case 2:
        //    //            firstColor = Constant.GreenProduct;
        //    //            secondColor = Constant.White;
        //    //            break;
        //    //    }
        //    //    if (amount == "0")
        //    //    {
        //    //        var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, Right, Bottom, Radius);
        //    //        path.AddLine(Center, Bottom, Center, Top);

        //    //        e.Graphics.FillPath(new SolidBrush(firstColor), path);
        //    //        e.Graphics.DrawPath(new Pen(secondColor, 1), path);

        //    //        var formatC = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Center,
        //    //        };
        //    //        var formatL = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Near,
        //    //        };
        //    //        var formatR = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Far,
        //    //        };
        //    //        // Draw ProductViewModel name.
        //    //        var font = new Font(PrivateFontCollection.Families[0], 10, FontStyle.Bold);
        //    //        var rect = new Rectangle(5, Top - 60, Right - 5, 55);
        //    //        e.Graphics.DrawString(productName, font, new SolidBrush(secondColor), rect, formatL);
        //    //        //Huy Comment
        //    //        //var font = new Font(PrivateFontCollection.Families[0], 8, FontStyle.Bold);
        //    //        //var rect = new Rectangle(8, Top - 32, Right - 13, 40);
        //    //        //e.Graphics.DrawString(productName, font, new SolidBrush(secondColor), rect, formatL);

        //    //        // Draw price.
        //    //        //font = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
        //    //        //rect = new Rectangle(0, 5, Right - 5, 20);
        //    //        //e.Graphics.DrawString(price, font, new SolidBrush(secondColor), rect, formatR);
        //    //    }
        //    //    //White background and color border
        //    //    else
        //    //    {
        //    //        var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, Right, Bottom, Radius);
        //    //        var border = DrawUtility.DrawBorderRadiusRectangle(1, 1, Right - 1, Bottom - 1, Radius - 1);
        //    //        border.AddLine(Center, Bottom - 2, Center, Top);

        //    //        e.Graphics.FillPath(new SolidBrush(secondColor), path);
        //    //        e.Graphics.DrawPath(new Pen(secondColor, 1), path);
        //    //        e.Graphics.DrawPath(new Pen(firstColor, 1), border);

        //    //        var formatC = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Center,
        //    //        };
        //    //        var formatL = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Near,
        //    //        };
        //    //        var formatR = new StringFormat
        //    //        {
        //    //            Alignment = StringAlignment.Far,
        //    //        };
        //    //        // Draw ProductViewModel name.
        //    //        var font = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
        //    //        var rect = new Rectangle(8, Top - 32, Right - 5, 40);
        //    //        e.Graphics.DrawString(productName, font, new SolidBrush(firstColor), rect, formatL);

        //    //        // Draw price.
        //    //        //font = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
        //    //        //rect = new Rectangle(0, 5, Right - 5, 20);
        //    //        //e.Graphics.DrawString(price, font, new SolidBrush(firstColor), rect, formatR);
        //    //        //Draw quantity
        //    //        font = new Font(PrivateFontCollection.Families[0], 21, FontStyle.Bold);
        //    //        rect = new Rectangle(5, 4, Right - 5, 65);
        //    //        e.Graphics.DrawString(amount.ToString(CultureInfo.InvariantCulture), font,
        //    //            new SolidBrush(firstColor), rect, formatL);
        //    //    }
        //    //}


        //    //public static void DrawQuantityControl(PaintEventArgs e, bool isLeft, bool isClicked, int type)
        //    //{
        //    //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //    //    var rectangle = isLeft
        //    //        ? new Rectangle(1, Top, Center - 2, Bottom - Top - 1)
        //    //        : new Rectangle(Center + 1, Top, Center - 2, Bottom - Top - 1);
        //    //    var path = isLeft
        //    //        ? DrawUtility.DrawBorderRadiusRectangle(rectangle, 0, 0, 0, Radius)
        //    //        : DrawUtility.DrawBorderRadiusRectangle(rectangle, 0, 0, Radius, 0);
        //    //    var font = new Font(PrivateFontCollection.Families[0], 10, FontStyle.Bold);

        //    //    if (isClicked)
        //    //    {
        //    //        var linGrBrush = new LinearGradientBrush(
        //    //            new Point(0, 0),
        //    //            new Point(0, Bottom - Top + 1),
        //    //            Constant.BlueProduct,
        //    //            Color.FromArgb(10, 159, 255));
        //    //        e.Graphics.FillPath(linGrBrush, path);
        //    //    }
        //    //    else
        //    //    {
        //    //        var whiteBrush = new SolidBrush(Color.FromArgb(0, 255, 255, 255));
        //    //        e.Graphics.FillPath(whiteBrush, path);
        //    //    }
        //    //    //draw text
        //    //    e.Graphics.DrawLine(new Pen(Constant.White, 3), 24, 83, 30, 83);
        //    //    //e.Graphics.DrawString(isLeft ? "-" : "+", font, new SolidBrush(Color.White),
        //    //    //    new RectangleF(rectangle.Location, rectangle.Size),
        //    //    //    new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        //    //}
        //}

        public static class OrderPanel
        {
            //public const int TopLine = 59;
            //public const int DeliverButtonRadius = 20;
            //public const int TableButtonRadius = 29;
            //public const int Bottom = 290;
            //public const int Right = 290;
            //public const int Radius = 4;
            //public const int Center = 57;
            //public const int PaymentButtonHeight = 42;
            //public const int PaymentButtonWidth = 180;
            //public const int MarginLeft = 6;
            //public const int ExchangeMarginBottom = 82;
            //public const int ReceivedTextBoxHeight = 35;
            //public const int OrderTotalPanelHeight = 100;

            //public static void DrawAdvanceButton(object sender, PaintEventArgs e)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //    var control = (Control)sender;
            //    var path = new GraphicsPath();
            //    path.StartFigure();
            //    path.AddLine(0, 14, 10, 0);
            //    path.AddLine(92, 0, 92, 28);
            //    path.AddLine(10, 28, 0, 14);
            //    path.CloseFigure();
            //    control.Width = 93;
            //    control.Height = 29;
            //    var font = new Font(PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            //    var format = new StringFormat
            //    {
            //        Alignment = StringAlignment.Far,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    if (!control.Enabled)
            //    {
            //        e.Graphics.DrawPath(new Pen(Constant.Brown), path);
            //        e.Graphics.DrawString("ADVANCE", font, new SolidBrush(Constant.Brown), 85, 12, format);
            //    }
            //    else
            //    {
            //        e.Graphics.FillPath(new SolidBrush(Constant.Brown), path);
            //        e.Graphics.DrawString("ADVANCE", font, new SolidBrush(Constant.Green), 85, 12, format);
            //    }
            //}

            //public static void DrawTotalPanel(PaintEventArgs e, int quantity, string payment, string totalPayment,
            //    string discount)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //    var formatCl = new StringFormat
            //    {
            //        Alignment = StringAlignment.Near,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    var formatCr = new StringFormat
            //    {
            //        Alignment = StringAlignment.Far,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    var formatCc = new StringFormat
            //    {
            //        Alignment = StringAlignment.Center,
            //        LineAlignment = StringAlignment.Center
            //    };

            //    ////Old Size
            //    //var fontExBold = new Font(PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            //    //var fontBold = new Font(PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            //    //var fontBoldS = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
            //    ////draw main label
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("DrawControlLibrary_Product", MainForm.cultureInfo), fontExBold, new SolidBrush(Constant.Green), 8, 13, formatCl);
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("DrawControlLibrary_Advanced", MainForm.cultureInfo), fontExBold, new SolidBrush(Constant.Green), 8, 55, formatCl);
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("DrawControlLibrary_Total_Amount", MainForm.cultureInfo), fontExBold, new SolidBrush(Constant.Green), 290 - 5, 13,
            //    //    formatCr);
            //    ////New Size - Sinh 
            //    var fontExBold = new Font(PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            //    var fontBold = new Font(PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            //    var fontBoldS = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);

            //    var fontExBold1 = new Font(PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            //    var fontBold1 = new Font(PrivateFontCollection.Families[0], 16, FontStyle.Bold);
            //    var fontBoldS1 = new Font(PrivateFontCollection.Families[0], 15, FontStyle.Bold);
            //    //draw main label
            //    e.Graphics.DrawString(
            //        MainForm.resManager.GetString("DrawControlLibrary_Product", MainForm.cultureInfo),
            //        fontExBold, new SolidBrush(Constant.Green), 8, 13, formatCl);
            //    e.Graphics.DrawString(
            //        MainForm.resManager.GetString("DrawControlLibrary_Advanced", MainForm.cultureInfo),
            //        fontExBold, new SolidBrush(Constant.Green), 8, 55, formatCl);

            //    // LongTN - thay đổi giao diện: thêm khoảng trống show list item
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("DrawControlLibrary_Total_Amount", MainForm.cultureInfo), 
            //    //    fontExBold, new SolidBrush(Constant.Green), 290 - 5, 13,
            //    //    formatCr);

            //    //draw quantity
            //    e.Graphics.DrawString(quantity.ToString(),
            //        fontBold1, new SolidBrush(Constant.White), 8, 28, formatCl);
            //    //draw payment
            //    e.Graphics.DrawString(payment,
            //        fontBoldS1, new SolidBrush(Constant.Green), 290 - 5, 22, formatCr);
            //    //draw total payment
            //    e.Graphics.DrawString(totalPayment,
            //        fontBold1, new SolidBrush(Constant.White), 290 - 5, 46, formatCr);


            //    //draw discount
            //    GraphicsPath path;
            //    if (!string.IsNullOrEmpty(discount))
            //    {
            //        path = DrawUtility.DrawTagRectangle(138, 37, 33, 14, 5, false);
            //        e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //        e.Graphics.DrawString(discount, fontBoldS, new SolidBrush(Constant.Brown),
            //            new RectangleF(139, 37, 32, 14),
            //            formatCl);
            //    }

            //    path = DrawUtility.DrawBorderRadiusRectangle(
            //        new Rectangle(290 - 67, 100 - 23, 67, 25), 25, 0, 0, 0);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);


            //    // LongTN - thay đổi giao diện: thêm khoảng trống show list item
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("Received", MainForm.cultureInfo), fontBold, new SolidBrush(Constant.Brown),
            //    //    new RectangleF(290 - 62, 100 - 23, 67, 25), formatCc);
            //}

            //public static void DrawPanel(PaintEventArgs e, int height)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //    var path = DrawUtility.DrawSmoothEdgeRectangle(0, 4, 290, height - 4 - 1, 4, 0, 4,
            //        0);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //    e.Graphics.DrawPath(new Pen(Constant.White, 1), path);

            //    path = new GraphicsPath();
            //    path.AddLine(6 + 20 * 2, 59, 290 / 2 - 29 - 2, 59);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //    e.Graphics.DrawPath(new Pen(Constant.Brown, 2), path);
            //    path = new GraphicsPath();
            //    path.AddLine(290 - 6 - 20 * 2, 59, 290 / 2 + 29 + 2,
            //        59);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //    e.Graphics.DrawPath(new Pen(Constant.Brown, 2), path);

            //    var font = new Font(PrivateFontCollection.Families[0], 12, FontStyle.Regular);
            //    var format = new StringFormat
            //    {
            //        Alignment = StringAlignment.Far,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    // LongTN - thay đổi giao diện: thêm khoảng trống show list item
            //    //e.Graphics.DrawString(
            //    //    MainForm.resManager.GetString("Exchange", MainForm.cultureInfo), font, new SolidBrush(Constant.Brown), 290 - 6,
            //    //    height - 82 - 42 + 10, format);
            //    //e.Graphics.DrawLine(new Pen(Constant.Brown), 6,
            //    //    height - 82 - 42 - 75, 290 - 6,
            //    //    height - 82 - 42 - 75);
            //    // 



            //    //e.Graphics.DrawString("TOTAL", font, new SolidBrush(Constant.Brown), MarginLeft,
            //    //    height - ExchangeMarginBottom - PaymentButtonHeight - 136);
            //    //e.Graphics.DrawLine(new Pen(Constant.Brown), MarginLeft,
            //    //    height - ExchangeMarginBottom - PaymentButtonHeight - 146, Right - MarginLeft,
            //    //    height - ExchangeMarginBottom - PaymentButtonHeight - 146);

            //}

            public static void DrawTypeToggleButton(object sender, PaintEventArgs e)
            {
                var label = (Label)sender;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(new Pen(Constant.Brown, 2), 0, 0, 20 * 2, 20 * 2);

                var image1B = Resources.cup4s;
                var image1W = Resources.cup4s_2;
                var image2B = Resources.delivery_brown;
                var image2W = Resources.delivery_white;
                if (label.TabIndex == 0)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Constant.Brown), 1, 1, 20 * 2 - 2,
                        20 * 2 - 2);
                }
                if (label.Name.Contains("Delivery"))
                {
                    e.Graphics.DrawImage(
                        label.TabIndex == 1
                            ? image2B
                            : image2W,
                        20 / 2, 20 / 2, 20, 20);
                }
                else
                {
                    e.Graphics.DrawImage(
                        label.TabIndex == 1
                            ? image1B
                            : image1W,
                        20 / 2, 20 / 2, 20, 20);
                }
                label.Width = 20 * 2 + 1;
                label.Height = 20 * 2 + 1;
            }

            public static void DrawTableButton(object sender, PaintEventArgs e)
            {
                var table = (Label)sender;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor), 1), 0, 0, 29 * 2, 29 * 2);
                e.Graphics.DrawEllipse(new Pen(Constant.White, 2), 1, 1, 29 * 2 - 2,
                    29 * 2 - 2);
                e.Graphics.FillEllipse(new SolidBrush(Constant.Brown), 2, 2, 29 * 2 - 4,
                    29 * 2 - 4);
                var font = new Font(PrivateFontCollection.Families[0], 20);
                var style = new StringFormat
                {
                    LineAlignment = StringAlignment.Center,
                    Alignment = StringAlignment.Center
                };
                e.Graphics.DrawString(table.Text, font, new SolidBrush(Constant.White), 29 - 1,
                    29 + 1, style);
            }

            //public static void DrawReceivedTextBox(object sender, PaintEventArgs e)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //    var textBox = (Label)sender;
            //    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, 290 - 6 * 2, 35, 5);
            //    textBox.Width = 290 - 6 * 2 + 1;
            //    textBox.Height = 35 + 1;
            //    var font = new Font(PrivateFontCollection.Families[0], 12, FontStyle.Bold);
            //    var format = new StringFormat
            //    {
            //        Alignment = StringAlignment.Far,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    e.Graphics.FillPath(new SolidBrush(Constant.Brown), path);
            //    e.Graphics.DrawPath(new Pen(Constant.White, 1), path);
            //    e.Graphics.DrawString(textBox.Text, font, new SolidBrush(Constant.White), textBox.Width - 4,
            //        textBox.Height / 2, format);
            //}

            public static void DrawPaymentButton(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                var textBox = (Control)sender;
                var path = DrawUtility.DrawSmoothEdgeRectangleWithHaft(0, 0, 350,
                    50 - 4, -4, 4, 196);
//                var path = DrawUtility.DrawSmoothEdgeRectangleWithHaft(0, 0, 350,
//                    50 - 4, -4, 4, 200);
                e.Graphics.FillPath(new SolidBrush(Constant.Orange), path);
                e.Graphics.DrawPath(new Pen(Constant.White, 1), path);
                var font = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Bold);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var x = (float)((200) / 2.0);
                var y = (float)(50 / 2.0) + 3;
                e.Graphics.DrawString(textBox.Tag.ToString(), font, new SolidBrush(Constant.White), x, y, format);
                textBox.Width = 200 - 2;
                textBox.Height = 50 + 2;
            }

            public static void DrawCancelButton(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                var textBox = (Label)sender;
                var path = DrawUtility.DrawSmoothEdgeRectangleWithHaft(-200, 0,
                    350 - 196,
//                    50 - 4, -4, 4, 196);
                    50 - 4, -4, 4, 196 - 350);
                e.Graphics.FillPath(new SolidBrush(Constant.Gray2), path);
                e.Graphics.DrawPath(new Pen(Constant.White, 1), path);
                var font = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Bold);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var x = (int)((350 - 200 - 2) / 2.0) + 20;
                var y = (int)(50 / 2.0);
                var image = new Bitmap(Resources.close, new Size(20, 20));
                e.Graphics.DrawImage(image, new Point(x - 10, y - 10));
                textBox.Width = 350 - 160 - 2;
                textBox.Height = 50 + 2;
            }

            public static class OrderItemList
            {
                public const int OrderItemHeight = 52;
                public const int PagingButtonHeight = 40;
                public const int PagingButtonWidth = 90;

                //public static void DrawOrderItem(object sender, PaintEventArgs e, string name, string quantity,
                //    string price, string finalAmount, string discountPercent, string additional = null,
                //    bool isDiscounted = false, bool isFirstItem = true, int parentQuantity = 0)
                //public static void DrawOrderItem(object sender, PaintEventArgs e, List<OrderDetailEditViewModel> orderDetails)
                //{
                //    var item = (OrderItemControl)sender;
                //    item.Height = OrderItemHeight * orderDetails.Count;
                //    item.Width = 290;


                //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                //    //New Size - Sinh
                //    var fontR = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Regular);
                //    var fontB = new Font(PrivateFontCollection.Families[0], 9, FontStyle.Bold);
                //    var fontBs = new Font(PrivateFontCollection.Families[0], 8, FontStyle.Bold);
                //    var fontS = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Strikeout);

                //    var formatCr = new StringFormat
                //    {
                //        Alignment = StringAlignment.Far,
                //        LineAlignment = StringAlignment.Center
                //    };
                //    var formatCl = new StringFormat
                //    {
                //        Alignment = StringAlignment.Near,
                //        LineAlignment = StringAlignment.Center
                //    };
                //    var brush1 = new SolidBrush(Constant.Brown);
                //    var brush2 = new SolidBrush(Constant.Green);
                //    var pen = new Pen(Constant.Brown);

                //    //Change color
                //    if (item.IsActive)
                //    {
                //        brush1 = new SolidBrush(Constant.Green);
                //        pen = new Pen(Constant.Green);
                //        brush2 = new SolidBrush(Constant.Brown);
                //        e.Graphics.FillRectangle(brush2, 0, 0, item.Width, item.Height);
                //    }

                //    for (int i = 0; i < orderDetails.Count; i++)
                //    {
                //        var od = orderDetails[i];
                
                //        if (od.DiscountRate > 0)
                //        {
                //            var path = DrawUtility.DrawTagRectangle(290 - 40, 17 + OrderItemHeight * i, 34, 12, 5, false);
                //            e.Graphics.FillPath(brush1, path);
                //            e.Graphics.DrawString(od.DiscountRate.ToString() + " %", fontB, brush2, new RectangleF(290 - 40, 17 + OrderItemHeight * i, 34, 12),
                //                formatCl);
                //        }

                //        if (i == 0)
                //        {
                //            //draw quantity
                //            e.Graphics.DrawString(od.ItemQuantity.ToString(), fontR, brush1, 10, 2);

                //            //draw name
                //            e.Graphics.DrawString(od.ProductName, fontR, brush1, 40, 2);

                //            //draw price
                //            e.Graphics.DrawString(od.UnitPrice.ToString("N0"), fontB, brush1, 40, 17);
                //            e.Graphics.DrawString(od.FinalAmount.ToString("N0"), fontB, brush1, 290 - 5, 40, formatCr);
                //        }
                //        else
                //        {
                //            //int tmpQuantity = int.Parse(quantity);
                //            //tmpQuantity = tmpQuantity / parentQuantity;

                //            string strTmpQuantity = "x " + od.ItemQuantity.ToString();
                //            //draw quantity
                //            e.Graphics.DrawString(strTmpQuantity, fontR, brush1, 40, 2 + OrderItemHeight * i);

                //            //draw name
                //            e.Graphics.DrawString(od.ProductName, fontR, brush1, 65, 2 + OrderItemHeight * i);

                //            //draw price
                //            e.Graphics.DrawString(od.UnitPrice.ToString(), fontB, brush1, 60, 17 + OrderItemHeight * i);
                //            //e.Graphics.DrawString(finalAmount, fontB, brush1, 290 - 5, 40, formatCr);
                //        }


                //        //draw additional field
                //        if (!string.IsNullOrEmpty(od.Notes))
                //        {
                //            string notes = od.Notes.Replace("|", " ");
                //            var size = e.Graphics.MeasureString(od.Notes, fontBs);
                //            var path = DrawUtility.DrawBorderRadiusRectangle(40, 33 + OrderItemHeight * i, (int)(40 + size.Width + 8), 45 + OrderItemHeight * i, 1);
                //            e.Graphics.FillPath(brush1, path);
                //            e.Graphics.DrawString(od.Notes, fontBs, brush2, 45, 40 + OrderItemHeight * i, formatCl);
                //        }

                //        //draw end line khi sản phẩm phía sau != extra
                //        //var pen1 = new Pen(Constant.Brown);
                //        //if (i > 0)
                //        //{
                //        //    // Khi sản phẩm phía sau là extra, vẽ đường màu xanh (trùng OrderPanel)
                //        //    pen1 = new Pen(Constant.Green);
                //        //}

                //        //e.Graphics.DrawLine(pen1, 2, OrderItemHeight * (i+1) - 1, 290 - 2,
                //        //         OrderItemHeight * (i + 1) - 1);
                //    }

                //    var pen1 = new Pen(Constant.Brown);
                //    e.Graphics.DrawLine(pen1, 2, item.Height - 1, 290 - 2,
                //            item.Height - 1);
                                      
                //}

                public static void DrawPagingButton(object sender, PaintEventArgs e)
                {
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    var button = (Label)sender;
                    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, PagingButtonWidth - 1, PagingButtonHeight - 1,
                        2);

                    e.Graphics.DrawPath(new Pen(Constant.Brown), path);
                    if (button.Enabled)
                    {
                        e.Graphics.FillPath(new SolidBrush(Constant.Brown), path);
                    }
                    if (button.Name.Contains("Down"))
                    {
                        path = new GraphicsPath();
                        path.AddLine(PagingButtonWidth / 2 - 7, PagingButtonHeight / 2 + 4, PagingButtonWidth / 2 + 7,
                            PagingButtonHeight / 2 + 4);
                        path.AddLine(PagingButtonWidth / 2 + 7, PagingButtonHeight / 2 + 4, PagingButtonWidth / 2,
                            PagingButtonHeight / 2 - 4);
                        e.Graphics.FillPath(new SolidBrush(button.Enabled ? Constant.White : Constant.Brown), path);
                    }
                    else
                    {
                        path = new GraphicsPath();
                        path.AddLine(PagingButtonWidth / 2 - 7, PagingButtonHeight / 2 - 4, PagingButtonWidth / 2 + 7,
                            PagingButtonHeight / 2 - 4);
                        path.AddLine(PagingButtonWidth / 2 + 7, PagingButtonHeight / 2 - 4, PagingButtonWidth / 2,
                            PagingButtonHeight / 2 + 4);

                        e.Graphics.FillPath(new SolidBrush(button.Enabled ? Constant.White : Constant.Brown), path);
                    }
                }
            }
        }

        public static class CategoryPanel
        {
            public static int Bottom = 40;

            public static void DrawPanel(PaintEventArgs e, int width)
            {
                //top category
                var rect = new Rectangle(0, 2, width, Bottom - 4);
                e.Graphics.DrawRectangle(new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor), 2), rect);
                rect = new Rectangle(rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
                e.Graphics.FillRectangle(new SolidBrush(Constant.White), rect);
            }

            public static void DrawPanelGray(PaintEventArgs e, int width)
            {
                //top category
                var rect = new Rectangle(0, 2, width, Bottom - 4);
                e.Graphics.DrawRectangle(new Pen(Constant.Gray2, 2), rect);
                rect = new Rectangle(rect.Left, rect.Top + 1, rect.Width, rect.Height - 2);
                e.Graphics.FillRectangle(new SolidBrush(Constant.White), rect);
            }

            public static class CategoryItem
            {
                public static void DrawItem(object sender, PaintEventArgs e, bool blackFont = false)
                {
                    var item = (CategoryItemControl)sender;
                    item.Height = Bottom - 4;
                    item.Top = 2;
                    var font = new Font(PrivateFontCollection.Families[0], 9, FontStyle.Bold);
                    var format = new StringFormat
                    {
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Near
                    };
                    var minWidth = (int)e.Graphics.MeasureString(item.CategoryName, font).Width;
                    //var minWidth = 100;
                    minWidth += item.ActiveImage.  Width + 10;
                    if (item.IsActive)
                    {
                        item.BackColor = Constant.Brown;
                        var topImage = item.Height / 2 - item.ActiveImage.Height / 2;
                        var leftImage = (item.Width - minWidth) / 2;
                        if (leftImage < 0)
                        {
                            item.Width = minWidth + 20;
                        }
                        leftImage = leftImage < 0 ? 20 : leftImage;
                        e.Graphics.DrawImage(item.ActiveImage, leftImage, topImage);
                        e.Graphics.DrawString(item.CategoryName, font, new SolidBrush(Constant.White),
                            leftImage + item.ActiveImage.Width + 10, Bottom / 2 - 2, format);
                    }
                    else
                    {
                        item.BackColor = Color.Transparent;
                        var topImage = item.Height / 2 - item.NormalImage.Height / 2 - 1;
                        var leftImage = (item.Width - minWidth) / 2;
                        if (leftImage < 0)
                        {
                            item.Width = minWidth + 20;
                        }
                        leftImage = leftImage < 0 ? 20 : leftImage;
                        e.Graphics.DrawImage(item.NormalImage, leftImage, topImage);
                        e.Graphics.DrawString(item.CategoryName, font, new SolidBrush(Constant.BlackBrown),
                                leftImage + item.NormalImage.Width + 10, Bottom / 2 - 2, format);

                    }
                }
            }
        }

        public static class PropertiesPanel
        {
            public const int Width = 665;
            public const int Height = 556;
            public const int PaddingTop = 40;
            public const int PaddingBottom = 45;
            public const int QuantityBoxHeight = 26;
            public const int QuantityBoxWidth = 66;
            public const int PropertySize = 75;
            public const int PropertyMargin = 1;

            //public static void DrawTopPanel(object sender, PaintEventArgs e)
            //{
            //    var control = (Control)sender;

            //    control.Height = PaddingTop;
            //    control.Top = 0;
            //    control.Left = 0;
            //    var formatLc = new StringFormat
            //    {
            //        Alignment = StringAlignment.Near,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    var formatRc = new StringFormat
            //    {
            //        Alignment = StringAlignment.Far,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    var formatCc = new StringFormat
            //    {
            //        Alignment = StringAlignment.Center,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    const int boxPadding = PaddingTop / 2 - QuantityBoxHeight / 2;
            //    var fontN = new Font(PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            //    var fontS = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Regular);
            //    e.Graphics.DrawString(control.Text, fontN, new SolidBrush(Constant.White), PaddingTop / 4, PaddingTop / 2,
            //        formatLc);
            //    e.Graphics.DrawString("TOTAL QUANTITY", fontS, new SolidBrush(Constant.White),
            //        control.Width - QuantityBoxWidth - boxPadding * 2, PaddingTop / 2, formatRc);
            //    e.Graphics.FillRectangle(new SolidBrush(Constant.DarkGrayPanel), control.Width - QuantityBoxWidth - boxPadding,
            //        boxPadding,
            //        QuantityBoxWidth, QuantityBoxHeight);
            //    e.Graphics.DrawString(control.TabIndex.ToString(), fontN, new SolidBrush(Constant.White),
            //        new RectangleF(control.Width - QuantityBoxWidth - boxPadding, boxPadding,
            //            QuantityBoxWidth, QuantityBoxHeight), formatCc);
            //    control.BackColor = Constant.GrayPanel;
            //}

            //public static void DrawBottomPanel(object sender, PaintEventArgs e)
            //{
            //    var control = (Control)sender;
            //    control.Height = PaddingBottom;
            //    control.Top = Height - PaddingBottom;
            //    control.Left = 0;
            //    control.BackColor = Constant.GrayPanel;
            //}

            //public static void DrawPaymentButton(object sender, PaintEventArgs e)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //    var label = (Label)sender;
            //    //var path = DrawUtility.DrawSmoothEdgeRectangleWithHaft(0, 0, 350,
            //    //    50 - 4, -4, 4, 200);
            //    var height = 40;
            //    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, 100, height, 0);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Orange), path);
            //    e.Graphics.DrawPath(new Pen(Constant.White, 1), path);
            //    var font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            //    var format = new StringFormat
            //    {
            //        Alignment = StringAlignment.Center,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    var x = (float)((200) / 2.0);
            //    var y = (float)(height / 2.0) + 3;
            //    e.Graphics.DrawString(label.Text, font, new SolidBrush(Constant.White), x, y, format);
            //    label.Width = 200 - 2;
            //    label.Height = height + 2;
            //}

            public static void DrawControlButtonR(object sender, PaintEventArgs e)
            {
                var control = (Control)sender;
                control.Width = 100;
                control.Height = PaddingBottom;
                control.BackColor = Color.Transparent;
                control.Margin = Padding.Empty;
//                var fontN = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Bold);
                var fontN = new Font("Tahoma", 11, FontStyle.Bold);
                var formatCc = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(control.Text, fontN, new SolidBrush(Constant.White),
                    new RectangleF(PointF.Empty, control.Size), formatCc);
                e.Graphics.DrawLine(new Pen(Constant.White, 2), 0, PaddingBottom / 4, 0, PaddingBottom - PaddingBottom / 4);
            }

            //public static void DrawControlButtonT(object sender, PaintEventArgs e)
            //{
            //    var control = (Control)sender;
            //    control.Width = 100;
            //    control.Height = PaddingBottom;
            //    control.BackColor = Color.Transparent;
            //    control.Margin = Padding.Empty;
            //    var fontN = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Bold);
            //    var formatCc = new StringFormat
            //    {
            //        Alignment = StringAlignment.Center,
            //        LineAlignment = StringAlignment.Center
            //    };
            //    e.Graphics.DrawString(control.Text, fontN, new SolidBrush(Constant.White),
            //        new RectangleF(PointF.Empty, control.Size), formatCc);
            //    e.Graphics.DrawLine(new Pen(Constant.White, 2), 0, PaddingBottom / 4, 0, PaddingBottom - PaddingBottom / 4);
            //}

            public static void DrawControlButton(object sender, PaintEventArgs e)
            {
                var control = (Control)sender;
                control.Width = 100;
                control.Height = PaddingBottom;
                control.BackColor = Color.Transparent;
                control.Margin = Padding.Empty;
                var fontN = new Font(PrivateFontCollection.Families[0], 11, FontStyle.Bold);
                var formatCc = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(control.Text, fontN, new SolidBrush(Constant.White),
                    new RectangleF(PointF.Empty, control.Size), formatCc);
            }

            public static void DrawGroupProperties(object sender, PaintEventArgs e)
            {
                var control = (Control)sender;
                control.Margin = Padding.Empty;
                var fontN = new Font(PrivateFontCollection.Families[0], 10, FontStyle.Bold);
                var formatCc = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(control.Name, fontN, new SolidBrush(Constant.Brown),
                    new RectangleF(15, 0, control.Width - 15, 60), formatCc);
            }

            public static void DrawProperty(object sender, PaintEventArgs e)
            {
                var control = (PropertyControl)sender;
                control.Margin = Padding.Empty;
                control.BackColor = Color.Transparent;
                //Ve lai kich thuoc (Size)
                if(control.Type == (int)PropertyTypeEnum.Size)
                {
                    control.Width = 150;
                    control.Height = PropertySize;
                }
                else
                {
                    control.Width = PropertySize;
                    control.Height = PropertySize;
                }
                
                var fontS = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
                var formatCc = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                var formatCl = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                if (!control.IsActive)
                {
                    if(control.Type == (int)PropertyTypeEnum.Size)
                    {
                        e.Graphics.DrawRectangle(new Pen(Constant.Brown, 2), 0, 0, 150, PropertySize);
                        //e.Graphics.DrawString(control.Name, fontS, new SolidBrush(Constant.Brown),
                        //    new RectangleF(control.X, control.Y, 150 - 10, 14), formatCl);
                    }else
                    {
                        e.Graphics.DrawRectangle(new Pen(Constant.Brown, 2), 0, 0, PropertySize, PropertySize);
                        //e.Graphics.DrawString(control.Name, fontS, new SolidBrush(Constant.Brown),
                        //    new RectangleF(2, 1, 75 - 10, 14), formatCl);
                    }
                    
                    //if (control.Property.RegularIcon != null)
                    //{
                    //    var width = control.Property.RegularIcon.Width > control.Property.RegularIcon.Height
                    //        ? 30
                    //        : control.Property.RegularIcon.Width * 30 / control.Property.RegularIcon.Height;
                    //    var height = control.Property.RegularIcon.Width > control.Property.RegularIcon.Height
                    //        ? control.Property.RegularIcon.Height * 30 / control.Property.RegularIcon.Width
                    //        : 30;

                    //    var image = new Bitmap(control.Property.RegularIcon, width, height);
                    //    e.Graphics.DrawImage(image, PropertySize / 2 - width / 2, PropertySize / 2 - height / 2);
                    //}
                    //else
                    {
                        var font = new Font(PrivateFontCollection.Families[0], control.TextSize,
                            FontStyle.Bold);
                        e.Graphics.DrawString(control.DisplayText, font, new SolidBrush(Constant.Brown),
                            new RectangleF(PointF.Empty, control.Size), formatCc);
                    }
                }
                else
                {
                    if (control.Type == (int)PropertyTypeEnum.Size)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Constant.Brown), 0, 0, 150, PropertySize);
                        //e.Graphics.DrawString(control.Name, fontS, new SolidBrush(Constant.Green),
                        //    new RectangleF(control.X, control.Y, 150 - 10, 14), formatCl);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Constant.Brown), 0, 0, PropertySize, PropertySize);
                        //e.Graphics.DrawString(control.Name, fontS, new SolidBrush(Constant.Green),
                        //    new RectangleF(2, 1, 75 - 10, 14), formatCl);
                    }
                    
                    //if (control.Property.ActiveIcon != null)
                    //{
                    //    var width = control.Property.ActiveIcon.Width > control.Property.ActiveIcon.Height
                    //        ? 30
                    //        : control.Property.ActiveIcon.Width * 30 / control.Property.ActiveIcon.Height;
                    //    var height = control.Property.ActiveIcon.Width > control.Property.ActiveIcon.Height
                    //        ? control.Property.ActiveIcon.Height * 30 / control.Property.ActiveIcon.Width
                    //        : 30;

                    //    var image = new Bitmap(control.Property.ActiveIcon, width, height);
                    //    e.Graphics.DrawImage(image,
                    //        PropertySize / 2 - width / 2, PropertySize / 2 - height / 2);
                    //}
                    //else
                    {
                        var font = new Font(PrivateFontCollection.Families[0], control.TextSize,
                            FontStyle.Bold);
                        string displayText = control.DisplayText.Replace(" ", Environment.NewLine);
                        e.Graphics.DrawString(displayText, font, new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)),
                            new RectangleF(PointF.Empty, control.Size), formatCc);
                    }
                }
            }
        }

        //public static class SplitProductPanel
        //{
        //    public static void DrawSplitPanel(Control sender, PaintEventArgs e, int quantity)
        //    {
        //        var path = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, sender.Size), 2);
        //        var path2 = DrawUtility.DrawBorderRadiusRectangle(1, 1, sender.Width - 1, sender.Height - 45, 2, 2, 0, 0);
        //        var path3 = DrawUtility.DrawBorderRadiusRectangle(1, sender.Height - 46, sender.Width - 1,
        //            sender.Height - 2, 0, 0, 2, 2);
        //        var font = new Font(PrivateFontCollection.Families[0], 22, FontStyle.Bold);
        //        var fontS = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
        //        var fontN = new Font(PrivateFontCollection.Families[0], 15, FontStyle.Bold);
        //        var formatcc = new StringFormat
        //        {
        //            Alignment = StringAlignment.Center,
        //            LineAlignment = StringAlignment.Center
        //        };
        //        e.Graphics.DrawPath(new Pen(Constant.Green, 2), path);
        //        e.Graphics.FillPath(new SolidBrush(Constant.DarkGrayPanel), path2);
        //        e.Graphics.FillPath(new SolidBrush(Constant.GrayPanel), path3);
        //        e.Graphics.DrawLine(new Pen(Constant.GrayPanel), sender.Width / 2, 113, sender.Width / 2,
        //            sender.Height - 45);
        //        e.Graphics.DrawString("/" + quantity, font, new SolidBrush(Constant.GrayPanel), sender.Width / 2, 60);
        //        e.Graphics.DrawString("SPLITING QUANTITY", fontS, new SolidBrush(Constant.White), sender.Width / 2, 12,
        //            formatcc);
        //        e.Graphics.DrawString("SPLIT", fontN, new SolidBrush(Constant.DarkGrayPanel), sender.Width / 2,
        //            sender.Height - 25,
        //            formatcc);
        //    }
        //}

        public static class BasicPanel
        {
            public const int TopPanelHeight = 52;

            public static void DrawTopPanel(object sender, PaintEventArgs e, string cashierName, string teminalName,
                Bitmap logo)
            {
                var panel = (Control)sender;
                var fontR = new Font(PrivateFontCollection.Families[0], 12, FontStyle.Regular);
                var fontB = new Font(PrivateFontCollection.Families[0], 12, FontStyle.Bold);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawImage(logo, new Point(10, TopPanelHeight / 2 - logo.Height / 2 + 1));
                e.Graphics.DrawString(teminalName, fontR, new SolidBrush(Constant.White), panel.Width - 14, 20, format);
                var size = e.Graphics.MeasureString(teminalName, fontR);
                e.Graphics.DrawString("TERMIAL", fontR, new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), panel.Width - 14 - size.Width,
                    20, format);
                size = e.Graphics.MeasureString(cashierName, fontB);
                e.Graphics.DrawString("CASHIER", fontR, new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), panel.Width - 14 - size.Width,
                    39, format);
                e.Graphics.DrawString(cashierName, fontB, new SolidBrush(Constant.White), panel.Width - 14, 39, format);
            }
        }

        //public static class CashButtonDraw
        //{
        //    public static void DrawButton(CashButton sender, PaintEventArgs e, bool isClick)
        //    {
        //        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        var path = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(0, 0, 130, 88), 44, 3, 3, 44);
        //        if (sender.HasValue)
        //        {
        //            e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
        //            e.Graphics.DrawPath(new Pen(Constant.Green, 2), path);
        //            e.Graphics.DrawLine(new Pen(Constant.Brown, 2), 20, 44, 120, 44);
        //        }
        //        else
        //        {
        //            e.Graphics.FillPath(new SolidBrush(Constant.Brown), path);
        //            e.Graphics.DrawPath(new Pen(Constant.BlackBrown, 4), path);
        //            e.Graphics.DrawLine(new Pen(Constant.BlackBrown, 2), 20, 44, 120, 44);
        //        }
        //        var font = new Font(PrivateFontCollection.Families[0], 14.5F, FontStyle.Bold);
        //        e.Graphics.DrawString(sender.Quantity.ToString(), font, new SolidBrush(Constant.BlackBrown), new RectangleF(75, 7, 55, 33), new StringFormat
        //        {
        //            Alignment = StringAlignment.Center,
        //            LineAlignment = StringAlignment.Near
        //        });

        //        if (isClick)
        //        {
        //            var path2 = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(0, 44, 130, 44), 3, 3, 3, 44);
        //            var color = Color.FromArgb(50, 255, 255, 255);
        //            e.Graphics.FillPath(new SolidBrush(color), path2);
        //            if (!sender.HasValue)
        //            {
        //                e.Graphics.DrawPath(new Pen(Constant.BlackBrown, 3), path2);
        //            }
        //        }
        //    }

        //    public static void DrawValue(PaintEventArgs e, string value, bool haveValue, bool isClicked)
        //    {
        //        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        var color = isClicked ? Constant.LightBrown : Constant.Brown;
        //        if (haveValue)
        //        {
        //            e.Graphics.DrawEllipse(new Pen(Constant.Brown), 0, 0, 76, 76);
        //            e.Graphics.FillEllipse(new SolidBrush(color), 0, 0, 76, 76);
        //            var font = new Font(PrivateFontCollectionExtraBold.Families[0], 12, FontStyle.Regular);
        //            e.Graphics.DrawString(value, font, new SolidBrush(Constant.Green), new RectangleF(0, 0, 76, 76), new StringFormat
        //            {
        //                Alignment = StringAlignment.Center,
        //                LineAlignment = StringAlignment.Center
        //            });
        //        }
        //        else
        //        {
        //            e.Graphics.DrawEllipse(new Pen(Constant.BlackBrown, 4), 0, 0, 85, 85);
        //            e.Graphics.FillEllipse(new SolidBrush(color), 0, 0, 85, 85);
        //            var font = new Font(PrivateFontCollectionExtraBold.Families[0], 12, FontStyle.Regular);
        //            e.Graphics.DrawString(value, font, new SolidBrush(Constant.Green), new RectangleF(0, 0, 85, 85), new StringFormat
        //            {
        //                Alignment = StringAlignment.Center,
        //                LineAlignment = StringAlignment.Center
        //            });
        //        }
        //    }

        //    public static void DrawMinute(PaintEventArgs e, bool isClick)
        //    {
        //        e.Graphics.DrawLine(new Pen(Constant.BlackBrown, 3), new Point(96, 22), new Point(114, 22));
        //    }
        //}

        //public static class GrowButtonDraw
        //{
        //    public static void DrawButton(GrowButton sender, PaintEventArgs e)
        //    {
        //        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        //        var size = new Size((int)(sender.Width - 1 - sender.BorderSize), (int)(sender.Height - 1 - sender.BorderSize));
        //        var start = new Point(1, 1);
        //        var path = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(start, size), 3, 3, 3, 3);
        //        e.Graphics.FillPath(new SolidBrush(sender.BackgroundColor), path);
        //        e.Graphics.DrawPath(new Pen(sender.BorderColor, sender.BorderSize), path);
        //        e.Graphics.DrawString(sender.StringValue, sender.Font, new SolidBrush(sender.ForeColor),
        //            new RectangleF(start, size), new StringFormat
        //            {
        //                Alignment = StringAlignment.Center,
        //                LineAlignment = StringAlignment.Center
        //            });
        //    }
        //}

        public static class FlatTextBoxDraw
        {
            public static void DrawTextBox(FlatTextBox sender, PaintEventArgs e)
            {
                var formatCl = new StringFormat
                {
                    Alignment = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center
                };
                var formatCr = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Center
                };
                var font = new Font(PrivateFontCollection.Families[0], 15, FontStyle.Bold);
                if (sender.Active)
                {
                    e.Graphics.DrawRectangle(new Pen(Constant.Brown), 0, 0, sender.Width - 1, sender.Height - 1);
                    e.Graphics.FillRectangle(new SolidBrush(Constant.White), 1, 1, sender.Width - 2, sender.Height - 2);
                    e.Graphics.DrawString(sender.TextValue, sender.Font, new SolidBrush(Constant.Brown),
                        new RectangleF(4, 1, sender.Width - 8, sender.Height - 2), formatCl);
                }
                else
                {
                    e.Graphics.DrawRectangle(new Pen(sender.BorderColor), 0, 0, sender.Width - 1, sender.Height - 1);
                    e.Graphics.FillRectangle(new SolidBrush(sender.BackgroundColor), 1, 1, sender.Width - 2,
                        sender.Height - 2);
                    e.Graphics.DrawString(sender.TextValue, sender.Font, new SolidBrush(sender.TextColor),
                        new RectangleF(4, 1, sender.Width - 8, sender.Height - 2), formatCl);
                }
                if (!string.IsNullOrEmpty(sender.TextValue) && sender.ShowClearButton)
                {
                    e.Graphics.DrawString("X", font, new SolidBrush(Constant.GrayPanel), sender.Width - 5,
                        sender.Height / 2 + 2, formatCr);
                }
            }
        }
    }
}
