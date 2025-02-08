using OneStore.Models;

namespace OneStore.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
