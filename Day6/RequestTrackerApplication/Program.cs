using RequestTrackerModelLibrary;

namespace RequestTrackerApplication;

internal class Program
{
    private readonly Employee[] employees;

    public Program()
    {
        employees = new Employee[1];
    }

    /// <summary>
    ///     For displaying options list for Employees CRUD.
    /// </summary>
    private void PrintMenu()
    {
        Console.WriteLine(
            "\n1. Add Employee\n2. Print Employees\n3. Search Employee by ID\n4. Update Employee Name\n5. Delete Employee By Id\n0. Exit\n");
    }

    /// <summary>
    ///     Primary method to route user options to Employee CRUD operations.
    /// </summary>
    private void EmployeeInteraction()
    {
        int choice;
        do
        {
            PrintMenu();
            Console.Write("Please select an option\t:");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Bye.....");
                    break;
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    PrintAllEmployees();
                    break;
                case 3:
                    SearchAndPrintEmployee();
                    break;
                case 4:
                    UpdateNameById();
                    break;
                case 5:
                    DeleteEmployeeById();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again");
                    break;
            }
        } while (choice != 0);
    }

    /// <summary>
    ///     to add employees, gets input from cli
    /// </summary>
    private void AddEmployee()
    {
        if (employees[employees.Length - 1] != null)
        {
            Console.WriteLine("\nSorry we have reached the maximum number of employees\n");
            return;
        }

        var counter = 1;
        for (var i = 0; i < employees.Length; i++)
            if (employees[i] == null)
            {
                Console.WriteLine($"\nEnter details for employee, entry count: {counter}\n");
                employees[i] = CreateEmployee(i);
                counter++;
            }
    }

    /// <summary>
    ///     To display all the employees details that are present in the record
    /// </summary>
    private void PrintAllEmployees()
    {
        if (employees[0] == null)
        {
            Console.WriteLine("No Employees available !!!\n");
            return;
        }

        foreach (var employee in employees)
            if (employee != null)
                employee.PrintEmployeeDetails();
    }

    /// <summary>
    ///     Base for creating employee from cli
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private Employee CreateEmployee(int id)
    {
        Console.WriteLine("choose the type\t:\n\t1. Permanent (default)\n\t2. Contract");
        Employee employee;
        var opt = Console.ReadLine() ?? "1";

        if (opt == "2")
            employee = new ContractEmployee();
        else
            employee = new PermanentEmployee();

        employee.Id = 101 + id;
        try
        {
            employee.BuildEmployeeFromConsole();
        }
        catch (FormatException e)
        {
            Console.WriteLine(e);
            Console.WriteLine("Then Date of Birth should be in the form of YYYY-MM-DD");
            return null;
        }

        return employee;
    }

    /// <summary>
    ///     To display the given employee with proper decoration.
    /// </summary>
    /// <param name="employee"></param>
    private void PrintEmployee(Employee employee)
    {
        Console.WriteLine("---------------------------");
        employee.PrintEmployeeDetails();
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
    private void SearchAndPrintEmployee()
    {
        Console.WriteLine("Print One employee");
        var id = GetIdFromConsole();
        var employee = SearchEmployeeById(id);
        if (employee == null)
        {
            Console.WriteLine("\nNo such Employee is present\n");
            return;
        }

        PrintEmployee(employee);
    }

    /// <summary>
    ///     Fetches employee with the given Employee Id.
    /// </summary>
    /// <param name="id">Employee Id</param>
    /// <returns>Employee object if presents</returns>
    private Employee SearchEmployeeById(int id)
    {
        Employee employee = null;
        for (var i = 0; i < employees.Length; i++)
            if (employees[i] != null && employees[i].Id == id)
            {
                employee = employees[i];
                break;
            }

        return employee;
    }

    /// <summary>
    ///     Updates name of employee with the given Employee Id.
    /// </summary>
    private void UpdateNameById()
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
    private void DeleteEmployeeById()
    {
        var id = GetIdFromConsole();
        for (var i = 0; i < employees.Length; i++)
            if (employees[i] != null && employees[i].Id == id)
            {
                employees[i] = null;
                return;
            }
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program.EmployeeInteraction();
    }
}