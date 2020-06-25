using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.Interfaces
{
    [ServiceContract]
    public interface IPromotionService : WcfAndSignalr.Interfaces.IBaseService<POS.Repository.Entities.Promotion>
    {
    }
}
