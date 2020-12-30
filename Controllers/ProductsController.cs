using System;
using System.Threading.Tasks;
using eShop_Backend.Models.Requests;
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
            var product = await productsRepository.GetProduct(id);
           
            if (product == null)
            {
                return NotFound($"Product with ID {id} doesn't exists!");
            }
           
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] GetProductsQueryParams getProductsQueryParams)
        {
            initPaginationFilters(getProductsQueryParams, out int startValue);

            var products = await productsRepository.GetProducts(getProductsQueryParams.categoryId, startValue, getProductsQueryParams.limit);

            return Ok(products);
        }

        private void initPaginationFilters(GetProductsQueryParams getProductsQueryParams, out int startValue)
        {
            if (getProductsQueryParams.page > 0)
            {
                startValue = ((int)getProductsQueryParams.page * getProductsQueryParams.limit) - getProductsQueryParams.limit; 
            }
            else
            {
                startValue = 0;
            }
        }

    }
}