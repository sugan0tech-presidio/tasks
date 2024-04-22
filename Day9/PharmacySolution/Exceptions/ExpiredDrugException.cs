namespace PharmacyManagement.Exceptions;

public class ExpiredDrugException : Exception
{
    public ExpiredDrugException()
    {
    }

    public ExpiredDrugException(string? message) : base(message)
    {
    }
}