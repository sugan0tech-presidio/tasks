namespace ECommerceApp.Entities;

public class User: BaseEntity
{

    public User(string name, string email, string address)
    {
        Name = name;
        Email = email;
        Address = address;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    
    public bool Equals(User obj)
    {
        return Name.Equals(obj.Name) && Email.Equals(obj.Email);
    }

    public override string ToString()
    {
        return $"User\t: {Id}" +
               $"\n\tName\t: {Name}" +
               $"\n\tEmail\t: {Email}" +
               $"\n\tAddress\t: {Address}";
    }
}