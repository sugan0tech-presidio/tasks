namespace AwesomeRequestTracker.DTO;

public record RequestDTO()
{
    string RequestMessage;
    DateTime RequestDate = DateTime.Now;
    DateTime? ClosedDate;
    string RequestStatus = "Created";
    int RequestRaisedById;
    int? RequestClosedBy;
}