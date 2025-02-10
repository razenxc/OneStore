using System.Formats.Asn1;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.Data;
using OneStore.DTOs.Category;
using OneStore.Helpers;
using OneStore.Interfaces;
using OneStore.Mappers;
using OneStore.Models;

namespace OneStore.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryInterface;
        public CategoryController(ICategoryRepository categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Category> categories = await _categoryInterface.GetAllAsync(query);
            IEnumerable<CategoryDTO> response = categories.Select(x => x.ToDTO());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await _categoryInterface.GetByIdAsync(id, query);
            CategoryDTO response = category.ToDTO();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = await _categoryInterface.UpdateAsync(id, categoryUpdateDTO.ToCategory());
            if (category == null)
            {
                return NotFound();
            }
            CategoryDTO response = category.ToDTO();
            return Ok(response);
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

            Category category = await _categoryInterface.DeleteAsync(id);
            if (category == null)
            {
                return null;
            }
            return NoContent();
        }
    }
}
