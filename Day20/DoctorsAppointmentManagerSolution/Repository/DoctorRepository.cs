using System;
using System.Collections.Generic;
using System.Linq;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        private readonly DoctorsAppointmentContext _context;

        public DoctorRepository(DoctorsAppointmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor Get(int key)
        {
            return _context.Doctors.Find(key);
        }

        public Doctor Add(Doctor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Doctor cannot be null.");

            _context.Doctors.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Doctor Update(Doctor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Doctor cannot be null.");

            _context.Doctors.Update(item);
            _context.SaveChanges();
            return item;
        }

        public Doctor Delete(int key)
        {
            var doctor = _context.Doctors.Find(key);
            if (doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {key} not found.");

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> FilterBySpeciality(string speciality)
        {
            return _context.Doctors.Where(d => d.Specialization.Contains(speciality)).ToList();
        }
    }
}
