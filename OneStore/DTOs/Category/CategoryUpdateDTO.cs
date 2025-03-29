namespace OneStore.DTOs.Category
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; } = new();
    }
}
