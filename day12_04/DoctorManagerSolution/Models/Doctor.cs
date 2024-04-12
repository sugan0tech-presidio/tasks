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
    public Doctor(int id, string name, int age, int experience, HashSet<string> qualification, HashSet<string> specialization) : this(id)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Age = age;
        Experience = experience;
        Qualifications = qualification ?? throw new ArgumentNullException(nameof(qualification));
        Specializations = specialization ?? throw new ArgumentNullException(nameof(specialization));
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }
    public HashSet<string> Qualifications { get;} = new();
    public HashSet<string> Specializations { get; } = new();
    
    /// <summary>
    /// Method to add specialization
    /// </summary>
    /// <param name="specialization"></param>
    public void AddSpecialization(string specialization)
    {
        Specializations.Add(specialization);
    }
    
    /// <summary>
    /// Method to add qualification
    /// </summary>
    /// <param name="qualification"></param>
    public void AddQualification(string qualification)
    {
        Qualifications.Add(qualification);
    }
}