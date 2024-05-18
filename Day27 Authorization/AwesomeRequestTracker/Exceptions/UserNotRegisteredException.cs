namespace AwesomeRequestTracker.Exceptions;

public class UserNotRegisteredException: Exception
{
    public UserNotRegisteredException()
    {
    }

    public UserNotRegisteredException(string? message) : base(message)
    {
    }
}