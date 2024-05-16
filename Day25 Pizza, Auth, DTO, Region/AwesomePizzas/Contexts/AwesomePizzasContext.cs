using AwesomePizzas.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomePizzas.Contexts;

public class AwesomePizzasContext: DbContext
{
    public AwesomePizzasContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders  { get; set; }
    public DbSet<Pizza> Pizzas  { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}