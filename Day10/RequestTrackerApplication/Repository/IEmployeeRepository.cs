using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Repository;

public interface IEmployeeRepository
{
    /// <summary>
    ///  Adds new employee.
    /// </summary>
    /// <param name="employee">Employee object</param>
    /// <returns></returns>
    Employee Add(Employee employee);

    /// <summary>
    ///  Updates existing employee.
    /// </summary>
    /// <param name="employee">Updated employee object</param>
    /// <returns>Updated ref of the Employee</returns>
    Employee Update(Employee employee);

    /// <summary>
    ///  Deletes an employee.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Deletion status</returns>
    bool Delete(int employeeId);

    /// <summary>
    ///  Fetches employee with the given Id.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Fetched Employee</returns>
    Employee GetById(int employeeId);

    /// <summary>
    ///  Gets the list of all Employees
    /// </summary>
    /// <returns>List of Employees</returns>
    List<Employee> GetAll();
}