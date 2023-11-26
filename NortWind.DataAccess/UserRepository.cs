
using Dapper;
using NorthWind.Models;
using NortWind.Repositories;
using System.Data.SqlClient;

namespace NortWind.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public User ValidateUser(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email);
            parameters.Add("@password", password);

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QueryFirstOrDefault<User>("dbo.ValidateUser", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
