using OneStore.DTOs.User;

namespace OneStore.Intefaces
{
    public interface IAdminService
    {
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> ChangeUserRoleAsync(UserResponseDto userId);
    }
}
