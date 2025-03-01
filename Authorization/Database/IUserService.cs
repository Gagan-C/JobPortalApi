using Authorization.Model;

namespace Authorization.Database
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(); 
    }
}
