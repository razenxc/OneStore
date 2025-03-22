using OneStore.Model;

namespace OneStore.Services
{
    public interface IAdminService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> ChangeUserRoleAsync(UserDto userId);
    }
}
