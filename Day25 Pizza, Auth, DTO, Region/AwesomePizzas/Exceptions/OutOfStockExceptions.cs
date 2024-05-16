namespace AwesomePizzas.Exceptions;

public class OutOfStockExceptions: Exception
{
    public OutOfStockExceptions()
    {
    }

    public OutOfStockExceptions(string? message) : base(message)
    {
    }
}