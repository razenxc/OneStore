using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.Product;
using OneStore.Helpers;
using OneStore.Interfaces;
using OneStore.Mappers;
using OneStore.Models;

namespace OneStore.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;
        public ProductController(IProductRepository productRepository)
        {
            _product = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Product> products = await _product.GetAllAsync(query);
            return Ok(products.Select(x => x.ToDTO()));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product model = await _product.GetByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToDTO());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product model = await _product.CreateAsync(product.FromDTO());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDTO());
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product model = await _product.UpdateAsync(id, product.FromDTO());
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model.ToDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product model = await _product.DeleteAsync(id);
            if(model == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
