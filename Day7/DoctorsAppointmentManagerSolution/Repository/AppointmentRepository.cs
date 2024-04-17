using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly Dictionary<int, Appointment> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        public List<Appointment> GetAll()
        {
            return new List<Appointment>(_appointments.Values);
        }

        public Appointment Get(int key)
        {
            // Use TryGetValue to safely retrieve the appointment
            _appointments.TryGetValue(key, out Appointment appointment);
            return appointment;
        }

        public Appointment Add(Appointment item)
        {
            // Generating a unique id for the new appointment 
            var newId = _appointments.Count > 0 ? _appointments.Keys.Max() + 1 : 1;
            item.Id = newId;
            _appointments.Add(newId, item);
            return item;
        }

        public Appointment Update(Appointment item)
        {
            // Find the appointment in the dictionary
            if (_appointments.ContainsKey(item.Id))
            {
                // Update the appointment's properties
                _appointments[item.Id] = item;
                return item;
            }
            else
            {
                return null; // Appointment not found
            }
        }

        public Appointment Delete(int key)
        {
            // Find the appointment in the dictionary
            if (_appointments.TryGetValue(key, out Appointment appointment))
            {
                _appointments.Remove(key);
                return appointment;
            }
            else
            {
                return null; // Appointment not found
            }
        }
    }
}