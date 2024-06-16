using Entities.Entities;
using Repositories.IRepositories;

namespace Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APIContext _apiContext;

        public UserRepository(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public User GetUserByEmail(string email)
        {
            var user = _apiContext.Users.First(e => e.Email.ToLower() == email.ToLower());

            return user;
        }

        public void RegisterUser(User user)
        {
            _apiContext.Add(user);
        }
    }
}
