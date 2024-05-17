using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class UserService : BaseService<User>
{
    public UserService(IBaseRepo<User> repository) : base(repository)
    {
    }
}