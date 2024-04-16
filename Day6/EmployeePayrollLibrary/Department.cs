namespace EmployeePayrollLibrary;

public class Department
{
    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"department id : {Id} name : {Name}";
    }
}