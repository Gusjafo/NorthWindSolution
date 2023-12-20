using NorthWind.Models;
using System.Collections.Generic;

namespace NortWind.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<SupplierList> SupplierPagedList(int page, int rows, string key);
    }
}
