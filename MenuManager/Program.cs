
using MenuManager.Models.Context;
using MenuManager.Models.Repositories;
using MenuManager.Services;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddSwaggerGen();

            // Add Repositories
            builder.Services.AddScoped<DishRepository>();
            builder.Services.AddScoped<DishTypeRepository>();

            // Add Services
            builder.Services.AddScoped<DishTypeServices>();
            builder.Services.AddScoped<DishServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
