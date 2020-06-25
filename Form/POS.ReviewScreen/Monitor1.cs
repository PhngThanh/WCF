using POS.Repository.Entities.Services;
using POS.ReviewScreen.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.ReviewScreen
{
    public partial class FullSreen : Form
    {
        int _orderID = -1;



        public FullSreen()
        {
            InitializeComponent();
            LoadRecentOrder();
           
        }


        public void LoadRecentOrder()
        {
            var order = ServiceManager.GetDbEntities().Orders.OrderByDescending(q => q.CheckInDate).FirstOrDefault();
            lblOrderCode.Text = MainForm.ResManager.GetString("Sys_Name",MainForm.CultureInfo)+": " + order.OrderCode.ToString();
            _orderID = order.OrderId;
        }


        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            var orderDetails = ServiceManager.GetDbEntities().OrderDetails.Where(q => q.OrderId == _orderID).ToList();
            dgvOrderDetail.DataSource = orderDetails;
        }

        private void dgvOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var productCode = dgvOrderDetail.Rows[e.RowIndex].Cells[3].Value.ToString();
                var product = ServiceManager.GetDbEntities().Products.FirstOrDefault(q => q.Code == productCode);
                lblProName.Text = product.ProductName;
                lblPrice.Text = product.Price.ToString();
                lblAttribute.Text = product.Att2;
            }
        }

        private void FullSreen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Monitor2 monitor2 = new Monitor2();
            monitor2.Show();

        }


        
    }   
}
