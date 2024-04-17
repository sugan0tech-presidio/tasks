using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.Repository
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        public static readonly string[] Specializations =
        {
            "General Medicine",
            "Pediatrics",
            "Cardiology",
            "Orthopedics",
            "Neurology",
            "Dermatology",
            "Ophthalmology"
        };

        public static readonly string[] Qualifications =
        {
            "MBBS",
            "MD",
            "MS",
            "DM"
        };

        private readonly Dictionary<int, Doctor> _doctors;

        public DoctorRepository()
        {
            // Initialize the dictionary of doctors
            _doctors = new Dictionary<int, Doctor>();
        }

        public List<Doctor> GetAll()
        {
            return new List<Doctor>(_doctors.Values);
        }

        public Doctor Get(int key)
        {
            // Use TryGetValue to safely retrieve the doctor
            _doctors.TryGetValue(key, out Doctor doctor);
            return doctor;
        }

        public Doctor Add(Doctor item)
        {
            // Generating a unique id for the new doctor
            var newId = _doctors.Count > 0 ? _doctors.Keys.Max() + 1 : 1;
            item.Id = newId;
            _doctors.Add(newId, item);
            return item;
        }

        public Doctor Update(Doctor item)
        {
            // Find the doctor in the dictionary
            if (_doctors.ContainsKey(item.Id))
            {
                // Update the doctor's properties
                _doctors[item.Id] = item;
                return item;
            }
            else
            {
                return null; // Doctor not found
            }
        }

        public Doctor Delete(int key)
        {
            // Find the doctor in the dictionary
            if (_doctors.TryGetValue(key, out Doctor doctor))
            {
                _doctors.Remove(key);
                return doctor;
            }
            else
            {
                return null; // Doctor not found
            }
        }

        public List<Doctor> FilterBySpeciality(string speciality)
        {
            return _doctors.Values.Where(d => d.Specialization.Contains(speciality)).ToList();
        }
    }
}
