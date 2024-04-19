using RequestTrackerApplication.BusinessLogic;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Controller;

public class DepartmentController
{
    private readonly DepartmentLogic _departmentLogic = new();
    private readonly EmployeeLogic _employeeLogic = new();

    /// <summary>
    ///     To display all the departments details that are present in the record
    /// </summary>
    public void PrintAllDepartments()
    {
        var res = _departmentLogic.GetAll();
        if (res.Count == 0)
            Console.WriteLine("\n\t\t\tNo departments found!!!\n");
        foreach (var department in res)
            Console.WriteLine(department);
    }

    /// <summary>
    ///     Base for creating department from CLI
    /// </summary>
    public void CreateDepartment()
    {
        Console.WriteLine("Creating a new department...");
        Department department = new Department();

        Console.Write("Please enter the Department Name: ");
        department.Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Please enter the Department Head Employee Id: ");
        int departmentHeadId;
        while (!int.TryParse(Console.ReadLine(), out departmentHeadId))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for Department Head.");
            Console.Write("Please enter the Department Head: ");
        }

        department.DepartmentHead = _employeeLogic.GetById(departmentHeadId);

        _departmentLogic.Add(department);
    }

    /// <summary>
    ///     Gets Department Id from CLI and displays that department.
    /// </summary>
    public void SearchAndPrintDepartment()
    {
        Console.WriteLine("Print One department");
        var id = GetIdFromConsole();
        var department = _departmentLogic.GetById(id);

        PrintDepartment(department);
    }

    /// <summary>
    ///     Helper for getting Id from console. With added error handling.
    /// </summary>
    /// <returns> int representation of department id</returns>
    private int GetIdFromConsole()
    {
        int id;
        Console.Write("Please enter the Department Id: ");
        while (!int.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("\nInvalid entry. Please try again\n");

        return id;
    }

    /// <summary>
    ///     To display the given department with proper decoration.
    /// </summary>
    /// <param name="department"></param>
    private void PrintDepartment(Department department)
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine(department);
        Console.WriteLine("---------------------------");
    }

    /// <summary>
    ///     Updates name of department with the given Department Id.
    /// </summary>
    public void UpdateDepartmentNameById()
    {
        var id = GetIdFromConsole();
        var department = _departmentLogic.GetById(id);
        Console.WriteLine($"Enter the new name to be updated for {department.Name}:");
        department.Name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine($"Successfully updated as {department.Name}!!!\n");
    }

    /// <summary>
    ///     Deletes Department with the given Id.
    /// </summary>
    public void DeleteDepartmentById()
    {
        var id = GetIdFromConsole();
        _departmentLogic.Delete(id);
    }

    /// <summary>
    /// Deletes Department by name.
    /// </summary>
    public void DeleteDepartmentByName()
    {
        Console.WriteLine("Enter the name of the department to delete:");
        var name = Console.ReadLine() ?? "";

        // Check if the department with the given name exists
        var department = _departmentLogic.DeleteByName(name);

        Console.WriteLine(department ? $"{name} Department deleted" : $"Department with name '{name}' not found!");
    }
}