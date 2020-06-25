using POS.Repository.Entities;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace WcfAndSignalr.Implements
{
    [AspNetCompatibilityRequirements
    (
    RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed
    )]
    public class TableService : WcfAndSignalr.Interfaces.ITableService
    {
        private POS.Repository.Entities.Services.TableService tableService
            = ServiceManager.GetService<POS.Repository.Entities.Services.TableService>(typeof(TableRepository));


        public POS.Repository.Response.BaseResponse<Table> Add(Table t)
        {
            return tableService.Add(t);
        }

        public POS.Repository.Response.BaseResponse<bool> Delete(string id)
        {
            return tableService.Delete(id);
        }

        public POS.Repository.Response.BaseResponse<Table> Edit(Table t, string id)
        {
            return tableService.Edit(t, id);
        }

        public POS.Repository.Response.BaseResponse<Table> GetById(string id)
        {
            return tableService.GetById(id);
        }

        public POS.Repository.Response.BaseResponse<int> GetCount()
        {
            return tableService.GetCount();
        }

        public POS.Repository.Response.BaseResponse<IEnumerable<Table>> Gets()
        {
            return tableService.GetTablesByDictionary(Utils.Utils.GetFromQueryString2<Table>());
        }
    }
}
