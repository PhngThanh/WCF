using Newtonsoft.Json;
using POS.Repository.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class VoucherModel
    {
        public string token { get; set; }
        public int terminalId { get; set; }
        public string voucherCode { get; set; }
        public int storeId { get; set; }
        public OrderAPIViewModel Order { get; set; }
        [JsonProperty(PropertyName = "MembershipCardCode")]
        public string MembershipCardCode { get; set; }

    }

    public class UseVoucherModel
    {
        public VoucherModel voucher { get; set; }
        public string transactionId { get; set; }
        public List<ItemsUserVoucherModel> items { get; set; }
        public int? applyToPartner { get; set; }
    }

    public class ItemsUserVoucherModel
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public double price { get; set; }
        public double amount { get; set; }
        public int quantity { get; set; }
        public double discount_amount { get; set; }

    }
}
