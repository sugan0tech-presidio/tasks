using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public class EmployeeLogic : IEmployeeBL
{
    private readonly EmployeeRepository _employeeRepository = new();

    public Employee Add(Employee employee)
    {
        return _employeeRepository.Add(employee);
    }

    public Employee Update(Employee employee)
    {
        return _employeeRepository.Update(employee);
    }

    public bool Delete(int employeeId)
    {
        return _employeeRepository.Delete(employeeId);
    }

    public Employee GetById(int employeeId)
    {
        return _employeeRepository.GetById(employeeId);
    }

    public List<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }
}