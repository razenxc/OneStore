using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
