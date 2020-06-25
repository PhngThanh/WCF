using POS.Repository.Entities;
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
    public partial interface IStoreService : WcfAndSignalr.Interfaces.IBaseService<POS.Repository.Entities.Store>
    {
        #region get AuthorizeCode
        [OperationContract]
        [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "Generate/{id}")]
        POS.Repository.Response.BaseResponse<Store> GetGenerateCode(string id);
        #endregion

        #region get AuthorizeCodeByStoreID
        [OperationContract]
        [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "{id}/{authorizeCode}")]
        POS.Repository.Response.BaseResponse<Store> GetCodeByStoreId(string id, string authorizeCode);
        #endregion

        #region post Device Login
        [OperationContract]
        [WebInvoke(Method = "POST",
               ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
               UriTemplate = "{id}/{authorizeCode}")]
        POS.Repository.Response.BaseResponse<bool> Login(string id, string authorizeCode);
        #endregion

        #region get listStore
        [OperationContract]
        [WebInvoke(Method = "GET",
              ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
              UriTemplate = "AllStores")]
        IEnumerable<Store> GetStores();
        #endregion
    }
}
