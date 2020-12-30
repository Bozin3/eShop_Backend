using eShop_Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts(int? categoryId, int startValue, int limit);
        Task<Product> GetProduct(int productId);
    }
}
