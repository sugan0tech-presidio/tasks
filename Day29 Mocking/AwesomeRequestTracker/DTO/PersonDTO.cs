using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record PersonDTO
{
    public PersonDTO(string name, string contactNumber, string email, string? address, Role role)
    {
        Name = name;
        ContactNumber = contactNumber;
        Email = email;
        Address = address;
        Role = role;
    }

    public string Name { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public Role Role { get; set; } = Role.User;
}