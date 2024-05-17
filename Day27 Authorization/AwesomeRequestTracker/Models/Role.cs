using System.Runtime.Serialization;

namespace AwesomeRequestTracker.Models;

public enum Role
{
    [EnumMember(Value = "Admin")]
    Admin,
    [EnumMember(Value = "User")]
    User,
    [EnumMember(Value = "Manager")]
    Manager,
    [EnumMember(Value = "Assistant")]
    Assistant,
    [EnumMember(Value = "Intern")]
    Intern,
    [EnumMember(Value = "Consultant")]
    Consultant
}