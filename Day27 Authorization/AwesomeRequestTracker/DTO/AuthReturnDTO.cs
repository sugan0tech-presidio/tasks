using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record AuthReturnDTO()
{
    private string Email;
    private string Name;
    private Role Role;
    private string Token;
}