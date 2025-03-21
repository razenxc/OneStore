using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OneStore.Data;
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

        public async Task<string> LoginAsync(UserAuth user)
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

            return token;
        }

        public async Task<User> RegisterAsync(UserAuth user)
        {
            User model = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username);
            if (model == null)
            {
                return null;
            }

            model.Username = user.Username;
            model.PasswordHash = new PasswordHasher<User>().HashPassword(model, user.Password);
            model.Role = "USER";

            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
