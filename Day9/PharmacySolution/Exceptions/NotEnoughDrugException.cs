namespace PharmacyManagement.Exceptions;

public class NotEnoughDrugException : Exception
{
    public NotEnoughDrugException()
    {
    }

    public NotEnoughDrugException(string? message) : base(message)
    {
    }
}