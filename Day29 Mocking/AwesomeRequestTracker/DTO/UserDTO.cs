using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record UserDTO: PersonDTO
{
    public UserDTO(string name, string contactNumber, string email, string? address) : base(name, contactNumber, email, address, Role.User)
    {
    }
}