using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentManager.Repository
{
    internal class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions options) : base(options) { }

        public virtual DbSet<Doctor> Doctors {get; set;}
        public virtual DbSet<Patient> Patients {get; set;}
        public virtual DbSet<Appointment> Appointments {get; set;}
    }
}
