using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Repositories
{
    public partial class OrderRepository
    {
        /// <summary>
        /// Get ALL (include Cancel, PreCancel...) Order
        /// </summary>
        /// <param name="fromDate">from date, include time</param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public IQueryable<Order> GetOrderReportViewModels(DateTime fromDate, DateTime toDate)
        {
            if (fromDate == toDate)
            {
                fromDate = fromDate.Date;
                toDate = toDate.Date.AddDays(1);
            }
            var orderReport =
                ((IQueryable<Order>)dbSet).Where(
                    o => o.OrderDetails.Any(od => od.OrderDate >= fromDate && od.OrderDate < toDate))
                    .Include(o => o.OrderDetails).Include(o => o.Payments);

            return orderReport;
        }
    }

    public partial interface IOrderRepository
    {
        IQueryable<Order> GetOrderReportViewModels(DateTime fromDate, DateTime toDate);
    }
}
