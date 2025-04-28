using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs;
using OneStore.DTOs.User;
using OneStore.Intefaces;
using OneStore.Model;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserResponseDto model = await _accountService.RegisterAsync(user);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tokens tokens = await _accountService.LoginAsync(user);
            if (tokens == null)
            {
                return BadRequest("Wrong username/password");
            }
            return Ok(tokens);
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Tokens tokens = await _accountService.RefreshTokenAsync(request.RefreshToken);
            if (tokens == null)
            {
                return BadRequest();
            }
            return Ok(tokens);
        }
    }
}
