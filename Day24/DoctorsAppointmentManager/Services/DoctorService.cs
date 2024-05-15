using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Repos;

namespace DoctorsAppointmentManager.Services;

/// <summary>
/// Service class for managing doctor-related operations.
/// Inherits from the BaseService class and implements IDoctorService interface.
/// </summary>
public class DoctorService : BaseService<Doctor>, IDoctorService
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorService"/> class.
    /// </summary>
    /// <param name="repository">The repository instance for Doctor entities.</param>
    public DoctorService(IBaseRepo<Doctor> repository) : base(repository)
    {
    }

    /// <summary>
    /// Gets all doctors by a specified speciality.
    /// </summary>
    /// <param name="speciality">The speciality to filter doctors by.</param>
    /// <returns>A list of doctors with the specified speciality.</returns>
    public async Task<List<Doctor>> GetAllBySpeciality(Speciality speciality)
    {
        var repos =  Repository.GetAll().Result
            .ToList().FindAll(doc => doc.Speciality.Equals(speciality));
        return repos;
    }

    /// <summary>
    /// Updates the experience of a doctor by their ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to update.</param>
    /// <param name="experience">The new experience value to set.</param>
    /// <returns>The updated doctor entity.</returns>
    public async Task<Doctor> UpdateExperience(int id, int experience)
    {
        var doctor = await GetById(id);
        doctor.Experience = experience;
        await Update(doctor);
        return doctor;
    }

    /// <summary>
    /// Updates the speciality of a doctor by their ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to update.</param>
    /// <param name="speciality">The new speciality to set.</param>
    /// <returns>The updated doctor entity.</returns>
    public async Task<Doctor> UpdateSpeciality(int id, Speciality speciality)
    {
        var doctor = await GetById(id);
        doctor.Speciality = speciality;
        await Update(doctor);
        return doctor;
    }
}