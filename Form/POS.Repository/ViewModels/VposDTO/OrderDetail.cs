using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Repository.ViewModels.VposDTO
{
    [Serializable]
    public class OrderDetail
    {
        public int OrderDetailId { get; set; } = 0;
        public string ProductCode { get; set; } = "";
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double DiscountPercent { get; set; } = 0;
        public double TotalAmount { get; set; } = 0;
        public double FinalAmount { get; set; } = 0;
        public bool IsExtra { get; set; } = false;
        public bool IsShowed { get; set; } = false;
        public string Note { get; set; } = "";
        public int Status { get; set; }
        public int? ParentId { get; set; }
    }
}
