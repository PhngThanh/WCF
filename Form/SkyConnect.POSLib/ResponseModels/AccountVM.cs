using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.ResponseModels
{
    public class AccountVM
    {
        public int AccountID { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public short Level_ { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<double> Balance { get; set; }
        public int MembershipId { get; set; }
        public int Type { get; set; }
        public int BrandId { get; set; }
        public bool Active { get; set; }
    }
}
