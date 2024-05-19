namespace AwesomeRequestTracker.DTO;

public record RequestDTO
{
    public RequestDTO(int id, string requestMessage, DateTime requestDate, DateTime? closedDate, string requestStatus, int requestRaisedById, int? requestClosedBy)
    {
        Id = id;
        RequestMessage = requestMessage;
        RequestDate = requestDate;
        ClosedDate = closedDate;
        RequestStatus = requestStatus;
        RequestRaisedById = requestRaisedById;
        RequestClosedBy = requestClosedBy;
    }

    public int? Id { get; }
    public string RequestMessage { get; }
    public DateTime RequestDate { get;  } = DateTime.Now;
    public DateTime? ClosedDate { get;  }
    public string RequestStatus { get; }= "Created";
    public int RequestRaisedById { get; }
    public int? RequestClosedBy { get; }
}