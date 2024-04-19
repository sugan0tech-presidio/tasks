namespace RequestTrackerApplication.Exceptions;

public class DepartmentInUseException : Exception
{
    public DepartmentInUseException()
    {
    }

    public DepartmentInUseException(string? message) : base(message)
    {
    }
}