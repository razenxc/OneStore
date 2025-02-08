using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.Account;
using OneStore.Interfaces;
using OneStore.Models;
using OneStore.Services;

namespace OneStore.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                User user = new User
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                };

                IdentityResult createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

                if (!createdUser.Succeeded)
                {
                    return BadRequest(createdUser.Errors);
                }

                IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (roleResult.Succeeded)
                {
                    return Ok(new NewUserDTO
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    });
                }
                else
                {
                    return BadRequest(roleResult.Errors);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}