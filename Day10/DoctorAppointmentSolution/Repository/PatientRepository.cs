using DoctorAppointmentManager.Entities;

namespace DoctorAppointmentManager.Repository
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }

        /// <summary>
        /// </summary>
        /// <returns>List of all patients from the store.</returns>
        public List<Patient> GetAll()
        {
            return new List<Patient>(_patients.Values);
        }

        /// <summary>
        /// Get's specific patient with the provided Id.
        /// </summary>
        /// <param name="key">Patient's Id</param>
        /// <returns>fetched Patient's object</returns>
        public Patient Get(int key)
        {
            _patients.TryGetValue(key, out Patient patient);
            return patient;
        }

        /// <summary>
        /// To add new Patient to the store.
        /// </summary>
        /// <param name="item">patient object</param>
        /// <returns>added patient object</returns>
        /// <exception cref="ArgumentNullException">If the provided argument is null</exception>
        public Patient Add(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Patient cannot be null.");

            var newId = _patients.Count > 0 ? _patients.Keys.Max() + 1 : 1;
            item.Id = newId;
            _patients.Add(newId, item);
            return item;
        }

        /// <summary>
        /// Updating patients data
        /// </summary>
        /// <param name="item">Updated patients object with key</param>
        /// <returns>Updated patients object</returns>
        /// <exception cref="ArgumentNullException">If the input object is null</exception>
        /// <exception cref="KeyNotFoundException">If no patients found with the id</exception>
        public Patient Update(Patient item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Patient cannot be null.");

            if (!_patients.ContainsKey(item.Id))
                throw new KeyNotFoundException($"Patient with ID {item.Id} not found.");

            _patients[item.Id] = item;
            return item;
        }

        /// <summary>
        /// To deleted a patient from the store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Deleted patents object</returns>
        public Patient Delete(int key)
        {
            if (!_patients.TryGetValue(key, out var patient))
                throw new KeyNotFoundException($"Patient with ID {key} not found.");

            _patients.Remove(key);
            return patient;
        }
    }
}