using RequestTrackerApplication.Exceptions;
using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public class EmployeeLogic : IEmployeeBL
{
    private readonly EmployeeRepository _employeeRepository = new();
    private readonly DepartmentLogic _departmentLogic = new();

    /// <summary>
    /// Adds employee to store
    /// </summary>
    /// <param name="employee">Employee obj without id</param>
    /// <returns></returns>
    /// <exception cref="DuplicatEntryException">If similar record of employee found</exception>
    public Employee Add(Employee employee)
    {
        return _employeeRepository.Add(employee);
    }

    /// <summary>
    ///  Updates existing employee with the Id.
    /// </summary>
    /// <param name="employee">Updated employee object</param>
    /// <returns>Updated ref of the Employee</returns>
    /// <exception cref="KeyNotFoundException">If no employee presents with that Id</exception>
    public Employee Update(Employee employee)
    {
        return _employeeRepository.Update(employee);
    }

    /// <summary>
    /// Adds departmentId to employee & updates in department
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="departmentId"></param>
    /// <returns></returns>
    /// <exception cref="KeyNotFoundException">If no employee presents with that Id</exception>
    public Employee AddDepartment(int employeeId, int departmentId)
    {
        var emp = _employeeRepository.GetById(employeeId);
        emp.DepartmentId = departmentId;
        _departmentLogic.AddEmployee(departmentId, emp);
        return _employeeRepository.Update(emp);
    }

    /// <summary>
    ///  Deletes an employee with the given Id.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Deletion status bool</returns>
    /// <exception cref="KeyNotFoundException">If no employee present with that Id</exception>
    public bool Delete(int employeeId)
    {
        return _employeeRepository.Delete(employeeId);
    }

    /// <summary>
    ///  Fetches employee with the given Id.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Fetched Employee</returns>
    /// <exception cref="KeyNotFoundException">If No employee presents</exception>
    public Employee GetById(int employeeId)
    {
        return _employeeRepository.GetById(employeeId);
    }

    /// <summary>
    ///  Gets the list of all Employees from the store
    /// </summary>
    /// <returns>List of Employees</returns>
    public List<Employee> GetAll()
    {
        return _employeeRepository.GetAll();
    }
}