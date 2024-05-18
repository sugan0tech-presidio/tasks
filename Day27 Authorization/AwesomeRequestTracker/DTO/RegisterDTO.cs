namespace AwesomeRequestTracker.DTO;

public record RegisterDTO
{
    public RegisterDTO(int id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }

    public int Id { get; }
    public string Email { get; }
    public string Password { get; }
}