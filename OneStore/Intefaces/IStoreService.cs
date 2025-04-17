using OneStore.Model;
using OneStore.Model.Queries;

namespace OneStore.Intefaces
{
    public interface IStoreService
    {
        // ===========
        // Categories
        Task<List<Category>> GetCategoriesAsync(CategoryQueryParams queryParams);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);

        // ===========
        // Products
        Task<List<Product>> GetProductsAsync(ProductQueryParams queryParams);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteProductAsync(int id);

    }
}
