using FitnessAppAPI.Models;
using FitnessAppAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using FitnessAppAPI.Data;
using System.Security.Claims;

namespace FitnessAppAPI.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
        {
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;

        public AuthController(TokenService tokenService, AppDbContext context)
            {
            _tokenService = tokenService;
            _context = context;
            }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
            {
            // Find user by username
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);


            if (user == null)
                {
                return Unauthorized(new { message = "Invalid username or password" });
                }

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                return Unauthorized(new { message = "Invalid Password" });
                }

            // Generate token
            var token = _tokenService.GenerateToken(user);

            return Ok(new
                {
                token,
                user = new
                    {
                    user.Id,
                    user.Username,
                    user.Email
                    // Add other user properties you want to return
                    }
                });
            }

        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult SecureData()
            {
            // Access user claims from the token
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var username = User.FindFirst(ClaimTypes.Name)?.Value;

            return Ok(new
                {
                message = "This is protected data",
                userId,
                username,
                timestamp = DateTime.UtcNow
                });
            }
        }
    }