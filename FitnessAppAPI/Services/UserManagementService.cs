using FitnessAppAPI.Data;
using FitnessAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessAppAPI.Services
{
    public class UserManagementService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManagementService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<User>> GetListUser()
        {
            var userList = await _context.Users.ToListAsync();
            if (userList == null || !userList.Any())
            {
                throw new InvalidOperationException("No users found in the database");
            }
            return userList;
        }
    }
}