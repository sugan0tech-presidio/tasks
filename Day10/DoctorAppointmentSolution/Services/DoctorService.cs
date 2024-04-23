using DoctorAppointmentManager.Entities;
using DoctorAppointmentManager.Exceptions;
using DoctorAppointmentManager.Repository;

namespace DoctorAppointmentManager.Services
{
    /// <summary>
    /// Service for managing doctors and their operations.
    /// </summary>
    public class DoctorService: IDoctorsService
    {
        private readonly DoctorRepository _doctorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DoctorService"/> class.
        /// </summary>
        /// <param name="doctorRepository">The doctor repository.</param>
        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        /// <summary>
        /// Gets all doctors.
        /// </summary>
        /// <returns>The list of all doctors.</returns>
        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        /// <summary>
        /// Gets a doctor by their ID.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor.</param>
        /// <returns>The doctor with the specified ID.</returns>
        /// <exception cref="DoctorNotFoundException">Thrown when the doctor with the specified ID is not found.</exception>
        public Doctor GetDoctorById(int doctorId)
        {
            try
            {
                return _doctorRepository.Get(doctorId);
            }
            catch (DoctorNotFoundException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Adds a new doctor.
        /// </summary>
        /// <param name="doctor">The doctor to add.</param>
        /// <returns>The added doctor.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided doctor object is null.</exception>
        /// <exception cref="DuplicateDoctorException">Thrown when a doctor with the same details already exists.</exception>
        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
                return _doctorRepository.Add(doctor);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (DuplicateDoctorException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing doctor.
        /// </summary>
        /// <param name="doctor">The updated doctor object.</param>
        /// <returns>The updated doctor.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the provided doctor object is null.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the doctor to update is not found.</exception>
        public Doctor UpdateDoctor(Doctor doctor)
        {
            try
            {
                return _doctorRepository.Update(doctor);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Deletes a doctor by their ID.
        /// </summary>
        /// <param name="doctorId">The ID of the doctor to delete.</param>
        /// <returns>The deleted doctor.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the doctor to delete is not found.</exception>
        public Doctor DeleteDoctor(int doctorId)
        {
            try
            {
                return _doctorRepository.Delete(doctorId);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Filters doctors by specialization.
        /// </summary>
        /// <param name="specialization">The specialization to filter by.</param>
        /// <returns>The list of doctors with the specified specialization.</returns>
        public List<Doctor> FilterDoctorsBySpecialization(string specialization)
        {
            return _doctorRepository.FilterBySpeciality(specialization);
        }

        public List<Doctor> FindDoctorsBySpeciality(string speciality)
        {
            return _doctorRepository.GetAll().FindAll(doctor => doctor.Specialization.Contains(speciality));
        }
    }
}
