using OneStore.Model;

namespace OneStore.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
