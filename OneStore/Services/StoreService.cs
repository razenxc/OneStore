using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.Model;

namespace OneStore.Services
{
    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===========
        // Categories
        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            Category model = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return null;
            }

            model.Name = category.Name;

            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        // ===========
        // Products
        public async Task<List<Product>> GetProductsAsync()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
            if (category == null)
            {
                return null;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            Product model = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return null;
            }

            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
            if (category == null)
            {
                return null;
            }

            model.Name = product.Name;
            model.Description = product.Description;
            model.CategoryId = product.CategoryId;
            model.Category = category;

            await _context.SaveChangesAsync();

            return model;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
