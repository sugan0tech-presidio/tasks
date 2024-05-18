using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class RequestService : BaseService<Request>
{
    public RequestService(IBaseRepo<Request> repository) : base(repository)
    {
    }

    public override async Task<List<Request>> GetAll()
    {
        return base.GetAll().Result.FindAll(request => request.RequestClosedBy == null)
            .OrderBy(request => request.RequestDate).ToList();

    }
}