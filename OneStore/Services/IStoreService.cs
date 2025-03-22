using OneStore.Model;

namespace OneStore.Services
{
    public interface IStoreService
    {
        // ===========
        // Categories
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(CategoryDto category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> UpdateCategoryAsync(int id, CategoryDto category);
        Task<bool> DeleteCategoryAsync(int id);

        // ===========
        // Products
        Task<List<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(ProductDto product);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, ProductDto product);
        Task<bool> DeleteProductAsync(int id);

    }
}
