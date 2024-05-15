namespace AwesomeRequestTrackerApi.Exeptions;

public class NoSuchEmployeeException : Exception
{
    public NoSuchEmployeeException()
    {
    }

    public NoSuchEmployeeException(string? message) : base(message)
    {
    }
}