using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class UserRepo: BaseRepo<User>
{
    public UserRepo(AwesomeRequestTrackerContext context) : base(context)
    {
    }
}