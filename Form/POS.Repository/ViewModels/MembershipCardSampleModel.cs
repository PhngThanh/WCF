using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public class MembershipCardSampleModel
    {
        public string MembershipCardCode { get; set; }
        public Nullable<int> MembershipTypeId { get; set; }
        public List<SampleAccount> Account { get; set; }
    }

    public class SampleAccount
    {
        public Nullable<decimal> Balance { get; set; }
        public Nullable<int> Type { get; set; }
    }
}
