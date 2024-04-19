using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Repository;

public interface IDepartmentRepository
{
    /// <summary>
    ///  Adds new Department.
    /// </summary>
    /// <param name="department">department object</param>
    /// <returns></returns>
    Department Add(Department department);

    /// <summary>
    ///  Updates existing department.
    /// </summary>
    /// <param name="department">Updated department object</param>
    /// <returns>Updated ref of the department</returns>
    Department Update(Department department);

    /// <summary>
    ///  Deletes an department.
    /// </summary>
    /// <param name="deptId">Department Id</param>
    /// <returns>Deletion status</returns>
    bool Delete(int deptId);

    /// <summary>
    ///  Fetches department with the given Id.
    /// </summary>
    /// <param name="deptId">department Id</param>
    /// <returns>Fetched Department</returns>
    Department GetById(int deptId);

    /// <summary>
    ///  Gets the list of all Department
    /// </summary>
    /// <returns>List of Department</returns>
    List<Department> GetAll();
}