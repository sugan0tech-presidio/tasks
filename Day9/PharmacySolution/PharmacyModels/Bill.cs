using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyModels;

public class Bill: BaseEntity
{

    public List<Prescription> Prescriptions { get; } = new();
    public double Total { get; set;}
    public string user;
    

    public override string ToString()
    {
        return $"\nBill Id\t: {Id}" +
               $"\nTotal\t: {Total}" +
               $"\nUser\t:{user}";
    }
}