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
        employee.Work();
        Console.WriteLine(employee.Name);
        employee.Salary = 10000;
        Console.WriteLine($"salary after tax 10% :{employee.Salary}");
    }
}