using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public class DepartmentLogic : IDepartmentBL
{
    private DepartmentRepository departmentRepository = new();

    public Department Add(Department department)
    {
        return departmentRepository.Add(department);
    }

    public Department Update(Department department)
    {
        return departmentRepository.Update(department);
    }

    public void AddEmployee(int deptId, Employee employee)
    {
        var dept = departmentRepository.GetById(deptId);
        dept.Employees.Add(employee);
        departmentRepository.Update(dept);
    }

    public bool DeleteByName(string name)
    {
        int id;
        try
        {
            id = departmentRepository.GetAll().First(dept => dept.Name.Equals(name)).Id;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"No Department with the name\t:\t{name}");
            return false;
        }

        return departmentRepository.Delete(id);
    }

    public bool Delete(int departmentId)
    {
        return departmentRepository.Delete(departmentId);
    }

    public Department GetById(int departmentId)
    {
        return departmentRepository.GetById(departmentId);
    }

    public List<Department> GetAll()
    {
        return departmentRepository.GetAll();
    }
}