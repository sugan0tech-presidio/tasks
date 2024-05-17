namespace AwesomeRequestTracker.DTO;

public record FeedbackDTO
{
    private float Rating;
    string? Remarks;
    int SolutionId;
    int FeedbackBy;
    DateTime FeedbackDate = DateTime.Now;
}