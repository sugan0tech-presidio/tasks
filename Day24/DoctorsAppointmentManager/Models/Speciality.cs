using System.Runtime.Serialization;

namespace DoctorsAppointmentManager.Models;

public enum Speciality
{
    [EnumMember(Value = "General")] GENERAL,
    [EnumMember(Value = "Cardio")] CARDIO,
    [EnumMember(Value = "Ortho")] ORTHO,
    [EnumMember(Value = "Dental")] DENTAL,
    [EnumMember(Value = "Ent")] ENT,
    [EnumMember(Value = "Gastro")] GASTRO
}