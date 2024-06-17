namespace Entities.DTOs
{
    public class BookDTO
    {
        public int? Id { get; set; }
        public string Author { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
