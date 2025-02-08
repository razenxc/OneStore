using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.DTOs.Category;
using OneStore.Helpers;
using OneStore.Interfaces;
using OneStore.Models;

namespace OneStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CategoryRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllAsync(QueryObject query)
        {
            IQueryable<Category> categories = _dbContext.Categories.Include(c => c.SubCategories).Where(x => !x.ParentCategoryId.HasValue);

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                categories = categories.Where(x => x.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    categories = query.IsDecsending ? categories.OrderByDescending(x => x.Name) : categories.OrderBy(x => x.Name);
                }
            }

            return await categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id, QueryObject query)
        {
            Category? category = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                category.Products = category.Products
                    .Skip((query.Page - 1) * query.PageSize)
                    .Take(query.PageSize)
                    .ToList();
            }

            return category;
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if (category.ParentCategoryId == 0)
            {
                category.ParentCategoryId = null;
                category.ParentCategory = null;
            }
            else if (category.ParentCategoryId.HasValue)
            {
                var parentCategory = await _dbContext.Categories
                    .FirstOrDefaultAsync(x => x.Id == category.ParentCategoryId);

                if (parentCategory == null)
                {
                    throw new Exception("Parent category does not exist.");
                }

                category.ParentCategory = parentCategory;
            }

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(int id, Category category)
        {
            Category model = await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                return null;
            }

            if (model.ParentCategoryId == 0)
            {
                model.ParentCategoryId = null;
                model.ParentCategory = null;
            }
            else if (model.ParentCategoryId.HasValue)
            {
                Category newParent = await _dbContext.Categories.FirstOrDefaultAsync(x => x.ParentCategoryId == model.ParentCategoryId);
                if (newParent == null)
                {
                    return null;
                }
                model.ParentCategory = newParent;
            }

            model.Name = category.Name;
            model.ParentCategoryId = model.ParentCategoryId;

            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            Category category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}