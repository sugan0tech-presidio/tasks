using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record RegisterDTO()
{
    int Id;
    string Email;
    string Password;
}