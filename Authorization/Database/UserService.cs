using Authorization.Model;

namespace Authorization.Database
{
    public class UserService:IUserService
    {
        private readonly UserContext _userContext;
        public UserService(UserContext userDbContext)
        {
            _userContext = userDbContext;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userContext.Users.ToList();
        }

    }
}
