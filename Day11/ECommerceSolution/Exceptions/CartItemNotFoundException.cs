namespace ECommerceApp.Exceptions;

public class CartItemNotFoundException : Exception
{
    public CartItemNotFoundException()
    {
    }

    public CartItemNotFoundException(string? message) : base(message)
    {
    }
}