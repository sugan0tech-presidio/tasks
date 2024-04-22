using System;

namespace PharmacyModels;

public class Staff: Person
{
    // todo roles for staff
    // public enum StaffRole
    // {
    //     Administrator,
    //     Pharmacist,
    //     Technician,
    //     Manager,
    //     SalesRepresentative
    // }
    
    public string Role { set; get; }
    public string Password { set; get; }
    public Staff(DateTime dob, string name, string contactNumber, string email, int age, string address) : base(dob, name, contactNumber, email, age, address)
    {
    }

    public Staff(DateTime dob, int id, string name, string contactNumber, string email, int age, string address) : base(dob, id, name, contactNumber, email, age, address)
    {
    }
}