using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class SendCustomerModel
    {
        public int TerminalID { get; set; }
        public  Customer { get; set; }
        //public string MembershipCardCode { get; set; }
        //public string MembershipCardTypeName { get; set; }
    }
}
