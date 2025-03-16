using Jobpost.API.Model;
using JobPost.API.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JobPost.API.Database
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserService> _logger;
        public UserService( UserManager<User> userManager, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task <IEnumerable<User>> GetUsersAsync()
        {
            _logger.LogInformation("Get all users");
            return await _userManager.Users.ToListAsync();
        }
        

    }
}
