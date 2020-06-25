using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class MembershipCardSampleModel
    {
        public string ProductCode { get; set; }
        public string MembershipCardCode { get; set; }
        public Nullable<int> MembershipTypeId { get; set; }
        public List<SampleAccount> Account { get; set; }
    }
    public class SampleAccount
    {
        public SampleAccount(decimal? balance, int? type)
        {
            this.Balance = balance;
            this.Type = type;
        }
        public Nullable<decimal> Balance { get; set; }
        public Nullable<int> Type { get; set; }
        
    }
}
