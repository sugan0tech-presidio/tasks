using System.Security.AccessControl;
using System.Text;
using System.Text.Json.Serialization;
using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;
using AwesomeRequestTracker.Serivces;
using AwesomeRequestTracker.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            builder.Services.AddLogging(l => l.AddLog4Net());
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        new string[] { }
                    }
                });
            });

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
            builder.Services.AddScoped<IBaseService<Registry>, RegistryService>();
            builder.Services.AddScoped<IBaseService<SolutionFeedback>, SolutionFeedbackService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<RequestSolutionService>();
            builder.Services.AddScoped<RequestService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<AdminService>();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                    };

                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policyBuilder =>  policyBuilder.RequireRole(Role.Admin.ToString()));
                options.AddPolicy("UserPolicy", policyBuilder =>  policyBuilder.RequireRole(Role.User.ToString(), Role.Employee.ToString(), Role.Admin.ToString()));
                options.AddPolicy("EmployeePolicy", policyBuilder =>  policyBuilder.RequireRole(Role.User.ToString(), Role.Employee.ToString()));
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}