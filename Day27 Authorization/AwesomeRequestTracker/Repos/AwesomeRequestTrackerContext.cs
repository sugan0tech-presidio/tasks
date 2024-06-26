﻿using AwesomeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTracker.Repos;

public class AwesomeRequestTrackerContext : DbContext
{
    public AwesomeRequestTrackerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Registry> Registry { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<SolutionFeedback> RequestFeedbacks { get; set; }
    public DbSet<RequestSolution> RequestSolutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seeds

        modelBuilder.Entity<Employee>().HasData(
            new
            {
                Id = 1, Name = "ramu", password = "123", Role = Role.Admin, Email = "ramu@gmail.com",
                ContactNumber = "6855339922"
            },
            new
            {
                Id = 2, Name = "somu", password = "456", Role = Role.Employee, Email = "somu@gmail.com",
                ContactNumber = "6855339922"
            },
            new
            {
                Id = 3, Name = "vembu", password = "789", Role = Role.Employee, Email = "vembu@gmail.com",
                ContactNumber = "6855339922"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = 4, Name = "sugu", Role = Role.User, Email = "sugu@gmail.com",
                ContactNumber = "6855339922", Address = "magic, street"
            },
            new
            {
                Id = 5, Name = "bboi", Role = Role.User, Email = "bboi@gmail.com",
                ContactNumber = "9855339922", Address = "Someting"
            }
        );

        #endregion

        #region Index

        modelBuilder.Entity<Person>()
            .HasIndex(p => p.Email)
            .IsUnique();

        #endregion

        #region Person

        modelBuilder.Entity<Person>()
            .HasMany<Request>()
            .WithOne(r => r.RaisedBy)
            .HasForeignKey(r => r.RequestRaisedById)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        
        modelBuilder.Entity<Person>()
            .HasMany<SolutionFeedback>()
            .WithOne(sf => sf.FeedbackByPerson)
            .HasForeignKey(sf => sf.FeedbackBy)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        modelBuilder.Entity<Person>()
            .Navigation(p => p.RequestsRaised)
            .AutoInclude();
        
        modelBuilder.Entity<Person>()
            .Navigation(p => p.FeedbacksGiven)
            .AutoInclude();

        #endregion

        #region Employee

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.SolutionPrvided)
            .WithOne(rs => rs.SolvedByEmployee)
            .HasForeignKey(e => e.Id)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        #endregion

        #region Request

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

        #endregion

        #region RequstSolution

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
            .Navigation(rs => rs.Feedbacks)
            .AutoInclude();

        #endregion

        #region SolutionFeedback

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

        #endregion

        #region Registry

        modelBuilder.Entity<Registry>()
            .Navigation(r => r.Person)
            .AutoInclude();

        #endregion
    }
}