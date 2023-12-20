using NorthWind.BusinessLogic.Interfaces;
using NorthWind.Models;
using NorthWind.UnitOfWork;
using System.Collections.Generic;

namespace NorthWind.BusinessLogic.Implementations
{
    public class CustomerLogic : ICustomerLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerList> CustomerPagedList(int page, int rows) => _unitOfWork.Customer.CustomerPagedList(page, rows);

        bool ICustomerLogic.Delete(Customer entity) => _unitOfWork.Customer.Delete(entity);

        Customer ICustomerLogic.GetById(int id) => _unitOfWork.Customer.GetById(id);

        int ICustomerLogic.Insert(Customer entity) => _unitOfWork.Customer.Insert(entity);



        bool ICustomerLogic.Update(Customer entity) => _unitOfWork.Customer.Update(entity);
    }
}
