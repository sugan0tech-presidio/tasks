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
            
            string drugA = val.Medications.Keys.First().Name;
            string drugB = prescription.Medications.Keys.First().Name;
            if(Dangerouscombinations.IsCombinationDangerous(drugA, drugB))
            {
                throw new ($"Fatal drug combination: {Dangerouscombinations.GetRisk(drugA, drugB)}");
            }
        }
        
        bill.Prescriptions.Add(prescription);
        _billRepo.Update(bill);
    }
}