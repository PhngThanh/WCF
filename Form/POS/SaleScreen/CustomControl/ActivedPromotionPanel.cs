using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Repository.ViewModels;

namespace POS.SaleScreen.CustomControl
{
    public partial class ActivedPromotionPanel : UserControl
    {
        public OrderPromotionMappingEditViewModel PromotionMapping { get; set; }

        public string PromotionName { get; set; }
        public string PromotionDetail { get; set; }

        public Action<OrderPromotionMappingEditViewModel> RemovePromotionEvent;


        public ActivedPromotionPanel(string promotionName, string promotionDetail, OrderPromotionMappingEditViewModel promotionMapping)
        {
            this.PromotionName = promotionName;
            this.PromotionDetail = promotionDetail;
            this.PromotionMapping = promotionMapping;

            InitializeComponent();
            GenerateLayout();
        }

        public void GenerateLayout()
        {
            lblName.Text = this.PromotionName;
            lblDescription.Text = this.PromotionDetail;
            //TODO:
            if (PromotionMapping.OrderId == 0)
            {
                lblResult.Text = "Đã giảm hóa đơn " + string.Format("{0:n0}", PromotionMapping.DiscountAmount);
                lblResult.Font = new Font(lblResult.Font, FontStyle.Bold);
                lblDescription.Font = new Font(lblDescription.Font, FontStyle.Bold);
                lblName.Font = new Font(lblName.Font, FontStyle.Bold | FontStyle.Underline);
            }
            else if (PromotionMapping.OrderId == -1)
            {
                lblResult.Text = "Đã giảm sản phẩm " + string.Format("{0:n0}", PromotionMapping.DiscountAmount);
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            if (RemovePromotionEvent != null)
            {
                RemovePromotionEvent(PromotionMapping);
            }
        }
    }
}
