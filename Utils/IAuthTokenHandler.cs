using eShop_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Utils
{
    public interface IAuthTokenHandler
    {
        string CreateToken(User user);
        bool CheckValidToken(string token);
    }
}
