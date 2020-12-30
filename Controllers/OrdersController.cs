using System.Threading.Tasks;
using eShop_Backend.Core.Entities;
using eShop_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            return Ok(await ordersRepository.GetOrders());
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await ordersRepository.GetOrder(id);

            return order == null ? NotFound() : (ActionResult)Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult> PostOrder(Order order)
        {
            await ordersRepository.AddOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteOrder(int id)
        {
            var order = await ordersRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }

            await ordersRepository.DeleteOrder(order);
            return Ok(order);
        }

    }
}