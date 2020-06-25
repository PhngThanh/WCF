using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Repository.ViewModels;
using POS.Repository;
using Rectangle = System.Drawing.Rectangle;

namespace POS.SaleScreen.CustomControl
{

    public sealed partial class ProductItemControl : Control
    {
        //public const int Top = 70;
        //public const int Bottom = 102;
        //public const int Right = 106;
        //public const int Radius = 5;
        //public const int Center = 53;

        //public const int Top = 75;
        //public const int Bottom = 107;
        //public const int Right = 111;
        //public const int Radius = 5;
        //public const int Center = 58;


        private const int cornerRadius = 5;
        private const int controlSize = 116;

        public ProductItemControl()
        {
            InitializeComponent();
            //            _minusLabel.Size = new Size(51, 56);
            _minusLabel.Size = new Size(controlSize / 2 + 1, controlSize / 2 - 14);
            _minusLabel.Location = new Point(3, controlSize / 2 + 12);
            //            _addLabel.Size = new Size(50, 56);
            _addLabel.Size = new Size(controlSize / 2 - 2, controlSize / 2 - 14);
            _addLabel.Location = new Point(controlSize / 2 + 5, controlSize / 2 + 12);
            //            _addLabel.Location = new Point(54,65);
        }

        private ProductViewModel _product;
        public ProductViewModel Product
        {
            get
            {
                return _product;
            }
        }

        public bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// Cap nhat thong tin ProductViewModel tu ben ngoai
        /// </summary>
        public void UpdateProduct(ProductViewModel p, int itemQuantity, int quantity)
        {
            bool change = false;
            if (_product == null || _product.Code != p.Code)
            //if (_product != p)
            {
                //Thay doi product
                _product = p;
                ItemQuantity = itemQuantity;
                Quantity = quantity;
                change = true;
            }
            else
            {
                //Cung ProductViewModel nhung doi so luong
                if (ItemQuantity != itemQuantity)
                {
                    ItemQuantity = itemQuantity;
                    change = true;
                }

                if (Quantity != quantity)
                {
                    if (StoreInfoManager.GetPosConfig(true).EnableQuantityColor.Trim().ToLower() == "true")
                    {
                        var menuInfo = StoreInfoManager.GetMenuInfo(false).MenuList
                                .SingleOrDefault(mii => mii.Code.Equals(_product.Code));
                        if (menuInfo != null)
                        {
                            if (Quantity < quantity)
                            {
                                menuInfo.Quantity--;

                                StoreInfoManager.UpdateMenuInfo();

                            }
                            else
                            {
                                menuInfo.Quantity++;

                                StoreInfoManager.UpdateMenuInfo();
                            }
                        }
                    }
                    Quantity = quantity;
                    change = true;
                }
            }

            if (change)
            {
                if (p != null)
                {
                    Visible = true;

                }
                else
                {
                    Visible = false;
                }
                Invalidate();
            }
        }


        //private int _quantity;
        public int ItemQuantity { get; set; }
        //{
        //    get
        //    {
        //        return _quantity;
        //    }

        //}

