using OneStore.DTOs.User;

namespace OneStore.Intefaces
{
    public interface IAccountService
    {
        Task<UserResponseDto> RegisterAsync(UserRequestDto user);
        Task<string> LoginAsync(UserRequestDto user);
    }
}
