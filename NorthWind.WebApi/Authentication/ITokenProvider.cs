using Microsoft.IdentityModel.Tokens;
using NorthWind.Models;
using System;

namespace NorthWind.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
