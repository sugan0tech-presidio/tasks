using PharmacyManagement.Exceptions;
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
        _drugRepository = drugRepository ??
                          throw new ArgumentNullException(nameof(drugRepository), "Drug repository cannot be null.");
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

    /// <summary>
    ///  checks the availablity of the drug
    /// </summary>
    /// <param name="drug"></param>
    /// <param name="quantity"></param>
    /// <exception cref="OutOfStockException">If There is not drugs available</exception>
    /// <exception cref="NotEnoughDrugException">If there is insufficient Drugs</exception>
    public void IsDrugAvailable(Drug drug, int quantity)
    {
        Console.WriteLine(drug.Name);
        Console.WriteLine(drug.Count);
        if (drug.Count <= 0)
        {
            Console.WriteLine("\nDrug is out of stock!!!");
            throw new OutOfStockException($"Drug :{drug.Name} is out of Stock!!!");
        }

        if (drug.Count >= quantity) return;

        Console.WriteLine("\nDrug is not enough!!!");
        throw new NotEnoughDrugException(
            $"Drug : {drug.Name} is not Enough!!!\nAvailable : {drug.Count} Required : {quantity}");
    }

    /// <summary>
    ///  checks if the Drugs Expired, has any warnings..
    /// </summary>
    /// <param name="drug"></param>
    /// <exception cref="ExpiredDrugException">If the drug expired.</exception>
    public void ValidateDrug(Drug drug)
    {
        var minExpiryDate = drug.QuantitiesWithDates.Keys.Min();
        var currentDate = DateTime.Today;
        if (drug.PrescriptionNeeded)
        {
            Console.WriteLine("Note this drugs needs doctors approval!!!");
        }

        if (currentDate >= minExpiryDate)
        {
            Console.WriteLine("Few drug are expired!! Update in Store!!");
            throw new ExpiredDrugException($"Few of the drugs {drug.Name}Expired");
        }

        if (minExpiryDate < currentDate.AddDays(30))
        {
            Console.WriteLine("Drug gonna Expire soon!!!");
        }
    }
}