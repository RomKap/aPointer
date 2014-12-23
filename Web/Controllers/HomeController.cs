using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apt.Core;
using Apt.Services.Appointments;
using Apt.Core.Domain.Appointments;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppointmentService _AppointmentService;

        public HomeController()
        {
            _AppointmentService = new AppointmentService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Default/Details/5

        public ActionResult AllAppointee()
        {
           List<Appointee> lst = _AppointmentService.GetAllAppointee();
           return View("../Appointments/Appointee", lst);
        }

        public ActionResult AddAppointee()
        {
            return View("../Appointments/AddAppointee");
        }

        [HttpPost]
        public ActionResult AddAppointee(Appointee aptee)
        {
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = DateTime.Now;         
            _AppointmentService.AddAppointee(aptee);
            return View(aptee);
        }
    }
}
