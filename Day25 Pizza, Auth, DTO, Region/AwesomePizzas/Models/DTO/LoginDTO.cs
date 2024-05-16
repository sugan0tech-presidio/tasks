namespace AwesomePizzas.Models.DTO;

public record LoginDTO
{
    public int Id { get; set; }
    public string Password { get; set; }
}