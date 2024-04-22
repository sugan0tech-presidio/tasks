using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class PatientService
{
    private readonly PatientRepo _patientRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PatientService"/> class.
    /// </summary>
    /// <param name="patientRepository">The patient repository.</param>
    public PatientService(PatientRepo patientRepository)
    {
        _patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository), "Patient repository cannot be null.");
    }

    /// <summary>
    /// Retrieves a patient by their ID.
    /// </summary>
    /// <param name="id">The ID of the patient to retrieve.</param>
    /// <returns>The patient with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the patient with the specified ID is not found.</exception>
    public Patient GetById(int id)
    {
        try
        {
            return _patientRepository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        }
    }

    /// <summary>
    /// Retrieves all patients.
    /// </summary>
    /// <returns>A list of all patients.</returns>
    public List<Patient> GetAll()
    {
        return _patientRepository.GetAll();
    }

    /// <summary>
    /// Adds a new patient.
    /// </summary>
    /// <param name="patient">The patient to add.</param>
    /// <returns>The added patient.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the patient is null.</exception>
    public Patient Add(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");

        return _patientRepository.Add(patient);
    }

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="patient">The patient to update.</param>
    /// <returns>The updated patient.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the patient is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the patient to update is not found.</exception>
    public Patient Update(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient), "Patient cannot be null.");

        try
        {
            return _patientRepository.Update(patient);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Patient with ID {patient.Id} not found.");
        }
    }

    /// <summary>
    /// Deletes a patient by their ID.
    /// </summary>
    /// <param name="id">The ID of the patient to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the patient with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        try
        {
            _patientRepository.Delete(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Patient with ID {id} not found.");
        }
    }
}