using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record AuthReturn()
{
    public string Email { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
    public string Token { get; set; }
}