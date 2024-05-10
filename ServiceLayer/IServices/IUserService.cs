using ProductAPI.Entities;

namespace ProductAPI.ServiceLayer.IServices
{
    public interface IUserService
    {
        string RegisterUser(User user);
        string Login(string email, string password);
    }
}
