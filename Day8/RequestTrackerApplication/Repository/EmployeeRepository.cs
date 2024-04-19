using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Repository;

// Implementation of the repository using a Dictionary
public class EmployeeRepository : IEmployeeRepository
{
    private static readonly Dictionary<int, Employee> EmployeeDict = new();

    /// <summary>
    ///  Adds new employee to the store.
    ///  Id will be auto generated
    /// </summary>
    /// <param name="employee">Employee obj without id</param>
    /// <returns></returns>
    /// <exception cref="Exception">If similar employee found</exception>
    public Employee Add(Employee employee)
    {
        // Make sure no Employee with same info (Name, DOB & Dept) exists
        if (EmployeeDict.Values.Count(emp =>
                emp.Name.Equals(employee.Name) && emp.DepartmentId.Equals(employee.DepartmentId) &&
                emp.DateOfBirth.Equals(employee.DateOfBirth)) > 0)
            throw new Exception($"Similar record exists!!!\n {employee}");

        // Generating employee ID also recycling deleted ids too in the sequence.
        var currSeq = 1;
        while (EmployeeDict.ContainsKey(currSeq))
            currSeq++;

        employee.Id = currSeq;
        EmployeeDict.Add(currSeq, employee);
        return EmployeeDict[currSeq];
    }

    /// <summary>
    ///  Updates existing employee with the Id.
    /// </summary>
    /// <param name="employee">Updated employee object</param>
    /// <returns>Updated ref of the Employee</returns>
    /// <exception cref="Exception">If no employee presents with that Id</exception>
    public Employee Update(Employee employee)
    {
        if (!EmployeeDict.ContainsKey(employee.Id))
            throw new Exception("Id doesn't exit");

        EmployeeDict[employee.Id] = employee;
        return EmployeeDict[employee.Id];
    }

    /// <summary>
    ///  Deletes an employee with the given Id.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Deletion status bool</returns>
    /// <exception cref="Exception">If no employee present with that Id</exception>
    public bool Delete(int employeeId)
    {
        if (!EmployeeDict.ContainsKey(employeeId))
            throw new Exception($"Employee with {employeeId} doesn't exit");

        return EmployeeDict.Remove(employeeId);
    }

    /// <summary>
    ///  Fetches employee with the given Id.
    /// </summary>
    /// <param name="employeeId">Employee Id</param>
    /// <returns>Fetched Employee</returns>
    /// <exception cref="Exception">If No employee presents</exception>
    public Employee GetById(int employeeId)
    {
        if (!EmployeeDict.TryGetValue(employeeId, out var emp))
            throw new Exception($"Employee with {employeeId} doesn't exit");

        return emp;
    }

    /// <summary>
    ///  Gets the list of all Employees from the store
    /// </summary>
    /// <returns>List of Employees</returns>
    public List<Employee> GetAll()
    {
        return EmployeeDict.Values.ToList();
    }
}