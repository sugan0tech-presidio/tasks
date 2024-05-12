using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class RequestSolutionService: BaseService<RequestSolution>
{
    public RequestSolutionService(BaseRepo<RequestSolution> repository) : base(repository)
    {
    }
}