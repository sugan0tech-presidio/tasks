using RequestTrackerApplication.BusinessLogic;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Controller;

public class EmployeeController
{
    private readonly EmployeeLogic _employeeLogic = new();
    private readonly DepartmentLogic _departmentLogic = new();
    private readonly DepartmentController _departmentController = new();

    /// <summary>
    ///     To display all the employees details that are present in the record
    /// </summary>
    public void PrintAllEmployees()
    {
        var res = _employeeLogic.GetAll();
        if (res.Count == 0)
            Console.WriteLine("\n\t\t\tNo employees found!!!\n");
        foreach (var employee in _employeeLogic.GetAll())
            Console.WriteLine(employee);
    }

    /// <summary>
    ///     Base for creating employee from cli
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public void CreateEmployee()
    {
        Console.WriteLine("choose the type\t:\n\t1. Permanent (default)\n\t2. Contract");
        Employee employee;
        var opt = Console.ReadLine() ?? "1";

        if (opt == "2")
            employee = new ContractEmployee();
        else
            employee = new PermanentEmployee();

        BuildEmployeeFromConsole(employee);
    }

    /// <summary>
    ///     Gets input from user and updates directly.
    /// </summary>
    private void BuildEmployeeFromConsole(Employee emp)
    {
        Console.Write("Please enter the Name\t:");
        emp.Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Please enter the Date of birth\t:");
        try
        {
            emp.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            while (emp.Age < 18)
            {
                Console.WriteLine("employee must be above 17");
                Console.Write("Please enter the Date of birth\t:");
                emp.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Then Date of Birth should be in the form of YYYY-MM-DD");
            return;
        }

        emp = GetSalary(emp);
        _employeeLogic.Add(emp);
    }

    private Employee GetSalary(Employee employee)
    {
        if (employee.GetType() == typeof(PermanentEmployee))
        {
            var tmpPe = employee as PermanentEmployee;
            Console.Write("Please enter the salary\t:");
            tmpPe.Salary = Convert.ToDouble(Console.ReadLine());
            return tmpPe;
        }

        var tmpCe = employee as ContractEmployee;
        Console.Write("Please enter the wages per day\t:");
        tmpCe.WagesPerDay = Convert.ToDouble(Console.ReadLine());
        return tmpCe;
    }

    /// <summary>
    ///     To display the given employee with proper decoration.
    /// </summary>
    /// <param name="employee"></param>
    private void PrintEmployee(Employee employee)
    {
        Console.WriteLine("---------------------------");
        Console.WriteLine(employee);
        Console.WriteLine("---------------------------");
    }

    /// <summary>
    ///     Helper for getting Id from console. With added error handeling.
    /// </summary>
    /// <returns> int representation of employee id</returns>
    private int GetIdFromConsole()
    {
        int id;
        Console.Write("Please enter the employee Id\t:");
        while (!int.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("\nInvalid entry. Please try again\n");

        return id;
    }

    /// <summary>
    ///     Gets Employee Id from CLI and displays that employee.
    /// </summary>
    public void SearchAndPrintEmployee()
    {
        Console.WriteLine("Print One employee");
        var id = GetIdFromConsole();
        var employee = _employeeLogic.GetById(id);

        PrintEmployee(employee);
    }

    /// <summary>
    ///     Fetches employee with the given Employee Id.
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <returns>Employee object if presents</returns>
    private Employee SearchEmployeeById(int id)
    {
        return _employeeLogic.GetById(id);
    }

    /// <summary>
    ///     Updates name of employee with the given Employee Id.
    /// </summary>
    public void UpdateNameById()
    {
        var id = GetIdFromConsole();
        var employee = SearchEmployeeById(id);
        Console.WriteLine($"Enter the new name to be updated for {employee.Name}\t:");
        employee.Name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine($"Scuccessly updated as {SearchEmployeeById(id).Name}!!!\n");
    }

    /// <summary>
    ///     Deletes Employee with the given Id.
    /// </summary>
    public void DeleteEmployeeById()
    {
        var id = GetIdFromConsole();
        _employeeLogic.Delete(id);
    }

    public void AddDepartment()
    {
        Console.WriteLine("Adding department to an employee...");

        // Get employee ID
        var employeeId = GetIdFromConsole();
        var employee = _employeeLogic.GetById(employeeId);

        // Get department ID
        foreach (var department1 in _departmentLogic.GetAll())
        {
            Console.WriteLine($"\n\t\t\t{department1.Id}. {department1.Name}");
        }

        Console.WriteLine("Enter the department ID to assign to the employee:");
        var departmentId = GetIdFromConsole();
        var department = _departmentLogic.GetById(departmentId);
        _departmentLogic.AddEmployee(department.Id, employee);

        // Assign department ID to the employee
        employee.DepartmentId = departmentId;

        // Update the employee using employee logic
        _employeeLogic.Update(employee);

        Console.WriteLine($"Department '{department.Name}' assigned to employee '{employee.Name}' successfully!");
    }
}