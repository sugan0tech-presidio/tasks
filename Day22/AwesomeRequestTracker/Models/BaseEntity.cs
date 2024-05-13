using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}