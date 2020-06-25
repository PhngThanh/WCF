using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.Interfaces
{
    [ServiceContract]
    public interface IBaseService<T>
    {
        #region get  with filter
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)
            ]
        POS.Repository.Response.BaseResponse<IEnumerable<T>> Gets();
        #endregion
        #region get count
        [OperationContract]
        [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "count")]
        POS.Repository.Response.BaseResponse<int> GetCount();
        #endregion
        #region get by id
        [OperationContract]
        [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "{id}")]
        POS.Repository.Response.BaseResponse<T> GetById(string id);
        #endregion
        #region add 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        POS.Repository.Response.BaseResponse<T> Add(T t);
        #endregion
        #region edit 
        [OperationContract]
        [WebInvoke(Method = "PUT",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "{id}")]
        POS.Repository.Response.BaseResponse<T> Edit(T t, string id);
        #endregion
        #region delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "{id}")]
        POS.Repository.Response.BaseResponse<bool> Delete(string id);
        #endregion
    }
}
