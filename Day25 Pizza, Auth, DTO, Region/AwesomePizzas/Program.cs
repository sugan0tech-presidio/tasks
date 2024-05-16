using System.Text.Json.Serialization;
using AwesomePizzas.Contexts;
using AwesomePizzas.Models;
using AwesomePizzas.Repos;
using AwesomePizzas.Services;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Context
            
            builder.Services.AddDbContext<AwesomePizzasContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
            
            #endregion

            #region Repos

            builder.Services.AddScoped<IBaseRepo<Pizza>, PizzaRepo>();
            builder.Services.AddScoped<IBaseRepo<Order>, OrderRepo>();
            builder.Services.AddScoped<IBaseRepo<User>, UserRepo>();

            #endregion

            #region Services

            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<PizzaService>();
            builder.Services.AddScoped<UserService>();

            #endregion

            builder.Services.AddControllers().AddJsonOptions(
                options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}