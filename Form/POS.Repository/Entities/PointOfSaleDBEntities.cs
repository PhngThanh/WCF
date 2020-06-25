using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities
{
    public partial class PointOfSaleDBEntities
    {
        public PointOfSaleDBEntities(string connectionString)
           : base(connectionString)
        {

        }
    }
}
