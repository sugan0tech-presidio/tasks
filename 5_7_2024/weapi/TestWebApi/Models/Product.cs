using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models;

public class Product
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public double price { get; set; }
}