namespace RequestTrackerModelLibrary;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentHead { get; set; }
    public Employee[] Employees { get; set; }
}