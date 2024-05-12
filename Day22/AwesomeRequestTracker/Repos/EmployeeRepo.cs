using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Repos;

public class EmployeeRepo: BaseRepo<Employee>
{
    public EmployeeRepo(AwesomeRequestTrackerContext context) : base(context)
    {
    }
}