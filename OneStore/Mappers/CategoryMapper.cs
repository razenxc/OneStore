
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
    }
}