        /// <summary>
        /// Trong tinh huong san pham co nhieu OrderDetail
        /// </summary>
        public int Quantity { get; set; }







        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    MouseDown_Event(_addLabel, null);
        //}

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MouseUp_Event(_addLabel, null);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            //Full fill with color
            if (_product != null)
            {
                pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                var firstColor = Color.Transparent;
                var secondColor = Color.Transparent;

                if (StoreInfoManager.GetPosConfig(true).EnableQuantityColor.Trim().ToLower() == "true")
                {
                    int leftInStock = 0;
                    var menuinfo = StoreInfoManager.GetMenuInfo(false).MenuList
                        .FirstOrDefault(mii => mii.Code.Equals(_product.Code));
                    if (menuinfo != null)
                    {
                        leftInStock = menuinfo.Quantity;
                        if (leftInStock > 5)
                        {
                            firstColor = Constant.BlueProduct;
                            secondColor = Constant.White;
                        }
                        else
                        {
                            if (leftInStock > 0)
                            {
                                firstColor = Constant.Orange;
                                secondColor = Constant.White;
                            }
                            else
                            {
                                firstColor = Constant.RedProduct;
                                secondColor = Constant.White;
                            }
                        }
                    } else
                    {
                        //thay doi mau theo luong sp con lai trong ngay
                        int type = Product.ColorGroup ?? 0;
                        switch (type % 3)
                        {
                            case 0:
                                firstColor = Constant.BlueProduct;
                                secondColor = Constant.White;
                                break;
                            case 1:
                                firstColor = ColorScheme.Danger;
                                secondColor = Constant.White;
                                break;
                            case 2:
                                firstColor = Constant.GreenProduct;
                                secondColor = Constant.White;
                                break;
                        }
                    }

                   
                }
                else
                {
                    //thay doi mau theo luong sp con lai trong ngay
                    int type = Product.ColorGroup ?? 0;
                    switch (type % 3)
                    {
                        case 0:
                            firstColor = Constant.BlueProduct;
                            secondColor = Constant.White;
                            break;
                        case 1:
                            firstColor = ColorScheme.Danger;
                            secondColor = Constant.White;
                            break;
                        case 2:
                            firstColor = Constant.GreenProduct;
                            secondColor = Constant.White;
                            break;
                    }
                }

                //Ve so luong san pham
                if (ItemQuantity == 0)
                {
                    //Truong hop san pham chua duoc Active: ve ten san pham - va totalQuantity

                    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, controlSize + 5, controlSize - 1, cornerRadius - 1);
                    //var rect = new Rectangle(5, 12, Right - 5, 55);
                    var rect = new Rectangle(5, 18, controlSize, 55);

                    // middle line between minus label and add label
                    var startPointMiddleLine = new Point(_minusLabel.Size.Width + _minusLabel.Location.X,
                        controlSize / 2 + 13);
                    var endPointMiddleLine = new Point(_minusLabel.Size.Width + _minusLabel.Location.X, controlSize - 1);
                    path.AddLine(startPointMiddleLine.X, startPointMiddleLine.Y, endPointMiddleLine.X, endPointMiddleLine.Y);
                    //                    path.AddLine(Center, Bottom, Center, Top);
                    //                    path.AddLine(0, controlSize, controlSize, controlSize);
                    //                    path.AddLine(controlSize / 2, controlSize, controlSize / 2, controlSize);

                    // Fill color
                    pe.Graphics.FillPath(new SolidBrush(firstColor), path);
                    // Draw border
                    pe.Graphics.DrawPath(new Pen(secondColor, 1), path);

                    var formatC = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                    };
                    var formatL = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                    };
                    var formatR = new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                    };
                    // Draw ProductViewModel name.
                    //                    var font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
                    var font = new Font("Tahoma", 10, FontStyle.Bold);
                    string productName = _product.ProductName;
                    if (Product.ProductType == (int)ProductTypeEnum.General)
                    {
                        productName += "(*)";
                    }

                    if (StoreInfoManager.GetPosConfig(true).EnableQuantityColor.Trim().ToLower() == "true")
                    {
                        int leftInStock = 0;
                        var menuInfo = StoreInfoManager.GetMenuInfo(false).MenuList
                            .SingleOrDefault(mii => mii.Code.Equals(_product.Code));
                        if (menuInfo != null)
                        {
                            leftInStock = menuInfo.Quantity;
                        }
                        if (leftInStock > 0)
                        {
                            productName += " | " + leftInStock;
                        }
                    }

                    pe.Graphics.DrawString(productName, font, new SolidBrush(secondColor), rect, formatL);
                    // Draw Price
                    // Business rule can phai xem lai
                    //rect = new Rectangle(10, 30, 40, 65);
                    //pe.Graphics.DrawString(_product.Price.ToString(), font,
                    //    new SolidBrush(secondColor), rect, formatL);

                    //Draw total quantity
                    if ((Quantity != ItemQuantity) && Quantity != 0)
                    {
                        rect = new Rectangle(80, 4, 40, 65);
                        pe.Graphics.DrawString(Quantity.ToString(), font,
                            new SolidBrush(secondColor), rect, formatL);
                    }

                }
                //White background and color border
                else
                {
                    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, controlSize + 5, controlSize, cornerRadius);
                    //                    var path = DrawUtility.DrawBorderRadiusRectangle(0, 0, Right, Bottom, cornerRadius);
                    var border = DrawUtility.DrawBorderRadiusRectangle(1, 1, controlSize + 6 - 2, controlSize - 1, cornerRadius - 1);
                    //                    var border = DrawUtility.DrawBorderRadiusRectangle(1, 1, Right - 1, Bottom - 1, cornerRadius - 1);
                    var rect = new Rectangle(8, controlSize / 3, controlSize, 40);
                    //                    var rect = new Rectangle(8, Top - 32, Right - 5, 40);
                    //if (_product.ProductType == (int)ProductTypeEnum.General)
                    //{
                    //    path.AddLine(Left, Bottom, Right, Top);
                    //    rect.Y = Top - 32;
                    //}
                    //else
                    //{
                    //                  path.AddLine(58, 107, 58, 75);
                    //                    path.AddLine(controlSize / 2, controlSize, controlSize / 2, 75);
                    //path.AddLine(Center, Bottom, Center, Top);
                    //}
                    // middle line between minus label and add label
                    var startPointMiddleLine = new Point(_minusLabel.Size.Width + _minusLabel.Location.X,
                        controlSize / 2 + 13);
                    var endPointMiddleLine = new Point(_minusLabel.Size.Width + _minusLabel.Location.X, controlSize - 2);
                    path.AddLine(startPointMiddleLine.X, startPointMiddleLine.Y, endPointMiddleLine.X, endPointMiddleLine.Y);

                    // Draw line
                    pe.Graphics.FillPath(new SolidBrush(secondColor), path);
                    pe.Graphics.DrawPath(new Pen(secondColor, 1), path);
                    pe.Graphics.DrawPath(new Pen(firstColor, 1), border);

                    var formatC = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                    };
                    var formatL = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                    };
                    var formatR = new StringFormat
                    {
                        Alignment = StringAlignment.Far,
                    };
                    // Draw ProductViewModel name.
                    //                    var font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 7, FontStyle.Bold);
                    var font = new Font("Tahoma", 7, FontStyle.Bold);

                    var product_name = _product.ProductName;
                    if (StoreInfoManager.GetPosConfig(true).EnableQuantityColor.Trim().ToLower() == "true")
                    {
                        int leftInStock = 0;
                        var menuInfo = StoreInfoManager.GetMenuInfo(false).MenuList
                           .SingleOrDefault(mii => mii.Code.Equals(_product.Code));
                        if (menuInfo != null)
                        {
                            leftInStock = menuInfo.Quantity;
                        }

                        if (leftInStock > 0)
                        {
                            product_name += " | " + leftInStock;
                        }

                    }

                    pe.Graphics.DrawString(product_name, font, new SolidBrush(firstColor), rect, formatL);

                    // Draw price.
                    //font = new Font(PrivateFontCollection.Families[0], 7, FontStyle.Bold);
                    //rect = new Rectangle(0, 5, Right - 5, 20);
                    //e.Graphics.DrawString(price, font, new SolidBrush(firstColor), rect, formatR);
                    //Draw quantity
                    font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 21, FontStyle.Bold);
                    rect = new Rectangle(5, 4, Right - 5, 65);
                    pe.Graphics.DrawString(ItemQuantity.ToString(), font,
                        new SolidBrush(firstColor), rect, formatL);

                    //Draw total quantity
                    if ((Quantity != ItemQuantity) && Quantity != 0)
                    {
                        font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
                        rect = new Rectangle(80, 4, 40, 65);
                        pe.Graphics.DrawString(Quantity.ToString(), font,
                            new SolidBrush(firstColor), rect, formatL);
                    }
                }

            }
            _addLabel.Invalidate();
            _minusLabel.Invalidate();
        }

        private void Paint_Event(object sender, PaintEventArgs e)
        {
            if (_product != null)
            {
                var label = (Label)sender;
                var g = e.Graphics;
                LinearGradientBrush linGrBrush = null;
                SolidBrush whiteBrush = null;
                SolidBrush mainBrush = null;

                int colorMode;
                bool colorFlag = false;
                if (StoreInfoManager.GetPosConfig(true).EnableQuantityColor.Trim().ToLower() == "true")
                {
                    int leftInStock = 0;
                    var menuInfo = StoreInfoManager.GetMenuInfo(false).MenuList
                        .SingleOrDefault(mii => mii.Code.Equals(_product.Code));
                    if (menuInfo != null)
                    {
                        leftInStock = menuInfo.Quantity;
                        colorMode = (ItemQuantity == 0)
                       ? (leftInStock > 5 ? 0 : (leftInStock > 0 ? 1 : 2))
                       : (leftInStock > 5 ? 3 : (leftInStock > 3 ? 4 : 5));
                        switch (colorMode)
                        {
                            case 0:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Constant.BlueProduct,
                                    Color.FromArgb(10, 159, 255));
                                whiteBrush = new SolidBrush(Constant.BlueProduct);
                                mainBrush = new SolidBrush(Constant.White);
                                break;
                            case 1:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Constant.Orange,
                                    Color.FromArgb(10, 159, 255));
                                whiteBrush = new SolidBrush(Constant.Orange);
                                mainBrush = new SolidBrush(Constant.White);
                                break;
                            case 2:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Constant.RedProduct,
                                    Color.FromArgb(10, 159, 255));
                                whiteBrush = new SolidBrush(Constant.RedProduct);
                                mainBrush = new SolidBrush(Constant.White);
                                break;
                            case 3:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Color.FromArgb(255, 255, 255),
                                    Color.FromArgb(180, 180, 180));
                                whiteBrush = new SolidBrush(Constant.White);
                                mainBrush = new SolidBrush(Constant.BlueProduct);
                                break;
                            case 4:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Color.FromArgb(255, 255, 255),
                                    Color.FromArgb(180, 180, 180));
                                whiteBrush = new SolidBrush(Constant.White);
                                mainBrush = new SolidBrush(Constant.Orange);
                                break;
                            case 5:
                                linGrBrush = new LinearGradientBrush(
                                    new Point(0, 0),
                                    new Point(0, label.Height),
                                    Color.FromArgb(255, 255, 255),
                                    Color.FromArgb(180, 180, 180));
                                whiteBrush = new SolidBrush(Constant.White);
                                mainBrush = new SolidBrush(Constant.RedProduct);
                                break;
                        }
                        colorFlag = true;
                    }
                    else
                    {
                        colorMode = (ItemQuantity == 0)
                        ? (Product.ColorGroup ?? 0) % 3
                        : (Product.ColorGroup ?? 0) % 3 + 3;
                    }
                }
                else
                {
                    colorMode = (ItemQuantity == 0)
                        ? (Product.ColorGroup ?? 0) % 3
                        : (Product.ColorGroup ?? 0) % 3 + 3;
                }
                if (!colorFlag)
                {
                    switch (colorMode)
                    {
                        case 0:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                Constant.BlueProduct,
                                Color.FromArgb(10, 159, 255));
                            whiteBrush = new SolidBrush(Constant.BlueProduct);
                            mainBrush = new SolidBrush(Constant.White);
                            break;
                        case 1:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                ColorScheme.Danger,
                                Color.FromArgb(10, 159, 255));
                            whiteBrush = new SolidBrush(ColorScheme.Danger);
                            mainBrush = new SolidBrush(Constant.White);
                            break;
                        case 2:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                Constant.GreenProduct,
                                Color.FromArgb(10, 159, 255));
                            whiteBrush = new SolidBrush(Constant.GreenProduct);
                            mainBrush = new SolidBrush(Constant.White);
                            break;
                        case 3:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                Color.FromArgb(255, 255, 255),
                                Color.FromArgb(180, 180, 180));
                            whiteBrush = new SolidBrush(Constant.White);
                            mainBrush = new SolidBrush(Constant.BlueProduct);
                            break;
                        case 4:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                Color.FromArgb(255, 255, 255),
                                Color.FromArgb(180, 180, 180));
                            whiteBrush = new SolidBrush(Constant.White);
                            mainBrush = new SolidBrush(ColorScheme.Danger);
                            break;
                        case 5:
                            linGrBrush = new LinearGradientBrush(
                                new Point(0, 0),
                                new Point(0, label.Height),
                                Color.FromArgb(255, 255, 255),
                                Color.FromArgb(180, 180, 180));
                            whiteBrush = new SolidBrush(Constant.White);
                            mainBrush = new SolidBrush(Constant.GreenProduct);
                            break;
                    }
                }
                

                var graphicsPath = DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, label.Size), 0, 0, 0, 0);
                //                var graphicsPath = label == _minusLabel
                //                    ? DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, label.Size), 0, 0, 0, 0)
                //                    : DrawUtility.DrawBorderRadiusRectangle(new Rectangle(Point.Empty, label.Size), 0, 0, 5, 0);

                if (_controlClicked)
                {
                    g.FillPath(linGrBrush, graphicsPath);
                }
                else
                {
                    g.FillPath(whiteBrush, graphicsPath);
                }
                //if (ProductViewModel.ProductType != (int)ProductTypeEnum.General)
                //{
                // ProductParentId == null => draw "+" and "-" label
                if (label.Text == @"-")
                {
                    g.DrawString("_",
                        label.Font,
                        mainBrush,
                        new RectangleF(0, -4, label.Width, label.Height),
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                }
                else
                {
                    g.DrawString("+",
                        label.Font,
                        mainBrush,
                        new RectangleF(0, 0, label.Width, label.Height),
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                }
                //}
            }
        }

        private bool _controlClicked;
        public Action<ProductViewModel, int> ChangeQuantityEvent;
        public Action<ProductViewModel> SelectGenericProductEvent;

        private void MouseUp_Event(object sender, MouseEventArgs e)
        {
            var label = (Label)sender;
            //_controlClicked = false;

            //if (_product.ProductType == (int)ProductTypeEnum.General)
            //{ 
            //    // General product
            //    //OrderDetailForm form = new OrderDetailForm(null, ProductViewModel, true);
            //    //form.Show();
            //    //SaleScreen3.orderDetailForm = new OrderDetailForm(null, ProductViewModel, true);
            //    //SaleScreen3.orderDetailForm.Show();

            //    //form.ProductViewModel = ProductViewModel;
            //    //if (SelectGenericProductEvent != null)
            //    //{
            //    //    Sele
            //    //    OrderDetailForm form = new OrderDetailForm(new List<OrderDetailEditViewModel>(), true);
            //    //    form.product = ProductViewModel;
            //    //    form.Show();ctGenericProductEvent(ProductViewModel);
            //    //}
            //}
            //else
            //{
            if (ChangeQuantityEvent != null)
            {
                if (label != _minusLabel)
                {
                    ChangeQuantityEvent(Product, 1);
                }
                else
                {
                    ChangeQuantityEvent(Product, -1);
                }
            }

            //}

            this.Invalidate();
        }

        //private bool _inscrease;
        //private void MouseDown_Event(object sender, MouseEventArgs e)
        //{
        //    var label = (Label)sender;
        //    _controlClicked = true;
        //    label.Invalidate();
        //    AutoSize = true;
        //    if (sender != _minusLabel)
        //    {
        //        _inscrease = true;
        //    }
        //    else
        //    {
        //        if (!AllowDelete()) return;
        //        _inscrease = false;
        //    }
        //}





        //private bool AllowDelete()
        //{


        //    return true;
        //}

        /// <summary>
        /// Set the control size
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="specified"></param>
        protected override void SetBoundsCore(int x, int y,
            int width, int height, BoundsSpecified specified)
        {
            // Set a fixed height for the control.
            base.SetBoundsCore(x, y, controlSize + 6, controlSize + 6, specified);
            //            base.SetBoundsCore(x, y, controlSize + 1, controlSize + 1, specified);
            //            base.SetBoundsCore(x, y, 107, 103, specified);
        }
    }
}
