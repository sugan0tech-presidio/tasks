using DoctorsAppointmentManager.Models;

namespace DoctorsAppointmentManager.Services;

public interface IDoctorService: IService<Doctor>
{
    public Task<List<Doctor>> GetAllBySpeciality(Speciality speciality);
    public Task<Doctor> UpdateExperience(int id, int experience);
    public Task<Doctor> UpdateSpeciality(int id, Speciality speciality);
}