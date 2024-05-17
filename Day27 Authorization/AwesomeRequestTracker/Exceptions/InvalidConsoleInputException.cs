namespace AwesomeRequestTracker.Exceptions;

public class InvalidConsoleInputException : Exception
{
    public InvalidConsoleInputException()
    {
    }

    public InvalidConsoleInputException(string? message) : base(message)
    {
    }
}