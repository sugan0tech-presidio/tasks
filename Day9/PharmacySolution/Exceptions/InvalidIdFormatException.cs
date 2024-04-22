namespace PharmacyManagement.Exceptions;

public class InvalidIdFormatException : Exception
{
    public InvalidIdFormatException()
    {
    }

    public InvalidIdFormatException(string? message) : base(message)
    {
    }
}