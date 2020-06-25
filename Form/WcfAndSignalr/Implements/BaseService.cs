using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.Response;

namespace WcfAndSignalr.Implements
{
    public class BaseService<T> : WcfAndSignalr.Interfaces.IBaseService<T>
    {
        public POS.Repository.Response.BaseResponse<T> Add(T t)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<T> Edit(T t, string id)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<T> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            throw new NotImplementedException();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<T>> Gets()
        {
            throw new NotImplementedException();
        }
    }
}
