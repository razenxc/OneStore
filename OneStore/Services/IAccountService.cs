using OneStore.Model;

namespace OneStore.Services
{
    public interface IAccountService
    {
        Task<User> RegisterAsync(UserAuth user);
        Task<string> LoginAsync(UserAuth user);
    }
}
