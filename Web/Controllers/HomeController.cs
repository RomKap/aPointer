using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apt.Core;
using Apt.Services.Appointments;
using Apt.Core.Domain.Appointments;
using Microsoft.Practices.Unity;
using Web.Models;


namespace Web.Controllers
{
    public class HomeController : Controller
    {

        //private readonly IAppointmentService _AppointmentService;

        [Dependency]
        public IAppointmentService _AppointmentService { get; set; }

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Default/Details/5

        public ActionResult AllAppointee()
        {
           AppointeeViewModel apvm = new AppointeeViewModel();
           apvm.lstAppointee = _AppointmentService.GetAllAppointee();
           return View("../Appointments/Appointee", apvm);
        }

        [HttpPost]
        public ActionResult AllAppointee(AppointeeViewModel apvm)
        {
            Appointee aptee = new Appointee();
            aptee.FirstName = apvm.FirstName;
            aptee.LastName = apvm.LastName;
            aptee.CreatedOn = DateTime.Now;
            aptee.ModifiedOn = DateTime.Now;
            _AppointmentService.AddAppointee(aptee);

            return RedirectToAction("AllAppointee");
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

   
        public ActionResult DelAppointee(int ID)
        {      
            Appointee aptee = new Appointee();
            aptee.ApteeID = ID;
            _AppointmentService.DelAppointee(aptee);


            AppointeeViewModel apvm = new AppointeeViewModel();
            apvm.lstAppointee = _AppointmentService.GetAllAppointee();
            return View("../Appointments/Appointee", apvm);

        }
    }
}
