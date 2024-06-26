﻿using System;

namespace PharmacyModels;

public class Staff : Person
{

    public Roles Role { set; get; }
    public string Password { set; get; }

    public Staff(DateTime dob, string name, string contactNumber, string email, int age, string address) : base(dob,
        name, contactNumber, email, age, address)
    {
    }

    public Staff(DateTime dob, int id, string name, string contactNumber, string email, int age, string address) : base(
        dob, id, name, contactNumber, email, age, address)
    {
    }

    public bool HasAuthority(string role)
    {
        return Role.Equals(role);
    }

    public override bool Equals(object? obj)
    {
        var staff = obj as Staff;
        return base.Equals(staff ?? throw new InvalidOperationException($"{GetType()} is not for Staff")) &&
               staff.Role.Equals(Role);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\n\tRole: {Role}";
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}