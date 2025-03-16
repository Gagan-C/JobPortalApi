using JobPost.API.Dtos;

namespace JobPost.API.Services.AuthService
{
    public interface IAuthService
    {
        public Task<bool> LoginUserAsync(LoginDto dto);
    }
}
