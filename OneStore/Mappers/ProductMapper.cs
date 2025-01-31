using OneStore.DTOs.Product;
using OneStore.Models;

namespace OneStore.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDto(this Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
        }
    }
}
