using OneStore.Model;

namespace OneStore.Intefaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        Task<string> GenerateRefreshTokenAsync(int userId);
        Task<Tokens> RefreshTokenAsync(string token);
    }
}
