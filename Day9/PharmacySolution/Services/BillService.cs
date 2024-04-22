using PharmacyManagement.Repositories;
using PharmacyModels;

namespace PharmacyManagement.Services;

public class BillService
{
    private BillRepo _billRepo;

    public BillService(BillRepo billRepo)
    {
        _billRepo = billRepo;
    }

    public void Add(Bill bill)
    {
        _billRepo.Add(bill);
    }

    public void AddPrescription(Bill bill, Prescription prescription)
    {
        var isDangerousCombination = false;
        foreach (var val in bill.Prescriptions)
        {
            
            string drugA = val.Drug.Name;
            Console.WriteLine(drugA);
            Console.WriteLine(prescription);
            string drugB = prescription.Drug.Name;
            Console.WriteLine(drugB);
            if(Dangerouscombinations.IsCombinationDangerous(drugA, drugB))
            {
                throw new ($"Fatal drug combination: {Dangerouscombinations.GetRisk(drugA, drugB)}");
            }
        }
        
        bill.Prescriptions.Add(prescription);
        var drug = prescription.Drug;
        bill.Total += drug.price * prescription.Quantity;
        try
        {
            _billRepo.Update(bill);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            _billRepo.Add(bill);
        }
    }
}