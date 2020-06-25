using SkyConnect.POSLib.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Domains.APIs
{
    public interface IAPI<T> where T : class
    {
        BaseResponse<T> GetById(int id, int partnerId);
        BaseResponse<T> Create(T viewModel, int partnerId);
        BaseResponse<T> Update(T viewModel, int partnerId);
        BaseResponse<T> Delete(int id, int partnerId);
    }
}
