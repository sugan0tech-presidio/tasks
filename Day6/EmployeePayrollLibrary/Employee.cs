namespace EmployeePayrollLibrary;

public abstract class Employee : GovtRules
{
    public Employee()
    {
        EmpId = 0;
        Name = string.Empty;
    }

    public Employee(int empId, string name)
    {
        EmpId = empId;
        Name = name;
    }

    protected Employee(int empId, string name, int departmentId, string designation, double basicSalary)
    {
        EmpId = empId;
        Name = name;
        DepartmentId = departmentId;
        Designation = designation;
        BasicSalary = basicSalary;
    }

    public int EmpId { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public string Designation { get; set; }
    public double BasicSalary { get; set; }

    public abstract double EmployeePF(double basicSalary);
    public abstract string LeaveDetails();
    public abstract double GratuityAmount(float serviceCompleted, double basicSalary);

    /// <summary>
    ///     Gets input from user and updates directly.
    /// </summary>
    public virtual void BuildEmployeeFromConsole(Department[] deptList)
    {
        if (deptList.Length == 0)
        {
            Console.WriteLine("\nNo departments found!!!\n");
            return;
        }

        Console.Write("Please enter the Name\t:");
        Name = Console.ReadLine() ?? string.Empty;
        Console.Write("Please enter the Basic Salary\t:");
        BasicSalary = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please enter the Designation\t:");
        Designation = Console.ReadLine() ?? string.Empty;

        foreach (var department in deptList)
            Console.WriteLine(department);
        Console.Write("Pick one of the depart:");
        var deptId = int.Parse(Console.ReadLine());
    }

    public override string ToString()
    {
        return $"Employee {EmpId} Details:\n"
               + $"\tEmployee type\t:\t{GetType()}\n"
               + $"\tEmployee Name\t:\t{Name}\n"
               + $"\tDepartment\t:\t{DepartmentId}\n"
               + $"\tEmployee Age\t:\t{BasicSalary}\n";
    }
}