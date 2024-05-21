using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("Employees")]
public class Employee : Person
{
    public ICollection<Request> RequestsClosed { get; set; }
    public ICollection<RequestSolution> SolutionPrvided { get; set; }
}