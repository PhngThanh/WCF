using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class TransactionAccountModel
    {
        public string AccountCode { get; set; }
        public bool IsChange { get; set; }
        public bool IsIncrease { get; set; }
        public decimal ChangeAmount { get; set; }
        public string TransactionCode { get; set; }
    }
}
