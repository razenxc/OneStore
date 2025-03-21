using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneStore.Data;
using OneStore.Model;

namespace OneStore.Controllers
{
    // ===================================
    // PLACEHOLDER CONTROLLER FOR TESTS
    // ===================================

    [ApiController]
    [Route("api/adminn")]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users
                .Select(u => new { u.Id, u.Username })
                .ToListAsync();

            return Ok(users);
        }
    }
}
