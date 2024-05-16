using System.ComponentModel.DataAnnotations;

namespace AwesomePizzas.Models;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}