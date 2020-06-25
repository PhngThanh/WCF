using System.Windows.Forms;
using POS.SaleScreen.CustomControl;
using System.Drawing.Drawing2D;
using System.Drawing;
using POS.CustomControl;
using POS.Repository.ViewModels;

namespace POS.SaleScreen
{
    public class CustomerItemControl : Label
    {
        //private Customer _customer;
        public CustomerViewModel Customer;

        private bool _isActive;

        private const int ItemHeight = 40;
        //int extraHeight = 30;

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

        public CustomerItemControl(CustomerViewModel c)
        {
            Customer = c;
            Height = ItemHeight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //New Size - Sinh
            var fontR = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            var fontB = new Font("Tahoma", 10, FontStyle.Bold);
            var fontBs = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 8, FontStyle.Bold);
            var fontS = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Strikeout);

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
            var pen = new Pen(Constant.Brown);

            //Change color
            if (IsActive)
            {
                brush1 = new SolidBrush(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                pen = new Pen(ColorScheme.GetColor(BootstrapColorEnum.MainColor));
                brush2 = new SolidBrush(Constant.Brown);
                e.Graphics.FillRectangle(brush2, 0, 0, Width, Height);
            }
            int yPos = 5;
                int xPos = 2;
                    //draw quantity
                    //e.Graphics.DrawString(od.ItemQuantity.ToString(), fontB, brush1, xPos, yPos);
                    xPos += 18; //20-quantity
                                //draw name

                    e.Graphics.DrawString(Customer.PhoneNumber, fontB, brush1, xPos, yPos);
                    xPos += 160;
                    //if (!string.IsNullOrEmpty(mainOrderDetail.Notes) && productName.Length > 25)
                    //{
                    //    itemHeight = 60;
                    //}

                Rectangle rect = new Rectangle(xPos, yPos, Width / 2, 40);

                e.Graphics.DrawString(Customer.CustomerName, fontB, brush1, rect, formatCr);
    
        }
    }
}
