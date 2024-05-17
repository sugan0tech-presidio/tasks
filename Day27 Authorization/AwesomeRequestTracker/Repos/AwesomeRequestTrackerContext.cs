using AwesomeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTracker.Repos;

public class AwesomeRequestTrackerContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=B4RBBX3\SQLEXPRESS;Integrated Security=true;TrustServerCertificate=True;Initial Catalog=AwesomeDB;");
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<SolutionFeedback> RequestFeedbacks { get; set; }
    public DbSet<RequestSolution> RequestSolutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new
            {
                Id = 1, Name = "ramu", password = "123", Role = Role.Admin, Email = "ramu@gmail.com",
                ContactNumber = "6855339922"
            },
            new
            {
                Id = 2, Name = "somu", password = "456", Role = Role.Intern, Email = "somu@gmail.com",
                ContactNumber = "6855339922"
            },
            new
            {
                Id = 3, Name = "vembu", password = "789", Role = Role.Manager, Email = "vembu@gmail.com",
                ContactNumber = "6855339922"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = 4, Name = "sugu", password = "123", Role = Role.BaseUser, Email = "sugu@gmail.com",
                ContactNumber = "6855339922"
            }
        );
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.SolutionPrvided)
            .WithOne(rs => rs.SolvedByEmployee)
            .HasForeignKey(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(r => r.RaisedBy)
            .WithMany(e => e.RequestsRaised)
            .HasForeignKey(r => r.RequestRaisedById)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Request>()
            .HasOne(r => r.RequestClosedByEmployee)
            .WithMany(e => e.RequestsClosed)
            .HasForeignKey(r => r.RequestClosedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Request>()
            .Navigation(request => request.RequestSolutions)
            .AutoInclude();

        modelBuilder.Entity<Request>()
            .Navigation(request => request.RaisedBy)
            .AutoInclude();

        modelBuilder.Entity<Request>()
            .Navigation(request => request.RequestClosedByEmployee)
            .AutoInclude();


        modelBuilder.Entity<RequestSolution>()
            .HasOne(rs => rs.RequestRaised)
            .WithMany(r => r.RequestSolutions)
            .HasForeignKey(rs => rs.RequestId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<RequestSolution>()
            .HasOne(rs => rs.SolvedByEmployee)
            .WithMany(e => e.SolutionPrvided)
            .HasForeignKey(rs => rs.SolvedBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<RequestSolution>()
            .Navigation(rs => rs.RequestRaised)
            .AutoInclude();

        modelBuilder.Entity<RequestSolution>()
            .Navigation(rs => rs.SolvedByEmployee)
            .AutoInclude();

        modelBuilder.Entity<RequestSolution>()
            .Navigation(rs => rs.Feedbacks)
            .AutoInclude();

        modelBuilder.Entity<SolutionFeedback>()
            .HasOne(sf => sf.Solution)
            .WithMany(s => s.Feedbacks)
            .HasForeignKey(sf => sf.SolutionId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<SolutionFeedback>()
            .HasOne(sf => sf.FeedbackByPerson)
            .WithMany(p => p.FeedbacksGiven)
            .HasForeignKey(sf => sf.FeedbackBy)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<SolutionFeedback>()
            .Navigation(sf => sf.Solution)
            .AutoInclude();

        modelBuilder.Entity<SolutionFeedback>()
            .Navigation(sf => sf.FeedbackByPerson)
            .AutoInclude();
    }
}