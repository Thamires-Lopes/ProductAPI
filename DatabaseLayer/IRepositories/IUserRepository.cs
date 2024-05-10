using ProductAPI.Entities;

namespace ProductAPI.DatabaseLayer.IRepositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
        void RegisterUser(User user);
    }
}
