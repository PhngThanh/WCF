using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class CardAccountModel
    {
        public string AccountCode { get; set; }
        public double? Balance { get; set; }
        public string ProductCode { get; set; }
        public int? Type { get; set; }
        public int? Level { get; set; }
        public int? BrandId { get; set; }
    }
}
