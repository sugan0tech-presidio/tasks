namespace AwesomeRequestTracker.DTO;

public record FeedbackDTO
{
    public FeedbackDTO(int id, float rating, string? remarks, int solutionId, int feedbackBy)
    {
        Id = id;
        Rating = rating;
        Remarks = remarks;
        SolutionId = solutionId;
        FeedbackBy = feedbackBy;
    }

    public int Id { get; }
    public float Rating { get; }
    public string? Remarks { get; }
    public int SolutionId { get; }
    public int FeedbackBy { get; }
    public DateTime FeedbackDate { get; }= DateTime.Now;
}