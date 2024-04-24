namespace ECommerceApp.Exceptions;

public class CartNotFoundException: Exception
{
    public CartNotFoundException()
    {
    }

    public CartNotFoundException(string? message) : base(message)
    {
    }
}