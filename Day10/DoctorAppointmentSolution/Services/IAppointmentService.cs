using DoctorAppointmentManager.Entities;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorAppointmentManager.Services;

public interface IAppointmentService
{
    /// <summary>
    ///     Gets all appoints for given doctor.
    /// </summary>
    /// <param name="doctor">doctor as object</param>
    /// <returns>List of Appointment</returns>
    List<Appointment> GetAppointmentsForDoctor(Doctor doctor);

    /// <summary>
    ///     Get all appointments for a specific patient
    /// </summary>
    /// <param name="patient">patient as object</param>
    /// <returns>List of Appointment</returns>
    List<Appointment> GetAppointmentsForPatient(Patient patient);

    /// <summary>
    ///     Get all appointments within a specified date range
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    List<Appointment> GetAppointmentsInDateRange(DateTime startDate, DateTime endDate);

    /// <summary>
    ///     Get all appointments for a specific doctor within a specified date range.
    /// </summary>
    /// <param name="doctor">Doctor object</param>
    /// <param name="startDate">Start Date</param>
    /// <param name="endDate">End Date</param>
    /// <returns>List of appointment</returns>
    List<Appointment> GetAppointmentsForDoctorInDateRange(Doctor doctor, DateTime startDate, DateTime endDate);

    /// <summary>
    ///     Get all appointments for a specific patient within a specified date range.
    /// </summary>
    /// <param name="patient">Patient object</param>
    /// <param name="startDate">Start Date</param>
    /// <param name="endDate">End Date</param>
    /// <returns></returns>
    List<Appointment> GetAppointmentsForPatientInDateRange(Patient patient, DateTime startDate, DateTime endDate);

    // Schedule a new appointment
    /// <summary>
    ///     Schedule a new appointment.
    /// </summary>
    /// <param name="doctor">doctor object</param>
    /// <param name="patient">patient object</param>
    /// <param name="appointmentDateTime">Date time object</param>
    /// <param name="purpose">Purpose of the appointment or visit</param>
    void ScheduleAppointment(Doctor doctor, Patient patient, DateTime appointmentDateTime, string purpose);

    /// <summary>
    ///     Update an existing appointment
    /// </summary>
    /// <param name="appointment"></param>
    void UpdateAppointment(Appointment appointment);

    /// <summary>
    ///     Cancel an appointment
    /// </summary>
    /// <param name="appointmentId">appointment id</param>
    void CancelAppointment(int appointmentId);
}