using OneStore.DTOs.User;

namespace OneStore.Intefaces
{
    public interface IAdminService
    {
        Task<List<UserDto>> GetAllUsersAsync();
        Task<UserDto> ChangeUserRoleAsync(UserDto userId);
    }
}
