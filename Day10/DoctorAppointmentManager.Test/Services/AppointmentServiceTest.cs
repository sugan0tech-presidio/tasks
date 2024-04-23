using DoctorAppointmentManager.Entities;
using DoctorAppointmentManager.Exceptions;
using DoctorAppointmentManager.Repository;
using DoctorAppointmentManager.Services;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManager.Test.Services
{
    public class AppointmentServiceTest
    {
        private AppointmentService appointmentService;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            appointmentService = new AppointmentService(new AppointmentRepository());
        }

        // Existing tests...

        [Test]
        public void GetAppointmentsForPatient_ValidPatient_ShouldReturnMatchingAppointments()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime appointmentDateTime1 = DateTime.Now.AddDays(1);
            DateTime appointmentDateTime2 = DateTime.Now.AddDays(2);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            Doctor doctor2 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor2", "", "", 40, "", 10);

            appointmentService.ScheduleAppointment(doctor1, patient, appointmentDateTime1, purpose);
            appointmentService.ScheduleAppointment(doctor2, patient, appointmentDateTime2, purpose);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForPatient(patient);

            // Assert
            Assert.NotNull(appointments);
            Assert.AreEqual(2, appointments.Count);
        }

        [Test]
        public void GetAppointmentsForPatient_EmptyResult_ShouldReturnEmptyList()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Nonexistent Patient", "", "", 30, "", "", "");

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForPatient(patient);

            // Assert
            Assert.NotNull(appointments);
            Assert.IsEmpty(appointments);
        }

        [Test]
        public void GetAppointmentsInDateRange_ValidRange_ShouldReturnMatchingAppointments()
        {
            // Arrange
            Doctor doctor = new Doctor(DateTime.Parse("1980-01-01"), "Doctor Name", "", "", 40, "", 10);
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Patient patient1 = new Patient(DateTime.Parse("1990-01-01"), "Patient1", "", "", 30, "", "", "");
            Patient patient2 = new Patient(DateTime.Parse("1990-01-01"), "Patient2", "", "", 30, "", "", "");
            Patient patient3 = new Patient(DateTime.Parse("1990-01-01"), "Patient3", "", "", 30, "", "", "");
            appointmentService.ScheduleAppointment(doctor, patient1, DateTime.Now, purpose);
            appointmentService.ScheduleAppointment(doctor, patient2, DateTime.Now.AddDays(-2), purpose);
            appointmentService.ScheduleAppointment(doctor, patient3, DateTime.Now.AddDays(2), purpose);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsInDateRange(startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.AreEqual(1, appointments.Count);
        }

        [Test]
        public void GetAppointmentsInDateRange_EmptyResult_ShouldReturnEmptyList()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(2);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsInDateRange(startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.IsEmpty(appointments);
        }

        [Test]
        public void GetAppointmentsInDateRange_InvalidRange_ShouldThrowException()
        {
            // Arrange
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(-1);

            // Act & Assert
            Assert.Throws<Exception>(() => appointmentService.GetAppointmentsInDateRange(startDate, endDate));

        }

        [Test]
        public void GetAppointmentsForDoctorInDateRange_ValidDoctorAndRange_ShouldReturnMatchingAppointments()
        {
            // Arrange
            Doctor doctor = new Doctor(DateTime.Parse("1980-01-01"), "Doctor Name", "", "", 40, "", 10);
            Doctor doctorOther = new Doctor(DateTime.Parse("1980-01-01"), "Doctor Other", "", "", 40, "", 10);
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Patient patient1 = new Patient(DateTime.Parse("1990-01-01"), "Patient1", "", "", 30, "", "", "");
            Patient patient2 = new Patient(DateTime.Parse("1990-01-01"), "Patient2", "", "", 30, "", "", "");
            Patient patient3 = new Patient(DateTime.Parse("1990-01-01"), "Patient3", "", "", 30, "", "", "");
            appointmentService.ScheduleAppointment(doctor, patient1, DateTime.Now, purpose);
            appointmentService.ScheduleAppointment(doctorOther, patient2, DateTime.Now.AddDays(-2), purpose);
            appointmentService.ScheduleAppointment(doctor, patient3, DateTime.Now.AddDays(2), purpose);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForDoctorInDateRange(doctor, startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.AreEqual(1, appointments.Count);
        }

        [Test]
        public void GetAppointmentsForDoctorInDateRange_EmptyResult_ShouldReturnEmptyList()
        {
            // Arrange
            Doctor doctor = new Doctor(DateTime.Parse("1980-01-01"), "Doctor Name", "", "", 40, "", 10);
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(2);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForDoctorInDateRange(doctor, startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.IsEmpty(appointments);
        }

        [Test]
        public void GetAppointmentsForDoctorInDateRange_InvalidTime_ShouldThrowException()
        {
            // Arrange
            Doctor doctor = new Doctor(DateTime.Parse("1980-01-01"), "Doctor Name", "", "", 40, "", 10);
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(-1);

            // Act
            Assert.Throws<Exception>(() => appointmentService.GetAppointmentsForDoctorInDateRange(doctor, startDate, endDate));
        }

        [Test]
        public void GetAppointmentsForPatientInDateRange_ValidPatientAndRange_ShouldReturnMatchingAppointments()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            Patient patientOther = new Patient(DateTime.Parse("1990-01-01"), "Patient other", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            Doctor doctor2 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor2", "", "", 40, "", 10);
            Doctor doctor3 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor3", "", "", 40, "", 10);
            appointmentService.ScheduleAppointment(doctor1, patient, DateTime.Now, purpose);
            appointmentService.ScheduleAppointment(doctor2, patientOther, DateTime.Now.AddDays(-2), purpose);
            appointmentService.ScheduleAppointment(doctor3, patient, DateTime.Now.AddDays(2), purpose);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForPatientInDateRange(patient, startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.AreEqual(1, appointments.Count);
        }

        [Test]
        public void GetAppointmentsForPatientInDateRange_InValidPatientAndRange_ShouldThrowException()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(-1);

            // Act & Assert
            Assert.Throws<Exception>(() => appointmentService.GetAppointmentsForPatientInDateRange(patient, startDate, endDate));
        }

        [Test]
        public void GetAppointmentsForPatientInDateRange_EmptyResult_ShouldReturnEmptyList()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddDays(2);

            // Act
            List<Appointment> appointments = appointmentService.GetAppointmentsForPatientInDateRange(patient, startDate, endDate);

            // Assert
            Assert.NotNull(appointments);
            Assert.IsEmpty(appointments);
        }

        [Test]
        public void GetAppointmentsForDoctor_GivenDoctor_ShouldReturnAppointments()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            Patient patientOther = new Patient(DateTime.Parse("1990-01-01"), "Patient other", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            Doctor doctor2 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor2", "", "", 40, "", 10);
            appointmentService.ScheduleAppointment(doctor1, patient, DateTime.Now, purpose);
            appointmentService.ScheduleAppointment(doctor2, patientOther, DateTime.Now.AddDays(-2), purpose);
            appointmentService.ScheduleAppointment(doctor2, patient, DateTime.Now.AddDays(2), purpose);
            
            // Act
            var appointments = appointmentService.GetAppointmentsForDoctor(doctor2);

            // Assert
            Assert.AreEqual(2, appointments.Count);
        }

        [Test]
        public void CreateAppointment_ForDupilcateAppointment_ShouldThrowDuplicateSchedule()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            DateTime date = DateTime.Now;
            appointmentService.ScheduleAppointment(doctor1, patient, date, purpose);

            // Act & Arrange
            Assert.Throws<DuplicateAppointmentException>(() => appointmentService.ScheduleAppointment(doctor1, patient, date, purpose));

        }

        [Test]
        public void UpdateAppointment_ActualValue_ShouldSaveAppointment()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            DateTime date = DateTime.Now;
            appointmentService.ScheduleAppointment(doctor1, patient, date, purpose);

            // Act
            DateTime Updatedate = DateTime.Now;
            Appointment updated = new Appointment(doctor1, patient, Updatedate, purpose);
            updated.Id = 1;
            appointmentService.UpdateAppointment(updated);

            // Assert
            Assert.That(appointmentService.GetAppointmentsInDateRange(startDate, endDate).FirstOrDefault().AppointmentDateTime, Is.EqualTo(Updatedate));
        }

        [Test]
        public void UpdateAppointment_InvalidKey_ShouldThrowInvalidKeyException()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            DateTime date = DateTime.Now;


            // Act & Assert
            Appointment appointment = new Appointment(doctor1, patient, date, purpose);
            Assert.Throws<KeyNotFoundException>(() => appointmentService.UpdateAppointment(appointment));
        }

        [Test]
        public void CanceledAppointment_WithId_ShouldDeleteAppointment()
        {
            // Arrange
            Patient patient = new Patient(DateTime.Parse("1990-01-01"), "Patient Name", "", "", 30, "", "", "");
            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate = DateTime.Now.AddDays(1);
            string purpose = "Regular checkup";
            Doctor doctor1 = new Doctor(DateTime.Parse("1980-01-01"), "Doctor1", "", "", 40, "", 10);
            DateTime date = DateTime.Now;
            appointmentService.ScheduleAppointment(doctor1, patient, date, purpose);

            // Act
            appointmentService.CancelAppointment(1);

            // Assert
            Assert.That(appointmentService.GetAppointmentsForDoctor(doctor1).Count, Is.EqualTo(0));
        }


        [Test]
        public void CanceledAppointment_WithInvalidId_ShouldThrowKeyNotFoundException()
        {

            // Act & Assert
            Assert.Throws<KeyNotFoundException>(() => appointmentService.CancelAppointment(2));
        }
    }
}
