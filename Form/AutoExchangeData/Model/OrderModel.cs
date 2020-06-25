using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoExchangeData
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public Nullable<System.DateTime> CheckOutDate { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountOrderDetail { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public string Notes { get; set; }
        public string FeeDescription { get; set; }
        public string CheckInPerson { get; set; }
        public string CheckOutPerson { get; set; }
        public string ApprovePerson { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> SourceID { get; set; }
        public Nullable<int> TableId { get; set; }
        public bool IsFixedPrice { get; set; }
        public Nullable<System.DateTime> LastRecordDate { get; set; }
        public string ServedPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryCustomer { get; set; }
        public int TotalInvoicePrint { get; set; }
        public double VAT { get; set; }
        public double VATAmount { get; set; }
        public int NumberOfGuest { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }
        public int GroupPaymentStatus { get; set; }
        public int StoreId { get; set; }

        public List<OrderDetailModel> OrderDetailMs { get; set; }
        public List<PaymentModel> PaymentMs { get; set; }

        public OrderModel()
        {
            OrderDetailMs = new List<OrderDetailModel>();
            PaymentMs = new List<PaymentModel>();
        }
    }
}
