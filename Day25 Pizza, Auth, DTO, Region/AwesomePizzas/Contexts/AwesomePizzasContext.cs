using AwesomePizzas.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizzas.Contexts;

public class AwesomePizzasContext : DbContext
{
    public AwesomePizzasContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pizza>().HasData(
            new Pizza
            {
                Id = 1,
                Name = "Margherita",
                Description = "Classic pizza with tomatoes and mozzarella cheese",
                Price = 8.99,
                stock = 50
            },
            new Pizza
            {
                Id = 2,
                Name = "Pepperoni",
                Description = "Pizza with pepperoni slices and mozzarella cheese",
                Price = 10.99,
                stock = 40
            },
            new Pizza
            {
                Id = 3,
                Name = "Vegetarian",
                Description = "Pizza with assorted vegetables and mozzarella cheese",
                Price = 9.99,
                stock = 30
            }
        );

        #region relations

        modelBuilder.Entity<User>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Pizza)
            .WithMany(u => u.Orders)
            .OnDelete(DeleteBehavior.NoAction);

        // TODO to have a dedicated entity for this many to many ( orderpizzas )
        // modelBuilder.Entity<Pizza>()
        //     .HasMany<Order>(p => p.Orders)
        //     .WithMany(p => p.Pizzas)

        #endregion

        #region Loading

        modelBuilder.Entity<Order>()
            .Navigation(o => o.Pizza)
            .AutoInclude();

        modelBuilder.Entity<User>()
            .Navigation(u => u.Orders)
            .AutoInclude();
        
        #endregion

        #region Index

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        #endregion
    }
}