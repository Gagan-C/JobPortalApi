using JobPost.API.Database;
using JobPost.API.Dtos;
using JobPost.API.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPost.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isValidUser = await _authService.LoginUserAsync(dto);
            if (isValidUser)
            {
                return Ok("Logged in successfully");
            }
            return Unauthorized();
        }
    }
}
