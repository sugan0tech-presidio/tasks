﻿namespace AwesomeRequestTracker.DTO;

public record LoginDTO
{
    public LoginDTO(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }
    public string Password { get; }
}