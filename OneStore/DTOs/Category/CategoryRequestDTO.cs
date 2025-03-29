namespace OneStore.DTOs.Category
{
    public class CategoryRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; } = new();
    }
}
