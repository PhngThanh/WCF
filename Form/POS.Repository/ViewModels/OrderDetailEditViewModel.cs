using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using POS.Repository.Entities;

namespace POS.Repository.ViewModels
{
    public partial class OrderDetailEditViewModel : OrderDetailViewModel
    {
        public List<ItemPropertyValue> ItemProperties { get; set; }
        public List<OrderDetailPromotionMappingEditViewModel> OrderDetailPromotionMappingEditViewModels { get; set; }

        public OrderPromotionMappingEditViewModel OrderPromotionMappingEditViewModel { get; set; }
        public OrderDetailPromotionMappingEditViewModel OrderDetailPromotionMappingEditViewModel { get; set; }

        public OrderDetailEditViewModel()
        {
            ItemProperties = new List<ItemPropertyValue>();
            OrderDetailPromotionMappingEditViewModels = new List<OrderDetailPromotionMappingEditViewModel>();
        }

        public OrderDetailEditViewModel(OrderDetailViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }
        [JsonIgnore]
        public OrderEditViewModel OrderEditViewModel { get; set; }
        public ProductViewModel ProductViewModel { get; set; }

        [NotMapped]
        public int SplitState { get; set; }

        public double DiscountRate { get; set; }

        public int GetDiscountRate()
        {
            if (Discount > 0)
            {
                return (int)(Discount / TotalAmount * 100);
            }
            return 0;
        }

        public int CatId { get; set; }

        public void SetAmountToZero()   
        {
            //Keep quantity 
            TotalAmount = 0;
            Discount = 0;
            FinalAmount = 0;
        }

        public void SetItemQuantity(int itemQuan, int quantity)
        {
            ItemQuantity = itemQuan;
            Quantity = quantity;
            TotalAmount = Quantity * UnitPrice;
            //Discount = TotalAmount * DiscountRate / 100;
            //FinalAmount = TotalAmount - Discount;
        }

        public void UpdateExtraQuantity(int mainItemQuantity)
        {
            Quantity = ItemQuantity * mainItemQuantity;
            TotalAmount = Quantity * UnitPrice;
            //Discount = TotalAmount * DiscountRate / 100;
            //FinalAmount = TotalAmount - Discount;
        }

        public void SetDiscount(int discountRate)
        {
            DiscountRate = discountRate;
            Discount = TotalAmount * DiscountRate / 100;
            FinalAmount = TotalAmount - Discount;
        }

        public bool IsExtra { get; set; }

        public bool HasOrderDetailId { get; set; }
        public class ItemPropertyValue
        {
            public int Type { get; set; }
            public int Group { get; set; }
            public int Value { get; set; }
        }
    }
}
