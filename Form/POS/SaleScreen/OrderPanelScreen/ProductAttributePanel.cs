using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using System.Diagnostics;
using AutoMapper;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.SaleScreen.CustomControl;
using POS.Utils;

namespace POS.SaleScreen
{
    public partial class ProductAttributePanel : Panel
    {
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // private readonly ProductService _productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));

        private ProductViewModel _product; // Dùng để lưu giữ Attribute do khách chọn và đối chiếu với database
        private List<ProductViewModel> _productChilds; // List các ProductViewModel con của 1 General ProductViewModel
        private ProductViewModel _productChild; // ProductViewModel được tìm thấy dựa trên attribute

        // List các attibutes
        private List<string> _attributeList1;
        private List<string> _attributeList2;
        private List<string> _attributeList3;
        private List<string> _attributeNameList;

        private PropertyGroupControl _attributeGroup1;
        private PropertyGroupControl _attributeGroup2;
        private PropertyGroupControl _attributeGroup3;

        private bool _isChangeMainItem = false;

        // Dùng khi muốn chỉnh sửa 1 main item
        private OrderDetailEditViewModel _parentOrderDetail;

        public ProductAttributePanel(ProductViewModel product, OrderDetailEditViewModel parentOrderDetail)
        {
            // Tạo 1 ProductViewModel mới để giữ các thông tin về attribute đã được chọn
            _product = Mapper.Map<ProductViewModel, ProductViewModel>(product, _product);
            //_product = new ProductViewModel();
            _parentOrderDetail = parentOrderDetail;

            //Load Attributes
            if (product.ProductParentId != null || product.GeneralProductId != null)
            {
                if (product.ProductParentId != null)
                {
                    //TODO: using AvailableProduct of Long
                    // Nếu là General ProductViewModel => load tất cả các ProductViewModel con của nó
                    var productParentId = product.ProductParentId.Value;
                    _productChilds = Program.context.getAllProducts().Where(a => a.IsUsed == true && a.IsAvailable == true &&
                                                                        (a.ProductParentId == productParentId ||
                                                                         a.GeneralProductId == productParentId))
                        .ToList();

                    //Xóa general ProductViewModel khỏi list con
                    var genProduct = _productChilds.FirstOrDefault(q => q.ProductParentId == productParentId);
                    _productChilds.Remove(genProduct);
                    // Load tên các attribute của General ProductViewModel để hiển thị
                    _attributeNameList = new List<string>() { product.Att1, product.Att2, product.Att3 };
                }
                else if (product.GeneralProductId != null)
                {
                    // Nếu là 1 ProductViewModel con => load tất cả anh em cùng General ProductViewModel với nó
                    var generalProductId = product.GeneralProductId.Value;
                    _productChilds = Program.context.getAllProducts().Where(a => a.IsUsed == true && a.IsAvailable == true &&
                                                                        (a.ProductParentId == generalProductId ||
                                                                         a.GeneralProductId == generalProductId))
                        .ToList();
                    _product.Price = product.Price;
                    _isChangeMainItem = true;
                    _product = Mapper.Map<ProductViewModel, ProductViewModel>(product, _product);

                    //Lấy general ProductViewModel để load tên của nhóm attribute
                    var generalProduct = _productChilds.FirstOrDefault(q => q.ProductParentId == generalProductId);
                    //Xóa general ProductViewModel khỏi list con
                    _productChilds.Remove(generalProduct);
                    // Load tên các attribute của General ProductViewModel để hiển thị
                    _attributeNameList = new List<string>() { generalProduct.Att1, generalProduct.Att2, generalProduct.Att3 };
                }

                ////// Load các attributes

                _attributeList1 = _productChilds.GroupBy(p => p.Att1).Where(group => group.Key != null).Select(group => group.Key).ToList();
                _attributeList2 = _productChilds.GroupBy(p => p.Att2).Where(group => group.Key != null).Select(group => group.Key).ToList();
                _attributeList3 = _productChilds.GroupBy(p => p.Att3).Where(group => group.Key != null).Select(group => group.Key).ToList();
                //Duy - set default product
                //    if (MainForm.StoreInfo.IsAddDefaultGeneralProduct.Trim().ToLower() == "true")
                //{
                //    _productChild = product;
                //}
                //else
                //{
                //_productChild = _productChilds.FirstOrDefault();
                _productChild = parentOrderDetail.ProductViewModel;
                //}
                AddOrderDetail();
                _isChangeMainItem = true;
            }

            InitializeComponent();
            GenerateLayout();

            this.Show();
        }

