using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class FeedbackService: BaseService<SolutionFeedback>
{
    public FeedbackService(IBaseRepo<SolutionFeedback> repository) : base(repository)
    {
    }
}