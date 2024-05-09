using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly Dictionary<int, Appointment?> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment?>();
        }

        /// <summary>
        /// Get all appointments.
        /// </summary>
        /// <returns>List of Appointment</returns>
        public List<Appointment> GetAll()
        {
            return new List<Appointment>(_appointments.Values);
        }

        /// <summary>
        ///  Get specific appointment with the given Id
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Matched appointment with the given key</returns>
        /// <exception cref="Exception">If no appointment found with the given key</exception>
        public Appointment Get(int key)
        {
            _appointments.TryGetValue(key, out Appointment appointment);
            if (appointment == null)
                throw new Exception("Appointment not found!!!");
            return appointment;
        }

        /// <summary>
        ///  To create new appointment.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the incoming Appointment object is null</exception>
        /// <exception cref="ArgumentException">If we had a appointment with that date</exception>
        public Appointment Add(Appointment item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Appointment cannot be null.");

            if (_appointments.Values.Any(a => a.AppointmentDateTime == item.AppointmentDateTime && a.Doctor.Equals(item.Doctor)))
                throw new ArgumentException("Appointment with the same date and doctor already exists.");

            var newId = _appointments.Count > 0 ? _appointments.Keys.Max() + 1 : 1;
            item.Id = newId;
            _appointments.Add(newId, item);
            return item;
        }
        
        /// <summary>
        /// To adjust Appointment.
        /// </summary>
        /// <param name="item">updated appointment with correct Id</param>
        /// <returns>Updated appointment</returns>
        /// <exception cref="ArgumentNullException">If the input is null</exception>
        /// <exception cref="KeyNotFoundException">If appointment not present with the given Id</exception>
        /// <exception cref="ArgumentException">If there is a appointment with same time</exception>
        public Appointment Update(Appointment item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Appointment cannot be null.");

            if (!_appointments.ContainsKey(item.Id))
                throw new KeyNotFoundException($"Appointment with ID {item.Id} not found.");

            if (_appointments.Values.Any(a => a.Id != item.Id && a.AppointmentDateTime == item.AppointmentDateTime && a.Doctor == item.Doctor))
                throw new ArgumentException("Appointment with the same date and doctor already exists.");
            
            _appointments[item.Id] = item;
            
            return item;
        }

        /// <summary>
        /// Deletes appointment
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Appointment</returns>
        /// <exception cref="KeyNotFoundException">If no appointment presents for the given appointment.</exception>
        public Appointment Delete(int key)
        {
            if (!_appointments.TryGetValue(key, out var appointment))
                throw new KeyNotFoundException($"Appointment with ID {key} not found.");

            _appointments.Remove(key);
            return appointment;
        }
    }
}