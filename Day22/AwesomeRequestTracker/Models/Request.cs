namespace AwesomeRequestTracker.Models;

public class Request: BaseEntity
{
    public Person RequestRaisedBy { get; set; }

}