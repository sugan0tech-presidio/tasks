namespace DoctorsAppointmentLibrary.Repository;

public class PatientRepository : IRepository<int, Patient>
{
    private readonly List<Patient> _patients;

    public PatientRepository()
    {
        // Initialize the list of patients
        _patients = new List<Patient>();
    }

    public List<Patient> GetAll()
    {
        return _patients;
    }

    public Patient Get(int key)
    {
        return _patients.FirstOrDefault(p => p.Id == key);
    }

    public Patient Add(Patient item)
    {
        // Generating a unique id for the new patient
        var newId = _patients.Count > 0 ? _patients.Max(p => p.Id) + 1 : 1;
        item.Id = newId;
        _patients.Add(item);
        return item;
    }

    public Patient Update(Patient item)
    {
        // Find the patient in the list
        var existingPatient = _patients.FirstOrDefault(p => p.Id == item.Id);
        if (existingPatient != null)
        {
            // Update the patient's properties
            existingPatient.Name = item.Name;
            existingPatient.ContactNumber = item.ContactNumber;
        }

        return existingPatient;
    }

    public Patient Delete(int key)
    {
        // Find the patient in the list
        var patientToDelete = _patients.FirstOrDefault(p => p.Id == key);
        if (patientToDelete != null) _patients.Remove(patientToDelete);
        return patientToDelete;
    }
}