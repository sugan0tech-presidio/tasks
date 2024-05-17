using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class UserService : BaseService<User>
{
    public UserService(BaseRepo<User> repository) : base(repository)
    {
    }
}