        private void GenerateLayout()
        {
            try
            {
                pnlAttributeContainer.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

                //                pnlBottomPanel.Controls.Add(lblFinish);
                //
                //                txtPrice.Text = _product.Price.ToString("N0");
                //
                //                pnlAttributeContainer.Controls.Add(txtPrice);

                #region Render Attributes

                if (_attributeList1 != null)
                {
                    var attributeProperty1 = GeneratePropertyControls(_attributeList1, PropertyTypeEnum.Att1);
                    _attributeGroup1 = new PropertyGroupControl(attributeProperty1)
                    {
                        Name = _attributeNameList[0],
                        SortIndex = _attributeList1.Count,
                        Width = 500
                    };
                    _attributeGroup1.PropertyClick += propertyGroup_PropertyClick;
                    pnlAttributeContainer.Controls.Add(_attributeGroup1);
                }

                if (_attributeList2 != null)
                {

                    var attributeProperty2 = GeneratePropertyControls(_attributeList2, PropertyTypeEnum.Att2);

                    _attributeGroup2 = new PropertyGroupControl(attributeProperty2)
                    {
                        Name = _attributeNameList[1],
                        SortIndex = _attributeList2.Count,
                        Width = 500
                    };
                    _attributeGroup2.PropertyClick += propertyGroup_PropertyClick;
                    pnlAttributeContainer.Controls.Add(_attributeGroup2);
                }

                if (_attributeList3 != null)
                {
                    var attribute3Property = GeneratePropertyControls(_attributeList3, PropertyTypeEnum.Att3);

                    _attributeGroup3 = new PropertyGroupControl(attribute3Property)
                    {
                        Name = _attributeNameList[2],
                        Width = 500,
                        SortIndex = _attributeList3.Count
                    };
                    _attributeGroup3.PropertyClick += propertyGroup_PropertyClick;
                    pnlAttributeContainer.Controls.Add(_attributeGroup3);
                }

                #endregion


                #region Render Notes

                NotePanel pnlNote = new NotePanel(_product.CatID, _parentOrderDetail)
                {
                    Anchor =
                        ((System.Windows.Forms.AnchorStyles)
                            ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                               | System.Windows.Forms.AnchorStyles.Left)))),
                    Location = new System.Drawing.Point(0, 0),
                    Name = "pnlNote",
                    Size = new System.Drawing.Size(361, 659),
                };

                this.Controls.Add(pnlNote);

                #endregion

            }
            catch (Exception ex)
            {
                log.Error("GenerateLayout - " + ex);
            }
        }



        // Add new OrderDetail
        private void AddOrderDetail()
        {
            if (_productChild != null)
            {
                if (!_isChangeMainItem)
                {
                    // Add new orderDetail
                    currentOrderManager.ChangeItemQuantityOfOrderDetail(
                        OrderDetailChangeModeEnum.AddOrderDetail, _productChild, null, 1);

                    // Get lastest OrderDetailViewModel 
                    var orderDetailId = currentOrderManager.getCurrentOrderDetailId() - 1;

                    _parentOrderDetail = currentOrderManager.getOrderEditViewModel().OrderDetailEditViewModels.FirstOrDefault(
                                   od => od.OrderDetailID == orderDetailId);
                }
                else
                {
                    currentOrderManager.UpdateMainItemOfOrderDetail(_parentOrderDetail, _productChild);
                }
            }
            else
            {
                //TODO: implement this case
            }
        }

        private ProductViewModel GetProductByAttributes()
        {
            return _productChilds.FirstOrDefault(
                p => p.Att1 == _product.Att1 && p.Att2 == _product.Att2 && p.Att3 == _product.Att3);
        }


        public OrderDetailViewModel GetMainOrderDetail()
        {
            return _parentOrderDetail;
        }

        // Tạo Property controls dựa trên list đầu vào
        private List<PropertyControl> GeneratePropertyControls(List<string> attributeList, PropertyTypeEnum type)
        {
            var attributeProperty = new List<PropertyControl>();
            for (int i = 0; i < attributeList.Count; i++)
            {
                attributeProperty.Add(new PropertyControl()
                {
                    ButtonType = ButtonType.Toggle,
                    DisplayText = attributeList[i].Substring(0, 1),
                    Group = 1,
                    Type = (int)type,
                    Name = attributeList[i],
                    TextSize = 35,
                    X = i,
                    Y = 0
                });
            }
            var attri = attributeProperty.FirstOrDefault(
                a => a.Name == _productChild.Att1 || a.Name == _productChild.Att2 || a.Name == _productChild.Att3);
            if (attri != null)
            {
                attri.IsActive = true;
            }
            return attributeProperty;
        }

        private void propertyGroup_PropertyClick(PropertyControl obj)
        {
            OnClickOrderDetailControl(obj);
        }

        private void OnClickOrderDetailControl(PropertyControl obj)
        {
            try
            {
                // Reset all
                if (obj == null)
                {
                    //TODO: don't know how to handle this case
                }
                else
                {
                    PropertyTypeEnum type = (PropertyTypeEnum)obj.Type;
                    //Xử lý các trường hợp đang thao tác trên ProductAttributeForm
                    if (type == PropertyTypeEnum.Att1)
                    {
                        foreach (var p in _attributeGroup1.Properties)
                        {
                            Debug.WriteLine(p.IsActive.ToString());
                            if (obj.Name == p.Name)
                            {
                                _product.Att1 = obj.Name;
                                p.IsActive = true;
                            }
                        }
                    }
                    else if (type == PropertyTypeEnum.Att2)
                    {
                        foreach (var p in _attributeGroup2.Properties)
                        {
                            if (obj.Name == p.Name)
                            {
                                _product.Att2 = obj.Name;
                                p.IsActive = true;
                            }
                        }
                    }
                    else if (type == PropertyTypeEnum.Att3)
                    {
                        foreach (var p in _attributeGroup3.Properties)
                        {
                            if (obj.Name == p.Name)
                            {
                                _product.Att3 = obj.Name;
                                p.IsActive = true;
                            }
                        }
                    }

                    // Update Price of this ProductViewModel in view
                    _productChild = GetProductByAttributes();
                    //                    if (_productChild != null)
                    //                    {
                    //                        txtPrice.Text = _productChild.Price.ToString("N0");
                    //                    }
                    //                    else
                    //                    {
                    //                        txtPrice.Text = "0";
                    //                    }
                    AddOrderDetail();
                    _isChangeMainItem = true;
                }
            }
            catch (Exception ex)
            {
                log.Error("OnClickOrderDetailControl - " + ex);
            }

        }
    }
}
