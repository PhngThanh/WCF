using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.Properties;
using POS.SaleScreen.CustomControl;
using log4net;
using POS.CustomControl;
using POS.Utils;

namespace POS.SaleScreen
{
    public sealed class OrderPanelSummary : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public OrderPanelSummary()
        {
            try
            {

                Width = 290;
                Height = 100;
                MaximumSize = Size;
                MinimumSize = Size;
                BackColor = Constant.Brown;
                var icon = Resources.advanced;
                icon = icon.Width > icon.Height
                    ? new Bitmap(icon, new Size(25, icon.Height * 25 / icon.Width))
                    : new Bitmap(icon, new Size(icon.Width * 25 / icon.Height, 25));
            }
            catch (Exception ex)
            {
                log.Error("OrderPanelSummary - " + ex);
            }
        }


        private int _totalAmount;
        private int _finalAmount;
        private int _quantity;


        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                Invalidate();
            }
        }

        public int TotalAmount
        {
            get
            {
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
                Invalidate();
            }
        }

        public int FinalAmount
        {
            get { return _finalAmount; }
            set
            {
                _finalAmount = value;
                Invalidate();
            }
        }

        public int DiscountPercent { get; set; }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            string discount = DiscountPercent == 0 ? null : string.Format("{0}%", DiscountPercent);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
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
            var formatCc = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };


            var fontExBold = new Font(DrawControlLibrary.PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            var fontBold = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            var fontBoldS = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 7, FontStyle.Bold);

            var fontExBold1 = new Font(DrawControlLibrary.PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            var fontBold1 = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 16, FontStyle.Bold);
            var fontBoldS1 = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 15, FontStyle.Bold);
            //draw main label
            e.Graphics.DrawString(
                MainForm.ResManager.GetString("DrawControlLibrary_Product", MainForm.CultureInfo),
                fontExBold, new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), 8, 13, formatCl);
            //e.Graphics.DrawString(
            //    MainForm.resManager.GetString("DrawControlLibrary_Advanced", MainForm.cultureInfo),
            //    fontExBold, new SolidBrush(Constant.Green), 8, 55, formatCl);

            //draw quantity
            e.Graphics.DrawString(Quantity.ToString(),
                fontBold1, new SolidBrush(Constant.White), 8, 28, formatCl);
            //draw payment
            e.Graphics.DrawString(TotalAmount.ToString("N0"),
                fontBoldS1, new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor)), Width - 5, 22, formatCr);
            //draw total payment
            e.Graphics.DrawString(FinalAmount.ToString("N0"),
                fontBold1, new SolidBrush(Constant.White), Width - 5, 46, formatCr);


            //draw discount
            //GraphicsPath path;
            //if (!string.IsNullOrEmpty(discount))
            //{
            //    path = DrawUtility.DrawTagRectangle(138, 37, 33, 14, 5, false);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //    e.Graphics.DrawString(discount, fontBoldS, new SolidBrush(Constant.Brown),
            //        new RectangleF(139, 37, 32, 14),
            //        formatCl);
            //}

            //path = DrawUtility.DrawBorderRadiusRectangle(
            //    new Rectangle(290 - 67, 100 - 23, 67, 25), 25, 0, 0, 0);
            //e.Graphics.FillPath(new SolidBrush(Constant.Green), path);



            //DrawControlLibrary.OrderPanel.DrawTotalPanel(
            //    e, Quantity, SumOrderDetail.ToString("N0"), FinalAmount.ToString("N0"), discount);

            //try
            //{
            //    base.OnPaint(e);
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
            //    var fontExBold = new Font(DrawControlLibrary.PrivateFontCollectionExtraBold.Families[0], 8, FontStyle.Regular);
            //    var fontBold = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            //    var fontBoldS = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 7, FontStyle.Bold);
            //    //draw main label
            //    e.Graphics.DrawString("PRODUCTS", fontExBold, new SolidBrush(Constant.Green), 8, 13, formatCl);
            //    e.Graphics.DrawString("ADVANCED", fontExBold, new SolidBrush(Constant.Green), 8, 55, formatCl);
            //    e.Graphics.DrawString("TOTAL AMOUNT", fontExBold, new SolidBrush(Constant.Green), Right - 5, 13,
            //        formatCr);
            //    //draw quantity
            //    e.Graphics.DrawString(Quantity.ToString(), fontBold, new SolidBrush(Constant.White), 8, 28, formatCl);
            //    //draw SumOrderDetail
            //    e.Graphics.DrawString(SumOrderDetail.ToString("N0"), fontBoldS, new SolidBrush(Constant.Gray2), Right - 5, 28, formatCr);
            //    //draw Final Amount
            //    e.Graphics.DrawString(FinalAmount.ToString("N0"), fontBold, new SolidBrush(Constant.White), Right - 5, 44, formatCr);

            //    //draw discount
            //    GraphicsPath path;
            //    string discount = DiscountPercent == 0 ? null : string.Format("{0}%", DiscountPercent);
            //    if (!string.IsNullOrEmpty(discount))
            //    {
            //        path = DrawUtility.DrawTagRectangle(138, 37, 33, 14, 5, false);
            //        e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //        e.Graphics.DrawString(discount, fontBoldS, new SolidBrush(Constant.Brown),
            //            new RectangleF(139, 37, 32, 14),
            //            formatCl);
            //    }
            //    path = DrawUtility.DrawBorderRadiusRectangle(
            //        new Rectangle(Right - 67, 100 - 23, 67, 25), 25, 0, 0, 0);
            //    e.Graphics.FillPath(new SolidBrush(Constant.Green), path);
            //    e.Graphics.DrawString("Received", fontBold, new SolidBrush(Constant.Brown),
            //        new RectangleF(Right - 62, 100 - 23, 67, 25), formatCc);
            //}
            //catch (Exception ex)
            //{
            //}
        }

    }
}
