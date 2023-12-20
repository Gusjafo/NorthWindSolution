using Dapper;
using NorthWind.Models;
using NortWind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace NortWind.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<SupplierList> SupplierPagedList(int page, int rows, string key)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@searchTerm", key);

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<SupplierList>("dbo.SupplierPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }
    }
}
