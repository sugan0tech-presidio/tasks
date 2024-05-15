using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Repos;

namespace DoctorsAppointmentManager.Services;

public class DoctorService : BaseService<Doctor>, IDoctorService
{
    public DoctorService(IBaseRepo<Doctor> repository) : base(repository)
    {
    }

    public async Task<List<Doctor>> GetAllBySpeciality(Speciality speciality)
    {
        return Repository.GetAll().Result
            .ToList().FindAll(doc => doc.Speciality.Equals(speciality));
    }

    public async Task<Doctor> UpdateExperience(int id, int experience)
    {
        var doctor = await GetById(id);
        doctor.Experience = experience;
        await Update(doctor);
        return doctor;
    }

    public async Task<Doctor> UpdateSpeciality(int id, Speciality speciality)
    {
        var doctor = await GetById(id);
        doctor.Speciality = speciality;
        await Update(doctor);
        return doctor;
    }
}