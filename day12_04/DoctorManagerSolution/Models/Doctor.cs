namespace DoctorManager;

public class Doctor
{

    public Doctor(int id)
    {
        Id = id;
    }

    /// <summary>
    /// Populate doctor entity with the given fields
    /// </summary>
    /// <param name="id">Id for the doctor</param>
    /// <param name="name">Doctor's name</param>
    /// <param name="age">Age as in Int</param>
    /// <param name="experience">Experience as in Int</param>
    /// <param name="qualification">Qatlification stream</param>
    /// <param name="specialization">Specialization</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Doctor(int id, string name, int age, int experience, List<string> qualification, List<string> specialization) : this(id)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
        Experience = experience;
        Qualification = qualification ?? throw new ArgumentNullException(nameof(qualification));
        Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
    }

    private int Id { get; set; }
    public string Name { get; set; }
    
    private int _age;
    public int Age 
    { 
        get => _age;
        set 
        {
            if (value < 17 || value > 65) // allowed age limits
            {
                throw new ArgumentException("Doctor's Age must be between 17 and 65 until retirement.");
            }
            _age = value;
        }
    }

    private int _experience;
    public int Experience
    {
        get => _experience;
        set
        {
            if (value < 0 || value > 48)
            {
                throw new ArgumentException("Experience cannot be negative nor greater than 48 as retirement occur.");
            }
            _experience = value;
        }
    }    
    public List<string> Qualification { get;} = new();
    public List<string> Specialization { get; } = new();
    
    /// <summary>
    /// Method to add specialization
    /// </summary>
    /// <param name="specialization"></param>
    public void AddSpecialization(string specialization)
    {
        if (Specializations.Contains(specialization))
        {
            if (!Specialization.Contains(specialization))
                Specialization.Add(specialization);
        }
        else
            throw new Exception($"{specialization} is not valid.");
    }
    
    /// <summary>
    /// Method to add qualification
    /// </summary>
    /// <param name="qualification"></param>
    public void AddQualification(string qualification)
    {
        if (Qualifications.Contains(qualification))
        {
            if (!Qualification.Contains(qualification))
                Qualification.Add(qualification);
        }
        else
            throw new Exception($"{qualification} is not a valid.");
    }
    
    public static readonly string[] Specializations = {
        "General Medicine",
        "Pediatrics",
        "Cardiology",
        "Orthopedics",
        "Neurology",
        "Dermatology",
        "Ophthalmology",
    };

    public static readonly string[] Qualifications = {
        "MBBS",
        "MD",
        "MS",
        "DM",
    };

    public void Display()
    {
        Console.WriteLine($"Doctor {Id} ------------");
        Console.WriteLine($"\tName\t\t:\t{Name}");
        Console.WriteLine($"\tAge\t\t:\t{Age} yrs");
        Console.WriteLine($"\tExperience\t:\t{Experience} yrs");
        var qualifications = string.Join(", ", Qualification);
        Console.WriteLine($"\tQualification\t:\t{qualifications}");
        var specializations = string.Join(", ", Specialization);
        Console.WriteLine($"\tSpecialization\t:\t{specializations}");
    }
}