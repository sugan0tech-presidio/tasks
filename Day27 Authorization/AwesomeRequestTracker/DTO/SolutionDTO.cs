namespace AwesomeRequestTracker.DTO;

public record SolutionDTO()
{
    public int RequestId { get; set; }
    public string SolutionDescription { get; set; }
    public int SolvedBy { get; set; }
    public DateTime SolvedDate { get; set; } = DateTime.Now;
    public bool IsSolved { get; set; } = false;
    public string? RequestRaiserComment { get; set; }
}