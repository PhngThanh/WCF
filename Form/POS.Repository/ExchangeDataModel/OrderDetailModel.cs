using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class OrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double FinalAmount { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
        public Nullable<double> TaxValue { get; set; }
        public double UnitPrice { get; set; }
        public Nullable<int> ProductType { get; set; }
        public int ProductOrderType { get; set; }
        public int ItemQuantity { get; set; }
        public int OrderGroup { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> TmpDetailId { get; set; }

        public int StoreId { get; set; }


        public List<OrderDetailPromotionMappingModel> OrderDetailPromotioMappingMs { get; set; }
        public Nullable<int> OrderPromotionMappingId { get; set; }
        public Nullable<int> OrderDetailPromotionMappingId { get; set; }
        public Nullable<int> PromotionMappingIndex { get; set; }

        public OrderDetailModel()
        {
            OrderDetailPromotioMappingMs = new List<OrderDetailPromotionMappingModel>();
        }
    }
}
