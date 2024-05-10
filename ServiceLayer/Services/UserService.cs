using ProductAPI.DatabaseLayer.IRepositories;
using ProductAPI.Entities;
using ProductAPI.ServiceLayer.IServices;
using System.Security.Cryptography;
using System.Text;

namespace ProductAPI.ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticateService _authenticateService;

        public UserService(IUserRepository userRepository, IAuthenticateService authenticateService)
        {
            _userRepository = userRepository;
            _authenticateService = authenticateService;
        }

        public string RegisterUser(User user)
        {
            try
            {
                if (user.Password == null) 
                {
                    using var hmac = new HMACSHA512();
                    byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                    byte[] passwordSalt = hmac.Key;

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                _userRepository.RegisterUser(user);
            }
            catch (Exception)
            {
                return "User not saved";
            }

            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return token;
        }

        public string Login(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return "Usuário não existe.";
            }
            
            var result = _authenticateService.Authenticate(email, password);

            if (!result) return "Usuário não autorizado.";

            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return token;
        }

    }
}
