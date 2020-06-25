using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class CardCustomerModel
    {
        public int? CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }

        public string CustomerPhone { get; set; }
        public int? cardType { get; set; }
        public string CustomerAddress { get; set; }
        //public string Message { get; set; }
        public List<CardAccountModel> Accounts { get; set; }

        public CardCustomerModel()
        {
            Accounts = new List<CardAccountModel>();
        }
    }
}
