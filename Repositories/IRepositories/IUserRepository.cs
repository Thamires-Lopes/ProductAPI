using Entities.Entities;

namespace Repositories.IRepositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        void RegisterUser(User user);
    }
}
