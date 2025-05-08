using FitnessAppAPI.Data;
using FitnessAppAPI.Models;
using FitnessAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;
        private readonly UserManagementService _userManagementService;

        public UserManagementController(TokenService tokenService, UserManagementService userManagementService, AppDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
            _userManagementService = userManagementService;
        }

        //[Authorize]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userList = await _userManagementService.GetListUser();
                return Ok(new
                {
                    message = "User list retrieved successfully",
                    users = userList,
                    timestamp = DateTime.UtcNow
                });
            } catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            } catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred", details = ex.Message });
            }
        }
    }
}