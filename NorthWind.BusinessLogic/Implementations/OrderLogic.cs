using NorthWind.BusinessLogic.Interfaces;
using NorthWind.Models;
using NorthWind.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace NorthWind.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<OrderList> OrderPagedList(int page, int rows) => _unitOfWork.Order.GetPaginatedOrder(page, rows);

        OrderList IOrderLogic.GetById(int orderId) => _unitOfWork.Order.GetById(orderId);

        //public string GetOrderNumber(int orderId) => _unitOfWork.Order.GetById(orderId).OrderNumber.ToString();

        public string GetOrderNumber(int orderId)
        {
            var list = _unitOfWork.Order.GetList();
            if (list == null)
            {
                return string.Empty;
            }
            var record = list.First(x => x.Id == orderId);
            return record.OrderNumber.ToString();
        }
    }
}
