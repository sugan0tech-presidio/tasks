using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Blobs;
using DemoWebService.Repos;
using DemoWebService.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoWebService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<KeyVaultService>();
        builder.Services.AddScoped<BlobService>();
        
        var secretClient = new SecretClient(new Uri("https://suga-vault.vault.azure.net/"), new DefaultAzureCredential());
        builder.Services.AddSingleton(secretClient);
        var serviceProvider = builder.Services.BuildServiceProvider();
        var keyVaultService = serviceProvider.GetService<KeyVaultService>();
        var connectionString = keyVaultService.GetSecretAsync("SqlConnectionString").Result;
        
        builder.Services.AddDbContext<ProductContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddSingleton(new BlobServiceClient(keyVaultService.GetSecretAsync("blobConnectionString").Result));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}