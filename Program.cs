using Microsoft.AspNetCore.Mvc;
using ProductAPI.DatabaseLayer.IRepositories;
using ProductAPI.DatabaseLayer.Repositories;
using ProductAPI.Entities;
using ProductAPI.ServiceLayer.Services;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = Configure(args);

            app.MapPost("/saveCar", ([FromServices] GeneralService service, [FromBody] Car car) =>
            {
                return service.SaveCar(car);
            });

            app.MapGet("/cars", ([FromServices] GeneralService service, HttpContext httpContext) =>
            {
                var cars = service.GetCars();

                return cars;
            });

            app.Run();
        }

        private static WebApplication Configure(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<APIContext>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddTransient<GeneralService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            return app;
        }
    }
}
