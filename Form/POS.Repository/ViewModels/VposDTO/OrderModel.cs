using System;
using System.Collections.Generic;

namespace POS.Repository.ViewModels.VposDTO
{
    [Serializable]
    public class OrderModel
    {
        public string Code { get; set; } = "";
        public int TableNumber { get; set; } = 0;
        public List<OrderDetail> OrderDetailList { get; set; } = null;
        public string Note { get; set; } = "";
        public double TotalAmount { get; set; } = 0;
        public double FinalAmount { get; set; } = 0;
        public double DiscountPercent { get; set; } = 0;
        public int Status { get; set; }
    }
}
