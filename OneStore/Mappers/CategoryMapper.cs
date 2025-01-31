using Microsoft.EntityFrameworkCore;
using OneStore.DTOs.Category;
using OneStore.Models;

namespace OneStore.Mappers
{
    public static class CategoryMapper
    {
        // =========
        // Category
        // To
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                SubCategories = category.SubCategories.Select(x => x.ToDTO()).ToList(),
            };
        }

        // From
        public static Category ToCategory(this CategoryDTO category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                SubCategories = category.SubCategories.Select(x => x.ToCategory()).ToList()
            };
        }
        // ================
        // Create Category
        // To
        public static CategoryCreateDTO ToCreateDTO(this Category category)
        {
            return new CategoryCreateDTO
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            };
        }

        // From
        public static Category ToCategory(this CategoryCreateDTO category)
        {
            return new Category
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            };
        }

        // Update Category
        // To
        public static CategoryUpdateDTO ToUpdateDTO(this Category category)
        {
            return new CategoryUpdateDTO
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            };
        }

        // From
        public static Category ToCategory(this CategoryUpdateDTO category)
        {
            return new Category
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            };
        }
    }
}
