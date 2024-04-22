using System.Collections.Generic;

namespace PharmacyModels;

public class Bill : BaseEntity
{
    public List<Prescription> Prescriptions { get; } = new();
    public double Total { get; set; }
    public Patient user;


    public override string ToString()
    {
        var prescriptions = "\nDrug\t\t\tQuan X Price";
        var score = user.LoyaltyScore;
        foreach (var prescription in Prescriptions)
        {
            prescriptions += "\n" + prescription.Drug.Name + "\t\t" + prescription.Quantity + "x" +
                             prescription.Drug.price;
        }

        var tmp = $"\nBill Id\t: {Id}" +
                  $"\nUser\t:{user}" +
                  prescriptions +
                  $"\nTotal\t:\t\t{Total}";

        if (score > 0)
        {
            return tmp +
                   $"\nLoyality\t:\t- ${score}" +
                   $"\nWithReduction\t:\t ${Total - score}\n";
        }

        return tmp;
    }
}