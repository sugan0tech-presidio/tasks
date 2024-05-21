using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("SolutionFeedbacks")]
public class SolutionFeedback : BaseEntity
{
    public float Rating { get; set; }
    public string? Remarks { get; set; }
    [ForeignKey("Solution")] public int SolutionId { get; set; }
    public RequestSolution Solution { get; set; }
    [ForeignKey("FeedbackPerson")] public int FeedbackBy { get; set; }
    public Person FeedbackByPerson { get; set; }
    public DateTime FeedbackDate { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"\n\nId: {Id}\t\tRating: {Rating}" +
               $"\n\tRemarks: {Remarks}" +
               $"\n\tSolutionID: {Solution.Id} Description: {Solution.SolutionDescription}" +
               $"\n\tOn: {FeedbackDate}\n\n";
    }
}