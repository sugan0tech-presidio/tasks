using System.ComponentModel.DataAnnotations;

namespace AwesomeRequestTracker.Models;

public abstract class Person : BaseEntity
{
    [MaxLength(100)] [Required] public string Name { get; set; }
    [MaxLength(12)] public string ContactNumber { get; }
    [Required] public string Email { get; set; }
    public string? Address { get; set; }
    public ICollection<Request> RequestsRaised { get; set; }
    public ICollection<SolutionFeedback> FeedbacksGiven { get; set; }
    public Role Role { get; set; } = Role.BaseUser;

    public override bool Equals(object? obj)
    {
        var tmp = obj as Person;
        return Id == tmp.Id;
    }

    protected bool Equals(Person other)
    {
        return Name == other.Name && ContactNumber == other.ContactNumber && Email == other.Email;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ContactNumber, Email);
    }

    public override string ToString()
    {
        return $"Type\t:\t{GetType()}" +
               $"\n\tName\t: {Name}," +
               $"\n\tContact Number\t: {ContactNumber}," +
               $"\n\tEmail\t: {Email}," +
               $"\n\tAddress: {Address}";
    }
}