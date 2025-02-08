using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OneStore.Interfaces;
using OneStore.Models;

namespace OneStore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            };

            SigningCredentials creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"],
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
