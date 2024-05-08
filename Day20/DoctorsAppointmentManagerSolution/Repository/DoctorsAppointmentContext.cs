using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentManager.Repository
{
    public partial class DoctorsAppointmentContext : DbContext
    {
        public DoctorsAppointmentContext()
        {
        }

        public DoctorsAppointmentContext(DbContextOptions<DoctorsAppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=B4RBBX3\\SQLSERVERG3;Database=DoctorsAppointmentLibrary;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Patient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.HasMany(d => d.Qualification)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("DoctorQualifications"));

                entity.HasMany(d => d.Specialization)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("DoctorSpecializations"));
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.Qualification });

                entity.HasOne(q => q.Doctor)
                    .WithMany(d => d.Qualification)
                    .HasForeignKey(q => q.DoctorId);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.HasKey(e => new { e.DoctorId, e.Specialization });

                entity.HasOne(s => s.Doctor)
                    .WithMany(d => d.Specialization)
                    .HasForeignKey(s => s.DoctorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
