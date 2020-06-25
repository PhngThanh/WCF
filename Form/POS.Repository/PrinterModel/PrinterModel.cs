using POS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.PrinterModel
{
    public class OrderPrinterModel
    {

        public string OrderCode { get; set; }
        public int? TableId { get; set; }
        public int OrderType { get; set; }
        public int DeliveryStatus { get; set; }
        public string TableNumber { get; set; }
        public virtual string CheckInPerson { get; set; }
        public virtual string Notes { get; set; }
        public virtual System.DateTime CheckInDate { get; set; }
        public virtual int TotalInvoicePrint { get; set; }
        public virtual double TotalAmount { get; set; }
        public virtual double DiscountOrderDetail { get; set; }
        public virtual double Discount { get; set; }
        public virtual double VATAmount { get; set; }
        public virtual double FinalAmount { get; set; }
        public virtual string DeliveryCustomer { get; set; }
        public virtual string DeliveryPhone { get; set; }
        public virtual string DeliveryAddress { get; set; }
        public virtual string PasswordWifi { get; set; }
        public POS.Repository.ExchangeDataModel.CardCustomerModel CurrentCustomerModel { get; set; }
        public bool HasOrder { get; set; }

        public double SumFinalOrderDetail()
        {
            return TotalAmount - DiscountOrderDetail;
        }
        public int GetDiscountRate()
        {
            var sumOrderDetail = TotalAmount - DiscountOrderDetail;
            if (sumOrderDetail > 0 && Discount > 0)
            {
                return (int)(Discount * 100 / sumOrderDetail);
            }
            return 0;
        }

        //[NotMapped]
        public double GuestPayment {
            get {
                return this.PaymentPrinterModels.Where(p =>
                        p.Type != (int)POS.Repository.PaymentTypeEnum.AccountReceivable
                        && p.Type != (int)POS.Repository.PaymentTypeEnum.PaymentMember
                        && p.Type != (int)POS.Repository.PaymentTypeEnum.ExchangeCash)
                        .Sum(p => { if (p.Type == (int)POS.Repository.PaymentTypeEnum.ExchangeCash && p.Amount >= 0) { return -p.Amount; } else { return p.Amount; } });
            }
        }
        public List<PromotionPrinterModel> AppliedPromotions { get; set; }
        public List<OrderDetailPrinterModel> OrderDetailPrinterModels { get; set; }
        public List<PaymentPrinterModel> PaymentPrinterModels { get; set; }
        public List<OrderPromotionMappingPrinterModel> OrderPromotionMappingPrinterModels { get; set; }
    }

    public class OrderDetailPrinterModel
    {
        public virtual int Status { get; set; }
        public virtual int? ParentId { get; set; }
        public virtual int OrderDetailID { get; set; }
        public virtual string ProductCode { get; set; }
        public virtual string ProductName { get; set; }
        public virtual int ItemQuantity { get; set; }
        public virtual int? TmpDetailId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double UnitPrice { get; set; }
        public virtual double TotalAmount { get; set; }
        public virtual double Discount { get; set; }
        public virtual double FinalAmount { get; set; }
        public bool IsExtraProduct { get; set; }
        public virtual string Notes { get; set; }
        public int CatID { get; set; }

    }

    public class PaymentPrinterModel
    {
        public virtual int Type { get; set; }
        public virtual double Amount { get; set; }

    }

    public class OrderPromotionMappingPrinterModel
    {
        public virtual string PromotionCode { get; set; }
    }

    public class OrderDetailPromotionMappingPrinterModel
    {
        public virtual string PromotionCode { get; set; }

    }
    public class PromotionPrinterModel
    {
        //public virtual string PromotionCode { get; set; }
        public virtual string Description { get; set; }
        //public virtual int? PromotionType { get; set; }

    }
}
