using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AwesomeRequestTracker.Models;

[Table("Registry")]
public class Registry : BaseEntity
{
    [ForeignKey("PersonId")] public int PersonId { get; set; }
    public Person Person { get; set; }

    [Required] public byte[] PasswordHash { get; set; }
    public byte[] HashKey { get; set; }
    public bool IsActivated { get; set; } = false;
}