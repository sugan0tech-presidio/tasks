using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomePizzas.Models;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    [ForeignKey("UserId")] public int UserId { get; set; }
    public User User { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Placed;
    public string? address { get; set; }

    [ForeignKey("PizzaId")] public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    
    public int Quantity { get; set; }
    public double Price { get; set; }
}