using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public interface IEmployeeBL
{
    Employee Add(Employee employee);
    Employee Update(Employee employee);
    bool Delete(int employeeId);
    Employee GetById(int employeeId);
    List<Employee> GetAll();
}