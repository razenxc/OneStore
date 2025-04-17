using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.Intefaces;
using OneStore.Model;
using OneStore.Model.Queries;

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
        public async Task<List<Category>> GetCategoriesAsync(CategoryQueryParams queryParams)
        {
            List<Category> categories;

            if(queryParams.Page > 0)
            {
                categories = await _context.Categories
                    .Where(x => x.ParentCategoryId == null)
                    .Include(x => x.SubCategories)
                    .Skip((queryParams.Page - 1) * queryParams.PageSize)
                    .Take(queryParams.PageSize)
                    .ToListAsync();
            }
            else
            {
                categories = await _context.Categories.Where(x => x.ParentCategoryId == null).Include(x => x.SubCategories).ToListAsync();
            }

            return categories;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            if (category.ParentCategoryId == 0)
            {
                category.ParentCategoryId = null;
            }

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
            model.ParentCategoryId = category.ParentCategoryId;

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
        public async Task<List<Product>> GetProductsAsync(ProductQueryParams queryParams)
        {
            List<Product> products;

            if (queryParams.CategoryId > 0)
            {
                products = await _context.Products.Where(x => x.CategoryId == queryParams.CategoryId).ToListAsync();
            }
            else
            {
                products = await _context.Products.ToListAsync();
            }

            if (queryParams.Page > 0)
            {
                products = products.Skip((queryParams.Page - 1) * queryParams.PageSize).Take(queryParams.PageSize).ToList();
            }

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
