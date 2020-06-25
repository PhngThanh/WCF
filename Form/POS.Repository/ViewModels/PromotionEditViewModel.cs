using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace POS.Repository.ViewModels
{
    public partial class PromotionEditViewModel : PromotionViewModel, ICloneable
    {
        public List<PromotionDetailViewModel> PromotionDetailViewModels { get; set; }

        public PromotionEditViewModel()
        {
            PromotionDetailViewModels = new List<PromotionDetailViewModel>();
        }

        public PromotionEditViewModel(PromotionViewModel orginal, IMapper mapper)
        {
            mapper.Map(orginal, this);
        }

        //Create copy new object with different address
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Kiểm tra hạn promotion
        /// </summary>
        /// <param name="dateCheck"></param>
        /// <returns></returns>
        public bool IsAvailableDate(DateTime dateCheck)
        {
            bool canApply = true;

            if (!this.IsActive)
            {
                canApply = false;
            }
            if (dateCheck < this.FromDate || this.ToDate < dateCheck)
            {
                canApply = false;
            }
            if (this.ApplyFromTime != null && this.ApplyToTime != null)
            {
                if (dateCheck.Hour < this.ApplyFromTime || this.ApplyToTime < dateCheck.Hour)
                {
                    canApply = false;
                }
            }

            return canApply;
        }
    }
}
