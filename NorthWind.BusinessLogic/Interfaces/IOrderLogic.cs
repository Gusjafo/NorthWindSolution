using NorthWind.Models;
using System.Collections.Generic;

namespace NorthWind.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        OrderList GetById(int id);
        IEnumerable<OrderList> OrderPagedList(int page, int rows);
        public string GetOrderNumber(int orderId);
    }
}
