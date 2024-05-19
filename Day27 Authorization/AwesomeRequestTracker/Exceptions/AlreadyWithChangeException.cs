namespace AwesomeRequestTracker.Exceptions;

public class AlreadyWithChangeException: Exception
{
    public AlreadyWithChangeException()
    {
    }

    public AlreadyWithChangeException(string? message) : base(message)
    {
    }
}