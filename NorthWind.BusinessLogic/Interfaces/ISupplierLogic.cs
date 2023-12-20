using NorthWind.Models;
using System.Collections.Generic;

namespace NorthWind.BusinessLogic.Interfaces
{
    public interface ISupplierLogic
    {
        Supplier GetById(int id);
        IEnumerable<SupplierList> SupplierPagedList(int page, int rows, string key);
        int Insert(Supplier supplier);
        bool Update(Supplier supplier);
        bool Delete(Supplier supplier);
    }
}
