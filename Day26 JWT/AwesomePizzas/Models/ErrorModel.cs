namespace AwesomePizzas.Models;

public class ErrorModel
{
    public ErrorModel(int statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
}