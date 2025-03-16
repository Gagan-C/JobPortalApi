using JobPost.API.Database;
using Jobpost.API.Model;
using JobPost.API.Dtos;
using Microsoft.AspNetCore.Identity;

namespace JobPost.API.Services.AuthService
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(SignInManager<User> signInManager, ILogger<AuthService> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<bool> LoginUserAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is null)
            {
                _logger.LogInformation("User Not Found");
                return false;
            }

            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return true;
            }
            _logger.LogInformation("Unable to login");
            return false;
        }
    }
}
