using AutoMapper;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ExchangeData
{
    public static class AutoMapHelper
    {
        private static MapperConfiguration MapperConfig = new MapperConfiguration(cfg => {
            cfg.CreateMap<OrderViewModel, OrderAPIViewModel>();
          
            
        });
        private static IMapper MapperInstance;
        public static IMapper GetMapperInstance()
        {
            if (MapperInstance == null)
            {
                MapperInstance = MapperConfig.CreateMapper();
            }

            return MapperInstance;
        }
    }

}
