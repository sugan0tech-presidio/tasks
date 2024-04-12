namespace ModelTest.Models;

public class Employee
{

    /// <summary>
    /// Default constructor
    /// </summary>
    public Employee() // default assignment 
    {
        Id = 0;
        Name = string.Empty;
        Email = string.Empty;
        DateOfBirth = DateTime.MinValue;
        Salary = 0;
    }

    /// <summary>
    /// With ID
    /// </summary>
    /// <param name="id"></param>
    public Employee(int id)
    {
        Id = id;
    }
    
    /// <summary>
    /// All Paramaters constructor
    /// </summary>
    /// <param name="id">Employee Id as int</param>
    /// <param name="salary">Employee Salary as double</param>
    /// <param name="name">Employee name</param>
    /// <param name="dateOfBirth">DOB of Employee</param>
    /// <param name="email">Email</param>
    public Employee(int id, double salary,string name, DateTime dateOfBirth, string email) :this(id) // constructor chaining
    {
        _salary = salary;
        Name = name;
        DateOfBirth = dateOfBirth;
        Email = email;
    }
    public int Id { get; private set; }
    public string Name { get; set; }

    private double _salary;

    public double Salary
    {
        get => _salary - _salary * 10 / 100;
        set => _salary = value;
    }
    
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

    /// <summary>
    /// displays hours that employee worked
    /// </summary>
    /// <param name="hours">Int of hours that employee worked</param>
    public void Work(int hours)
    {
        Console.WriteLine($"Working... for \t: {hours}");
    }

    /// <summary>
    /// Prints all the details of the employee
    /// </summary>
    public void PrintEmployeeDetails()
    {
        Console.WriteLine($"Employee Id\t:\t{Id}");
        Console.WriteLine($"Employee Name\t:\t{Name}");
        Console.WriteLine($"Employee DOB\t:\t{DateOfBirth}");
        Console.WriteLine($"Employee Salary\t:\t{Salary}");
        Console.WriteLine($"Employee Email\t:\t{Email}");
    }
}