using System;
using System.Threading.Tasks;
using eShop_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                var product = await productsRepository.GetProduct(id);
                if (product == null) {
                    return NotFound($"Product with ID {id} doesn't exists!");
                }
                return Ok(product);

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery]int? categoryId, [FromQuery] int page, [FromQuery] int limit = 10)
        {
            try
            {
                initPaginationFilters(page, limit, out int startValue);

                var products = await productsRepository.GetProducts(categoryId, startValue, limit);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private void initPaginationFilters(int page, int limit, out int startValue)
        {
            if (page > 0)
            {
                startValue = ((int)page * limit) - limit; 
            }
            else
            {
                startValue = 0;
            }
        }

    }
}