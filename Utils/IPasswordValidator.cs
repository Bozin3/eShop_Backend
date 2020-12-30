using eShop_Backend.Core.Entities;

namespace eShop_Backend.Utils
{
    public interface IPasswordHandler
    {
        bool CheckValidPassword(string providedPass, User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
