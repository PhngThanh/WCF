﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Repository.ViewModels
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
        public int OrderId { get; set; }
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
        PromotionChange = 5,
        NoThing = 0
    }
}
