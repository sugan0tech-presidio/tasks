namespace RequestTrackerModelLibrary;

public class Employee
{
    private DateTime _dob;

    public Employee()
    {
        Id = 0;
        Name = string.Empty;
        DateOfBirth = new DateTime();
    }

    public Employee(int id, string name, DateTime dateOfBirth)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public int Age { get; private set; }

    /// <summary>
    ///     directly updates age with the given Date of Birth.
    /// </summary>
    public DateTime DateOfBirth
    {
        get => _dob;
        set
        {
            _dob = value;
            Age = (DateTime.Today - _dob).Days / 365;
        }
    }

    /// <summary>
    ///     Gets input from user and updates directly.
    /// </summary>
    public virtual void BuildEmployeeFromConsole()
    {
        Console.Write("Please enter the Name\t:");
        Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Please enter the Date of birth\t:");
        DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        while (Age < 18)
        {
            Console.WriteLine("employee must be above 17");
            Console.Write("Please enter the Date of birth\t:");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }
    }

    public virtual void PrintEmployeeDetails()
    {
        Console.Write($"Employee {Id} Details:\n");
        Console.WriteLine($"\tEmployee type\t:\t{GetType()}\n"); // Get's type for current instance either parent or the child
        Console.Write($"\tEmployee Name\t:\t{Name}\n");
        Console.Write($"\tEmployee DOB\t:\t{DateOfBirth}\n");
        Console.Write($"\tEmployee Age\t:\t{Age}\n");
    }
    
    public override string ToString()
    {
        return $"Employee {Id} Details:\n"
               +$"\tEmployee type\t:\t{GetType()}\n"
               +$"\tEmployee Name\t:\t{Name}\n"
               +$"\tEmployee DOB\t:\t{DateOfBirth}\n"
               +$"\tEmployee Age\t:\t{Age}\n";
    }

}