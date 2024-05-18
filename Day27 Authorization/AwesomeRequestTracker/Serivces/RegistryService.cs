using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class RegistryService: BaseService<Registry>
{
    public RegistryService(IBaseRepo<Registry> repository) : base(repository)
    {
    }
}