using Microsoft.AspNetCore.Mvc;
using OneStore.Model;
using OneStore.Services;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/store")]
    public class StoreController : ControllerBase
    {
        // ==========================================================================
        // Issues: Object cycling (possible solution: Create a DTO without List<>)
        //              - Targets: CreateProduct
        // ==========================================================================

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
        [Route("createCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto category)
        {
            Category model = await _storeService.CreateCategoryAsync(category);
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
            return Ok(model);
        }

        [HttpPost]
        [Route("updateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryDto category)
        {
            Category model = await _storeService.UpdateCategoryAsync(id, category);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("deleteCategory/{id}")]
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
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto product)
        {
            Product model = await _storeService.CreateProductAsync(product);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
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
            return Ok(model);
        }

        [HttpPost]
        [Route("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductDto product)
        {
            Product model = await _storeService.UpdateProductAsync(id, product);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("deleteProduct/{id}")]
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
