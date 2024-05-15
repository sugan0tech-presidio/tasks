using DoctorsAppointmentManager.Contexts;
using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Repos;
using DoctorsAppointmentManager.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentManager
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

            builder.Services.AddDbContext<DoctorAppointmentManagerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            builder.Services.AddScoped<IBaseRepo<Doctor>, DoctorRepo>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();

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