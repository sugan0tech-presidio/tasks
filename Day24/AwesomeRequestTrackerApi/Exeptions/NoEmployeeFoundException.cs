namespace AwesomeRequestTrackerApi.Exeptions;

public class NoEmployeeFoundException : Exception
{
    public NoEmployeeFoundException()
    {
    }

    public NoEmployeeFoundException(string? message) : base(message)
    {
    }
}