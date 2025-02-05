using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneStore.DTOs.Product
{
    public class ProductUpdateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be 0 >")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be 0 >")]
        public decimal? DiscountPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
