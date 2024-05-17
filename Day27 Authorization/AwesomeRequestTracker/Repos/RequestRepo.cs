using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class RequestRepo : BaseRepo<Request>
{
    public RequestRepo(AwesomeRequestTrackerContext context) : base(context)
    {
    }
}