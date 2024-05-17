using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class SolutionFeedbackRepo : BaseRepo<SolutionFeedback>
{
    public SolutionFeedbackRepo(AwesomeRequestTrackerContext context) : base(context)
    {
    }
}