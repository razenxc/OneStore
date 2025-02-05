using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs.Category
{
    public class CategoryCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
    }
}
