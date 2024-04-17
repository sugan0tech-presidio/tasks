namespace DoctorsAppointmentLibrary;

public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    private int _age;
    private DateTime _dob;
    public int Age => _age;

    public DateTime DateOfBirth
    {
        get => _dob;
        set
        {
            _dob = value;
            _age = (DateTime.Today - _dob).Days / 365;
        }
    }

    public string Address { get; set; }

    public override bool Equals(object? obj)
    {
        Person? tmp = obj as Person;
        return Id == tmp.Id;
    }
    public override string ToString()
    {
        return $"Type\t:\t{GetType()}\n";
    }
}