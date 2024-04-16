namespace EmployeePayrollLibrary;

public class AccentureEmployee : Employee
{
    public AccentureEmployee(int empId, string name, int deptId, string desg, double basicSalary) : base(empId, name,
        deptId, desg, basicSalary)
    {
    }

    public override double EmployeePf()
    {
        return BasicSalary * 0.12;
    }

    /// <summary>
    ///     As part of employeer PF amount
    /// </summary>
    /// <returns></returns>
    public double EmployerPFContribution()
    {
        return BasicSalary * (0.0833 + 0.0367); // Employer contribution (PF + Pension Fund)
    }

    public override string LeaveDetails()
    {
        return @"Leave Details for Accenture:
               2 day of Casual Leave per month
               5 days of Sick Leave per year
               5 days of Privilege Leave per year";
    }

    public override double GratuityAmount(float serviceCompleted)
    {
        if (serviceCompleted > 5)
        {
            if (serviceCompleted > 10)
                return BasicSalary * 2;
            if (serviceCompleted > 20)
                return BasicSalary * 3;
            return BasicSalary;
        }

        return 0;
    }
}