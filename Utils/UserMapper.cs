using eShop_Backend.Core.Entities;
using eShop_Backend.Models.Requests;

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
