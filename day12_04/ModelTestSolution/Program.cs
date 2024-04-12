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
    }
}