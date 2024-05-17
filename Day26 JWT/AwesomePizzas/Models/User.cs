using System.ComponentModel.DataAnnotations;
using AwesomePizzas.Models.DTO;

namespace AwesomePizzas.Models;

public class User : BaseEntity
{
    [Required] public string Name { get; set; }
    [Required] public string Email { get; set; }
    public byte[] Password { get; set; }
    public byte[] PasswordHashKey { get; set; }
    public List<Order> Orders { get; set; }
    public LoginReturnDTO ToLoginReturnDto()
    {
        return new LoginReturnDTO(Name, Email);
    }
}