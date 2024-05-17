
using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class RegistryRepo: BaseRepo<Registry>
{
    public RegistryRepo(AwesomeRequestTrackerContext context): base(context)
    {
    }
}