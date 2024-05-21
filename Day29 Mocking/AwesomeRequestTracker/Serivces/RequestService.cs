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
    
    /// <summary>
    /// Retrieves all entities asynchronously with the respective user.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<Request>> GetAll(int id, Role role)
    {
        if (role.Equals(Role.Admin))
            return await GetAll();
        
        return GetAll().Result.FindAll(request => request.RequestRaisedById.Equals(id));
    }

}