using OneStore.DTOs.User;
using OneStore.Model;

namespace OneStore.Intefaces
{
    public interface IAccountService
    {
        Task<UserResponseDto> RegisterAsync(UserRequestDto user);
        Task<Tokens> LoginAsync(UserRequestDto user);
        Task<Tokens> RefreshTokenAsync(string token);
    }
}
