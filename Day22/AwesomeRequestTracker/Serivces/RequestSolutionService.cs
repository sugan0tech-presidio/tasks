using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class RequestSolutionService : BaseService<RequestSolution>
{
    public RequestSolutionService(BaseRepo<RequestSolution> repository) : base(repository)
    {
    }

    public async Task<RequestSolution> AddFeedback(SolutionFeedback solutionFeedback)
    {
        RequestSolution requestSolution = GetById(solutionFeedback.SolutionId).Result;
        requestSolution.Feedbacks.Add(solutionFeedback);
        Update(requestSolution);
        return requestSolution;
    }
}