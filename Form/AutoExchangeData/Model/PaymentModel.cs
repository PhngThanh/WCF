﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoExchangeData
{
    public class PaymentModel
    {
        public int PaymentID { get; set; }
        public int OrderId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal FCAmount { get; set; }
        public string Notes { get; set; }
        public System.DateTime PayTime { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}