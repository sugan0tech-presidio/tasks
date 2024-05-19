using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record PayloadDTO
{
    public PayloadDTO(int id, string email, Role role)
    {
        Id = id;
        Email = email;
        Role = role;
    }

    public int Id { get; }
    public string Email { get; }
    public Role Role { get; } 

}