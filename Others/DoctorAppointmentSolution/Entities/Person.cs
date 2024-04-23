namespace DoctorAppointmentManager.Entities;

public abstract class Person
{
    protected Person(DateTime dob, string name, string contactNumber, string email, int age, string address)
    {
        _dob = dob;
        Name = name;
        ContactNumber = contactNumber;
        Email = email;
        Age = age;
        Address = address;
    }

    protected Person(DateTime dob, int id, string name, string contactNumber, string email, int age, string address)
    {
        DateOfBirth = dob;
        Id = id;
        Name = name;
        ContactNumber = contactNumber;
        Email = email;
        Age = age;
        Address = address;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    private DateTime _dob;
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