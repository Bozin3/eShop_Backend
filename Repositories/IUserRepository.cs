using eShop_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task UpdateUser(User user);
        Task AddUser(User user);
        Task DeleteUser(User user);
        bool UserExists(int id);
    }
}
