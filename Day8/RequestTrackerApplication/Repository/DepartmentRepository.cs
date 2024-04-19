using System.Transactions;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private static readonly Dictionary<int, Department> DepartmentDict = new();

    /// <summary>
    ///  Adding new Department.
    /// </summary>
    /// <param name="department">Department object</param>
    /// <returns>Saved Department object</returns>
    /// <exception cref="Exception">If the department with same fields exist</exception>
    public Department Add(Department department)
    {
        if (DepartmentDict.Values.Any(dept => dept.Name.Equals(department.Name)))
            throw new Exception($"Department exists with same Name {department.Name}");

        // Generating employee ID also recycling deleted ids too in the sequence.
        var currSeq = 1;
        while (DepartmentDict.ContainsKey(currSeq))
            currSeq++;

        DepartmentDict.Add(currSeq, department);
        return DepartmentDict[currSeq];
    }

    /// <summary>
    ///  Updates given Department object based on the Id.
    /// </summary>
    /// <param name="department">Updated Department object</param>
    /// <returns></returns>
    /// <exception cref="Exception">If no Department found with the Id</exception>
    public Department Update(Department department)
    {
        if (!DepartmentDict.ContainsKey(department.Id))
            throw new Exception($"Department exists with same Id {department.Id}");

        DepartmentDict[department.Id] = department;
        return DepartmentDict[department.Id];
    }

    /// <summary>
    ///  Deletes department by Id.
    /// </summary>
    /// <param name="deptId">Deprtment Id</param>
    /// <returns>Deletion status</returns>
    /// <exception cref="Exception">If no deparment found with the Id</exception>
    public bool Delete(int deptId)
    {
        if (!DepartmentDict.ContainsKey(deptId))
            throw new Exception($"No Department exists with same Id {deptId}");

        return DepartmentDict.Remove(deptId);
    }

    /// <summary>
    ///  Gets Department with the given Id.
    /// </summary>
    /// <param name="deptId"></param>
    /// <returns>Department Object</returns>
    /// <exception cref="Exception">If no department found with Id</exception>
    public Department GetById(int deptId)
    {
        if (!DepartmentDict.TryGetValue(deptId, out var dept))
            throw new Exception($"No Department exists with same Id {deptId}");

        return dept;
    }

    /// <summary>
    /// Get's all the departmets.
    /// </summary>
    /// <returns>List of Department</returns>
    public List<Department> GetAll()
    {
        return DepartmentDict.Values.ToList();
    }
}