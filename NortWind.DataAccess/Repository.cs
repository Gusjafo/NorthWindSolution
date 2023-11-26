using Dapper.Contrib.Extensions;
using NortWind.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NortWind.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected string _connectionString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Delete(entity);

            }
        }

        public T GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Get<T>(id);

            }
        }

        public IEnumerable<T> GetList()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.GetAll<T>();

            }
        }

        public int Insert(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return (int)conn.Insert(entity);

            }
        }

        public bool Update(T entity)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Update(entity);

            }
        }
    }
}
