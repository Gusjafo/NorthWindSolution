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

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Supplier>("dbo.SupplierPagedList", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

        }
    }
}
