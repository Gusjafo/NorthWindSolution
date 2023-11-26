using NorthWind.Models;

namespace NortWind.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
