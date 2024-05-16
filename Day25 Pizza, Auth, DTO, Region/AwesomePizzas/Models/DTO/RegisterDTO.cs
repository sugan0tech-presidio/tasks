namespace AwesomePizzas.Models.DTO;

public record RegisterDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}