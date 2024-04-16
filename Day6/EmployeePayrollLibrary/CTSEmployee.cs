namespace EmployeePayrollLibrary;

public class CTSEmployee : Employee
{
    public CTSEmployee(int empId, string name, int deptId, string desg, double basicSalary) : base(empId, name, deptId,
        desg, basicSalary)
    {
    }

    public override double EmployeePf()
    {
        return BasicSalary * 0.12;
    }

    public double EmployerPFContribution(double basicSalary)
    {
        return basicSalary * 0.12; // Employer contribution (PF)
    }

    public override string LeaveDetails()
    {
        return @"Leave Details for CTS:
               1 day of Casual Leave per month
               12 days of Sick Leave per year
               10 days of Privilege Leave per year";
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