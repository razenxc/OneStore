using OneStore.DTOs.Product;
using OneStore.Model;

namespace OneStore.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static Product FromDto(this ProductDto product)
        {
            return new Product
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static ProductGetDto ToGetDto(this Product product)
        {
            return new ProductGetDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
            };
        }

        public static Product FromDto(this ProductGetDto product)
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
