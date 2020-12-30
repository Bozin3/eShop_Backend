using eShop_Backend.Core;
using eShop_Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly eShopContext context;

        public OrdersRepository(eShopContext context)
        {
            this.context = context;
        }
        public async Task AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await context.Orders.Where(o => o.Id == id)
                       .Include(o => o.OrdersDetails).ThenInclude(o => o.Product)
                       .FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await context.Orders.ToListAsync();
        }
    }
}
