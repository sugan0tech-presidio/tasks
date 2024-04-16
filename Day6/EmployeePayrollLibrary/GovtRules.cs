namespace EmployeePayrollLibrary;

public interface GovtRules
{
    /// <summary>
    ///     Employee Pf amount to be deducted from his base salary.
    /// </summary>
    /// <returns></returns>
    public double EmployeePf();

    /// <summary>
    ///     Info String about leaves in particular company.
    /// </summary>
    /// <returns></returns>
    public string LeaveDetails();

    /// <summary>
    ///     GratuityAmount based on service years
    /// </summary>
    /// <param name="serviceCompleted"></param>
    /// <returns></returns>
    public double GratuityAmount(float serviceCompleted);
}