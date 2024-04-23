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

    public override string ToString()
    {
        return base.ToString()
               + $"\tEmployee Wage Per Day\t:\t{WagesPerDay}";
    }
}