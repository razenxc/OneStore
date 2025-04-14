using OneStore.Model;

namespace OneStore.Intefaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
