using System;

namespace PharmacyModels;

public class Patient : Person
{
    public Patient(DateTime dob, int id, string name, string contactNumber, string email, int age, string address,
        string insuranceProvider, string medicalHistory) : base(dob, id, name, contactNumber, email, age, address)
    {
        InsuranceProvider = insuranceProvider;
        MedicalHistory = medicalHistory;
    }

    public string InsuranceProvider { get; set; }
    public string MedicalHistory { get; set; }

    /// <summary>
    ///  Loyalty score based on previous purchase histories ( will be 10% of purchase )
    /// </summary>
    public double LoyaltyScore { get; set; } = 0;

    public override string ToString()
    {
        // todo to move this to base.
        return base.ToString()
               + $"Patient {Id} Details:\n"
               + $"\tPatient Name\t:\t{Name}\n"
               + $"\tPatient DOB\t:\t{DateOfBirth}\n"
               + $"\tPatient Age\t:\t{Age}\n"
               + $"\tPatient Loyalty Score\t:\t{LoyaltyScore}\n"
               + $"\tPatient InsuranceProvider\t:\t{InsuranceProvider}\n";
    }
}