using Entities.DTOs;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Repositories;
using Repositories.IManager;
using Repositories.IRepositories;
using Repositories.Manager;
using Repositories.Repositories;
using Services.IServices;
using Services.Services;
using Utils.CustomAttributes;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = Configure(args);

            app.MapPost("/saveCar", [TransactionRequired] ([FromServices] IGeneralService service, [FromBody] Car car) =>
            {
                return service.SaveCar(car);
            }).RequireAuthorization();

            app.MapGet("/cars", ([FromServices] IGeneralService service, HttpContext httpContext) =>
            {
                var cars = service.GetCars();

                return cars;
            }).RequireAuthorization();

            app.MapPost("/registerUser", [TransactionRequired] ([FromServices] IUserService service, [FromBody] User user) =>
            {
                return service.RegisterUser(user);
            });

            app.MapPost("/login", ([FromServices] IUserService service, [FromBody] string email, string password) =>
            {
                return service.Login(email, password);
            });

            app.MapPost("/saveBook", [TransactionRequired] ([FromServices] IGeneralService service, [FromBody] BookDTO bookDto) =>
            {
                return service.SaveBook(bookDto);
            });

            app.MapGet("/books", ([FromServices] IGeneralService service, HttpContext httpContext) =>
            {
                var books = service.GetBooks();

                return books;
            });

            app.MapPost("/updateBook", [TransactionRequired] ([FromServices] IGeneralService service, [FromBody] BookDTO bookDto) =>
            {
                return service.UpdateBook(bookDto);
            });

            app.Run();
        }

        private static WebApplication Configure(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<APIContext>();

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            ConfigSwagger(builder);
            
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITransactionManager, TransactionManager>();
            builder.Services.AddTransient<IGeneralService, GeneralService>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();
            
            builder.Services.AddScoped<IMiddleware, ApiMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<IMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }

        private static void ConfigSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
    }
}
