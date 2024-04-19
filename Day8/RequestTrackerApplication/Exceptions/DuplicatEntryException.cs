namespace RequestTrackerApplication.Exceptions;

public class DuplicatEntryException : Exception
{
    public DuplicatEntryException()
    {
    }

    public DuplicatEntryException(string? message) : base(message)
    {
    }
}