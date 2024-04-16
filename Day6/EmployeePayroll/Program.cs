using EmployeePayrollLibrary;

namespace EmployeePayroll;

public class Program
{
    private const int MaxDepartments = 3;
    private const int MaxEmployees = 2;

    private static readonly Department[] Departments = new Department[MaxDepartments];
    private static readonly Employee[] Employees = new Employee[MaxEmployees];

    public static void Main(string[] args)
    {
        Departments[0] = new Department(1, "IT");
        Departments[1] = new Department(2, "development");
        Departments[2] = new Department(3, "Cloud");
        var ctsEmployee = new CTSEmployee(101, "sugan", 1, "Senior", 20000);
        var accentureEmployee = new AccentureEmployee(102, "tech", 3, "SD2", 10000);

        Employees[0] = ctsEmployee;
        Employees[1] = accentureEmployee;

        foreach (var employee in Employees)
            DispalyGovtStatInfos(employee);

    }

    static void DispalyGovtStatInfos(GovtRules govtRules)
    {
        Console.WriteLine(govtRules.EmployeePf());
        Console.WriteLine(govtRules.GratuityAmount(10));
        Console.WriteLine(govtRules.LeaveDetails());
    }
}