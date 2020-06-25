using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class PromotionDetailModel
    {
        public int PromotionDetailID { get; set; }
        public string PromotionCode { get; set; }
        public string PromotionDetailCode { get; set; }
        public string RegExCode { get; set; }
        public Nullable<double> MinOrderAmount { get; set; }
        public Nullable<double> MaxOrderAmount { get; set; }
        public string BuyProductCode { get; set; }
        public Nullable<int> MinBuyQuantity { get; set; }
        public Nullable<int> MaxBuyQuantity { get; set; }
        public string GiftProductCode { get; set; }
        public int GiftQuantity { get; set; }
        public Nullable<double> DiscountRate { get; set; }
        public Nullable<double> DiscountAmount { get; set; }
    }
}
