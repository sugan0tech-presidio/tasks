﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("Requests")]
public class Request : BaseEntity
{
    public string RequestMessage { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.Now;
    public DateTime? ClosedDate { get; set; }
    public string RequestStatus { get; set; } = "Created";
    [ForeignKey("RaisedPerson")] public int RequestRaisedById { get; set; }
    public Person RaisedBy { get; set; }

    [ForeignKey("RequestClosedEmployee")] public int? RequestClosedBy { get; set; }

    public Employee? RequestClosedByEmployee { get; set; }
    public ICollection<RequestSolution>? RequestSolutions { get; set; }

    public override string ToString()
    {
        var tmp = $"\n\tId: {Id}\t\tMsg: {RequestMessage}" +
                  $"\n\tReqested On: {RequestDate}" +
                  $"\n\tStatus : {RequestStatus}" +
                  $"\n\tRaisedBy: {RaisedBy.Id}";

        return tmp + "\n\n";
    }
}