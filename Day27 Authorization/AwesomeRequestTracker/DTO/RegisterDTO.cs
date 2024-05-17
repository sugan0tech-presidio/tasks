using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record RegisterDTO()
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}