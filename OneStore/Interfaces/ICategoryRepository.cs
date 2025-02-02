﻿using OneStore.DTOs.Category;
using OneStore.Models;

namespace OneStore.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int id, Category category);
        Task<Category?> DeleteAsync(int id);
    }
}
