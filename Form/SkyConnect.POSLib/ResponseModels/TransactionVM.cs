using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.ResponseModels
{
    public class TransactionVM
    {
        public int Id { get; set; }
        public Nullable<int> AccountId { get; set; }
        public Nullable<int> CardId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string TransactionCode { get; set; }
        public Nullable<decimal> FCAmount { get; set; }
        public System.DateTime Date { get; set; }
        public string Notes { get; set; }
        public bool IsIncreaseTransaction { get; set; }
        public int Status { get; set; }
        public int StoreId { get; set; }
        public int BrandId { get; set; }
        public string UserId { get; set; }
        public int TransactionType { get; set; }
        public string AccountCode { get; set; }
        public string CardCode { get; set; }
        public Nullable<int> PartnerId { get; set; }
        public Nullable<int> OrderId { get; set; }
    }
}
