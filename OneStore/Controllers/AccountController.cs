﻿using Microsoft.AspNetCore.Mvc;
using OneStore.DTOs.User;
using OneStore.Intefaces;

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

            string token = await _accountService.LoginAsync(user);
            if (token == null)
            {
                return BadRequest("Wrong username/password");
            }
            return Ok(token);
        }
    }
}
