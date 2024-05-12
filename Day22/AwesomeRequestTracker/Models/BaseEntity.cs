using System.ComponentModel.DataAnnotations;

namespace AwesomeRequestTracker.Models;

public class BaseEntity : IBase
{
    public BaseEntity(int id)
    {
        Id = id;
    }

    public BaseEntity()
    {
    }

    [Key] public int Id { get; set; }
}