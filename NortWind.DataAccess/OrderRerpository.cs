using Dapper;
using NorthWind.Models;
using NortWind.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NortWind.DataAccess
{
    public class OrderRerpository : Repository<Order>, IOrderRepository
    {
        public OrderRerpository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<OrderList> GetPaginatedOrder(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var conn = new SqlConnection(_connectionString))
            {
                var reader =  conn.QueryMultiple(
                        "dbo.get_paginated_orders",
                        parameters,
                        commandType: System.Data.CommandType.StoredProcedure
                        );
                var orderList = reader.Read<OrderList>().ToList();
                var orderItemList = reader.Read<OrderItemList>().ToList();
                foreach (var item in orderList)
                {
                    item.SetDetails(orderItemList);
                }

                return orderList;
            }
        }

        public new OrderList GetById(int orderId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@orderId", orderId);

            using (var conn = new SqlConnection(_connectionString))
            {
                var reader = conn.QueryMultiple(
                    "dbo.get_orders_by_id",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                var order = reader.ReadSingle<OrderList>();
                var orderItem = reader.Read<OrderItemList>().ToList();

                order.SetDetails(orderItem);

                return order;
            }
        }

        public bool Delete(OrderList entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(OrderList entity)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(OrderList entity)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<Order> IRepository<Order>.GetList()
        {
            throw new System.NotImplementedException();
        }

    }
}
