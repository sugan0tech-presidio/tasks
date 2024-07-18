using DemoWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWebService.Repos;

public class ProductContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
 
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
 
         modelBuilder.Entity<Product>(entity =>
         {
             entity.HasKey(e => e.ProductId);
             entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
             entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
             entity.Property(e => e.PictureUrl).HasMaxLength(200);
         });
                 modelBuilder.Entity<Product>().HasData(
                     new Product
                     {
                         ProductId = 1,
                         Name = "Product One",
                         Price = 10.0M,
                         PictureUrl = "https://dbsuga.blob.core.windows.net/products/one.png"
                     },
                     new Product
                     {
                         ProductId = 2,
                         Name = "Product Two",
                         Price = 20.0M,
                         PictureUrl = "https://dbsuga.blob.core.windows.net/products/two.png"
                     },
                     new Product
                     {
                         ProductId = 3,
                         Name = "Product Three",
                         Price = 30.0M,
                         PictureUrl = "https://dbsuga.blob.core.windows.net/products/three.png"
                     }
                 );
     }   
}