using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneStore.Data;
using OneStore.Intefaces;
using OneStore.Model;

namespace OneStore.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        public JwtService(IConfiguration config, ApplicationDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<string> GenerateRefreshTokenAsync(int userId)
        {
            JwtRefreshToken token = new JwtRefreshToken()
            {
                UserId = userId,
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpireAt = DateTime.UtcNow.AddDays(Convert.ToInt32(_config["Jwt:RefreshTokenLifeTime"])),
                IsRevoked = false,
            };

            await _context.JwtRefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();

            return token.RefreshToken;
        }

        public string GenerateToken(User user)
        {
            if (user == null)
            {
                return null;
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                _config["Jwt:Issuer"], 
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:AccessTokenLifeTime"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Tokens> RefreshTokenAsync(string token)
        {
            JwtRefreshToken oldRefreshToken = await _context.JwtRefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == token);
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == oldRefreshToken.UserId);
            if (oldRefreshToken == null || oldRefreshToken.IsRevoked || oldRefreshToken.ExpireAt < DateTime.UtcNow
                || user == null)
            {
                return null;
            }

            string newAccessToken = GenerateToken(user);
            string newRefreshToken = await GenerateRefreshTokenAsync(user.Id);

            oldRefreshToken.IsRevoked = true;
            await _context.SaveChangesAsync();

            return new Tokens
            { 
                AccessToken = newAccessToken, 
                RefreshToken = newRefreshToken 
            };
        }
    }
}
