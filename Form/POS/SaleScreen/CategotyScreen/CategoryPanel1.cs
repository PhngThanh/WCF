using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.SaleScreen.CustomControl;
using log4net;

namespace POS.SaleScreen
{
    public partial class CategoryPanel1 : UserControl
    {
        private List<CategoryBar> _moreBars;
        private Dictionary<int, List<CategoryBar>> _dicSubCategoryBars;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();

        private static int _maxProductPage = 1;
        private static int _currentProductPage = 1;
        private static int _currentCategoryId = -1;
        private SearchProductPanel _searchProductPanel = new SearchProductPanel();

        public CategoryPanel1()
        {
            _moreBars = new List<CategoryBar>();
            _dicSubCategoryBars = new Dictionary<int, List<CategoryBar>>();

            InitializeComponent();
            ShowCategoryOnBar();
            CreateProductsPanel();
            Controls.Add(_searchProductPanel);
        }

        #region Category

        private void ShowCategoryOnBar()
        {
            // TODO: need to refactor code 

            #region Init
            var fontTahoma9B = new Font("Verdana", 10, FontStyle.Bold);
            var textColor = Color.Black;
            var imageColor = Color.Black;
            var backgroudColor = BootstrapColorEnum.StripColor;
            var activeBackgroudColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            var height = this.barTop.Height - 7;
            //var width = 110;
            var buttonType = POS.CustomControl.ButtonType.Toggle;
            var isActive = false;
            var sizeMode = PictureBoxSizeMode.CenterImage;
            // var isAutoScaleWidth = true;
            int barWidth = 682;
            var screenResolution = MainForm.StoreInfo.ComputerScreenResolution.Trim().ToLower();
            if (screenResolution == "hd")
            {
                barWidth = 900;
            }
            else if (screenResolution == "fhd")
            {
                barWidth = 1400;
            }
            #endregion

            //Add 4 phtần tử ở trên
            int remainTopWidth = barWidth;
            int miniumWidth = 138;

            #region Search menu
            //Add searchProductPanel for mode SUPERMARKET
            if (MainForm.PosConfig.EnableQuickSaleMode.Trim().ToLower() == "true")
            {
                var cateSearch = new BootstrapButton()
                {
                    Top = 2,
                    BackgroudBootstrapColor = backgroudColor,
                    ActiveBackgroudColor = activeBackgroudColor,
                    ImageCss = "heart",
                    ImageFontSize = 16,
                    SizeMode = sizeMode,
                    TextValue = "Tìm kiếm",
                    Height = height,
                    TextFont = fontTahoma9B,
                    TextColor = textColor,
                    ImageColor = imageColor,
                    ButtonValue = "-2",
                    Type = buttonType,
                    IsActive = isActive,
                    Size = new Size(miniumWidth, height),
                    Location = new Point(barWidth - remainTopWidth, 3),
                    IsAutoScaleWidth = false
                };
                // cateMostUse.Width = cateMostUse.Image.Width - 32;
                cateSearch.Click += categoryItem_Click;
                barTop.Controls.Add(cateSearch);

                remainTopWidth -= cateSearch.Width;
            }
            #endregion

            #region Most Ordered Menu
            if (MainForm.PosConfig.IsShowMostOrderMenu.Trim().ToLower() == "true")
            {
                var cateMostUse = new BootstrapButton()
                {
                    Top = 2,
                    BackgroudBootstrapColor = backgroudColor,
                    ActiveBackgroudColor = activeBackgroudColor,
                    ImageCss = "heart",
                    ImageFontSize = 16,
                    SizeMode = sizeMode,
                    TextValue = "Thường dùng",
                    Height = height,
                    TextFont = fontTahoma9B,
                    TextColor = textColor,
                    ImageColor = imageColor,
                    ButtonValue = "-1",
                    Type = buttonType,
                    IsActive = isActive,
                    Size = new Size(miniumWidth, height),
                    Location = new Point(barWidth - remainTopWidth, 3),
                    IsAutoScaleWidth = false
                };
                cateMostUse.Click += categoryItem_Click;
                barTop.Controls.Add(cateMostUse);

                remainTopWidth -= cateMostUse.Width;
            }
            #endregion

            List<CategoryViewModel> _categories;

            _categories = Program.context.getAvailableCategories().Where(a => a.IsExtra == 0 &&
                                                                a.ParentCateId != null && a.ParentCateId > 0)
                                                        .OrderBy(a => a.DisplayOrder)
                                                        .ToList();

            if (MainForm.PosConfig.UsingCategoryLevel.Trim().ToLower() == "true")
            {
                #region Phân cấp Category (Cha - con)
                var superCategory =
                   Program.context.getAvailableCategories().Where(a => a.IsExtra == 0 &&
                                                               a.ParentCateId == null)
                                                        .OrderByDescending(a => a.Code)
                                                        .ToList();

                foreach (var superCate in superCategory)
                {
                    _dicSubCategoryBars.Add(superCate.Code, new List<CategoryBar>());
                }

                //Load top menu
                int cateCount = 0;
                do
                {
                    if (cateCount == superCategory.Count)
                    {
                        break;
                    }

                    CategoryViewModel cate = superCategory.ElementAt(cateCount);
                    var item = new BootstrapButton()
                    {
                        BackgroudBootstrapColor = backgroudColor,
                        ActiveBackgroudColor = activeBackgroudColor,
                        ImageCss =
                            string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                        ImageFontSize = 16,
                        SizeMode = sizeMode,
                        TextValue = cate.Name,
                        Height = height,
                        TextFont = fontTahoma9B,
                        TextColor = textColor,
                        ImageColor = imageColor,
                        ButtonValue = (cate.Code * (-1)).ToString(),
                        Type = buttonType,
                        IsActive = isActive,
                        Size = new Size(miniumWidth, height),
                        Location = new Point(barWidth - remainTopWidth, 3),
                        IsAutoScaleWidth = false
                    };
                    item.Click += ChangePageControl_Click;
                    barTop.Controls.Add(item);
                    remainTopWidth -= item.Width;
                    cateCount++;
                } while (remainTopWidth > miniumWidth);


                //Add 6 phần tử bên dưới
                int remainBottomWidth = barWidth;
                do
                {
                    if (cateCount == superCategory.Count)
                    {
                        break;
                    }

                    CategoryViewModel cate = superCategory.ElementAt(cateCount);
                    var item = new BootstrapButton()
                    {
                        BackgroudBootstrapColor = backgroudColor,
                        ActiveBackgroudColor = activeBackgroudColor,
                        ImageCss =
                            string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                        ImageFontSize = 16,
                        SizeMode = sizeMode,
                        TextValue = cate.Name,
                        Height = height,
                        TextFont = fontTahoma9B,
                        TextColor = textColor,
                        ImageColor = imageColor,
                        ButtonValue = (cate.Code * (-1)).ToString(),
                        Type = buttonType,
                        IsActive = isActive,
                        Size = new Size(miniumWidth, height),
                        Location = new Point(barWidth - remainBottomWidth, 3),
                        IsAutoScaleWidth = false
                    };
                    item.Click += categoryItem_Click;
                    barBottom.Controls.Add(item);
                    remainBottomWidth -= item.Width;
                    cateCount++;

                    if (superCategory.Count - cateCount == 1)
                    {
                        cate = superCategory.ElementAt(cateCount);
                        var item1 = new BootstrapButton()
                        {
                            BackgroudBootstrapColor = backgroudColor,
                            ActiveBackgroudColor = activeBackgroudColor,
                            ImageCss =
                                string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                            ImageFontSize = 16,
                            SizeMode = sizeMode,
                            TextValue = cate.Name,
                            Height = height,
                            TextFont = fontTahoma9B,
                            TextColor = textColor,
                            ImageColor = imageColor,
                            ButtonValue = "-2",
                            Type = buttonType,
                            IsActive = isActive,
                            Size = new Size(miniumWidth, height),
                            Location = new Point(barWidth - remainBottomWidth, 3),
                            IsAutoScaleWidth = false
                        };
                        item1.Click += ChangePageControl_Click;
                        barBottom.Controls.Add(item1);
                        remainBottomWidth -= item1.Width;
                        cateCount++;

                        //return;
                    }
                } while (remainBottomWidth > miniumWidth * 2); //chua cho danh cho nut More

                foreach (var item in _dicSubCategoryBars)
                {
                    var countBarMore = 1;
                    cateCount = 0;
                    // Lấy tất cả danh mục sản phẩm là con của danh mục item
                    var categories = _categories.Where(c => c.ParentCateId == item.Key).ToList();
                    do
                    {
                        int remainMoreWidth = barWidth;
                        var subCategoryBar = new CategoryBar()
                        {
                            Anchor =
                                ((System.Windows.Forms.AnchorStyles)
                                    (((System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left)
                                      | System.Windows.Forms.AnchorStyles.Right))),
                            BackColor = System.Drawing.Color.White,
                            //Location = new System.Drawing.Point(0, -100),
                            Location = new System.Drawing.Point(0, 450 - (countBarMore * 49)),
                            Margin = new System.Windows.Forms.Padding(0),
                            Name = "barMore",
                            Size = new System.Drawing.Size(628, 50),
                            TabIndex = 1,
                            Visible = true,
                        };
                        item.Value.Add(subCategoryBar);
                        this.Controls.Add(subCategoryBar);

                        countBarMore++;
                        if (categories.Count > 0)
                            do
                            {
                            
                            CategoryViewModel cate = categories.ElementAt(cateCount);
                            if (remainMoreWidth < miniumWidth * 2)
                            {
                                break;
                            }
                            var bootstrapButton = new BootstrapButton()
                            {
                                BackgroudBootstrapColor = backgroudColor,
                                ActiveBackgroudColor = activeBackgroudColor,
                                ImageCss =
                                    string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss)
                                        ? cate.ImageFontAwsomeCss
                                        : "glass",
                                ImageFontSize = 16,
                                SizeMode = sizeMode,
                                TextValue = cate.Name,
                                Height = height,
                                TextFont = fontTahoma9B,
                                TextColor = textColor,
                                ImageColor = imageColor,
                                ButtonValue = cate.Code.ToString(),
                                Type = buttonType,
                                IsActive = isActive,
                                Size = new Size(miniumWidth, height),
                                Location = new Point(barWidth - remainMoreWidth, 3),
                                IsAutoScaleWidth = false
                            };
                            bootstrapButton.Click += categoryItem_Click;
                            subCategoryBar.Controls.Add(bootstrapButton);
                            remainMoreWidth -= bootstrapButton.Width;
                            cateCount++;
                            if (cateCount >= categories.Count)
                            {
                                break;
                            }
                        } while (remainMoreWidth > miniumWidth);
                    } while (cateCount < categories.Count);
                }
                #endregion
            }
            else
            {
                #region Mode hiển thị tất cả danh mục theo thứ tự
                _categories = Program.context.getAvailableCategories().Where(a => a.IsExtra == 0)
                                                        .OrderBy(a => a.DisplayOrder)
                                                        .ToList();
                //Load top menu
                int cateCount = 0;
                do
                {
                    if (cateCount == _categories.Count)
                    {
                        break;
                    }

                    CategoryViewModel cate = _categories.ElementAt(cateCount);
                    var item = new BootstrapButton()
                    {
                        BackgroudBootstrapColor = backgroudColor,
                        ActiveBackgroudColor = activeBackgroudColor,
                        ImageCss =
                            string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                        ImageFontSize = 16,
                        SizeMode = sizeMode,
                        TextValue = cate.Name,
                        Height = height,
                        TextFont = fontTahoma9B,
                        TextColor = textColor,
                        ImageColor = imageColor,
                        ButtonValue = cate.Code.ToString(),
                        Type = buttonType,
                        IsActive = isActive,
                        Size = new Size(miniumWidth, height),
                        Location = new Point(barWidth - remainTopWidth, 3)
                    };
                    item.Click += categoryItem_Click;
                    barTop.Controls.Add(item);
                    remainTopWidth -= item.Width;
                    cateCount++;
                } while (remainTopWidth > miniumWidth);


                //Add 6 phần tử bên dưới
                int remainBottomWidth = barWidth;
                do
                {
                    if (cateCount == _categories.Count)
                    {
                        break;
                    }

                    CategoryViewModel cate = _categories.ElementAt(cateCount);
                    var item = new BootstrapButton()
                    {
                        BackgroudBootstrapColor = backgroudColor,
                        ActiveBackgroudColor = activeBackgroudColor,
                        ImageCss =
                            string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                        ImageFontSize = 16,
                        SizeMode = sizeMode,
                        TextValue = cate.Name,
                        Height = height,
                        TextFont = fontTahoma9B,
                        TextColor = textColor,
                        ImageColor = imageColor,
                        ButtonValue = cate.Code.ToString(),
                        Type = buttonType,
                        IsActive = isActive,
                        Size = new Size(miniumWidth, height),
                        Location = new Point(barWidth - remainBottomWidth, 3),
                    };
                    item.Click += categoryItem_Click;
                    barBottom.Controls.Add(item);
                    remainBottomWidth -= item.Width;
                    cateCount++;

                    if (_categories.Count - cateCount == 1)
                    {
                        cate = _categories.ElementAt(cateCount);
                        var item1 = new BootstrapButton()
                        {
                            BackgroudBootstrapColor = backgroudColor,
                            ActiveBackgroudColor = activeBackgroudColor,
                            ImageCss =
                                string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss) ? cate.ImageFontAwsomeCss : "glass",
                            ImageFontSize = 16,
                            SizeMode = sizeMode,
                            TextValue = cate.Name,
                            Height = height,
                            TextFont = fontTahoma9B,
                            TextColor = textColor,
                            ImageColor = imageColor,
                            ButtonValue = cate.Code.ToString(),
                            Type = buttonType,
                            IsActive = isActive,
                            Size = new Size(miniumWidth, height),
                            Location = new Point(barWidth - remainBottomWidth, 3),
                        };
                        item1.Click += categoryItem_Click;
                        barBottom.Controls.Add(item1);
                        remainBottomWidth -= item1.Width;
                        cateCount++;

                        /*return*/;
                    }
                } while (remainBottomWidth > miniumWidth * 2); //chua cho danh cho nut More

