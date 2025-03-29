using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.User;
using OneStore.Services;

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
        public async Task<IActionResult> Register([FromBody] UserAuth user)
        {
            UserDto model = await _accountService.RegisterAsync(user);
            if (model == null)
            {
                return BadRequest();
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserAuth user)
        {
            string token = await _accountService.LoginAsync(user);
            if (token == null)
            {
                return BadRequest("Wrong username/password");
            }
            return Ok(token);
        }
    }
}
