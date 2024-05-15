using DoctorsAppointmentManager.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentManager.Contexts;

public class DoctorAppointmentManagerContext: DbContext
{
    public DoctorAppointmentManagerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Qualification>().HasData(
            new { Id = 1, Name = "MBBS" },
            new { Id = 2, Name = "MS"},
            new { Id = 3, Name = "BDS"},
            new { Id = 4, Name = "MD"}
            );
        
        modelBuilder.Entity<Speciality>().HasData(
            new { Id = 1, Name = "Cardia" },
            new { Id = 2, Name = "Dental"},
            new { Id = 3, Name = "Neuro"},
            new { Id = 4, Name = "Ortho"}
            );

        
        modelBuilder.Entity<Doctor>().HasData(
            new
            {
                Id = 101, Name = "Perumal", ContactNumber = "885593323", Email = "perumal@gmail.com",
                Address = "1st street banglore, india", Dob = DateTime.Now.AddYears(-30), Experience = 5
            },
            new
            {
                Id = 102, Name = "uerumal", ContactNumber = "885593333", Email = "uerumal@gmail.com",
                Address = "2st street banglore, india", Dob = DateTime.Now.AddYears(-35), Experience = 5
            }
        );

        modelBuilder.Entity<Doctor>()
            .Navigation(d => d.Qualification)
            .AutoInclude();
        
        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Qualification)
            .WithMany(q => q.Doctors);
        
        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.Specialities)
            .WithMany(q => q.Doctors);

        // todo nice idea have to check
        // modelBuilder.Entity<Doctor>()
        //     .Property(doctor => doctor.Qualification)
        //     .HasConversion(
        //         q => string.Join(',', q),
        //         q => q.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<Qualification>()
        //     );
    }
}