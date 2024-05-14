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
        var qualificationsOne = new List<Qualification> { Qualification.MBBS, Qualification.MS };
        var specializationsOne = new List<Speciality> { Speciality.Cardia };
        var qualificationsTwo = new List<Qualification> { Qualification.BDS, Qualification.MS };
        var specializationsTwo = new List<Speciality> { Speciality.Dental };
        
        modelBuilder.Entity<Doctor>().HasData(
            new
            {
                Id = 101, Name = "Perumal", ContactNumber = "885593323", Email = "perumal@gmail.com",
                Address = "1st street banglore, india", Dob = DateTime.Now.AddYears(-30), Experience = 5, Qualification = qualificationsOne, Speciality = specializationsOne
            },
            new
            {
                Id = 102, Name = "uerumal", ContactNumber = "885593333", Email = "uerumal@gmail.com",
                Address = "2st street banglore, india", Dob = DateTime.Now.AddYears(-35), Experience = 5, Qualification = qualificationsTwo, Speciality = specializationsTwo
            }
        );
    }
}