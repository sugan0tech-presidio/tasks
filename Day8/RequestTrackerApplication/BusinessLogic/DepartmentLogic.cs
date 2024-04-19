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