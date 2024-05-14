using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class RequestSolutionRepo : BaseRepo<RequestSolution>
{
    public RequestSolutionRepo(AwesomeRequestTrackerContext context) : base(context)
    {
    }
}