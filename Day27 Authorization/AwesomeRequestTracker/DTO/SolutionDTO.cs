namespace AwesomeRequestTracker.DTO;

public record SolutionDTO()
{
    int RequestId;
    string SolutionDescription;
    int SolvedBy;
    DateTime SolvedDate = DateTime.Now;
    bool IsSolved = false;
    string? RequestRaiserComment;
}