using DoctorsAppointmentManager.services;
using DoctorsAppointmentManager.DoctorsAppointmentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsAppointmentManagementTest.services
{
    public class DoctorServiceTest
    {
        private DoctorService doctorService;

        [SetUp]
        public void SetUp()
        {
            doctorService = new DoctorService(new());
        }

        [Test]
        public void AddDoctorTest()
        {
            Doctor doctor = new Doctor();
            Assert.AreEqual(1,2);
        }
    }
}
