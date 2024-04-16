using EmployeePayrollLibrary;

namespace EmployeePayroll;

public class Program
{
    private const int MAX_DEPARTMENTS = 3;

    private static readonly Department[] departments = new Department[MAX_DEPARTMENTS];

    public static void Main(string[] args)
    {
        departments[0] = new Department(1, "IT");
        departments[1] = new Department(2, "development");
        departments[2] = new Department(3, "Cloud");
        Employee ctsEmployee = new CTSEmployee(101, "sugan", 1, "Senior", 20000);
        Employee accentureEmployee = new CTSEmployee(102, "tech", 3, "SD2", 10000);


        GovtRules govtRules = ctsEmployee;
        Console.WriteLine(govtRules.EmployeePF(ctsEmployee.BasicSalary));
        Console.WriteLine(govtRules.GratuityAmount(10, accentureEmployee.BasicSalary));
        Console.WriteLine(govtRules.LeaveDetails());
    }
}