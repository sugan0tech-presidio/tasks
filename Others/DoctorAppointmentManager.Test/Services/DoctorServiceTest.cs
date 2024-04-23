using DoctorAppointmentManager.Entities;
using DoctorAppointmentManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManager.Test.Services
{
    public class DoctorServiceTest
    {
        private DoctorService doctorService;

        [SetUp]
        public void SetUP()
        {
            doctorService = new DoctorService(new());
        }

        [Test]
        public void AddTest()
        {
            Doctor doctor = new Doctor(DateTime.Parse("2000-12-12"), "sugan", "8888888888", "me@mail.com", 18, "adr", 5);
            doctorService.AddDoctor(doctor);
            Assert.AreEqual(doctor, doctorService.GetDoctorById(1));
        }
    }
}
