using ModelTest.Models;

namespace ModelTest;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var employee = new Employee
        {
            Id = 201,
            Name = "sugan0tech"
        };
        employee.DateOfBirth = new DateTime(2000,08,01);
        employee.Email = "sugan0tech@gmail.com";
        employee.Salary = 10000;
        Console.WriteLine(employee);
        Console.WriteLine($"salary after tax 10% :{employee.Salary}");
    }
}