using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.Constants;
using OneStore.DTOs.Product;
using OneStore.Intefaces;
using OneStore.Mappers;
using OneStore.Model;
using OneStore.Model.Queries;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/store/product")]
    public class ProductController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public ProductController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryParams queryParams)
        {
            List<Product> products = await _storeService.GetProductsAsync(queryParams);
            return Ok(products.Select(x => x.ToGetDto()).ToList());
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Create([FromBody] ProductRequestDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
            return Ok(model.ToGetDto());
        }

        [HttpPost]
        [Route("update/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductRequestDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product model = await _storeService.UpdateProductAsync(id, product.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("delete/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
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
