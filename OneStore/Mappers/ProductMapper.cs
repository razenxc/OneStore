using OneStore.DTOs.Product;
using OneStore.Models;

namespace OneStore.Mappers
{
    public static class ProductMapper
    {
        // =========
        // Product
        // To
        public static ProductDTO ToDTO(this Product product)
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

        // From
        public static Product ToProduct(this ProductDTO productDTO)
        {
            return new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                DiscountPrice = productDTO.DiscountPrice,
                Stock = productDTO.Stock,
                CategoryId = productDTO.CategoryId,
            };
        }

        // =========
        // Create Product
        // To
        public static ProductCreateDTO ToCreateDTO(this ProductDTO productDTO)
        {
            return new ProductCreateDTO
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                DiscountPrice = productDTO.DiscountPrice,
                Stock = productDTO.Stock,
                CategoryId = productDTO.CategoryId,
            };
        }

        // From
        public static Product FromDTO(this ProductCreateDTO productCreateDTO)
        {
            return new Product
            {
                Name = productCreateDTO.Name,
                Description = productCreateDTO.Description,
                Price = productCreateDTO.Price,
                DiscountPrice = productCreateDTO.DiscountPrice,
                Stock = productCreateDTO.Stock,
                CategoryId = productCreateDTO.CategoryId,
            };
        }

        // =========
        // Update Product
        // To
        public static ProductUpdateDTO ToUpdateDTO(this Product product)
        {
            return new ProductUpdateDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DiscountPrice = product.DiscountPrice,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
        }

        // From
        public static Product FromDTO(this ProductUpdateDTO productUpdateDTO)
        {
            return new Product
            {
                Name = productUpdateDTO.Name,
                Description = productUpdateDTO.Description,
                Price = productUpdateDTO.Price,
                DiscountPrice = productUpdateDTO.DiscountPrice,
                Stock = productUpdateDTO.Stock,
                CategoryId = productUpdateDTO.CategoryId,
            };
        }
    }
}
