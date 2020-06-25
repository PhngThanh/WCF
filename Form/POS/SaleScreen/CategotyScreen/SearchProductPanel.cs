using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using POS.Repository.ViewModels;
using POS.Properties;
using POS.SaleScreen.CustomControl;
using POS.Common;
using POS.Utils;
using POS.Repository;

namespace POS.SaleScreen
{
    public partial class SearchProductPanel : Panel
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        public List<ProductViewModel> Products;

        private const int Column = 4;
        private const int Row = 3;

        private static int _maxProductPage = 1;
        private static int _currentProductPage = 1;

        private bool _alreadySearched = false;

        public SearchProductPanel()
        {
            InitializeComponent();

            GenerateLayout();

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtInput);
            }
        }

        public void UpdateWhenOrderDetailChange(OrderDetailEditViewModel orderDetail, OrderDetailChangeModeEnum mode)
        {
            try
            {
                if (mode != OrderDetailChangeModeEnum.UpdateOrderDetailInfo)
                {
                    int productId = orderDetail.ProductId;

                    //Kiểm tra xem đã search product nào chưa
                    if (pnlProduct.Controls.Count > 0)
                    {
                        for (int row = 0; row < Row; row++)
                        {
                            for (int column = 0; column < Column; column++)
                            {
                                var control = (ProductItemControl)pnlProduct.GetControlFromPosition(column, row);
                                if (control != null && (((orderDetail.ProductViewModel.GeneralProductId != null) && (orderDetail.ProductViewModel.GeneralProductId == control.Product.ProductParentId))
                                    || control.Product.Code == orderDetail.ProductViewModel.Code))
                                {
                                    //Use tmpProduct to get exactly ProductViewModel with ProductId
                                    //var tmpProduct = _productService.GetProductById(orderDetail.ProductId);
                                    //ProductViewModel tmpProduct = SaleScreen3.AvailableProducts.Where(tp => tp.ProductId == orderDetail.ProductId).FirstOrDefault();
                                    ProductViewModel tmpProduct = Program.context.getAllProducts().FirstOrDefault(tp => ((orderDetail.ProductViewModel.GeneralProductId != null) && (orderDetail.ProductViewModel.GeneralProductId == tp.ProductParentId)) || tp.Code == orderDetail.ProductCode);

                                    ProductViewModel p = new ProductViewModel
                                    {
                                        Price = orderDetail.UnitPrice,
                                        Code = orderDetail.ProductCode,

                                        //For size 
                                        ProductId = tmpProduct.ProductId,
                                        ProductName = tmpProduct.ProductName,
                                        ProductType = tmpProduct.ProductType,
                                        ProductParentId = tmpProduct.ProductParentId
                                    };

                                    int total = currentOrderManager.GetNumOfProduct(orderDetail.ProductCode);
                                    //currentOrderManager.order.OrderDetailEditViewModels.Where(
                                    //    od => od.ProductId == productId)
                                    //    .Sum(od => od.Quantity);

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
                }
            }
            catch (Exception ex)
            {
                log.Error("UpdateWhenOrderDetailChange - " + ex);
            }
        }



        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            txtInput.Focus();
        }

        private void GenerateLayout()
        {
            GenerateProductItemLayout();
            _keyboard.AddTextbox(txtInput);
        }

        private void GenerateProductItemLayout()
        {
            pnlProduct.ColumnCount = Column;
            pnlProduct.RowCount = Row;

            pnlProduct.ColumnStyles.Clear();
            pnlProduct.RowStyles.Clear();
            for (var i = 0; i < pnlProduct.ColumnCount; i++)
            {
                pnlProduct.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, (float)100.0 / pnlProduct.ColumnCount));
            }

            for (var i = 0; i < pnlProduct.RowCount; i++)
            {
                pnlProduct.RowStyles.Add(new RowStyle(SizeType.Absolute, 125));
            }
        }

        private void HandleChangeProductQuantiy(ProductViewModel productViewModel, int quantity)
        {
            if (productViewModel.ProductType == (int)ProductTypeEnum.General)
            {
                if (productViewModel.ProductParentId != null)
                {
                    var childProducts = Program.context.getAllProducts().Where(p => p.GeneralProductId == productViewModel.ProductParentId).ToList();

                    productViewModel = childProducts.FirstOrDefault();
                    foreach (var childProduct in childProducts)
                    {
                        if (childProduct.IsDefaultChildProduct)
                        {
                            productViewModel = childProducts.FirstOrDefault(p => p.IsDefaultChildProduct);
                        }
                    }
                }
            }

            if (_alreadySearched)
            {
                currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.AddOrderDetail, productViewModel, null, quantity);
            }
            else
            {
                currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, productViewModel, null, quantity);
            }
            _alreadySearched = false;
        }

        private void ChangePageControl_Click(object sender, EventArgs e)
        {
            try
            {
                var item = (CategoryItemControl)sender;
                if (item.Id == 0)
                {
                    //_cateMenu.Show();
                }
                //else if (item.Id == -99) // show search tab
                //{
                //    //DeactiveAllCategory();
                //    item.IsActive = !item.IsActive;
                //    _mainContainer.Hide();
                //}
                else if (item.Id == -1) // left
                {
                    if (_currentProductPage > 1)
                    {
                        ShowProducts(_currentProductPage - 1);
                    }
                }
                else if (item.Id == 1) // right
                {
                    if (_maxProductPage > _currentProductPage)
                    {
                        ShowProducts(_currentProductPage + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("ChangePageControl_Click - " + ex);
            }

        }

        private void ShowProducts(int gotoPage = 1)
        {
            try
            {
                pnlProduct.Controls.Clear();
                foreach (Control c in this.pnlProduct.Controls)
                {
                    c.Dispose();
                }

                const int pageSize = Column * Row;

                // Filter.
                var maxProduct = Products.Count();
                var products = Products.Skip((gotoPage - 1) * pageSize).Take(pageSize)
                     .ToList();

                //currentCategoryId = cate;
                _currentProductPage = gotoPage;


                if (maxProduct > 20)
                {
                    _maxProductPage = (int)(maxProduct / pageSize) + 1;
                }
                else
                {
                    //Tránh trường hợp 20 productViewModel
                    _maxProductPage = 1;
                }

                Queue<ProductViewModel> queue = new Queue<ProductViewModel>();
                foreach (var product in products)
                {
                    queue.Enqueue(product);
                }

                for (int i = 0; i < Column; i++)
                {
                    for (int j = 0; j < Row; j++)
                    {
                        var control = pnlProduct.GetControlFromPosition(i, j);
                        //Vi trí trống,add ProductViewModel trong queue vào vị trí
                        if (control == null && queue.Count > 0)
                        {
                            ProductItemControl productItem = new ProductItemControl();
                            productItem.ChangeQuantityEvent += HandleChangeProductQuantiy;

                            ProductViewModel product = queue.Dequeue();// Lay phan tu trong queue dua vao man hinh
                            //Kiem tra tren CurrentOrder de hien thi TotalOrder
                            int totalQuantity = currentOrderManager.getOrderEditViewModel()
                                .OrderDetailEditViewModels.Where(od => od.ProductCode == product.Code)
                                .Sum(od => od.Quantity);

                            productItem.UpdateProduct(product, 0, totalQuantity);

                            pnlProduct.Controls.Add(productItem, i, j);//Sản phẩm ở khác vị trí so với cấu hình
                        }
                    }
                }

                //Navigation buttons for page
                #region Navigation Buttons

                Panel navBtnPanel = new Panel
                {
                    Height = 40,
                    Width = 300
                };

                if (_maxProductPage > 1)
                {
                    //Button go left
                    var btnPageLeft = new CategoryItemControl(Resources.key_move_left_b1, Resources.key_move_left_b1, -1, null);
                    btnPageLeft.Height = 35;
                    btnPageLeft.Width = 50;
                    btnPageLeft.Click += ChangePageControl_Click;
                    navBtnPanel.Controls.Add(btnPageLeft);

                    //Label page number
                    string page = _currentProductPage + " / " + _maxProductPage + "    ";
                    var btnPageNum = new CategoryItemControl(Resources.null_image, Resources.null_image, 4, page)
                    {
                        Height = 50
                    };
                    navBtnPanel.Controls.Add(btnPageNum);

                    //Button go right
                    var btnPageRight = new CategoryItemControl(Resources.key_move_right_b1, Resources.key_move_right_b1, 1, null)
                    {
                        Height = 35,
                        Width = 50
                    };
                    btnPageRight.Click += ChangePageControl_Click;
                    navBtnPanel.Controls.Add(btnPageRight);
                }

                pnlProduct.Controls.Add(navBtnPanel, 2, 4);
                pnlProduct.SetColumnSpan(navBtnPanel, 2);

                #endregion
            }
            catch (Exception ex)
            {
                log.Error("ShowProducts - " + ex);
            }

        }

        private void SearchProduct(object sender, EventArgs e)
        {
            var keyword = Ultis.EscapeName(txtInput.Text.Trim()).ToLower();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Products = new List<ProductViewModel>();
            }
            else
            {
                Products = Program.context.getAvailableSingleProducts().Where(p =>
                    Ultis.EscapeName(p.ProductName).ToLower().Contains(keyword) ||
                    Ultis.EscapeName(p.Code).ToLower().Contains(keyword)).ToList();
            }

            ShowProducts();
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            _alreadySearched = true;
            if (e.KeyCode == Keys.Enter)
            {
                if (Products.Count == 1)
                {
                    var p = Products.FirstOrDefault();
                    SaleScreen3.AddOrderDetailWithProduct(p);
                }
                txtInput.ResetText();
            }
        }
    }


}
