namespace OneStore.Model.Queries
{
    public class ProductQueryParams
    {
        public int CategoryId { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; } = 10;
    }
}
