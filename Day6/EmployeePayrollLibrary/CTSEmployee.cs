namespace EmployeePayrollLibrary;

public class CTSEmployee : Employee
{
    public CTSEmployee(int empId, string name, int deptId, string desg, double basicSalary) : base(empId, name, deptId,
        desg, basicSalary)
    {
    }

    public override double EmployeePF(double basicSalary)
    {
        return basicSalary * 0.12;
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

    public override double GratuityAmount(float serviceCompleted, double basicSalary)
    {
        if (serviceCompleted > 5)
        {
            if (serviceCompleted > 10)
                return basicSalary * 2;
            if (serviceCompleted > 20)
                return basicSalary * 3;
            return basicSalary;
        }

        return 0;
    }
}