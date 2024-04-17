using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class PatientRepository : IRepository<int, Patient>
    {
        private readonly Dictionary<int, Patient> _patients;

        public PatientRepository()
        {
            // Initialize the dictionary of patients
            _patients = new Dictionary<int, Patient>();
        }

        public List<Patient> GetAll()
        {
            return new List<Patient>(_patients.Values);
        }

        public Patient Get(int key)
        {
            // Use TryGetValue to safely retrieve the patient
            _patients.TryGetValue(key, out Patient patient);
            return patient;
        }

        public Patient Add(Patient item)
        {
            // Generating a unique id for the new patient
            var newId = _patients.Count > 0 ? _patients.Keys.Max() + 1 : 1;
            item.Id = newId;
            _patients.Add(newId, item);
            return item;
        }

        public Patient Update(Patient item)
        {
            // Find the patient in the dictionary
            if (_patients.ContainsKey(item.Id))
            {
                // Update the patient's properties
                _patients[item.Id] = item;
                return item;
            }
            else
            {
                return null; // Patient not found
            }
        }

        public Patient Delete(int key)
        {
            // Find the patient in the dictionary
            if (_patients.TryGetValue(key, out Patient patient))
            {
                _patients.Remove(key);
                return patient;
            }
            else
            {
                return null; // Patient not found
            }
        }
    }
}