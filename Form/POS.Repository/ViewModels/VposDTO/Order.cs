using System;
using System.Collections.Generic;

namespace POS.Repository.ViewModels.VposDTO
{
    [Serializable]
    public class Order
    {
        public Order()
        {
            this.OrderDetailDictionary = new Dictionary<OrderDetail, List<OrderDetail>>();
        }
        public string Code { get; set; } = "";
        public int TableNumber { get; set; } = 0;
        public Dictionary<OrderDetail, List<OrderDetail>> OrderDetailDictionary { get; set; }
        public string Note { get; set; } = "";
        public double TotalAmount { get; set; }
        public double FinalAmount { get; set; }
        public double DiscountPercent { get; set; }
    }
}
