using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public class CustomerEditViewModel2
    {
        public int CustomerID { get; set; }
        public virtual Nullable<int> Type { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BirthDay { get; set; }
        public string IDCard { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
    public class CustomerEditViewModel3
    {
        public string message { get; set; }
        public bool success { get; set; }
        public CustomerEditViewModel2 customer { get; set; }
    }
}
