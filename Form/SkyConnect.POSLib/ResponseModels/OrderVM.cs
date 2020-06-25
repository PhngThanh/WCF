using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.ResponseModels
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
        public string OrderTotalQuantity { get; set; }
        public Nullable<System.DateTime> CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public string Notes { get; set; }
        public string ApprovePerson { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> VATAmount { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }
        [JsonProperty("table_number")]
        public string TableNumber { get; set; }
        [JsonProperty("card_code")]
        public string CardCode { get; set; }

        [JsonProperty("payment_code")]
        public string PaymentCode { get; set; }
        public IEnumerable<TransactionVM> ListTransaction { get; set; }
    }
}