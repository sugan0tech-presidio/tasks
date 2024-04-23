using DoctorsAppointmentManager.services;
using DoctorsAppointmentManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DoctorsAppointmentManagementTest.services
{
    public class AppointmentServiceTest
    {

        private AppointmentService appointmentService;

        [SetUp]
        public void SetUp()
        {
            appointmentService = new AppointmentService(new AppointmentRepository());
        }

        [Test]
        public void AddTest()
        {
            Assert.Pass();
        }
    }
}
