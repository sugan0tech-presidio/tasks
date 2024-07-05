using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Contexts;

public class ShopContext(DbContextOptions<ShopContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>();
    }
}