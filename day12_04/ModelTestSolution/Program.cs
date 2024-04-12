using ModelTest.Models;

namespace ModelTest;

class Program
{
    static void Main(string[] args)
    {
        var employee = new Employee(101)
        {
            Name = "sugan0tech"
        };
        employee.DateOfBirth = new DateTime(2000,08,01);
        employee.Email = "sugan0tech@gmail.com";
        employee.Salary = 10000;
        employee.PrintEmployeeDetails();
        
        var employee2 = new Employee(23, 2783.2, "suga", new DateTime(2001, 02, 20), "sie@mgia.com");
        employee2.PrintEmployeeDetails();


        var employees = new Employee[2];
        var program = new Program();
        for (int i = 0; i < employees.Length; i++)
            employees[i] = program.CreateEmployeeFromInput(i);

        foreach (var emp in employees)
            emp.PrintEmployeeDetails();

    }

    /// <summary>
    /// Takes employee info like Name, DOB, Salary & Email and returns Employee object
    /// </summary>
    /// <param name="id"></param>
    /// <returns>fully populated Employee object</returns>
    Employee CreateEmployeeFromInput(int id)
    {
        var employee = new Employee(id);
        Console.WriteLine("Please enter the employee name");
        employee.Name = Console.ReadLine();
        Console.WriteLine("Please enter the employee Date of Birth in the format of yyyy/mm/dd");
        employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Please enter the employee salary");
        double salary;
        while (!double.TryParse(Console.ReadLine(), out salary))
            Console.WriteLine("Invalid entry");
        employee.Salary = salary;
        Console.WriteLine("Please enter the employee mail");
        employee.Email = Console.ReadLine();
        
        return employee;
    }
}