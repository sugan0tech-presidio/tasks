namespace DoctorsAppointmentLibrary.Repository;

public class AppointmentRepository : IRepository<int, Appointment>
{
    private readonly List<Appointment> _appointments;

    public AppointmentRepository()
    {
        _appointments = new List<Appointment>();
    }

    public List<Appointment> GetAll()
    {
        return _appointments;
    }

    public Appointment Get(int key)
    {
        return _appointments.FirstOrDefault(a => a.Id == key);
    }

    public Appointment Add(Appointment item)
    {
        // Generating a unique id for the new appointment 
        var newId = _appointments.Count > 0 ? _appointments.Max(a => a.Id) + 1 : 1;
        item.Id = newId;
        _appointments.Add(item);
        return item;
    }

    public Appointment Update(Appointment item)
    {
        // Find the appointment in the list
        var existingAppointment = _appointments.FirstOrDefault(a => a.Id == item.Id);
        if (existingAppointment != null)
        {
            // Update the appointment's properties
            existingAppointment.Doctor = item.Doctor;
            existingAppointment.Patient = item.Patient;
            existingAppointment.AppointmentDateTime = item.AppointmentDateTime;
        }

        return existingAppointment;
    }

    public Appointment Delete(int key)
    {
        // Find the appointment in the list
        var appointmentToDelete = _appointments.FirstOrDefault(a => a.Id == key);
        if (appointmentToDelete != null) _appointments.Remove(appointmentToDelete);
        return appointmentToDelete;
    }
}