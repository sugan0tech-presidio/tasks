namespace AwesomeRequestTracker.DTO;

public record FeedbackDTO
{
    public float Rating { get; set; }
    public string? Remarks { get; set; }
    public int SolutionId { get; set; }
    public int FeedbackBy { get; set; }
    public DateTime FeedbackDate { get; set; } = DateTime.Now;
}