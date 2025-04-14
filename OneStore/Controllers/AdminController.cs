using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneStore.Constants;
using OneStore.Data;
using OneStore.DTOs.User;
using OneStore.Intefaces;

namespace OneStore.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _adminService.GetAllUsersAsync());
        }

        [HttpPost]
        [Route("changeUserRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] UserDto user)
        {
            UserDto model = await _adminService.ChangeUserRoleAsync(user);
            if (model == null)
            {
                return BadRequest("User doesn't exsist");
            }
            return Ok(model);
        }
    }
}
