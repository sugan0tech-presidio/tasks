using System.Runtime.Serialization;

namespace AwesomeRequestTracker.Models;

public enum Role
{
    [EnumMember(Value = "Admin")] Admin,
    [EnumMember(Value = "User")] User,
    [EnumMember(Value = "Employee")] Employee,
}