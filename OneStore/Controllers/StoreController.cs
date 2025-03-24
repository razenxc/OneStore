using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.Mappers;
using OneStore.Model;
using OneStore.Services;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        // ===========
        // Categories
        [HttpGet]
        [Route("getCategories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _storeService.GetCategoriesAsync());
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [Route("createCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto category)
        {
            Category model = await _storeService.CreateCategoryAsync(category.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("getCategoryById/{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            Category model = await _storeService.GetCategoryByIdAsync(id);
            if (model == null)
            { 
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("updateCategory/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryDto category)
        {
            Category model = await _storeService.UpdateCategoryAsync(id, category.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("deleteCategory/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            bool deleted = await _storeService.DeleteCategoryAsync(id);
            if (!deleted)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // ===========
        // Products
        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _storeService.GetProductsAsync());
        }

        [HttpPost]
        [Route("createProduct")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            Product model = await _storeService.CreateProductAsync(product.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpGet]
        [Route("getProductById/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            Product model = await _storeService.GetProductByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("updateProduct/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductDto product)
        {
            Product model = await _storeService.UpdateProductAsync(id, product.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("deleteProduct/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            bool deleted = await _storeService.DeleteProductAsync(id);
            if (!deleted)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
