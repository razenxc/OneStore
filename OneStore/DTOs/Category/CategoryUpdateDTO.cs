using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs.Category
{
    public class CategoryUpdateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? ParentCategoryId { get; set; }
    }
}
