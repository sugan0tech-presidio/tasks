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
        modelBuilder.Entity<Request>()
            .HasOne(r => r.RaisedBy)
            .WithMany(e => e.RequestsRaised)
            .HasForeignKey(r => r.RequestRaisedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(r => r.RequestClosedByEmployee)
            .WithMany(e => e.RequestsClosed)
            .HasForeignKey(r => r.RequestClosedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RequestSolution>()
            .HasOne(rs => rs.RequestRaised)
            .WithMany(r => r.RequestSolutions)
            .HasForeignKey(rs => rs.RequestId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<RequestSolution>()
            .HasOne(rs => rs.SolvedByEmployee)
            .WithMany(e => e.SolutionPrvided)
            .HasForeignKey(rs => rs.SolvedBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        modelBuilder.Entity<SolutionFeedback>()
            .HasOne(sf=>sf.Solution)
            .WithMany(s=>s.Feedbacks)
            .HasForeignKey(sf=>sf.SolutionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        
        modelBuilder.Entity<SolutionFeedback>()
            .HasOne(sf => sf.FeedbackByPerson)
            .WithMany(p => p.FeedbacksGiven)
            .HasForeignKey(sf => sf.FeedbackBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}