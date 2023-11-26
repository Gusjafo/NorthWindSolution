using Dapper;
using NorthWind.Models;
using NortWind.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NortWind.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
            
        }

        public IEnumerable<CustomerList> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using(var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<CustomerList>("dbo.CustomerPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
