using Jobpost.API.Model;
using JobPost.API.Dtos;

namespace JobPost.API.Database
{
    public interface IUserService
    {
        public  Task<IEnumerable<User>> GetUsersAsync();
    }
}
