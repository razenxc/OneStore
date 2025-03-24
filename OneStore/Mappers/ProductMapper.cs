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
    }
}
