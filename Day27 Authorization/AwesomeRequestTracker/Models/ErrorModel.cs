namespace AwesomeRequestTracker.Models;

public class ErrorModel
{
    public ErrorModel(int status, string message)
    {
        Status = status;
        Message = message;
    }

    public int Status { get; set; }
    public string Message { get; set; }
}