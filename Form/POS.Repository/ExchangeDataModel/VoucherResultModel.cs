using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class VoucherResultModel
    {
        public string VoucherCode { get; set; }
        public string PromotionCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public CardCustomerModel Customer { get; set; }
        public PromotionViewModel PromotionVM { get; set; }


    }
}
