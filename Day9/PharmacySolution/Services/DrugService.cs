using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class DrugService
{
    private readonly DrugRepo _drugRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DrugService"/> class.
    /// </summary>
    /// <param name="drugRepository">The drug repository.</param>
    public DrugService(DrugRepo drugRepository)
    {
        _drugRepository = drugRepository ?? throw new ArgumentNullException(nameof(drugRepository), "Drug repository cannot be null.");
    }

    /// <summary>
    /// Retrieves a drug by its ID.
    /// </summary>
    /// <param name="id">The ID of the drug to retrieve.</param>
    /// <returns>The drug with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the drug with the specified ID is not found.</exception>
    public Drug GetById(int id)
    {
        try
        {
            return _drugRepository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Drug with ID {id} not found.");
        }
    }

    /// <summary>
    /// Retrieves all drugs.
    /// </summary>
    /// <returns>A list of all drugs.</returns>
    public List<Drug> GetAll()
    {
        return _drugRepository.GetAll();
    }

    /// <summary>
    /// Adds a new drug.
    /// </summary>
    /// <param name="drug">The drug to add.</param>
    /// <returns>The added drug.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the drug is null.</exception>
    public Drug Add(Drug drug)
    {
        if (drug == null)
            throw new ArgumentNullException(nameof(drug), "Drug cannot be null.");

        return _drugRepository.Add(drug);
    }

    /// <summary>
    /// Updates an existing drug.
    /// </summary>
    /// <param name="drug">The drug to update.</param>
    /// <returns>The updated drug.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the drug is null.</exception>
    /// <exception cref="KeyNotFoundException">Thrown if the drug to update is not found.</exception>
    public Drug Update(Drug drug)
    {
        if (drug == null)
            throw new ArgumentNullException(nameof(drug), "Drug cannot be null.");

        try
        {
            return _drugRepository.Update(drug);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Drug with ID {drug.Id} not found.");
        }
    }

    /// <summary>
    /// Deletes a drug by its ID.
    /// </summary>
    /// <param name="id">The ID of the drug to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the drug with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        try
        {
            _drugRepository.Delete(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Drug with ID {id} not found.");
        }
    }
}