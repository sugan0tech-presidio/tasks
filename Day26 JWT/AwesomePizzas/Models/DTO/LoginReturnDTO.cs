﻿namespace AwesomePizzas.Models.DTO;

public record LoginReturnDTO
{
    public LoginReturnDTO(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}