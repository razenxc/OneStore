using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.Category;
using OneStore.Mappers;
using OneStore.Model;
using OneStore.Services;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/store/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public CategoryController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _storeService.GetCategoriesAsync();
            return Ok(categories.Select(x => x.ToIdDto()).ToList());
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CategoryDto category)
        {
            Category model = await _storeService.CreateCategoryAsync(category.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToIdDto());
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Category model = await _storeService.GetCategoryByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToIdDto());
        }

        [HttpPost]
        [Route("update/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDto category)
        {
            Category model = await _storeService.UpdateCategoryAsync(id, category.FromDto());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToIdDto());
        }

        [HttpPost]
        [Route("delete/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            bool deleted = await _storeService.DeleteCategoryAsync(id);
            if (!deleted)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
