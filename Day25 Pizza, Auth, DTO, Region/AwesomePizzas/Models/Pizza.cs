using System.ComponentModel.DataAnnotations;

namespace AwesomePizzas.Models;

public class Pizza : BaseEntity
{
    [Required] [MaxLength(50)] public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int stock { get; set; }
    public ICollection<Order> Orders { get; set; }
}