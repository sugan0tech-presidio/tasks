using DoctorAppointmentManager.Entities;
using DoctorAppointmentManager.Exceptions;
using DoctorAppointmentManager.Repository;
using DoctorAppointmentManager.Services;

namespace DoctorAppointmentManager.Test.Services
{
    public class DoctorServiceTest
    {
        private DoctorService doctorService;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            doctorService = new DoctorService(new DoctorRepository());
        }

        [Test]
        public void AddDoctor_ValidDoctor_ShouldAddSuccessfully()
        {
            // Act
            Doctor doctorToAdd = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            Doctor addedDoctor = doctorService.AddDoctor(doctorToAdd);

            // Assert
            Assert.NotNull(addedDoctor);
            Assert.That(addedDoctor, Is.EqualTo(doctorToAdd));
        }

        [Test]
        public void AddDoctor_NullDoctor_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => doctorService.AddDoctor(null));
        }

        [Test]
        public void AddDoctor_DuplicateDoctor_ShouldThrowDuplicateDoctorException()
        {
            // Arrange
            Doctor doctorToAdd = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctorService.AddDoctor(doctorToAdd);

            // Act & Assert
            Assert.Throws<DuplicateDoctorException>(() => doctorService.AddDoctor(doctorToAdd));
        }

        [Test]
        public void GetDoctorById_ExistingId_ShouldReturnDoctor()
        {
            // Arrange
            Doctor doctorToAdd = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctorService.AddDoctor(doctorToAdd);

            // Act
            Doctor retrievedDoctor = doctorService.GetDoctorById(1);

            // Assert
            Assert.NotNull(retrievedDoctor);
            Assert.That(retrievedDoctor, Is.EqualTo(doctorToAdd));
        }

        [Test]
        public void GetDoctorById_NonExistingId_ShouldThrowDoctorNotFoundException()
        {
            // Act & Assert
            Assert.Throws<DoctorNotFoundException>(() => doctorService.GetDoctorById(999));
        }

        [Test]
        public void UpdateDoctor_ExistingDoctor_ShouldUpdateSuccessfully()
        {
            // Arrange
            Doctor doctorToAdd = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctorService.AddDoctor(doctorToAdd);
            doctorToAdd.Name = "Updated Name";

            // Act
            Doctor updatedDoctor = doctorService.UpdateDoctor(doctorToAdd);

            // Assert
            Assert.NotNull(updatedDoctor);
            Assert.That(updatedDoctor, Is.EqualTo(doctorToAdd));
        }

        [Test]
        public void UpdateDoctor_NullDoctor_ShouldThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => doctorService.UpdateDoctor(null));
        }

        [Test]
        public void UpdateDoctor_NonExistingDoctor_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            Doctor nonExistingDoctor = new Doctor(DateTime.Parse("2000-12-12"), "Non Existing Doctor", "8888888888", "non.existing@mail.com", 18, "Address", 5);

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => doctorService.UpdateDoctor(nonExistingDoctor));
        }

        [Test]
        public void DeleteDoctor_ExistingId_ShouldDeleteSuccessfully()
        {
            // Arrange
            Doctor doctorToAdd = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctorService.AddDoctor(doctorToAdd);

            // Act
            Doctor deletedDoctor = doctorService.DeleteDoctor(1);

            // Assert
            Assert.NotNull(deletedDoctor);
            Assert.AreEqual(doctorToAdd, deletedDoctor);
        }

        [Test]
        public void DeleteDoctor_NonExistingId_ShouldThrowKeyNotFoundException()
        {
            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => doctorService.DeleteDoctor(999));
        }

        [Test]
        public void FilterDoctorsBySpecialization_ValidSpecialization_ShouldReturnMatchingDoctors()
        {
            // Arrange
            string specialization = "Cardiology";
            Doctor doctor1 = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctor1.Specialization.Add(specialization);
            Doctor doctor2 = new Doctor(DateTime.Parse("2000-12-12"), "Jane Doe", "7777777777", "jane.doe@mail.com", 19, "Address", 6);
            doctor2.Specialization.Add(specialization);
            doctorService.AddDoctor(doctor1);
            doctorService.AddDoctor(doctor2);

            // Act
            List<Doctor> filteredDoctors = doctorService.FilterDoctorsBySpecialization(specialization);

            // Assert
            Assert.NotNull(filteredDoctors);
            Assert.That(filteredDoctors.Count, Is.EqualTo(2));
        }

        [Test]
        public void FilterDoctorsBySpecialization_InvalidSpecialization_ShouldReturnEmptyList()
        {
            // Act
            List<Doctor> filteredDoctors = doctorService.FilterDoctorsBySpecialization("Invalid Specialization");

            // Assert
            Assert.NotNull(filteredDoctors);
            Assert.That(filteredDoctors.Count, Is.EqualTo(0));
        }

        [Test]
        public void FindDoctorsBySpeciality_ValidSpeciality_ShouldReturnMatchingDoctors()
        {
            // Arrange
            string speciality = "Cardiology";
            Doctor doctor1 = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            doctor1.Specialization.Add(speciality);
            Doctor doctor2 = new Doctor(DateTime.Parse("2000-12-12"), "Jane Doe", "7777777777", "jane.doe@mail.com", 19, "Address", 6);
            doctor2.Specialization.Add(speciality);
            doctorService.AddDoctor(doctor1);
            doctorService.AddDoctor(doctor2);

            // Act
            List<Doctor> foundDoctors = doctorService.FindDoctorsBySpeciality(speciality);

            // Assert
            Assert.NotNull(foundDoctors);
            Assert.That(foundDoctors.Count, Is.EqualTo(2));
        }

        [Test]
        public void FindDoctorsBySpeciality_InvalidSpeciality_ShouldReturnEmptyList()
        {
            // Act
            List<Doctor> foundDoctors = doctorService.FindDoctorsBySpeciality("Invalid Speciality");

            // Assert
            Assert.NotNull(foundDoctors);
            Assert.That(foundDoctors.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetAllDoctors_WithValues()
        {
            Doctor doctor1 = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            Doctor doctor2 = new Doctor(DateTime.Parse("2000-12-12"), "Jane Doe", "7777777777", "jane.doe@mail.com", 19, "Address", 6);
            doctorService.AddDoctor(doctor1);
            doctorService.AddDoctor(doctor2);

            List<Doctor> doctors = doctorService.GetAllDoctors();
            Assert.That(doctors.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetAllDoctors_WithOutValues()
        {
            List<Doctor> doctors = doctorService.GetAllDoctors();
            Assert.That(doctors.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetAllDoctors_WithDeletedValues()
        {
            Doctor doctor1 = new Doctor(DateTime.Parse("2000-12-12"), "John Doe", "8888888888", "john.doe@mail.com", 18, "Address", 5);
            Doctor doctor2 = new Doctor(DateTime.Parse("2000-12-12"), "Jane Doe", "7777777777", "jane.doe@mail.com", 19, "Address", 6);
            doctorService.AddDoctor(doctor1);
            doctorService.AddDoctor(doctor2);

            doctorService.DeleteDoctor(1);
            List<Doctor> doctors = doctorService.GetAllDoctors();
            Assert.That(doctors.Count, Is.EqualTo(1));
        }
    }
}
