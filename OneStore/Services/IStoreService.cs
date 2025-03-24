using OneStore.Model;

namespace OneStore.Services
{
    public interface IStoreService
    {
        // ===========
        // Categories
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);

        // ===========
        // Products
        Task<List<Product>> GetProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);

    }
}
