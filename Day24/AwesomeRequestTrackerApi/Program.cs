using AwesomeRequestTrackerApi.Contexts;
using AwesomeRequestTrackerApi.Models;
using AwesomeRequestTrackerApi.Repos;
using AwesomeRequestTrackerApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTrackerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AwesomeRequestTrackerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

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