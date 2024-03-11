
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using System.Text.Json;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = Configure(args);

            var db = new APIContext();

            app.MapPost("/saveCar", ([FromBody] Car car) =>
            {
                db.Add(car);
                db.SaveChanges();

                return "Saved";
            });

            app.MapPost("/saveBook", ([FromBody] Book book) =>
            {
                db.Add(book);
                db.SaveChanges();

                return "Saved";
            });

            app.MapGet("/cars", (HttpContext httpContext) =>
            {
                var cars = db.Cars.ToList();

                return cars;
            });

            app.MapGet("/books", (HttpContext httpContext) =>
            {
                var books = db.Books.ToList();

                return books;
            });

            app.MapGet("/products", (HttpContext httpContext) =>
            {
                var products = db.Products.ToList();

                return products;
            });


            app.Run();
        }

        private static WebApplication Configure(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
