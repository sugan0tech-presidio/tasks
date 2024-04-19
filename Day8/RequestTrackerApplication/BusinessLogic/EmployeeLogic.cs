using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public class EmployeeLogic: IEmployeeBL
{
    private EmployeeRepository employeeRepository = new();
    public Employee Add(Employee employee)
    {
        return employeeRepository.Add(employee);
    }

    public Employee Update(Employee employee)
    {
        return employeeRepository.Update(employee);
    }

    public bool Delete(int employeeId)
    {
        return employeeRepository.Delete(employeeId);
    }

    public Employee GetById(int employeeId)
    {
        return employeeRepository.GetById(employeeId);
    }

    public List<Employee> GetAll()
    {
        return employeeRepository.GetAll();
    }
}