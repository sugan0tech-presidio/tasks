using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("Requests")]
public class Request : BaseEntity
{
    public string RequestMessage { get; set; }
    public DateTime RequestDate { get; set; } = System.DateTime.Now;
    public DateTime? ClosedDate { get; set; } = null;
    public string RequestStatus { get; set; }
    [ForeignKey("RaisedPerson")] public int RequestRaisedById { get; set; }
    public Person RaisedBy { get; set; }

    [ForeignKey("RequestClosedEmployee")] public int RequestClosedBy { get; set; }

    public Employee RequestClosedByEmployee { get; set; }
    public ICollection<RequestSolution> RequestSolutions { get; set; }
}