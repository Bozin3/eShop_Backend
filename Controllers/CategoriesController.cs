using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop_Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await categoryRepository.GetAllCategories());
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var category = await categoryRepository.GetCategoryById(id);

            return category == null ? NotFound() : (ActionResult)Ok(category);
        }
    }
}