using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class PrescriptionService
{
    private readonly PrescriptionRepo _prescriptionRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PrescriptionService"/> class.
    /// </summary>
    /// <param name="prescriptionRepository">The prescription repository.</param>
    public PrescriptionService(PrescriptionRepo prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository ??
                                  throw new ArgumentNullException(nameof(prescriptionRepository),
                                      "Prescription repository cannot be null.");
    }

    /// <summary>
    /// Retrieves a prescription by its ID.
    /// </summary>
    /// <param name="id">The ID of the prescription to retrieve.</param>
    /// <returns>The prescription with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the prescription with the specified ID is not found.</exception>
    public Prescription GetById(int id)
    {
        try
        {
            return _prescriptionRepository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Prescription with ID {id} not found.");
        }
    }

    /// <summary>
    /// Retrieves all prescriptions.
    /// </summary>
    /// <returns>A list of all prescriptions.</returns>
    public List<Prescription> GetAll()
    {
        return _prescriptionRepository.GetAll();
    }

    /// <summary>
    /// Adds a new prescription.
    /// </summary>
    /// <param name="prescription">The prescription to add.</param>
    /// <returns>The added prescription.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the prescription is null.</exception>
    public Prescription Add(Prescription prescription)
    {
        if (prescription == null)
            throw new ArgumentNullException(nameof(prescription), "Prescription cannot be null.");

        prescription.IssueDate = new DateTime();

        return _prescriptionRepository.Add(prescription);
    }

    /// <summary>
    /// Updates an existing prescription.
    /// </summary>
    /// <param name="prescription">The prescription to update.</param>
    /// <returns>The updated prescription.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the prescription is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the prescription to update is not found.</exception>
    public Prescription Update(Prescription prescription)
    {
        if (prescription == null)
            throw new ArgumentNullException(nameof(prescription), "Prescription cannot be null.");

        try
        {
            return _prescriptionRepository.Update(prescription);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Prescription with ID {prescription.Id} not found.");
        }
    }

    /// <summary>
    /// Deletes a prescription by its ID.
    /// </summary>
    /// <param name="id">The ID of the prescription to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the prescription with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        try
        {
            _prescriptionRepository.Delete(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Prescription with ID {id} not found.");
        }
    }
}