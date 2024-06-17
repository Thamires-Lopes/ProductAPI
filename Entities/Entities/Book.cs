using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Book : Product
    {
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        [Timestamp]
        public byte[] VersionBook { get; set; }
    }
}
