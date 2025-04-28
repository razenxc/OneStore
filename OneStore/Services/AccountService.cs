using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.DTOs.User;
using OneStore.Intefaces;
using OneStore.Model;

namespace OneStore.Services
{
    public class AccountService : IAccountService
    {
        private readonly IJwtService _jwtService;
        private readonly ApplicationDbContext _context;
        public AccountService(IJwtService jwtService, ApplicationDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<Tokens> LoginAsync(UserRequestDto user)
        {
            User model = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (model == null)
            {
                return null;
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(model, model.PasswordHash, user.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }

            string token = _jwtService.GenerateToken(model);
            string refreshToken = await _jwtService.GenerateRefreshTokenAsync(model.Id);

            return new Tokens
            {
                AccessToken = token,
                RefreshToken = refreshToken,
            };
        }

        public async Task<UserResponseDto> RegisterAsync(UserRequestDto user)
        {
            if (await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username) != null)
            {
                return null;
            }

            User model = new();

            model.Username = user.Username;
            model.PasswordHash = new PasswordHasher<User>().HashPassword(model, user.Password);
            model.Role = "USER";

            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                Id = model.Id,
                Username = model.Username,
                Role = model.Role
            };
        }

        public async Task<Tokens> RefreshTokenAsync(string token)
        {
            Tokens tokens = await _jwtService.RefreshTokenAsync(token);
            if (tokens == null)
            {
                return null;
            }

            return tokens;
        }
    }
}
