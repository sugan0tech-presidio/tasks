using System.Collections.Generic;

namespace PharmacyModels;

public class Bill: BaseEntity
{

    public List<Prescription> Prescriptions { get; } = new();
    public double Total { get; set;}
    public string user;
    

    public override string ToString()
    {
        return $"\nBill Id\t: {Id}" +
               $"\n\tUser\t:{user}" +
               $"\n\tTotal\t: ${Total}\n";
    }
}