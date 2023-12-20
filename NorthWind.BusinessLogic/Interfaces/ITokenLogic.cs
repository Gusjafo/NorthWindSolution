using NorthWind.Models;

namespace NorthWind.BusinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
