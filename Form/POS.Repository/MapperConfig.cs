using AutoMapper;
using POS.Repository.Entities;
using POS.Repository.ViewModels;

namespace POS.Repository
{
    public static class MapperConfig
    {
        public static void CustomMapperConfig(IMapperConfiguration config)
        {
            config.CreateMap<Order, OrderEditViewModel>()
                .ForMember(q => q.OrderDetailEditViewModels, opt => opt.MapFrom(q => q.OrderDetails));
            config.CreateMap<DateReportViewModel,DateReport>();
        }
    }
}
