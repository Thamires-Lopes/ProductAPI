namespace ProductAPI.ServiceLayer.IServices
{
    public interface IAuthenticateService
    {
        bool Authenticate(string email, string password);
        bool EmailAlreadyRegistered(string email);
        string GenerateToken(int id, string email);
    }
}
