using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs.Product
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Name is required property")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required property")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "CategoryId is required property")]
        public int CategoryId { get; set; }
    }
}
