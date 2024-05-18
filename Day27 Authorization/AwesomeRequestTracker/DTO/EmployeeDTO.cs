using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.DTO;

public record EmployeeDTO: PersonDTO
{
    public EmployeeDTO(string name, string contactNumber, string email, string? address, Role role) : base(name, contactNumber, email, address, role)
    {
    }

}