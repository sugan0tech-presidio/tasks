namespace PharmacyManagement.Exceptions;

public class UserNotAuthorisedException : Exception
{
    public UserNotAuthorisedException()
    {
    }

    public UserNotAuthorisedException(string? message) : base(message)
    {
    }
}