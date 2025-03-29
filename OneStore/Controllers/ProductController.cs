using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.Product;
using OneStore.Mappers;
using OneStore.Model;
using OneStore.Services;

namespace OneStore.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public ProductController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _storeService.GetProductsAsync());
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            Product model = await _storeService.CreateProductAsync(product.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Product model = await _storeService.GetProductByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("update/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductDto product)
        {
            Product model = await _storeService.UpdateProductAsync(id, product.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("delete/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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
