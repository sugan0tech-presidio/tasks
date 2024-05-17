using System.Text.Json.Serialization;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;
using AwesomeRequestTracker.Serivces;
using AwesomeRequestTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Controller

            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            #endregion
            
            #region Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion
            
            #region Context

            builder.Services.AddDbContext<AwesomeRequestTrackerContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

            #endregion

            #region Repository

            builder.Services.AddScoped<IBaseRepo<User>, UserRepo>();
            builder.Services.AddScoped<IBaseRepo<Employee>, EmployeeRepo>();
            builder.Services.AddScoped<IBaseRepo<Registry>, RegistryRepo>();
            builder.Services.AddScoped<IBaseRepo<Request>, RequestRepo>();
            builder.Services.AddScoped<IBaseRepo<RequestSolution>, RequestSolutionRepo>();
            builder.Services.AddScoped<IBaseRepo<SolutionFeedback>, SolutionFeedbackRepo>();

            #endregion

            #region Service

            builder.Services.AddScoped<IBaseService<User>, UserService>();
            builder.Services.AddScoped<IBaseService<Employee>, EmployeeService>();
            builder.Services.AddScoped<IBaseService<Request>, RequestService>();
            builder.Services.AddScoped<IBaseService<SolutionFeedback>, SolutionFeedbackService>();
            builder.Services.AddScoped<RequestSolutionService>();
            builder.Services.AddScoped<AuthService>();

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