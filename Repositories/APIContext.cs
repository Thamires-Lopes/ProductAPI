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

        public string DbPath;

        public APIContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "api.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
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
