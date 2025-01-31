using System.Formats.Asn1;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using OneStore.Data;
using OneStore.DTOs.Category;
using OneStore.Interfaces;
using OneStore.Mappers;
using OneStore.Models;

namespace OneStore.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ICategoryRepository _categoryInterface;
        public CategoryController(ApplicationDBContext dBContext, ICategoryRepository categoryInterface)
        {
            _dbContext = dBContext;
            _categoryInterface = categoryInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _categoryInterface.GetAllAsync();
            IEnumerable<CategoryDTO> response = categories.Select(x => x.ToDTO()).Where(x => !x.ParentCategoryId.HasValue);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Category category = await _categoryInterface.GetByIdAsync(id);
            CategoryDTO response = category.ToDTO();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryUpdateDTO categoryCreateDTO)
        {
            Category category = categoryCreateDTO.ToCategory();
            await _categoryInterface.CreateAsync(category);
            if(category == null)
            {
                return NotFound();
            }
            CategoryDTO response = category.ToDTO();
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            Category category = await _categoryInterface.UpdateAsync(id, categoryUpdateDTO);
            if (category == null)
            {
                return NotFound();
            }
            CategoryDTO response = category.ToDTO();
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Category category = await _categoryInterface.DeleteAsync(id);
            if (category == null)
            {
                return null;
            }
            return NoContent();
        }
    }
}
