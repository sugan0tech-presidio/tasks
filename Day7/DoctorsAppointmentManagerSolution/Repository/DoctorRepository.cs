using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository;

public class DoctorRepository : IRepository<int, Doctor>
{
    private readonly List<Doctor> _doctors;

    public DoctorRepository()
    {
        // Initialize the list of doctors
        _doctors = new List<Doctor>();
    }

    public List<Doctor> GetAll()
    {
        return _doctors;
    }

    public Doctor Get(int key)
    {
        return _doctors.FirstOrDefault(d => d.Id == key);
    }

    public Doctor Add(Doctor item)
    {
        // Generating a unique id for the new doctor
        var newId = _doctors.Count > 0 ? _doctors.Max(d => d.Id) + 1 : 1;
        item.Id = newId;
        _doctors.Add(item);
        return item;
    }

    public Doctor Update(Doctor item)
    {
        // Find the doctor in the list
        var existingDoctor = _doctors.FirstOrDefault(d => d.Id == item.Id);
        if (existingDoctor != null)
        {
            // Update the doctor's properties
            existingDoctor.Name = item.Name;
            existingDoctor.Specialization = item.Specialization;
        }

        return existingDoctor;
    }

    public Doctor Delete(int key)
    {
        // Find the doctor in the list
        var doctorToDelete = _doctors.FirstOrDefault(d => d.Id == key);
        if (doctorToDelete != null) _doctors.Remove(doctorToDelete);
        return doctorToDelete;
    }
}