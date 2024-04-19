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

    public override string ToString()
    {
        return base.ToString()
            +$"\tEmployee Salary\t:\t{Salary}";
    }
}