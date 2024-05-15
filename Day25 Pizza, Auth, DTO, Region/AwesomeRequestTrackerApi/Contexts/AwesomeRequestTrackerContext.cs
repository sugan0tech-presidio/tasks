using System.Data.Common;
using AwesomeRequestTrackerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTrackerApi.Contexts;

public class AwesomeRequestTrackerContext : DbContext
{
    public AwesomeRequestTrackerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Image = "" },
            new { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Image = "" }
        );
    }
}