namespace DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;

public abstract class Person
{
    private DateTime _dob;
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public int Age { get; private set; }

    public DateTime DateOfBirth
    {
        get => _dob;
        set
        {
            _dob = value;
            Age = (DateTime.Today - _dob).Days / 365;
        }
    }

    public string Address { get; set; }

    public override bool Equals(object? obj)
    {
        var tmp = obj as Person;
        return Id == tmp.Id;
    }

    public override string ToString()
    {
        return $"Type\t:\t{GetType()}\n";
    }
}