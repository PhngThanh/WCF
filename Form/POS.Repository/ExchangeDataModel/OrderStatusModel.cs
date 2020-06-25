namespace POS.Repository.ExchangeDataModel
{
    public class OrderStatusModel
    {
        public int OrderStatus { get; set; }
        public int DeliveryStatus { get; set; }
        public string InvoiceId { get; set; }
        public string CheckInPerson { get; set; }
    }

    public class MessageSend
    {
        public int RentId { get; set; }
        public int NotifyType { get; set; }
        public string Content { get; set; }
        public int CountQueue { get; set; }
        public bool CheckFlag { get; set; }
    }

    public enum NotifyMessageType
    {
        AccountChange = 1,
        ProductChange = 2,
        CategoryChange = 3,
        OrderChange = 4,
        NoThing = 0
    }
}
