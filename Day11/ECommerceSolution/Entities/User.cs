namespace ECommerceApp.Entities;

/// <summary>
///  User Entity.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Recommended Constructor for User
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="address"></param>
    public User(string name, string email, string address)
    {
        Name = name;
        Email = email;
        Address = address;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public override bool Equals(object? obj)
    {
        var item = obj as User;
        return base.Equals(obj) && Equals(item);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Email, Address);
    }

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