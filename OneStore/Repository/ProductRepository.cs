using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.Interfaces;
using OneStore.Models;

namespace OneStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Product?> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            product.Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
            if (product.Category == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsync(int id)
        {
            Product model = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return null;
            }
            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            Product model = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return null;
            }
            return model;
        }

        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            Product model = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return null;
            }

            model.Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == product.CategoryId);
            if (model.Category == null)
            {
                return null;
            }

            model.Name = product.Name;
            model.Description = product.Description;
            model.Price = product.Price;
            model.DiscountPrice = product.DiscountPrice;
            model.Stock = product.Stock;
            model.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
