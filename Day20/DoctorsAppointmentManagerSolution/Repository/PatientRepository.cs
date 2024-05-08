using System;
using System.Collections.Generic;
using System.Linq;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly DoctorsAppointmentContext _context;

        public PatientRepository(DoctorsAppointmentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient Get(int key)
        {
            return _context.Patients.Find(key);
        }

        public Patient Add(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Patient cannot be null.");

            _context.Patients.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Patient Update(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Patient cannot be null.");

            _context.Patients.Update(item);
            _context.SaveChanges();
            return item;
        }

        public Patient Delete(int key)
        {
            var patient = _context.Patients.Find(key);
            if (patient == null)
                throw new KeyNotFoundException($"Patient with ID {key} not found.");

            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return patient;
        }
    }
}
