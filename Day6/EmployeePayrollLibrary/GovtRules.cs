namespace EmployeePayrollLibrary;

public interface GovtRules
{
    public double EmployeePF(double basicSalary);
    public string LeaveDetails();
    public double gratuityAmount(float serviceCompleted, double basicSalary);
}