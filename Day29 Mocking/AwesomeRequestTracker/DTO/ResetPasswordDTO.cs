namespace AwesomeRequestTracker.DTO;

public class ResetPasswordDTO
{
    public ResetPasswordDTO(string email, string password, string newPassword)
    {
        Email = email;
        Password = password;
        NewPassword = newPassword;
    }

    public string Email { get; }
    public string Password { get; }
    public string NewPassword { get; }
}