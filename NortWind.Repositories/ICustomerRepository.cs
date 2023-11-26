using NorthWind.Models;
using System.Collections.Generic;

namespace NortWind.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
    }
}
