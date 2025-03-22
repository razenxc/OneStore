using OneStore.Model;

namespace OneStore.Services
{
    public interface IAccountService
    {
        Task<UserDto> RegisterAsync(UserAuth user);
        Task<string> LoginAsync(UserAuth user);
    }
}
