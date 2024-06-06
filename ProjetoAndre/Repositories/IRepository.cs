using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository
    {
        void ClientInsert(Client client);
        void EmployeeInsert(Employee employee);
        void SaleInsert(Sale sale);
        void PurchaseInsert(Purchase purchase);


    }
}
