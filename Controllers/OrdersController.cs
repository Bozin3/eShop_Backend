using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Backend.Models;
using eShop_Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Controllers
{
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
            try
            {
                var orders = await ordersRepository.GetOrders();
                return Ok(orders);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            try
            {
                var order = await ordersRepository.GetOrder(id);
                if (order == null) 
                {
                    return NotFound();
                }
                return Ok(order);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult> PostOrder(Order order)
        {
            try
            {
                await ordersRepository.AddOrder(order);
                return CreatedAtAction("GetOrder", new { id = order.Id }, order);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteOrder(int id)
        {
            try
            {
                var order = await ordersRepository.GetOrder(id);
                if(order == null)
                {
                    return NotFound();
                }

                await ordersRepository.DeleteOrder(order);
                return Ok(order);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}