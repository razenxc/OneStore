using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.DTOs.User;
using OneStore.Intefaces;
using OneStore.Model;

namespace OneStore.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> ChangeUserRoleAsync(UserResponseDto user)
        {
            User model = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (model == null)
            {
                return null;
            }

            model.Role = user.Role;

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            List<UserResponseDto> users = await _context.Users
                .Select(u => new UserResponseDto { Id = u.Id, Username = u.Username, Role = u.Role })
                .ToListAsync();

            return users;
        }
    }
}
