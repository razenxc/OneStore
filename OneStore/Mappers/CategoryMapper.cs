
using OneStore.DTOs.Category;
using OneStore.Model;

namespace OneStore.Mappers
{
    public static class CategoryMapper
    {
        // ============
        // Request DTO
        public static CategoryRequestDTO ToRequestDTO(this Category category)
        {
            return new CategoryRequestDTO
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }

        public static Category FromRequestDTO(this CategoryRequestDTO category)
        {
            return new Category
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }

        // ====
        // DTO

        public static CategoryDTO ToDTO(this Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                SubCategories = category.SubCategories.Select(x => x.ToDTO()).ToList()
            };
        }

        public static Category FromDTO(this CategoryDTO category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = category.SubCategories.Select(x => x.FromDTO()).ToList(),
                ParentCategoryId = category.ParentCategoryId,
            };
        }

        // ===========
        // Update DTO
        public static CategoryUpdateDTO ToUpdateDTO(this Category category)
        {
            return new CategoryUpdateDTO
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }

        public static Category FromUpdateDTO(this CategoryUpdateDTO category)
        {
            return new Category
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
            };
        }
    }
}
