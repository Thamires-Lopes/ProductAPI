using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class APIContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }

        public APIContext(DbContextOptions<APIContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"Server=localhost;Database=product;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().UseTptMappingStrategy();
            modelBuilder.Entity<Book>().UseTptMappingStrategy();
            modelBuilder.Entity<Car>().UseTptMappingStrategy();
            modelBuilder.Entity<User>();
        }
    }
}
