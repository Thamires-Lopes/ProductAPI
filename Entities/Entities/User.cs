using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [NotMapped]
        public string Password { get; set; }
    }
}
