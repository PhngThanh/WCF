using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS.SaleScreen.CustomControl;
using log4net;
using System.Drawing;
using System.Drawing.Drawing2D;
using POS.CustomControl;
using POS.Repository.ViewModels;
using POS.Repository;
using POS.Utils;

namespace POS.SaleScreen
{
    public partial class OrderDetailForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();

        private OrderDetailEditViewModel _mainOrderDetail;
        public ProductViewModel ProductViewModel;
        public List<ProductViewModel> ExtraProducts;

        //Sử dụng 3 panel để thay thế vào  
        OrderDetailPropetyPanel _generalPanel;
        TableLayoutPanel _tlpExtraProducts;
        ProductAttributePanel _productAttributePanel;

        private bool _isTyping = false;

        private readonly bool _isGeneralProduct;

        public OrderDetailForm(OrderDetailEditViewModel mainOd)
        {
            _mainOrderDetail = mainOd;
            ProductViewModel = _mainOrderDetail.ProductViewModel;
            _isGeneralProduct = (ProductViewModel.ProductType == (int)ProductTypeEnum.General || ProductViewModel.GeneralProductId != null);
            this.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(124, 124, 124), 3))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawRectangle(pen, ClientRectangle);
                }
            };

            #region Get ProductViewModel extra
            var productExtraList = new List<ProductExtraViewModel>();
            if (_isGeneralProduct)
            {
                var parentProduct = Program.context.getAvailableSingleProducts().FirstOrDefault(p => p.ProductParentId == ProductViewModel.GeneralProductId);
                ExtraProducts = SaleScreen3.GetProductExtraByPrimaryCate(parentProduct.CatID);
                //SaleScreen3.AllProductExtras.Where(pe => pe.PrimaryProductCode == parentProduct.Code).ToList();
            }
            else
            {
                ExtraProducts = SaleScreen3.GetProductExtraByPrimaryCate(ProductViewModel.CatID);
                //SaleScreen3.AllProductExtras.Where(pe => pe.PrimaryProductCode == ProductViewModel.Code).ToList();
            }

            //ExtraProducts = new List<ProductViewModel>();

            //CategoryViewModel currentProductCate =
            //    SaleScreen3.AvailableCategories.FirstOrDefault(c => c.Code == this.ProductViewModel.CatID);



            //foreach (var productExtra in  productExtraList)
            //{
            //    var extra = Program.context.getAllProducts().FirstOrDefault(p => p.Code == productExtra.ExtraProductCode);
            //    if (extra != null)
            //    {
            //        ExtraProducts.Add(extra);
            //    }
            //}
            #endregion

            InitializeComponent();

            #region Extra buttons

            var activeBackGroundColor = Color.Black;

            this.btnExtra1.IsActive = false;
            this.btnExtra1.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra2.IsActive = false;
            this.btnExtra2.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra3.IsActive = false;
            this.btnExtra3.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra4.IsActive = false;
            this.btnExtra4.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra5.IsActive = false;
            this.btnExtra5.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra6.IsActive = false;
            this.btnExtra6.ActiveBackgroudColor = activeBackGroundColor;
            this.btnExtra7.IsActive = false;
            this.btnExtra7.ActiveBackgroudColor = activeBackGroundColor;
            this.btnAttribute.IsActive = false;
            this.btnAttribute.ActiveBackgroudColor = activeBackGroundColor;
            this.btnGeneral.IsActive = true;
            this.btnGeneral.ActiveBackgroudColor = activeBackGroundColor;
            #endregion

            GenerateLayout();
            _generalPanel.RecheckActivedButton();
        }

        #region MainLayout
        private void GenerateLayout()
        {
            try
            {
                #region Button Location

                //Set button location 
                int xLocation = btnGeneral.Width;//Vi trí bắt đầu của Attribute Button
                btnAttribute.Visible = true;
                xLocation += btnAttribute.Width;

                int extraProductInpage = row * column;
                if (ExtraProducts != null && ExtraProducts.Count > 0)
                {
                    int totalProduct = ExtraProducts.Count;
                    int countPage = totalProduct / extraProductInpage;
                    if (totalProduct % extraProductInpage != 0) countPage++;

                    if (countPage >= 1)
                    {
                        btnExtra1.Location = new Point(xLocation, 3);
                        btnExtra1.Visible = true;
                        xLocation += btnExtra1.Width;
                    }
                    else
                    {
                        btnExtra1.Visible = false;
                    }

                    if (countPage >= 2)
                    {
                        btnExtra2.Location = new Point(xLocation, 3);
                        btnExtra2.Visible = true;
                        xLocation += btnExtra1.Width;
                    }
                    else
                    {
                        btnExtra2.Visible = false;
                    }

                    btnMoreExtra.Hide();

                    if (countPage >= 3)
                    {
                        if (countPage == 3)
                        {
                            barTop.Controls.Add(btnExtra3);
                            btnExtra3.Location = new Point(xLocation, 3);
                            btnExtra3.Visible = true;
                            xLocation += btnExtra1.Width;
                        }
                        else
                        {
                            // if countPage >= 4
                            btnMoreExtra.Show();
                            btnMoreExtra.Location = new Point(xLocation, 3);
                            btnMoreExtra.Visible = true;
                            xLocation += btnExtra1.Width;
                        }
                    }
                    else
                    {
                        btnExtra3.Visible = false;
                    }

                }
                else
                {
                    btnExtra1.Visible = false;
                    btnExtra2.Visible = false;
                    btnExtra3.Visible = false;
                }


                #endregion

                #region 3 Panels


                if (_generalPanel == null)
                {
                    _generalPanel = new OrderDetailPropetyPanel();
                    _generalPanel.HideOrderDetail += this.Hide;
                }

                //Extra ProductViewModel panel
                if (ExtraProducts != null && ExtraProducts.Count > 0)
                {
                    CreateExtraProductsPanel();
                }

                //Attribute panel
                if (_isGeneralProduct)
                {

                    if (_productAttributePanel == null)
                    {
                        _productAttributePanel = new ProductAttributePanel(ProductViewModel, _mainOrderDetail);
                    }
                }

                //DeactiveAllCategory();
                UpdateOrderDetailPropertyPanel();
                ShowGeneralPanel(_generalPanel);
                // ShowCategoryMenu();

                #endregion

                #region Text value
                this.btnGeneral.TextValue = MainForm.ResManager.GetString("OrderDetailForm_General", MainForm.CultureInfo);
                this.btnAttribute.TextValue = MainForm.ResManager.GetString("OrderDetailForm_Property", MainForm.CultureInfo);
                this.btnExtra1.TextValue = MainForm.ResManager.GetString("OrderDetailForm_Extra_1", MainForm.CultureInfo);
                this.btnExtra2.TextValue = MainForm.ResManager.GetString("OrderDetailForm_Extra_2", MainForm.CultureInfo);
                this.btnMoreExtra.TextValue = MainForm.ResManager.GetString("OrderDetailForm_More", MainForm.CultureInfo);

                #endregion
            }
            catch (Exception ex)
            {
                log.Error("GenerateLayout - " + ex);
            }
        }

        public void UpdateOrderDetailForm()
        {
            UpdateOrderDetailPropertyPanel();
            //if (currentPanelMode == PanelMode.Extra)
            //{
            UpdateCurrentExtraProductsPanel();
            //}
        }

        enum PanelMode
        {
            General,
            Attribute,
            Extra,
            MenuExtra
        }

        private PanelMode currentPanelMode;
        //private int currentExtraProductCategoryId;

        private void ShowPanel(Panel panel)
        {
            pnlMain.Controls.Clear();
            foreach (Control c in this.pnlMain.Controls)
            {
                c.Dispose();
            }

            panel.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(panel);
        }

        private void ShowGeneralPanel(OrderDetailPropetyPanel panel)
        {
            pnlMain.Controls.Clear();
            foreach (Control c in this.pnlMain.Controls)
            {
                c.Dispose();
            }

            panel.Dock = DockStyle.Fill;

            pnlMain.Controls.Add(panel);
        }

        //private void categoryItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_mainOrderDetail == null)
        //        {
        //            _mainOrderDetail = _productAttributePanel.GetMainOrderDetail();
        //        }
        //        UpdateOrderDetailPropertyPanel();

        //        var item = (BootstrapButton)sender;
        //        DeactiveAllCategory();
        //        item.IsActive = !item.IsActive;

        //        if (item.TextValue == "Size")
        //        {
        //            //In case : General ProductViewModel => Load Attribute Panel
        //            ShowPanel(_productAttributePanel);
        //        }
        //        else if (item.TextValue == "Tổng quan")
        //        {
        //            ShowPanel(_generalPanel);
        //        }
        //        else if (item.TextValue == "Thêm")
        //        {
        //            ShowPanel(_morePanel);
        //        }
        //        else
        //        {
        //            //Extra category
        //            currentPanelMode = PanelMode.Extra;
        //            currentExtraProductCategoryId = int.Parse(item.ButtonValue);
        //            LoadExtraProductsToPanel(currentExtraProductCategoryId);
        //            ShowPanel(tlpExtraProducts);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}

        private void ResetPanel()
        {
            try
            {
                DeactiveAllCategory();

                currentPanelMode = PanelMode.General;
                ShowGeneralPanel(_generalPanel);
                btnGeneral.IsActive = true;

            }
            catch (Exception ex)
            {
                log.Error("ResetPanel - " + ex);
            }
        }

        private void DeactiveAllCategory()
        {
            foreach (var itm in barTop.Controls.Cast<BootstrapButton>().Where(itm => itm.IsActive))
            {
                itm.IsActive = false;
            }
        }

        #endregion

        #region OrderDetailPropertyPanel

        private void UpdateOrderDetailPropertyPanel()
        {
            try
            {
                if (_mainOrderDetail != null)
                {
                    var orderDetails = currentOrderManager.GetExtraAndMainOrderDetails(_mainOrderDetail.OrderDetailID).ToList();
                    if (_generalPanel == null)
                    {
                        _generalPanel = new OrderDetailPropetyPanel();
                        _generalPanel.HideOrderDetail += this.Hide;
                    }
                    _generalPanel.LoadOrderDetail(orderDetails);
                }
            }
            catch (Exception ex)
            {
                log.Error("UpdateOrderDetailPropertyPanel - " + ex);
            }
        }



        #endregion

        #region AttributePanel
        //private void UpdateAttributePanel()
        //{
        //    try
        //    {
        //        //var item = (CategoryItemControl)sender;
        //        //DeactiveAllCategory();
        //        //item.IsActive = !item.IsActive;
        //        //ShowProducts(item.Id);

        //        _productAttributePanel = new ProductAttributePanel(ProductViewModel, mainOrderDetail);

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        #endregion

        #region Exta ProductViewModel Panel
        int column = 4;
        int row = 4;


        //private ProductService _productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));
        //private static int maxProductPage = 1;
        //private static int currentProductPage = 1;
        //private static int currentCategoryId = -1;

        private void CreateExtraProductsPanel()
        {
            try
            {
                _tlpExtraProducts = new TableLayoutPanel();
                _tlpExtraProducts.ColumnCount = column; //So luong san pham thao chieu ngang
                _tlpExtraProducts.RowCount = row; //So luong san pham theo chieu doc

                //Set grid layout column x row
                for (var i = 0; i < column; i++)
                {
                    _tlpExtraProducts.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, (float)100.0 / column));
                }

                //Add last row for navigation buttons
                for (var i = 0; i < row; i++)
                {
                    _tlpExtraProducts.RowStyles.Add(
                        new RowStyle(SizeType.Percent, (float)100.0 / row));
                }

            }
            catch (Exception ex)
            {
                log.Error("CreateExtraProductsPanel - " + ex);
            }
        }

        private void LoadExtraProductsToPanel(int pageIndex)
        {
            try
            {

                _tlpExtraProducts.Controls.Clear();
                foreach (Control c in this._tlpExtraProducts.Controls)
                {
                    c.Dispose();
                }

                //tlpExtraProducts.MaximumSize = new System.Drawing.Size(620, 600);
                int pageSize = column * row;

                //var products = _productService.GetAvailableProducts().Where...
                //var products = SaleScreen3.AvailableSingleProducts.Where(p => p.CatID == cate)
                //     .OrderBy(p => p.DisplayOrder).AsEnumerable().Skip((gotoPage - 1) * pageSize).Take(pageSize)
                //   .ToList();

                List<OrderDetailEditViewModel> orderDetails = null;

                if (_mainOrderDetail != null)
                {
                    orderDetails = currentOrderManager.GetExtraAndMainOrderDetails(_mainOrderDetail.OrderDetailID);
                }


                Queue<ProductViewModel> queue = new Queue<ProductViewModel>();
                var products = ExtraProducts.Skip(pageSize * pageIndex).Take(pageSize);
                foreach (var product in products)
                {

                    var item = _tlpExtraProducts.GetControlFromPosition(product.PosX, product.PosY);
                    //Kiem tra phan tu tai vi tri index xem co chua san pham chua
                    if (item == null)
                    {
                        //item.UpdateProduct(product, 0);
                        ProductItemControl productItem = new ProductItemControl();
                        productItem.ChangeQuantityEvent += HandleChangeProductQuantiy;
                        //Kiem tra tren CurrentOrder de hien thi TotalOrder
                        if (orderDetails != null)
                        {
                            int totalQuantity = orderDetails.Where(od => od.ProductCode == product.Code)
                               .Sum(od => od.Quantity);
                            int itemQuantity = orderDetails.Where(od => od.ProductCode == product.Code)
                               .Sum(od => od.ItemQuantity);
                            productItem.UpdateProduct(product, itemQuantity, totalQuantity);

                            _tlpExtraProducts.Controls.Add(productItem, product.PosX, product.PosY);
                        }
                    }
                    else
                    {
                        //Da co san pham tai vi tri nay, kg the add san pham hien tai vao ma phai dua vao list
                        queue.Enqueue(product);
                    }
                }

                //Lay danh sach tat cac cac san vi tri tren man hinh ma chua co san pham nao chiem cho
                //Add lan luot cac san pham vao danh sach

                var productControls = pnlMain.Controls.Cast<ProductItemControl>()
                   .Where(control => control.Product == null);

                for (int i = 0; i < column; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        var control = _tlpExtraProducts.GetControlFromPosition(i, j);
                        //Vi trí trống,add ProductViewModel trong queue vào vị trí
                        if (control == null && queue.Count > 0)
                        {
                            ProductItemControl productItem = new ProductItemControl();
                            productItem.ChangeQuantityEvent += HandleChangeProductQuantiy;
                            ProductViewModel product = queue.Dequeue();// Lay phan tu trong queue dua vao man hinh


                            //Kiem tra tren CurrentOrder de hien thi TotalOrder

                            int totalQuantity = orderDetails.Where(od => od.ProductCode == product.Code)
                               .Sum(od => od.Quantity);
                            int itemQuantity = orderDetails.Where(od => od.ProductCode == product.Code)
                               .Sum(od => od.ItemQuantity);

                            productItem.UpdateProduct(product, itemQuantity, totalQuantity);
                            _tlpExtraProducts.Controls.Add(productItem, i, j);//Sản phẩm ở khác vị trí so với cấu hình
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                log.Error("LoadExtraProductsToPanel - " + ex);
            }
        }

        private void UpdateCurrentExtraProductsPanel()
        {
            if (_mainOrderDetail != null)
            {
                var orderDetails = currentOrderManager.GetExtraAndMainOrderDetails(_mainOrderDetail.OrderDetailID);

                if (_tlpExtraProducts != null)
                {
                    foreach (var control in _tlpExtraProducts.Controls.Cast<ProductItemControl>())
                    {
                        var orderDetail = orderDetails.FirstOrDefault(od => od.ProductCode == control.Product.Code);
                        if (orderDetail != null)
                        {
                            control.UpdateProduct(control.Product, orderDetail.ItemQuantity, orderDetail.Quantity);
                        }
                        else
                        {
                            control.UpdateProduct(control.Product, 0, 0);
                        }
                    }
                }
            }
        }

        private void HandleChangeProductQuantiy(ProductViewModel product, int quantity)
        {
            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.ModifiedOrderDetail, product, _mainOrderDetail, quantity);
        }

        #endregion


        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            //            this.Hide();
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                base.OnShown(e);

                ResetPanel();

                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 340;
                this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2 - 10;

                //ShowGeneralInfo(null, e);
                this.Show();
                this.BringToFront();
            }
            catch (Exception ex)
            {
                log.Error("OnShown - " + ex);
            }

        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            barMore.Hide();
            currentPanelMode = PanelMode.General;
            ShowGeneralPanel(_generalPanel);
        }

        private void btnAttribute_Click(object sender, EventArgs e)
        {
            barMore.Hide();
            currentPanelMode = PanelMode.Attribute;
            if (_productAttributePanel == null)
            {
                _productAttributePanel = new ProductAttributePanel(ProductViewModel, _mainOrderDetail);
            }
            ShowPanel(_productAttributePanel);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }



        private void btnExtra_Click(object sender, EventArgs e)
        {
            barMore.Hide();
            int index = int.Parse((sender as BootstrapButton).ButtonValue);
            LoadExtraProductsToPanel(index);
            ShowPanel(_tlpExtraProducts);
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            barMore.Show();
            barMore.BringToFront();
            int totalProduct = ExtraProducts.Count;
            int extraProductInpage = row * column;

            int countPage = totalProduct / extraProductInpage;
            if (totalProduct % extraProductInpage != 0) countPage++;
            int xLocation = btnGeneral.Location.X;//Vi trí bắt đầu của Attribute Button

            if (countPage > 3)
            {
                btnExtra3.Location = new Point(xLocation, 3);
                btnExtra3.Visible = true;
                xLocation += btnExtra1.Width;

                btnExtra4.Location = new Point(xLocation, 3);
                btnExtra4.Visible = true;
                xLocation += btnExtra1.Width;
            }
            else
            {
                btnExtra4.Visible = false;
                btnExtra3.Visible = false;
            }

            if (countPage >= 5)
            {
                btnExtra5.Location = new Point(xLocation, 3);
                btnExtra5.Visible = true;
                xLocation += btnExtra1.Width;
            }
            else
            {
                btnExtra5.Visible = false;
            }

            if (countPage >= 6)
            {
                btnExtra6.Location = new Point(xLocation, 3);
                btnExtra6.Visible = true;
                xLocation += btnExtra1.Width;
            }
            else
            {
                btnExtra6.Visible = false;
            }

            if (countPage >= 7)
            {
                btnExtra7.Location = new Point(xLocation, 3);
                btnExtra7.Visible = true;
                xLocation += btnExtra1.Width;
            }
            else
            {
                btnExtra7.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if ((currentOrderManager.getOrderEditViewModel().OrderStatus == (int)OrderStatusEnum.New
                    || currentOrderManager.getOrderEditViewModel().OrderStatus == (int)OrderStatusEnum.PosProcessing
                    || currentOrderManager.getOrderEditViewModel().OrderStatus == (int)OrderStatusEnum.Processing)
                && (_mainOrderDetail.Status == (int)OrderDetailStatusEnum.New
                    || _mainOrderDetail.Status == (int)OrderDetailStatusEnum.Processing
                    || _mainOrderDetail.Status == (int)OrderDetailStatusEnum.PosFinished))
            {
                //Delete product
                currentOrderManager.ChangeItemQuantityOfOrderDetail(
                    OrderDetailChangeModeEnum.RemoveOrderDetail, null, _mainOrderDetail, 0);
                this.Hide();
            }
        }


        private void btnClone_Click(object sender, EventArgs e)
        {
            //Nhấn nút New OrderEditViewModel từ OrderEditViewModel đã có
            currentOrderManager.ChangeItemQuantityOfOrderDetail(OrderDetailChangeModeEnum.AddOrderDetail, null, _mainOrderDetail, 0);
            this.Hide();
        }

        public void UpdateQuantity(int quantity)
        {
            if (_generalPanel != null)
            {
                _generalPanel.UpdateQuantity(quantity);
            }
        }
    }
}
