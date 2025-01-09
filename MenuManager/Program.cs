
using MenuManager.Models.Context;
using MenuManager.Models.Repositories;
using MenuManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MenuManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Add Swagger
            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MenuManager",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Cristian Marinozzi",
                        Email = string.Empty,
                        Url = new Uri("https://menumanager20250109143504.azurewebsites.net"),
                    },
                });
            });

            // Add Repositories
            builder.Services.AddScoped<DishRepository>();
            builder.Services.AddScoped<DishTypeRepository>();

            // Add Services
            builder.Services.AddScoped<DishTypeServices>();
            builder.Services.AddScoped<DishServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MenuManager v1");
                c.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
