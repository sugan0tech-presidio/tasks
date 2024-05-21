namespace AwesomeRequestTracker.DTO;

public record SolutionDTO
{
    public SolutionDTO(int requestId, string solutionDescription, int solvedBy, bool isSolved, string? requestRaiserComment)
    {
        RequestId = requestId;
        SolutionDescription = solutionDescription;
        SolvedBy = solvedBy;
        IsSolved = isSolved;
        RequestRaiserComment = requestRaiserComment;
    }

    public int RequestId { get; }
    public string SolutionDescription { get; }
    public int SolvedBy { get; }
    public DateTime SolvedDate { get; }= DateTime.Now;
    public bool IsSolved { get;  }= false;
    public string? RequestRaiserComment { get; }
}