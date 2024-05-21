namespace AwesomeRequestTracker.DTO;

public record LoginReturnDTO
{
    public LoginReturnDTO(string token)
    {
        Token = token;
    }

    public string Token { get; }
}