using NorthWind.Models;
using System.Collections.Generic;

namespace NortWind.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<OrderList> GetPaginatedOrder(int page, int rows);
        new OrderList GetById(int id);
    }
}
