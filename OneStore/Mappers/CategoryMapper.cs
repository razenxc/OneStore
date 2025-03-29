
using OneStore.DTOs.Category;
using OneStore.Model;

namespace OneStore.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto(this Category category)
        {
            return new CategoryDto
            {
                Name = category.Name
            };
        }

        public static Category FromDto(this CategoryDto category)
        {
            return new Category
            {
                Name = category.Name
            };
        }

        public static CategoryIdDto ToIdDto(this Category category)
        {
            return new CategoryIdDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static Category FromDto(this CategoryIdDto category)
        {
            return new Category
            {

                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
