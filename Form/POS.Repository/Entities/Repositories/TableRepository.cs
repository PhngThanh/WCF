using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial interface ITableRepository
    {
        Table GetTableById(int id);
    }

    public partial class TableRepository
    {
        public Table GetTableById(int id)
        {
            return dbSet.FirstOrDefault(t => t.Id == id);
        }
    }
}
