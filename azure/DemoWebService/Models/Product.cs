using System.ComponentModel.DataAnnotations;

namespace DemoWebService.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
}
