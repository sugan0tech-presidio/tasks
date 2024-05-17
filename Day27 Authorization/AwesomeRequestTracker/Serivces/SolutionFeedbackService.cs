using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class SolutionFeedbackService : BaseService<SolutionFeedback>
{
    public SolutionFeedbackService(IBaseRepo<SolutionFeedback> repository) : base(repository)
    {
    }
}