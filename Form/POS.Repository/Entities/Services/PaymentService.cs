using POS.Repository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.Entities.Services
{
    public partial class PaymentService
    {
        public void RemoveRange(IEnumerable<Payment> list)
        {
            foreach (var item in list)
            {
                var dbItem = repository.Get(item.PaymentID);
                if (dbItem != null)
                {
                    repository.Delete(dbItem);
                }
            }
            repository.Save();
        }
    }

    public partial interface IPaymentService
    {
        void RemoveRange(IEnumerable<Payment> list);
    }
}
