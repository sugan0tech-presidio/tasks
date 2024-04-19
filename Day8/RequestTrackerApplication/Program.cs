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
                    _employeeController.CreateEmployee();
                    break;
                case 2:
                    _employeeController.PrintAllEmployees();
                    break;
                case 3:
                    _employeeController.SearchAndPrintEmployee();
                    break;
                case 4:
                    _employeeController.UpdateNameById();
                    break;
                case 5:
                    _employeeController.DeleteEmployeeById();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again");
                    break;
            }
        } while (choice != 0);
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program.EmployeeInteraction();
    }
}