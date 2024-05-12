using AwesomeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTracker.Repos;

public class AwesomeRequestTrackerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=B4RBBX3\SQLEXPRESS;Integrated Security=true;TrustServerCertificate=True;Initial Catalog=AwesomeDB;");
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<SolutionFeedback> RequestFeedbacks { get; set; }
    public DbSet<RequestSolution> RequestSolutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}