using DoctorAppointmentManager.Entities;
using DoctorAppointmentManager.Exceptions;
using DoctorAppointmentManager.Repository;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

// Added exception namespace

namespace DoctorAppointmentManager.Services
{
    /// <summary>
    /// Service for managing appointments between doctors and patients.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppointmentService"/> class.
        /// </summary>
        /// <param name="appointmentRepository">The appointment repository.</param>
        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        /// <summary>
        /// Gets appointments for a specific doctor.
        /// </summary>
        /// <param name="doctor">The doctor.</param>
        /// <returns>The list of appointments for the specified doctor.</returns>
        public List<Appointment> GetAppointmentsForDoctor(Doctor doctor)
        {
            return _appointmentRepository.GetAll().FindAll(appointment => appointment.Doctor.Equals(doctor));
        }

        /// <summary>
        /// Gets appointments for a specific patient.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <returns>The list of appointments for the specified patient.</returns>
        public List<Appointment> GetAppointmentsForPatient(Patient patient)
        {
            return _appointmentRepository.GetAll().FindAll(appointment => appointment.Patient.Equals(patient));
        }

        /// <summary>
        /// Gets appointments within a specified date range.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The list of appointments within the specified date range.</returns>
        /// <exception cref="Exception">Thrown when the end date is greater than the start date.</exception>
        public List<Appointment> GetAppointmentsInDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate > startDate)
                throw new Exception("endDate > startDate");
            return _appointmentRepository.GetAll().FindAll(appointment => appointment.AppointmentDateTime > startDate && appointment.AppointmentDateTime < endDate);
        }

        /// <summary>
        /// Gets appointments for a specific doctor within a specified date range.
        /// </summary>
        /// <param name="doctor">The doctor.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The list of appointments for the specified doctor within the specified date range.</returns>
        public List<Appointment> GetAppointmentsForDoctorInDateRange(Doctor doctor, DateTime startDate, DateTime endDate)
        {
            var inRangeAppointments = _appointmentRepository.GetAll().FindAll(appointment =>
                appointment.AppointmentDateTime > startDate && appointment.AppointmentDateTime < endDate);

            return inRangeAppointments.FindAll(appointment => appointment.Doctor.Equals(doctor));
        }

        /// <summary>
        /// Gets appointments for a specific patient within a specified date range.
        /// </summary>
        /// <param name="patient">The patient.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>The list of appointments for the specified patient within the specified date range.</returns>
        public List<Appointment> GetAppointmentsForPatientInDateRange(Patient patient, DateTime startDate, DateTime endDate)
        {
            var inRangeAppointments = _appointmentRepository.GetAll().FindAll(appointment =>
                appointment.AppointmentDateTime > startDate && appointment.AppointmentDateTime < endDate);

            return inRangeAppointments.FindAll(appointment => appointment.Patient.Equals(patient));
        }

        /// <summary>
        /// Schedules a new appointment.
        /// </summary>
        /// <param name="doctor">The doctor.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="appointmentDateTime">The appointment date and time.</param>
        /// <param name="purpose">The purpose of the appointment.</param>
        /// <exception cref="DuplicateAppointmentException">Thrown when an appointment with the same date and doctor already exists.</exception>
        public void ScheduleAppointment(Doctor doctor, Patient patient, DateTime appointmentDateTime, string purpose)
        {
            try
            {
                var appointment = new Appointment(doctor, patient, appointmentDateTime, purpose);
                _appointmentRepository.Add(appointment);
            }
            catch (DuplicateAppointmentException ex)
            {
                Console.WriteLine($"Error scheduling appointment: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing appointment.
        /// </summary>
        /// <param name="appointment">The appointment to update.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the appointment to update is not found.</exception>
        /// <exception cref="DuplicateAppointmentException">Thrown when an appointment with the same date and doctor already exists.</exception>
        public void UpdateAppointment(Appointment appointment)
        {
            try
            {
                _appointmentRepository.Update(appointment);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                throw;
            }
            catch (DuplicateAppointmentException ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Cancels an appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment ID.</param>
        /// <exception cref="KeyNotFoundException">Thrown when the appointment to cancel is not found.</exception>
        public void CancelAppointment(int appointmentId)
        {
            try
            {
                _appointmentRepository.Delete(appointmentId);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"Error canceling appointment: {ex.Message}");
                throw;
            }
        }
    }
}
