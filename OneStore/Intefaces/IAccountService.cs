using OneStore.DTOs.User;

namespace OneStore.Intefaces
{
    public interface IAccountService
    {
        Task<UserDto> RegisterAsync(UserAuth user);
        Task<string> LoginAsync(UserAuth user);
    }
}
