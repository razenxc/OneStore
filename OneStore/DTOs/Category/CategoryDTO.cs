

using System.ComponentModel.DataAnnotations;
using OneStore.Models;

namespace OneStore.DTOs.Category
{
    public class CategoryDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? ParentCategoryId { get; set; }
        public List<CategoryDTO> SubCategories { get; set; } = new List<CategoryDTO>();
    }
}
