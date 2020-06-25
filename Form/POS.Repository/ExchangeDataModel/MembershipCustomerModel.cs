using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class MembershipCustomerModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int TerminalId { get; set; }
        public String StoreId { get; set; }
        public string MembershipCardCode { get; set; }
        public virtual System.DateTime CreatedTime { get; set; }
        public string SampleShipCardCode { get; set; }
        public string ProductCode { get; set; }

    }
}
