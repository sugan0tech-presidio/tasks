namespace ECommerceApp.Exceptions;

public class TooMuchItemsException : Exception
{
    public TooMuchItemsException()
    {
    }

    public TooMuchItemsException(string? message) : base(message)
    {
    }
}