namespace RequestTrackerModelLibrary;

public class PermanentEmployee : Employee
{
    public PermanentEmployee()
    {
        Salary = 0.0;
    }

    public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
    {
        Salary = salary;
    }

    public double Salary { get; set; }

    /// <summary>
    ///     For Contract Employees it will be wages not salary.
    /// </summary>
    public override void BuildEmployeeFromConsole()
    {
        base.BuildEmployeeFromConsole();
        Console.Write("Please enter the salary\t:");
        Salary = Convert.ToDouble(Console.ReadLine());
    }

    public override void PrintEmployeeDetails()
    {
        base.PrintEmployeeDetails();
        Console.Write($"\tEmployee Salary\t:\t{Salary}\n");
    }
}