using RequestTrackerApplication.Repository;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.BusinessLogic;

public interface IDepartmentBL
{
        Department Add(Department department);
        Department Update(Department department);
        bool Delete(int departmentId);
        Department GetById(int departmentId);
        List<Department> GetAll();}