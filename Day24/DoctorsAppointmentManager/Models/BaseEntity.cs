using System.ComponentModel.DataAnnotations;

namespace DoctorsAppointmentManager.Models;

public class BaseEntity
{
    [Key] public int Id { get; set; }
}