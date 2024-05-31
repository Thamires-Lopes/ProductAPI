using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductAPI;
using Repositories;

namespace IntegrationTest
{
    public class ProductApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<APIContext>));

                services.AddDbContext<APIContext>(options => options.UseInMemoryDatabase("apiInMemoryDatabase"));

                var dbContext = CreateDbContext(services);

                dbContext.Database.EnsureDeleted();
            });
        }

        private static APIContext CreateDbContext(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<APIContext>();

            return dbContext;
        }
    }
}
