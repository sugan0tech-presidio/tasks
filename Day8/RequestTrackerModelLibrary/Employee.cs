namespace RequestTrackerModelLibrary;

public class Employee
{
    private DateTime _dob;

    public Employee()
    {
        Id = 0;
        Name = string.Empty;
        DateOfBirth = new DateTime();
    }

    public Employee(int id, string name, DateTime dateOfBirth)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public int Age { get; private set; }

    /// <summary>
    ///     directly updates age with the given Date of Birth.
    /// </summary>
    public DateTime DateOfBirth
    {
        get => _dob;
        set
        {
            _dob = value;
            Age = (DateTime.Today - _dob).Days / 365;
        }
    }

    public override bool Equals(Object obj)
    {
        var tmp = (Employee) obj;
        return Equals(tmp);
    }

    protected bool Equals(Employee other)
    {
        return _dob.Equals(other._dob) && Id == other.Id && Name == other.Name && DepartmentId == other.DepartmentId && Age == other.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_dob, Id, Name, DepartmentId, Age);
    }

    public override string ToString()
    {
        return $"Employee {Id} Details:\n"
               +$"\tEmployee type\t:\t{GetType()}\n"
               +$"\tEmployee Name\t:\t{Name}\n"
               +$"\tEmployee DOB\t:\t{DateOfBirth}\n"
               +$"\tEmployee Age\t:\t{Age}\n";
    }

}