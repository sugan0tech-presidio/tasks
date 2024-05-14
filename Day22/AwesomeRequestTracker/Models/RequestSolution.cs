using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("RequestSolutions")]
public class RequestSolution : BaseEntity
{
    [ForeignKey("Request")] public int RequestId { get; set; }
    public Request RequestRaised { get; set; }

    public string SolutionDescription { get; set; }


    [ForeignKey("SolvedByEmployee")] public int SolvedBy { get; set; }
    public Employee SolvedByEmployee { get; set; }

    public DateTime SolvedDate { get; set; }
    public bool IsSolved { get; set; } = false;
    public string? RequestRaiserComment { get; set; }
    public ICollection<SolutionFeedback> Feedbacks { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\tIsSolved: {IsSolved}" +
               $"\nSolvedBy: {SolvedByEmployee.Name}" +
               $"\nDescription: {SolutionDescription}" +
               $"\nFeedbacks: {Feedbacks?.Count}";
    }
}