namespace AwesomePizzas.Models.DTO;

public record OrderDTO
{
    public int PizzaId { get; set; }

    // public Pizza Pizza { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public int UserId { get; set; }

    // public User User { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Placed;
    public string? Address { get; set; } = string.Empty;
    public double Price { get; set; }
}