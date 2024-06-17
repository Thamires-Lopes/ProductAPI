using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Car : Product
    {
        public string Manufacturer { get; set; }
        public int Year { get; set; }

        [Timestamp]
        public byte[] VersionCar { get; set; }
    }
}
