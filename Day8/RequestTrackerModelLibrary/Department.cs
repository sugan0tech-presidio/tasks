namespace RequestTrackerModelLibrary;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentHead { get; set; }
    public List<Employee> Employees { get; set; } = new();
    
    public override bool Equals(object? obj)
    {
        var dept = obj as Department;
        return Id.Equals(dept.Id);
    }

    public override string ToString()
    {
        return $"Department {Id} Details:\n"
               +$"\tDepartment Name\t:\t{Name}\n"
               +$"\tDepartment Head\t:\t{DepartmentHead}\n"
               +$"\tEmployee Count\t:\t{Employees.Count}\n";
    }
}