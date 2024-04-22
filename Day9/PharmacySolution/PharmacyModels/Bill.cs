using System.Collections.Generic;

namespace PharmacyModels;

public class Bill: BaseEntity
{

    public List<Prescription> Prescriptions { get; } = new();
    public double Total { get; set;}
    public string user;
    

    public override string ToString()
    {
        var prescriptions = "\nDrug\t\t\tQuan X Price";
        foreach (var prescription in Prescriptions)
        {
            prescriptions += "\n" + prescription.Drug.Name + "\t\t" + prescription.Quantity + "x" + prescription.Drug.price;
        }

        return $"\nBill Id\t: {Id}" +
               $"\nUser\t:{user}" +
               prescriptions +
               $"\nTotal\t:\t\t${Total}\n";
    }
}