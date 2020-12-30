using eShop_Backend.Core.Entities;

namespace eShop_Backend.Utils
{
    public interface IAuthTokenHandler
    {
        string CreateToken(User user);
        bool CheckValidToken(string token);
    }
}
