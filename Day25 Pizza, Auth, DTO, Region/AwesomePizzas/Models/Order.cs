using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizzas.Models;

public class Order: BaseEntity
{
    public DateTime OrderDate { get; set; }
    [ForeignKey("UserId")] public int UserId { get; set; }
    public User User { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Placed;
    public string? address { get; set; }

    public ICollection<Pizza> Pizzas { get; set; }
    public double Price { get; set; }
}