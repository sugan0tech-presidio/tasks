using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("Requests")]
public class Request : BaseEntity
{
    public Person RequestRaisedBy { get; set; }
}