                if (cateCount < _categories.Count)
                {
                    var cateMoreUse = new BootstrapButton()
                    {
                        BackgroudBootstrapColor = backgroudColor,
                        ActiveBackgroudColor = activeBackgroudColor,
                        ImageCss = "plus",
                        ImageFontSize = 16,
                        SizeMode = sizeMode,
                        TextValue = "Thêm",
                        Height = height,
                        TextFont = fontTahoma9B,
                        TextColor = textColor,
                        ImageColor = imageColor,
                        ButtonValue = "0",
                        Type = buttonType,
                        IsActive = isActive,
                        Size = new Size(miniumWidth, height),
                        Location = new Point(barWidth - remainBottomWidth, 3)
                    };
                    cateMoreUse.Click += ChangePageControl_Click;
                    barBottom.Controls.Add(cateMoreUse);

                    _moreBars = new List<CategoryBar>();
                    var countBarMore = 1;
                    do
                    {
                        int remainMoreWidth = barWidth;
                        var barMore = new CategoryBar()
                        {
                            Anchor =
                                ((System.Windows.Forms.AnchorStyles)
                                    (((System.Windows.Forms.AnchorStyles.Bottom
                                       | System.Windows.Forms.AnchorStyles.Left)
                                      | System.Windows.Forms.AnchorStyles.Right))),
                            BackColor = System.Drawing.Color.White,
                            Location = new System.Drawing.Point(0, 450 - (countBarMore * 49)),
                            Margin = new System.Windows.Forms.Padding(0),
                            Name = "barMore",
                            Size = new System.Drawing.Size(628, 50),
                            TabIndex = 1,
                            Visible = true,
                        };
                        _moreBars.Add(barMore);
                        this.Controls.Add(barMore);

                        countBarMore++;
                        do
                        {
                            CategoryViewModel cate = _categories.ElementAt(cateCount);
                            var item = new BootstrapButton()
                            {
                                BackgroudBootstrapColor = backgroudColor,
                                ActiveBackgroudColor = activeBackgroudColor,
                                ImageCss =
                                    string.IsNullOrWhiteSpace(cate.ImageFontAwsomeCss)
                                        ? cate.ImageFontAwsomeCss
                                        : "glass",
                                ImageFontSize = 16,
                                SizeMode = sizeMode,
                                TextValue = cate.Name,
                                Height = height,
                                TextFont = fontTahoma9B,
                                TextColor = textColor,
                                ImageColor = imageColor,
                                ButtonValue = cate.Code.ToString(),
                                Type = buttonType,
                                IsActive = isActive,
                                Size = new Size(miniumWidth, height),
                                Location = new Point(barWidth - remainMoreWidth, 3)
                            };
                            item.Click += categoryItem_Click;
                            barMore.Controls.Add(item);
                            remainMoreWidth -= item.Width;
                            cateCount++;
                            if (cateCount >= _categories.Count)
                            {
                                break;
                            }
                        } while (remainMoreWidth > miniumWidth);
                    } while (cateCount < _categories.Count);
                }
                #endregion
            }
        }

        #endregion

        #region Handle ProductViewModel
        int column = 5;
        int row = 4;
        private void CreateProductsPanel()
        {
            try
            {
                tlpProductContainer.ColumnStyles.Clear();
                tlpProductContainer.RowStyles.Clear();

                tlpProductContainer.ColumnCount = column; //So luong san pham thao chieu ngang
                tlpProductContainer.RowCount = row; //So luong san pham theo chieu doc
                //Set grid layout column x row
                for (var i = 0; i < column; i++)
                {
                    tlpProductContainer.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, (float)100.0 / column));
                }

                //Add last row for navigation buttons
                for (var i = 0; i < row; i++)
                {
                    //// DuyDT - change from  Percent to Absolute
                    tlpProductContainer.RowStyles.Add(
                        new RowStyle(SizeType.Absolute, 123));
                    //                        new RowStyle(SizeType.Percent, (float)100.0 / (row + 1)));
                }

            }
            catch (Exception ex)
            {
                log.Error("CreateProductsPanel - " + ex);
            }
        }
        #endregion

        private void categoryItem_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (BootstrapButton)sender;
                DeactiveAllCategory();
                item.IsActive = !item.IsActive;
                var buttonValue = int.Parse(item.ButtonValue);
                if (buttonValue == -2)
                {
                    ShowSearchPanel();
                }
                else
                {
                    ShowProducts(buttonValue);
                }

                foreach (var moreBar in _moreBars)
                {
                    moreBar.Hide();
                }

                foreach (var listCateBars in _dicSubCategoryBars.Values)
                {
                    foreach (var cateBar in listCateBars)
                    {
                        cateBar.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("categoryItem_Click - " + ex);
            }
        }

        private void ShowSearchPanel()
        {
            try
            {
                tlpProductContainer.Controls.Clear();
                foreach (Control c in this.tlpProductContainer.Controls)
                {
                    c.Dispose();
                }

                if (tlpProductContainer != null)
                {
                    tlpProductContainer.Hide();
                }
                if (_searchProductPanel != null)
                {
                    _searchProductPanel.Show();
                }
            }
            catch (Exception ex)
            {
                log.Error("ShowSearchPanel - " + ex);
            }
        }

        private void DeactiveAllCategory()
        {
            foreach (var itm in barTop.Controls.Cast<BootstrapButton>().Where(itm => itm.IsActive))
            {
                itm.IsActive = false;
            }
            if (barBottom != null && barBottom.Controls != null)
            {
                foreach (var itm in barBottom.Controls.Cast<BootstrapButton>().Where(itm => itm.IsActive))
                {
                    itm.IsActive = false;
                }
            }
        }


        public void UpdateFromOrder()
        {
            try
            {
                DeactiveAllCategory();

                //Luôn show category có Display OrderEditViewModel = 1 (control[0])
                var categoryControl = (BootstrapButton)barTop.Controls[0];
                if (MainForm.PosConfig.EnableQuickSaleMode.Trim().ToLower() == "true")
                {
                    //Mode SUPERMARKET có Search Tab đầu tiên
                    categoryControl = (BootstrapButton)barTop.Controls[1];
                }

                categoryControl.IsActive = true;
                ShowProducts(int.Parse(categoryControl.ButtonValue));
            }
            catch (Exception ex)
            {
                log.Error("UpdateFromOrder - " + ex);
            }
        }


        private void ShowProducts(int cate = -1, int gotoPage = 1)
        {
            try
            {
                if (_searchProductPanel != null)
                {
                    _searchProductPanel.Hide();
                }

                if (tlpProductContainer != null)
                {
                    tlpProductContainer.Show();


                    tlpProductContainer.Controls.Clear();
                    foreach (Control c in this.tlpProductContainer.Controls)
                    {
                        c.Dispose();
                    }

                    IEnumerable<ProductViewModel> products;
                    int pageSize = column * row;


                    // Filter.
                    int maxProduct;
                    if (cate == -1)
                    {

                        //products =
                        //   Program.context.getAvailableSingleProducts().Where(
                        //        p => p.IsMostOrder != null && (p.IsMostOrder.Value))
                        //        .OrderBy(p => p.DisplayOrder).AsEnumerable();

                        products =
                         Program.context.getAllProducts().OrderByDescending(s=>s.Position).AsEnumerable();
                        maxProduct = products.Count();
                        products = products.Skip((gotoPage - 1) * pageSize).Take(pageSize);
                        //    .ToList();
                    }
                    else
                    {
                        // products = _productService.GetAvailableProducts().Where...
                        products = Program.context.getAvailableSingleProducts().Where(p => p.CatID == cate)
                            .OrderBy(p => p.DisplayOrder).AsEnumerable();
                        maxProduct = products.Count();
                        products = products.Skip((gotoPage - 1) * pageSize).Take(pageSize)
                            .ToList();
                    }


                    _currentCategoryId = cate;
                    _currentProductPage = gotoPage;


                    if (maxProduct > 20)
                    {
                        _maxProductPage = (int)(maxProduct / 20) + 1;
                    }
                    else
                    {
                        //Tránh trường hợp 20 product
                        _maxProductPage = 1;
                    }

                    Queue<ProductViewModel> queue = new Queue<ProductViewModel>();
                    foreach (var product in products)
                    {

                        var item = tlpProductContainer.GetControlFromPosition(product.PosX, product.PosY);
                        //Kiem tra phan tu tai vi tri index xem co chua san pham chua
                        if (item == null)
                        {
                            //item.UpdateProduct(product, 0);
                            ProductItemControl productItem = new ProductItemControl();
                            productItem.ChangeQuantityEvent += HandleChangeProductQuantiy;

                            //Kiem tra tren CurrentOrder de hien thi TotalOrder
                            int totalProductInOrder = currentOrderManager.GetNumOfProduct(product.Code, product.ProductParentId);
                            //int totalProductInOrder = currentOrderManager.order.OrderDetailEditViewModels.Where(od => od.ProductId == product.ProductId)
                            //   .Sum(od => od.Quantity);

                            productItem.UpdateProduct(product, 0, totalProductInOrder);

                            tlpProductContainer.Controls.Add(productItem, product.PosX, product.PosY);

                        }
                        else
                        {
                            //Da co san pham tai vi tri nay, kg the add san pham hien tai vao ma phai dua vao list
                            queue.Enqueue(product);
                        }
                    }

                    //Lay danh sach tat cac cac san vi tri tren man hinh ma chua co san pham nao chiem cho
                    //Add lan luot cac san pham vao danh sach

                    var productControls = tlpProductContainer.Controls.Cast<ProductItemControl>()
                        .Where(control => control.Product == null);

                    for (int i = 0; i < column; i++)
                    {
                        for (int j = 0; j < row; j++)
                        {
                            var control = tlpProductContainer.GetControlFromPosition(i, j);
                            //Vi trí trống,add ProductViewModel trong queue vào vị trí
                            if (control == null && queue.Count > 0)
                            {
                                ProductItemControl productItem = new ProductItemControl();
                                productItem.ChangeQuantityEvent += HandleChangeProductQuantiy;

                                ProductViewModel product = queue.Dequeue(); // Lay phan tu trong queue dua vao man hinh
                                //Kiem tra tren CurrentOrder de hien thi TotalOrder
                                int totalQuantity = currentOrderManager.GetNumOfProduct(product.Code, product.ProductParentId);

                                //int totalQuantity = currentOrderManager.order.OrderDetailEditViewModels.Where(od => od.ProductId == product.ProductId)
                                //   .Sum(od => od.Quantity);

                                productItem.UpdateProduct(product, 0, totalQuantity);

                                tlpProductContainer.Controls.Add(productItem, i, j);
                                //Sản phẩm ở khác vị trí so với cấu hình
                            }
                        }
                    }



                    //Navigation buttons for page

                    #region Navigation Buttons

                    Panel navBtnPanel = new FlowLayoutPanel()
                    {
                        Height = 40,
                        Width = 300,
                    };

                    if (_maxProductPage > 1)
                    {
                        //Button go left
                        var btnPageLeft = new BootstrapButton()
                        {
                            Height = 35,
                            Width = 50,
                            BackgroudBootstrapColor = BootstrapColorEnum.MainColor,
                            ImageCss = "arrow-left",
                            ButtonValue = "-100001",
                        };

                        btnPageLeft.Click += ChangePageControl_Click;
                        navBtnPanel.Controls.Add(btnPageLeft);

                        //Label page number
                        string page = _currentProductPage + " / " + _maxProductPage + "    ";
                        var btnPageNum = new BootstrapButton
                        {
                            TextValue = page,
                            ButtonValue = "4",
                            Height = 50,
                        };

                        navBtnPanel.Controls.Add(btnPageNum);

                        //Button go right
                        var btnPageRight = new BootstrapButton()
                        {
                            Height = 35,
                            Width = 50,
                            ImageCss = "arrow-right",
                            ButtonValue = "-100002",
                            BackgroudBootstrapColor = BootstrapColorEnum.MainColor,
                        };

                        btnPageRight.Click += ChangePageControl_Click;
                        navBtnPanel.Controls.Add(btnPageRight);
                    }

                    tlpProductContainer.Controls.Add(navBtnPanel, 2, 4);
                    tlpProductContainer.SetColumnSpan(navBtnPanel, 2);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                log.Error("ShowProducts - " + ex);
            }

        }

        private void ChangePageControl_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (BootstrapButton)sender;
                var buttonVal = int.Parse(item.ButtonValue);

                // DeactiveSearchTab();
                if (int.Parse(item.ButtonValue) == -100001) // left
                {
                    if (_currentProductPage > 1)
                    {
                        ShowProducts(_currentCategoryId, _currentProductPage - 1);
                    }
                }
                else if (int.Parse(item.ButtonValue) == -100002) // right
                {
                    if (_maxProductPage > _currentProductPage)
                    {
                        ShowProducts(_currentCategoryId, _currentProductPage + 1);
                    }
                }
                else if (buttonVal < 0)
                {
                    foreach (var listCateBars in _dicSubCategoryBars.Values)
                    {
                        foreach (var cateBar in listCateBars)
                        {
                            cateBar.Hide();
                        }
                    }

                    var subCategoryBars = _dicSubCategoryBars[(buttonVal * (-1))];
                    foreach (var subCateBar in subCategoryBars)
                    {
                        subCateBar.BringToFront();
                        subCateBar.Show();
                    }
                    DeactiveAllCategory();
                    item.IsActive = !item.IsActive;
                }
                else if (int.Parse(item.ButtonValue) == 0)
                {
                    foreach (var moreBar in _moreBars)
                    {
                        moreBar.BringToFront();
                        moreBar.Show();
                    }
                    //                    barMore.BringToFront();
                    //                    barMore.Show();
                    DeactiveAllCategory();
                    item.IsActive = !item.IsActive;
                }
                else if (int.Parse(item.ButtonValue) == -999999) // show search tab
                {
                    DeactiveAllCategory();
                    item.IsActive = !item.IsActive;
                    tlpProductContainer.Hide();
                    //_searchProductPanel.Show();
                    //_searchProductPanel.Focus();
                }

            }
            catch (Exception ex)
            {
                log.Error("ChangePageControl_Click - " + ex);
            }

        }

        /// <summary>
        /// Cập nhật product Item Control khi có sự thay đổi số lượng
        /// </summary>
        public void UpdateWhenOrderDetailChange(OrderDetailEditViewModel orderDetail, OrderDetailChangeModeEnum mode)
        {
            try
            {
                if (mode != OrderDetailChangeModeEnum.UpdateOrderDetailInfo)
                {
                    int productId = orderDetail.ProductId;

                    for (int row = 0; row < 4; row++)
                    {
                        for (int column = 0; column < 5; column++)
                        {
                            var control = (ProductItemControl)tlpProductContainer.GetControlFromPosition(column, row);
                            if (control != null && (control.Product.Code == orderDetail.ProductCode
                                || control.Product.Code == orderDetail.ProductViewModel.Code
                                || ((orderDetail.ProductViewModel.GeneralProductId != null)
                                    && (control.Product.ProductParentId != null)
                                    && (orderDetail.ProductViewModel.GeneralProductId == control.Product.ProductParentId))))
                            {
                                ProductViewModel tmpProduct = Program.context.getAllProducts()
                                    .FirstOrDefault(tp => ((orderDetail.ProductViewModel.GeneralProductId != null) 
                                                    && (orderDetail.ProductViewModel.GeneralProductId == tp.ProductParentId)) 
                                                || tp.Code == orderDetail.ProductCode);

                                ProductViewModel p = new ProductViewModel
                                {
                                    Price = orderDetail.UnitPrice,
                                    Code = orderDetail.ProductCode,

                                    //For size 
                                    ProductId = tmpProduct.ProductId,
                                    ProductName = tmpProduct.ProductName,
                                    ProductType = tmpProduct.ProductType,
                                    ProductParentId = tmpProduct.ProductParentId,
                                    ColorGroup = tmpProduct.ColorGroup??0
                                };

                                int total = currentOrderManager.GetNumOfProduct(orderDetail.ProductCode);

                                //Cập nhật sản phẩm
                                control.UpdateProduct(p, orderDetail.Quantity, total);
                            }
                            else if (control != null && mode == OrderDetailChangeModeEnum.AddOrderDetail)
                            {
                                //Ở 1 thời điểm chỉ có 1 sản phẩm có Quantity > 0 - sản phẩm đang thao tác
                                //Sản phẩm không thao tác -> chuyển Quantity về 0
                                if (control.ItemQuantity > 0)
                                {
                                    control.UpdateProduct(control.Product, 0, control.Quantity);
                                }
                            }
                        }
                    }
                }
                _searchProductPanel.UpdateWhenOrderDetailChange(orderDetail, mode);
            }
            catch (Exception ex)
            {
                log.Error("UpdateWhenOrderDetailChange - " + ex);
            }
        }

        private void HandleChangeProductQuantiy(ProductViewModel product, int quantity)
        {
            if (product.ProductType == (int)ProductTypeEnum.General)
            {
                if (product.ProductParentId != null)
                {
                    var childProducts = Program.context.getAllProducts().Where(p => p.GeneralProductId == product.ProductParentId).ToList();

                    product = childProducts.FirstOrDefault();
                    foreach (var childProduct in childProducts)
                    {
                        if (childProduct.IsDefaultChildProduct)
                        {
                            product = childProducts.FirstOrDefault(p => p.IsDefaultChildProduct);
                        }
                    }
                }
            }
            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, product, null, quantity);
        }
    }
}
