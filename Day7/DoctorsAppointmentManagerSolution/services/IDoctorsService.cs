using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

namespace DoctorsAppointmentManager.services;

public interface IDoctorsService
{
    /// <summary>
    /// Get all doctors by given speciality.
    /// </summary>
    /// <param name="speciality">Given valid speciality as string</param>
    /// <returns>List of Doctors</returns>
    List<Doctor> FindDoctorsBySpeciality(string speciality);
}