using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly eShopContext context;

        public UserRepository(eShopContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public Task<List<User>> GetUsers()
        {
            return context.Users.ToListAsync();
        }

        public async Task<int> AddUser(User user)
        {
            context.Users.Add(user);
            return await context.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public bool UserExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
