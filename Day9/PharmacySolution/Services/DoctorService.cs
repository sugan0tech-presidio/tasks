using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class DoctorService
{
    private readonly DoctorRepo _doctorRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DoctorService"/> class.
    /// </summary>
    /// <param name="doctorRepository">The doctor repository.</param>
    public DoctorService(DoctorRepo doctorRepository)
    {
        _doctorRepository = doctorRepository ??
                            throw new ArgumentNullException(nameof(doctorRepository),
                                "Doctor repository cannot be null.");
    }

    /// <summary>
    /// Retrieves a doctor by their ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to retrieve.</param>
    /// <returns>The doctor with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the doctor with the specified ID is not found.</exception>
    public Doctor GetById(int id)
    {
        try
        {
            return _doctorRepository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");
        }
    }

    /// <summary>
    /// Retrieves all doctors.
    /// </summary>
    /// <returns>A list of all doctors.</returns>
    public List<Doctor> GetAll()
    {
        return _doctorRepository.GetAll();
    }

    /// <summary>
    /// Adds a new doctor.
    /// </summary>
    /// <param name="doctor">The doctor to add.</param>
    /// <returns>The added doctor.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the doctor is null.</exception>
    public Doctor Add(Doctor doctor)
    {
        if (doctor == null)
            throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");

        return _doctorRepository.Add(doctor);
    }

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="doctor">The doctor to update.</param>
    /// <returns>The updated doctor.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the doctor is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the doctor to update is not found.</exception>
    public Doctor Update(Doctor doctor)
    {
        if (doctor == null)
            throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null.");

        try
        {
            return _doctorRepository.Update(doctor);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Doctor with ID {doctor.Id} not found.");
        }
    }

    /// <summary>
    /// Deletes a doctor by their ID.
    /// </summary>
    /// <param name="id">The ID of the doctor to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the doctor with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        try
        {
            _doctorRepository.Delete(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Doctor with ID {id} not found.");
        }
    }
}