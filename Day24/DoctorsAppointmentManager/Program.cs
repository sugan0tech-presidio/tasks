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

            #region DBContextConfig

            builder.Services.AddDbContext<DoctorAppointmentManagerContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            #endregion

            #region Repos

            builder.Services.AddScoped<IBaseRepo<Doctor>, DoctorRepo>();

            #endregion

            #region Services

            builder.Services.AddScoped<IDoctorService, DoctorService>();

            #endregion

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