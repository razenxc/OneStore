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
            IEnumerable<CategoryDTO> catigoriesDTO = categories.Select(x => x.ToDTO());
            return Ok(catigoriesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Category category = await _categoryInterface.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryUpdateDTO categoryCreateDTO)
        {
            Category category = categoryCreateDTO.FromUpdateDTO();
            await _categoryInterface.CreateAsync(category);
            return Ok(category.ToDTO());
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
            return Ok(category.ToDTO());
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
