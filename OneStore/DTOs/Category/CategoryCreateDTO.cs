namespace OneStore.DTOs.Category
{
    public class CategoryCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
    }
}
