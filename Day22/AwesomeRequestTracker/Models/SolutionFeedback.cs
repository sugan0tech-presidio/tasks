using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("SolutionFeedbacks")]
public class SolutionFeedback : BaseEntity
{
    public float Rating { get; set; }
    public string? Remarks { get; set; }
    [ForeignKey("Solution")] public int SolutionId { get; set; }
    public RequestSolution Solution { get; set; }
    [ForeignKey("FeedbackEmployee")] public int FeedbackBy { get; set; }
    public Employee FeedbackByEmployee { get; set; }
    public DateTime FeedbackDate { get; set; }
}