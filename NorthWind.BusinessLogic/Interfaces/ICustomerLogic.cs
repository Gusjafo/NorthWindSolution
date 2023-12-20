using NorthWind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.BusinessLogic.Interfaces
{
    public interface ICustomerLogic
    {
        Customer GetById(int id);
        IEnumerable<CustomerList> CustomerPagedList(int page, int rows);
        int Insert(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
    }
}
