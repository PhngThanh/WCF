using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class ProductExtraModel
    {
        public int ProductExtraId { get; set; }
        public string PrimaryProductCode { get; set; }
        public string ExtraProductCode { get; set; }
        public bool IsEnable { get; set; }
        public bool IsDisplayed { get; set; }
        public int MaxItem { get; set; }
        public double Price { get; set; }
        public double TimeStamp { get; set; }
        public bool IsUsed { get; set; }
    }
}
