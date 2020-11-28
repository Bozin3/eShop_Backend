using eShop_Backend.Models;
using eShop_Backend.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Utils
{
    public static class UserMapper
    {
        static public User CreateUserFromRequest(RegisterRequest registerRequest)
        {
            return new User
            {
                Fname = registerRequest.Fname,
                Lname = registerRequest.Lname,
                Email = registerRequest.Email,
                Age = registerRequest.Age
            };
        }
    }
}
