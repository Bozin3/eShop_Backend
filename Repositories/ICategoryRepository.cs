using eShop_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
    }
}
