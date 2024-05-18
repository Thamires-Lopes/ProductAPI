using Entities.Entities;

namespace Services.IServices
{
    public interface IUserService
    {
        string RegisterUser(User user);
        string Login(string email, string password);
    }
}
