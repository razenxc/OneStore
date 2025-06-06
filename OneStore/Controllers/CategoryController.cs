﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneStore.Constants;
using OneStore.DTOs.Category;
using OneStore.Intefaces;
using OneStore.Mappers;
using OneStore.Model;
using OneStore.Model.Queries;

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
        public async Task<IActionResult> GetAll([FromQuery] CategoryQueryParams queryParams)
        {
            List<Category> categories = await _storeService.GetCategoriesAsync(queryParams);
            return Ok(categories.Select(x => x.ToDTO()).ToList());
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category model = await _storeService.CreateCategoryAsync(category.FromRequestDTO());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDTO());
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Category model = await _storeService.GetCategoryByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDTO());
        }

        [HttpPost]
        [Route("update/{id:int}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryUpdateDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category model = await _storeService.UpdateCategoryAsync(id, category.FromUpdateDTO());
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model.ToDTO());
        }

        [HttpPost]
        [Route("delete/{id:int}")]
        [Authorize(Roles = UserRoles.Admin)]
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
