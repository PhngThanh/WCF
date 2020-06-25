using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using System;
using POS.Repository.Entities;

namespace POS.Repository.ViewModels
{
    public partial class OrderEditViewModel : OrderViewModel
    {
        public List<PaymentEditViewModel> PaymentEditViewModels { get; set; }
        public List<OrderDetailEditViewModel> OrderDetailEditViewModels { get; set; }
        public List<OrderPromotionMappingEditViewModel> OrderPromotionMappingEditViewModels { get; set; }
        
        public OrderEditViewModel()
        {
            PaymentEditViewModels = new List<PaymentEditViewModel>();
            OrderDetailEditViewModels = new List<OrderDetailEditViewModel>();
            OrderPromotionMappingEditViewModels = new List<OrderPromotionMappingEditViewModel>();
            PrefixBarCodes = new List<string>();
        }

        public OrderEditViewModel getOrderEditViewModel()
        {
            return this;
        }
        public OrderEditViewModel(OrderViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }

        //getter and setter for fiedl 
        public List<PaymentEditViewModel> getPaymentEditViewModels()
        {
            return PaymentEditViewModels;
        }
        public void setPaymentEditViewModels(List<PaymentEditViewModel> modelList)
        {
            PaymentEditViewModels = modelList;
        }

        public void addPaymentEditViewModels(PaymentEditViewModel model)
        {
            PaymentEditViewModels.Add(model);
        }

        public void deletePaymentEditViewModel(PaymentEditViewModel model)
        {
            PaymentEditViewModels.Remove(model);
        }

        public List<OrderDetailEditViewModel> getOrderDetailEditViewModelsList()
        {
            return OrderDetailEditViewModels.ToList();
        }

        public List<OrderDetailEditViewModel> getOrderDetailEditViewModels()
        {
            return OrderDetailEditViewModels;
        }





        //[NotMapped]
        //public double DiscountRate { get; set; }//Kg luu database


        //Tong gia tri cua OrderDetail (chua giam gia tren Order)
        public double SumFinalOrderDetail()
        {
            return TotalAmount - DiscountOrderDetail;
        }

        //[NotMapped]
        //public double ExcessCash { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán (đã trừ đi tiền trả lại)
        /// </summary>
        [NotMapped]
        public double TotalPayment
        {
            get
            {
                return this.PaymentEditViewModels.Where(p =>
                                p.Type != (int)PaymentTypeEnum.AccountReceivable
                                && p.Type != (int)PaymentTypeEnum.PaymentMember)
                            .Sum(p => p.Amount);
            }
        }

        /// <summary>
        /// Tổng tiền khách đưa (chưa trừ đi tiền trả lại)
        /// </summary>
        [NotMapped]
        public double GuestPayment {
            get
            {
                return this.PaymentEditViewModels.Where(p =>
                        p.Type != (int)PaymentTypeEnum.AccountReceivable
                        && p.Type != (int)PaymentTypeEnum.PaymentMember
                        && p.Type != (int)PaymentTypeEnum.ExchangeCash)
                        .Sum(p => { if (p.Type == (int)PaymentTypeEnum.ExchangeCash && p.Amount >= 0) { return -p.Amount; } else { return p.Amount; } });
            }
        }

        /// <summary>
        /// Tổng tiền mặt đã trả lại khách
        /// </summary>
        [NotMapped]
        public double ExchangedCash
        {
            get
            {
                return this.PaymentEditViewModels
                            .Where(p => p.Type == (int)PaymentTypeEnum.ExchangeCash)
                            .Sum(p => p.Amount);
            }
        }

        [NotMapped]
        public string TableNumber { get; set; }

        [NotMapped]
        public bool HasOrderId { get; set; }

        [NotMapped]
        public string BarCode { get; set; }

        [NotMapped]
        public string PrefixBarCode { get; set; }

        public List<string> PrefixBarCodes { get; set; }

        public void ResetPayment()
        {
            TotalAmount = 0;
            FinalAmount = 0;
            Discount = 0;
            DiscountOrderDetail = 0;
            VAT = 0;
            VATAmount = 0;

            foreach (var p in PaymentEditViewModels)
            {
                p.Amount = 0;
            }
        }

        /// <summary>
        /// Update data after load old order form database
        /// </summary>
        public void UpdateDateAfterLoad()
        {
            //HasOrderId & HasOrderDetailId = true
            //Để xác định order cũ
            HasOrderId = true;
            foreach (var detail in OrderDetailEditViewModels)
            {
                detail.HasOrderDetailId = true;

                //Update lại discount rate
                detail.DiscountRate = detail.GetDiscountRate();
            }
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


    }
}
