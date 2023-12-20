using NorthWind.BusinessLogic.Interfaces;
using NorthWind.Models;
using NorthWind.UnitOfWork;
using System.Collections.Generic;

namespace NorthWind.BusinessLogic.Implementations
{
    public class SupplierLogic : ISupplierLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Delete(Supplier entity) => _unitOfWork.Supplier.Delete(entity);

        public Supplier GetById(int id) => _unitOfWork.Supplier.GetById(id);

        public int Insert(Supplier entity) => _unitOfWork.Supplier.Insert(entity);

        public IEnumerable<SupplierList> SupplierPagedList(int page, int rows, string key) => _unitOfWork.Supplier.SupplierPagedList(page, rows, key);

        public bool Update(Supplier entity) => (_unitOfWork.Supplier.Update(entity));
    }
}
