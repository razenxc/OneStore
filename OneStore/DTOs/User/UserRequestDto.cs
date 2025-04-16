using System.ComponentModel.DataAnnotations;

namespace OneStore.DTOs.User
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "Name is required property")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required property")]
        public string Password { get; set; }
    }
}
