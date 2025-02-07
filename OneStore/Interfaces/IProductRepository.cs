using OneStore.Helpers;
using OneStore.Models;

namespace OneStore.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(QueryObject query);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product product);
        Task<Product?> DeleteAsync(int id);
    }
}
