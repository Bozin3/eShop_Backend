using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop_Backend.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly eShopContext context;

        public ProductsRepository(eShopContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await context.Products.FindAsync(productId);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await context.Products.Where(p => p.CatId == categoryId).ToListAsync();
        }
    }
}
