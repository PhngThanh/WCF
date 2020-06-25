using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public class CustomerEditViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IDCard { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public int TerminalId { get; set; }
        public string MembershipCardCode { get; set; }
        public virtual System.DateTime CreatedTime { get; set; }
    }
}
