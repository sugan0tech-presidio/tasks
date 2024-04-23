using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class BillService
{
    private readonly BillRepo _billRepo;

    public BillService(BillRepo billRepo)
    {
        _billRepo = billRepo;
    }

    /// <summary>
    ///  To add  Bill
    /// </summary>
    /// <param name="bill"></param>
    public void Add(Bill bill)
    {
        _billRepo.Add(bill);
    }

    /// <summary>
    /// Retrieves all Bills.
    /// </summary>
    /// <returns>A list of Bills.</returns>
    public List<Bill> GetAll()
    {
        return _billRepo.GetAll();
    }

    /// <summary>
    ///  Gets bill by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException">Thrown if Bills with the specified ID is not found.</exception>
    public Bill GetById(int id)
    {
        return _billRepo.GetById(id);
    }

    /// <summary>
    ///  Adding prescription to the bill.
    ///  If bill not present, creates one.
    /// </summary>
    /// <param name="bill"></param>
    /// <param name="prescription"></param>
    /// <exception cref="Exception">If A dangerous drug combination detected.</exception>
    public void AddPrescription(Bill bill, Prescription prescription)
    {
        foreach (var val in bill.Prescriptions)
        {
            string drugA = val.Drug.Name;
            string drugB = prescription.Drug.Name;

            if (Dangerouscombinations.IsCombinationDangerous(drugA, drugB))
            {
                throw new($"Fatal drug combination: {Dangerouscombinations.GetRisk(drugA, drugB)}");
            }
        }

        bill.Prescriptions.Add(prescription);
        var drug = prescription.Drug;
        bill.Total += drug.price * prescription.Quantity;
        try
        {
            _billRepo.Update(bill);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Creating new bill!!");
            _billRepo.Add(bill);
        }
    }

    /// <summary>
    /// Deletes by given key
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        _billRepo.Delete(id);
    }
}