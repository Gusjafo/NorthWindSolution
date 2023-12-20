using NorthWind.BusinessLogic.Interfaces;
using NorthWind.Models;
using NorthWind.UnitOfWork;

namespace NorthWind.BusinessLogic.Implementations
{
    public class TokenLogic : ITokenLogic
    {
        private IUnitOfWork _unitOfWork;
        public TokenLogic( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User ValidateUser(string email, string password)
        {
            return _unitOfWork.User.ValidateUser(email, password);
        }
    }
}
