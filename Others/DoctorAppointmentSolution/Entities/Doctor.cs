namespace DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

public class Doctor : Person
{

    public Doctor(DateTime dob, string name, string contactNumber, string email, int age, string address, int experience) : base(dob, name, contactNumber, email, age, address)
    {
        _experience = experience;
    }
    public Doctor(DateTime dob, int id, string name, string contactNumber, string email, int age, string address,
        int experience) : base(dob, id, name, contactNumber, email, age, address)
    {
        _experience = experience;
    }

    private int _experience;

    public List<string> Qualification { get; } = new();
    public List<string> Specialization { get; } = new();

    public int Experience
    {
        get => _experience;
        set
        {
            if (value < 0 || value > 48)
                throw new ArgumentException("Experience cannot be negative nor greater than 48 as retirement occur.");
            _experience = value;
        }
    }

    /// <summary>
    ///     Method to add specialization
    /// </summary>
    /// <param name="specialization"></param>
    public void AddSpecialization(string specialization)
    {
        if (!Specialization.Contains(specialization))
            Specialization.Add(specialization);
    }

    /// <summary>
    ///     Method to add qualification
    /// </summary>
    /// <param name="qualification"></param>
    public void AddQualification(string qualification)
    {
        if (!Qualification.Contains(qualification))
            Qualification.Add(qualification);
    }

    public override string ToString()
    {
        var qualifications = string.Join(", ", Qualification);
        var specializations = string.Join(", ", Specialization);

        // todo to move this to base.
        return base.ToString()
               + $"Doctor {Id} Details:\n"
               + $"\tDoctor Name\t:\t{Name}\n"
               + $"\tDoctor DOB\t:\t{DateOfBirth}\n"
               + $"\tDoctor Age\t:\t{Age}\n"
               + $"\tDoctor Experience\t:\t{Experience}\n"
               + $"\tDoctor Specialization\t:\t{specializations}\n"
               + $"\tDoctor Qualification\t:\t{qualifications}\n";
    }

    public bool Equals(Doctor doctor)
    {
        return Name.Equals(doctor.Name) && DateOfBirth.Equals(doctor.DateOfBirth) &&
               ContactNumber.Equals(doctor.ContactNumber);
    }
}