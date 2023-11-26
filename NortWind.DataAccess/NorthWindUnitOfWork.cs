using NorthWind.UnitOfWork;
using NortWind.Repositories;

namespace NortWind.DataAccess
{
    public class NorthWindUnitOfWork : IUnitOfWork
    {
        public NorthWindUnitOfWork(string connectionString) 
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
            Order = new OrderRerpository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }

        public IUserRepository User { get; private set; }

        public ISupplierRepository Supplier { get; private set; }

        public IOrderRepository Order { get; private set; }
    }
}
