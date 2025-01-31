using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.DTOs.Category;
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

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories
                .Include(c => c.SubCategories)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> CreateAsync(Category category)
        {
            if(category.ParentCategoryId != 0)
            {
                category.ParentCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.ParentCategoryId == x.Id);
            }
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == id);

            if (category == null)
            {
                return null;
            }

            category.Name = categoryUpdateDTO.Name;

            if (category.ParentCategoryId != categoryUpdateDTO.ParentCategoryId)
            {
                if (categoryUpdateDTO.ParentCategoryId.HasValue)
                {
                    Category newParent = await _dbContext.Categories.FindAsync(categoryUpdateDTO.ParentCategoryId);
                    if (newParent == null)
                    {
                        return null;
                    }
                    category.ParentCategory = newParent;
                }
                else
                {
                    category.ParentCategory = null;
                }
                category.ParentCategoryId = categoryUpdateDTO.ParentCategoryId;
            }

            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

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