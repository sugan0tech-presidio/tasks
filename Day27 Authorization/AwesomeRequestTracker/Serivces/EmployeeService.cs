using AwesomeRequestTracker.Models;
using AwesomeRequestTracker.Repos;

namespace AwesomeRequestTracker.Serivces;

public class EmployeeService : BaseService<Employee>
{
    public EmployeeService(IBaseRepo<Employee> repository) : base(repository)
    {
    }
}