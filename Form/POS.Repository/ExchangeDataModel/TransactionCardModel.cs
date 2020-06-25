using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class TransactionCardModel
    {
        public string Token { get; set; }
        public int TerminalId { get; set; }
        public List<TransactionAccountModel> Accounts { get; set; }
        public string UserId { get; set; }
        public string table_number { get; set; }
        public string bill_id { get; set; }
        public string Customer { get; set; }
        public string TransactionCode { get; set; }
    }
}
