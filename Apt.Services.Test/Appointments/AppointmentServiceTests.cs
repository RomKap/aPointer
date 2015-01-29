using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Apt.Core.Infrastructure;
using Apt.Core.Domain.Appointments;
using Rhino.Mocks;
using Apt.Services.Appointments;
using Apt.Data.Domain;

namespace Apt.Services.Test.Appointments
{
    [TestFixture]
    public class AppointmentServiceTests
    {
        public ICommonRepository<Appointee> _AppointeeRepo { get; set; }
        private IAppointmentService _AppointmentService;

        [SetUp]
        public new void SetUp()
        {
            _AppointeeRepo = MockRepository.GenerateMock<ICommonRepository<Appointee>>();

            Appointee apt1 = new Appointee()
            {
                ApteeID = 1,
                FirstName = "test1",
                LastName = "demo1"
            };

            Appointee apt2 = new Appointee()
            {
                ApteeID = 2,
                FirstName = "test2",
                LastName = "demo2"
            };

            _AppointeeRepo.Expect(x => x.FindAll()).Return(new List<Appointee>() { apt1, apt2 }.AsEnumerable());

            _AppointmentService = new AppointmentService();
            _AppointmentService.AppointeeRepo = _AppointeeRepo;

        }

        [Test]
        public void Ensure_only_two_Appointees_added()
        {
            var result = _AppointmentService.GetAllAppointee();
            Assert.AreEqual(2, result.Count);
            
        }

        //[Test]
        //public void Ensure_Appointees_is_deleted()
        //{
        //    var result = _AppointmentService.GetAllAppointee();
        //    Assert.AreEqual(3, result.Count);
        //}
    }
}
