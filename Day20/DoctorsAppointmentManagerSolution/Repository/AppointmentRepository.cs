using System;
using System.Collections.Generic;
using System.Linq;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly DoctorsAppointmentContext _context;

        public AppointmentRepository(DoctorsAppointmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment Get(int key)
        {
            return _context.Appointments.Find(key);
        }

        public Appointment Add(Appointment item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Appointment cannot be null.");

            if (_context.Appointments.Any(a => a.AppointmentDateTime == item.AppointmentDateTime && a.DoctorId == item.DoctorId))
                throw new ArgumentException("Appointment with the same date and doctor already exists.");

            _context.Appointments.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment Update(Appointment item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Appointment cannot be null.");

            if (!_context.Appointments.Any(a => a.Id == item.Id))
                throw new KeyNotFoundException($"Appointment with ID {item.Id} not found.");

            if (_context.Appointments.Any(a => a.Id != item.Id && a.AppointmentDateTime == item.AppointmentDateTime && a.DoctorId == item.DoctorId))
                throw new ArgumentException("Appointment with the same date and doctor already exists.");

            _context.Appointments.Update(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment Delete(int key)
        {
            var appointment = _context.Appointments.Find(key);
            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with ID {key} not found.");

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return appointment;
        }
    }
}
