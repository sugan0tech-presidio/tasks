using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }

        void PrintMenu()
        {
            Console.WriteLine("\n1. Add Employee\n2. Print Employees\n3. Search Employee by ID\n4. Update Employee Name\n5. Delete Employee By Id\n0. Exit\n");
        }

        void EmployeeInteraction()
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
            } while (choice !=0);
        }
        void AddEmployee()
        {
            if(employees[employees.Length - 1] != null)
            {
                Console.WriteLine("\nSorry we have reached the maximum number of employees\n");
                return;
            }

            var counter = 1;
            for(var i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    Console.WriteLine($"\nEnter details for employee, entry count: {counter}\n");
                    employees[i] = CreateEmployee(i);
                    counter++;
                }
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

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id;
            Console.Write($"Please enter the employee Id\t:");
            while(!int.TryParse(Console.ReadLine(), out id))
                Console.WriteLine("\nInvalid entry. Please try again\n");
            
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if(employee == null)
            {
                Console.WriteLine("\nNo such Employee is present\n");
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
            Console.WriteLine($"Scuccessly updated as {SearchEmployeeById(id).Name}!!!\n");
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
