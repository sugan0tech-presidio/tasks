namespace AwesomeRequestTracker.DTO;

public record RequestDTO()
{
    public string RequestMessage { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public DateTime? ClosedDate { get; set; }
    public string RequestStatus { get; set; } = "Created";
    public int RequestRaisedById { get; set; }
    public int? RequestClosedBy { get; set; }
}