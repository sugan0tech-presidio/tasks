using RequestTrackerApplication.Controller;

namespace RequestTrackerApplication;

internal class Program
{
    private EmployeeController _employeeController;
    private DepartmentController _departmentController;

    public Program()
    {
        _employeeController = new EmployeeController();
        _departmentController = new DepartmentController();
    }

    /// <summary>
    ///     For displaying options list for Employees CRUD.
    /// </summary>
    private void PrintMenu()
    {
        Console.WriteLine(
            "\n1. Add Employee\n" +
            "2. Print Employees\n" +
            "3. Search Employee by ID\n" +
            "4. Update Employee\n" +
            "5. Delete Employee By Id\n" +
            "6. Add Department\n" +
            "7. List Department\n" +
            "8. Delete Department by Name\n" +
            "9. Delete Department by ID\n" +
            "10. Add Department to Employee\n" +
            "0. Exit\n");
    }

    /// <summary>
    ///     Primary method to route user options to Employee CRUD operations.
    /// </summary>
    private void EmployeeInteraction()
    {
        string choice;
        do
        {
            PrintMenu();
            Console.Write("Please select an option\t:");
            choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "0":
                    Console.WriteLine("Bye.....");
                    break;
                case "1":
                    _employeeController.CreateEmployee();
                    break;
                case "2":
                    _employeeController.PrintAllEmployees();
                    break;
                case "3":
                    _employeeController.SearchAndPrintEmployee();
                    break;
                case "4":
                    _employeeController.UpdateNameById();
                    break;
                case "5":
                    _employeeController.DeleteEmployeeById();
                    break;
                case "6":
                    _departmentController.CreateDepartment();
                    break;
                case "7":
                    _departmentController.PrintAllDepartments();
                    break;
                case "8":
                    _departmentController.DeleteDepartmentByName();
                    break;
                case "9":
                    _departmentController.DeleteDepartmentById();
                    break;
                case "10":
                    _employeeController.AddDepartment();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again");
                    break;
            }
        } while (choice != "0");
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program.EmployeeInteraction();
    }
}