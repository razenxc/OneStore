using OneStore.DTOs.Category;
using OneStore.Models;

namespace OneStore.Mappers
{
    public static class CategoryMapper
    {
        // Category DTO
        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static Category FromDto(this CategoryDTO categoryDTO)
        {
            return new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
            };
        }

        // Update DTO
        public static CategoryUpdateDTO ToUpdateDTO(this Category category)
        {
            return new CategoryUpdateDTO
            {
                Name = category.Name,
            };
        }

        public static Category FromUpdateDTO(this CategoryUpdateDTO category)
        {
            return new Category
            {
                Name = category.Name,
            };
        }

        // Create DTO
        public static CategoryCreateDTO ToCreateDTO(this Category category)
        {
            return new CategoryCreateDTO
            {
                Name = category.Name,
            };
        }

        public static Category FromCreateDTO(this CategoryCreateDTO category)
        {
            return new Category
            {
                Name = category.Name,
            };
        }
    }
}
