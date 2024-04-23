namespace RequestTrackerApplication.Exceptions;

public class InvalidDepartmentNameException : Exception
{
    public InvalidDepartmentNameException()
    {
    }

    public InvalidDepartmentNameException(string? message) : base(message)
    {
    }
}