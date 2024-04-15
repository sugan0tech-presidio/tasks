using System.Net;
using System.Threading.Channels;
using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[1];
        }

        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee\n2. Print Employees\n3. Search Employee by ID\n4. Update Employee Name\n5. Delete Employee By Id\n0. Exit\n");
        }

        void EmployeeInteraction()
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
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
            } while (choice !=0);
        }
        void AddEmployee()
        {
            if(employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees\n");
                return;
            }
            for(var i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                    employees[i] = CreateEmployee(i);
            }
                
        }
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available !!!\n");
                return;
            }

            foreach (var employee in employees)
            {
                if (employee != null)
                    employee.PrintEmployeeDetails();
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101+ id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id;
            Console.WriteLine("Please enter the employee Id");
            while(!int.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("Invalid entry. Please try again");
            
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if(employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
               if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        void UpdateNameById()
        {
            int id = GetIdFromConsole();
            var employee = SearchEmployeeById(id);
            Console.WriteLine($"Enter the new name to be updated for {employee.Name}\t:");
            employee.Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine($"Scuccessly updated as {SearchEmployeeById(id).Name}!!!");
        }

        void DeleteEmployeeById()
        {
            int id = GetIdFromConsole();
            for (int i = 0; i < employees.Length; i++)
            {
               if (employees[i] != null && employees[i].Id == id)
               {
                   employees[i] = null;
                   return;
               }
            }
            
        }

        static void Main(string[] args)
        {
           var program = new Program();
           program.EmployeeInteraction();
        }
    }    
}
