using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class SolutionFeedbackService : BaseService<SolutionFeedback>
{
    public SolutionFeedbackService(BaseRepo<SolutionFeedback> repository) : base(repository)
    {
    }
}