using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Repository.Entities.Repositories;
using POS.Repository.ViewModels;

namespace POS.Repository.Entities.Services
{
    public partial interface ITableService
    {
        IEnumerable<Table> GetAvailableTables();
        int StoreHasFloor();
        void UpdateTableStatus(TableViewModel tableViewModel);

        Response.BaseResponse<Table> Add(Table t);
        Response.BaseResponse<Table> Edit(Table t, string id);
        Response.BaseResponse<bool> Delete(string id);
        Response.BaseResponse<Table> GetById(string id);
        Response.BaseResponse<IEnumerable<Table>> GetTablesByDictionary(Dictionary<string, object> dictionary);
        Response.BaseResponse<int> GetCount();
    }

    public partial class TableService
    {
        private const string ORDER_BY = "Id";


        public IEnumerable<Table> GetAvailableTables()
        {
            int notUse = (int)TableStatusEnum.NotUse;
            return Get().Where(t => t.Status != notUse);
        }

        public int StoreHasFloor()
        {
            int maxFloor = 0;
            List<Table> tables = Get(t => t.Floor != maxFloor).ToList();
            if (tables != null && tables.Count > 0)
            {
                for (int i = 0; i < tables.Count; i++)
                {
                    if (tables[i].Floor > maxFloor)
                    {
                        maxFloor = tables[i].Floor;
                    }
                }
            }

            return maxFloor;
        }

        public void UpdateTableStatus(TableViewModel tableViewModel)
        {
            var table = repository.FirstOrDefault(t => t.Id == tableViewModel.Id);
            if (table != null)
            {
                table.Status = tableViewModel.Status;
                table.CurrentOrderId = tableViewModel.CurrentOrderId;
                table.CurrentOrderDate = tableViewModel.CurrentOrderDate;

                repository.Edit(table);
                repository.Save();
            }
        }

        public Response.BaseResponse<Table> Add(Table t)
        {
            var result = new POS.Repository.Response.BaseResponse<Table>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidTable(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (repository.FirstOrDefault(tbl => tbl.Number == t.Number) != null)
            {
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = "TableNumber is duplicated";
                return result;
            }

            try
            {
                repository.Add(t);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.CREATED;
                result.Data = t;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        public Response.BaseResponse<IEnumerable<Table>> GetTablesByDictionary(Dictionary<string, object> dictionary)
        {
            var result = new Response.BaseResponse<IEnumerable<Table>>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
            };
            try
            {
                IQueryable<Table> entities = Utils.FilterIQueryableByDictionary(repository.Get(), dictionary, ORDER_BY);
                entities = Utils.PagingIQueryable(entities, dictionary, ORDER_BY);

                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = entities.ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = ex is ArgumentNullException || ex is FormatException || ex is OverflowException 
                    ? (int)ResponseStatusEnum.BADREQUEST : (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<int> GetCount()
        {
            var result = new Response.BaseResponse<int>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = 0
            };
            try
            {
                int count = repository.Get().Count();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = count;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
            }
            return result;
        }

        public Response.BaseResponse<Table> GetById(string id)
        {
            int entityId = 0;
            var result = new POS.Repository.Response.BaseResponse<Table>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                entityId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Table entity = repository.FirstOrDefault(e => e.Id == entityId);
            if (entity == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
            }
            else
            {
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = entity;
            }

            return result;
        }

        public Response.BaseResponse<bool> Delete(string id)
        {
            int tableId = 0;
            var result = new POS.Repository.Response.BaseResponse<bool>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR,
                Data = false
            };

            try
            {
                tableId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            Table entity = repository.FirstOrDefault(p => p.Id == tableId);
            if (entity == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }
            else
            {
                try
                {
                    repository.Delete(entity);
                    repository.Save();
                    result.Success = true;
                    result.Status = (int)ResponseStatusEnum.NOCONTENT;
                    result.Data = true;
                    return result;
                }
                catch (System.Exception ex)
                {
                    result.Status = (int)ResponseStatusEnum.ERROR;
                    result.Success = false;
                    result.Data = true;
                    result.Message = ex.Message;
                    return result;
                }
            }
        }

        public Response.BaseResponse<Table> Edit(Table t, string id)
        {
            int tableId = 0;

            var result = new POS.Repository.Response.BaseResponse<Table>()
            {
                Success = false,
                Status = (int)ResponseStatusEnum.ERROR
            };

            try
            {
                tableId = int.Parse(id);
            }
            catch (System.Exception)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (t == null)
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }

            if (!IsValidTable(t))
            {
                result.Status = (int)ResponseStatusEnum.BADREQUEST;
                return result;
            }
            TableRepository tableRepository = new TableRepository(ServiceManager.GetDbEntities());
            Table table = tableRepository.GetTableById(tableId);
            if (table == null)
            {
                result.Status = (int)ResponseStatusEnum.NOTFOUND;
                return result;
            }

            try
            {
                table = (Table)AutoMapper.Mapper.Map(t, typeof(Table), typeof(Table));
                repository.Edit(table);
                repository.Save();
                result.Success = true;
                result.Status = (int)ResponseStatusEnum.OK;
                result.Data = t;
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Status = (int)ResponseStatusEnum.ERROR;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }

        private bool IsValidTable(Table t)
        {
            if (!string.IsNullOrEmpty(t.Number))
            {
                if (t.Number.Length > 50)
                {
                    return false;
                }
            }

            return true;
        }
    }


}
