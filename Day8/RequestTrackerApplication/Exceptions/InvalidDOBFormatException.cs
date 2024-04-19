namespace RequestTrackerApplication.Exceptions;

public class InvalidDOBFormatException: Exception
{
    public InvalidDOBFormatException()
    {
    }

    public InvalidDOBFormatException(string? message) : base(message)
    {
    }
}