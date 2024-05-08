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
            _doctors = new Dictionary<int, Doctor>();
        }

        /// <summary>
        /// </summary>
        /// <returns>List of Doctors</returns>
        public List<Doctor> GetAll()
        {
            return new List<Doctor>(_doctors.Values);
        }

        /// <summary>
        /// Fetches specific Doctor.
        /// </summary>
        /// <param name="key">Doctor's Id</param>
        /// <returns></returns>
        public Doctor Get(int key)
        {
            _doctors.TryGetValue(key, out Doctor doctor);
            return doctor;
        }

        /// <summary>
        /// Adds new Doctor to the store ( dict as of now )
        /// No need of id, since it's auto generated
        /// </summary>
        /// <param name="item">Provided Doctor Object</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the provided is null</exception>
        public Doctor Add(Doctor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Doctor cannot be null.");

            var newId = _doctors.Count > 0 ? _doctors.Keys.Max() + 1 : 1;
            item.Id = newId;
            _doctors.Add(newId, item);
            return item;
        }

        /// <summary>
        /// Updates existing doctor with the given Id.
        /// </summary>
        /// <param name="item">Updated doctors object with Id.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">If the provided object is null</exception>
        /// <exception cref="KeyNotFoundException">If the key doesn't exist anymore</exception>
        public Doctor Update(Doctor item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Doctor cannot be null.");

            if (!_doctors.ContainsKey(item.Id))
                throw new KeyNotFoundException($"Doctor with ID {item.Id} not found.");

            _doctors[item.Id] = item;
            return item;
        }

        /// <summary>
        /// Deletes Doctor from the store.
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Deleted doctor object</returns>
        /// <exception cref="KeyNotFoundException">If the object doesn't exist</exception>
        public Doctor Delete(int key)
        {
            if (!_doctors.TryGetValue(key, out var doctor))
                throw new KeyNotFoundException($"Doctor with ID {key} not found.");

            _doctors.Remove(key);
            return doctor;
        }

        /// <summary>
        /// Filter doctors based on the speciality.
        /// </summary>
        /// <param name="speciality">string of speciality</param>
        /// <returns>selected list of doctors</returns>
        public List<Doctor> FilterBySpeciality(string speciality)
        {
            return _doctors.Values.Where(d => d.Specialization.Contains(speciality)).ToList();
        }
    }
}
