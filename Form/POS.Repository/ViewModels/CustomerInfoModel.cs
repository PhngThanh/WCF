using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
{
    public class CustomerInfoModel
    {
        public string CustomerName { get; set; }
        public string CustomerCompany { get; set; }
        public string CustomerCompanyAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string CustomerTaxCode { get; set; }
        public string CustomerAccountNo { get; set; }
    }
}
