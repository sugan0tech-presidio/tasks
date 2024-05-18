using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record AuthReturnDTO
{
    public AuthReturnDTO(string email, string name, Role role, string token)
    {
        Email = email;
        Name = name;
        Role = role;
        Token = token;
    }

    public string Email { get; }
    public string Name { get; }
    public Role Role { get; }
    public string Token { get; }
}