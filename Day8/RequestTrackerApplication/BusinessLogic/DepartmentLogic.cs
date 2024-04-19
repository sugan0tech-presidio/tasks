using RequestTrackerApplication.Exceptions;
using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public class DepartmentLogic : IDepartmentBL
{
    private readonly DepartmentRepository _departmentRepository = new();

    /// <summary>
    ///  Adds department to store using repository.
    /// </summary>
    /// <param name="department"></param>
    /// <returns>saved department</returns>
    /// <exception cref="DuplicatEntryException">If same department record present</exception>
    public Department Add(Department department)
    {
        return _departmentRepository.Add(department);
    }

    /// <summary>
    /// Updates Department
    /// </summary>
    /// <param name="department"></param>
    /// <returns>Updated Department</returns>
    /// <exception cref="KeyNotFoundException">If department ID doesn't exist</exception>
    public Department Update(Department department)
    {
        return _departmentRepository.Update(department);
    }

    /// <summary>
    ///  Adds Employee to department.
    /// </summary>
    /// <param name="deptId">Department Id</param>
    /// <param name="employee">Fetched Object of Employee.</param>
    /// <exception cref="KeyNotFoundException">If department ID doesn't exist</exception>
    public void AddEmployee(int deptId, Employee employee)
    {
        var dept = _departmentRepository.GetById(deptId);
        dept.Employees.Add(employee);
        _departmentRepository.Update(dept);
    }
    
    /// <summary>
    ///  Removes Employee from department.
    /// </summary>
    /// <param name="deptId">Department Id</param>
    /// <param name="employee">Fetched Object of Employee.</param>
    /// <exception cref="KeyNotFoundException">If department ID doesn't exist</exception>
    public void RemoveEmployee(int deptId, Employee employee)
    {
        var dept = _departmentRepository.GetById(deptId);
        dept.Employees.Remove(employee);
        _departmentRepository.Update(dept);
    }

    /// <summary>
    /// Deletes department by given name.
    /// </summary>
    /// <param name="name">Department Name as string</param>
    /// <returns>Deletion status</returns>
    /// <exception cref="InvalidDepartmentNameException">If department name doesn't exist</exception>
    public bool DeleteByName(string name)
    {
        int id;
        try
        {
            id = _departmentRepository.GetAll().First(dept => dept.Name.Equals(name)).Id;
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidDepartmentNameException($"No Department with the name\t:\t{name}");
        }

        return Delete(id);
    }

    /// <summary>
    ///  Deletes department
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns>Deletion status</returns>
    /// <exception cref="KeyNotFoundException">If department ID doesn't exist</exception>
    /// <exception cref="DepartmentInUseException">If Employees are in this Department</exception>
    public bool Delete(int departmentId)
    {
        int count = GetById(departmentId).Employees.Count;
        if (count > 0)
        {
            throw new DepartmentInUseException($"{count} employees are in this department, Delete them first!!");
        }

        return _departmentRepository.Delete(departmentId);
    }
 
    /// <summary>
    ///  Get department by Id
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns>Department Object</returns>
    /// <exception cref="KeyNotFoundException">If department ID doesn't exist</exception>
    public Department GetById(int departmentId)
    {
        return _departmentRepository.GetById(departmentId);
    }

    /// <summary>
    /// List all departments
    /// </summary>
    /// <returns>List of department</returns>
    public List<Department> GetAll()
    {
        return _departmentRepository.GetAll();
    }
}