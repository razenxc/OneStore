using OneStore.DTOs.Product;
using OneStore.Model;

namespace OneStore.Mappers
{
    public static class ProductMapper
    {
        public static ProductRequestDto ToDto(this Product product)
        {
            return new ProductRequestDto
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static Product FromDto(this ProductRequestDto product)
        {
            return new Product
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static ProductResponseDto ToGetDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
            };
        }

        public static Product FromDto(this ProductResponseDto product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
            };
        }
    }
}
