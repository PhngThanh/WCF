using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Utils;

namespace POS.SaleScreen.CustomControl
{
    public partial class CustomerItemList : UserControl
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CustomerViewModel Customer;

        public CustomerItemList()
        {
            InitializeComponent();
            this.BackColor = Color.Green;
            //pnlItemContainer.BackColor = Color.Yellow;

            lblUp.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;
            lblDown.Paint += DrawControlLibrary.OrderPanel.OrderItemList.DrawPagingButton;
            lblUp.Click += lblUp_Click;
            lblDown.Click += lblDown_Click;
            lblUp.Enabled = pnlItemContainer.Height > Height;
            lblDown.Enabled = pnlItemContainer.Top < 0;
            SizeChanged += ChangeSize;
            pnlItemContainer.SizeChanged += ChangeSize;
        }

        public void ReSize()
        {
            try
            {
                pnlItemContainer.Top = 0;
                pnlItemContainer.Height = 0;
                ClearItems();
            }
            catch (Exception ex)
            {
                log.Error("ReSize - " + ex);
            }
        }

        private void ChangeSize(object sender, EventArgs e)
        {
            try
            {
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
                pnlPaging.Visible = pnlItemContainer.Height > Height;
            }
            catch (Exception ex)
            {
                log.Error("ChangeSize - " + ex);
            }

        }

        private void lblUp_Click(object sender, EventArgs e)
        {
            try
            {
                pnlItemContainer.Top -= DrawControlLibrary.OrderPanel.OrderItemList.OrderItemHeight;
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
            }
            catch (Exception ex)
            {
                log.Error("lblUp_Click - " + ex);
            }
        }

        private void lblDown_Click(object sender, EventArgs e)
        {
            try
            {
                pnlItemContainer.Top += DrawControlLibrary.OrderPanel.OrderItemList.OrderItemHeight;
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
            }
            catch (Exception ex)
            {
                log.Error("lblDown_Click - " + ex);
            }

        }

        public void CheckPaging()
        {
            try
            {
                lblUp.Enabled = pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0);
                lblDown.Enabled = pnlItemContainer.Top < 0;
                pnlPaging.Visible = pnlItemContainer.Height > Height;
            }
            catch (Exception ex)
            {
                log.Error("CheckPaging - " + ex);
            }

        }

        //public void AddNewItem(OrderDetailViewModel orderItem)
        //{

        //        var label = new OrderItemControl(orderItem);
        //        label.Click += OrderItem_Click;
        //        pnlItemContainer.Controls.Add(label);
        //        CheckPaging();

        //}


        private void CustomerItem_Click(object sender, EventArgs e)
        {
            CustomerItemControl item = (CustomerItemControl)sender;
            DeactiveAllControls();
            item.IsActive = true;
            Customer = item.Customer;
            this.Hide();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="mode"></param>
        public void UpdateCustomerList(CustomerViewModel customer, OrderDetailChangeModeEnum mode)
        {
            try
            {
                //Cập nhật list
                if (customer == null) return;

                this.pnlItemContainer.Width = this.Width;

                if (mode == OrderDetailChangeModeEnum.AddOrderDetail)
                {
                    var label = new CustomerItemControl(customer)
                    {
                        Width = pnlItemContainer.Width
                    };
                    label.Click += CustomerItem_Click;
                    ////Set active cho item moi vừa add
                    //DeactiveAllControls();
                    //label.IsActive = true;

                    pnlItemContainer.Controls.Add(label);

                    //Load đến vị trí cuối cùng trong list
                    if (pnlItemContainer.Bottom > Height - (pnlPaging.Visible ? pnlPaging.Height : 0))
                        pnlItemContainer.Top -= label.Height;

                    CheckPaging();
                }
                else if (mode == OrderDetailChangeModeEnum.RemoveOrderDetail)
                {
                    foreach (CustomerItemControl control in pnlItemContainer.Controls)
                    {
                        if (control.Customer.CustomerName == customer.CustomerName)
                        {
                            pnlItemContainer.Controls.Remove(control);
                            CheckPaging();
                        }
                    }
                    ////Hide OrderDetailViewModel Form
                    //if (SaleScreen3.orderDetailForm != null && SaleScreen3.orderDetailForm.Visible)
                    //{
                    //    SaleScreen3.orderDetailForm.Hide();
                    //}
                }
                else if (mode == OrderDetailChangeModeEnum.ModifiedOrderDetail || mode == OrderDetailChangeModeEnum.UpdateOrderDetailInfo)
                {
                    //Mode update - Update OrderPanelItemList
                    foreach (CustomerItemControl control in pnlItemContainer.Controls)
                    {
                        if (control.Customer.CustomerName == customer.CustomerName)
                        {
                            //var tmpOds = orderDetails;
                            //control.OrderItems = tmpOds;//Cap nhat danh sach moi
                            //control.RenewUi();
                        }
                    }
                    ////Cập nhật OrderDetailForm khi dang mo-- IMPORTANT
                    //if (SaleScreen3.orderDetailForm != null && SaleScreen3.orderDetailForm.Visible)
                    //{
                    //    SaleScreen3.orderDetailForm.UpdateOrderDetailForm();
                    //}

                }
            }


            catch (Exception ex)
            {
                log.Error("UpdateCustomerList - " + ex);
            }
        }

        //public void GenerateCustomerList(List<Customer> customers)
        //{
        //    try
        //    {
        //        ClearItems();


        //        if (customers != null && customers.Count > 0)
        //        {
        //            //duyet qua danh sach cac OrderDetail
        //            //Gom nhom cac OrderDetailViewModel theo mainitem và cac extra di kem
        //            //Moi nhom la 1 List tuong ung 1 elment cua orList
        //            //List<List<OrderDetailEditViewModel>> orList = new List<List<OrderDetailEditViewModel>>();
        //            //ProductService productService = ServiceManager.GetService<ProductService>(typeof(ProductRepository));

        //            //foreach (var c in customers)
        //            //{
        //            //        //main item => add to orlist
        //            //        List<Cus> mainItemList = new List<OrderDetailEditViewModel>();
        //            //        mainItemList.Add(c);
        //            //        orList.Add(mainItemList);
        //            //}
        //            //duyet qua list 
        //            foreach (var c in customers)
        //            {
        //                var label = new CustomerItemControl(c);
        //                label.Width = pnlItemContainer.Width;
        //                label.Click += CustomerItem_Click;
        //                pnlItemContainer.Controls.Add(label);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}


        public void ClearItems()
        {
            pnlItemContainer.Controls.Clear();
            foreach (Control c in this.pnlItemContainer.Controls)
            {
                c.Dispose();
            }

            CheckPaging();
        }

        private void DeactiveAllControls()
        {
            foreach (var itm in pnlItemContainer.Controls.Cast<CustomerItemControl>().Where(itm => itm.IsActive))
            {
                itm.IsActive = false;
            }
        }
    }
}
