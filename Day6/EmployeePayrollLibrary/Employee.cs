namespace EmployeePayrollLibrary;

public abstract class Employee: GovtRules
{
    public Employee()
    {
        EmpId = 0;
        Name = string.Empty;
    }

    public Employee(int empId, string name)
    {
        EmpId = empId;
        Name = name;
    }

    public int EmpId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public double BasicSalary { get; set; }

    /// <summary>
    ///     Gets input from user and updates directly.
    /// </summary>
    public virtual void BuildEmployeeFromConsole()
    {
        Console.Write("Please enter the Name\t:");
        Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Please enter the Department Id\t:");
    }
    
    public override string ToString()
    {
        return $"Employee {EmpId} Details:\n"
               +$"\tEmployee type\t:\t{GetType()}\n"
               +$"\tEmployee Name\t:\t{Name}\n"
               +$"\tDepartment\t:\t{DepartmentId}\n"
               +$"\tEmployee Age\t:\t{BasicSalary}\n";
    }

    public abstract double EmployeePF(double basicSalary);
    public abstract string LeaveDetails();
    public abstract double gratuityAmount(float serviceCompleted, double basicSalary);
}
