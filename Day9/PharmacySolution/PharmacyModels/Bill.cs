using System;
using System.Collections.Generic;

namespace PharmacyModels;

public class Bill : BaseEntity
{
    public List<Prescription> Prescriptions { get; } = new();
    public DateTime time;
    public double Total { get; set; }
    public Patient user;


    public override string ToString()
    {
        var prescriptions = "\nDrug\t\t\tQuan X Price";
        var score = user.LoyaltyScore;
        foreach (var prescription in Prescriptions)
        {
            prescriptions += "\n" + prescription.Drug.Name + "\t:\t\t" + prescription.Quantity + "x" +
                             prescription.Drug.price;
        }

        var tmp = $"\nBill Id\t: {Id}\t Date:{time}" +
                  $"\nUser\t:\t\t{user.Name}" +
                  prescriptions +
                  $"\nTotal\t:\t\t{Total:F2}";

        if (score > 0)
        {
            return tmp +
                   $"\nLoyality\t:\t- ${score:F2}" +
                   $"\nWithReduction\t:\t ${Total - score:F2}\n";
        }

        return tmp;
    }
}