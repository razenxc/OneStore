namespace OneStore.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public List<CategoryDTO> SubCategories { get; set; } = new();
    }
}
