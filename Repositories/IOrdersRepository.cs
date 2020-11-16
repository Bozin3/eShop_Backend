using eShop_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Repositories
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(int id);
        Task AddOrder(Order order);
        Task DeleteOrder(Order order);
    }
}
