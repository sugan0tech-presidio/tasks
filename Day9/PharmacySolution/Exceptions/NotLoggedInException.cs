namespace PharmacyManagement.Exceptions;

public class NotLoggedInException : Exception
{
    public NotLoggedInException()
    {
    }

    public NotLoggedInException(string? message) : base(message)
    {
    }
}