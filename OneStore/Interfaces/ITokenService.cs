using OneStore.Models;

namespace OneStore.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
