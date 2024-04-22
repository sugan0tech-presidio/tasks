using PharmacyModels;

namespace PharmacyManagement.Repositories;

public class DoctorRepo: BaseEntityRepo<Doctor>
{
    public static readonly string[] Specializations =
    {
        "General Medicine",
        "Pediatrics",
        "Cardiology",
        "Orthopedics",
        "Neurology",
        "Dermatology",
        "Ophthalmology"
    };

    public static readonly string[] Qualifications =
    {
        "MBBS",
        "MD",
        "MS",
        "DM"
    };
    
    /// <summary>
    /// Filter doctors based on the speciality.
    /// </summary>
    /// <param name="speciality">string of speciality</param>
    /// <returns>selected list of doctors</returns>
    public List<Doctor> FilterBySpeciality(string speciality)
    {
        return _entities.Values.Where(d => d.Specialization.Contains(speciality)).ToList();
    }
}