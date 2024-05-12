using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class RequestService: BaseService<Request>
{
    public RequestService(BaseRepo<Request> repository) : base(repository)
    {
    }
}