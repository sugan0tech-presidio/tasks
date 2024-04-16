namespace RequestTrackerModelLibrary;

public class ContractEmployee : Employee
{
    public ContractEmployee()
    {
        WagesPerDay = 0;
    }

    public ContractEmployee(int id, string name, DateTime dateOfBirth, double salary, double wagesPerDay) : base(id,
        name, dateOfBirth)
    {
        WagesPerDay = wagesPerDay;
    }

    public double WagesPerDay { get; set; }

    /// <summary>
    ///     For Contract Employees it will be wages not salary.
    /// </summary>
    public override void BuildEmployeeFromConsole()
    {
        base.BuildEmployeeFromConsole();
        Console.Write("Please enter the wages per day\t:");
        WagesPerDay = Convert.ToDouble(Console.ReadLine());
    }

    /// <summary>
    ///     Displaying additional wages along with Employee details.
    /// </summary>
    public override void PrintEmployeeDetails()
    {
        base.PrintEmployeeDetails();
        Console.Write($"\tEmployee Wage Per Day\t:\t{WagesPerDay}\n");
    }
}