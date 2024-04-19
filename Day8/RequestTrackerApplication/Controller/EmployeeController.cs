using RequestTrackerApplication.BusinessLogic;
using RequestTrackerApplication.Exceptions;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication.Controller;

public class EmployeeController
{
    private readonly EmployeeLogic _employeeLogic = new();
    private readonly DepartmentLogic _departmentLogic = new();

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

        try
        {
            BuildEmployeeFromConsole(employee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /// <summary>
    ///     Gets input from user and updates directly.
    /// </summary>
    private void BuildEmployeeFromConsole(Employee emp)
    {
        Console.Write("Please enter the Name\t:");
        emp.Name = Console.ReadLine() ?? string.Empty;
        try
        {
            Console.Write("Please enter the Date of birth\t:");
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
            throw new InvalidDOBFormatException("Should be in the form: YYYY-MM-DD");
        }

        emp = GetSalary(emp);
        _employeeLogic.Add(emp);
    }

    /// <summary>
    /// Gets salary details from the users ( routes based on Employee type )
    /// </summary>
    /// <param name="employee">Employee object</param>
    /// <returns>returns salary amount in double</returns>
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
    /// To display the given employee with proper decoration.
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
    private int GetIdFromConsole(string msg)
    {
        int id;
        Console.Write($"Please enter the {msg} Id\t:");
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
        var id = GetIdFromConsole("employee");
        try
        {
            var employee = _employeeLogic.GetById(id);
            PrintEmployee(employee);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }

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
        var id = GetIdFromConsole("employee");
        Employee employee;
        try
        {
            employee = SearchEmployeeById(id);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            return;
        }
        Console.WriteLine($"Enter the new name to be updated for {employee.Name}\t:");
        employee.Name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine($"Scuccessly updated as {SearchEmployeeById(id).Name}!!!\n");
    }

    /// <summary>
    ///     Deletes Employee with the given Id.
    /// </summary>
    public void DeleteEmployeeById()
    {
        var id = GetIdFromConsole("employee");
        try
        {
            _employeeLogic.Delete(id);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }
    }

    public void AddDepartment()
    {
        Console.WriteLine("Adding department to an employee...");

        // Get employee ID
        var employeeId = GetIdFromConsole("employee");

        // Get department ID
        foreach (var department1 in _departmentLogic.GetAll())
        {
            Console.WriteLine($"\n\t\t\t{department1.Id}. {department1.Name}");
        }

        Console.WriteLine("Enter the department ID to assign to the employee:");
        var departmentId = GetIdFromConsole("department");
        Department department;
        try
        {
            department = _departmentLogic.GetById(departmentId);
            _employeeLogic.AddDepartment(employeeId, departmentId);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            return;
        }

        Console.WriteLine($"Department '{department.Name}' assigned to employee '{_employeeLogic.GetById(employeeId).Name}' successfully!");
    }
}